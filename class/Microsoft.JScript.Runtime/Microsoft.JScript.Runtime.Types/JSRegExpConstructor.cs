using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSRegExpConstructor : JSFunctionObject {

		public JSRegExpConstructor (CodeContext context)
			: base (context, null, null, false)
		{
		}

		public static object call (CodeContext context, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static new object construct (CodeContext context, object self, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static object Construct (CodeContext context, string pattern, bool ignoreCase, bool global, bool multiline)
		{
			throw new NotImplementedException ();
		}

		public static JSRegExpObject CreateInstance (CodeContext context, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static JSRegExpObject Invoke (CodeContext context, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public override void SetItem (SymbolId name, object value)
		{
			base.SetItem (name, value);
		}

		public override bool TryGetItem (SymbolId name, out object value)
		{
			return base.TryGetItem (name, out value);
		}

		public object index {
			get { throw new NotImplementedException (); }
		}

		public object input {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public object lastIndex {
			get { throw new NotImplementedException (); }
		}

		public object lastMatch {
			get { throw new NotImplementedException (); }
		}

		public object lastParen {
			get { throw new NotImplementedException (); }
		}

		public object leftContext {
			get { throw new NotImplementedException (); }
		}

		public object rightContext {
			get { throw new NotImplementedException (); }
		}
	}
}
