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

		[Test]
		public void TestRoutedEvents ()
		{
			Assert.AreEqual (typeof (UIElement), UIElement.PreviewMouseLeftButtonDownEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseLeftButtonDown", UIElement.PreviewMouseLeftButtonDownEvent.Name);
			Assert.AreEqual ("UIElement.PreviewMouseLeftButtonDown", UIElement.PreviewMouseLeftButtonDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.PreviewMouseLeftButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.PreviewMouseLeftButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.MouseLeftButtonDownEvent.OwnerType);
			Assert.AreEqual ("MouseLeftButtonDown", UIElement.MouseLeftButtonDownEvent.Name);
			Assert.AreEqual ("UIElement.MouseLeftButtonDown", UIElement.MouseLeftButtonDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.MouseLeftButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.MouseLeftButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.PreviewMouseLeftButtonUpEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseLeftButtonUp", UIElement.PreviewMouseLeftButtonUpEvent.Name);
			Assert.AreEqual ("UIElement.PreviewMouseLeftButtonUp", UIElement.PreviewMouseLeftButtonUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.PreviewMouseLeftButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.PreviewMouseLeftButtonUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.MouseLeftButtonUpEvent.OwnerType);
			Assert.AreEqual ("MouseLeftButtonUp", UIElement.MouseLeftButtonUpEvent.Name);
			Assert.AreEqual ("UIElement.MouseLeftButtonUp", UIElement.MouseLeftButtonUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.MouseLeftButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.MouseLeftButtonUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.PreviewMouseRightButtonDownEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseRightButtonDown", UIElement.PreviewMouseRightButtonDownEvent.Name);
			Assert.AreEqual ("UIElement.PreviewMouseRightButtonDown", UIElement.PreviewMouseRightButtonDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.PreviewMouseRightButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.PreviewMouseRightButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.MouseRightButtonDownEvent.OwnerType);
			Assert.AreEqual ("MouseRightButtonDown", UIElement.MouseRightButtonDownEvent.Name);
			Assert.AreEqual ("UIElement.MouseRightButtonDown", UIElement.MouseRightButtonDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.MouseRightButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.MouseRightButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.PreviewMouseRightButtonUpEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseRightButtonUp", UIElement.PreviewMouseRightButtonUpEvent.Name);
			Assert.AreEqual ("UIElement.PreviewMouseRightButtonUp", UIElement.PreviewMouseRightButtonUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.PreviewMouseRightButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.PreviewMouseRightButtonUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.MouseRightButtonUpEvent.OwnerType);
			Assert.AreEqual ("MouseRightButtonUp", UIElement.MouseRightButtonUpEvent.Name);
			Assert.AreEqual ("UIElement.MouseRightButtonUp", UIElement.MouseRightButtonUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.MouseRightButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.MouseRightButtonUpEvent.RoutingStrategy);

			Assert.AreSame (UIElement.PreviewMouseDownEvent, Mouse.PreviewMouseDownEvent);
			Assert.AreSame (UIElement.MouseDownEvent, Mouse.MouseDownEvent);
			Assert.AreSame (UIElement.PreviewMouseUpEvent, Mouse.PreviewMouseUpEvent);
			Assert.AreSame (UIElement.MouseUpEvent, Mouse.MouseUpEvent);
			Assert.AreSame (UIElement.PreviewMouseMoveEvent, Mouse.PreviewMouseMoveEvent);
			Assert.AreSame (UIElement.MouseMoveEvent, Mouse.MouseMoveEvent);
			Assert.AreSame (UIElement.PreviewMouseWheelEvent, Mouse.PreviewMouseWheelEvent);
			Assert.AreSame (UIElement.MouseWheelEvent, Mouse.MouseWheelEvent);
			Assert.AreSame (UIElement.MouseEnterEvent, Mouse.MouseEnterEvent);
			Assert.AreSame (UIElement.MouseLeaveEvent, Mouse.MouseLeaveEvent);
			Assert.AreSame (UIElement.GotMouseCaptureEvent, Mouse.GotMouseCaptureEvent);
			Assert.AreSame (UIElement.LostMouseCaptureEvent, Mouse.LostMouseCaptureEvent);
			Assert.AreSame (UIElement.QueryCursorEvent, Mouse.QueryCursorEvent);
			Assert.AreSame (UIElement.PreviewStylusDownEvent, Stylus.PreviewStylusDownEvent);
			Assert.AreSame (UIElement.StylusDownEvent, Stylus.StylusDownEvent);
			Assert.AreSame (UIElement.PreviewStylusUpEvent, Stylus.PreviewStylusUpEvent);
			Assert.AreSame (UIElement.StylusUpEvent, Stylus.StylusUpEvent);
			Assert.AreSame (UIElement.PreviewStylusMoveEvent, Stylus.PreviewStylusMoveEvent);
			Assert.AreSame (UIElement.StylusMoveEvent, Stylus.StylusMoveEvent);
			Assert.AreSame (UIElement.PreviewStylusInAirMoveEvent, Stylus.PreviewStylusInAirMoveEvent);
			Assert.AreSame (UIElement.StylusInAirMoveEvent, Stylus.StylusInAirMoveEvent);
			Assert.AreSame (UIElement.StylusEnterEvent, Stylus.StylusEnterEvent);
			Assert.AreSame (UIElement.StylusLeaveEvent, Stylus.StylusLeaveEvent);
			Assert.AreSame (UIElement.PreviewStylusInRangeEvent, Stylus.PreviewStylusInRangeEvent);
			Assert.AreSame (UIElement.StylusInRangeEvent, Stylus.StylusInRangeEvent);
			Assert.AreSame (UIElement.PreviewStylusOutOfRangeEvent, Stylus.PreviewStylusOutOfRangeEvent);
			Assert.AreSame (UIElement.StylusOutOfRangeEvent, Stylus.StylusOutOfRangeEvent);
			Assert.AreSame (UIElement.PreviewStylusSystemGestureEvent, Stylus.PreviewStylusSystemGestureEvent);
			Assert.AreSame (UIElement.StylusSystemGestureEvent, Stylus.StylusSystemGestureEvent);
			Assert.AreSame (UIElement.GotStylusCaptureEvent, Stylus.GotStylusCaptureEvent);
			Assert.AreSame (UIElement.LostStylusCaptureEvent, Stylus.LostStylusCaptureEvent);
			Assert.AreSame (UIElement.StylusButtonDownEvent, Stylus.StylusButtonDownEvent);
			Assert.AreSame (UIElement.StylusButtonUpEvent, Stylus.StylusButtonUpEvent);
			Assert.AreSame (UIElement.PreviewStylusButtonDownEvent, Stylus.PreviewStylusButtonDownEvent);
			Assert.AreSame (UIElement.PreviewStylusButtonUpEvent, Stylus.PreviewStylusButtonUpEvent);
			Assert.AreSame (UIElement.PreviewKeyDownEvent, Keyboard.PreviewKeyDownEvent);
			Assert.AreSame (UIElement.KeyDownEvent, Keyboard.KeyDownEvent);
			Assert.AreSame (UIElement.PreviewKeyUpEvent, Keyboard.PreviewKeyUpEvent);
			Assert.AreSame (UIElement.KeyUpEvent, Keyboard.KeyUpEvent);
			Assert.AreSame (UIElement.PreviewGotKeyboardFocusEvent, Keyboard.PreviewGotKeyboardFocusEvent);
			Assert.AreSame (UIElement.GotKeyboardFocusEvent, Keyboard.GotKeyboardFocusEvent);
			Assert.AreSame (UIElement.PreviewLostKeyboardFocusEvent, Keyboard.PreviewLostKeyboardFocusEvent);
			Assert.AreSame (UIElement.LostKeyboardFocusEvent, Keyboard.LostKeyboardFocusEvent);
			Assert.AreSame (UIElement.PreviewTextInputEvent, TextCompositionManager.PreviewTextInputEvent);
			Assert.AreSame (UIElement.TextInputEvent, TextCompositionManager.TextInputEvent);
			Assert.AreSame (UIElement.PreviewQueryContinueDragEvent, DragDrop.PreviewQueryContinueDragEvent);
			Assert.AreSame (UIElement.QueryContinueDragEvent, DragDrop.QueryContinueDragEvent);
			Assert.AreSame (UIElement.PreviewGiveFeedbackEvent, DragDrop.PreviewGiveFeedbackEvent);
			Assert.AreSame (UIElement.GiveFeedbackEvent, DragDrop.GiveFeedbackEvent);
			Assert.AreSame (UIElement.PreviewDragEnterEvent, DragDrop.PreviewDragEnterEvent);
			Assert.AreSame (UIElement.DragEnterEvent, DragDrop.DragEnterEvent);
			Assert.AreSame (UIElement.PreviewDragOverEvent, DragDrop.PreviewDragOverEvent);
			Assert.AreSame (UIElement.DragOverEvent, DragDrop.DragOverEvent);
			Assert.AreSame (UIElement.PreviewDragLeaveEvent, DragDrop.PreviewDragLeaveEvent);
			Assert.AreSame (UIElement.DragLeaveEvent, DragDrop.DragLeaveEvent);
			Assert.AreSame (UIElement.PreviewDropEvent, DragDrop.PreviewDropEvent);
			Assert.AreSame (UIElement.DropEvent, DragDrop.DropEvent);
			Assert.AreSame (UIElement.GotFocusEvent, FocusManager.GotFocusEvent);
			Assert.AreSame (UIElement.LostFocusEvent, FocusManager.LostFocusEvent);
		}
	}
}
