using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting;
using IronPython.Runtime;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSArrayObject : JSObject, IAttributesCollection, ICustomMembers, IEnumerable,
		IEnumerable<KeyValuePair<object, object>>, IMapping, IPythonContainer {

		internal JSArrayObject ()
			: base (null)
		{
		}

		public override IDictionary<object, object> AsObjectKeyedDictionary ()
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

		public override string GetClassName ()
		{
			throw new NotImplementedException ();
		}

		public override IDictionary<object, object> GetCustomMemberDictionary (CodeContext context)
		{
			throw new NotImplementedException ();
		}

		public override IList<object> GetCustomMemberNames (CodeContext context)
		{
			throw new NotImplementedException ();
		}

		public override IEnumerator<KeyValuePair<object, object>> GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		public override object GetValue (object key)
		{
			throw new NotImplementedException ();
		}

		public override void SetCustomMember (CodeContext context, SymbolId name, object value)
		{
			throw new NotImplementedException ();
		}

		public void SetLength (CodeContext context, object value)
		{
			throw new NotImplementedException ();
		}

		public override void SetValue (object key, object value)
		{
			throw new NotImplementedException ();
		}

		protected void SpliceSlowly (CodeContext context, uint start, uint deleteCount, object [] args,
					     JSArrayObject outArray, uint oldLength, uint newLength)
		{
			throw new NotImplementedException ();
		}

		public override bool TryGetCustomMember (CodeContext context, SymbolId name, out object value)
		{
			throw new NotImplementedException ();
		}

		public override int Count {
			get { throw new NotImplementedException (); }
		}

		public override ICollection<object> Keys {
			get { throw new NotImplementedException (); }
		}

		public virtual object length {
			get { throw new NotImplementedException (); }
		}
	}
}
