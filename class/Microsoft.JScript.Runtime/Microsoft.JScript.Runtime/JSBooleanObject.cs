using System;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSBooleanObject : JSObject {
		
		bool value;

		public JSBooleanObject (JSObject prototype, bool val)
			: base (prototype)
		{
			value = val;
		}

		public override string GetClassName ()
		{
			throw new NotImplementedException ();
		}
	}
}
