using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class InvocationExpression : Expression
	{
		public readonly Expression Target;
		public readonly ArgumentList Arguments;

		public InvocationExpression(Expression Target, ArgumentList Arguments, Expression.Operation Opcode, TextSpan Location)
			: base(Opcode, Location)
		{
			this.Target = Target;
			this.Arguments = Arguments;
		}
	}
}
