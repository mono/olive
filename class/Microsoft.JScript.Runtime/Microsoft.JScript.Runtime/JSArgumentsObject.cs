using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSArgumentsObject : JSObject {

		JSArgumentsObject ()
			: base (null)
		{
		}

		public static JSObject Create (CodeContext context, SymbolId [] paramIds, IAttributesCollection dict,
					       object [] actualParameters)
		{
			throw new NotImplementedException ();
		}

		public override bool DeleteCustomMember (CodeContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public override bool DeleteItem (object key)
		{
			throw new NotImplementedException ();
		}

		public override object GetValue (object key)
		{
			throw new NotImplementedException ();
		}

		public override void SetCustomMember (CodeContext context, SymbolId name, object value)
		{
			base.SetCustomMember (context, name, value);
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
