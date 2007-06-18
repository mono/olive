using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class VariableDeclarationStatement : Statement
	{
		public readonly List<VariableDeclarationListElement> Declarations;

		public VariableDeclarationStatement(List<VariableDeclarationListElement> Declarations, TextSpan Location)
			:base(Operation.VariableDeclaration,Location)
		{
			this.Declarations = Declarations;
		}
	}
}
