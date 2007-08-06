//
// XamlReader.cs: this is a reader that wraps Ian McCoy's Xaml Reader
// that he wrote for the Google Summer of Code 2005 and exposes the
// API required in Silverlight.
//
// Author:
//   Miguel de Icaza (miguel@novell.com)
//
// Copyright 2007 Novell, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using Mono;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace System.Windows {
	
	public static class XamlReader {
	
		internal static CreateCustomXamlElementCallback custom_el_cb = new CreateCustomXamlElementCallback (create_element);
		internal static SetCustomXamlAttributeCallback custom_at_cb = new SetCustomXamlAttributeCallback (set_attribute);
		internal static XamlHookupEventCallback hookup_event_cb = new XamlHookupEventCallback (hookup_event);

		static XamlReader () {
			NativeMethods.xaml_set_parser_callbacks (custom_el_cb, custom_at_cb, hookup_event_cb);
		}

		public static DependencyObject Load (string xaml)
		{
			DependencyObject.Ping ();
			return Load (xaml, false);
		}
		
		public static DependencyObject Load (string xaml, bool createNamescope)
		{
			if (xaml == null)
				throw new ArgumentNullException ("xaml");

			DependencyObject.Ping ();
			Kind kind;
			IntPtr top = NativeMethods.xaml_create_from_str (xaml, createNamescope, out kind);

			if (top == IntPtr.Zero)
				return null;

			return DependencyObject.Lookup (kind, top);
		}

		//
		// Proxy so that we return IntPtr.Zero in case of any failures, instead of
		// genreating an exception and unwinding the stack.
		//
		internal static IntPtr create_element (string xmlns, string name)
		{
			try {
				return real_create_element (xmlns, name);
			} catch {
				return IntPtr.Zero;
			} finally {
				Console.WriteLine ("create_element: returning");
			}
			
		}
		
		internal static IntPtr real_create_element (string xmlns, string name)
		{
			string ns;
			string type_name;
			string asm_path;

			ParseXmlns (xmlns, out type_name, out ns, out asm_path);

			if (asm_path == null) {
				Console.Error.WriteLine ("XamlReader, create_element: unable to parse xmlns string: '{0}'", xmlns);
				return IntPtr.Zero;
			}

			Console.Error.WriteLine ("XamlReader: Loading assembly from {0}", asm_path);

			// TODO: Use a downloader here
			Assembly clientlib = Moonlight.LoadFile (asm_path);
			if (clientlib == null) {
				Console.Error.WriteLine ("XamlReader, create_element: could not load client library: '{0}'", asm_path);
				return IntPtr.Zero;
			}

			if (type_name != null)
				name = type_name;

			if (ns != null)
				name = String.Concat (ns, ".", name);

			object r = clientlib.CreateInstance (name);
			if (r == null){
				Console.Error.WriteLine ("XamlReader, create_element: unable to create object instance:  '{0}'",
							 name);
				return IntPtr.Zero;
			}
			DependencyObject res = r as DependencyObject;
			if (res == null){
				Console.WriteLine ("Object is not a dependency object:  '{0}'", r.GetType ());
				return IntPtr.Zero;
			}

			IntPtr p = Hosting.GetNativeObject (res);
			return p;
		}

		private static TypeConverter GetConverterFor (PropertyInfo info)
		{
			Attribute[] attrs = (Attribute[])info.GetCustomAttributes (true);
			TypeConverterAttribute at = null;
			TypeConverter converter = null;

			foreach (Attribute attr in attrs) {
				if (attr is TypeConverterAttribute) {
					at = (TypeConverterAttribute)attr;
					break;
				}
			}

			if (at == null || at == TypeConverterAttribute.Default)
				converter = TypeDescriptor.GetConverter (info.PropertyType);
			else {
				Type t = Type.GetType (at.ConverterTypeName);
				if (t == null) {
					converter = TypeDescriptor.GetConverter (info.PropertyType);
				}
				else {
					ConstructorInfo ci = t.GetConstructor (new Type[] { typeof(Type) });
					if (ci != null)
						converter = (TypeConverter) ci.Invoke (new object[] { info.PropertyType });
					else
						converter = (TypeConverter) Activator.CreateInstance (t);
				}
			}
			return converter;
		}
		
		//
		// Proxy to prevent exceptions from being returned to unmanaged code.
		//
		internal static void set_attribute (IntPtr target_ptr, string name, string value)
		{
			try {
				real_set_attribute (target_ptr, name, value);
			} catch {
			}
		}
		
		internal static void real_set_attribute (IntPtr target_ptr, string name, string value)
		{
			DependencyObject target = DependencyObject.Lookup (target_ptr);

			if (target == null) {
				Console.Error.WriteLine ("XamlReader, set_attribute: unable to create target object from: 0x{0:x}",
							 target_ptr);
				return;
			}

			PropertyInfo pi = target.GetType().GetProperty (name);

			if (pi == null) {
				Console.Error.WriteLine (
				    "XamlReader, set_attribute: unable to set property ({0}) no property descriptor found", name);
				return;
			}

			TypeConverter converter = GetConverterFor (pi);
			if (!converter.CanConvertFrom (typeof (string))) {
				//
				// MS does not seem to handle this yet either, but I think a logical improvement
				// here is to call back into unmanaged code something like xaml_create_object_from_str
				// with the attribute string, and see if the managed code can parse it, this would
				// allow you to stick things like Colors and KeySplines on your object and still have
				// custom setters
				//
				Console.Error.WriteLine ("XamlReader, set_attribute: unable to convert property '{0}' from a string", name);
				return;
			}

			pi.SetValue (target, converter.ConvertFrom (value), null);
		}

		//
		// Proxy to prevent exceptions from being returned to unmanaged code.
		//
		internal static void hookup_event (IntPtr target_ptr, string name, string value)
		{
			try {
				real_hookup_event (target_ptr, name, value);
			} catch {
			}
		}
			
		internal static void real_hookup_event (IntPtr target_ptr, string name, string value)
		{
			Kind k = NativeMethods.dependency_object_get_object_type (target_ptr);
			DependencyObject target = DependencyObject.Lookup (k, target_ptr);

			if (target == null) {
				Console.Error.WriteLine ("XamlReader, hookup_event: unable to create target object from: 0x{0:x}",
							 target_ptr);
				return;
			}

			EventInfo src = target.GetType ().GetEvent (name);
			if (src == null) {
				Console.Error.WriteLine ("Xamlreader, hookup_event: unable to find event to hook to: '{0}'.", name);
				return;
			}

			Delegate d = Delegate.CreateDelegate (src.EventHandlerType, target, value);
			if (d == null) {
				Console.Error.WriteLine ("XamlReader, hookup_event: unable to create delegate.");
				return;
			}

			src.AddEventHandler (target, d);
		}

		internal static void ParseXmlns (string xmlns, out string type_name, out string ns, out string asm)
		{
			type_name = null;
			ns = null;
			asm = null;

			string [] decls = xmlns.Split (';');
			foreach (string decl in decls) {
				if (decl.StartsWith ("clr-namespace:")) {
					ns = decl.Substring (14, decl.Length - 14);
					continue;
				}
				if (decl.StartsWith ("assembly=")) {
					asm = decl.Substring (9, decl.Length - 9);
					continue;
				}
				type_name = decl;
			}
		}
	}
}
