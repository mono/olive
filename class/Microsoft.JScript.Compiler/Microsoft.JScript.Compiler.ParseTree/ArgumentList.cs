using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public struct ArgumentList
	{
		public readonly List<ExpressionListElement> Arguments;
		public readonly TextSpan Location;

		public ArgumentList(List<ExpressionListElement> Arguments, TextSpan Location)
		{
			this.Arguments = Arguments;
			this.Location = Location;
		}
	}
}
