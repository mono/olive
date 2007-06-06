using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class FinallyClause
	{
		public readonly BlockStatement Handler;
		public readonly TextSpan Location;

		public FinallyClause(BlockStatement Handler, TextSpan Location)
		{
			this.Handler = Handler;
			this.Location = Location;
		}
	}
}
