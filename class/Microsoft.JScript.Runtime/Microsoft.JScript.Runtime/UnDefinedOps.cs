using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Internal;

namespace Microsoft.JScript.Runtime {

	public static class UnDefinedOps {

		[OperatorMethod]
		public static double Add (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Add (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Add (UnDefined x, [NotNull] JSBooleanObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Add (UnDefined x, [NotNull] JSNumberObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static string Add (UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Add (UnDefined x, IronPython.Runtime.Types.None y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static string Add (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Add (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int BitwiseAnd (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int BitwiseAnd (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int BitwiseAnd (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int BitwiseAnd (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int BitwiseAnd (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int BitwiseOr (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int BitwiseOr (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int BitwiseOr (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int BitwiseOr (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int BitwiseOr (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Divide (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Divide (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Divide (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Divide (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Divide (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool Equal ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool Equal ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool Equal ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool Equal ([NotNull] UnDefined x, IronPython.Runtime.Types.None y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool Equal ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool Equal ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int ExclusiveOr (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int ExclusiveOr (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int ExclusiveOr (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int ExclusiveOr (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int ExclusiveOr (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThan ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThan ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThan ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThan ([NotNull] UnDefined x, IronPython.Runtime.Types.None y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThan ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThan ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, IronPython.Runtime.Types.None y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int LeftShift (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int LeftShift (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int LeftShift (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int LeftShift (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int LeftShift (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThan ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThan ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThan ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThan ([NotNull] UnDefined x, IronPython.Runtime.Types.None y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThan ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThan ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, IronPython.Runtime.Types.None y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool LessThanOrEqual ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Mod (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Mod (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Mod (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Mod (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Mod (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Multiply (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Multiply (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Multiply (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Multiply (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Multiply (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool NotEqual ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool NotEqual ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool NotEqual ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool NotEqual ([NotNull] UnDefined x, IronPython.Runtime.Types.None y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool NotEqual ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool NotEqual ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int RightShift (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int RightShift (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int RightShift (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int RightShift (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static int RightShift (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static uint RightShiftUnsigned (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static uint RightShiftUnsigned (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static uint RightShiftUnsigned (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static uint RightShiftUnsigned (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static uint RightShiftUnsigned (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Subtract (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Subtract (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Subtract (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Subtract (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Subtract (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

	}
}
