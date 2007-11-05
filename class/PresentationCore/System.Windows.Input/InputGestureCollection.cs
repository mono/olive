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
// Copyright (c) 2007 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Chris Toshok (toshok@ximian.com)
//

using System;
using System.Collections;

namespace System.Windows.Input {

	public sealed class InputGestureCollection : IList, ICollection, IEnumerable
	{

		public InputGestureCollection ()
		{
		}

		public InputGestureCollection (IList inputGestures)
		{
		}

		public int Count {
			get { throw new NotImplementedException(); }
		}

		public bool IsFixedSize {
			get { throw new NotImplementedException(); }
		}

		public bool IsReadOnly {
			get { throw new NotImplementedException(); }
		}

		public bool IsSynchronized {
			get { throw new NotImplementedException(); }
		}

		public object SyncRoot {
			get { throw new NotImplementedException(); }
		}

		object IList.this[int index] {
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		public InputGesture this[int index] {
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		int IList.Add (object o)
		{
			throw new NotImplementedException ();
		}

		public int Add (InputGesture inputGesture)
		{
			return Add(inputGesture);
		}

		public void AddRange (ICollection collection)
		{
			throw new NotImplementedException();
		}

		public void Clear ()
		{
			throw new NotImplementedException();
		}

		bool IList.Contains (object o)
		{
			throw new NotImplementedException ();
		}

		public bool Contains (InputGesture key)
		{
			return Contains (key);
		}

		void ICollection.CopyTo (Array array, int index)
		{
			throw new NotImplementedException();
		}

		public void CopyTo (InputGesture[] inputGestures, int index)
		{
			throw new NotImplementedException();
		}

		public IEnumerator GetEnumerator ()
		{
			throw new NotImplementedException();
		}

		int IList.IndexOf (object o)
		{
			throw new NotImplementedException ();
		}

		public int IndexOf (InputGesture value)
		{
			return IndexOf (value);
		}

		void IList.Insert (int index, object o)
		{
			throw new NotImplementedException();
		}

		public void Insert (int index, InputGesture inputGesture)
		{
			Insert (index, inputGesture);
		}

		void IList.Remove (object o)
		{
			throw new NotImplementedException();
		}

		public void Remove (InputGesture inputGesture)
		{
			Remove (inputGesture);
		}

		public void RemoveAt (int index)
		{
			throw new NotImplementedException();
		}

		public void Seal()
		{
			throw new NotImplementedException();
		}
	}

}
