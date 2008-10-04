// ConcatString.cs
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

namespace Microsoft.JScript.Runtime
{
	public static class ConcatStringOps
	{

/*
		public static ConcatString operator + (ConcatString x, JSBooleanObject y)
		{
			throw new NotImplementedException ();
		}

		public static ConcatString operator +(ConcatString x, JSNumberObject y)
		{
			throw new NotImplementedException ();
		}


		public static ConcatString operator +(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static ConcatString operator +(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static ConcatString operator +(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static ConcatString operator +(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static ConcatString operator +(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static double operator &(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		public static double operator &(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static double operator &(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static double operator &(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static double operator &(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static double operator &(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static double operator |(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		public static double operator |(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static double operator |(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static double operator |(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static double operator |(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static double operator |(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static double operator /(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		public static double operator /(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static double operator /(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static double operator /(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static double operator /(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static double operator /(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator ==(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator ==(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator ==(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator ==(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator ==(ConcatString x, decimal y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator ==(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator ==(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static double operator ^(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		public static double operator ^(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static double operator ^(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static double operator ^(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static double operator ^(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static double operator ^(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >=(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >=(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >=(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >=(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >=(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator >=(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator !=(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator !=(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator !=(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator !=(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator !=(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator !=(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static double operator <<(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		public static double operator <<(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static double operator <<(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static double operator <<(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static double operator <<(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static double operator <<(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <=(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <=(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <=(ConcatString x, None y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <=(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <=(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static bool operator <=(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static double operator %(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		public static double operator %(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static double operator %(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static double operator %(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static double operator %(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static double operator %(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static double operator *(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		public static double operator *(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static double operator *(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static double operator *(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static double operator *(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static double operator *(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static double operator >>(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		public static double operator >>(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static double operator >>(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static double operator >>(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static double operator >>(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static double operator >>(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static double operator -(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		public static double operator -(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static double operator -(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static double operator -(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static double operator -(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static double operator -(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}


		public static double op_UnsignedRightShift(ConcatString x, ConcatString y)
		{
			throw new NotImplementedException ();
		}


		public static double op_UnsignedRightShift(ConcatString x, JSObject y)
		{
			throw new NotImplementedException ();
		}


		public static double op_UnsignedRightShift(ConcatString x, UnDefined y)
		{
			throw new NotImplementedException ();
		}


		public static double op_UnsignedRightShift(ConcatString x, bool y)
		{
			throw new NotImplementedException ();
		}


		public static double op_UnsignedRightShift(ConcatString x, double y)
		{
			throw new NotImplementedException ();
		}


		public static double op_UnsignedRightShift(ConcatString x, string y)
		{
			throw new NotImplementedException ();
		}*/
	 }
}
