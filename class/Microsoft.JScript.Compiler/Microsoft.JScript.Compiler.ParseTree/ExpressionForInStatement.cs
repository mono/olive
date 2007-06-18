using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class ExpressionForInStatement : ForInStatement
	{
		public readonly Expression Item;

		public ExpressionForInStatement(Expression Item, Expression Collection, Statement Body, TextSpan Location, TextSpan HeaderLocation, TextPoint In, TextPoint LeftParen, TextPoint RightParen)
			: base(Operation.ExpressionFor, Collection, Body, Location, HeaderLocation, In, LeftParen, RightParen)
		{
			this.Item = Item;
		}
	}
}
