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
//	Chris Toshok (toshok@ximian.com)
//

using System;
using System.ComponentModel;
using System.Windows;

namespace System.Windows.Media.Animation {

#if notyet
	[TypeConverter (typeof (KeyTimeConverter))]
#endif
	public struct KeyTime : IEquatable<KeyTime>
	{
		public static bool operator != (KeyTime keyTime1, KeyTime keyTime2)
		{
			throw new NotImplementedException ();
		}

		public static bool operator == (KeyTime keyTime1, KeyTime keyTime2)
		{
			throw new NotImplementedException ();
		}

		public static implicit operator KeyTime (TimeSpan timeSpan)
		{
			throw new NotImplementedException ();
		}

		public static KeyTime Paced {
			get { throw new NotImplementedException (); }
		}

		public static KeyTime Uniform {
			get { throw new NotImplementedException (); }
		}

		public double Percent {
			get { throw new NotImplementedException (); }
		}

		public TimeSpan TimeSpan {
			get { throw new NotImplementedException (); }
		}

		public KeyTimeType Type {
			get { throw new NotImplementedException (); }
		}

		public bool Equals (KeyTime value)
		{
			throw new NotImplementedException ();
		}

		public override bool Equals (object value)
		{
			if (!(value is KeyTime))
				return false;

			return Equals ((KeyTime)value);
		}

		public static bool Equals (KeyTime keyTime1, KeyTime keyTime2)
		{
			return keyTime1.Equals (keyTime2);
		}

		public static KeyTime FromPercent (double percent)
		{
			throw new NotImplementedException ();
		}

		public static KeyTime FromTimeSpan (TimeSpan timeSpan)
		{
			throw new NotImplementedException ();
		}

		public override int GetHashCode ()
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	}
}
