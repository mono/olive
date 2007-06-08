using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class IfStatement : Statement
	{
		public readonly Expression Condition;
		public readonly Statement ElseBody;
		public readonly TextSpan HeaderLocation;
		public readonly Statement IfBody;
		private readonly TextPoint LeftParen;
		private readonly TextPoint RightParen;
		private readonly TextPoint Else;

		public IfStatement (Expression Condition, Statement IfBody, Statement ElseBody, TextSpan Location,
				    TextSpan HeaderLocation, TextPoint LeftParen, TextPoint RightParen, TextPoint Else)
			: base (Operation.If, Location)
		{
			this.Condition = Condition;
			this.IfBody = IfBody;
			this.ElseBody = ElseBody;
			this.HeaderLocation = HeaderLocation;
			this.LeftParen = LeftParen;
			this.RightParen = RightParen;
			this.Else = Else;
		}
	}

 

}
