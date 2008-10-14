using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSDateConstructor : JSFunctionObject {
		
		public JSDateConstructor (CodeContext context) : base (context, "", new string []{}, true )
		{
			throw new NotImplementedException ();
		}

		public static object call (CodeContext context, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static new JSObject construct (CodeContext context, object self, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static string Invoke ()
		{
			throw new NotImplementedException ();
		}

		public static double parse (string str)
		{
			throw new NotImplementedException ();
		}

		public static double UTC (object year, object month, object date, object hours, object minutes, object seconds,
					  object ms)
		{
			throw new NotImplementedException ();
		}
	}
}
