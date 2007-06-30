using System;
using System.Collections.Generic;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSMathObject : JSObject {

		public const double E = Math.E;
		public const double LN10 = 2.30259;
		public const double LN2 = 0.693147;
		public const double LOG10E = 0.434294;
		public const double LOG2E = 1.4427;
		public const double PI = Math.PI;
		public const double SQRT1_2 = 0.707107;
		public const double SQRT_2 = 1.41421;

		internal JSMathObject ()
			: base (null)
		{
		}

		public static double abs (double d)
		{
			return Math.Abs (d);
		}

		public static object abs (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double acos (double x)
		{
			return Math.Acos (x);
		}

		public static object acos (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double asin (double x)
		{
			return Math.Asin (x);
		}

		public static object asin (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double atan (double x)
		{
			return Math.Atan (x);
		}

		public static object atan (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double atan2 (double dx, double dy)
		{
			return Math.Atan2 (dy, dx);
		}

		public static object atan2 (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double ceil (double x)
		{
			return Math.Ceiling (x);
		}

		public static object ceil (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double cos (double x)
		{
			return Math.Cos (x);
		}

		public static object cos (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double exp (double x)
		{
			return Math.Exp (x);
		}

		public static object exp (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double floor (double x)
		{
			return Math.Floor (x);
		}

		public static object floor (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public override string GetClassName ()
		{
			return base.GetClassName ();
		}

		public static object GetClassName (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double log (double x)
		{
			return Math.Log (x);
		}

		public static object log (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double max (object x, object y, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static object max (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double min (object x, object y, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static object min (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double pow (double dx, double dy)
		{
			return Math.Pow (dx, dy);
		}

		public static object pow (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double random ()
		{
			Random r = new Random ();
			return r.NextDouble ();
		}

		public static object random (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double round (double d)
		{
			return Math.Round (d);
		}

		public static object round (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double sin (double x)
		{
			return Math.Sin (x);
		}

		public static object sin (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double sqrt (double x)
		{
			return Math.Sqrt (x);
		}

		public static object sqrt (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double tan (double x)
		{
			return Math.Tan (x);
		}

		public static object tan (params object [] arguments)
		{
			throw new NotImplementedException ();
		}
	}
}
