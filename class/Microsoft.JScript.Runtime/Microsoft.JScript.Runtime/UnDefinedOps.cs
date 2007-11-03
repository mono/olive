using System;
using Microsoft.Scripting;
using System.Runtime.CompilerServices;

namespace Microsoft.JScript.Runtime {

	public static class UnDefinedOps {

		[SpecialName]
		public static double Add (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Add (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Add (UnDefined x, [NotNull] JSBooleanObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Add (UnDefined x, [NotNull] JSNumberObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static string Add (UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Add (UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static string Add (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Add (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int BitwiseAnd (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int BitwiseAnd (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int BitwiseAnd (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int BitwiseAnd (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int BitwiseAnd (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int BitwiseOr (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int BitwiseOr (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int BitwiseOr (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int BitwiseOr (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int BitwiseOr (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Divide (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Divide (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Divide (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Divide (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Divide (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool Equal ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool Equal ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool Equal ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool Equal ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool Equal ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool Equal ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int ExclusiveOr (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int ExclusiveOr (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int ExclusiveOr (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int ExclusiveOr (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int ExclusiveOr (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThan ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThan ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThan ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThan ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThan ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThan ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int LeftShift (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int LeftShift (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int LeftShift (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int LeftShift (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int LeftShift (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThan ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThan ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThan ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThan ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThan ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThan ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Mod (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Mod (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Mod (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Mod (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Mod (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Multiply (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Multiply (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Multiply (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Multiply (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Multiply (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool NotEqual ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool NotEqual ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool NotEqual ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool NotEqual ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool NotEqual ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool NotEqual ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int RightShift (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int RightShift (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int RightShift (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int RightShift (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static int RightShift (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static uint RightShiftUnsigned (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static uint RightShiftUnsigned (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static uint RightShiftUnsigned (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static uint RightShiftUnsigned (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static uint RightShiftUnsigned (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Subtract (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Subtract (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Subtract (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Subtract (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double Subtract (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

	}
}
