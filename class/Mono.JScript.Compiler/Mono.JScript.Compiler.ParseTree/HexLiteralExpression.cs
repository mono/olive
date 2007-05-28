using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class HexLiteralExpression : Expression
	{
		public readonly double Value;

		public HexLiteralExpression(double Value, TextSpan Location)
			:base(Operation.HexLiteral,Location)
		{
			this.Value = Value;
		}
	}

 

}
