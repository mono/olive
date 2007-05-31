using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class SubscriptExpression : Expression
	{
		
		public readonly Expression Base;
		public readonly Expression Subscript;
		private readonly TextPoint LeftBracketLocation;

		public SubscriptExpression(Expression Base, Expression Subscript, TextSpan Location, TextPoint LeftBracketLocation)
			: base(Operation.Subscript, Location)
		{
			this.Base = Base;
			this.Subscript = Subscript;
			this.LeftBracketLocation = LeftBracketLocation;
		}
	}
}
