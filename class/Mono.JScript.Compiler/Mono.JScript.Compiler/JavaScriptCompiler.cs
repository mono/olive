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
			throw new NotImplementedException();
		}

		public override CodeBlock ParseExpressionCode(CompilerContext Context)
		{
			throw new NotImplementedException();
		}

		public override CodeBlock ParseFile(CompilerContext Context)
		{
			throw new NotImplementedException();
		}

		public override CodeBlock ParseInteractiveCode(CompilerContext cc, bool allowIncomplete, out InteractiveCodeProperties properties)
		{
			throw new NotImplementedException();
		}
				
		public override CodeBlock ParseStatementCode(CompilerContext Context)
		{
			throw new NotImplementedException();
		}

	}
}
