using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSFunctionConstructor : JSFunctionObject {

		public JSFunctionConstructor (CodeContext context) : base (context, "", new string []{}, true )
		{

		}

		public static JSObject call (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static new JSObject construct (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}
	}
}
