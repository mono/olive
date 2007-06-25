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
//	Chris Toshok (toshok@novell.com)
//

using System;

namespace System.Windows {

	// [TypeConverter (typeof (SizeConverter))]
	// [ValueSerializer (...)]
	[Serializable]
	public struct Size : IFormattable
	{
		public Size (double width, double height)
		{
			this.width = width;
			this.height = height;
		}

		public bool Equals (Size value)
		{
			return width == value.Width && height == value.Height;
		}
		
		public override bool Equals (object o)
		{
			if (!(o is Size))
				return false;

			return Equals ((Size)o);
		}

		public static bool Equals (Size size1, Size size2)
		{
			return size1.Equals (size2);
		}

		public override int GetHashCode ()
		{
			throw new NotImplementedException ();
		}

		string IFormattable.ToString(string format, IFormatProvider formatProvider) {
			throw new NotImplementedException ();
		}

		public bool IsEmpty {
			get { return width == 0.0 && height == 0.0; }
		}

		public double Height {
			get { return height; }
			set { height = value; }
		}

		public double Width {
			get { return width; }
			set { width = value; }
		}

		public static Size Empty {
			get { return new Size (0, 0); }
		}

		/* operators */
		public static explicit operator Point (Size size)
		{
			return new Point (size.Width, size.Height);
		}

		public static explicit operator Vector (Size size)
		{
			return new Vector (size.Width, size.Height);
		}

		public static bool operator ==(Size size1, Size size2)
		{
			return size1.Equals (size2);
		}

		public static bool operator !=(Size size1, Size size2)
		{
			return !size1.Equals (size2);
		}

		double width;
		double height;
	}
}
