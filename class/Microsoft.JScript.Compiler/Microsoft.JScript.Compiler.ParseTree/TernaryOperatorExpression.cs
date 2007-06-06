using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class TernaryOperatorExpression : Expression
	{
		public readonly Expression First;
		public readonly Expression Second;
		public readonly Expression Third;
		private readonly TextPoint FirstOperatorLocation;
		private readonly TextPoint SecondOperatorLocation;

		public TernaryOperatorExpression(Expression First, Expression Second, Expression Third, Expression.Operation opcode, TextSpan Location, TextPoint FirstOperatorLocation, TextPoint SecondOperatorLocation)
			:base(opcode,Location)
		{
			this.First = First;
			this.Second = Second;
			this.Third = Third;
			this.FirstOperatorLocation = FirstOperatorLocation;
			this.SecondOperatorLocation = SecondOperatorLocation;
		}
	}
}
