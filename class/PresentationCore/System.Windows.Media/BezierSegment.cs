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

namespace System.Windows.Media {

	public class BezierSegment : PathSegment {
		public BezierSegment (Point point1, Point point2, Point point3, bool isStroked)
		{
			Point1 = point1;
			Point2 = point2;
			Point3 = point3;
		}

		public BezierSegment ()
		{
		}

		public BezierSegment Clone ()
		{
			throw new NotImplementedException ();
		}

		public BezierSegment CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			throw new NotImplementedException ();
		}

		public static readonly DependencyProperty Point1Property;
		public Point Point1 {
		    get { return (Point)GetValue (Point1Property); }
		    set { SetValue (Point1Property, value); }
		}

		public static readonly DependencyProperty Point2Property;
		public Point Point2 {
		    get { return (Point)GetValue (Point2Property); }
		    set { SetValue (Point2Property, value); }
		}

		public static readonly DependencyProperty Point3Property;
		public Point Point3 {
		    get { return (Point)GetValue (Point3Property); }
		    set { SetValue (Point3Property, value); }
		}
		
	}

}
