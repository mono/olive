using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class SwitchStatement : Statement
	{
		public readonly DList<CaseClause, SwitchStatement> Cases;
		public readonly TextSpan HeaderLocation;
		public readonly Expression Value;
		private TextPoint LeftBrace;
		private TextPoint LeftParen;
		private TextPoint RightParen;

		public SwitchStatement(Expression Value, DList<CaseClause, SwitchStatement> Cases, TextSpan Location, TextSpan HeaderLocation, TextPoint LeftParen, TextPoint RightParen, TextPoint LeftBrace)
			:base(Operation.Switch,Location)
		{
			this.Value = Value;
			this.Cases = Cases;
			this.HeaderLocation = HeaderLocation;
			this.LeftParen = LeftParen;
			this.RightParen = RightParen;
			this.LeftBrace = LeftBrace;
		}
	}
}
