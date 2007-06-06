using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class OctalLiteralExpression : Expression
	{
		public readonly double Value;

		public OctalLiteralExpression(double Value, TextSpan Location)
			:base(Operation.OctalLiteral,Location)
		{
			this.Value = Value;
		}
	}
}
