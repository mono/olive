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
using NUnit.Framework;

namespace MonoTests.System.Windows.Input {

	[TestFixture]
	public class MouseTest {

		[Test]
		public void RoutedEvents ()
		{
			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseMoveEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseMove", Mouse.PreviewMouseMoveEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseMove", Mouse.PreviewMouseMoveEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.PreviewMouseMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseMoveEvent.OwnerType);
			Assert.AreEqual ("MouseMove", Mouse.MouseMoveEvent.Name);
			Assert.AreEqual ("Mouse.MouseMove", Mouse.MouseMoveEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.MouseMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.MouseMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseDownOutsideCapturedElementEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseDownOutsideCapturedElement", Mouse.PreviewMouseDownOutsideCapturedElementEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseDownOutsideCapturedElement", Mouse.PreviewMouseDownOutsideCapturedElementEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.PreviewMouseDownOutsideCapturedElementEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseDownOutsideCapturedElementEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseUpOutsideCapturedElementEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseUpOutsideCapturedElement", Mouse.PreviewMouseUpOutsideCapturedElementEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseUpOutsideCapturedElement", Mouse.PreviewMouseUpOutsideCapturedElementEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.PreviewMouseUpOutsideCapturedElementEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseUpOutsideCapturedElementEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseDownEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseDown", Mouse.PreviewMouseDownEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseDown", Mouse.PreviewMouseDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.PreviewMouseDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseDownEvent.OwnerType);
			Assert.AreEqual ("MouseDown", Mouse.MouseDownEvent.Name);
			Assert.AreEqual ("Mouse.MouseDown", Mouse.MouseDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.MouseDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.MouseDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseUpEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseUp", Mouse.PreviewMouseUpEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseUp", Mouse.PreviewMouseUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.PreviewMouseUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseUpEvent.OwnerType);
			Assert.AreEqual ("MouseUp", Mouse.MouseUpEvent.Name);
			Assert.AreEqual ("Mouse.MouseUp", Mouse.MouseUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.MouseUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.MouseUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseWheelEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseWheel", Mouse.PreviewMouseWheelEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseWheel", Mouse.PreviewMouseWheelEvent.ToString());
			Assert.AreEqual (typeof (MouseWheelEventHandler), Mouse.PreviewMouseWheelEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseWheelEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseWheelEvent.OwnerType);
			Assert.AreEqual ("MouseWheel", Mouse.MouseWheelEvent.Name);
			Assert.AreEqual ("Mouse.MouseWheel", Mouse.MouseWheelEvent.ToString());
			Assert.AreEqual (typeof (MouseWheelEventHandler), Mouse.MouseWheelEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.MouseWheelEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseEnterEvent.OwnerType);
			Assert.AreEqual ("MouseEnter", Mouse.MouseEnterEvent.Name);
			Assert.AreEqual ("Mouse.MouseEnter", Mouse.MouseEnterEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.MouseEnterEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, Mouse.MouseEnterEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseLeaveEvent.OwnerType);
			Assert.AreEqual ("MouseLeave", Mouse.MouseLeaveEvent.Name);
			Assert.AreEqual ("Mouse.MouseLeave", Mouse.MouseLeaveEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.MouseLeaveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, Mouse.MouseLeaveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.GotMouseCaptureEvent.OwnerType);
			Assert.AreEqual ("GotMouseCapture", Mouse.GotMouseCaptureEvent.Name);
			Assert.AreEqual ("Mouse.GotMouseCapture", Mouse.GotMouseCaptureEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.GotMouseCaptureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.GotMouseCaptureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.LostMouseCaptureEvent.OwnerType);
			Assert.AreEqual ("LostMouseCapture", Mouse.LostMouseCaptureEvent.Name);
			Assert.AreEqual ("Mouse.LostMouseCapture", Mouse.LostMouseCaptureEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.LostMouseCaptureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.LostMouseCaptureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.QueryCursorEvent.OwnerType);
			Assert.AreEqual ("QueryCursor", Mouse.QueryCursorEvent.Name);
			Assert.AreEqual ("Mouse.QueryCursor", Mouse.QueryCursorEvent.ToString());
			Assert.AreEqual (typeof (QueryCursorEventHandler), Mouse.QueryCursorEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.QueryCursorEvent.RoutingStrategy);
		}
	}

}