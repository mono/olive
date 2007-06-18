using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class DeclarationForStatement : ForStatement
	{
		public readonly List<VariableDeclarationListElement> Initial;

		public DeclarationForStatement(List<VariableDeclarationListElement> Initial, Expression Condition, Expression Increment, Statement Body, TextSpan Location, TextSpan HeaderLocation, TextPoint FirstSemicolon, TextPoint SecondSemicolon, TextPoint LeftParen, TextPoint RightParen)
			:base(Operation.DeclarationFor,Condition, Increment, Body, Location, HeaderLocation, FirstSemicolon, SecondSemicolon, LeftParen, RightParen)
		{
			this.Initial = Initial;
		}
	}

 

}
