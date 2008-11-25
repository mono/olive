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

	public class LinearGradientBrush : GradientBrush
	{
		public LinearGradientBrush ()
		{
		}

		public LinearGradientBrush (Color color1, Color color2, Point startPoint, Point endPoint)
		{
			StartPoint = startPoint;
			EndPoint = endPoint;

			GradientStops.Add (new GradientStop (color1, 0.0));
			GradientStops.Add (new GradientStop (color2, 1.0));
		}

		public LinearGradientBrush (GradientStopCollection stops, Point startPoint, Point endPoint)
			: base (stops)
		{
			StartPoint = startPoint;
			EndPoint = endPoint;
		}

		public LinearGradientBrush (Color color1, Color color2, double d)
		{
		}

		public LinearGradientBrush (GradientStopCollection stops, double d)
			: base (stops)
		{
		}

		public LinearGradientBrush (GradientStopCollection stops)
			: base (stops)
		{
		}

		public LinearGradientBrush Clone ()
		{
			throw new NotImplementedException ();
		}

		public LinearGradientBrush CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			throw new NotImplementedException ();
		}

		public static readonly DependencyProperty StartPointProperty;
		public Point StartPoint {
		    get { return (Point)GetValue (StartPointProperty); }
		    set { SetValue (StartPointProperty, value); }
		}

		public static readonly DependencyProperty EndPointProperty;
		public Point EndPoint {
		    get { return (Point)GetValue (EndPointProperty); }
		    set { SetValue (EndPointProperty, value); }
		}
	}

}
