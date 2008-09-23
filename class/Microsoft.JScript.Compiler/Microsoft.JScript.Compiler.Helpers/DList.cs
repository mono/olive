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

namespace Microsoft.JScript.Compiler
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
			Node newNode = new Node (Item);
			if (tail != null) {
				tail.Next = newNode;
				newNode.Previous = tail;
			} else {
				head = newNode;
			}

			tail = newNode;
		}

		// FIXME: test it
		public DList<ElementType, ParentType> Copy ()
		{
			DList<ElementType, ParentType> result = new DList<ElementType, ParentType> ();
			DList<ElementType, ParentType>.Iterator insert_it = new DList<ElementType, ParentType>.Iterator (this);
			DList<ElementType, ParentType>.Iterator enum_it = new DList<ElementType, ParentType>.Iterator (result);

			while (true) {
				enum_it.Advance ();
				if (!enum_it.ElementAvailable)
					break;

				insert_it.Insert (enum_it.Element);
			}

			return result;

		}

		// FIXME: null tail
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
			
			public bool AtLast {
				get { return (current.Next == null); }
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
