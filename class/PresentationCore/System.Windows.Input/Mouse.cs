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
using System.Security;
using System.Windows;

namespace System.Windows.Input {

	public static class Mouse {
		public const int MouseWheelDeltaForOneLine = 120;

		public static readonly RoutedEvent GotMouseCaptureEvent = new RoutedEvent ("GotMouseCapture",
											   typeof (MouseEventHandler),
											   typeof (Mouse),
											   RoutingStrategy.Bubble);
		public static readonly RoutedEvent LostMouseCaptureEvent = new RoutedEvent ("LostMouseCapture",
											    typeof (MouseEventHandler),
											    typeof (Mouse),
											    RoutingStrategy.Bubble);
		public static readonly RoutedEvent MouseDownEvent = new RoutedEvent ("MouseDown",
										     typeof (MouseButtonEventHandler),
										     typeof (Mouse),
										     RoutingStrategy.Bubble);
		public static readonly RoutedEvent MouseEnterEvent = new RoutedEvent ("MouseEnter",
										      typeof (MouseEventHandler),
										      typeof (Mouse),
										      RoutingStrategy.Direct);
		public static readonly RoutedEvent MouseLeaveEvent = new RoutedEvent ("MouseLeave",
										     typeof (MouseEventHandler),
										     typeof (Mouse),
										     RoutingStrategy.Direct);
		public static readonly RoutedEvent MouseMoveEvent = new RoutedEvent ("MouseMove",
										     typeof (MouseEventHandler),
										     typeof (Mouse),
										     RoutingStrategy.Bubble);
		public static readonly RoutedEvent MouseUpEvent = new RoutedEvent ("MouseUp",
										   typeof (MouseButtonEventHandler),
										   typeof (Mouse),
										   RoutingStrategy.Bubble);
		public static readonly RoutedEvent MouseWheelEvent = new RoutedEvent ("MouseWheel",
										      typeof (MouseWheelEventHandler),
										      typeof (Mouse),
										      RoutingStrategy.Bubble);
		public static readonly RoutedEvent PreviewMouseDownEvent = new RoutedEvent ("PreviewMouseDown",
											    typeof (MouseButtonEventHandler),
											    typeof (Mouse),
											    RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewMouseDownOutsideCapturedElementEvent = new RoutedEvent ("PreviewMouseDownOutsideCapturedElement",
														  typeof (MouseButtonEventHandler),
														  typeof (Mouse),
														  RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewMouseMoveEvent = new RoutedEvent ("PreviewMouseMove",
											    typeof (MouseEventHandler),
											    typeof (Mouse),
											    RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewMouseUpEvent = new RoutedEvent ("PreviewMouseUp",
											  typeof (MouseButtonEventHandler),
											  typeof (Mouse),
											  RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewMouseUpOutsideCapturedElementEvent = new RoutedEvent ("PreviewMouseUpOutsideCapturedElement",
														typeof (MouseButtonEventHandler),
														typeof (Mouse),
														RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewMouseWheelEvent = new RoutedEvent ("PreviewMouseWheel",
											     typeof (MouseWheelEventHandler),
											     typeof (Mouse),
											     RoutingStrategy.Tunnel);
		public static readonly RoutedEvent QueryCursorEvent = new RoutedEvent ("QueryCursor",
										       typeof (QueryCursorEventHandler),
										       typeof (Mouse),
										       RoutingStrategy.Bubble);

		public static IInputElement Captured {
			get { return PrimaryDevice.Captured; }
		}

		public static IInputElement DirectlyOver {
			get { return PrimaryDevice.DirectlyOver; }
		}

		public static MouseButtonState LeftButton {
			get { return PrimaryDevice.LeftButton; }
		}

		public static MouseButtonState MiddleButton {
			get { return PrimaryDevice.MiddleButton; }
		}

		public static Cursor OverrideCursor {
			get { return PrimaryDevice.OverrideCursor; }
			set { PrimaryDevice.OverrideCursor = value; }
		}

		public static MouseDevice PrimaryDevice {
			[SecurityCritical]
			get { return InputManager.Current.PrimaryMouseDevice; }
		}

		public static MouseButtonState RightButton {
			get { return PrimaryDevice.RightButton; }
		}

		public static MouseButtonState XButton1 {
			get { return PrimaryDevice.XButton1; }
		}

		public static MouseButtonState XButton2 {
			get { return PrimaryDevice.XButton2; }
		}

		public static void AddGotMouseCaptureHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (GotMouseCaptureEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (GotMouseCaptureEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddLostMouseCaptureHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (LostMouseCaptureEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (LostMouseCaptureEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddMouseDownHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (MouseDownEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (MouseDownEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddMouseEnterHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (MouseEnterEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (MouseEnterEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddMouseLeaveHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (MouseLeaveEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (MouseLeaveEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddMouseMoveHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (MouseMoveEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (MouseMoveEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddMouseUpHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (MouseUpEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (MouseUpEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddMouseWheelHandler (DependencyObject element, MouseWheelEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (MouseWheelEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (MouseWheelEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddPreviewMouseDownHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (PreviewMouseDownEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (PreviewMouseDownEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddPreviewMouseDownOutsideCapturedElementHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (PreviewMouseDownOutsideCapturedElementEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (PreviewMouseDownOutsideCapturedElementEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddPreviewMouseMoveHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (PreviewMouseMoveEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (PreviewMouseMoveEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddPreviewMouseUpHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (PreviewMouseUpEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (PreviewMouseUpEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddPreviewMouseUpOutsideCapturedElementHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (PreviewMouseUpOutsideCapturedElementEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (PreviewMouseUpOutsideCapturedElementEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddPreviewMouseWheelHandler (DependencyObject element, MouseWheelEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (PreviewMouseWheelEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (PreviewMouseWheelEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void AddQueryCursorHandler (DependencyObject element, QueryCursorEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (QueryCursorEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (QueryCursorEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static bool Capture (IInputElement element)
		{
			return PrimaryDevice.Capture (element);
		}

		public static bool Capture (IInputElement element, CaptureMode captureMode)
		{
			return PrimaryDevice.Capture (element, captureMode);
		}

		[SecurityCritical]
		public static int GetIntermediatePoints (IInputElement relativeTo, Point[] points)
		{
			throw new NotImplementedException ();
		}

		public static Point GetPosition (IInputElement relativeTo)
		{
			return PrimaryDevice.GetPosition (relativeTo);
		}

		public static void RemoveGotMouseCaptureHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (GotMouseCaptureEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (GotMouseCaptureEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemoveLostMouseCaptureHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (LostMouseCaptureEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (LostMouseCaptureEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemoveMouseDownHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (MouseDownEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (MouseDownEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemoveMouseEnterHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (MouseEnterEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (MouseEnterEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemoveMouseLeaveHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (MouseLeaveEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (MouseLeaveEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemoveMouseMoveHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (MouseMoveEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (MouseMoveEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemoveMouseUpHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (MouseUpEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (MouseUpEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemoveMouseWheelHandler (DependencyObject element, MouseWheelEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (MouseWheelEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (MouseWheelEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemovePreviewMouseDownHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (PreviewMouseDownEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (PreviewMouseDownEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemovePreviewMouseDownOutsideCapturedElementHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (PreviewMouseDownOutsideCapturedElementEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (PreviewMouseDownOutsideCapturedElementEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemovePreviewMouseMoveHandler (DependencyObject element, MouseEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (PreviewMouseMoveEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (PreviewMouseMoveEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemovePreviewMouseUpHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (PreviewMouseUpEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (PreviewMouseUpEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemovePreviewMouseUpOutsideCapturedElementHandler (DependencyObject element, MouseButtonEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (PreviewMouseUpOutsideCapturedElementEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (PreviewMouseUpOutsideCapturedElementEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemovePreviewMouseWheelHandler (DependencyObject element, MouseWheelEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (PreviewMouseWheelEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (PreviewMouseWheelEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void RemoveQueryCursorHandler (DependencyObject element, QueryCursorEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (QueryCursorEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (QueryCursorEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static bool SetCursor (Cursor cursor)
		{
			return PrimaryDevice.SetCursor (cursor);
		}

		public static void Synchronize ()
		{
			PrimaryDevice.Synchronize ();
		}

		public static void UpdateCursor ()
		{
			PrimaryDevice.UpdateCursor ();
		}
	}
}
