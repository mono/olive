using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class RegularExpressionLiteralExpression : Expression
	{
		public readonly string Body;
		public readonly string Flags;

		public RegularExpressionLiteralExpression(string Body, string Flags, TextSpan Location)
			: base(Operation.RegularExpressionLiteral, Location)
		{
			this.Body = Body;
			this.Flags = Flags;
		}
	}
}
