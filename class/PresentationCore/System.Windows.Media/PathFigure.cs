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
using System.Windows;
using System.Windows.Media.Animation;

namespace System.Windows.Media {

	public class PathFigure : Animatable {

		public PathFigure ()
		{
		}

		public PathFigure (Point startPoint, IEnumerable<PathSegment> segments, Boolean isClosed)
		{
			StartPoint = startPoint;
			Segments = new PathSegmentCollection (segments);
			IsClosed = isClosed;
		}

		public new PathFigure Clone ()
		{
			throw new NotImplementedException ();
		}

		public new PathFigure CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			return new PathFigure ();
		}

		public bool MayHaveCurves()
		{
			throw new NotImplementedException ();
		}

		public PathFigure GetFlattenedPathFigure ()
		{
			throw new NotImplementedException ();
		}

		public PathFigure GetFlattenedPathFigure (double flatteningTolerance, ToleranceType tolerance)
		{
			throw new NotImplementedException ();
		}

		public static readonly DependencyProperty IsClosedProperty;
		public bool IsClosed {
		    get { return (bool)GetValue (IsClosedProperty); }
		    set { SetValue (IsClosedProperty, value); }
		}

		public static readonly DependencyProperty IsFilledProperty;
		public bool IsFilled {
		    get { return (bool)GetValue (IsFilledProperty); }
		    set { SetValue (IsFilledProperty, value); }
		}

		public static readonly DependencyProperty SegmentsProperty;
		public PathSegmentCollection Segments {
		    get { return (PathSegmentCollection)GetValue (SegmentsProperty); }
		    set { SetValue (SegmentsProperty, value); }
		}

		public static readonly DependencyProperty StartPointProperty;
		public Point StartPoint {
		    get { return (Point)GetValue (StartPointProperty); }
		    set { SetValue (StartPointProperty, value); }
		}
		
	}

}