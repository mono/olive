using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSFunctionPrototype : JSFunctionObject {

		public JSFunctionPrototype (CodeContext context, JSObject prototype) : base (context, "", new string[] {},
					    true)
		{
			throw new NotImplementedException ();
		}

		public static object apply (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object call (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object CallTarget (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static string toString (object instance)
		{
			throw new NotImplementedException ();
		}
	}
}
