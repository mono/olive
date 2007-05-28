using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class StringLiteralExpression : Expression
	{
		public readonly string Spelling;
		public readonly string Value;

		public StringLiteralExpression(string Value, string Spelling, TextSpan Location)
			:base(Operation.StringLiteral,Location)
		{
			this.Value = Value;
			this.Spelling = Spelling;
		}
	}
}
