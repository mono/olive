// UnDefined.cs
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

namespace Microsoft.JScript.Runtime.Types {

	[Serializable]
	public sealed class UnDefined : IConvertible {

		public static readonly object Value;

		UnDefined ()
		{
		}

		public TypeCode GetTypeCode ()
		{
			return TypeCode.Empty;
		}

		public bool ToBoolean (IFormatProvider provider)
		{
			return false;
		}

		public byte ToByte (IFormatProvider provider)
		{
			return 0x00;
		}

		public char ToChar (IFormatProvider provider)
		{
			return '\0';//endding char
		}

		public DateTime ToDateTime (IFormatProvider provider)
		{
			return DateTime.MinValue;
		}

		public decimal ToDecimal (IFormatProvider provider)
		{
			return 0;
		}

		public double ToDouble (IFormatProvider provider)
		{
			return 0;
		}

		public short ToInt16 (IFormatProvider provider)
		{
			return 0;
		}

		public int ToInt32 (IFormatProvider provider)
		{
			return 0;
		}

		public long ToInt64 (IFormatProvider provider)
		{
			return 0;
		}

		public sbyte ToSByte (IFormatProvider provider)
		{
			return 0;
		}

		public float ToSingle (IFormatProvider provider)
		{
			return 0;
		}

		public string ToString (IFormatProvider provider)
		{
			return "undefined";
		}

		public object ToType (Type conversionType, IFormatProvider provider)
		{
			return null;
		}

		public ushort ToUInt16 (IFormatProvider provider)
		{
			return 0;
		}
		
		public uint ToUInt32 (IFormatProvider provider)
		{
			return 0;
		}

		public ulong ToUInt64 (IFormatProvider provider)
		{
			return 0;
		}

		public override string ToString ()
		{
			return "undefined";
		}
	}
}
