using System;
using System.Diagnostics;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {
	public sealed class Convert {
		public Convert ()
		{
		}

		public static bool CanConvertFrom (Type fromType, Type toType, NarrowingLevel level)
		{
			throw new NotImplementedException ();
		}

		public static object Coerce2 (object value, TypeCode target)
		{
			throw new NotImplementedException ();
		}

		public static object CoerceT (object value, Type to, bool explicitOk)
		{
			throw new NotImplementedException ();
		}

		public static bool ToBoolean (double d)
		{
			return Convert.ToBoolean (d, true);
		}

		[DebuggerHidden]	
		[DebuggerStepThrough]
		public static bool ToBoolean (object value)
		{
			return ToBoolean (value, true);
		}

		[DebuggerHidden]
		[DebuggerStepThrough]
		public static bool ToBoolean (object value, bool explicitConversion)
		{
			IConvertible convertible = value as IConvertible;
			return ToBoolean (value, explicitConversion, convertible);
		}

		private static bool ToBoolean (object value, bool explicitConversion, IConvertible convertible)
		{
			TypeCode preferredType = GetTypeCode (value, convertible);
			switch (preferredType) {
					//undefined & null
				case TypeCode.Empty:
				case TypeCode.DBNull:
					return false;

				case TypeCode.Boolean:
					return convertible.ToBoolean (null);

				case TypeCode.Byte:
				case TypeCode.Char:
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.SByte:
				case TypeCode.Single:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
					double d = convertible.ToDouble (null);
					return ((d != 0.0) && !double.IsNaN (d));
				case TypeCode.String:
					string str = convertible.ToString ();
					return str.Length != 0;
				case TypeCode.Object:
					return true;

				//TODO datetime find behaviour maybe as a number
				case TypeCode.DateTime:
					return true;
								
			}
			throw new NotImplementedException ();
		}

		public static int ToInt32 (object value)
		{//ECMA 9.5
			double d = ToNumber (value);
			if (double.IsNaN (d) || d == 0 || double.IsInfinity (d))
				return 0;
			double dd = Math.Sign (d) * Math.Floor (Math.Abs(d));
			//2^32 = 1 << 32
			//2^2 = 4 = 100b = 1 << 2 
			double ddd = Math.IEEERemainder(dd,(1 << 32));
			if (ddd >= (1 << 31))
				return (int)(ddd - (1 << 32));
			return (int)ddd;
		}

		public static double ToNumber (object value)
		{//ECMA 9.3

			IConvertible convertible = value as IConvertible;
			TypeCode preferredType = Convert.GetTypeCode (value, convertible);

			switch (preferredType) {
				case TypeCode.Empty:
					return double.NaN;
				case TypeCode.DBNull:
					return 0;
				case TypeCode.Boolean:
					return (convertible.ToBoolean (null) ? 1 : 0);
					//TODO here
				/*case TypeCode.String:
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Single:
					*/
				case TypeCode.Byte:
				case TypeCode.Char:
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.SByte:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
					return (double)value;

				case TypeCode.Object:
					return ToNumber(ToPrimitive (value, TypeCode.Double));
				//case TypeCode.DateTime:

			}
			throw new NotImplementedException ();
		}

		public static double ToNumber (string str)
		{
			return JSGlobalObject.parseFloat (str);
		}

		public static object ToObject (CodeContext context, object value)
		{
			IConvertible convertible = value as IConvertible;
			TypeCode preferredType = Convert.GetTypeCode (value, convertible);

			switch (preferredType) {
				case TypeCode.Empty:
				case TypeCode.DBNull:
					throw new TypeErrorException();

				case TypeCode.Boolean:
					return new JSBooleanObject (null, convertible.ToBoolean (null));

				case TypeCode.String:
					return new JSStringObject (null, convertible.ToString ());

				case TypeCode.Object:
					return value;

				//case TypeCode.DateTime:

				case TypeCode.Byte:
				case TypeCode.Char:
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.SByte:
				case TypeCode.Single:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
					return new JSNumberObject (null, convertible.ToDouble (null));
			}
			throw new NotImplementedException ();
		}

		public static string ToString (bool b)
		{
			throw new NotImplementedException ();
		}

		public static string ToString (double d)
		{
			throw new NotImplementedException ();
		}

		public static string ToString (object value)
		{
			throw new NotImplementedException ();
		}

		internal static object ToPrimitive (object value)
		{
			IConvertible convertible = value as IConvertible;
			TypeCode preferredType = GetTypeCode (value, convertible);

			return ToPrimitive (value, preferredType);
		}

		internal static object ToPrimitive (object value, TypeCode preferredType)
		{
				if (preferredType == TypeCode.Object) {
					if (value is JSObject) {
						return ((JSObject)value).GetDefaultValue (null, preferredType);
					}
				}
				//TODO for datetime convert to JSDateObject? check with unit test
			return value;
		}

		[DebuggerHidden]
		[DebuggerStepThrough]
		public static string ToString (object value, bool explicitOk)
		{
			throw new NotImplementedException ();
		}

		public static object [] VarArgs (object [] args, int offset, int n)
		{
			throw new NotImplementedException ();
		}

		internal static TypeCode GetTypeCode (object obj, IConvertible convertible)
		{
			if (obj == null)
				return TypeCode.Empty;
			else if (convertible == null)
				return TypeCode.Object;
			else
				return convertible.GetTypeCode ();
		}

	}
}
