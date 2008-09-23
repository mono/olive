//
// Microsoft.JScript.Compiler
//
// Author:
//   Olivier Dufour (olivier.duff@gmail.com)
//
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler
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

		internal TextSpan (Token start, Token end)
		{
			this.startLine = start.StartLine;
			this.startColumn = start.StartColumn;
			this.endLine = end.StartLine;
			this.endColumn = end.StartColumn + end.Width;
			this.startPosition = end.StartPosition + end.Width;
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
