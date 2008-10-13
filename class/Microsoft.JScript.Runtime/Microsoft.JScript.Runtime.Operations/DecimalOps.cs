// decimal.cs
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
using System.Runtime.CompilerServices;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime
{
    
    
	public static class DecimalOps
	{
 		[SpecialName]
		public static double op_Addition (decimal x, JSBooleanObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition(decimal x, JSNumberObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static string op_Addition(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition(decimal x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition(decimal x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition(decimal x, string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition(decimal x, ConcatString y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseAnd(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseAnd(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseAnd(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseAnd(decimal x, string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr(decimal x, string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division(decimal x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(decimal x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(decimal x, string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr(decimal x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(decimal x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(decimal x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(decimal x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(decimal x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(decimal x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(decimal x, string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift(decimal x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(decimal x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(decimal x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(decimal x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(decimal x, string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus(decimal x, string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply(decimal x, string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift(decimal x, string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction(decimal x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction(decimal x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_UnsignedRightShift(decimal x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift(decimal x, UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift(decimal x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift(decimal x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift(decimal x, string y)
		{
			throw new NotImplementedException ();
		}
	}
}
