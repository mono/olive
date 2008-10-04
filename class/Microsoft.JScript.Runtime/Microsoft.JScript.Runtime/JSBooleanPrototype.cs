using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSBooleanPrototype : JSBooleanObject {
		
		public JSBooleanPrototype (CodeContext context, JSObject prototype) : base(prototype, true)
		{
		}

		public static string toString (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static object valueOf (object thisob)
		{
			throw new NotImplementedException ();
		}
	}
}
