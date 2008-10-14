using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {
	public class JSObjectConstructor : JSFunctionObjectWithThis {

		public JSObjectConstructor (CodeContext context) : base (context, "", new string[] {}, true)
		{

		}

		public static object call (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static new object construct (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}
	}
}
