using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class BreakOrContinueStatement : Statement
	{
		private TextPoint labelLocation;
		public readonly Identifier Label;

		public BreakOrContinueStatement(Statement.Operation Opcode, Identifier Label, TextSpan Location, TextPoint LabelLocation)
			: base(Opcode,Location)
		{
			this.Label = Label;
			this.labelLocation = LabelLocation;
		}
	}
}
