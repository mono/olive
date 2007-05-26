using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
{
	public class TextSpan
	{
		public TextSpan (int StartLine, int StartColumn, int EndLine, int EndColumn, int StartPosition, int EndPosition)
		{
			this.startLine = StartLine;
			this.startColumn = StartColumn;
			this.endLine = EndLine;
			this.endColumn = EndColumn;
			this.startPosition = StartPosition;
			this.endPosition = EndPosition;
		}


		private int startLine;
		private int startColumn;
		private int endLine;
		private int endColumn;
		private int startPosition;
		private int endPosition;

		public int StartLine { get { return startLine; } }
		public int StartColumn { get { return startColumn; } }
		public int EndLine { get { return endLine; } }
		public int EndColumn { get { return endColumn; } }
		public int StartPosition { get { return startPosition; } }
		public int EndPosition { get { return endPosition; } }
		public int Width { get { return endPosition - startPosition; } }

	}
}
