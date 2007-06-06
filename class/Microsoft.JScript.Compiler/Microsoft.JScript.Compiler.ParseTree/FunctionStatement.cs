using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class FunctionStatement : Statement
	{
		public readonly FunctionDefinition Function;

		public FunctionStatement(FunctionDefinition Function)
			:base(Operation.Function,Function.Location)
		{
			this.Function = Function;
		}
	}

 

}
