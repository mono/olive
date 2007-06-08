using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Mono.JScript.Compiler
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
