using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
{
	// double linked list because of name so must have a node somewhere
	public class DList<ElementType, ParentType>
	{
		public DList ()
		{
		}

		private Node head;
		private Node tail;
		private ParentType parent;

		public void Append (ElementType Item)
		{
			Node newNode = new Node(Item);
			if (tail != null) {
				tail.Next = newNode;
				newNode.Previous = tail;
			}
			else
				head = newNode;

			tail = newNode;
		}

		public DList<ElementType, ParentType> Copy ()
		{
			DList<ElementType, ParentType> result = new DList<ElementType, ParentType> ();
			//while (ite)
			//result.Append(
			return null;
		}

		public ElementType Last ()
		{
			return tail.Data;
		}

		public ParentType Parent {
			get { return parent; }
			set { parent = value; }
		}

		public class Iterator
		{
			public Iterator (DList<ElementType, ParentType> DL)
			{
				current = DL.head;
				this.DL = DL;
			}

			private Node current;
			private DList<ElementType, ParentType> DL;

			public void Advance ()
			{
				if (current != null)
					current = current.Next;
			}

			public void Insert (ElementType Item)
			{
				Node newNode = new Node (Item);
				newNode.Next = current.Next;
				newNode.Previous = current;
				current.Next.Previous = newNode;
				current.Next = newNode;
				current = newNode;
			}

			public void Remove ()
			{
				if (current == null) {
					return;
				}

				if (current.Next == null && current.Previous == null) {
					current = null;
					DL.head = null;
					DL.tail = null;
				}
				if (current.Next != null) {//if not tail
					current.Next.Previous = current.Previous;
					current = current.Next;
				}
				else
					DL.tail = current.Previous;

				if (current.Previous != null) {//if not head
					current.Previous.Next = current.Next;
					current = current.Previous;
				}
				else
					DL.head = current.Next;
			}

			public ElementType Element {
				get { return current.Data; }
			}

			public bool ElementAvailable {
				get { return (current != null); }
			}

		}

		private class Node
		{
			public Node (ElementType Item)
			{
				data = Item;
			}

			private Node prev;
			private Node next;
			private ElementType data;

			public Node Previous {
				get { return prev; }
				set { prev = value; }
			}

			public Node Next {
				get { return next; }
				set { next = value; }
			}

			public ElementType Data
			{
				get { return data; }
				set { data = value; }
			}
		}
	}
}
