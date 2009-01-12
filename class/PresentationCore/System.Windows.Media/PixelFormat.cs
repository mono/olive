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
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;

namespace System.Windows.Media {

	//	[TypeConverter (typeof (PixelFormatConverter))]
	public struct PixelFormat : IEquatable<PixelFormat>
	{

		public IList<PixelFormatChannelMask> Masks {
			[SecurityCritical]
			get { throw new NotImplementedException (); }
		}

		public int BitsPerPixel {
			[SecurityCritical]
			get { throw new NotImplementedException (); }
		}

		public override string ToString ()
		{
			throw new NotImplementedException ();
		}

		public override int GetHashCode ()
		{
			throw new NotImplementedException ();
		}

		public static bool Equals (PixelFormat pixelFormat1, PixelFormat pixelFormat2)
		{
			throw new NotImplementedException ();
		}

		public bool Equals (PixelFormat pixelFormat)
		{
			throw new NotImplementedException ();
		}

		public override bool Equals (object value)
		{
			return Equals ((PixelFormat)value);
		}

		public static bool operator == (PixelFormat format1, PixelFormat format2)
		{
			throw new NotImplementedException ();
		}

		public static bool operator != (PixelFormat format1, PixelFormat format2)
		{
			throw new NotImplementedException ();
		}
	}
}
