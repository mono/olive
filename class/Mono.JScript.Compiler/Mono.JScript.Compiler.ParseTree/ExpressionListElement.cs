using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public struct ExpressionListElement
	{
		public readonly Expression Value;
		private readonly TextPoint CommaLocation;

		public ExpressionListElement(Expression Value, TextPoint CommaLocation)
		{
			this.Value = Value;
			this.CommaLocation = CommaLocation;
		}
	}
}
