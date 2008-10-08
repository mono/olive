using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSNumberPrototype : JSNumberObject {

		public JSNumberPrototype (CodeContext context, JSObject prototype)
			: base (prototype, 0d)
		{
		}

		public static string toExponential (object thisob, object fractionDigits)
		{
			throw new NotImplementedException ();
		}

		public static string toFixed (object thisob, double fractionDigits)
		{
			throw new NotImplementedException ();
		}

		public static string toLocaleString (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string toPrecision (object thisob, object precision)
		{
			throw new NotImplementedException ();
		}

		public static string toString (object thisob, object radix)
		{
			throw new NotImplementedException ();
		}

		public static object valueOf (object thisob)
		{
			throw new NotImplementedException ();
		}
	}
}
