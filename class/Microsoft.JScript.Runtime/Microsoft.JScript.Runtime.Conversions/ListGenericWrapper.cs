// ListGenericWrapper.cs
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

namespace Microsoft.JScript.Runtime.Conversions
{
    
    
    public class ListGenericWrapper<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
    {
        
	private IList<object> self;

	public ListGenericWrapper (IList<object> value)
	{
		this.self = value;
	}

	public void Add (T item)
	{
		self.Add (item);
	}

	public void Clear ()
	{
		self.Clear ();
	}

	public bool Contains (T item)
	{
		return self.Contains (item);
	}

	public void CopyTo (T[] array, int arrayIndex)
	{
		//TODO
		throw new NotImplementedException ();
	}

	public IEnumerator<T> GetEnumerator ()
	{
		return new IEnumeratorOfTWrapper<T> (self.GetEnumerator ());
	}

	public int IndexOf (T item)
	{
		return self.IndexOf (item);
	}

	public void Insert (int index, T item)
	{
		self.Insert (index, item);
	}

	public bool Remove (T item)
	{
		return self.Remove (item);
	}

	public void RemoveAt(int index)
	{
		self.RemoveAt (index);
	}

	IEnumerator IEnumerable.GetEnumerator ()
	{
		return self.GetEnumerator ();
	}


	public int Count { get {return self.Count;}}

	public bool IsReadOnly { get {return self.IsReadOnly;} }

	public T this [int index] 
	{ 
		get {return (T)self [index];} 
		set {self [index] = value;} 
	}

    }
}
