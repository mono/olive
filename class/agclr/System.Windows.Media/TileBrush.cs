//
// System.Windows.Media.TileBrush class
//
// Authors:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
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

namespace System.Windows.Media {

	public class TileBrush : Brush {

		public static readonly DependencyProperty AlignmentXProperty = DependencyProperty.Lookup (Kind.DOUBLE, "AlignmentX", typeof (TileBrush));
		public static readonly DependencyProperty AlignmentYProperty = DependencyProperty.Lookup (Kind.DOUBLE, "AlignmentY", typeof (TileBrush));
		public static readonly DependencyProperty StretchProperty = DependencyProperty.Lookup (Kind.INT32, "Stretch", typeof (TileBrush));


		public TileBrush ()
		{
		}


		public double AlignmentX {
			get { return (double) GetValue (AlignmentXProperty); }
			set { SetValue (AlignmentXProperty, value); }
		}

		public double AlignmentY {
			get { return (double) GetValue (AlignmentYProperty); }
			set { SetValue (AlignmentYProperty, value); }
		}

		public Stretch Stretch {
			get { return (Stretch) GetValue (StretchProperty); }
			set { SetValue (StretchProperty, value); }
		}
	}
}
