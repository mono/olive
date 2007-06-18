using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler
{
	public class OctalIntegerLiteralToken : Token
	{
		public readonly string Spelling;
		public readonly double Value;

		public OctalIntegerLiteralToken(string Spelling, double Value, int StartCharacterPosition, int StartLine, int StartColumn, bool FirstOnLine)
			:base(Token.Type.OctalIntegerLiteral, StartCharacterPosition, StartLine, StartColumn, FirstOnLine)
		{
			this.Spelling = Spelling;
			this.Value = Value;
		}

		public override int Width {
			get { return Spelling.Length; }
			}

	}
}
