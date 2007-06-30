//
// Microsoft.JScript.Compiler
//
// Author:
//   Olivier Dufour (olivier.duff@gmail.com)
//
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Microsoft.JScript.Compiler
{
	public class Table<KeyType, ValueType> where KeyType : IComparable<KeyType>
	{
		Node<KeyType, ValueType> root;

		public Table ()
		{
		}

		// FIXME: move changing root to rotations?
		public void Insert (KeyType Key, ValueType Value, bool OverwriteExistingEntry)
		{
			bool found;
			Node<KeyType, ValueType> node = lookup_node (Key, out found);

			if (found) {
				if (OverwriteExistingEntry)
					node.Value = Value;
				
				node.SplayToRoot ();
				root = node;
			} else {
				Node<KeyType, ValueType> newNode = new Node<KeyType, ValueType> (Key, Value);
				
				if (node == null) {
					root = newNode;
				} else {
					int cmp = Key.CompareTo (node.Key);

					if (cmp == -1)
						node.AddAsLeftChild (newNode);
					else //cmp == 1
						node.AddAsRightChild (newNode);

					newNode.SplayToRoot ();
					root = newNode;
				}
			}
		}

		public void InsertIfNotPresent (KeyType Key, ValueType Value)
		{
			Insert (Key, Value, false);
		}

		// FIXME: if key was not found splay last found node
		public ValueType Lookup (KeyType Key)
		{
			bool found;
			Node<KeyType, ValueType> node = lookup_node (Key, out found);

			if (node != null) {
				node.SplayToRoot ();
				root = node;
			}

			if (found)
				return node.Value;
			else
				return default (ValueType);
		}

		// if key is not found we return node that will be parent of the new node (it may be null)
		Node<KeyType, ValueType> lookup_node (KeyType key, out bool found)
		{
			found = false;

			Node<KeyType, ValueType> node = root;
			Node<KeyType, ValueType> parent = null;

			while (node != null) {
				int cmp = key.CompareTo (node.Key);
				if (cmp == -1) {
					parent = node;
					node = (Node<KeyType, ValueType>) node.Left;
				} else if (cmp == 1) {
					parent = node;
					node = (Node<KeyType, ValueType>) node.Right;
				} else {
					found = true;
					return node;
				}
			}

			return parent;
		}

	}

	class Node<KeyType, ValueType> : SplayTree {

		KeyType key;
		ValueType value;

		public Node (KeyType key, ValueType value)
		{
			this.key = key;
			this.value = value;
		}

		public KeyType Key {
			get { return key; }
		}

		public ValueType Value {
			get { return value; }
			set { this.@value = value; }
		}
	}
}
