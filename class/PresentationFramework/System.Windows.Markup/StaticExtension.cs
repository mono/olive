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
// Copyright (c) 2008 Novell, Inc. (http://www.novell.com)
//

using System;
using System.ComponentModel;
using System.Reflection;

namespace System.Windows.Markup {

	[MarkupExtensionReturnType (typeof(object))]
#if notyet
	[TypeConverter (typeof(StaticExtensionConverter))]
#endif
	public class StaticExtension : MarkupExtension
	{
		public StaticExtension ()
		{
		}

		public StaticExtension (string member)
		{
			if (member == null)
				throw new ArgumentNullException ();
			this.member = member;
		}

		[ConstructorArgument ("member")]
		public string Member {
			get { return member; }
			set {
				if (value == null)
					throw new ArgumentNullException ();
				member = value;
			}
		}

		public override object ProvideValue (IServiceProvider serviceProvider)
		{
			if (serviceProvider == null)
				throw new ArgumentNullException ();

			if (member == null)
				throw new ArgumentNullException ();

			IXamlTypeResolver resolver = serviceProvider.GetService (typeof (IXamlTypeResolver)) as IXamlTypeResolver;
			if (resolver == null)
				throw new ArgumentException ("Markup extension 'StaticExtension' requires 'IXamlTypeResolver' be implemented in the IServiceProvider for ProvideValue");

			int dot = member.LastIndexOf ('.');
			string typeName = member.Substring (0, dot);
			string memberName = member.Substring (dot + 1);

			Type type = resolver.Resolve (typeName);
			// we don't check type here for nullness, as WPF raises a NRE

			PropertyInfo pi = type.GetProperty (memberName, BindingFlags.Public | BindingFlags.Static);
			if (pi != null)
				return pi.GetValue (null, null);

			FieldInfo fi = type.GetField (memberName, BindingFlags.Public | BindingFlags.Static);
			if (fi != null)
				return fi.GetValue (null);

			throw new ArgumentException (string.Format ("'{0}' StaticExtension value cannot be resolved to an enumeration, static field, or static property", member));
		}

		string member;
	}

}
