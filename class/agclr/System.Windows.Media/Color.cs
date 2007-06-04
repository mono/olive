//
// System.Windows.Media.Color enum
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

namespace System.Windows.Media {

		[MonoTODO]
	public struct Color : IFormattable, IEquatable<Color> {

		private uint argb;

		private Color (uint value)
		{
			argb = value;
		}

		public static Color FromArgb (byte a, byte r, byte g, byte b)
		{
			return new Color ((uint)(a << 24 | r << 16 | g << 8 | b));
		}

		public static Color FromRgb (byte r, byte g, byte b)
		{
			return new Color (0xFF000000 | (uint) (r << 16 | g << 8 | b));
		}

		[MonoTODO]
		public string ToString (string format, IFormatProvider formatProvider)
		{
 			throw new NotImplementedException ();
		}

		[MonoTODO]
		public bool Equals (Color other)
		{
 			throw new NotImplementedException ();
		}
	}
}
