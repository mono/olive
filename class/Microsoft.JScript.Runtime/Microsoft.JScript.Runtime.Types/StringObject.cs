using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSStringObject : JSObject {

		public JSStringObject (JSObject prototype, string val)
			: base (prototype)
		{
		}

		public override string GetClassName ()
		{
			return "string";
		}

		public override object GetItem (object key)
		{
			return base.GetItem (key);
		}

		public override bool TryGetItem (SymbolId name, out object value)
		{
			return base.TryGetItem (name, out value);
		}
	}
}
