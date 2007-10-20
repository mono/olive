//
// System.Windows.Input.MouseEventArgs
//
// Author:
//   Miguel de Icaza (miguel@novell.com)
//
// Copyright 2007 Novell, Inc.
//
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
using Mono;
namespace System.Windows.Input {
	
	public sealed class MouseEventArgs : EventArgs {
		int state;
		double x, y;
		
		internal MouseEventArgs (int state, double x, double y)
		{
			this.state = state;
			this.x = x;
			this.y = y;
		}
		
		public MouseEventArgs ()
		{
		}

		public Point GetPosition (UIElement uiElement)
		{
			double nx = x;
			double ny = y;

			// from the samples it seems null is a valid value
			if (uiElement != null)
				NativeMethods.uielement_transform_point (uiElement.native, ref nx, ref ny);

			return new Point (nx, ny);
		}

#if not_yet_done
		public StylusInfo GetStylusInfo ()
		{
			return null;
		}
		
		public StylusPointCollection GetStylusPoints (UIElement uiElement)
		{
			return null;
		}
#endif
		
		public bool Ctrl {
			get { return (state & 4) != 0; }
			set {
				if (value)
					state |= 4;
				else
					state &= ~4;
			}
		}
		public bool Shift {
			get { return (state & 1) != 0; } 
			set {
				if (value)
					state |= 1;
				else
					state &= ~1;
			}
		}
	}
}
