using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Internal.Ast;

namespace Mono.JScript.Compiler
{
	public class Compiler
	{
		public Compiler()
		{
		}

		public CodeBlock CompileExpression(string Input, ref List<Diagnostic> Diagnostics)
		{
			throw new NotImplementedException();
		}

		public CodeBlock CompileExpression(char[] Input, ref List<Diagnostic> Diagnostics)
		{
			throw new NotImplementedException();
		}

		public CodeBlock CompileProgram(char[] Input, ref List<Diagnostic> Diagnostics, ref bool IncompleteInput)
		{
			throw new NotImplementedException();
		}

		public CodeBlock CompileProgram(char[] Input, ref List<Diagnostic> Diagnostics, ref bool IncompleteInput, bool PrintExpressions)
		{
			throw new NotImplementedException();
		}

		public Statement CompileStatement(char[] Input)
		{
			throw new NotImplementedException();
		}

		public Statement CompileStatement(string Input)
		{
			throw new NotImplementedException();
		}
	}
}
