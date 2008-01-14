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

namespace System.Windows.Media {

	[Localizability (LocalizationCategory.None, Readability = Readability.Unreadable)]
	//[TypeConverter (typeof (ColorConverter))]
	public struct Color : IFormattable, IEquatable<Color>
	{
		public static Color operator - (Color color1, Color color2)
		{
			throw new NotImplementedException ();
		}

		public static Color operator * (Color color1, float coefficient)
		{
			throw new NotImplementedException ();
		}

		public static Color operator + (Color color1, Color color2)
		{
			throw new NotImplementedException ();
		}

		public static bool operator == (Color color1, Color color2)
		{
			throw new NotImplementedException ();
		}

		public static bool operator != (Color color1, Color color2)
		{
			throw new NotImplementedException ();
		}

		public byte A {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public byte B {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public byte G {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public byte R {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public ColorContext ColorContext {
			get { throw new NotImplementedException (); }
		}

		public float ScA {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public float ScB {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public float ScG {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public float ScR {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public static Color Add (Color color1, Color color2)
		{
			return color1 + color2;
		}

		public static Color Subtract (Color color1, Color color2)
		{
			return color1 + color2;
		}

		public static bool AreClose (Color color1, Color color2)
		{
			throw new NotImplementedException ();
		}

		public void Clamp ()
		{
		}

		public bool Equals (Color color)
		{
			throw new NotImplementedException ();
		}

		public override bool Equals (object o)
		{
			throw new NotImplementedException ();
		}

		public static bool Equals (Color color1, Color color2)
		{
			throw new NotImplementedException ();
		}

		public static Color FromArgb (byte a,byte r, byte g, byte b)
		{
			throw new NotImplementedException ();
		}

		public static Color FromAValues (float a, float[] values, Uri profileUri)
		{
			throw new NotImplementedException ();
		}

		public static Color FromRgb (byte r, byte g, byte b)
		{
			throw new NotImplementedException ();
		}

		public static Color FromScRgb (float a, float r, float g, float b)
		{
			throw new NotImplementedException ();
		}

		public static Color FromValues (float[] values, Uri profileUri)
		{
			throw new NotImplementedException ();
		}

		public override int GetHashCode ()
		{
			throw new NotImplementedException ();
		}

		public float[] GetNativeColorValues ()
		{
			throw new NotImplementedException ();
		}

		public static Color Multiply (Color color1, float coefficient)
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
	}
}

