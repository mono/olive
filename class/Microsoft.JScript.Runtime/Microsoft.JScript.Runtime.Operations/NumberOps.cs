// NumberOps.cs
//
// Authors:
//	Olivier Dufour <olivier.duff@gmail.com>
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
using Microsoft.Scripting;
using System.Runtime.CompilerServices;
using Microsoft.JScript.Runtime.Types;
using System.Scripting;

namespace Microsoft.JScript.Runtime.Operations {

	public static class NumberOps {

		[SpecialName]
		public static double op_Addition (double x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (double x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (double x, [NotNull] BooleanObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (double x, [NotNull] NumberObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static string op_Addition (double x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition (double x, [NotNull] ConcatString y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (double x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (double x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (double x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality (double x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (double x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (double x, decimal y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (double x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (double x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan (double x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan (double x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan (double x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual (double x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual (double x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual (double x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (double x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan (double x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan (double x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan (double x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual (double x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual (double x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual (double x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (double x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (double x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality (double x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality (double x, int y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality (double x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality (double x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (double x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_UnsignedRightShift (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (double x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction (double x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (double x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (double x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (double x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}
	}
}
