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

namespace System.Windows.Media {

	public sealed class RotateTransform : Transform {

		public static readonly DependencyProperty AngleProperty;
		public static readonly DependencyProperty CenterXProperty;
		public static readonly DependencyProperty CenterYProperty;

		static RotateTransform ()
		{
			throw new NotImplementedException ();
		}

		public RotateTransform ()
		{
			throw new NotImplementedException ();
		}

		public RotateTransform (double angle)
		{
			throw new NotImplementedException ();
		}

		public RotateTransform (double angle,
					double centerX,
					double centerY)
		{
			throw new NotImplementedException ();
		}

		public new RotateTransform Clone ()
		{
			throw new NotImplementedException ();
		}

		public new RotateTransform CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		public double Angle { 
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public double CenterX { 
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public double CenterY { 
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public override Matrix Value {
			get {
				throw new NotImplementedException ();
			}
		}
	}
}
