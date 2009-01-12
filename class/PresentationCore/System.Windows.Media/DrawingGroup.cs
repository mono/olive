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
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace System.Windows.Media {

	[ContentProperty ("Children")]
	public class DrawingGroup : Drawing
	{
		public DrawingGroup ()
		{
		}

		public new DrawingGroup Clone ()
		{
			throw new NotImplementedException ();
		}

		public new DrawingGroup CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			return new DrawingGroup ();
		}

		public static readonly DependencyProperty ChildrenProperty;
		public DrawingCollection Children {
		    get { return (DrawingCollection)GetValue (ChildrenProperty); }
		    set { SetValue (ChildrenProperty, value); }
		}

		public static readonly DependencyProperty BitmapEffectProperty;
		public BitmapEffect BitmapEffect {
		    get { return (BitmapEffect)GetValue (BitmapEffectProperty); }
		    set { SetValue (BitmapEffectProperty, value); }
		}

		public static readonly DependencyProperty ClipGeometryProperty;
		public Geometry ClipGeometry {
		    get { return (Geometry)GetValue (ClipGeometryProperty); }
		    set { SetValue (ClipGeometryProperty, value); }
		}

		public static readonly DependencyProperty BitmapEffectInputProperty;
#if notyet
		public BitmapEffectInput BitmapEffectInput {
		    get { return (BitmapEffectInput)GetValue (BitmapEffectInputProperty); }
		    set { SetValue (BitmapEffectInputProperty, value); }
		}
#endif

		public static readonly DependencyProperty GuidelineSetProperty;
#if notyet
		public GuidelineSet GuidelineSet {
		    get { return (GuidelineSet)GetValue (GuidelineSetProperty); }
		    set { SetValue (GuidelineSetProperty, value); }
		}
#endif

		public static readonly DependencyProperty TransformProperty;
		public Transform Transform {
		    get { return (Transform)GetValue (TransformProperty); }
		    set { SetValue (TransformProperty, value); }
		}

		public static readonly DependencyProperty OpacityProperty;
		public double Opacity {
		    get { return (double)GetValue (OpacityProperty); }
		    set { SetValue (OpacityProperty, value); }
		}

		public static readonly DependencyProperty OpacityMaskProperty;
		public Brush OpacityMask {
		    get { return (Brush)GetValue (OpacityMaskProperty); }
		    set { SetValue (OpacityMaskProperty, value); }
		}

		public DrawingContext Append ()
		{
			throw new NotImplementedException ();
		}

		public DrawingContext Open ()
		{
			throw new NotImplementedException ();
		}
	}

}

