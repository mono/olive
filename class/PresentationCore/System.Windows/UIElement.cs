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

		public static readonly RoutedEvent DragEnterEvent;
		public static readonly RoutedEvent DragLeaveEvent;
		public static readonly RoutedEvent DragOverEvent;
		public static readonly RoutedEvent DropEvent;
		public static readonly RoutedEvent GiveFeedbackEvent;
		public static readonly RoutedEvent GotFocusEvent;
		public static readonly RoutedEvent GotKeyboardFocusEvent;
		public static readonly RoutedEvent GotMouseCaptureEvent;
		public static readonly RoutedEvent GotStylusCaptureEvent;
		public static readonly RoutedEvent KeyDownEvent;
		public static readonly RoutedEvent KeyUpEvent;
		public static readonly RoutedEvent LostFocusEvent;
		public static readonly RoutedEvent LostKeyboardFocusEvent;
		public static readonly RoutedEvent LostMouseFocusEvent;
		public static readonly RoutedEvent LostStylusFocusEvent;
		public static readonly RoutedEvent MouseDownEvent;
		public static readonly RoutedEvent MouseEnterEvent;
		public static readonly RoutedEvent MouseLeaveEvent;
		public static readonly RoutedEvent MouseLeftButtonDownEvent;
		public static readonly RoutedEvent MouseLeftButtonUpEvent;
		public static readonly RoutedEvent MouseMoveEvent;
		public static readonly RoutedEvent MouseRightButtonDownEvent;
		public static readonly RoutedEvent MouseRightButtonUpEvent;
		public static readonly RoutedEvent MouseUpEvent;
		public static readonly RoutedEvent MouseWheelEvent;
		public static readonly RoutedEvent PreviewDragEnterEvent;
		public static readonly RoutedEvent PreviewDragLeaveEvent;
		public static readonly RoutedEvent PreviewDragOverEvent;
		public static readonly RoutedEvent PreviewDropEvent;
		public static readonly RoutedEvent PreviewGiveFeedbackEvent;
		public static readonly RoutedEvent PreviewGotKeyboardFocusEvent;
		public static readonly RoutedEvent PreviewKeyDownEvent;
		public static readonly RoutedEvent PreviewKeyUpEvent;
		public static readonly RoutedEvent PreviewLostKeyboardFocusEvent;
		public static readonly RoutedEvent PreviewMouseDownEvent;
		public static readonly RoutedEvent PreviewMouseLeftButtonDownEvent;
		public static readonly RoutedEvent PreviewMouseLeftButtonUpEvent;
		public static readonly RoutedEvent PreviewMouseMoveEvent;
		public static readonly RoutedEvent PreviewMouseRightButtonDownEvent;
		public static readonly RoutedEvent PreviewMouseRightButtonUpEvent;
		public static readonly RoutedEvent PreviewMouseUpEvent;
		public static readonly RoutedEvent PreviewMouseWheelEvent;
		public static readonly RoutedEvent PreviewQueryContinueDragEvent;
		public static readonly RoutedEvent PreviewStylusButtonDownEvent;
		public static readonly RoutedEvent PreviewStylusButtonUpEvent;
		public static readonly RoutedEvent PreviewStylusDownEvent;
		public static readonly RoutedEvent PreviewStylusInAirMoveEvent;
		public static readonly RoutedEvent PreviewStylusInRangeEvent;
		public static readonly RoutedEvent PreviewStylusMoveEvent;
		public static readonly RoutedEvent PreviewStylusOutOfRangeEvent;
		public static readonly RoutedEvent PreviewStylusSystemGestureEvent;
		public static readonly RoutedEvent PreviewStylusUpEvent;
		public static readonly RoutedEvent PreviewTextInputEvent;
		public static readonly RoutedEvent QueryContinueDragEvent;
		public static readonly RoutedEvent QueryCursorEvent;
		public static readonly RoutedEvent StylusButtonDownEvent;
		public static readonly RoutedEvent StylusButtonUpEvent;
		public static readonly RoutedEvent StylusDownEvent;
		public static readonly RoutedEvent StylusEnterEvent;
		public static readonly RoutedEvent StylusInAirMoveEvent;
		public static readonly RoutedEvent StylusInRangeEvent;
		public static readonly RoutedEvent StylusLeaveEvent;
		public static readonly RoutedEvent StylusMoveEvent;
		public static readonly RoutedEvent StylusOutOfRangeEvent;
		public static readonly RoutedEvent StylusSystemGestureEvent;
		public static readonly RoutedEvent StylusUpEvent;
		public static readonly RoutedEvent TextInputEvent;

		public UIElement ()
		{
		}

		/* XXX tons of properties and Add*Handler/Remove*Handler calls */

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
