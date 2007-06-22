using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class WithStatement : Statement
	{

		public readonly Statement Body;
		public readonly TextSpan HeaderLocation;
		public readonly Expression Scope;
		private readonly TextPoint LeftParen;
		private readonly TextPoint RightParen;

		public WithStatement(Expression Scope, Statement Body, TextSpan Location, TextSpan HeaderLocation, TextPoint LeftParen, TextPoint RightParen)
			:base(Operation.With,Location)
		{
			this.LeftParen = LeftParen;
			this.RightParen = RightParen;
			this.Body = Body;
			this.HeaderLocation = HeaderLocation;
			this.Scope = Scope;
		}
	}
}
