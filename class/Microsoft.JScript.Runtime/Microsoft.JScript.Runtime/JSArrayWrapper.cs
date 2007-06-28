using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSArrayWrapper : JSArrayObject {
		JSArrayWrapper ()
		{
		}

		public new Type GetType ()
		{
			throw new NotImplementedException ();
		}

		public override object GetValue (object key)
		{
			return base.GetValue  (key);
		}

		public override void SetCustomMember (CodeContext context, SymbolId name, object value)
		{
			base.SetCustomMember (context, name, value);
		}

		public override void SetValue (object key, object value)
		{
			base.SetValue (key, value);
		}

		public override object length {
			get { return base.length; }
		}
	}
}
