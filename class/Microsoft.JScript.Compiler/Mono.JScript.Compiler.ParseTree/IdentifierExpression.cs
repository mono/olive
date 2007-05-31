using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class IdentifierExpression : Expression
	{
		public readonly Identifier ID;

		public IdentifierExpression(Identifier ID, TextSpan Location)
			:base(Operation.Identifier,Location)
		{
			this.ID = ID;
		}
	}

 

}
