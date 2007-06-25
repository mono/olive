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

namespace System.Windows.Controls.Primitive {

	[LocalizabilityAttribute(LocalizationCategory.Button)] 
	public abstract class ButtonBase : ContentControl, ICommandSource {
		public static readonly RoutedEvent ClickEvent;
		public static readonly DependencyProperty ClickModeProperty;
		public static readonly DependencyProperty CommandParameterProperty;
		public static readonly DependencyProperty CommandProperty;
		public static readonly DependencyProperty CommandTargetProperty;
		public static readonly DependencyProperty IsPressedProperty;

		protected ButtonBase ()
		{
		}

		protected override void OnAccessKey (AccessKeyEventArgs e)
		{
		}

		protected virtual void OnClick ()
		{
		}

		protected virtual void OnIsPressedChanged (DependencyPropertyChangedEventArgs e)
		{
		}

		protected override void OnKeyDown (KeyEventArgs e)
		{
		}

		protected override void OnKeyUp (KeyEventArgs e)
		{
		}

		protected override void OnLostKeyboardFocus (KeyboardFocusChangedEventArgs e)
		{
		}

		protected override void OnLostMouseCapture (MouseEventArgs e)
		{
		}

		protected override void OnMouseEnter (MouseEventArgs e)
		{
		}

		protected override void OnMouseLeave (MouseEventArgs e)
		{
		}

		protected override void OnMouseLeftButtonDown (MouseButtonEventArgs e)
		{
		}

		protected override void OnMouseLeftButtonUp (MouseButtonEventArgs e)
		{
		}

		protected override void OnMouseMove (MouseEventArgs e)
		{
		}

		protected internal override void OnRenderSizeChanged (SizeChangedInfo sizeInfo)
		{
		}

		[BindableAttribute(true)] 
		public ClickMode ClickMode { get; set; }

		[BindableAttribute(true)] 
		[LocalizabilityAttribute(LocalizationCategory.NeverLocalize)] 
		public ICommand Command { get; set; }

		[LocalizabilityAttribute(LocalizationCategory.NeverLocalize)] 
		[BindableAttribute(true)] 
		public Object CommandParameter { get; set; }

		[BindableAttribute(true)] 
		public IInputElement CommandTarget { get; set; }

		protected override bool IsEnabledCore { get; }

		public bool IsPressed { get; }

		public event RoutedEventHandler Click;
	}

}
