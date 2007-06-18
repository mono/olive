using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class TryStatement : Statement
	{
		public readonly BlockStatement Block;
		public readonly CatchClause Catch;
		public readonly FinallyClause Finally;

		public TryStatement(BlockStatement Block, CatchClause Catch, FinallyClause Finally, TextSpan Location)
			: base(Operation.Try, Location)
		{
			this.Block = Block;
			this.Catch = Catch;
			this.Finally = Finally;
		}
	}
}
