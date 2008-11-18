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
	public class UIElement3DTest {

		[Test]
		public void TestRoutedEvents ()
		{
#if notyet
			Assert.AreSame (UIElement3D.PreviewMouseDownEvent, Mouse.PreviewMouseDownEvent);
			Assert.AreSame (UIElement3D.MouseDownEvent, Mouse.MouseDownEvent);
			Assert.AreSame (UIElement3D.PreviewMouseUpEvent, Mouse.PreviewMouseUpEvent);
			Assert.AreSame (UIElement3D.MouseUpEvent, Mouse.MouseUpEvent);
			Assert.AreSame (UIElement3D.PreviewMouseLeftButtonDownEvent, UIElement.PreviewMouseLeftButtonDownEvent);
			Assert.AreSame (UIElement3D.MouseLeftButtonDownEvent, UIElement.MouseLeftButtonDownEvent);
			Assert.AreSame (UIElement3D.PreviewMouseLeftButtonUpEvent, UIElement.PreviewMouseLeftButtonUpEvent);
			Assert.AreSame (UIElement3D.MouseLeftButtonUpEvent, UIElement.MouseLeftButtonUpEvent);
			Assert.AreSame (UIElement3D.PreviewMouseRightButtonDownEvent, UIElement.PreviewMouseRightButtonDownEvent);
			Assert.AreSame (UIElement3D.MouseRightButtonDownEvent, UIElement.MouseRightButtonDownEvent);
			Assert.AreSame (UIElement3D.PreviewMouseRightButtonUpEvent, UIElement.PreviewMouseRightButtonUpEvent);
			Assert.AreSame (UIElement3D.MouseRightButtonUpEvent, UIElement.MouseRightButtonUpEvent);
			Assert.AreSame (UIElement3D.PreviewMouseMoveEvent, Mouse.PreviewMouseMoveEvent);
			Assert.AreSame (UIElement3D.MouseMoveEvent, Mouse.MouseMoveEvent);
			Assert.AreSame (UIElement3D.PreviewMouseWheelEvent, Mouse.PreviewMouseWheelEvent);
			Assert.AreSame (UIElement3D.MouseWheelEvent, Mouse.MouseWheelEvent);
			Assert.AreSame (UIElement3D.MouseEnterEvent, Mouse.MouseEnterEvent);
			Assert.AreSame (UIElement3D.MouseLeaveEvent, Mouse.MouseLeaveEvent);
			Assert.AreSame (UIElement3D.GotMouseCaptureEvent, Mouse.GotMouseCaptureEvent);
			Assert.AreSame (UIElement3D.LostMouseCaptureEvent, Mouse.LostMouseCaptureEvent);
			Assert.AreSame (UIElement3D.QueryCursorEvent, Mouse.QueryCursorEvent);
			Assert.AreSame (UIElement3D.PreviewStylusDownEvent, Stylus.PreviewStylusDownEvent);
			Assert.AreSame (UIElement3D.StylusDownEvent, Stylus.StylusDownEvent);
			Assert.AreSame (UIElement3D.PreviewStylusUpEvent, Stylus.PreviewStylusUpEvent);
			Assert.AreSame (UIElement3D.StylusUpEvent, Stylus.StylusUpEvent);
			Assert.AreSame (UIElement3D.PreviewStylusMoveEvent, Stylus.PreviewStylusMoveEvent);
			Assert.AreSame (UIElement3D.StylusMoveEvent, Stylus.StylusMoveEvent);
			Assert.AreSame (UIElement3D.PreviewStylusInAirMoveEvent, Stylus.PreviewStylusInAirMoveEvent);
			Assert.AreSame (UIElement3D.StylusInAirMoveEvent, Stylus.StylusInAirMoveEvent);
			Assert.AreSame (UIElement3D.StylusEnterEvent, Stylus.StylusEnterEvent);
			Assert.AreSame (UIElement3D.StylusLeaveEvent, Stylus.StylusLeaveEvent);
			Assert.AreSame (UIElement3D.PreviewStylusInRangeEvent, Stylus.PreviewStylusInRangeEvent);
			Assert.AreSame (UIElement3D.StylusInRangeEvent, Stylus.StylusInRangeEvent);
			Assert.AreSame (UIElement3D.PreviewStylusOutOfRangeEvent, Stylus.PreviewStylusOutOfRangeEvent);
			Assert.AreSame (UIElement3D.StylusOutOfRangeEvent, Stylus.StylusOutOfRangeEvent);
			Assert.AreSame (UIElement3D.PreviewStylusSystemGestureEvent, Stylus.PreviewStylusSystemGestureEvent);
			Assert.AreSame (UIElement3D.StylusSystemGestureEvent, Stylus.StylusSystemGestureEvent);
			Assert.AreSame (UIElement3D.GotStylusCaptureEvent, Stylus.GotStylusCaptureEvent);
			Assert.AreSame (UIElement3D.LostStylusCaptureEvent, Stylus.LostStylusCaptureEvent);
			Assert.AreSame (UIElement3D.StylusButtonDownEvent, Stylus.StylusButtonDownEvent);
			Assert.AreSame (UIElement3D.StylusButtonUpEvent, Stylus.StylusButtonUpEvent);
			Assert.AreSame (UIElement3D.PreviewStylusButtonDownEvent, Stylus.PreviewStylusButtonDownEvent);
			Assert.AreSame (UIElement3D.PreviewStylusButtonUpEvent, Stylus.PreviewStylusButtonUpEvent);
			Assert.AreSame (UIElement3D.PreviewKeyDownEvent, Keyboard.PreviewKeyDownEvent);
			Assert.AreSame (UIElement3D.KeyDownEvent, Keyboard.KeyDownEvent);
			Assert.AreSame (UIElement3D.PreviewKeyUpEvent, Keyboard.PreviewKeyUpEvent);
			Assert.AreSame (UIElement3D.KeyUpEvent, Keyboard.KeyUpEvent);
			Assert.AreSame (UIElement3D.PreviewGotKeyboardFocusEvent, Keyboard.PreviewGotKeyboardFocusEvent);
			Assert.AreSame (UIElement3D.GotKeyboardFocusEvent, Keyboard.GotKeyboardFocusEvent);
			Assert.AreSame (UIElement3D.PreviewLostKeyboardFocusEvent, Keyboard.PreviewLostKeyboardFocusEvent);
			Assert.AreSame (UIElement3D.LostKeyboardFocusEvent, Keyboard.LostKeyboardFocusEvent);
			Assert.AreSame (UIElement3D.PreviewTextInputEvent, TextCompositionManager.PreviewTextInputEvent);
			Assert.AreSame (UIElement3D.TextInputEvent, TextCompositionManager.TextInputEvent);
			Assert.AreSame (UIElement3D.PreviewQueryContinueDragEvent, DragDrop.PreviewQueryContinueDragEvent);
			Assert.AreSame (UIElement3D.QueryContinueDragEvent, DragDrop.QueryContinueDragEvent);
			Assert.AreSame (UIElement3D.PreviewGiveFeedbackEvent, DragDrop.PreviewGiveFeedbackEvent);
			Assert.AreSame (UIElement3D.GiveFeedbackEvent, DragDrop.GiveFeedbackEvent);
			Assert.AreSame (UIElement3D.PreviewDragEnterEvent, DragDrop.PreviewDragEnterEvent);
			Assert.AreSame (UIElement3D.DragEnterEvent, DragDrop.DragEnterEvent);
			Assert.AreSame (UIElement3D.PreviewDragOverEvent, DragDrop.PreviewDragOverEvent);
			Assert.AreSame (UIElement3D.DragOverEvent, DragDrop.DragOverEvent);
			Assert.AreSame (UIElement3D.PreviewDragLeaveEvent, DragDrop.PreviewDragLeaveEvent);
			Assert.AreSame (UIElement3D.DragLeaveEvent, DragDrop.DragLeaveEvent);
			Assert.AreSame (UIElement3D.PreviewDropEvent, DragDrop.PreviewDropEvent);
			Assert.AreSame (UIElement3D.DropEvent, DragDrop.DropEvent);
			Assert.AreSame (UIElement3D.GotFocusEvent, FocusManager.GotFocusEvent);
			Assert.AreSame (UIElement3D.LostFocusEvent, FocusManager.LostFocusEvent);
#endif
		}
	}
}
