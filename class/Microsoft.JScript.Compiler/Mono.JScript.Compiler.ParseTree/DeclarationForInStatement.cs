using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class DeclarationForInStatement : ForInStatement
	{
		public readonly VariableDeclaration Item;
		private readonly TextPoint In;
		private readonly TextPoint LeftParen;
		private readonly TextPoint RightParen;

		public DeclarationForInStatement(VariableDeclaration Item, Expression Collection, Statement Body, TextSpan Location, TextSpan HeaderLocation, TextPoint In, TextPoint LeftParen, TextPoint RightParen)
			:base(Operation.DeclarationForIn,Collection,Body,Location,HeaderLocation,In,LeftParen,RightParen)
		{
			this.Item = Item;
			this.In = In;
			this.LeftParen = LeftParen;
			this.RightParen = RightParen;
		}
	}
}
