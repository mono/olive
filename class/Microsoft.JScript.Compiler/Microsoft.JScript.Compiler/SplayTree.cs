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

namespace Microsoft.JScript.Compiler {
	public class SplayTree {

		private SplayTree left;
		private SplayTree right;
		private SplayTree parent;

		public SplayTree ()
		{
		}

		public void AddAsLeftChild (SplayTree Child)
		{
			this.Left = Child;
			Child.Parent = this;
		}

		public void AddAsRightChild (SplayTree Child)
		{
			this.Right = Child;
			Child.Parent = this;
		}

		public void SplayToRoot ()
		{
			SplayTree x = this;

			while (x.Parent != null) {
				if (x.HasGrandParent) {
					if (SameDirection (x))
						x = ZigZig (x);
					else
						x = ZigZag (x);
				} else if (x.HasParent) {
					x = Zig (x);
				}
			}
		}

		public static void Validate ()
		{
			throw new NotImplementedException ();
		}

		// assumption: x.Parent != null
		SplayTree Zig (SplayTree x)
		{
			if (x.Parent.Left == x)
				return RightRotate (x.Parent);
			else
				return LeftRotate (x.Parent);
		}

		// assumption: x != null && x.Parent != null && x.GrandParent != null
		SplayTree ZigZig (SplayTree x)
		{
			if (x.Parent.Left == x) {
				RightRotate (x.GrandParent);
				x = RightRotate (x.Parent);
			} else {
				LeftRotate (x.GrandParent);
				x = LeftRotate (x.Parent);
			}
			return x;
		}

		// assumption: x != null && x.Parent != null && x.GrandParent != null
		SplayTree ZigZag (SplayTree x)
		{
			if (x.Parent.Left == x) {
				x = RightRotate (x.Parent);
				x = LeftRotate (x.Parent);
			} else {
				x = LeftRotate (x.Parent);
				x = RightRotate (x.Parent);
			}
			return x;
		}

		// assumption: x != null && x.Parent != null && x.GrandParent != null
		bool SameDirection (SplayTree x)
		{
			if (x.Parent.Left == x)
				return (x.GrandParent.Left == x.Parent);
			else
				return (x.GrandParent.Right == x.Parent);
		}
	
		// assumption: x != null && x.Right != null
		// return value: node that is where rotated node (x) was
		SplayTree LeftRotate (SplayTree x)
		{
			SplayTree y = x.Right;
	
			x.Right = y.Left;
			if (y.Left != null)
				y.Left.Parent = x;
			y.Parent = x.Parent;
	
			if (x.HasParent) {
				if (x == x.Parent.Left)
					x.Parent.Left = y;
				else
					x.Parent.Right = y;
			}
		
			y.Left = x;
			x.Parent = y;
			
			return y;
		}

		// assumption: y != null && y.Left != null
		// return value: node that is where rotated node (y) was
		SplayTree RightRotate (SplayTree y)
		{
			SplayTree x = y.Left;
		
			y.Left = x.Right;
			if (x.Right != null)
				x.Right.Parent = y;
			x.Parent = y.Parent;
		
			if (y.HasParent) {
				if (y == y.Parent.Left)
					y.Parent.Left = x;
				else
					y.Parent.Right = x;
			}
		
			x.Right = y;
			y.Parent = x;
	
			return x;
		}

		public SplayTree Left {
			get { return left; }
			private set { left = value; }
		}

		public SplayTree Right {
			get { return right; }
			private set { right = value; }
		}

		SplayTree Parent {
			get { return parent; }
			set { parent = value; }
		}

		SplayTree GrandParent {
			get { return Parent.Parent; }
		}

		bool HasParent {
			get { return parent != null; }
		}

		bool HasGrandParent {
			get { return parent != null && parent.parent != null; }
		}

	}
}
