using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public abstract class ForInStatement : LoopStatement
	{
		public readonly Expression Collection;
		public readonly TextSpan HeaderLocation;
		private TextPoint In;

		public ForInStatement(Statement.Operation Opcode, Expression Collection, Statement Body, TextSpan Location, TextSpan HeaderLocation, TextPoint In, TextPoint LeftParen, TextPoint RightParen)
			:base(Opcode, Body, Location, LeftParen, RightParen)
		{
			this.Collection = Collection;
			this.HeaderLocation = HeaderLocation;
			this.In = In;
		}
	}
}
