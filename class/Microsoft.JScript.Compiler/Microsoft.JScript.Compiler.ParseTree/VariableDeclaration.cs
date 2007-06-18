using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class VariableDeclaration
	{
		public readonly TextSpan Location;
		public readonly Identifier Name;

		public VariableDeclaration(Identifier Name, TextSpan Location)
		{
			this.Name = Name;
			this.Location = Location;
		}
	}
}
