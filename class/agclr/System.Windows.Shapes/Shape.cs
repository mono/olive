//
// System.Windows.Shapes.Shape
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

using System.Windows.Media;

namespace System.Windows.Shapes {

	public abstract class Shape : FrameworkElement {

		public static readonly DependencyProperty FillProperty = DependencyProperty.Register ("Fill", typeof (Brush), typeof (Shape));
		public static readonly DependencyProperty StretchProperty = DependencyProperty.Register ("Stretch", typeof (Stretch), typeof (Shape));
		public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register ("Stroke", typeof (Brush), typeof (Shape));
		public static readonly DependencyProperty StrokeDashArrayProperty = DependencyProperty.Register ("StrokeDashArray", typeof (double[]), typeof (Shape));
		public static readonly DependencyProperty StrokeDashCapProperty = DependencyProperty.Register ("StrokeDashCap", typeof (PenLineCap), typeof (Shape));
		public static readonly DependencyProperty StrokeDashOffsetProperty = DependencyProperty.Register ("StrokeDashOffset", typeof (double), typeof (Shape));
		public static readonly DependencyProperty StrokeEndLineCapProperty = DependencyProperty.Register ("StrokeEndLineDashCap", typeof (PenLineCap), typeof (Shape));
		public static readonly DependencyProperty StrokeLineJoinProperty = DependencyProperty.Register ("StrokeLineJoin", typeof (PenLineJoin), typeof (Shape));
		public static readonly DependencyProperty StrokeMiterLimitProperty = DependencyProperty.Register ("StrokeMiterLimit", typeof (double), typeof (Shape));
		public static readonly DependencyProperty StrokeStartLineCapProperty = DependencyProperty.Register ("StrokeStartLineDashCap", typeof (PenLineCap), typeof (Shape));
		public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register ("StrokeThickness", typeof (double), typeof (Shape));
		
		public Shape ()
		{
		}

		public Brush Fill {
			get { return (Brush) GetValue (FillProperty); }
			set { SetValue (FillProperty, value); }
		}

		public Stretch Stretch {
			get { return (Stretch) GetValue (StretchProperty); }
			set { SetValue (StretchProperty, value); }
		}

		public Brush Stroke {
			get { return (Brush) GetValue (StrokeProperty); }
			set { SetValue (StrokeProperty, value); }
		}

		public double[] StrokeDashArray {
			get { return (double[]) GetValue (StrokeDashArrayProperty); }
			set { SetValue (StrokeDashArrayProperty, value); }
		}

		public PenLineCap StrokeDashCap {
			get { return (PenLineCap) GetValue (StrokeDashCapProperty); }
			set { SetValue (StrokeDashCapProperty, value); }
		}

		public double StrokeDashOffset {
			get { return (double) GetValue (StrokeDashOffsetProperty); }
			set { SetValue (StrokeDashOffsetProperty, value); }
		}

		public PenLineCap StrokeEndLineCap {
			get { return (PenLineCap) GetValue (StrokeEndLineCapProperty); }
			set { SetValue (StrokeEndLineCapProperty, value); }
		}

		public PenLineJoin StrokeLineJoin {
			get { return (PenLineJoin) GetValue (StrokeLineJoinProperty); }
			set { SetValue (StrokeLineJoinProperty, value); }
		}

		public double StrokeMiterLimit {
			get { return (double) GetValue (StrokeMiterLimitProperty); }
			set { SetValue (StrokeMiterLimitProperty, value); }
		}

		public PenLineCap StrokeStartLineCap {
			get { return (PenLineCap) GetValue (StrokeStartLineCapProperty); }
			set { SetValue (StrokeStartLineCapProperty, value); }
		}

		public double StrokeThickness {
			get { return (double) GetValue (StrokeThicknessProperty); }
			set { SetValue (StrokeThicknessProperty, value); }
		}
	}
}
