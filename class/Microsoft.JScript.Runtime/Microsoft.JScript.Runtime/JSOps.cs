using System;
using System.Collections.Generic;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace Microsoft.JScript.Runtime {

	public static class JSOps {

		public static int CompareTypes (object x, object y)
		{
			if ((x == null) && (y == null)) {
				return 0;
			} else if (x == null) {
				return -1;
			} else if (y == null) {
				return 1;
			}
			return string.Compare (x.GetType ().ToString (), y.GetType ().ToString ());
		}

		public static bool CompareTypesEqual (object x, object y)
		{
			return (CompareTypes (x, y) == 0);
		}

		public static bool CompareTypesGreaterThan (object x, object y)
		{
			return (CompareTypes (x, y) > 0);
		}

		public static bool CompareTypesGreaterThanOrEqual (object x, object y)
		{
			return (CompareTypes (x, y) >= 0);
		}

		public static bool CompareTypesLessThan (object x, object y)
		{
			return (CompareTypes (x, y) < 0);
		}

		public static bool CompareTypesLessThanOrEqual (object x, object y)
		{
			return (CompareTypes (x, y) <= 0);
		}

		public static bool CompareTypesNotEqual (object x, object y)
		{
			return (CompareTypes (x, y) != 0);
		}

		public static IList<object> GetAttrNames (CodeContext context, object o)
		{
			//TODO
			throw new NotImplementedException ();
		}

		public static IList<object> GetAttrNamesHost (CodeContext context, object o)
		{
			//TODO
			throw new NotImplementedException ();
		}

		public static IAttributesCollection GetEnvironmentDictionary (object environment)
		{
			throw new NotImplementedException ();
		}

		public static JSGlobalObject GetGlobalObject (CodeContext context)
		{
			throw new NotImplementedException ();
			//return new JSGlobalObject (((JSContext)context.LanguageContext).);//get scriptModule somewhere
		}

		public static object GetThisObject (CodeContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public static bool DelIndex (CodeContext context, object obj, object index)
		{
			throw new NotImplementedException ();
		}

		public static bool TryGetAttr (CodeContext context, object o, SymbolId name, out object ret)
		{
			throw new NotImplementedException ();
		}

		public static Exception TypeError (string format, object[] args)
		{
			throw new NotImplementedException ();
		}

		public static Exception ValueError (string format, object[] args)
		{
			throw new NotImplementedException ();
		}

		public static object CallWithContext (CodeContext context, object func, object[] args)
		{
			throw new NotImplementedException ();
		}

		public static object CallWithContextAndThis (CodeContext context, object func, object instance, object[] args)
		{
			throw new NotImplementedException ();
		}

		public static object GetIndex (CodeContext context, object o, object index)
		{
			throw new NotImplementedException ();
		}

		public static void SetIndex (CodeContext context, object o, object index, object value)
		{
			throw new NotImplementedException ();
		}
	}
}
