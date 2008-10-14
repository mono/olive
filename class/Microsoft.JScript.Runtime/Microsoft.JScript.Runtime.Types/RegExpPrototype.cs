using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSRegExpPrototype : JSObject {

		public JSRegExpPrototype (CodeContext context, JSObject prototype) : base (prototype)
		{
		}

		public static JSRegExpObject compile (object thisob, object source, object flags)
		{
			throw new NotImplementedException ();
		}

		public static object exec (CodeContext context, object thisob, object input)
		{
			throw new NotImplementedException ();
		}

		public static bool test (object thisob, object input)
		{
			throw new NotImplementedException ();
		}

		public static string toString (object thisob)
		{
			throw new NotImplementedException ();
		}
	}
}
