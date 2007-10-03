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
		
		internal JSObject prototype;
		private Dictionary<SymbolId, object> members;

		public JSObject (JSObject prototype)
		{
			this.prototype = prototype;
			members = new Dictionary<SymbolId, object> ();
		}

		public void Add (SymbolId name, object value)
		{
			members.Add (name, value);
		}

		public void AddObjectKey (object name, object value)
		{
			members.Add (ObjectToId (name), value);
		}

		public virtual IDictionary<object, object> AsObjectKeyedDictionary ()
		{//TODO test if must include inheritence with prototype?
			Dictionary<object, object> result = new Dictionary<object, object> ();
			foreach (KeyValuePair<SymbolId, object> k in members)
				result.Add (SymbolTable.IdToString (k.Key), k.Value);
			return result;
		}

		public bool ContainsKey (SymbolId name)
		{//ECAM 8.6.2.4 HasProperty
			if (members.ContainsKey (name))
				return true;
			if (prototype == null)
				return false;
			return prototype.ContainsKey (name);
		}

		public bool ContainsObjectKey (object name)
		{
			return ContainsKey (ObjectToId (name));
		}

		public bool ContainsValue (object value)
		{
			if (members.ContainsValue (value))
				return true;
			if (prototype == null)
				return false;
			return prototype.ContainsValue (value);
		}

		public virtual bool DeleteCustomMember (CodeContext context, SymbolId name)
		{//8.6.2.5 Delete
			if (!members.ContainsKey (name))
				return true;
			if (members[name] is JSAttributedProperty) {
				if (((JSAttributedProperty)members[name]).IsDontDelete)
					return false;
			}
			return members.Remove (name);
		}

		public virtual bool DeleteItem (object key)
		{
			return DeleteCustomMember (null, ObjectToId (key));
		}

		public IList<object> GetAllNames (CodeContext context)
		{
			List<object> result = new List<object> ();
			foreach (object obj in members.Keys) {
				result.Add (obj);
			}
			return result;
		}

		public virtual string GetClassName ()
		{
			return "object";
		}
		
		public virtual IDictionary<object, object> GetCustomMemberDictionary (CodeContext context)
		{
			IDictionary<object, object> result;
			//inheritence
			if (prototype != null) {
				result = prototype.GetCustomMemberDictionary (context);
			} else {
				result = new Dictionary<object, object> ();
			}
			//local
			foreach (KeyValuePair<SymbolId, object> k in members)
				result.Add (SymbolTable.IdToString(k.Key), k.Value);

			return result;
		}

		public virtual IList<object> GetCustomMemberNames (CodeContext context)
		{
			List<object> result = new List<object> ();
			foreach (object obj in members.Keys) {
				result.Add (obj);
			}
			return result;
		}

		public virtual IEnumerator<KeyValuePair<object, object>> GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return members.GetEnumerator ();
		}

		public int GetLength ()
		{
			return members.Count;
		}

		public virtual object GetValue (object key)
		{
			return GetValue (key, null);
		}

		public object GetValue (object key, object defaultValue)
		{// inheritence with prototype is done inside TryGetCustomMember
			object result;
			if (TryGetCustomMember (null, ObjectToId (key), out result))
				return result;
			return UnDefined.Value;
		}

		internal object GetDefaultValue (CodeContext context, TypeCode hint)
		{//ECAM 8.6.2.6 DefaultValue
			object obj;
			object result;
			if (hint == TypeCode.String || this is JSDateObject) {
				if (this.TryGetCustomMember (null, ObjectToId ("toString"), out obj)) {
					if (obj is JSFunctionObject) {
						//call is with instance= this and arguement list empty
						result = ((JSFunctionObject)obj).Call (context, this, new Object[] { });
						if (result == null)
							return result;
						//TODO check if primitive and return result if primitive
					}
				}
				if (this.TryGetCustomMember (null, ObjectToId ("valueOf"), out obj)) {
					if (obj is JSFunctionObject) {
						//call is with instance= this and arguement list empty
						result = ((JSFunctionObject)obj).Call (context, this, new Object[] { });
						if (result == null)
							return result;
						//TODO check if primitive and return result if primitive
					}
				}
			}
			else {//number and other hint
				if (this.TryGetCustomMember (null, ObjectToId ("valueOf"), out obj)) {
					if (obj is JSFunctionObject) {
						//call is with instance= this and arguement list empty
						result = ((JSFunctionObject)obj).Call (context, this, new Object[] { });
						if (result == null)
							return result;
						//TODO check if primitive and return result if primitive
					}
				}
				if (this.TryGetCustomMember (null, ObjectToId ("toString"), out obj)) {
					if (obj is JSFunctionObject) {
						//call is with instance= this and arguement list empty
						result = ((JSFunctionObject)obj).Call (context, this, new Object[] { });
						if (result == null)
							return result;
						//TODO check if primitive and return result if primitive
					}
				}
			}
			throw new TypeErrorException ();
		}

		public bool Remove (SymbolId name)
		{
			return members.Remove (name);
		}

		public bool RemoveObjectKey (object name)
		{
			return Remove (ObjectToId (name));
		}

		private SymbolId ObjectToId (object key)
		{
			return SymbolTable.StringToId (key.ToString ());
		}

		public virtual void SetCustomMember (CodeContext context, SymbolId name, object value)
		{//ECMA 8.6.2.2 Put
			if (!CanSetCustomMember (name))
				return;
			if (members.ContainsKey (name))
				members[name] = value;
			else
				members.Add (name, value);
		}

		private bool CanSetCustomMember (SymbolId name) 
		{//ECMA 8.6.2.3 CanPut
			object obj;
			if (members.TryGetValue (name,out obj)) {
				if ( obj is JSAttributedProperty) {
					return !((JSAttributedProperty)obj).IsReadOnly;
				}
				return true;
			}
			if (prototype == null)
				return true;
			return prototype.CanSetCustomMember(name);
		}

		public virtual void SetValue (object key, object value)
		{
			SetCustomMember (null, ObjectToId (key), value);
		}

		public virtual bool TryGetBoundCustomMember (CodeContext context, SymbolId name, out object value)
		{
			throw new NotImplementedException ();
		}

		public virtual bool TryGetCustomMember (CodeContext context, SymbolId name, out object value)
		{//ECMA 8.6.2.1 Get
			if (members.TryGetValue (name, out value))
				return true;
			if (prototype == null) {
				value = UnDefined.Value;
				return false;
			}
			return prototype.TryGetCustomMember (context, name,out value);
		}

		public bool TryGetObjectValue (object name, out object value)
		{
			return TryGetCustomMember (null, ObjectToId (name), out value);
		}

		public bool TryGetValue (SymbolId name, out object value)
		{
			return TryGetCustomMember (null, name, out value);
		}

		public bool TryGetValue (object key, out object value)
		{
			return TryGetCustomMember (null, ObjectToId (key), out value);
		}

		public virtual int Count {
			get { return members.Count; }
		}

		public virtual ICollection<object> Keys {
			get {
				ICollection<object> result = new List<object> ();
				foreach (KeyValuePair<SymbolId, object> k in members)
					result.Add (SymbolTable.IdToString (k.Key));
				return result;
			}
		}

		public virtual IDictionary<SymbolId, object> SymbolAttributes {
			get { return null; }
		}

		//TODO : quick hack here
		public object this [int index] {
			get {
				Dictionary<SymbolId, object>.Enumerator en = members.GetEnumerator ();
				for (int i = 0; i < Math.Max(index,members.Count); i++)
					en.MoveNext ();
				return en.Current.Value;		
			}
			set {
				Dictionary<SymbolId, object>.Enumerator en = members.GetEnumerator ();
				for (int i = 0; i < Math.Max (index, members.Count); i++)
					en.MoveNext ();
				members[en.Current.Key] = value;				
			}
		}

		public object this [SymbolId name] {
			get { return members[name]; }
			set { members[name] = value;}
		}

		public object this [object key] {
			get { return this[ObjectToId (key)]; }
			set { this[ObjectToId (key)] = value; }
		}
	}
}
