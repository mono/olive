using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSArgumentsObject : JSObject {

		JSArgumentsObject ()
			: base (null)
		{
		}

		public static JSObject Create (CodeContext context, JSFunctionObject function, SymbolId [] paramIds, IAttributesCollection dict,
					       object [] actualParameters)
		{
			throw new NotImplementedException ();
		}

		public override bool DeleteItem (SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public override bool DeleteItem (object key)
		{
			throw new NotImplementedException ();
		}

		public override object GetItem (object key)
		{
			throw new NotImplementedException ();
		}

		public override void SetItem (SymbolId name, object value)
		{
			base.SetItem (name, value);
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
