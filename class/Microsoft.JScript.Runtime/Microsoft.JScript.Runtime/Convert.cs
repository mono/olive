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
			throw new NotImplementedException ();
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
