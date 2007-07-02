using System;
using Microsoft.Scripting;
using IronPython.Runtime.Types;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSStringObject : JSObject {

		public JSStringObject (JSObject prototype, string val)
			: base (prototype)
		{
		}

		public override string GetClassName ()
		{
			return base.GetClassName ();
		}

		public override object GetValue (object key)
		{
			return base.GetValue (key);
		}

		public override bool TryGetCustomMember (CodeContext context, SymbolId name, out object value)
		{
			return base.TryGetCustomMember (context, name, out value);
		}
	}
}
