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
// Copyright (c) 2007 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Chris Toshok (toshok@ximian.com)
//

using System;

using System.Collections;
using System.ComponentModel;
using System.Windows.Markup;

namespace System.Windows.Controls {

// 	[LocalizabilityAttribute(LocalizationCategory.None, Readability=Readability.Unreadable)] 
// 	[ContentPropertyAttribute("Content")] 
	public class ContentControl : Control, IAddChild {

		public static readonly DependencyProperty ContentProperty;
		public static readonly DependencyProperty ContentTemplateProperty;
		public static readonly DependencyProperty ContentTemplateSelectorProperty;
		public static readonly DependencyProperty HasContentProperty;

		protected virtual void AddChild (object value)
		{
			throw new NotImplementedException ();
		}

		protected virtual void AddText (string text)
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnContentChanged (object oldContent,
							 object newContent)
		{
			throw new NotImplementedException ();
		}

#if notyet
		protected virtual void OnContentTemplateChanged (DataTemplate oldContentTemplate,
								 DataTemplate newContentTemplate)
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnContentTemplateSelectorChanged (DataTemplateSelector oldContentTemplateSelector,
									 DataTemplateSelector newContentTemplateSelector)
		{
			throw new NotImplementedException ();
		}
#endif

		public virtual bool ShouldSerializeContent ()
		{
			throw new NotImplementedException ();
		}

		void IAddChild.AddChild (object value)
		{
			throw new NotImplementedException ();
		}

		void IAddChild.AddText (string text)
		{
			throw new NotImplementedException ();
		}

		[Bindable (true)] 
		public object Content {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}


#if notyet
		[Bindable (true)] 
		public DataTemplate ContentTemplate {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[Bindable (true)] 
		public DataTemplateSelector ContentTemplateSelector {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}
#endif

		public bool HasContent {
			get { throw new NotImplementedException (); }
		}

#if notyet
		protected internal override IEnumerator LogicalChildren {
			get { throw new NotImplementedException (); }
		}
#endif
	}

}
