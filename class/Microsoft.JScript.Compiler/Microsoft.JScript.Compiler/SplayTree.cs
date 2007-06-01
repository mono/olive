using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
{
	public class SplayTree
	{
		public SplayTree()
		{
			throw new NotImplementedException();
		}

		public void AddAsLeftChild(SplayTree Child)
		{
			this.left = Child;
		}

		public void AddAsRightChild(SplayTree Child)
		{
			this.right = Child;
		}

		public void SplayToRoot()
		{
			throw new NotImplementedException();
		}

		public static void Validate()
		{
			throw new NotImplementedException();
		}

		private SplayTree left;
		private SplayTree right;

		public SplayTree Left {
			get { return left; }
		}
		public SplayTree Right {
			get { return right; }
		}
	}
}
