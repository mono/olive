using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class LabelStatement : Statement
	{
		public readonly Identifier Label;
		public readonly Statement Labeled;
		private readonly TextPoint Colon;

		public LabelStatement(Identifier Label, Statement Labeled, TextSpan Location, TextPoint Colon)
			:base(Operation.Label,Location)
		{
			this.Label = Label;
			this.Labeled = Labeled;
			this.Colon = Colon;
		}
	}
}
