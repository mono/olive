//
// HtmlElement.cs
//
// Authors:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
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
using System;

namespace System.Windows.Browser
{
	public class HtmlElement : HtmlObject
	{
		// When does this .ctor make sense?
		public HtmlElement ()
		{
		}

		internal HtmlElement (IntPtr handle)
			: base (handle)
		{
		}

		[MonoTODO]
		public void AppendChild (HtmlElement element)
		{
			InvokeMethod ("appendChild", element);
		}

		[MonoTODO]
		public void AppendChild (HtmlElement element, HtmlElement referenceElement)
		{
			InvokeMethod ("insertAfter", element, referenceElement);
		}

		[MonoTODO]
		public void Focus ()
		{
			InvokeMethod ("focus");
		}

		[MonoTODO]
		public string GetAttribute (string name)
		{
			return (string) InvokeMethod ("getAttribute", name);
		}

		[MonoTODO]
		public string GetStyleAttribute (string name)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void RemoveAttribute (string name)
		{
			InvokeMethod ("removeAttribute", name);
		}

		[MonoTODO]
		public void RemoveChild (HtmlElement element)
		{
			InvokeMethod ("removeChild", element);
		}

		[MonoTODO]
		public void RemoveStyleAttribute (string name)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void SetAttribute (string name, string value)
		{
			InvokeMethod ("setAttribute", name, value);
		}

		[MonoTODO]
		public override void SetProperty (string name, object value)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void SetStyleAttribute (string name, string value)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public HtmlElementCollection Children {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public string CssClass {
			get { return GetProperty<string> ("class"); }
			set { SetProperty ("class", value); }
		}

		public string ID {
			get { return GetProperty<string> ("id"); }
			set { SetProperty ("id", value); }
		}

		public HtmlElement Parent {
			get { return GetProperty<HtmlElement> ("parentNode"); }
		}

		public string TagName {
			get { return GetProperty<string> ("tagName"); }
		}
	}
}

