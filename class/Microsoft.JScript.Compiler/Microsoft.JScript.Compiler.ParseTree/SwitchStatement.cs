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
using Microsoft.JScript.Compiler.Helpers;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class SwitchStatement : Statement
	{
		public readonly DList<CaseClause, SwitchStatement> Cases;
		public readonly TextSpan HeaderLocation;
		public readonly Expression Value;
		private TextPoint LeftBrace;
		private TextPoint LeftParen;
		private TextPoint RightParen;

		public SwitchStatement(Expression Value, DList<CaseClause, SwitchStatement> Cases, TextSpan Location, TextSpan HeaderLocation, TextPoint LeftParen, TextPoint RightParen, TextPoint LeftBrace)
			:base(Operation.Switch,Location)
		{
			this.Value = Value;
			this.Cases = Cases;
			this.HeaderLocation = HeaderLocation;
			this.LeftParen = LeftParen;
			this.RightParen = RightParen;
			this.LeftBrace = LeftBrace;
		}
	}
}
