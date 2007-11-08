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

	public class MouseEventArgs : InputEventArgs {

		public MouseEventArgs (MouseDevice mouse, int timestamp)
			: base (mouse, timestamp)
		{
		}

		public MouseEventArgs (MouseDevice mouse, int timestamp, StylusDevice stylusDevice)
			: base (mouse, timestamp)
		{
			this.stylusDevice = stylusDevice;
		}

		protected override void InvokeEventHandler (Delegate genericHandler, object genericTarget)
		{
			((MouseEventHandler)genericHandler)(genericTarget, this);
		}

		public Point GetPosition (IInputElement relativeTo)
		{
			return MouseDevice.GetPosition (relativeTo);
		}

		public MouseDevice MouseDevice {
			get { return (MouseDevice)Device; }
		}

		public StylusDevice StylusDevice {
			get { return stylusDevice; }
		}

		public MouseButtonState LeftButton {
			get { return MouseDevice.LeftButton; }
		}

		public MouseButtonState MiddleButton {
			get { return MouseDevice.MiddleButton; }
		}

		public MouseButtonState RightButton {
			get { return MouseDevice.RightButton; }
		}

		public MouseButtonState XButton1 {
			get { return MouseDevice.XButton1; }
		}

		public MouseButtonState XButton2 {
			get { return MouseDevice.XButton2; }
		}

		StylusDevice stylusDevice;
	}

}
