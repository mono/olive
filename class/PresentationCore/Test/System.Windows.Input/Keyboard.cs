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
	public class KeyboardTest {

		[Test]
		public void RoutedEvents ()
		{
			Assert.AreEqual (typeof (Keyboard), Keyboard.PreviewKeyDownEvent.OwnerType);
			Assert.AreEqual ("PreviewKeyDown", Keyboard.PreviewKeyDownEvent.Name);
			Assert.AreEqual ("Keyboard.PreviewKeyDown", Keyboard.PreviewKeyDownEvent.ToString());
			Assert.AreEqual (typeof (KeyEventHandler), Keyboard.PreviewKeyDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Keyboard.PreviewKeyDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.KeyDownEvent.OwnerType);
			Assert.AreEqual ("KeyDown", Keyboard.KeyDownEvent.Name);
			Assert.AreEqual ("Keyboard.KeyDown", Keyboard.KeyDownEvent.ToString());
			Assert.AreEqual (typeof (KeyEventHandler), Keyboard.KeyDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Keyboard.KeyDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.PreviewKeyUpEvent.OwnerType);
			Assert.AreEqual ("PreviewKeyUp", Keyboard.PreviewKeyUpEvent.Name);
			Assert.AreEqual ("Keyboard.PreviewKeyUp", Keyboard.PreviewKeyUpEvent.ToString());
			Assert.AreEqual (typeof (KeyEventHandler), Keyboard.PreviewKeyUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Keyboard.PreviewKeyUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.KeyUpEvent.OwnerType);
			Assert.AreEqual ("KeyUp", Keyboard.KeyUpEvent.Name);
			Assert.AreEqual ("Keyboard.KeyUp", Keyboard.KeyUpEvent.ToString());
			Assert.AreEqual (typeof (KeyEventHandler), Keyboard.KeyUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Keyboard.KeyUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.PreviewGotKeyboardFocusEvent.OwnerType);
			Assert.AreEqual ("PreviewGotKeyboardFocus", Keyboard.PreviewGotKeyboardFocusEvent.Name);
			Assert.AreEqual ("Keyboard.PreviewGotKeyboardFocus", Keyboard.PreviewGotKeyboardFocusEvent.ToString());
			Assert.AreEqual (typeof (KeyboardFocusChangedEventHandler), Keyboard.PreviewGotKeyboardFocusEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Keyboard.PreviewGotKeyboardFocusEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.GotKeyboardFocusEvent.OwnerType);
			Assert.AreEqual ("GotKeyboardFocus", Keyboard.GotKeyboardFocusEvent.Name);
			Assert.AreEqual ("Keyboard.GotKeyboardFocus", Keyboard.GotKeyboardFocusEvent.ToString());
			Assert.AreEqual (typeof (KeyboardFocusChangedEventHandler), Keyboard.GotKeyboardFocusEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Keyboard.GotKeyboardFocusEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.PreviewLostKeyboardFocusEvent.OwnerType);
			Assert.AreEqual ("PreviewLostKeyboardFocus", Keyboard.PreviewLostKeyboardFocusEvent.Name);
			Assert.AreEqual ("Keyboard.PreviewLostKeyboardFocus", Keyboard.PreviewLostKeyboardFocusEvent.ToString());
			Assert.AreEqual (typeof (KeyboardFocusChangedEventHandler), Keyboard.PreviewLostKeyboardFocusEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Keyboard.PreviewLostKeyboardFocusEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.LostKeyboardFocusEvent.OwnerType);
			Assert.AreEqual ("LostKeyboardFocus", Keyboard.LostKeyboardFocusEvent.Name);
			Assert.AreEqual ("Keyboard.LostKeyboardFocus", Keyboard.LostKeyboardFocusEvent.ToString());
			Assert.AreEqual (typeof (KeyboardFocusChangedEventHandler), Keyboard.LostKeyboardFocusEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Keyboard.LostKeyboardFocusEvent.RoutingStrategy);
		}
	}

}