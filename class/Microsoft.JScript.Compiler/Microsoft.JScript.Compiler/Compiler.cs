using System;
using System.Collections.Generic;
using System.Text;
using Mono.JScript.Compiler.ParseTree;

namespace Mono.JScript.Compiler
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

		public Mono.JScript.Compiler.ParseTree.Statement CompileStatement(char[] Input)
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
