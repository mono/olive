using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public abstract class CaseClause
	{
		private TextPoint colon;
		private TextSpan location;
		public readonly DList<Statement, CaseClause> Children;
		public readonly TextSpan HeaderLocation;

		public CaseClause(DList<Statement, CaseClause> Children, TextSpan Location, TextSpan HeaderLocation, TextPoint Colon)

		{
			this.colon = Colon;
			this.location = Location;
			this.Children = Children;
			this.HeaderLocation = HeaderLocation;
		}
	}
}
