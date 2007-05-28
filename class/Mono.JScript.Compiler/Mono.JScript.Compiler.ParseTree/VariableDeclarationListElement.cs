using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public struct VariableDeclarationListElement
	{
		public readonly VariableDeclaration Declaration;
		private readonly TextPoint CommaLocation;
		public VariableDeclarationListElement(VariableDeclaration Declaration, TextPoint CommaLocation)
		{
			this.Declaration = Declaration;
			this.CommaLocation = CommaLocation;
		}
	}
}
