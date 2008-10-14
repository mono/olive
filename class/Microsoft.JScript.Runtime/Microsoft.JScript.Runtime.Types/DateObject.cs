using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
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
