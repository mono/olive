using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSNumberObject : JSObject, IAttributesCollection, ICustomMembers, IEnumerable,
		IEnumerable<KeyValuePair<object, object>> {

		public JSNumberObject (JSObject prototype, double val)
			: base (prototype)
		{
		}

		public override string GetClassName ()
		{
			throw new NotImplementedException ();
		}
	}
}
