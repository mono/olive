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

	public sealed class TranslateTransform : Transform
	{
		public static readonly DependencyProperty XProperty;
		public static readonly DependencyProperty YProperty;

		public TranslateTransform ()
		{
		}

		public TranslateTransform (double offsetX, double offsetY)
		{
			X = offsetX;
			Y = offsetY;
		}

		public override Matrix Value {
			get {
				Matrix m = Matrix.Identity;
				m.Translate (X, Y);
				return m;
			}
		}

		public double X {
			get { return (double)GetValue (TranslateTransform.XProperty); }
			set { SetValue (TranslateTransform.XProperty, value); }
		}

		public double Y {
			get { return (double)GetValue (TranslateTransform.YProperty); }
			set { SetValue (TranslateTransform.YProperty, value); }
		}

		public new TranslateTransform Clone ()
		{
			return new TranslateTransform (X, Y);
		}

		public new TranslateTransform CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			return new TranslateTransform ();
		}
	}

}

