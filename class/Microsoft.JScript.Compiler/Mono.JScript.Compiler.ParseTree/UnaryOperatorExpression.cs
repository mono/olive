using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class UnaryOperatorExpression : Expression
	{
		public readonly Expression Operand;

		public UnaryOperatorExpression(Expression Operand, Expression.Operation Opcode, TextSpan Location)
			:base(Opcode, Location)
		{
			this.Operand = Operand;
		}
	}
}
