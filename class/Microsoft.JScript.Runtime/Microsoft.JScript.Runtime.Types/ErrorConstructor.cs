using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSErrorConstructor : JSFunctionObjectWithThis {
		
		public JSErrorConstructor (CodeContext context, ErrorType errorType) : base (context, "", delegate { return null;}, new string []{}, true )
		{
			throw new NotImplementedException ();
		}

		public static object callError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callEvalError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callRangeError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callReferenceError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callSyntaxError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callTypeError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callURIError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructEvalError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructRangeError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructReferenceError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructSyntaxError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructTypeError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructURIError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}
	}
}
