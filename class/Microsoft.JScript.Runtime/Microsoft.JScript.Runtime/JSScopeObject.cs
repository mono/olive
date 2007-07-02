using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSScopeObject : IEnumerable<KeyValuePair<object, object>>, IEnumerable, IAttributesCollection {

		public JSScopeObject (object instance)
		{
		}

		public void Add (SymbolId name, object value)
		{
			throw new NotImplementedException ();
		}

		public void AddObjectKey (object name, object value)
		{
			throw new NotImplementedException ();
		}

		public IDictionary<object, object> AsObjectKeyedDictionary ()
		{
			throw new NotImplementedException ();
		}

		public bool ContainsKey (SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public bool ContainsObjectKey (object name)
		{
			throw new NotImplementedException ();
		}

		public IEnumerator<KeyValuePair<object, object>> GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		public bool Remove (SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public bool RemoveObjectKey (object name)
		{
			throw new NotImplementedException ();
		}

		public bool TryGetObjectValue (object name, out object value)
		{
			throw new NotImplementedException ();
		}

		public bool TryGetValue (SymbolId name, out object value)
		{
			throw new NotImplementedException ();
		}

		public int Count {
			get { throw new NotImplementedException (); }
		}

		public IAttributesCollection Instance {
			get { throw new NotImplementedException (); }
		}

		public ICollection<object> Keys {
			get { throw new NotImplementedException (); }
		}

		public IDictionary<SymbolId, object> SymbolAttributes {
			get { throw new NotImplementedException (); }
		}

		public object this [SymbolId name] {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}
	}
}
