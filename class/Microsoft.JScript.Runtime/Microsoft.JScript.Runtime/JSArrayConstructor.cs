using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSArrayConstructor : JSFunctionObject {
//TODO base ctor param
		public JSArrayConstructor (CodeContext context) : base (context, "", new string []{}, true )
		{
			throw new NotImplementedException ();
		}

		public static object call (CodeContext context, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static JSArrayObject Construct (CodeContext context)
		{
			throw new NotImplementedException ();
		}

		public static new object construct (CodeContext context, object self, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static JSArrayObject CreateInstance (CodeContext context, params object [] args)
		{
			throw new NotImplementedException ();
		}
	}
}
