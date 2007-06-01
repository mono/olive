using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Internal.Ast;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;

namespace Mono.JScript.Compiler
{
	public class JavaScriptCompiler : ScriptCompiler
	{
		public JavaScriptCompiler(Engine engine) : base(engine)
		{
		}

		public override CodeBlock ParseExpressionCode(CompilerContext Context)
		{
			Compiler compiler = new Compiler();
			List<Diagnostic> diagnostics = null;
			return compiler.CompileExpression (Context.SourceUnit.GetCode (), ref diagnostics);
		}

		public override CodeBlock ParseFile(CompilerContext Context)
		{
			Compiler compiler = new Compiler ();
			List<Diagnostic> diagnostics = null;
			bool incompleteInput = false;
			return compiler.CompileProgram (Context.SourceUnit.GetCode ().ToCharArray (), ref diagnostics, ref incompleteInput);
		}

		public override CodeBlock ParseInteractiveCode(CompilerContext cc, bool allowIncomplete, out InteractiveCodeProperties properties)
		{
			Compiler compiler = new Compiler ();
			List<Diagnostic> diagnostics = null;
			bool IncompleteInput = false;
			CodeBlock result = compiler.CompileProgram (cc.SourceUnit.GetCode ().ToCharArray(), ref diagnostics, ref IncompleteInput, false);
			//TODO properties
			properties = InteractiveCodeProperties.IsEmpty;
			if (allowIncomplete && IncompleteInput) 
			{
				throw new Exception ("Incomplete code!");
			}
			//TODO
			return result;
		}
				
		public override CodeBlock ParseStatementCode(CompilerContext Context)
		{
			Compiler compiler = new Compiler ();
			List<Diagnostic> diagnostics = null;
			bool IncompleteInput = false;
			return compiler.CompileProgram (Context.SourceUnit.GetCode ().ToCharArray (), ref diagnostics, ref IncompleteInput, false);
		}
	}
}
