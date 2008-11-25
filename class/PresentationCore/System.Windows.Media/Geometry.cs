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

using System.Security;
using System.Windows;
using System.Windows.Media.Animation;

namespace System.Windows.Media {
	public abstract class Geometry : Animatable {
		internal Geometry ()
		{
		}

		public bool FillContains (Geometry geometry)
		{
			throw new NotImplementedException ();
		}

		public bool FillContains (Geometry geometry, double d, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public bool FillContains (Point point)
		{
			throw new NotImplementedException ();
		}

		public bool FillContains (Point point, double d, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public abstract bool IsEmpty ();
		public abstract bool MayHaveCurves ();

		public bool ShouldSerializeTransform ()
		{
			throw new NotImplementedException ();
		}

		public bool StrokeContains (Pen pen, Point point)
		{
			throw new NotImplementedException ();
		}

		public bool StrokeContains (Pen pen, Point point, double d, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public double GetArea ()
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public virtual double GetArea (double d, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public Geometry Clone ()
		{
			throw new NotImplementedException ();
		}

		public Geometry CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		public static Geometry Parse (string str)
		{
			throw new NotImplementedException ();
		}

		public IntersectionDetail FillContainsWithDetail (Geometry geometry)
		{
			throw new NotImplementedException ();
		}

		public virtual IntersectionDetail FillContainsWithDetail (Geometry geometry, double d, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public IntersectionDetail StrokeContainsWithDetail (Pen pen, Geometry geometry)
		{
			throw new NotImplementedException ();
		}

		public IntersectionDetail StrokeContainsWithDetail (Pen pen, Geometry geometry, double d, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public static PathGeometry Combine (Geometry geometry1, Geometry geometry2, GeometryCombineMode combineMode, Transform transform)
		{
			throw new NotImplementedException ();
		}

		public static PathGeometry Combine (Geometry geometry1, Geometry geometry2, GeometryCombineMode combineMode, Transform transform, double flatteningTolerance, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public PathGeometry GetFlattenedPathGeometry ()
		{
			throw new NotImplementedException ();
		}

		public virtual PathGeometry GetFlattenedPathGeometry (double flattingTolerance, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public PathGeometry GetOutlinedPathGeometry ()
		{
			throw new NotImplementedException ();
		}

		public virtual PathGeometry GetOutlinedPathGeometry (double flatteningTolerance, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public PathGeometry GetWidenedPathGeometry (Pen pen)
		{
			throw new NotImplementedException ();
		}

		public virtual PathGeometry GetWidenedPathGeometry (Pen pen, double flatteningTolerance, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public Rect GetRenderBounds (Pen pen)
		{
			throw new NotImplementedException ();
		}

		public virtual Rect GetRenderBounds (Pen pen, double flatteningTolerance, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public double StandardFlatteningTolerance {
			get { throw new NotImplementedException (); }
		}

		public Geometry Empty {
			get { throw new NotImplementedException (); }
		}

		public Rect Bounds {
			get { throw new NotImplementedException (); }
		}

		public static readonly DependencyProperty TransformProperty;
		
		public Transform Transform {
		    get { return (Transform)GetValue (TransformProperty); }
		    set { SetValue (TransformProperty, value); }
		}
	}
}
