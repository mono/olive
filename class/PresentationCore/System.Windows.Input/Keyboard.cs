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

namespace System.Windows.Input {

	public static class Keyboard {
		public static void AddGotKeyboardFocusHandler (DependencyObject element, KeyboardFocusChangedEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemoveGotKeyboardFocusHandler (DependencyObject element, KeyboardFocusChangedEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void AddLostKeyboardFocusHandler (DependencyObject element, KeyboardFocusChangedEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemoveLostKeyboardFocusHandler (DependencyObject element, KeyboardFocusChangedEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void AddPreviewGotKeyboardFocusHandler (DependencyObject element, KeyboardFocusChangedEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemovePreviewGotKeyboardFocusHandler (DependencyObject element, KeyboardFocusChangedEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void AddPreviewLostKeyboardFocusHandler (DependencyObject element, KeyboardFocusChangedEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemovePreviewLostKeyboardFocusHandler (DependencyObject element, KeyboardFocusChangedEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void AddKeyDownHandler (DependencyObject element, KeyEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemoveKeyDownHandler (DependencyObject element, KeyEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void AddKeyUpHandler (DependencyObject element, KeyEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemoveKeyUpHandler (DependencyObject element, KeyEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void AddPreviewKeyDownHandler (DependencyObject element, KeyEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemovePreviewKeyDownHandler (DependencyObject element, KeyEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void AddPreviewKeyUpHandler (DependencyObject element, KeyEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemovePreviewKeyUpHandler (DependencyObject element, KeyEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static IInputElement Focus (IInputElement element)
		{
			return PrimaryDevice.Focus (element);
		}

		public static KeyStates GetKeyStates (Key key)
		{
			return PrimaryDevice.GetKeyStates (key);
		}

		public static bool IsKeyDown (Key key)
		{
			return PrimaryDevice.IsKeyDown (key);
		}

		public static bool IsKeyToggled (Key key)
		{
			return PrimaryDevice.IsKeyToggled (key);
		}

		public static bool IsKeyUp (Key key)
		{
			return PrimaryDevice.IsKeyUp (key);
		}

		public static IInputElement FocusedElement {
			get { return PrimaryDevice.FocusedElement; }
		}

		public static ModifierKeys Modifiers {
			get { return PrimaryDevice.Modifiers; }
		}

		public static KeyboardDevice PrimaryDevice {
			get { return InputManager.Current.PrimaryKeyboardDevice; }
		}

		public static readonly RoutedEvent GotKeyboardFocusEvent;
		public static readonly RoutedEvent LostKeyboardFocusEvent;
		public static readonly RoutedEvent KeyDownEvent;
		public static readonly RoutedEvent KeyUpEvent;

		public static readonly RoutedEvent PreviewGotKeyboardFocusEvent;
		public static readonly RoutedEvent PreviewLostKeyboardFocusEvent;
		public static readonly RoutedEvent PreviewKeyDownEvent;
		public static readonly RoutedEvent PreviewKeyUpEvent;
	}

}
