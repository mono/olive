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
	public class ContentElementTest {
		[Test]
		public void TestRoutedEvents ()
		{
			Assert.AreSame (ContentElement.DragEnterEvent, DragDrop.DragEnterEvent);
			Assert.AreSame (ContentElement.DragLeaveEvent, DragDrop.DragLeaveEvent);
			Assert.AreSame (ContentElement.DragOverEvent, DragDrop.DragOverEvent);
			Assert.AreSame (ContentElement.DropEvent, DragDrop.DropEvent);
			Assert.AreSame (ContentElement.GiveFeedbackEvent, DragDrop.GiveFeedbackEvent);
			Assert.AreSame (ContentElement.GotFocusEvent, FocusManager.GotFocusEvent);
			Assert.AreSame (ContentElement.GotKeyboardFocusEvent, Keyboard.GotKeyboardFocusEvent);
			Assert.AreSame (ContentElement.GotMouseCaptureEvent, Mouse.GotMouseCaptureEvent);
			//			Assert.AreSame (ContentElement.GotStylusCaptureEvent, Stylus.GotStylusCaptureEvent);
			Assert.AreSame (ContentElement.KeyDownEvent, Keyboard.KeyDownEvent);
			Assert.AreSame (ContentElement.KeyUpEvent, Keyboard.KeyUpEvent);
			Assert.AreSame (ContentElement.LostFocusEvent, FocusManager.LostFocusEvent);
			Assert.AreSame (ContentElement.LostKeyboardFocusEvent, Keyboard.LostKeyboardFocusEvent);
			Assert.AreSame (ContentElement.LostMouseCaptureEvent, Mouse.LostMouseCaptureEvent);
			//			Assert.AreSame (ContentElement.LostStylusCaptureEvent, Stylus.LostStylusCaptureEvent);
			Assert.AreSame (ContentElement.MouseDownEvent, Mouse.MouseDownEvent);
			Assert.AreSame (ContentElement.MouseEnterEvent, Mouse.MouseEnterEvent);
			Assert.AreSame (ContentElement.MouseLeaveEvent, Mouse.MouseLeaveEvent);
			Assert.AreSame (ContentElement.MouseLeftButtonDownEvent, UIElement.MouseLeftButtonDownEvent);
			Assert.AreSame (ContentElement.MouseLeftButtonUpEvent, UIElement.MouseLeftButtonUpEvent);
			Assert.AreSame (ContentElement.MouseMoveEvent, Mouse.MouseMoveEvent);
			Assert.AreSame (ContentElement.MouseRightButtonDownEvent, UIElement.MouseRightButtonDownEvent);
			Assert.AreSame (ContentElement.MouseRightButtonUpEvent, UIElement.MouseRightButtonUpEvent);
			Assert.AreSame (ContentElement.MouseUpEvent, Mouse.MouseUpEvent);
			Assert.AreSame (ContentElement.MouseWheelEvent, Mouse.MouseWheelEvent);

			Assert.AreSame (ContentElement.QueryContinueDragEvent, DragDrop.QueryContinueDragEvent);
			Assert.AreSame (ContentElement.QueryCursorEvent, Mouse.QueryCursorEvent);
// 			Assert.AreSame (ContentElement.StylusButtonDownEvent, Stylus.StylusButtonDownEvent);
// 			Assert.AreSame (ContentElement.StylusButtonUpEvent, Stylus.StylusButtonUpEvent);
// 			Assert.AreSame (ContentElement.StylusDownEvent, Stylus.StylusDownEvent);
// 			Assert.AreSame (ContentElement.StylusEnterEvent, Stylus.StylusEnterEvent);
// 			Assert.AreSame (ContentElement.StylusInAirMoveEvent, Stylus.StylusInAirMoveEvent);
// 			Assert.AreSame (ContentElement.StylusInRangeEvent, Stylus.StylusInRangeEvent);
// 			Assert.AreSame (ContentElement.StylusLeaveEvent, Stylus.StylusLeaveEvent);
// 			Assert.AreSame (ContentElement.StylusMoveEvent, Stylus.StylusMoveEvent);
// 			Assert.AreSame (ContentElement.StylusOutOfRangeEvent, Stylus.StylusOutOfRangeEvent);
// 			Assert.AreSame (ContentElement.StylusSystemGestureEvent, Stylus.StylusSystemGestureEvent);
// 			Assert.AreSame (ContentElement.StylusUpEvent, Stylus.StylusUpEvent);
			Assert.AreSame (ContentElement.TextInputEvent, TextCompositionManager.TextInputEvent);

			Assert.AreSame (ContentElement.PreviewDragEnterEvent, DragDrop.PreviewDragEnterEvent);
			Assert.AreSame (ContentElement.PreviewDragLeaveEvent, DragDrop.PreviewDragLeaveEvent);
			Assert.AreSame (ContentElement.PreviewDragOverEvent, DragDrop.PreviewDragOverEvent);
			Assert.AreSame (ContentElement.PreviewDropEvent, DragDrop.PreviewDropEvent);
			Assert.AreSame (ContentElement.PreviewGiveFeedbackEvent, DragDrop.PreviewGiveFeedbackEvent);
			Assert.AreSame (ContentElement.PreviewGotKeyboardFocusEvent, Keyboard.PreviewGotKeyboardFocusEvent);
			Assert.AreSame (ContentElement.PreviewKeyDownEvent, Keyboard.PreviewKeyDownEvent);
			Assert.AreSame (ContentElement.PreviewKeyUpEvent, Keyboard.PreviewKeyUpEvent);
			Assert.AreSame (ContentElement.PreviewLostKeyboardFocusEvent, Keyboard.PreviewLostKeyboardFocusEvent);
			Assert.AreSame (ContentElement.PreviewMouseDownEvent, Mouse.PreviewMouseDownEvent);
			Assert.AreSame (ContentElement.PreviewMouseLeftButtonDownEvent, UIElement.PreviewMouseLeftButtonDownEvent);
			Assert.AreSame (ContentElement.PreviewMouseLeftButtonUpEvent, UIElement.PreviewMouseLeftButtonUpEvent);
			Assert.AreSame (ContentElement.PreviewMouseMoveEvent, Mouse.PreviewMouseMoveEvent);
			Assert.AreSame (ContentElement.PreviewMouseRightButtonDownEvent, UIElement.PreviewMouseRightButtonDownEvent);
			Assert.AreSame (ContentElement.PreviewMouseRightButtonUpEvent, UIElement.PreviewMouseRightButtonUpEvent);
			Assert.AreSame (ContentElement.PreviewMouseUpEvent, Mouse.PreviewMouseUpEvent);
			Assert.AreSame (ContentElement.PreviewMouseWheelEvent, Mouse.PreviewMouseWheelEvent);
			Assert.AreSame (ContentElement.PreviewQueryContinueDragEvent, DragDrop.PreviewQueryContinueDragEvent);
// 			Assert.AreSame (ContentElement.PreviewStylusButtonDownEvent, Stylus.PreviewStylusButtonDownEvent);
// 			Assert.AreSame (ContentElement.PreviewStylusButtonUpEvent, Stylus.PreviewStylusButtonUpEvent);
// 			Assert.AreSame (ContentElement.PreviewStylusDownEvent, Stylus.PreviewStylusDownEvent);
// 			Assert.AreSame (ContentElement.PreviewStylusEnterEvent, Stylus.PreviewStylusEnterEvent);
// 			Assert.AreSame (ContentElement.PreviewStylusInAirMoveEvent, Stylus.PreviewStylusInAirMoveEvent);
// 			Assert.AreSame (ContentElement.PreviewStylusInRangeEvent, Stylus.PreviewStylusInRangeEvent);
// 			Assert.AreSame (ContentElement.PreviewStylusLeaveEvent, Stylus.PreviewStylusLeaveEvent);
// 			Assert.AreSame (ContentElement.PreviewStylusMoveEvent, Stylus.PreviewStylusMoveEvent);
// 			Assert.AreSame (ContentElement.PreviewStylusOutOfRangeEvent, Stylus.PreviewStylusOutOfRangeEvent);
// 			Assert.AreSame (ContentElement.PreviewStylusSystemGestureEvent, Stylus.PreviewStylusSystemGestureEvent);
// 			Assert.AreSame (ContentElement.PreviewStylusUpEvent, Stylus.PreviewStylusUpEvent);
			Assert.AreSame (ContentElement.PreviewTextInputEvent, TextCompositionManager.PreviewTextInputEvent);
		}
	}
}
