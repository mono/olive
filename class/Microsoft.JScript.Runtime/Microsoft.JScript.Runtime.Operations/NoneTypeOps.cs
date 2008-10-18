// NoneTypeOps.cs
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
using System.Scripting;
using System.Runtime.CompilerServices;
using Microsoft.JScript.Runtime.Types;

namespace Microsoft.JScript.Runtime.Operations {

	public static class NoneTypeOps {

		[SpecialName]
		public static double op_Addition (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (None x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (None x, [NotNull] BooleanObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (None x, [NotNull] NumberObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static string op_Addition (None x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition (None x, [NotNull] ConcatString y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (None x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (None x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (None x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality (None x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality (None x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_ExclusiveOr (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (None x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan (None x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan (None x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual (None x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual (None x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (None x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan (None x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan (None x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual (None x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual (None x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (None x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Multiply (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (None x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (None x, decimal y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (None x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (None x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (None x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_UnsignedRightShift (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (None x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction (None x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (None x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (None x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (None x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction (None x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}
	}
}
