using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class Statement
	{
		public readonly TextSpan Location;
		public readonly Operation Opcode;

		public Statement (Operation Opcode, TextSpan Location)
		{
			this.Opcode = Opcode;
			this.Location = Location;
		}

		public enum Operation
		{
			Block,
			VariableDeclaration,
			Empty,
			Expression,
			If,
			Do,
			While,
			ExpressionFor,
			DeclarationFor,
			ExpressionForIn,
			DeclarationForIn,
			Break,
			Continue,
			Return,
			With,
			Label,
			Switch,
			Throw,
			Try,
			Function,
			SyntaxError
		}
	}
}
