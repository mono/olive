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

namespace MS.Internal {
	//
	// It seems that this only works for DependencyObjects, but its not in 
	// the public contract
	//
	public abstract class Collection<T> : DependencyObject {
		public Collection () : base (NativeMethods.collection_new ())
		{
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
		
		public void Add (T t)
		{
			DependencyObject dob = t as DependencyObject;
			if (dob != null)
				NativeMethods.collection_add (native, dob.native);
			else
				throw new Exception ("The collection only supports DependencyObjects");
		}

		public void Remove (T t)
		{
			DependencyObject dob = t as DependencyObject;
			if (dob != null)
				NativeMethods.collection_remove (native, dob.native);
			else
				throw new Exception ("The collection only supports DependencyObjects");
		}
		
		protected internal override Kind GetKind ()
		{
			return Kind.COLLECTION;
		}
	}
}
