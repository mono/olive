using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class ArrayLiteralExpression : Expression
	{
		public readonly List<ExpressionListElement> Elements;

		public ArrayLiteralExpression(List<ExpressionListElement> Elements, TextSpan Location)
			:base(Operation.ArrayLiteral, Location)
		{
			this.Elements = Elements;
		}
	}


}
