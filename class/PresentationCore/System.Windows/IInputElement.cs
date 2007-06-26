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
//	Chris Toshok (toshok@novell.com)
//

using System;
using System.Windows.Input;

namespace System.Windows {

	public interface IInputElement
	{
		void AddHandler (RoutedEvent routedEvent, Delegate handler);
		bool CaptureMouse ();
		bool CaptureStylus ();
		bool Focus ();
		void RaiseEvent (RoutedEventArgs e);
		void ReleaseMouseCapture ();
		void ReleaseStylusCapture ();
		void RemoveHandler (RoutedEvent routedEvent, Delegate handler);

		bool Focusable { get; set; }
		bool IsEnabled { get; }
		bool IsKeyboardFocused { get; }
		bool IsKeyboardFocusWithin { get; }
		bool IsMouseCaptured { get; }
		bool IsMouseDirectlyOver { get; }
		bool IsMouseOver { get; }
		bool IsStylusCaptured { get; }
		bool IsStylusDirectlyOver { get; }
		bool IsStylusOver { get; }

		event KeyboardFocusChangedEventHandler GotKeyboardFocus;
		event MouseEventHandler GotMouseCapture;
		event StylusEventHandler GotStylusCapture;
		event KeyEventHandler KeyDown;
		event KeyEventHandler KeyUp;
		event KeyboardFocusChangedEventHandler LostKeyboardFocus;
		event MouseEventHandler LostMouseCapture;
		event StylusEventHandler LostStylusCapture;
		event MouseEventHandler MouseEnter;
		event MouseEventHandler MouseLeave;
		event MouseButtonEventHandler MouseLeftButtonDown;
		event MouseButtonEventHandler MouseLeftButtonUp;
		event MouseEventHandler MouseMove;
		event MouseButtonEventHandler MouseRightButtonDown;
		event MouseButtonEventHandler MouseRightButtonUp;
// 		event MouseWheelEventHandler MouseWheel;
		event KeyboardFocusChangedEventHandler PreviewGotKeyboardFocus;
		event KeyEventHandler PreviewKeyDown;
		event KeyEventHandler PreviewKeyUp;
		event KeyboardFocusChangedEventHandler PreviewLostKeyboardFocus;
		event MouseButtonEventHandler PreviewMouseLeftButtonDown;
		event MouseButtonEventHandler PreviewMouseLeftButtonUp;
		event MouseEventHandler PreviewMouseMove;
		event MouseButtonEventHandler PreviewMouseRightButtonDown;
		event MouseButtonEventHandler PreviewMouseRightButtonUp;
// 		event MouseWheelEventHandler PreviewMouseWheel;
// 		event StylusButtonEventHandler PreviewStylusButtonDown;
// 		event StylusButtonEventHandler PreviewStylusButtonUp;
// 		event StylusDownEventHandler PreviewStylusDown;
		event StylusEventHandler PreviewStylusInAirMove;
		event StylusEventHandler PreviewStylusInRange;
		event StylusEventHandler PreviewStylusMove;
		event StylusEventHandler PreviewStylusOutOfRange;
// 		event StylusSystemGestureEventHandler PreviewStylusSystemGesture;
		event StylusEventHandler PreviewStylusUp;
//		event TextCompositionEventHandler PreviewTextInput;
// 		event StylusButtonEventHandler StylusButtonDown;
// 		event StylusButtonEventHandler StylusButtonUp;
// 		event StylusDownEventHandler StylusDown;
		event StylusEventHandler StylusEnter;
		event StylusEventHandler StylusInAirMove;
		event StylusEventHandler StylusInRange;
		event StylusEventHandler StylusLeave;
		event StylusEventHandler StylusMove;
		event StylusEventHandler StylusOutOfRange;
// 		event StylusSystemGestureEventHandler StylusSystemGesture;
		event StylusEventHandler StylusUp;
// 		event TextCompositionEventHandler TextInput;
	}

}
