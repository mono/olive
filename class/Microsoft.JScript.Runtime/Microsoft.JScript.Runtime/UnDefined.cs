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
			throw new NotImplementedException ();
		}

		public bool ToBoolean (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public byte ToByte (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public char ToChar (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public DateTime ToDateTime (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public decimal ToDecimal (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public double ToDouble (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public short ToInt16 (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public int ToInt32 (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public long ToInt64 (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		[CLSCompliant (false)]
		public sbyte ToSByte (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public float ToSingle (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public string ToString (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public object ToType (Type conversionType, IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		[CLSCompliant (false)]
		public ushort ToUInt16 (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}
		
		[CLSCompliant (false)]
		public uint ToUInt32 (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		[CLSCompliant (false)]
		public ulong ToUInt64 (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	}
}
