using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class CatchClause
	{
		public readonly BlockStatement Handler;
		public readonly TextSpan Location;
		public readonly Identifier Name;
		public readonly TextSpan NameLocation;
		private TextPoint leftParen;
		private TextPoint rightParen;

		public CatchClause(Identifier Name, BlockStatement Handler, TextSpan Location, TextSpan NameLocation, TextPoint LeftParen, TextPoint RightParen)
		{
			this.Name = Name;
			this.Handler = Handler;
			this.Location = Location;
			this.NameLocation = NameLocation;
			this.leftParen = LeftParen;
			this.rightParen = RightParen;
		}
	}
}
