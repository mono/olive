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
// Author:
//	Chris Toshok (toshok@ximian.com)
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media.Animation;

namespace System.Windows.Media {


	public class VisualCollection : ICollection, IEnumerable
	{
		public struct Enumerator : IEnumerator
		{
			public void Reset()
			{
				throw new NotImplementedException (); 
			}

			public bool MoveNext()
			{
				throw new NotImplementedException (); 
			}

			public Visual Current {
				get { throw new NotImplementedException (); }
			}

			object IEnumerator.Current {
				get { return Current; }
			}
		}

		public VisualCollection (Visual parentVisual)
		{
		}

		public bool Contains (Visual value)
		{
			throw new NotImplementedException ();
		}

		public int IndexOf (Visual value)
		{
			throw new NotImplementedException ();
		}

		public int Add (Visual value)
		{
			throw new NotImplementedException ();
		}

		public void Clear ()
		{
			throw new NotImplementedException ();
		}

		public void CopyTo (Visual[] array, int offset)
		{
			throw new NotImplementedException ();
		}

		public void Insert (int index, Visual value)
		{
			throw new NotImplementedException ();
		}

		public void Remove (Visual child)
		{
			throw new NotImplementedException ();
		}

		public void RemoveAt (int index)
		{
			throw new NotImplementedException ();
		}

		public void RemoveRange (int a, int b)
		{
			throw new NotImplementedException ();
		}

		public int Count {
			get { throw new NotImplementedException (); }
		}

		public Visual this[int index] {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}

		public void CopyTo(Array array, int offset)
		{
			CopyTo ((Visual[]) array, offset);
		}

		public bool IsReadOnly {
			get { return false; }
		}

		public bool IsSynchronized {
			get { return false; }
		}

		public object SyncRoot {
			get { return this; }
		}

		public int Capacity {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}
	}
}
