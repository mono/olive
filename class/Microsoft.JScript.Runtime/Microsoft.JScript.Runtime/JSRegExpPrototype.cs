using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSRegExpPrototype {

		public JSRegExpPrototype ()
		{
		}

		public static JSRegExpObject compile (object thisob, object source, object flags)
		{
			throw new NotImplementedException ();
		}

		public static object compile (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object exec (CodeContext context, object thisob, object input)
		{
			throw new NotImplementedException ();
		}

		public static object exec (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static bool test (object thisob, object input)
		{
			throw new NotImplementedException ();
		}

		public static object test (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static string toString (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static object toString (params object [] arguments)
		{
			throw new NotImplementedException ();
		}
	}
}
