using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class ExpressionStatement : Statement
	{
		public readonly Expression Expression;

		public ExpressionStatement(Expression Expression, TextSpan Location)
			:base(Operation.Expression, Location)
		{
			this.Expression = Expression;
		}
	}


}
