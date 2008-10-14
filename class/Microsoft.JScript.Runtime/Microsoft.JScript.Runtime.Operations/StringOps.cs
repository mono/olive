// StringOps.cs
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

namespace Microsoft.JScript.Runtime.Operations {

	public static class StringOps {

		[SpecialName]
		public static ConcatString op_Addition ([NotNull] string x, ConcatString y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition ([NotNull] string x, [NotNull] JSBooleanObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition ([NotNull] string x, [NotNull] JSNumberObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition ([NotNull] string x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd ([NotNull] string x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseAnd ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_BitwiseOr ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr ([NotNull] string x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_BitwiseOr ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Division ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division ([NotNull] string x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Division ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] string x, decimal y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] string x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] string x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr ([NotNull] string x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_ExclusiveOr ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] string x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] string x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] string x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] string x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_LeftShift ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift ([NotNull] string x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_LeftShift ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] string x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] string x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] string x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] string x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Modulus ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus ([NotNull] string x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Modulus ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply ([NotNull] string x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Multiply ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] string x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] string x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_RightShift ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift ([NotNull] string x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_RightShift ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_UnsignedRightShift ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift ([NotNull] string x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_UnsignedRightShift ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static double op_Subtraction ([NotNull] string x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction ([NotNull] string x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction ([NotNull] string x, JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction ([NotNull] string x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Subtraction ([NotNull] string x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}
	}
}
