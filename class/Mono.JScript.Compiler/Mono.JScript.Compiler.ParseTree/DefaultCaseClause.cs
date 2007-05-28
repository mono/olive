using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class DefaultCaseClause : CaseClause
	{
		public DefaultCaseClause(DList<Statement, CaseClause> Children, TextSpan Location, TextSpan HeaderLocation, TextPoint Colon)
			:base(Children,Location,HeaderLocation,Colon)
		{
		}
	}

 

}
