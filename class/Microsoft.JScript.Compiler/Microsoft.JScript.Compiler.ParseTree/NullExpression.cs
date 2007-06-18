using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class NullExpression : Expression
	{
		public NullExpression(TextSpan Location)
			:base(Operation.Null,Location)
		{
		}
	}

 

}
