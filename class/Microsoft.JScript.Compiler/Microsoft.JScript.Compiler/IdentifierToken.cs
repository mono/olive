using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler
{
	public class IdentifierToken : Token
	{
		public readonly Identifier Spelling;
		private int width;

		public IdentifierToken(Identifier Spelling, int Width, Token.Type Kind, int StartCharacterPosition, int StartLine, int StartColumn, bool FirstOnLine)
			:base(Kind, StartCharacterPosition, StartLine, StartColumn, FirstOnLine)
		{
			this.Spelling = Spelling;
			this.width = Width;
		}

		public override int Width {
			get { return width; }
			}

	}
}
