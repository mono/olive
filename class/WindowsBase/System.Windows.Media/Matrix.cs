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
using System.Windows.Threading;

namespace System.Windows.Media {

	[SerializableAttribute] 
	//[TypeConverterAttribute(typeof(MatrixConverter))] 
	public struct Matrix : IFormattable {
		public Matrix (double m11,
			       double m12,
			       double m21,
			       double m22,
			       double offsetX,
			       double offsetY)
		{
			throw new NotImplementedException ();
		}

		public void Append (Matrix matrix)
		{
			throw new NotImplementedException ();
		}

		public bool Equals (Matrix value)
		{
			throw new NotImplementedException ();
		}

		public override bool Equals (object o)
		{
			throw new NotImplementedException ();
		}

		public static bool Equals (Matrix matrix1,
					   Matrix matrix2)
		{
			throw new NotImplementedException ();
		}

		public override int GetHashCode ()
		{
			throw new NotImplementedException ();
		}

		public void Invert ()
		{
			throw new NotImplementedException ();
		}

		public static Matrix Multiply (Matrix trans1,
					       Matrix trans2)
		{
			throw new NotImplementedException ();
		}


		public static bool operator == (Matrix matrix1,
						Matrix matrix2)
		{
			throw new NotImplementedException ();
		}

		public static bool operator != (Matrix matrix1,
						Matrix matrix2)
		{
			throw new NotImplementedException ();
		}

		public static Matrix operator * (Matrix trans1,
						 Matrix trans2)
		{
			throw new NotImplementedException ();
		}

		public static Matrix Parse (string source)
		{
			throw new NotImplementedException ();
		}

		public void Prepend (Matrix matrix)
		{
			throw new NotImplementedException ();
		}

		public void Rotate (double angle)
		{
			throw new NotImplementedException ();
		}

		public void RotateAt (double angle,
				      double centerX,
				      double centerY)
		{
			throw new NotImplementedException ();
		}

		public void RotateAtPrepend (double angle,
					     double centerX,
					     double centerY)
		{
			throw new NotImplementedException ();
		}

		public void RotatePrepend (double angle)
		{
			throw new NotImplementedException ();
		}

		public void Scale (double scaleX,
				   double scaleY)
		{
			throw new NotImplementedException ();
		}

		public void ScaleAt (double scaleX,
				     double scaleY,
				     double centerX,
				     double centerY)
		{
			throw new NotImplementedException ();
		}

		public void ScaleAtPrepend (double scaleX,
					    double scaleY,
					    double centerX,
					    double centerY)
		{
			throw new NotImplementedException ();
		}

		public void ScalePrepend (double scaleX,
					  double scaleY)
		{
			throw new NotImplementedException ();
		}

		public void SetIdentity ()
		{
			throw new NotImplementedException ();
		}

		public void Skew (double skewX,
				  double skewY)
		{
			throw new NotImplementedException ();
		}

		public void SkewPrepend (double skewX,
					 double skewY)
		{
			throw new NotImplementedException ();
		}

		string IFormattable.ToString (string format,
					      IFormatProvider provider)
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

		public Point Transform (Point point)
		{
			throw new NotImplementedException ();
		}

		public void Transform (Point[] points)
		{
			throw new NotImplementedException ();
		}

		public Vector Transform (Vector vector)
		{
			throw new NotImplementedException ();
		}

		public void Transform (Vector[] vectors)
		{
			throw new NotImplementedException ();
		}

		public void Translate (double offsetX,
				       double offsetY)
		{
			throw new NotImplementedException ();
		}

		public void TranslatePrepend (double offsetX,
					      double offsetY)
		{
			throw new NotImplementedException ();
		}

		public double Determinant {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool HasInverse {
			get {
				throw new NotImplementedException ();
			}
		}

		public static Matrix Identity {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool IsIdentity {
			get {
				throw new NotImplementedException ();
			}
		}

		public double M11 { 
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public double M12 { 
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public double M21 { 
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public double M22 { 
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public double OffsetX { 
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public double OffsetY { 
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
	}

}
