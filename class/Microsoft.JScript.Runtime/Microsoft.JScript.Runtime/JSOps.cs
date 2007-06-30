using System;
using System.Collections.Generic;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace Microsoft.JScript.Runtime {

	public static class JSOps {

		public static int CompareTypes (object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static bool CompareTypesEqual (object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static bool CompareTypesGreaterThan (object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static bool CompareTypesGreaterThanOrEqual (object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static bool CompareTypesLessThan (object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static bool CompareTypesLessThanOrEqual (object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static bool CompareTypesNotEqual (object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static IList<object> GetAttrNames (CodeContext context, object o)
		{
			throw new NotImplementedException ();
		}

		public static JSGlobalObject GetGlobalObject (CodeContext context)
		{
			throw new NotImplementedException ();
		}

		public static object GetThisObject (CodeContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public static object InPlaceRightShiftUnsigned (object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static object RightShiftUnsigned (object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static Exception SyntaxError (string msg, string filename, int line, int column, string lineText,
						     int errorCode, Severity severity)
		{
			throw new NotImplementedException ();
		}
	}
}
