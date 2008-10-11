// JSBoundFunctionObject.cs
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
using Microsoft.Scripting;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Scripting.Actions;

namespace Microsoft.JScript.Runtime
{
	
	
	public class JSBoundFunctionObject : IAttributesCollection, IConstructorWithCodeContext, ICustomMembers, IDynamicObject
	{
		private readonly JSFunctionObject _function;
		private readonly JSObject _instance;

		public JSBoundFunctionObject(JSFunctionObject function, JSObject instance)
		{
			_function = function;
			_instance = instance;
		}

		public void AddObjectKey(object name, object value)
		{
			throw new NotImplementedException ();
		}


		public IDictionary<object, object>  AsObjectKeyedDictionary ()
		{
			throw new NotImplementedException ();
		}


		public object Call(CodeContext context, object[] args)
		{
			throw new NotImplementedException ();
		}


		public object Call(CodeContext context, object instance, object[] args)
		{
			throw new NotImplementedException ();
		}


		public object Construct(CodeContext context,  params object[] args)
		{
			throw new NotImplementedException ();
		}


		public bool ContainsKey(SymbolId name)
		{
			throw new NotImplementedException ();
		}


		public bool ContainsObjectKey(object name)
		{
			throw new NotImplementedException ();
		}


		public bool DeleteCustomMember(CodeContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}


		public bool DeleteItem(SymbolId name)
		{
			throw new NotImplementedException ();
		}


		public virtual bool DeleteItem(object name)
		{
			throw new NotImplementedException ();
		}


		public object GetBoundItem(object name)
		{
			throw new NotImplementedException ();
		}


		public IDictionary<object, object>  GetCustomMemberDictionary(CodeContext context)
		{
			throw new NotImplementedException ();
		}


		public IEnumerator<KeyValuePair<object, object>>  GetEnumerator ()
		{
			throw new NotImplementedException ();
		}


		public object GetItem(object name)
		{
			throw new NotImplementedException ();
		}


		public IList<object>  GetMemberNames(CodeContext context)
		{
			throw new NotImplementedException ();
		}


		public StandardRule<T>  GetRule<T >(DynamicAction action, CodeContext context, object[] args)
		{
			throw new NotImplementedException ();
		}


	   	void IAttributesCollection.Add(SymbolId name, object value)
		{
			throw new NotImplementedException ();
		}


		public bool Remove(SymbolId name)
		{
			throw new NotImplementedException ();
		}


		public bool RemoveObjectKey(object name)
		{
			throw new NotImplementedException ();
		}


		public void SetCustomMember(CodeContext context, SymbolId name, object value)
		{
			throw new NotImplementedException ();
		}


		public void SetItem(SymbolId name, object value)
		{
			throw new NotImplementedException ();
		}


		public void SetItem(object key, object value)
		{
			throw new NotImplementedException ();
		}


	   	IEnumerator IEnumerable.GetEnumerator ()
		{
			throw new NotImplementedException ();
		}


		public bool TryGetBoundCustomMember(CodeContext context, SymbolId name,  out object value)
		{
			throw new NotImplementedException ();
		}


		public bool TryGetBoundItem(SymbolId name,  out object value)
		{
			throw new NotImplementedException ();
		}


		public bool TryGetCustomMember(CodeContext context, SymbolId name,  out object value)
		{
			throw new NotImplementedException ();
		}


		public bool TryGetItem(SymbolId name,  out object value)
		{
			throw new NotImplementedException ();
		}


		public bool TryGetObjectValue(object name,  out object value)
		{
			throw new NotImplementedException ();
		}


		public bool TryGetValue(SymbolId name,  out object value)
		{
			throw new NotImplementedException ();
		}


		public ConstructTargetN ConstructTarget  { get { throw new NotImplementedException (); } }

		public CodeContext Context  {  get { throw new NotImplementedException (); } }

		public int Count  {  get { throw new NotImplementedException (); } }

		public JSFunctionObject Function  {  get { return _function; } }

		public JSObject Instance  {  get { return _instance; } }

		public object this[SymbolId name] {  get { throw new NotImplementedException (); }  set { throw new NotImplementedException (); } }

		public ICollection<object>  Keys  {  get { throw new NotImplementedException (); } }

		public LanguageContext LanguageContext  {  get { throw new NotImplementedException (); } }

		public int Length  {  get { throw new NotImplementedException (); } }

		public IDictionary<SymbolId, object>  SymbolAttributes  {  get { throw new NotImplementedException (); } }

		public Delegate Target  {  get { throw new NotImplementedException (); } }

		public bool UsesArguments  {  get { throw new NotImplementedException (); } }
	}
}
