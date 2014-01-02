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

#if !NET_4_0

using System;
using System.ComponentModel;

namespace System.Windows.Markup {

	[MarkupExtensionReturnType (typeof (Type))]
#if notyet
	[TypeConverter (typeof(TypeExtensionConverter))]
#endif
	public class TypeExtension : MarkupExtension {

		public TypeExtension ()
		{
		}

		public TypeExtension (string typeName)
		{
			this.typeName = typeName;
		}

		public TypeExtension (Type type)
		{
			this.type = type;
		}

		[ConstructorArgument ("type")]
		[DefaultValue ("")]
		public Type Type {
			get { return type; }
			set { type = value; }
		}

		[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
		public string TypeName {
			get { return typeName; }
			set { typeName = value; }
		}

		public override object ProvideValue (IServiceProvider provider)
		{
			if (type != null)
				return type;

			if (provider == null)
				throw new ArgumentNullException ();

			if (typeName == null)
				throw new ArgumentNullException ();

			IXamlTypeResolver resolver = provider.GetService (typeof (IXamlTypeResolver)) as IXamlTypeResolver;
			if (resolver == null)
				throw new Exception ("null resolver");

			return resolver.Resolve (typeName);
		}

		Type type;
		string typeName;
	}
}

#endif
