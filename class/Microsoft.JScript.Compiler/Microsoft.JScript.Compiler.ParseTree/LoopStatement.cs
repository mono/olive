using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public abstract class LoopStatement : Statement
	{
		public readonly Statement Body;
		private TextPoint LeftParen;
		private TextPoint RightParen;

		public LoopStatement(Statement.Operation Opcode, Statement Body, TextSpan Location, TextPoint LeftParen, TextPoint RightParen)
			:base(Opcode,Location)
		{
			this.Body = Body;
			this.LeftParen = LeftParen;
			this.RightParen = RightParen;
		}
	}
}
