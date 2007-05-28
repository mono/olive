using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
{
	public class HexIntegerLiteralToken : Token
	{
		public readonly string Spelling;
		public readonly double Value;

		public HexIntegerLiteralToken(string Spelling, double Value, int StartCharacterPosition, int StartLine, int StartColumn, bool FirstOnLine) 
			: base(Token.Type.HexIntegerLiteral,StartCharacterPosition,StartLine,StartColumn,FirstOnLine)
		{
			this.Spelling = Spelling;
			this.Value = Value;
		}

		public override int Width {
			get	{ return this.Spelling.Length; }
		}
	}

 

}
