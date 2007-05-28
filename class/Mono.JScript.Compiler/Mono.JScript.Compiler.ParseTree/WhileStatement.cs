using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class WhileStatement : LoopStatement
	{
		public readonly Expression Condition;
		public readonly TextSpan HeaderLocation;

		public WhileStatement(Expression Condition, Statement Body, TextSpan Location, TextSpan HeaderLocation, TextPoint LeftParen, TextPoint RightParen)
			:base(Operation.While, Body, Location, LeftParen, RightParen)
		{
			this.HeaderLocation = HeaderLocation;
			this.Condition = Condition;
		}
	}
}
