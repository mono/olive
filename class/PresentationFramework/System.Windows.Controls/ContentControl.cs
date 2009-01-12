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

 	[LocalizabilityAttribute(LocalizationCategory.None, Readability=Readability.Unreadable)] 
 	[ContentPropertyAttribute("Content")] 
	public class ContentControl : Control, IAddChild {

		protected virtual void AddChild (object value)
		{
			throw new NotImplementedException ();
		}

		protected virtual void AddText (string text)
		{
			throw new NotImplementedException ();
		}

		public virtual bool ShouldSerializeContent ()
		{
			throw new NotImplementedException ();
		}

		void IAddChild.AddChild (object value)
		{
			AddChild (value);
		}

		void IAddChild.AddText (string text)
		{
			AddText (text);
		}

#region Content Property
		public static readonly DependencyProperty ContentProperty
			= DependencyProperty.Register ("Content", typeof (object), typeof (ContentControl),
						       new PropertyMetadata (OnContentChanged));

		[Bindable (true)] 
		public object Content {
		    get { return (object)GetValue (ContentProperty); }
		    set { SetValue (ContentProperty, value); }
		}

		private static void OnContentChanged (object sender, DependencyPropertyChangedEventArgs args)
		{
			((ContentControl)sender).OnContentChanged (args.OldValue, args.NewValue);
		}

		protected virtual void OnContentChanged (object oldContent,
							 object newContent)
		{
		}
#endregion

#region ContentTemplate Property
		public static readonly DependencyProperty ContentTemplateProperty
			= DependencyProperty.Register ("ContentTemplate", typeof (DataTemplate), typeof (ContentControl),
						       new PropertyMetadata (OnContentTemplateChanged));

		[Bindable (true)] 
		public DataTemplate ContentTemplate {
		    get { return (DataTemplate)GetValue (ContentTemplateProperty); }
		    set { SetValue (ContentTemplateProperty, value); }
		}

		private static void OnContentTemplateChanged (object sender, DependencyPropertyChangedEventArgs args)
		{
			((ContentControl)sender).OnContentTemplateChanged ((DataTemplate)args.OldValue, (DataTemplate)args.NewValue);
		}

		protected virtual void OnContentTemplateChanged (DataTemplate oldContentTemplate,
								 DataTemplate newContentTemplate)
		{
		}
#endregion

#region ContentTemplateSelector Property
		public static readonly DependencyProperty ContentTemplateSelectorProperty =
			DependencyProperty.Register ("ContentTemplateSelector", typeof (DataTemplateSelector), typeof (ContentControl),
						     new PropertyMetadata (OnContentTemplateSelectorChanged));

		public DataTemplateSelector ContentTemplateSelector {
		    get { return (DataTemplateSelector)GetValue (ContentTemplateSelectorProperty); }
		    set { SetValue (ContentTemplateSelectorProperty, value); }
		}

		private static void OnContentTemplateSelectorChanged (object sender, DependencyPropertyChangedEventArgs args)
		{
			((ContentControl)sender).OnContentTemplateSelectorChanged ((DataTemplateSelector)args.OldValue, (DataTemplateSelector)args.NewValue);
		}

		protected virtual void OnContentTemplateSelectorChanged (DataTemplateSelector oldContentTemplateSelector,
									 DataTemplateSelector newContentTemplateSelector)
		{
		}
#endregion

#region HasContent Property
		public static readonly DependencyProperty HasContentProperty =
			DependencyProperty.Register ("HasContent", typeof (bool), typeof (ContentControl));

		public bool HasContent {
		    get { return (bool)GetValue (HasContentProperty); }
		}
#endregion
		
		protected internal override IEnumerator LogicalChildren {
			get { throw new NotImplementedException (); }
		}
	}

}
