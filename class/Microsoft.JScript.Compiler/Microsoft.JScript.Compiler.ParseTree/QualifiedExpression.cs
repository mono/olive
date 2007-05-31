using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class QualifiedExpression : Expression
	{
		public readonly Expression Base;
		public readonly Identifier Qualifier;
		private readonly TextPoint DotLocation;
		private readonly TextPoint QualifierLocation;

		public QualifiedExpression(Expression Base, Identifier Qualifier, TextSpan Location, TextPoint DotLocation, TextPoint QualifierLocation)
			:base(Operation.Qualified, Location)
		{
			this.Base = Base;
			this.Qualifier = Qualifier;
			this.DotLocation = DotLocation;
			this.QualifierLocation = QualifierLocation;
		}
	}
}
