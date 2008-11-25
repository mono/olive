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
// Copyright (c) 2008 Novell, Inc. (http://www.novell.com)
//
// Author:
//	Chris Toshok (toshok@ximian.com)
//

using System.Windows;
using System.Windows.Media.Animation;

namespace System.Windows.Media {

	public class Pen : Animatable {

		public Pen (Brush brush, double thickness)
		{
			Brush = brush;
			Thickness = thickness;
		}

		public Pen ()
		{
		}

		public Pen Clone ()
		{
			throw new NotImplementedException ();
		}

		public Pen CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			throw new NotImplementedException ();
		}

		public static readonly DependencyProperty LineJoinProperty;
		public PenLineJoin LineJoin {
		    get { return (PenLineJoin)GetValue (LineJoinProperty); }
		    set { SetValue (LineJoinProperty, value); }
		}

		public static readonly DependencyProperty EndLineCapProperty;
		public PenLineCap EndLineCap {
		    get { return (PenLineCap)GetValue (EndLineCapProperty); }
		    set { SetValue (EndLineCapProperty, value); }
		}

		public static readonly DependencyProperty BrushProperty;
		public Brush Brush {
		    get { return (Brush)GetValue (BrushProperty); }
		    set { SetValue (BrushProperty, value); }
		}

		public static readonly DependencyProperty MiterLimitProperty;
		public double MiterLimit {
		    get { return (double)GetValue (MiterLimitProperty); }
		    set { SetValue (MiterLimitProperty, value); }
		}

		public static readonly DependencyProperty DashStyleProperty;
#if notyet
		public DashStyle DashStyle {
		    get { return (DashStyle)GetValue (DashStyleProperty); }
		    set { SetValue (DashStyleProperty, value); }
		}
#endif

		public static readonly DependencyProperty DashCapProperty;
		public PenLineCap DashCap {
		    get { return (PenLineCap)GetValue (DashCapProperty); }
		    set { SetValue (DashCapProperty, value); }
		}

		public static readonly DependencyProperty ThicknessProperty;
		public double Thickness {
		    get { return (double)GetValue (ThicknessProperty); }
		    set { SetValue (ThicknessProperty, value); }
		}

		public static readonly DependencyProperty StartLineCapProperty;
		public PenLineCap StartLineCap {
		    get { return (PenLineCap)GetValue (StartLineCapProperty); }
		    set { SetValue (StartLineCapProperty, value); }
		}
		
	}

}
