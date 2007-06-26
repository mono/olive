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

	public abstract class KeyboardDevice : InputDevice {
		protected KeyboardDevice (InputManager inputManager)
		{
			throw new NotImplementedException ();
		}

		public IInputElement Focus (IInputElement element)
		{
			throw new NotImplementedException ();
		}

		public KeyStates GetKeyStates (Key key)
		{
			throw new NotImplementedException ();
		}

		protected abstract KeyStates GetKeyStatesFromSystem (Key key);

		public bool IsKeyDown (Key key)
		{
			throw new NotImplementedException ();
		}

		public bool IsKeyToggled (Key key)
		{
			throw new NotImplementedException ();
		}

		public bool IsKeyUp (Key key)
		{
			throw new NotImplementedException ();
		}

		public override PresentationSource ActiveSource {
			get {
				throw new NotImplementedException ();
			}
		}

		public IInputElement FocusedElement {
			get {
				throw new NotImplementedException ();
			}
		}

		public ModifierKeys ModifierKeys {
			get {
				throw new NotImplementedException ();
			}
		}

		public override IInputElement Target {
			get {
				throw new NotImplementedException ();
			}
		}
	}
}
