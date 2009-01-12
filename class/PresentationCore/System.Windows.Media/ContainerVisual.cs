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

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace System.Windows.Media {

	public class ContainerVisual : Visual {

		public ContainerVisual ()
		{
		}

		protected override Visual GetVisualChild (int childIndex)
		{
			throw new NotImplementedException ();
		}

		public Geometry Clip { get; set; }

		[Obsolete]
		public BitmapEffect BitmapEffect { get; set; }

#if notyet
		[Obsolete]
		public BitmapEffectInput BitmapEffectInput { get; set; }
#endif

		public DependencyObject Parent { get; private set; }

		public double Opacity { get; set; }

		public Brush OpacityMask { get; set; }

		protected override int VisualChildrenCount {
			get { throw new NotImplementedException (); }
		}

		public Rect DescendentBounds { get; private set; }

		public Transform Transform { get; set; }

		[DefaultValue (null)]
		public DoubleCollection YSnappingGuidelines { get; set; }

		[DefaultValue (null)]
		public DoubleCollection XSnappingGuidelines { get; set; }

		public Rect ContentBounds { get; private set; }

		public VisualCollection Children { get; private set; }

		public Vector Offset { get; set; }

		public void HitTest (HitTestFilterCallback filter, HitTestResultCallback result, HitTestParameters parameters)
		{
			throw new NotImplementedException ();
		}

		public HitTestResult HitTest (Point point)
		{
			throw new NotImplementedException ();
		}
	}

}
