using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public sealed class JSRegExpMatch : JSArrayObject {

		internal JSRegExpMatch ()
		{
		}

		public override bool DeleteItem (object key)
		{
			return base.DeleteItem (key);
		}

		public override object GetItem (object key)
		{
			return base.GetItem (key);
		}

		public override void SetItem (object key, object value)
		{
			base.SetItem (key, value);
		}

		public override bool TryGetItem (SymbolId name, out object value)
		{
			return base.TryGetItem (name, out value);
		}
	}
}
