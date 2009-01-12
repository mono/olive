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

	public class RadialGradientBrush : GradientBrush {
		public RadialGradientBrush (GradientStopCollection stops)
			: base (stops)
		{
		}

		public RadialGradientBrush (Color color1, Color color2)
		{
		}

		public RadialGradientBrush ()
		{
		}

		public new RadialGradientBrush Clone ()
		{
			throw new NotImplementedException ();
		}

		public new RadialGradientBrush CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			return new RadialGradientBrush ();
		}

		public static readonly DependencyProperty CenterProperty;
		public Point Center {
		    get { return (Point)GetValue (CenterProperty); }
		    set { SetValue (CenterProperty, value); }
		}

		public static readonly DependencyProperty RadiusXProperty;
		public double RadiusX {
		    get { return (double)GetValue (RadiusXProperty); }
		    set { SetValue (RadiusXProperty, value); }
		}

		public static readonly DependencyProperty RadiusYProperty;
		public double RadiusY {
		    get { return (double)GetValue (RadiusYProperty); }
		    set { SetValue (RadiusYProperty, value); }
		}

		public static readonly DependencyProperty GradientOriginProperty;
		public Point GradientOrigin {
		    get { return (Point)GetValue (GradientOriginProperty); }
		    set { SetValue (GradientOriginProperty, value); }
		}
	}

}
