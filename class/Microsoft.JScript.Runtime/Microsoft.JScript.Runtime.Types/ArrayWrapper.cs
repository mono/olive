using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSArrayWrapper : JSArrayObject {

		JSArrayWrapper ()
		{
		}

		public new Type GetType ()
		{
			throw new NotImplementedException ();
		}

		public override object GetItem (object key)
		{
			return base.GetItem  (key);
		}

		public override void SetItem (SymbolId name, object value)
		{
			base.SetItem (name, value);
		}

		public override void SetItem (object key, object value)
		{
			base.SetItem (key, value);
		}

		public override object length {
			get { return base.length; }
		}
	}
}
