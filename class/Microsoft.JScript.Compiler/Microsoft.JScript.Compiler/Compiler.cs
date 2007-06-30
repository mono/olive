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
using Microsoft.JScript.Compiler.ParseTree;

namespace Microsoft.JScript.Compiler
{
	public class Compiler
	{
		public Compiler()
		{
		}

		public Microsoft.Scripting.Internal.Ast.CodeBlock CompileExpression(string Input, ref List<Diagnostic> Diagnostics)
		{
			return CompileExpression (Input.ToCharArray (), ref Diagnostics);
		}
		[MonoTODO]
		public Microsoft.Scripting.Internal.Ast.CodeBlock CompileExpression (char[] Input, ref List<Diagnostic> Diagnostics)
		{
			Parser parser = new Parser (Input, new IdentifierTable ());
			List<Comment> comments = null;
			Expression expr = parser.ParseExpression (ref comments);
			Diagnostics = parser.Diagnostics;
			//TODO return
			return null;
		}

		public Microsoft.Scripting.Internal.Ast.CodeBlock CompileProgram (char[] Input, ref List<Diagnostic> Diagnostics, ref bool IncompleteInput)
		{
			return CompileProgram (Input, ref Diagnostics, ref IncompleteInput, false);
		}

		[MonoTODO]
		public Microsoft.Scripting.Internal.Ast.CodeBlock CompileProgram (char[] Input, ref List<Diagnostic> Diagnostics, ref bool IncompleteInput, bool PrintExpressions)
		{
			Parser parser = new Parser (Input, new IdentifierTable ());
			List<Comment> comments = null;
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			Diagnostics = parser.Diagnostics;
			IncompleteInput = parser.SyntaxIncomplete();
			//TODO return
			return null;
		}

		public Microsoft.JScript.Compiler.ParseTree.Statement CompileStatement(char[] Input)
		{
			Parser parser = new Parser (Input, new IdentifierTable ());
			List<Comment> comments = null;
			return parser.ParseStatement (ref comments);
		}

		public Statement CompileStatement(string Input)
		{
			return CompileStatement (Input.ToCharArray ());
		}
	}
}
