using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public abstract class ForStatement : LoopStatement
	{
		public readonly Expression Condition;
		public readonly TextSpan HeaderLocation;
		public readonly Expression Increment;
		private readonly TextPoint FirstSemicolon;
		private readonly TextPoint SecondSemicolon;

		public ForStatement(Statement.Operation Opcode, Expression Condition, Expression Increment, Statement Body, TextSpan Location, TextSpan HeaderLocation, TextPoint FirstSemicolon, TextPoint SecondSemicolon, TextPoint LeftParen, TextPoint RightParen)
			:base(Opcode,Body,Location,LeftParen,RightParen)
		{
			this.Condition = Condition;
			this.Increment = Increment;
			this.HeaderLocation = HeaderLocation;
			this.FirstSemicolon= FirstSemicolon;
			this.SecondSemicolon = SecondSemicolon;
		}
	}

 

}
