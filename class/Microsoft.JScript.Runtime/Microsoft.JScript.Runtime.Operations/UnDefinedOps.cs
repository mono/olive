// UnDefinedOps.cs
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

	public static class UnDefinedOps {

		[SpecialName]
		public static ConcatString op_Addition (UnDefined x, ConcatString y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition (UnDefined x, string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (UnDefined x, [NotNull] JSBooleanObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (UnDefined x, [NotNull] JSNumberObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static string op_Addition (UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] UnDefined x, [NotNull] decimal y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool GreaterThanOrEqual ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] UnDefined x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] UnDefined x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (UnDefined x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (UnDefined x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (UnDefined x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (UnDefined x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (UnDefined x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

	}
}
