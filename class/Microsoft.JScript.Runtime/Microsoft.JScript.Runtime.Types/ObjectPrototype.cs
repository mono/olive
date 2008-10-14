using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSObjectPrototype : JSObject {

		public JSObjectPrototype (JSObject prototype) : base (prototype)
		{

		}

		public static object hasOwnProperty (CodeContext context, object instance, object propertyName)
		{
			throw new NotImplementedException ();
		}

		public static object isPrototypeOf (object instance, object value)
		{
			throw new NotImplementedException ();
		}

		public static object propertyIsEnumerable (CodeContext context, object instance, object propertyName)
		{
			throw new NotImplementedException ();
		}

		public static object toLocaleString (CodeContext context, object instance)
		{
			throw new NotImplementedException ();
		}

		public static object toString (object instance)
		{
			throw new NotImplementedException ();
		}

		public static object valueOf (object instance)
		{
			throw new NotImplementedException ();
		}
	}
}
