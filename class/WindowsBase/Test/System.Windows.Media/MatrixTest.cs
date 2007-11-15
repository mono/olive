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
using System.Windows;
using System.Windows.Media;
using NUnit.Framework;

namespace MonoTests.System.Windows.Media {

	[TestFixture]
	public class MatrixTest {

		void CheckMatrix (Matrix expected, Matrix actual)
		{
			Assert.AreEqual (expected.M11, actual.M11);
			Assert.AreEqual (expected.M12, actual.M12);
			Assert.AreEqual (expected.M21, actual.M21);
			Assert.AreEqual (expected.M22, actual.M22);
			Assert.AreEqual (expected.OffsetX, actual.OffsetX);
			Assert.AreEqual (expected.OffsetY, actual.OffsetY);
		}

		[Test]
		public void TestAccessors ()
		{
			Matrix m = new Matrix (1, 2, 3, 4, 5, 6);
			Assert.AreEqual (1, m.M11);
			Assert.AreEqual (2, m.M12);
			Assert.AreEqual (3, m.M21);
			Assert.AreEqual (4, m.M22);
			Assert.AreEqual (5, m.OffsetX);
			Assert.AreEqual (6, m.OffsetY);
		}

		[Test]
		public void Append ()
		{
			Matrix m = new Matrix (1, 2, 3, 4, 5, 6);
			m.Append (m);
			CheckMatrix (new Matrix (7, 10, 15, 22, 28, 40), m);
		}

		[Test]
		public void Equals ()
		{
			Matrix m = new Matrix (1, 2, 3, 4, 5, 6);
			Assert.IsTrue  (m.Equals (new Matrix (1, 2, 3, 4, 5, 6)));
			Assert.IsFalse (m.Equals (new Matrix (0, 2, 3, 4, 5, 6)));
			Assert.IsFalse (m.Equals (new Matrix (1, 0, 3, 4, 5, 6)));
			Assert.IsFalse (m.Equals (new Matrix (1, 2, 0, 4, 5, 6)));
			Assert.IsFalse (m.Equals (new Matrix (1, 2, 3, 0, 5, 6)));
			Assert.IsFalse (m.Equals (new Matrix (1, 2, 3, 4, 0, 6)));
			Assert.IsFalse (m.Equals (new Matrix (1, 2, 3, 4, 5, 0)));

			Assert.IsFalse (m.Equals (0));
			Assert.IsTrue (m.Equals ((object)m));
		}

		[Test]
		public void Determinant ()
		{
			Assert.AreEqual (0, (new Matrix (2, 2, 2, 2, 0, 0)).Determinant);
			Assert.AreEqual (-6, (new Matrix (1, 4, 2, 2, 0, 0)).Determinant);
			Assert.AreEqual (1, (new Matrix (1, 0, 0, 1, 0, 0)).Determinant);
			Assert.AreEqual (1, (new Matrix (1, 0, 0, 1, 5, 5)).Determinant);
			Assert.AreEqual (-1, (new Matrix (0, 1, 1, 0, 5, 5)).Determinant);
		}

		[Test]
		public void HasInverse ()
		{
			/* same matrices as in Determinant() */
			Assert.IsFalse ((new Matrix (2, 2, 2, 2, 0, 0)).HasInverse);
			Assert.IsTrue ((new Matrix (1, 4, 2, 2, 0, 0)).HasInverse);
			Assert.IsTrue  ((new Matrix (1, 0, 0, 1, 0, 0)).HasInverse);
			Assert.IsTrue  ((new Matrix (1, 0, 0, 1, 5, 5)).HasInverse);
			Assert.IsTrue  ((new Matrix (0, 1, 1, 0, 5, 5)).HasInverse);
		}

		[Test]
		public void IsIdentity ()
		{
			Assert.IsTrue (Matrix.Identity.IsIdentity);;
			Assert.IsFalse ((new Matrix (1, 0, 0, 1, 5, 5)).IsIdentity);
			Assert.IsFalse ((new Matrix (5, 5, 5, 5, 5, 5)).IsIdentity);
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))] // "Transform is not invertible."
		public void InvertException1 ()
		{
			Matrix m = new Matrix (2, 2, 2, 2, 0, 0);
			m.Invert ();
		}

		[Test]
		public void Invert ()
		{
			Matrix m;

			m = new Matrix (1, 0, 0, 1, 0, 0);
			m.Invert ();
			CheckMatrix (new Matrix (1, 0, 0, 1, 0, 0), m);

			m = new Matrix (1, 0, 0, 1, 5, 5);
			m.Invert ();
			CheckMatrix (new Matrix (1, 0, 0, 1, -5, -5), m);

			m = new Matrix (1, 0, 0, 2, 5, 5);
			m.Invert ();
			CheckMatrix (new Matrix (1, 0, 0, 0.5, -5, -2.5), m);

			m = new Matrix (0, 2, 4, 0, 5, 5);
			m.Invert ();
			CheckMatrix (new Matrix (0, 0.25, 0.5, 0, -2.5, -1.25), m);
		}

		[Test]
		public void Identity ()
		{
			CheckMatrix (new Matrix (1, 0, 0, 1, 0, 0), Matrix.Identity);
		}

		[Test]
		public void Multiply ()
		{
			CheckMatrix (new Matrix (5, 0, 0, 5, 10, 10),
				     Matrix.Multiply (new Matrix (1, 0, 0, 1, 2, 2),
						      new Matrix (5, 0, 0, 5, 0, 0)));

			CheckMatrix (new Matrix (0, 0, 0, 0, 10, 10),
				     Matrix.Multiply (new Matrix (1, 0, 0, 1, 0, 0),
						      new Matrix (0, 0, 0, 0, 10, 10)));

			// XXX more here
		}

		[Test]
		public void Parse ()
		{
			CheckMatrix (Matrix.Identity, Matrix.Parse ("Identity"));
			CheckMatrix (new Matrix (1, 0, 0, 1, 0, 0), Matrix.Parse ("1, 0, 0, 1, 0, 0"));
			CheckMatrix (new Matrix (0.1, 0.2, 0.3, 0.4, 0.5, 0.6), Matrix.Parse ("0.1,0.2,0.3,0.4,0.5,0.6"));
			// XXX what about locales where . and , are switched?
		}

		[Test]
		public void Prepend ()
		{
		}

		[Test]
		public void Rotate ()
		{
		}

		[Test]
		public void RotateAt ()
		{
		}

		[Test]
		public void RotateAtPrepend ()
		{
		}

		[Test]
		public void RotatePrepend ()
		{
		}

		[Test]
		public void Scale ()
		{
			Matrix m = Matrix.Identity;

			m.Scale (5, 6);
			CheckMatrix (new Matrix (5, 0, 0, 6, 0, 0), m);

			m = new Matrix (1, 2, 2, 1, 3, 3);
			m.Scale (5, 5);
			CheckMatrix (new Matrix (5, 10, 10, 5, 15, 15), m);
		}

		[Test]
		public void ScaleAt ()
		{
			Matrix m = new Matrix (1, 0, 0, 1, 2, 2);
			m.ScaleAt (2, 2, 0, 0);
			CheckMatrix (new Matrix (2, 0, 0, 2, 4, 4), m);

			m = new Matrix (1, 0, 0, 1, 2, 2);
			m.ScaleAt (2, 2, 4, 4);
			CheckMatrix (new Matrix (2, 0, 0, 2, 0, 0), m);

			m = new Matrix (1, 0, 0, 1, 2, 2);
			m.ScaleAt (2, 2, 2, 2);
			CheckMatrix (new Matrix (2, 0, 0, 2, 2, 2), m);
		}

		[Test]
		public void ScaleAtPrepend ()
		{
		}

		[Test]
		public void ScalePrepend ()
		{
		}

		[Test]
		public void SetIdentity ()
		{
			Matrix m = new Matrix (5, 5, 5, 5, 5, 5);
			m.SetIdentity ();
			CheckMatrix (Matrix.Identity, m);
		}

		[Test]
		public void Skew ()
		{
		}

		[Test]
		public void SkewPrepend ()
		{
		}

		[Test]
		public void ToStringTest ()
		{
			Matrix m = new Matrix (1, 2, 3, 4, 5, 6);
			Assert.AreEqual ("1,2,3,4,5,6", m.ToString());
			m = Matrix.Identity;
			Assert.AreEqual ("Identity", m.ToString());
		}

		[Test]
		public void PointTransform ()
		{
			Matrix m = new Matrix (2, 0, 0, 2, 4, 4);

			Point p = new Point (5, 6);
		}

		[Test]
		public void VectorTransform ()
		{
		}

		[Test]
		public void Translate ()
		{
			Matrix m = new Matrix (1, 0, 0, 1, 0, 0);
			m.Translate (5, 5);
			CheckMatrix (new Matrix (1, 0, 0, 1, 5, 5), m);

			m = new Matrix (2, 0, 0, 2, 0, 0);
			m.Translate (5, 5);
			CheckMatrix (new Matrix (2, 0, 0, 2, 5, 5), m);
		}

		[Test]
		public void TranslatePrepend ()
		{
			Matrix m = new Matrix (1, 0, 0, 1, 0, 0);
			m.TranslatePrepend (5, 5);
			CheckMatrix (new Matrix (1, 0, 0, 1, 5, 5), m);

			m = new Matrix (2, 0, 0, 2, 0, 0);
			m.TranslatePrepend (5, 5);
			CheckMatrix (new Matrix (2, 0, 0, 2, 10, 10), m);
		}

	}
}

