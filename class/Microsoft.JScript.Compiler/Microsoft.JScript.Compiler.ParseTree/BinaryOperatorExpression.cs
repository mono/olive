using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class BinaryOperatorExpression : Expression
	{
		public readonly Expression Left;
		public readonly Expression Right;
		private readonly TextPoint operatorLocation;

		public BinaryOperatorExpression(Expression Left, Expression Right, Expression.Operation Opcode, TextSpan Location, TextPoint OperatorLocation)
			: base(Opcode,Location)
		{
			this.Left = Left;
			this.Right = Right;
			this.operatorLocation = OperatorLocation;
		}
	}
}
