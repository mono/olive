using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public sealed class JSRegExpMatch : JSArrayObject {

		internal JSRegExpMatch ()
		{
		}

		public override bool DeleteItem (object key)
		{
			return base.DeleteItem (key);
		}

		public override object GetValue (object key)
		{
			return base.GetValue (key);
		}

		public override void SetValue (object key, object value)
		{
			base.SetValue (key, value);
		}

		public override bool TryGetCustomMember (CodeContext context, SymbolId name, out object value)
		{
			return base.TryGetCustomMember (context, name, out value);
		}
	}
}
