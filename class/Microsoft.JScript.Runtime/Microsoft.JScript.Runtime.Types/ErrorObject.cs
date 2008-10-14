using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSErrorObject : JSObject {

		internal JSErrorObject ()
			: base (null)
		{
		}

		public override string GetClassName ()
		{
			return base.GetClassName ();
		}
	}
}
