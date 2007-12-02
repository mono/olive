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

using System.Windows.Media;

using System.Windows.Input;

namespace System.Windows {

	public class UIElement : Visual {

		public static readonly DependencyProperty AllowDropProperty;
		public static readonly DependencyProperty BitmapEffectInputProperty;
		public static readonly DependencyProperty BitmapEffectProperty;
		public static readonly DependencyProperty ClipProperty;
		public static readonly DependencyProperty ClipToBoundsProperty;
		public static readonly DependencyProperty FocusableProperty;
		public static readonly DependencyProperty IsEnabledProperty;
		public static readonly DependencyProperty IsFocusedProperty;
		public static readonly DependencyProperty IsHitTestVisibleProperty;
		public static readonly DependencyProperty IsKeyboardFocusdProperty;
		public static readonly DependencyProperty IsKeyboardFocusWithinProperty;
		public static readonly DependencyProperty IsMouseCapturedProperty;
		public static readonly DependencyProperty IsMouseCaptureWithinProperty;
		public static readonly DependencyProperty IsMouseDirectlyOverProperty;
		public static readonly DependencyProperty IsStylusCapturedProperty;
		public static readonly DependencyProperty IsStylusCapturedWithinProperty;
		public static readonly DependencyProperty IsStylusDirectlyOverProperty;
		public static readonly DependencyProperty IsStylusOverProperty;
		public static readonly DependencyProperty IsVisibleProperty;
		public static readonly DependencyProperty OpacityMaskProperty;
		public static readonly DependencyProperty OpacityProperty;
		public static readonly DependencyProperty RenderTransformOriginProperty;
		public static readonly DependencyProperty RenderTransformProperty;
		public static readonly DependencyProperty SnapsToDevicePixelsProperty;

		public static readonly RoutedEvent DragEnterEvent = DragDrop.DragEnterEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent DragLeaveEvent = DragDrop.DragLeaveEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent DragOverEvent = DragDrop.DragOverEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent DropEvent = DragDrop.DropEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent GiveFeedbackEvent = DragDrop.GiveFeedbackEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent GotFocusEvent = FocusManager.GotFocusEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent GotKeyboardFocusEvent = Keyboard.GotKeyboardFocusEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent GotMouseCaptureEvent = Mouse.GotMouseCaptureEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent GotStylusCaptureEvent; // XXX
		public static readonly RoutedEvent KeyDownEvent = Keyboard.KeyDownEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent KeyUpEvent = Keyboard.KeyUpEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent LostFocusEvent = FocusManager.LostFocusEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent LostKeyboardFocusEvent = Keyboard.LostKeyboardFocusEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent LostMouseCaptureEvent = Mouse.LostMouseCaptureEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent LostStylusCaptureEvent; // XXX
		public static readonly RoutedEvent MouseDownEvent = Mouse.MouseDownEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent MouseEnterEvent = Mouse.MouseEnterEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent MouseLeaveEvent = Mouse.MouseLeaveEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent MouseLeftButtonDownEvent = UIElement.MouseLeftButtonDownEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent MouseLeftButtonUpEvent = UIElement.MouseLeftButtonUpEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent MouseMoveEvent = Mouse.MouseMoveEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent MouseRightButtonDownEvent = UIElement.MouseRightButtonDownEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent MouseRightButtonUpEvent = UIElement.MouseRightButtonUpEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent MouseUpEvent = Mouse.MouseUpEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent MouseWheelEvent = Mouse.MouseWheelEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewDragEnterEvent =  DragDrop.PreviewDragEnterEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewDragLeaveEvent = DragDrop.PreviewDragLeaveEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewDragOverEvent = DragDrop.PreviewDragOverEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewDropEvent = DragDrop.PreviewDropEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewGiveFeedbackEvent = DragDrop.PreviewGiveFeedbackEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewGotKeyboardFocusEvent = Keyboard.PreviewGotKeyboardFocusEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewKeyDownEvent = Keyboard.PreviewKeyDownEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewKeyUpEvent = Keyboard.PreviewKeyUpEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewLostKeyboardFocusEvent = Keyboard.PreviewLostKeyboardFocusEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewMouseDownEvent = Mouse.PreviewMouseDownEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewMouseLeftButtonDownEvent = UIElement.PreviewMouseLeftButtonDownEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewMouseLeftButtonUpEvent = UIElement.PreviewMouseLeftButtonUpEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewMouseMoveEvent = Mouse.PreviewMouseMoveEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewMouseRightButtonDownEvent = UIElement.PreviewMouseRightButtonDownEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewMouseRightButtonUpEvent = UIElement.PreviewMouseRightButtonUpEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewMouseUpEvent = Mouse.PreviewMouseUpEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewMouseWheelEvent = Mouse.PreviewMouseWheelEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewQueryContinueDragEvent = DragDrop.PreviewQueryContinueDragEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent PreviewStylusButtonDownEvent; // XXX
		public static readonly RoutedEvent PreviewStylusButtonUpEvent; // XXX
		public static readonly RoutedEvent PreviewStylusDownEvent; // XXX
		public static readonly RoutedEvent PreviewStylusInAirMoveEvent; // XXX
		public static readonly RoutedEvent PreviewStylusInRangeEvent; // XXX
		public static readonly RoutedEvent PreviewStylusMoveEvent; // XXX
		public static readonly RoutedEvent PreviewStylusOutOfRangeEvent; // XXX
		public static readonly RoutedEvent PreviewStylusSystemGestureEvent; // XXX
		public static readonly RoutedEvent PreviewStylusUpEvent; // XXX
		public static readonly RoutedEvent PreviewTextInputEvent = TextCompositionManager.PreviewTextInputEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent QueryContinueDragEvent = DragDrop.QueryContinueDragEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent QueryCursorEvent = Mouse.QueryCursorEvent.AddOwner (typeof (UIElement));
		public static readonly RoutedEvent StylusButtonDownEvent; // XXX
		public static readonly RoutedEvent StylusButtonUpEvent; // XXX
		public static readonly RoutedEvent StylusDownEvent; // XXX
		public static readonly RoutedEvent StylusEnterEvent; // XXX
		public static readonly RoutedEvent StylusInAirMoveEvent; // XXX
		public static readonly RoutedEvent StylusInRangeEvent; // XXX
		public static readonly RoutedEvent StylusLeaveEvent; // XXX
		public static readonly RoutedEvent StylusMoveEvent; // XXX
		public static readonly RoutedEvent StylusOutOfRangeEvent; // XXX
		public static readonly RoutedEvent StylusSystemGestureEvent; // XXX
		public static readonly RoutedEvent StylusUpEvent; // XXX
		public static readonly RoutedEvent TextInputEvent = TextCompositionManager.TextInputEvent.AddOwner (typeof (UIElement));

		public UIElement ()
		{
		}

		/* XXX tons of properties and Add*Handler/Remove*Handler calls */

		internal static void AddHandler (DependencyObject d, RoutedEvent routedEvent, Delegate handler)
		{
			if (d is UIElement)
				((UIElement)d).AddHandler (routedEvent, handler);
			else if (d is ContentElement)
				((ContentElement)d).AddHandler (routedEvent, handler);
			else if (d is IInputElement)
				((IInputElement)d).AddHandler (routedEvent, handler);
			else
				throw new ArgumentException (String.Format ("type '{0}' is not subclass of UIElement or ContentElement, and doesn't implement the IInputElement interface, so you can't add RoutedEvent handlers to it.", d.GetType()));
		}

		internal static void RemoveHandler (DependencyObject d, RoutedEvent routedEvent, Delegate handler)
		{
			if (d is UIElement)
				((UIElement)d).RemoveHandler (routedEvent, handler);
			else if (d is ContentElement)
				((ContentElement)d).RemoveHandler (routedEvent, handler);
			else if (d is IInputElement)
				((IInputElement)d).RemoveHandler (routedEvent, handler);
			else
				throw new ArgumentException (String.Format ("type '{0}' is not subclass of UIElement or ContentElement, and doesn't implement the IInputElement interface, so you can't add RoutedEvent handlers to it.", d.GetType()));
		}

		public void AddHandler (RoutedEvent routedEvent, Delegate handler)
		{
			throw new NotImplementedException ();
		}

		public void AddHandler (RoutedEvent routedEvent, Delegate handler, bool handledEventsToo)
		{
			throw new NotImplementedException ();
		}

		public void RemoveHandler (RoutedEvent routedEvent, Delegate handler)
		{
			throw new NotImplementedException ();
		}
	}
}
