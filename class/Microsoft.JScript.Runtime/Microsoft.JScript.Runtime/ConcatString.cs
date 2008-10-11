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
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.JScript.Runtime
{
	 
	 public sealed class ConcatString : IFormattable, IComparable, IConvertible, IComparable <string>, IEnumerable <char>, IEquatable <string>
	 {
		  
		public ConcatString(ConcatString string1, string string2)
		{
			throw new NotImplementedException ();
		}

		public ConcatString(string string1, ConcatString string2)
		{
			throw new NotImplementedException ();
		}

		public ConcatString(string string1, string string2)
		{
			throw new NotImplementedException ();
		}
	
		public override bool Equals (object obj)
		{
			throw new NotImplementedException ();
		}

		public override int GetHashCode ()
		{
			throw new NotImplementedException ();
		}

		public static implicit operator string(ConcatString s)
		{
			return (s != null) ? s.ToString () : string.Empty;
		}

		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	
		public char this[int index]
		{
			get
			{
				throw new NotImplementedException ();
			}
		}
#region private member

		IEnumerator<char> IEnumerable<char>.GetEnumerator()
		{
			throw new NotImplementedException ();
		}
	
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException ();
		}
	
		int IComparable.CompareTo(object obj)
		{
			throw new NotImplementedException ();
		}
	
		int IComparable<string>.CompareTo(string other)
		{
			throw new NotImplementedException ();
		}
	
		TypeCode IConvertible.GetTypeCode()
		{
			throw new NotImplementedException ();
		}
	
		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		byte IConvertible.ToByte(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		char IConvertible.ToChar(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		double IConvertible.ToDouble(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		short IConvertible.ToInt16(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		int IConvertible.ToInt32(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		long IConvertible.ToInt64(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		float IConvertible.ToSingle(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		string IConvertible.ToString(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
	
		bool IEquatable<string>.Equals(string other)
		{
			throw new NotImplementedException ();
		}
	
		string IFormattable.ToString(string format, IFormatProvider formatProvider)
		{
			throw new NotImplementedException ();
		}
	
		IConvertible ToIConvertible()
		{
			throw new NotImplementedException ();
		}
		
		public int Length
		{
			get
			{
				throw new NotImplementedException ();
			}
		}


#endregion
	 }
}
