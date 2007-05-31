using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
{
	public class BadToken : Token
	{
		public BadToken(string Spelling, DiagnosticCode Diagnostic, int StartCharacterPosition, int StartLine, int StartColumn, bool FirstOnLine)
			: base(Token.Type.Bad, StartCharacterPosition, StartLine, StartColumn, FirstOnLine)
		{
			this.Spelling = Spelling;
			this.Diagnostic = Diagnostic;
		}

		public readonly DiagnosticCode Diagnostic;
		public readonly string Spelling;

		public override int Width {
			get { return Spelling.Length; }
		}

	}
}
