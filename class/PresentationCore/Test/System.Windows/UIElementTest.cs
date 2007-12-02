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
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using NUnit.Framework;

namespace MonoTests.System.Windows {

	[TestFixture]
	public class UIElementTest {

		void _checkEvent (RoutedEvent ev,
				  string expected_name, Type expected_handler_type,
				  Type expected_owner_type, RoutingStrategy expected_routing_strategy)
		{
			Assert.AreEqual (expected_handler_type, ev.HandlerType);
			Assert.AreEqual (expected_name, ev.Name);
			Assert.AreEqual (expected_owner_type, ev.OwnerType);
			Assert.AreEqual (expected_routing_strategy, ev.RoutingStrategy);
		}

		[Test]
		public void TestRoutedEvents ()
		{
			Assert.AreSame (UIElement.DragEnterEvent, DragDrop.DragEnterEvent);
			Assert.AreSame (UIElement.DragLeaveEvent, DragDrop.DragLeaveEvent);
			Assert.AreSame (UIElement.DragOverEvent, DragDrop.DragOverEvent);
			Assert.AreSame (UIElement.DropEvent, DragDrop.DropEvent);
			Assert.AreSame (UIElement.GiveFeedbackEvent, DragDrop.GiveFeedbackEvent);
			Assert.AreSame (UIElement.GotFocusEvent, FocusManager.GotFocusEvent);
			Assert.AreSame (UIElement.GotKeyboardFocusEvent, Keyboard.GotKeyboardFocusEvent);
			Assert.AreSame (UIElement.GotMouseCaptureEvent, Mouse.GotMouseCaptureEvent);
			//			Assert.AreSame (UIElement.GotStylusCaptureEvent, Stylus.GotStylusCaptureEvent);
			Assert.AreSame (UIElement.KeyDownEvent, Keyboard.KeyDownEvent);
			Assert.AreSame (UIElement.KeyUpEvent, Keyboard.KeyUpEvent);
			Assert.AreSame (UIElement.LostFocusEvent, FocusManager.LostFocusEvent);
			Assert.AreSame (UIElement.LostKeyboardFocusEvent, Keyboard.LostKeyboardFocusEvent);
			Assert.AreSame (UIElement.LostMouseCaptureEvent, Mouse.LostMouseCaptureEvent);
			//			Assert.AreSame (UIElement.LostStylusCaptureEvent, Stylus.LostStylusCaptureEvent);
			Assert.AreSame (UIElement.MouseDownEvent, Mouse.MouseDownEvent);
			Assert.AreSame (UIElement.MouseEnterEvent, Mouse.MouseEnterEvent);
			Assert.AreSame (UIElement.MouseLeaveEvent, Mouse.MouseLeaveEvent);

			_checkEvent (UIElement.MouseLeftButtonDownEvent, "MouseLeftButtonDown",
				     typeof (MouseButtonEventHandler), typeof (UIElement), RoutingStrategy.Direct);
			_checkEvent (UIElement.MouseLeftButtonUpEvent, "MouseLeftButtonUp",
				     typeof (MouseButtonEventHandler), typeof (UIElement), RoutingStrategy.Direct);

			Assert.AreSame (UIElement.MouseMoveEvent, Mouse.MouseMoveEvent);

			_checkEvent (UIElement.MouseRightButtonDownEvent, "MouseRightButtonDown",
				     typeof (MouseButtonEventHandler), typeof (UIElement), RoutingStrategy.Direct);
			_checkEvent (UIElement.MouseRightButtonUpEvent, "MouseRightButtonUp",
				     typeof (MouseButtonEventHandler), typeof (UIElement), RoutingStrategy.Direct);

			Assert.AreSame (UIElement.MouseUpEvent, Mouse.MouseUpEvent);
			Assert.AreSame (UIElement.MouseWheelEvent, Mouse.MouseWheelEvent);

			Assert.AreSame (UIElement.QueryContinueDragEvent, DragDrop.QueryContinueDragEvent);
			Assert.AreSame (UIElement.QueryCursorEvent, Mouse.QueryCursorEvent);
// 			Assert.AreSame (UIElement.StylusButtonDownEvent, Stylus.StylusButtonDownEvent);
// 			Assert.AreSame (UIElement.StylusButtonUpEvent, Stylus.StylusButtonUpEvent);
// 			Assert.AreSame (UIElement.StylusDownEvent, Stylus.StylusDownEvent);
// 			Assert.AreSame (UIElement.StylusEnterEvent, Stylus.StylusEnterEvent);
// 			Assert.AreSame (UIElement.StylusInAirMoveEvent, Stylus.StylusInAirMoveEvent);
// 			Assert.AreSame (UIElement.StylusInRangeEvent, Stylus.StylusInRangeEvent);
// 			Assert.AreSame (UIElement.StylusLeaveEvent, Stylus.StylusLeaveEvent);
// 			Assert.AreSame (UIElement.StylusMoveEvent, Stylus.StylusMoveEvent);
// 			Assert.AreSame (UIElement.StylusOutOfRangeEvent, Stylus.StylusOutOfRangeEvent);
// 			Assert.AreSame (UIElement.StylusSystemGestureEvent, Stylus.StylusSystemGestureEvent);
// 			Assert.AreSame (UIElement.StylusUpEvent, Stylus.StylusUpEvent);
			Assert.AreSame (UIElement.TextInputEvent, TextCompositionManager.TextInputEvent);

			Assert.AreSame (UIElement.PreviewDragEnterEvent, DragDrop.PreviewDragEnterEvent);
			Assert.AreSame (UIElement.PreviewDragLeaveEvent, DragDrop.PreviewDragLeaveEvent);
			Assert.AreSame (UIElement.PreviewDragOverEvent, DragDrop.PreviewDragOverEvent);
			Assert.AreSame (UIElement.PreviewDropEvent, DragDrop.PreviewDropEvent);
			Assert.AreSame (UIElement.PreviewGiveFeedbackEvent, DragDrop.PreviewGiveFeedbackEvent);
			Assert.AreSame (UIElement.PreviewGotKeyboardFocusEvent, Keyboard.PreviewGotKeyboardFocusEvent);
			Assert.AreSame (UIElement.PreviewKeyDownEvent, Keyboard.PreviewKeyDownEvent);
			Assert.AreSame (UIElement.PreviewKeyUpEvent, Keyboard.PreviewKeyUpEvent);
			Assert.AreSame (UIElement.PreviewLostKeyboardFocusEvent, Keyboard.PreviewLostKeyboardFocusEvent);
			Assert.AreSame (UIElement.PreviewMouseDownEvent, Mouse.PreviewMouseDownEvent);

			_checkEvent (UIElement.PreviewMouseLeftButtonDownEvent, "PreviewMouseLeftButtonDown",
				     typeof (MouseButtonEventHandler), typeof (UIElement), RoutingStrategy.Direct);
			_checkEvent (UIElement.PreviewMouseLeftButtonUpEvent, "PreviewMouseLeftButtonUp",
				     typeof (MouseButtonEventHandler), typeof (UIElement), RoutingStrategy.Direct);

			Assert.AreSame (UIElement.PreviewMouseMoveEvent, Mouse.PreviewMouseMoveEvent);

			_checkEvent (UIElement.PreviewMouseRightButtonDownEvent, "PreviewMouseRightButtonDown",
				     typeof (MouseButtonEventHandler), typeof (UIElement), RoutingStrategy.Direct);
			_checkEvent (UIElement.PreviewMouseRightButtonUpEvent, "PreviewMouseRightButtonUp",
				     typeof (MouseButtonEventHandler), typeof (UIElement), RoutingStrategy.Direct);

			Assert.AreSame (UIElement.PreviewMouseUpEvent, Mouse.PreviewMouseUpEvent);
			Assert.AreSame (UIElement.PreviewMouseWheelEvent, Mouse.PreviewMouseWheelEvent);
			Assert.AreSame (UIElement.PreviewQueryContinueDragEvent, DragDrop.PreviewQueryContinueDragEvent);
// 			Assert.AreSame (UIElement.PreviewStylusButtonDownEvent, Stylus.PreviewStylusButtonDownEvent);
// 			Assert.AreSame (UIElement.PreviewStylusButtonUpEvent, Stylus.PreviewStylusButtonUpEvent);
// 			Assert.AreSame (UIElement.PreviewStylusDownEvent, Stylus.PreviewStylusDownEvent);
// 			Assert.AreSame (UIElement.PreviewStylusEnterEvent, Stylus.PreviewStylusEnterEvent);
// 			Assert.AreSame (UIElement.PreviewStylusInAirMoveEvent, Stylus.PreviewStylusInAirMoveEvent);
// 			Assert.AreSame (UIElement.PreviewStylusInRangeEvent, Stylus.PreviewStylusInRangeEvent);
// 			Assert.AreSame (UIElement.PreviewStylusLeaveEvent, Stylus.PreviewStylusLeaveEvent);
// 			Assert.AreSame (UIElement.PreviewStylusMoveEvent, Stylus.PreviewStylusMoveEvent);
// 			Assert.AreSame (UIElement.PreviewStylusOutOfRangeEvent, Stylus.PreviewStylusOutOfRangeEvent);
// 			Assert.AreSame (UIElement.PreviewStylusSystemGestureEvent, Stylus.PreviewStylusSystemGestureEvent);
// 			Assert.AreSame (UIElement.PreviewStylusUpEvent, Stylus.PreviewStylusUpEvent);
			Assert.AreSame (UIElement.PreviewTextInputEvent, TextCompositionManager.PreviewTextInputEvent);
		}
	}
}
