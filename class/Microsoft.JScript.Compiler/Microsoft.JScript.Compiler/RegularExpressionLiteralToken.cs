using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
{
	public class RegularExpressionLiteralToken : Token
	{
		public readonly string BodySpelling;
		public readonly string FlagsSpelling;
		private readonly int width;

		public RegularExpressionLiteralToken (string BodySpelling, string FlagsSpelling, int Width, int StartCharacterPosition, int StartLine, int StartColumn, bool FirstOnLine)
			:base(Type.RegularExpressionLiteral, StartCharacterPosition, StartLine, StartColumn, FirstOnLine)
		{
			this.BodySpelling = BodySpelling;
			this.FlagsSpelling = FlagsSpelling;
			this.width = Width;
		}

		public override int Width {	get { return width; } }
	}
}
