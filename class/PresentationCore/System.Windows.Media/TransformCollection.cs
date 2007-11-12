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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace System.Windows.Media {

	public sealed class TransformCollection : Animatable, IList, ICollection, IList<Transform>, ICollection<Transform>, IEnumerable<Transform>, IEnumerable
	{
		public TransformCollection ()
		{
		}

		public TransformCollection (IEnumerable<Transform> collection)
		{
		}

		public TransformCollection (int capacity)
		{
		}

		public int Count {
			get { throw new NotImplementedException (); }
		}

		bool IList.IsFixedSize {
			get { throw new NotImplementedException (); }
		}

		bool IList.IsReadOnly {
			get { throw new NotImplementedException (); }
		}
		bool ICollection<Transform>.IsReadOnly {
			get { throw new NotImplementedException (); }
		}

		bool ICollection.IsSynchronized {
			get { throw new NotImplementedException (); }
		}

		object ICollection.SyncRoot {
			get { throw new NotImplementedException (); }
		}

		public Transform this[int index] {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		object IList.this[int index] {
			get { return this[index]; }
			set { this[index] = (Transform)value; }
		}

		public void Add (Transform value)
		{
			throw new NotImplementedException ();
		}
		int IList.Add (object value)
		{
			Add ((Transform)value);
			return Count;
		}

		public void Clear ()
		{
			throw new NotImplementedException ();
		}

		public new TransformCollection Clone ()
		{
			throw new NotImplementedException ();
		}

		protected override void CloneCore (Freezable source)
		{
			throw new NotImplementedException ();
		}

		public new TransformCollection CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override void CloneCurrentValueCore (Freezable source)
		{
			throw new NotImplementedException ();
		}

		public bool Contains (Transform value)
		{
			throw new NotImplementedException ();
		}
		bool IList.Contains (object value)
		{
			return Contains ((Transform) value);
		}

		public void CopyTo (Transform[] array, int index)
		{
			throw new NotImplementedException ();
		}
		void ICollection.CopyTo (Array array, int index)
		{
			CopyTo ((Transform[])array, index);
		}

		protected override Freezable CreateInstanceCore ()
		{
			throw new NotImplementedException ();
		}

		protected override bool FreezeCore (bool isChecking)
		{
			throw new NotImplementedException ();
		}

		protected override void GetAsFrozenCore (Freezable source)
		{
			throw new NotImplementedException ();
		}

		protected override void GetCurrentValueAsFrozenCore (Freezable source)
		{
			throw new NotImplementedException ();
		}

		public TransformCollection.Enumerator GetEnumerator ()
		{
			throw new NotImplementedException ();
		}
		IEnumerator<Transform> IEnumerable<Transform>.GetEnumerator()
		{
			return GetEnumerator ();
		}
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}

		public int IndexOf (Transform value)
		{
			throw new NotImplementedException ();
		}
		int IList.IndexOf (object value)
		{
			return IndexOf ((Transform)value);
		}

		public void Insert (int index, Transform value)
		{
			throw new NotImplementedException ();
		}
		void IList.Insert (int index, object value)
		{
			Insert (index, (Transform)value);
		}

		public void Remove (Transform value)
		{
			throw new NotImplementedException ();
		}
		void IList.Remove (object value)
		{
			Remove ((Transform)value);
		}
		bool ICollection<Transform>.Remove (Transform value)
		{
			Remove (value);
			return true;
		}

		public void RemoveAt (int index)
		{
			throw new NotImplementedException ();
		}

		public struct Enumerator : IEnumerator<Transform>, IDisposable, IEnumerator
		{
			public Transform Current {
				get { throw new NotImplementedException (); }
			}
			object IEnumerator.Current {
				get { return Current; }
			}
			public bool MoveNext ()
			{
				throw new NotImplementedException ();
			}

			public void Reset ()
			{
				throw new NotImplementedException ();
			}

			void IDisposable.Dispose ()
			{
			}
		}
	}
}
