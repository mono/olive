using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSErrorObject : JSObject {

		JSErrorObject ()
			: base (null)
		{
		}

		public override string GetClassName ()
		{
			return base.GetClassName ();
		}
	}
}
