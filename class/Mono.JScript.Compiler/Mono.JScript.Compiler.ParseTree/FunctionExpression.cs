using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class FunctionExpression : Expression
	{
		public readonly FunctionDefinition Function;

		public FunctionExpression(FunctionDefinition Function)
			:base(Operation.Function,Function.Location)
		{
			this.Function = Function;
		}
	}
}
