using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class InitializerVariableDeclaration : VariableDeclaration
	{
		public readonly Expression Initializer;
		private readonly TextPoint Equal;

		public InitializerVariableDeclaration(Identifier Name, Expression Initializer, TextSpan Location, TextPoint Equal)
			: base(Name, Location)
		{
			this.Initializer = Initializer;
			this.Equal = Equal;
		}
	}
}
