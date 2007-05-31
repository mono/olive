using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class NumericLiteralExpression : Expression
	{
		public readonly string Spelling;

		public NumericLiteralExpression(string Spelling, TextSpan Location)
			:base(Operation.NumericLiteral, Location)
		{
			this.Spelling = Spelling;
		}
	}
}
