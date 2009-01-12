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

using System.Collections.Generic;
using System.Security;
using System.Windows;
using System.Windows.Media.Animation;

namespace System.Windows.Media {

	public class PathGeometry : Geometry {

		public PathGeometry ()
		{
		}

		public PathGeometry (IEnumerable<PathFigure> figures)
		{
			Figures = new PathFigureCollection (figures);
		}

		public PathGeometry (IEnumerable<PathFigure> figures, FillRule fillRule, Transform transform)
		{
			Figures = new PathFigureCollection (figures);
			FillRule = fillRule;
			Transform = transform;
		}

		public new PathGeometry Clone ()
		{
			throw new NotImplementedException ();
		}

		public new PathGeometry CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			return new PathGeometry ();
		}

		public override bool IsEmpty ()
		{
			throw new NotImplementedException ();
		}

		public override bool MayHaveCurves ()
		{
			throw new NotImplementedException ();
		}

		public void AddGeometry (Geometry geometry)
		{
			throw new NotImplementedException ();
		}

		public void Clear ()
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public void GetPointAtFractionLength (double d, out Point p1, out Point p2)
		{
			throw new NotImplementedException ();
		}

		protected override void OnChanged ()
		{
			throw new NotImplementedException ();
		}

		public static PathGeometry CreateFromGeometry (Geometry geometry)
		{
			throw new NotImplementedException ();
		}

		public static readonly DependencyProperty FillRuleProperty;
		public FillRule FillRule {
		    get { return (FillRule)GetValue (FillRuleProperty); }
		    set { SetValue (FillRuleProperty, value); }
		}

		public static readonly DependencyProperty FiguresProperty;
		public PathFigureCollection Figures {
		    get { return (PathFigureCollection)GetValue (FiguresProperty); }
		    set { SetValue (FiguresProperty, value); }
		}

		public override Rect Bounds {
			get { throw new NotImplementedException (); }
		}
	}

}
