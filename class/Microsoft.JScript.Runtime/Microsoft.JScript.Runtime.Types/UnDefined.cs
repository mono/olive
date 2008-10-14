using System;

namespace Microsoft.JScript.Runtime {

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
