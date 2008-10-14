using System;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSBooleanObject : JSObject {
		
		internal bool value;

		public JSBooleanObject (JSObject prototype, bool val)
			: base (prototype)
		{
			value = val;
		}

		public override string GetClassName ()
		{
			return "boolean";
		}
	}
}
