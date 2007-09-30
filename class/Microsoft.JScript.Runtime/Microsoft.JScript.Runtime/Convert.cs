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
			throw new NotImplementedException ();
		}

		[DebuggerHidden]	
		[DebuggerStepThrough]
		public static bool ToBoolean (object value)
		{
			throw new NotImplementedException ();
		}

		[DebuggerHidden]
		[DebuggerStepThrough]
		public static bool ToBoolean (object value, bool explicitConversion)
		{
			throw new NotImplementedException ();
		}

		public static int ToInt32 (object value)
		{
			throw new NotImplementedException ();
		}

		public static double ToNumber (object value)
		{

			throw new NotImplementedException ();
		}

		public static double ToNumber (string str)
		{
			return Double.Parse (str);
		}

		public static object ToObject (CodeContext context, object value)
		{
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
		{//TODO done something to get JSObject.eType from regulare type 
			//else find a type which ever done that somewhere...
			return ToPrimitive (value, null);
		}

		internal static object ToPrimitive (object value, JSObject.eType preferredType)
		{
			if (value is JSObject)
			{

				switch (preferredType) {
					case JSObject.eType.Undefined:
					case JSObject.eType.Null:
					case JSObject.eType.Boolean:
					case JSObject.eType.Number:
					case JSObject.eType.String:
						return value;
					case JSObject.eType.Object:
						return ((JSObject)value).GetDefaultValue (null, preferredType);
					default:
						break;
				}
			}
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
	}
}
