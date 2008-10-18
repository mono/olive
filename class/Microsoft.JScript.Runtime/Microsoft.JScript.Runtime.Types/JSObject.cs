// JSObject.cs
//
// Authors:
//   Olivier Dufour <olivier.duff@gmail.com>
//
// Copyright (C) 2008 Olivier Dufour
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;
using System.Scripting.Actions;
using Microsoft.Scripting.Actions;

namespace Microsoft.JScript.Runtime.Types {

	[Serializable]
	public class JSObject : IAttributesCollection, IMembersList, IOldDynamicObject, IDynamicObject {
		
		internal JSObject prototype;
		private SymbolDictionary members;

		public JSObject (JSObject prototype)
		{
			this.prototype = prototype;
			members = new SymbolDictionary ();
		}

#region put
		void IAttributesCollection.Add (SymbolId name, object value)
		{
			SetItem (name, value);
		}

		public virtual void SetItem (SymbolId name, object value)
		{//ECMA 8.6.2.2 Put
			if (!CanSetItem (name))
				return;
			if (members.ContainsKey (name))
				members[name] = value;
			else
				members.Add (name, value);
		}

		public void AddObjectKey (object name, object value)
		{
			SetItem (ObjectToId (name), value);
		}

		private bool CanSetItem (SymbolId name) 
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
			return prototype.CanSetItem(name);
		}

		public virtual void SetItem (object key, object value)
		{
			SetCustomMember (null, ObjectToId (key), value);
		}

#endregion
#region get

		public virtual IList<object> GetMemberNames (CodeContext context)
		{
			List<object> result;
			if (prototype != null) {
				result = prototype.GetMemberNames (context);
			} else {
				result = new List<object> ();
			}
			foreach (object obj in members.Keys) {
				result.Add (obj);
			}
			return result;
		}

		public virtual object GetBoundItem (object name)
		{//TODO check here 
			return GetItem (name);
		}

		public virtual object GetItem (object name)
		{// inheritence with prototype is done inside TryGetItem
			object result = UnDefined.Value;
			if (TryGetItem (ObjectToId (name), out result))
				return result;
			return UnDefined.Value;
		}


		public virtual bool TryGetBoundItem (SymbolId name, out object value)
		{
			throw new NotImplementedException ();
		}

		public virtual bool TryGetItem (SymbolId name, out object value)
		{//ECMA 8.6.2.1 Get
			if (members.TryGetValue (name, out value))
				return true;
			if (prototype == null) {
				value = UnDefined.Value;
				return false;
			}
			return prototype.TryGetItem (context, name,out value);
		}

		public bool TryGetObjectValue (object name, out object value)
		{
			return TryGetItem (ObjectToId (name), out value);
		}

		public bool TryGetValue (SymbolId name, out object value)
		{
			return TryGetItem (name, out value);
		}

#endregion
		public virtual IDictionary<object, object> AsObjectKeyedDictionary ()
		{
			return members.AsObjectKeyedDictionary ();
		}
#region has property
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
#endregion
#region delete
		public virtual bool DeleteItem (SymbolId name)
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
			return DeleteItem (null, ObjectToId (key));
		}

		public bool Remove (SymbolId name)
		{
			return members.Remove (name);
		}

		public bool RemoveObjectKey (object name)
		{
			return Remove (ObjectToId (name));
		}

#endregion
		public IList<object> GetAllNames (CodeContext context)
		{
			List<object> result;
			if (prototype != null) {
				result = prototype.GetAllNames (context);
			} else {
				result = new List<object> ();
			}

			foreach (object obj in members.Keys) {
				result.Add (obj);//TODO check if need idToObject
			}
			return result;
		}

		public virtual string GetClassName ()
		{
			return "object";
		}
		

		public virtual RuleBuilder<T> GetRule <T> (OldDynamicAction action, CodeContext context, object [] args) where T : class
		{
			switch (action.Kind)
			{
				case DynamicActionKind.Call:
					return new CallBinderHelper<T> (context, (OldCallAction)action, args).MakeRule ();
				case DynamicActionKind.CreateInstance:
					return new CreateInstanceBinderHelper<T> (context, (OldCreateInstanceAction)action, args).MakeRule ();
				case DynamicActionKind.DeleteMember:
					return new DeleteMemberBinderHelper<T> (context, (OldDeleteMemberAction)action, args).MakeRule ();
				case DynamicActionKind.DoOperation:
					return new DoOperationBinderHelper<T> (context, (OldDoOperationAction)action, args).MakeRule ();
				case DynamicActionKind.GetMember:
					return new GetMemberBinderHelper<T> (context, (OldGetMemberAction)action, args).MakeRule ();
				case DynamicActionKind.SetMember:
					return new SetMemberBinderHelper<T> (context, (OldSetMemberAction)action, args).MakeRule ();
				default: 
					throw new NotImplementedException ();
			}
		}


		public virtual IEnumerator<KeyValuePair<object, object>> GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
//TODO custom enumerator to get all prototype members too
			return members.GetEnumerator ();
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

		private SymbolId ObjectToId (object key)
		{
			return SymbolTable.StringToId (key.ToString ());
		}

		public virtual int Count {
			get { return members.Count; }
		}

		public virtual ICollection<object> Keys {
			get {
				return members.Keys;
			}
		}

		public virtual IDictionary<SymbolId, object> SymbolAttributes {
			get { return null; }
		}

		public object this [SymbolId name] {
			get {
				return GetItem (name);
			}
			set {
				SetItem (name, value);				
			}
		}

		public object this [object key] {
			get { return GetItem (key); }
			set { SetItem (key, value); }
		}

		public virtual LanguageContext LanguageContext
		{
			get
			{
				return JSContext.GetContext (null);
			}
		}
	}
}
