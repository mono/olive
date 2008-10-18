// NumberObjectOps.cs
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

	public static class NumberObjectOps {

		[SpecialName]
		public static double op_Addition ([NotNull] NumberObject x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition ([NotNull] NumberObject x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition ([NotNull] NumberObject x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition ([NotNull] NumberObject x, [NotNull] BooleanObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition ([NotNull] NumberObject x, [NotNull] NumberObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static string op_Addition ([NotNull] NumberObject x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition ([NotNull] NumberObject x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition ([NotNull] NumberObject x, [NotNull] ConcatString y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static ConcatString op_Addition ([NotNull] NumberObject x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Equality ([NotNull] NumberObject x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] NumberObject x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] NumberObject x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] NumberObject x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] NumberObject x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] NumberObject x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThan ([NotNull] NumberObject x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] NumberObject x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] NumberObject x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] NumberObject x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] NumberObject x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThan ([NotNull] NumberObject x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] NumberObject x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] NumberObject x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] NumberObject x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] NumberObject x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] NumberObject x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_GreaterThanOrEqual ([NotNull] NumberObject x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThan ([NotNull] NumberObject x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] NumberObject x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] NumberObject x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] NumberObject x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] NumberObject x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThan ([NotNull] NumberObject x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] NumberObject x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] NumberObject x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] NumberObject x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] NumberObject x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] NumberObject x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_LessThanOrEqual ([NotNull] NumberObject x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}


		[SpecialName]
		public static bool op_Inequality ([NotNull] NumberObject x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] NumberObject x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] NumberObject x, int y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] NumberObject x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] NumberObject x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] NumberObject x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] NumberObject x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}
	}
}
