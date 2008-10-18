// MathObject.cs
//
// Authors:
//   Olivier Dufour <olivier.duff@gmail.com>
//
// Copyright (C) 2008 Olivier Dufour
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
//

using System;
using System.Collections.Generic;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace Microsoft.JScript.Runtime.Types {

	[Serializable]
	public class MathObject : JSObject {

		public const double E = 2.71828182845905;
		public const double LN10 = 2.30258509299405;
		public const double LN2 = 0.693147180559945;
		public const double LOG10E = 0.434294481903252;
		public const double LOG2E = 1.44269504088896;
		public const double PI = 3.14159265358979;
		public const double SQRT1_2 = 0.707106781186548;
		public const double SQRT2 = 1.4142135623731;

		internal MathObject ()
			: base (null)
		{
		}

		public MathObject (CodeContext context, JSObject prototype)
			: base (null)
		{
		}

		public static double abs (double d)
		{
			return Math.Abs (d);
		}

		public static double acos (double x)
		{
			return Math.Acos (x);
		}

		public static double asin (double x)
		{
			return Math.Asin (x);
		}

		public static double atan (double x)
		{
			return Math.Atan (x);
		}

		public static double atan2 (double dx, double dy)
		{
			return Math.Atan2 (dy, dx);
		}

		public static double ceil (double x)
		{
			return Math.Ceiling (x);
		}

		public static double cos (double x)
		{
			return Math.Cos (x);
		}

		public static double exp (double x)
		{
			return Math.Exp (x);
		}

		public static double floor (double x)
		{
			return Math.Floor (x);
		}

		public override string GetClassName ()
		{
			return base.GetClassName ();
		}

		public static double log (double x)
		{
			return Math.Log (x);
		}

		public static double max (object x, object y, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static double min (object x, object y, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static double pow (double dx, double dy)
		{
			return Math.Pow (dx, dy);
		}

		public static double random ()
		{
			Random r = new Random ();
			return r.NextDouble ();
		}

		public static double round (double d)
		{
			return Math.Round (d);
		}

		public static double sin (double x)
		{
			return Math.Sin (x);
		}

		public static double sqrt (double x)
		{
			return Math.Sqrt (x);
		}

		public static double tan (double x)
		{
			return Math.Tan (x);
		}
	}
}
