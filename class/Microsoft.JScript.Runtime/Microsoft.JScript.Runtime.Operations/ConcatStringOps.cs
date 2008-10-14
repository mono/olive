// ConcatStringOps.cs
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
using System.Runtime.CompilerServices;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime.Operations
{
	public static class ConcatStringOps
	{

		[SpecialName]
		public static ConcatString op_Addition (ConcatString x, JSBooleanObject y)
		{
			return new ConcatString(x, Convert.ToString(y));
		}

		[SpecialName]
		public static ConcatString op_Addition(ConcatString x, JSNumberObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseAnd(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseAnd(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseAnd(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseAnd(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseAnd(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseAnd(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(ConcatString x, decimal y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}
	 }
}
