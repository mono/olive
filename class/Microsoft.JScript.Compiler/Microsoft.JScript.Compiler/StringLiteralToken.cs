using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
{
	public class StringLiteralToken : Token
	{
		public readonly string Spelling;
		public readonly string Value;

		public StringLiteralToken (string Spelling, string Value, int StartCharacterPosition, int StartLine, int StartColumn, bool FirstOnLine)
			: base(Token.Type.StringLiteral, StartCharacterPosition, StartLine, StartColumn, FirstOnLine)
		{
			this.Spelling = Spelling;
			this.Value = Value;
		}

		public override int Width { get { return Spelling.Length; } }
	}
}
