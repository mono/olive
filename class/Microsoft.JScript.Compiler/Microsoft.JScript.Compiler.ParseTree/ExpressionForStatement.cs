using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class ExpressionForStatement : ForStatement
	{
		public readonly Expression Initial;

		public ExpressionForStatement(Expression Initial, Expression Condition, Expression Increment, Statement Body, TextSpan Location, TextSpan HeaderLocation, TextPoint FirstSemicolon, TextPoint SecondSemicolon, TextPoint LeftParen, TextPoint RightParen)
			:base(Operation.ExpressionFor, Condition, Increment, Body, Location, HeaderLocation, FirstSemicolon, SecondSemicolon, LeftParen, RightParen)
		{
			this.Initial = Initial;
		}
	}

 

}
