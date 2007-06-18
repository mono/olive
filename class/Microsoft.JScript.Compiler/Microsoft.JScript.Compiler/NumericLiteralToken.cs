using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler
{
	public class NumericLiteralToken : Token
	{
		public readonly string Spelling;

		public NumericLiteralToken (string Spelling, int StartCharacterPosition, int StartLine, int StartColumn, bool FirstOnLine)
			:base(Token.Type.NumericLiteral, StartCharacterPosition, StartLine, StartColumn, FirstOnLine)
		{
			this.Spelling = Spelling;
		}

		public override int Width { get { return Spelling.Length; } }

	}
}
