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
using System.Collections;
using System.ComponentModel;

namespace System.Windows.Markup {

	[ContentProperty ("Items")]
	[MarkupExtensionReturnType (typeof (IList))]
	public class ArrayExtension : MarkupExtension, IAddChild
	{
		public ArrayExtension (Array array)
		{
		}

		public ArrayExtension (Type arrayType)
		{
		}

		public ArrayExtension ()
		{
		}

		public override object ProvideValue (IServiceProvider provider)
		{
			throw new NotImplementedException ();
		}

		public void AddChild (object child)
		{
			throw new NotImplementedException ();
		}

		public void AddText (string text)
		{
			throw new NotImplementedException ();
		}

		[ConstructorArgumentAttribute ("type")]
		public Type Type {
			get { return arrayType; }
			set { arrayType = value; }
		}

		[DesignerSerializationVisibility (DesignerSerializationVisibility.Content)]
		public IList Items {
			get { return items; }
		}

		Type arrayType;
		IList items;
	}

}