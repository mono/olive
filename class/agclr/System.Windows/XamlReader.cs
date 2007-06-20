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
using System.Xml;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace System.Windows {
	
	public static class XamlReader {
	
		static CreateCustomXamlElementCallback custom_el_cb = new CreateCustomXamlElementCallback (create_element);
		static SetCustomXamlAttributeCallback custom_at_cb = new SetCustomXamlAttributeCallback (set_attribute);
		static XamlHookupEventCallback hookup_event_cb = new XamlHookupEventCallback (hookup_event);

		public static DependencyObject Load (string xaml)
		{
			return Load (xaml, true);
		}
		
		public static DependencyObject Load (string xaml, bool createNamescope)
		{
			if (xaml == null)
				throw new ArgumentNullException ("xaml");

			Kind kind;
			IntPtr top = NativeMethods.xaml_create_from_str (xaml, createNamescope, custom_el_cb,
					custom_at_cb, hookup_event_cb, out kind);

			if (top == IntPtr.Zero)
				return null;

			return DependencyObject.Lookup (kind, top);
		}

		internal static IntPtr create_element (string xmlns, string name)
		{
			string ns;
			string type_name;
			string asm_path;

			ParseXmlns (xmlns, out type_name, out ns, out asm_path);

			if (asm_path == null) {
				Console.WriteLine ("unable to parse xmlns string: '{0}'", xmlns);
				return IntPtr.Zero;
			}

			// TODO: Use a downloader here
			Assembly clientlib = Assembly.LoadFile (asm_path);
			if (clientlib == null) {
				Console.WriteLine ("could not load client library: '{0}'", asm_path);
				return IntPtr.Zero;
			}

			if (type_name != null)
				name = type_name;

			if (ns != null)
				name = String.Concat (ns, ".", name);

			DependencyObject res = (DependencyObject) clientlib.CreateInstance (name);

			if (res == null) {
				Console.WriteLine ("unable to create object instance:  '{0}'", name);
				return IntPtr.Zero;
			}

			IntPtr p = Hosting.GetNativeObject (res);
			return p;
		}

		
		private static void set_attribute (IntPtr target_ptr, string name, string value)
		{
			MethodInfo m = typeof (DependencyObject).GetMethod ("Lookup",
					BindingFlags.Static | BindingFlags.NonPublic, null, new Type [] { typeof (IntPtr) }, null);
			DependencyObject target = (DependencyObject) m.Invoke (null, new object [] { target_ptr });

			if (target == null) {
				Console.WriteLine ("unable to create target object from: 0x{0}", target_ptr);
				return;
			}

			PropertyDescriptor pd = TypeDescriptor.GetProperties (target).Find (name, true);

			if (pd == null) {
				Console.WriteLine ("unable to set property ({0}) no property descriptor found", name);
				return;
			}

			if (!pd.Converter.CanConvertFrom (typeof (string))) {
				//
				// MS does not seem to handle this yet either, but I think a logical improvement
				// here is to call back into unmanaged code something like xaml_create_object_from_str
				// with the attribute string, and see if the managed code can parse it, this would
				// allow you to stick things like Colors and KeySplines on your object and still have
				// custom setters
				//
				Console.WriteLine ("unable to convert property '{0}' from a string", name);
				return;
			}

			pd.SetValue (target, pd.Converter.ConvertFrom (value));
		}

		internal static void hookup_event (IntPtr target_ptr, string name, string value)
		{
			MethodInfo m = typeof (DependencyObject).GetMethod ("Lookup",
					BindingFlags.Static | BindingFlags.NonPublic, null, new Type [] { typeof (IntPtr) }, null);
			DependencyObject target = (DependencyObject) m.Invoke (null, new object [] { target_ptr });

			if (target == null) {
				Console.WriteLine ("hookup event unable to create target object from: 0x{0}", target_ptr);
				return;
			}

			EventInfo src = target.GetType ().GetEvent (name);
			if (src == null) {
				Console.WriteLine ("hookup event unable to find event to hook to: '{0}'.", name);
				return;
			}

			Delegate d = Delegate.CreateDelegate (src.EventHandlerType, target, value);
			if (d == null) {
				Console.WriteLine ("hookup event unable to create delegate.");
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
