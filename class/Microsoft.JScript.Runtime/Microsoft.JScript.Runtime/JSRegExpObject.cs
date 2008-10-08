using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public sealed class JSRegExpObject : JSObject {

		bool _global;
		bool _ignore_case;
		object _last_index;
		bool _multiline;
		string _source;

		JSRegExpObject ()
			: base (null)
		{
		}


		public override void SetItem (SymbolId name, object value)
		{
			base.SetItem (name, value);
		}

		public override bool TryGetItem (SymbolId name, out object value)
		{
			return base.TryGetItem (name, out value);
		}

		public override string GetClassName ()
		{
			return base.GetClassName ();
		}

		public override string ToString ()
		{
			return base.ToString ();
		}

		public bool global {
			get { return _global; }
		}

		public bool ignoreCase {
			get { return _ignore_case; }
		}

		public object lastIndex {
			get { return _last_index; }
			set { _last_index = value; }
		}

		public bool multiline {
			get { return _multiline; }
		}

		public string source {
			get { return _source; }
		}
	}
}
