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

using System.Security;

using System.Windows.Threading;

using System.Windows.Input.X11;
#if notyet
using System.Windows.Input.Win32;
#endif

namespace System.Windows.Input {

	public sealed class InputManager : DispatcherObject {

		static InputManager current;
		KeyboardDevice keyboardDevice;
		MouseDevice mouseDevice;

		internal InputManager ()
		{
		}

		public static InputManager Current {
			[SecurityCritical]
			get {
				if (current == null) {
					current = new InputManager ();

					KeyboardDevice key;
					MouseDevice mouse;

					if (Environment.OSVersion.Platform == PlatformID.Unix) {
						// XXX need a way to differentiate MacOS from linux
						key = new X11KeyboardDevice(current);
						mouse = new X11MouseDevice(current);
					}
					else {
#if notyet
						key = new Win32KeyboardDevice(current);
						mouse = new Win32MouseDevice(current);
#else
						key = null;
						mouse = null;
#endif
					}

					current.SetPrimaryKeyboardDevice (key);
					current.SetPrimaryMouseDevice (mouse);
				}

				return current;
			}
		}

		public ICollection InputProviders {
			[SecurityCritical]
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
			get { return keyboardDevice; }
		}

		public MouseDevice PrimaryMouseDevice {
			get { return mouseDevice; }
		}

		public event EventHandler HitTestInvalidatedAsync;
		public event NotifyInputEventHandler PreNotifyInput;
		public event NotifyInputEventHandler PostNotifyInput;
		public event PreProcessInputEventHandler PreProcessInput;
		public event ProcessInputEventHandler PostProcessInput;

		[SecurityCritical]
		public bool ProcessInput (InputEventArgs input)
		{
			StagingAreaInputItem stagingItem = new StagingAreaInputItem (input);

			PreProcessInputEventArgs preProcessArgs = new PreProcessInputEventArgs(this, stagingItem);
			if (PreProcessInput != null)
				PreProcessInput (this, preProcessArgs);

			NotifyInputEventArgs notifyArgs = new NotifyInputEventArgs(this, stagingItem);
			if (PreNotifyInput != null)
				PreNotifyInput (this, notifyArgs);

#if notyet
			if (!preProcessArgs.Canceled)
				/* XXX route the event */;
#endif

			if (PostNotifyInput != null)
				PostNotifyInput (this, notifyArgs);

			if (PostProcessInput != null) {
				ProcessInputEventArgs processArgs = new ProcessInputEventArgs (this, stagingItem);
				PostProcessInput (this, processArgs);
			}

			return true;
		}

		void SetPrimaryKeyboardDevice (KeyboardDevice keyboardDevice)
		{
			this.keyboardDevice = keyboardDevice;
		}

		void SetPrimaryMouseDevice (MouseDevice mouseDevice)
		{
			this.mouseDevice = mouseDevice;
		}
	}
}
