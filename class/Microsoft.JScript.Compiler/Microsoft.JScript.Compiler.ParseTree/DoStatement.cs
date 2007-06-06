using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class DoStatement : LoopStatement
	{
		public readonly Expression Condition;
		public readonly TextSpan HeaderLocation;
		private readonly TextPoint While;
 
		public DoStatement(Statement Body, Expression Condition, TextSpan Location, TextSpan HeaderLocation, TextPoint While, TextPoint LeftParen, TextPoint RightParen)
			:base(Operation.Do, Body, Location, LeftParen, RightParen)
		{
			this.While = While;
		}
	}


}
