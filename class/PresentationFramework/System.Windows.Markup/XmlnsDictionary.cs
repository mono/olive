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
// Copyright (c) 2008 Novell, Inc. (http://www.novell.com)
//

using System;
using System.Collections;
using System.Xml;

namespace System.Windows.Markup {

	public class XmlnsDictionary : IEnumerable, IDictionary, ICollection
	{

		public XmlnsDictionary (XmlnsDictionary dict)
		{
		}

		public XmlnsDictionary ()
		{
		}

		public string DefaultNamespace ()
		{
			throw new NotImplementedException ();
		}

		public void PushScope ()
		{
			throw new NotImplementedException ();
		}

		public void PopScope ()
		{
			throw new NotImplementedException ();
		}

		public void Seal ()
		{
			throw new NotImplementedException ();
		}

		public void Add (object prefix, object xmlNamespace)
		{
			throw new NotImplementedException ();
		}

		public void Add (string prefix, string xmlNamespace)
		{
			throw new NotImplementedException ();
		}

		public void Clear ()
		{
			throw new NotImplementedException ();
		}

		public void Remove (object prefix)
		{
			throw new NotImplementedException ();
		}

		public void Remove (string prefix)
		{
		}

		public void CopyTo (Array array, int index)
		{
			throw new NotImplementedException ();
		}

		public void CopyTo (DictionaryEntry[] array, int index)
		{
			throw new NotImplementedException ();
		}

		public bool Contains (object value)
		{
			throw new NotImplementedException ();
		}

		protected IDictionaryEnumerator GetDictionaryEnumerator ()
		{
			throw new NotImplementedException ();
		}

		protected IEnumerator GetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		public string LookupNamespace (string xmlns)
		{
			throw new NotImplementedException ();
		}

		public string LookupPrefix (string xmlNamespace)
		{
			throw new NotImplementedException ();
		}

		public bool IsFixedSize {
			get { throw new NotImplementedException (); }
		}

		public bool IsReadOnly {
			get { throw new NotImplementedException (); }
		}

		public object this [object prefix] {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public string this [string prefix] {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public bool Sealed {
			get { throw new NotImplementedException (); }
		}

		public ICollection Keys {
			get { throw new NotImplementedException (); }
		}

		public ICollection Values {
			get { throw new NotImplementedException (); }
		}

		public int Count {
			get { throw new NotImplementedException (); }
		}

		public bool IsSynchronized {
			get { throw new NotImplementedException (); }
		}

		public object SyncRoot {
			get { throw new NotImplementedException (); }
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator();
		}

		IDictionaryEnumerator IDictionary.GetEnumerator ()
		{
			return GetDictionaryEnumerator();
		}
	}
}