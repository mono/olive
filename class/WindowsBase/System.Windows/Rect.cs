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
//	Chris Toshok <toshok@novell.com>
//	Sebastien Pouliot  <sebastien@ximian.com>
//

using System;

using System.Windows.Media;

namespace System.Windows {

	[Serializable]
#if notyet
	[ValueSerializer (typeof (RectValueSerializer))]
	[TypeConverter (typeof (RectConverter))]
#endif
	public struct Rect : IFormattable
	{
		public Rect (Size size)
		{
			x = y = 0.0;
			width = size.Width;
			height = size.Width;
		}

		public Rect (Point point, Vector vector) : this (point, Point.Add (point, vector))
		{ }

		public Rect (Point point1, Point point2)
		{
			if (point1.X < point2.X) {
				x = point1.X;
				width = point2.X - point1.X;
			}
			else {
				x = point2.X;
				width = point1.X - point2.X;
			}

			if (point1.Y < point2.Y) {
				y = point1.Y;
				height = point2.Y - point1.Y;
			}
			else {
				y = point2.Y;
				height = point1.Y - point2.Y;
			}
		}

		public Rect (double x, double y, double width, double height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public Rect (Point location, Size size)
		{
			x = location.X;
			y = location.Y;
			width = size.Width;
			height = size.Height;
		}

		public bool Equals (Rect rect)
		{
			return (x == rect.X &&
				y == rect.Y &&
				width == rect.Width &&
				height == rect.Height);
		}

		public override bool Equals (object o)
		{
			if (!(o is Rect))
				return false;

			return Equals ((Rect)o);
		}

		public static bool Equals (Rect rect1, Rect rect2)
		{
			return rect1.Equals (rect2);
		}

		public override int GetHashCode ()
		{
			throw new NotImplementedException ();
		}

		public bool Contains (Rect rect)
		{
			if (rect.Left > this.Right ||
			    rect.Right < this.Left)
				return false;

			if (rect.Top > this.Bottom ||
			    rect.Bottom < this.Top)
				return false;

			return true;
		}

		public bool Contains (double x, double y)
		{
			if (x < Left || x > Right)
				return false;
			if (y < Top || y > Bottom)
				return false;

			return true;
		}

		public bool Contains (Point p)
		{
			return Contains (p.X, p.Y);
		}

		public static Rect Inflate (Rect rect, double width, double height)
		{
			if (width < rect.Width * -2)
				return Rect.Empty;
			if (height < rect.Height * -2)
				return Rect.Empty;

			Rect result = rect;
			result.Inflate (width, height);
			return result;
		}

		public static Rect Inflate (Rect rect, Size size)
		{
			return Rect.Inflate (rect, size.Width, size.Height);
		}

		public void Inflate (double width, double height)
		{
			// XXX any error checking like in the static case?
			x -= width;
			y -= height;

			this.width += 2*width;
			this.height += 2*height;
		}

		public void Inflate (Size size)
		{
			Inflate (size.Width, size.Height);
		}

		public bool IntersectsWith(Rect rect)
		{
			return !((Left >= rect.Right) || (Right <= rect.Left) ||
			    (Top >= rect.Bottom) || (Bottom <= rect.Top));
		}

		public void Intersect(Rect rect)
		{
			x = Math.Max (x, rect.x);
			y = Math.Max (y, rect.y);
			width = Math.Min (Right, rect.Right) - x;
			height = Math.Min (Bottom, rect.Bottom) - y; 
		}

		public static Rect Intersect(Rect rect1, Rect rect2)
		{
			Rect result = rect1;
			result.Intersect (rect2);
			return result;
		}

		public void Offset(double offsetX, double offsetY)
		{
			x += offsetX;
			y += offsetY;
		}

		public static Rect Offset(Rect rect, double offsetX, double offsetY)
		{
			Rect result = rect;
			result.Offset (offsetX, offsetY);
			return result;
		}

		public void Offset (Vector offsetVector)
		{
			x += offsetVector.X;
			y += offsetVector.Y;
		}

		public static Rect Offset (Rect rect, Vector offsetVector)
		{
			Rect result = rect;
			result.Offset (offsetVector);
			return result;
		}

		public void Scale(double scaleX, double scaleY)
		{
			x *= scaleX;
			y *= scaleY;
			width *= scaleX;
			height *= scaleY;
		}

		public void Transform (Matrix matrix)
		{
			throw new NotImplementedException ();
		}

		public static Rect Transform (Rect rect, Matrix matrix)
		{
			Rect result = rect;
			result.Transform (matrix);
			return result;
		}

		public static Rect Union(Rect rect1, Rect rect2)
		{
			Rect result = rect1;
			result.Union (rect2);
			return result;
		}

		public static Rect Union(Rect rect, Point point)
		{
			Rect result = rect;
			result.Union (point);
			return result;
		}
		
		public void Union(Rect rect)
		{
			x = Math.Min (x, rect.x);
			y = Math.Min (y, rect.y);
			width = Math.Max (Right, rect.Right) - x;
			height = Math.Max (Bottom, rect.Bottom) - y;
		}

		public void Union(Point point)
		{
			Union (new Rect (point, point));
		}

		public static Rect Parse (string source)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			throw new NotImplementedException ();
		}

		public string ToString (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		string IFormattable.ToString (string format, IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public static Rect Empty { 
			get { return new Rect (0, 0, 0, 0); } 
		}
		
		public bool IsEmpty { 
			get {
				return width == 0 || height == 0;
			}
		}
		
		public Point Location { 
			get {
				return new Point (x, y);
			}
			set {
				x = value.X;
				y = value.Y;
			}
		}
		
		public Size Size { 
			get { 
				return new Size (width, height);
			}
			set {
				width = value.Width;
				height = value.Height;
			}
		}

		public double X {
			get { return x; }
			set { x = value; }
		}

		public double Y {
			get { return y; }
			set { y = value; }
		}

		public double Width {
			get { return width; }
			set { width = value; }
		}

		public double Height {
			get { return height; }
			set { height = value; }
		}

		public double Left { 
			get { return x; }
		}
		
		public double Top { 
			get { return y; }
		}
		
		public double Right { 
			get { return x + width; }
		}
		
		public double Bottom { 
			get { return y + height; }
		}
		
		public Point TopLeft { 
			get { return new Point (Top, Left); }
		}
		
		public Point TopRight { 
			get { return new Point (Top, Right); }
		}
		
		public Point BottomLeft { 
			get { return new Point (Bottom, Left); }
		}

		public Point BottomRight { 
			get { return new Point (Bottom, Right); }
		}
		
		double x;
		double y;
		double width;
		double height;
	}
}
