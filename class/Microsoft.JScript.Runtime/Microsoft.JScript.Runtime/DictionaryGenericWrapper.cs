// ConcatString.cs
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

namespace Microsoft.JScript.Runtime
{
    
    
    public class DictionaryGenericWrapper<K, V> : IDictionary<K, V>
    {
        
	private IDictionary<object, object> self;
        public DictionaryGenericWrapper (IDictionary<object, object> self)
        {
		this.self = self;
        }

	public void Add (KeyValuePair<K, V> item)
	{
		self.Add (new KeyValuePair<object, object> (item.Key, item.Value));
	}

	public void Add (K key, V value)
	{
		self.Add (key, value);
	}

	public void Clear()
	{
		self.Clear ();
	}

	public bool Contains (KeyValuePair<K, V> item)
	{
		return self.Contains (new KeyValuePair<object, object> (item.Key, item.Value));
	}

	public bool ContainsKey (K key)
	{
		return self.ContainsKey (key);
	}

	public void CopyTo (KeyValuePair<K, V>[] array, int arrayIndex)
	{
		//TODO
		throw new NotImplementedException ();
	}

	public IEnumerator<KeyValuePair<K, V>> GetEnumerator ()
	{
		//TODO made an internal enumerator class
		//return self.GetEnumerator ();
		throw new NotImplementedException ();
	}

	public bool Remove (K key)
	{
		return self.Remove (key);
	}

	public bool Remove (KeyValuePair<K, V> item)
	{
		return self.Remove (new KeyValuePair<object, object> (item.Key, item.Value));
	}

	IEnumerator IEnumerable.GetEnumerator ()
	{
		return self.GetEnumerator ();
	}

	public bool TryGetValue (K key, out V value)
	{
		object o = null;
		if (self.TryGetValue (key, out o))
		{
			value = (V)o;
			return true;
		}
		value = default(V);
		return false;
	}
	
	public int Count { get {return self.Count;}}
	
	public bool IsReadOnly { get {return self.IsReadOnly;} }
	public V this [K key] 
	{ 
		get {return (V)self [key];} 
		set {self [key] = value;} 
	}

	public ICollection<K> Keys 
	{ 
		get
		{
			List<K> result = new List<K> (self.Count);
			foreach (object o in self.Keys)
				result.Add ((K)o);
			return result;
		}
	}

	public ICollection<V> Values
	{ 
		get
		{
			List<V> result = new List<V> (self.Count);
			foreach (object o in self.Values)
				result.Add ((V)o);
			return result;
		}
	}

    }
}
