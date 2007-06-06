using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class ReturnOrThrowStatement : Statement
	{
		public readonly Expression Value;

		public ReturnOrThrowStatement(Statement.Operation Opcode, Expression Value, TextSpan Location)
			: base(Opcode, Location)
		{
			this.Value = Value;
		}
	}
}
