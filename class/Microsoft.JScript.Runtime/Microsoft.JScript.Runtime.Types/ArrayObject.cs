// ArrayObject.cs
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

namespace Microsoft.JScript.Runtime.Types {

	[Serializable]
	public class ArrayObject : JSObject, IAttributesCollection, ICustomMembers, IEnumerable,
		IEnumerable<KeyValuePair<object, object>> {

		internal ArrayObject ()
			: base (null)
		{
		}

		public override IDictionary<object, object> AsObjectKeyedDictionary ()
		{
			throw new NotImplementedException ();
		}

		public override bool DeleteItem (SymbolId name)
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

		public override IList<object> GetMemberNames (CodeContext context)
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

		public override object GetItem (object key)
		{
			throw new NotImplementedException ();
		}

		public object GetItem (long index)
		{
			throw new NotImplementedException ();
		}

		public override void SetItem (SymbolId name, object value)
		{
			throw new NotImplementedException ();
		}

		public void SetLength (object value)
		{
			throw new NotImplementedException ();
		}

		public override void SetItem (object key, object value)
		{
			throw new NotImplementedException ();
		}

		protected void SpliceSlowly (CodeContext context, uint start, uint deleteCount, object [] args,
					     JSArrayObject outArray, uint oldLength, uint newLength)
		{
			throw new NotImplementedException ();
		}

		public override bool TryGetItem (SymbolId name, out object value)
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
