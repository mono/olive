using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSStringConstructor : JSFunctionObjectWithThis{

		public JSStringConstructor (CodeContext context) : base (context, "", new string [] {}, true )
		{

		}
		public static object call (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object construct (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static string fromCharCode (object instance, params object [] args)
		{
			throw new NotImplementedException ();
		}
	}
}
