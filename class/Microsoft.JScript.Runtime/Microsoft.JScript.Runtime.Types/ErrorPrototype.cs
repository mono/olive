using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSErrorPrototype : JSErrorObject {

		public JSErrorPrototype (CodeContext context, JSObject prototype, ErrorType errorType)
		{

		}

		public static string toString (CodeContext context, object instance)
		{
			throw new NotImplementedException ();
		}
	}
}
