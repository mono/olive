using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting;
using IronPython.Runtime;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSObject : IAttributesCollection, ICustomMembers, IEnumerable, IEnumerable<KeyValuePair<object,object>>,
		IMapping, IPythonContainer {

		JSObject prototype;

		public JSObject (JSObject prototype)
		{
			this.prototype = prototype;
		}

		public void Add (SymbolId name, object value)
		{
			throw new NotImplementedException ();
		}

		public void AddObjectKey (object name, object value)
		{
			throw new NotImplementedException ();
		}

		public virtual IDictionary<object, object> AsObjectKeyedDictionary ()
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

		public bool ContainsValue (object value)
		{
			throw new NotImplementedException ();
		}

		public virtual bool DeleteCustomMember (CodeContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public virtual bool DeleteItem (object key)
		{
			throw new NotImplementedException ();
		}

		public IList<object> GetAllNames (CodeContext context)
		{
			throw new NotImplementedException ();
		}

		public virtual string GetClassName ()
		{
			throw new NotImplementedException ();
		}
		
		public virtual IDictionary<object, object> GetCustomMemberDictionary (CodeContext context)
		{
			throw new NotImplementedException ();
		}

		public virtual IList<object> GetCustomMemberNames (CodeContext context)
		{
			throw new NotImplementedException ();
		}

		public virtual IEnumerator<KeyValuePair<object, object>> GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		public int GetLength ()
		{
			throw new NotImplementedException ();
		}

		public virtual object GetValue (object key)
		{
			throw new NotImplementedException ();
		}

		public object GetValue (object key, object defaultValue)
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

		public virtual void SetCustomMember (CodeContext context, SymbolId name, object value)
		{
			throw new NotImplementedException ();
		}

		public virtual void SetValue (object key, object value)
		{
			throw new NotImplementedException ();
		}

		public virtual bool TryGetBoundCustomMember (CodeContext context, SymbolId name, out object value)
		{
			throw new NotImplementedException ();
		}

		public virtual bool TryGetCustomMember (CodeContext context, SymbolId name, out object value)
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

		public bool TryGetValue (object key, out object value)
		{
			throw new NotImplementedException ();
		}

		public virtual int Count {
			get { return 0; }
		}

		public virtual ICollection<object> Keys {
			get { return null; }
		}

		public virtual IDictionary<SymbolId, object> SymbolAttributes {
			get { return null; }
		}

		public object this [int index] {
			get { return null; }
			set { }
		}

		public object this [SymbolId name] {
			get { return null; }
			set { }
		}

		public object this [object key] {
			get { return null; }
			set { }
		}
	}
}
