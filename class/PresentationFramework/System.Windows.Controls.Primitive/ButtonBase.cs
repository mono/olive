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

using System.ComponentModel;
using System.Windows.Input;

namespace System.Windows.Controls.Primitive {

	//[LocalizabilityAttribute(LocalizationCategory.Button)] 
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

#if notyet
		protected override void OnAccessKey (AccessKeyEventArgs e)
		{
			throw new NotImplementedException ();
		}
#endif

		protected virtual void OnClick ()
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnIsPressedChanged (DependencyPropertyChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}

#if notyet
		protected override void OnKeyDown (KeyEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected override void OnKeyUp (KeyEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected override void OnLostKeyboardFocus (KeyboardFocusChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected override void OnLostMouseCapture (MouseEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected override void OnMouseEnter (MouseEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected override void OnMouseLeave (MouseEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected override void OnMouseLeftButtonDown (MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected override void OnMouseLeftButtonUp (MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected override void OnMouseMove (MouseEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected internal override void OnRenderSizeChanged (SizeChangedInfo sizeInfo)
		{
			throw new NotImplementedException ();
		}
#endif

		[Bindable (true)] 
		public ClickMode ClickMode {
			get { return (ClickMode)GetValue (ClickModeProperty); }
			set { SetValue (ClickModeProperty, value); }
		}

		[Bindable (true)] 
		//[LocalizabilityAttribute(LocalizationCategory.NeverLocalize)] 
		public ICommand Command {
			get { return (ICommand)GetValue (CommandProperty); }
			set { SetValue (CommandProperty, value); }
		}

		[Bindable (true)] 
		//[LocalizabilityAttribute(LocalizationCategory.NeverLocalize)] 
		public object CommandParameter {
			get { return (object)GetValue (CommandParameterProperty); }
			set { SetValue (CommandParameterProperty, value); }
		}

		[Bindable (true)] 
		public IInputElement CommandTarget {
			get { return (IInputElement)GetValue (CommandTargetProperty); }
			set { SetValue (CommandTargetProperty, value); }
		}

#if notyet
		protected override bool IsEnabledCore {
			get { throw new NotImplementedException (); }
		}
#endif

		public bool IsPressed {
			get { return (bool)GetValue (IsPressedProperty); }
		}

		public event RoutedEventHandler Click;
	}

}
