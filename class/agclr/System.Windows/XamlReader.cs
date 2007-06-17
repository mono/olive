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

using System.Xml;
using System.IO;
using Mono;
using System.Reflection;
using System.ComponentModel;

namespace System.Windows {
	
	public static class XamlReader {
	
		static CreateCustomXamlElementCallback custom_el_cb = new CreateCustomXamlElementCallback (create_element);
		static SetCustomXamlAttributeCallback custom_at_cb = new SetCustomXamlAttributeCallback (set_attribute);

		public static DependencyObject Load (string xaml)
		{
			return Load (xaml, true);
		}
		
		public static DependencyObject Load (string xaml, bool createNamescope)
		{
			if (xaml == null)
				throw new ArgumentNullException ("xaml");

			Kind kind;
			IntPtr top = NativeMethods.xaml_create_from_str (xaml, createNamescope, custom_el_cb, custom_at_cb, out kind);

			if (top == IntPtr.Zero)
				return null;

			return DependencyObject.Lookup (kind, top);
		}

		internal static IntPtr create_element (string xmlns, string name)
		{
			string ns;
			string asm;
			string fullname;
			
			ParseXmlns (xmlns, out ns, out asm);

			if (ns == null || asm == null)
				return IntPtr.Zero;

			fullname = String.Concat (ns, ".", name);

			// TODO: We need to use the downloader here
			Assembly clientlib = Assembly.LoadFile (asm);

			if (clientlib == null)
				return IntPtr.Zero;

			DependencyObject res = (DependencyObject) clientlib.CreateInstance (fullname);

			if (res == null)
				return IntPtr.Zero;

			return res._native;
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

		internal static void ParseXmlns (string xmlns, out string ns, out string asm)
		{
			ns = null;
			asm = null;

			string [] decls = xmlns.Split (';');
			foreach (string decl in decls) {
				if (decl.StartsWith ("clr-namespace:")) {
					ns = decl.Substring (14, decl.Length - 14);
				}
				if (decl.StartsWith ("assembly=")) {
					asm = decl.Substring (9, decl.Length - 9);
				}
			}
		}
	}
}
