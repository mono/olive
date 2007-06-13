//
// KeyboardEventArgs.cs
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

namespace System.Windows.Input {
	
	public sealed class MouseEventArgs : EventArgs {
		DependencyObject o;
		int state;
		double x, y;
		
		internal MouseEventArgs (DependencyObject o, int state, double x, double y)
		{
			this.o = o;
			this.state = state;
			this.x = x;
			this.y = y;
		}
		
		public MouseEventArgs ()
		{
		}

		public Point GetPosition (UIElement uiElement)
		{
			Console.WriteLine ("We should get the matrix and figure what this really is");
			return new Point (x, y);
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
