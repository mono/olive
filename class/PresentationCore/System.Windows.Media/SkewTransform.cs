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
using System.ComponentModel;
using System.Windows;

namespace System.Windows.Media {

	public sealed class SkewTransform : Transform
	{
		public static readonly DependencyProperty AngleXProperty;
		public static readonly DependencyProperty AngleYProperty;
		public static readonly DependencyProperty CenterXProperty;
		public static readonly DependencyProperty CenterYProperty;

		public SkewTransform ()
		{
		}

		public SkewTransform (double angleX, double angleY)
		{
			AngleX = angleX;
			AngleY = angleY;
		}

		public SkewTransform (double angleX, double angleY, double centerX, double centerY)
		{
			AngleX = angleX;
			AngleY = angleY;
			CenterX = centerX;
			CenterY = centerY;
		}


		public override Matrix Value {
			get {
				Matrix m = Matrix.Identity;
				m.Translate (CenterX, CenterY);
				m.Skew (AngleX, AngleY);
				m.Translate (-CenterX, -CenterY);
				return m;
			}
		}

		public double CenterX {
			get { return (double)GetValue (SkewTransform.CenterXProperty); }
			set { SetValue (SkewTransform.CenterXProperty, value); }
		}

		public double CenterY {
			get { return (double)GetValue (SkewTransform.CenterYProperty); }
			set { SetValue (SkewTransform.CenterYProperty, value); }
		}

		public double AngleX {
			get { return (double)GetValue (SkewTransform.CenterXProperty); }
			set { SetValue (SkewTransform.CenterXProperty, value); }
		}

		public double AngleY {
			get { return (double)GetValue (SkewTransform.CenterYProperty); }
			set { SetValue (SkewTransform.CenterYProperty, value); }
		}

		public new SkewTransform Clone ()
		{
			return new SkewTransform (AngleX, AngleY, CenterX, CenterY);
		}

		public new SkewTransform CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			throw new NotImplementedException ();
		}
	}
}

