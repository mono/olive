using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class ValueCaseClause : CaseClause
	{
		public readonly Expression Value;

		public ValueCaseClause(Expression Value, DList<Statement, CaseClause> Children, TextSpan Location, TextSpan HeaderLocation, TextPoint Colon)
			:base(Children, Location, HeaderLocation, Colon)
		{
			this.Value = Value;
		}
	}
}
