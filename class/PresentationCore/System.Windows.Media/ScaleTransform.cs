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

	public sealed class ScaleTransform : Transform
	{
		public static readonly DependencyProperty CenterXProperty;
		public static readonly DependencyProperty CenterYProperty;
		public static readonly DependencyProperty ScaleXProperty;
		public static readonly DependencyProperty ScaleYProperty;

		public ScaleTransform ()
		{
		}

		public ScaleTransform (double scaleX, double scaleY)
		{
			ScaleX = scaleX;
			ScaleY = scaleY;
		}

		public ScaleTransform (double scaleX, double scaleY, double centerX, double centerY)
		{
			ScaleX = scaleX;
			ScaleY = scaleY;
			CenterX = centerX;
			CenterY = centerY;
		}


		public override Matrix Value {
			get {
				Matrix m = Matrix.Identity;
				m.ScaleAt (ScaleX, ScaleY, CenterX, CenterY);
				return m;
			}
		}

		public double CenterX {
			get { return (double)GetValue (ScaleTransform.CenterXProperty); }
			set { SetValue (ScaleTransform.CenterXProperty, value); }
		}

		public double CenterY {
			get { return (double)GetValue (ScaleTransform.CenterYProperty); }
			set { SetValue (ScaleTransform.CenterYProperty, value); }
		}

		public double ScaleX {
			get { return (double)GetValue (ScaleTransform.CenterXProperty); }
			set { SetValue (ScaleTransform.CenterXProperty, value); }
		}

		public double ScaleY {
			get { return (double)GetValue (ScaleTransform.CenterYProperty); }
			set { SetValue (ScaleTransform.CenterYProperty, value); }
		}

		public new ScaleTransform Clone ()
		{
			return new ScaleTransform (ScaleX, ScaleY, CenterX, CenterY);
		}

		public new ScaleTransform CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			return new ScaleTransform ();
		}
	}
}
