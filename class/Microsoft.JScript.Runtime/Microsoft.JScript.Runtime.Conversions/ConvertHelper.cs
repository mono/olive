// ConvertHelper.cs
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
using System.Diagnostics;
using Microsoft.Scripting;
using Microsoft.Scripting.Generation;
using Microsoft.Scripting.Runtime;

namespace Microsoft.JScript.Runtime.Conversions {
	public sealed class ConvertHelper {
		public ConvertHelper ()
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

		public static object CoerceT (object value, Type to)
		{
			throw new NotImplementedException ();
		}

		public static object ConvertToDelegate (object fromObject, RuntimeTypeHandle typeHandle)
		{
			throw new NotImplementedException ();
		}

		public static object ConvertToNullableType (object fromObject, RuntimeTypeHandle typeHandle)
		{
			throw new NotImplementedException ();
		}

		public static object ConvertToReferenceType (object fromObject, RuntimeTypeHandle typeHandle)
		{
			throw new NotImplementedException ();
		}

		public static object ConvertToValueType (object fromObject, RuntimeTypeHandle typeHandle)
		{
			throw new NotImplementedException ();
		}

		public static Type ConvertToType (object value)
		{
			throw new NotImplementedException ();
		}
		
		public static Type SelectBestConversionFor (Type actualType, Type candidateOne, Type candidateTwo, NarrowingLevel level)
		{
			throw new NotImplementedException ();
		}
		

		public static bool ToBoolean (double d)
		{
			return Convert.ToBoolean (d, true);
		}

		public static bool ToBoolean (object value)
		{
			return ToBoolean (value, true);
		}

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

		public static string ToString (object value, bool explicitOk)
		{
			throw new NotImplementedException ();
		}
/*
		public static object [] VarArgs (object [] args, int offset, int n)
		{
			throw new NotImplementedException ();
		}
*/
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
