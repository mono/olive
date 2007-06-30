using System;
using Microsoft.Scripting;
using IronPython.Runtime.Types;

namespace Microsoft.JScript.Runtime {

	public class JSDateObject : JSObject {
		public JSDateObject (JSObject prototype, double val)
			: base (prototype)
		{
		}

		public override string GetClassName ()
		{
			return base.GetClassName ();
		}
	}
}
