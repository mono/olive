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

namespace System.Windows.Input {

	public abstract class MouseDevice : InputDevice {

		internal MouseDevice (InputManager manager)
		{
		}

		[SecurityCritical]
		public bool Capture (IInputElement element, CaptureMode captureMode)
		{
			throw new NotImplementedException ();
		}

		public bool Capture (IInputElement element)
		{
			throw new NotImplementedException ();
		}

		protected MouseButtonState GetButtonState (MouseButton mouseButton)
		{
			throw new NotImplementedException ();
		}

		protected Point GetClientPosition (PresentationSource presentationSource)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		[SecurityTreatAsSafe]
		protected Point GetClientPosition ()
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public Point GetPosition (IInputElement relativeTo)
		{
			throw new NotImplementedException ();
		}

		protected Point GetScreenPosition ()
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public bool SetCursor (Cursor cursor)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public void Synchronize ()
		{
			throw new NotImplementedException ();
		}

		public void UpdateCursor ()
		{
			throw new NotImplementedException ();
		}

		public override PresentationSource ActiveSource {
			[SecurityCritical]
			get {
				throw new NotImplementedException ();
			}
		}

		public IInputElement Captured {
			get {
				throw new NotImplementedException ();
			}
		}

		public IInputElement DirectlyOver {
			get {
				throw new NotImplementedException ();
			}
		}

		public MouseButtonState LeftButton {
			get {
				throw new NotImplementedException ();
			}
		}

		public MouseButtonState MiddleButton {
			get {
				throw new NotImplementedException ();
			}
		}

		public MouseButtonState RightButton {
			get {
				throw new NotImplementedException ();
			}
		}

		public MouseButtonState XButton1 {
			get {
				throw new NotImplementedException ();
			}
		}

		public MouseButtonState XButton2 {
			get {
				throw new NotImplementedException ();
			}
		}

		public Cursor OverrideCursor {
			set {
				throw new NotImplementedException ();
			}
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
