using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSBooleanConstructor : JSFunctionObject {
		public JSBooleanConstructor(CodeContext context) : base (context, "", new string []{}, true )
		{
			throw new NotImplementedException ();			
		}

		public static object call (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object construct (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}
	}
}
