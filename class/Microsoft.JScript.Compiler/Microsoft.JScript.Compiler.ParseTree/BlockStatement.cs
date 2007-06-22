using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class BlockStatement : Statement
	{
		public readonly DList<Statement, BlockStatement> Children;
		
		public BlockStatement (DList<Statement, BlockStatement> Children, TextSpan Location) 
			:base(Statement.Operation.Block, Location)
		{
			this.Children = Children;
		}
	}
}
