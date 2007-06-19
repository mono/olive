//
// Collection.cs: provides a wrapper to the unmanaged collection class
//
// Author:
//   Miguel de Icaza (miguel@novell.com)
//
// Copyright 2007 Novell, Inc.
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
using Mono;
using System;
using System.Windows;
using System.Collections;

namespace MS.Internal {
	//
	// It seems that this only works for DependencyObjects, but its not in 
	// the public contract
	//
	public abstract class Collection<T> : DependencyObject {
		public Collection () : base (NativeMethods.collection_new ())
		{
			NativeMethods.base_ref (native);
			//
			// We really need to revisit native collections, should
			// they all be Collection *, instead of Collection fields?
			//
			// If we keep them as Collection fields, when we "new" one,
			// the "new" versions should be immediately dispossed once
			// we do a 'set' operation (which should be a bitwise copy).
			//
		}
		
		internal Collection (IntPtr raw) : base (raw)
		{
		}
		
		public void Add (T value)
		{
			DependencyObject dob = value as DependencyObject;
			if (dob != null)
				NativeMethods.collection_add (native, dob.native);
			else
				throw new Exception ("The collection only supports DependencyObjects");
		}

		public void Remove (T value)
		{
			DependencyObject dob = value as DependencyObject;
			if (dob != null)
				NativeMethods.collection_remove (native, dob.native);
			else
				throw new Exception ("The collection only supports DependencyObjects");
		}

		public void Clear ()
		{
			NativeMethods.collection_clear (native);
		}

		public void Insert (int index, T value)
		{
			DependencyObject dob = value as DependencyObject;
			if (dob != null)
				NativeMethods.collection_insert (native, index, dob.native);
			else
				throw new Exception ("The collection only supports DependencyObjects");
		}
		
		protected internal override Kind GetKind ()
		{
			return Kind.COLLECTION;
		}

		public class CollectionIterator : IEnumerator {
			IntPtr native_iter;
			Kind   kind;
			
			public CollectionIterator(IntPtr native_iter, Kind k)
			{
				this.native_iter = native_iter;
				kind = k;
			}
			
			public bool MoveNext ()
			{
				return NativeMethods.collection_iterator_move_next (native_iter);
			}
			
			public void Reset ()
			{
				NativeMethods.collection_iterator_reset (native_iter);
			}

			public object Current {
				get {
					IntPtr o = NativeMethods.collection_iterator_get_current (native_iter);

					if (o == IntPtr.Zero)
						return null;

					return DependencyObject.Lookup (kind, o);
				}
			}

			~CollectionIterator ()
			{
				// This is safe, as it only does a "delete" in the C++ side
				NativeMethods.collection_iterator_destroy (native_iter);
			}
		}
		
		public IEnumerator GetEnumerator ()
		{
			return new CollectionIterator (NativeMethods.collection_get_iterator (native),
						       NativeMethods.collection_get_element_type (native));
		}
	}
}
