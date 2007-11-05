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
using System.Collections;

using System.Windows.Threading;

namespace System.Windows.Input {

	public sealed class InputManager : DispatcherObject {

		public static InputManager Current {
			get {
				throw new NotImplementedException ();
			}
		}

		public ICollection InputProviders {
			get {
				throw new NotImplementedException ();
			}
		}

		public InputDevice MostRecentInputDevice {
			get {
				throw new NotImplementedException ();
			}
		}

		public KeyboardDevice PrimaryKeyboardDevice {
			get {
				throw new NotImplementedException ();
			}
		}

		public MouseDevice PrimaryMouseDevice {
			get {
				throw new NotImplementedException ();
			}
		}

		public event EventHandler HitTestInvalidatedAsync;
#if notyet
		public event NotifyInputEventHandler PreNotifyInput;
		public event NotifyInputEventHandler PostNotifyInput;
		public event ProcessInputEventHandler PreProcessInput;
		public event ProcessInputEventHandler PostProcessInput;
#endif

		public bool ProcessInput (InputEventArgs input)
		{
				throw new NotImplementedException ();
		}
	}
}
