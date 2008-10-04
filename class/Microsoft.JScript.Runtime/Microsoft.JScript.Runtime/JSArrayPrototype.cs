using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSArrayPrototype : JSArrayObject {

			
		
		static JSArrayPrototype ()
		{
			DefaultJoinSeparator = ",";
		}

		public JSArrayPrototype (CodeContext context, JSObject prototype)
		{
			throw new NotImplementedException ();
		}

		public static readonly string DefaultJoinSeparator;

		public static JSArrayObject concat (CodeContext context, object thisob, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static string join (CodeContext context, object thisob, object separator)
		{
			throw new NotImplementedException ();
		}

		public static object pop (CodeContext context, object thisob)
		{
			throw new NotImplementedException ();
		}

		public static object push (CodeContext context, object thisob, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static object reverse (CodeContext context, object thisob)
		{
			throw new NotImplementedException ();
		}

		public static object shift (CodeContext context, object thisob)
		{
			throw new NotImplementedException ();
		}

		public static JSArrayObject slice (CodeContext context, object thisob, double start, object end)
		{
			throw new NotImplementedException ();
		}

		public static object sort (CodeContext context, object thisob, object function)
		{
			throw new NotImplementedException ();
		}

		public static JSArrayObject splice (CodeContext context, object thisob, double start, double deleteCnt,
						    params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static string toLocaleString (CodeContext context, object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string toString (CodeContext context, object thisob)
		{
			throw new NotImplementedException ();
		}

		public static object unshift (CodeContext context, object thisob, params object [] args)
		{
			throw new NotImplementedException ();
		}
	}
}
