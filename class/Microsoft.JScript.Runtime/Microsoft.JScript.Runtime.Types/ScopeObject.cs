// ScopeObject.cs
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
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime.Types {

	public class ScopeObject : IEnumerable<KeyValuePair<object, object>>, IEnumerable, IAttributesCollection {

		public ScopeObject (object instance)
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
