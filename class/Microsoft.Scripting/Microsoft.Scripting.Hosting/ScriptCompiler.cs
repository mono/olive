using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Internal.Ast;

namespace Microsoft.Scripting.Hosting
{
	public abstract class ScriptCompiler
	{
		protected ScriptCompiler (ScriptEngine engine)
		{
			throw new NotImplementedException ();
		}

		public abstract CodeBlock ParseExpressionCode (CompilerContext cc);
		public abstract CodeBlock ParseFile (CompilerContext cc);
		public abstract CodeBlock ParseInteractiveCode (CompilerContext cc, bool allowIncomplete, out InteractiveCodeProperties properties);
		public abstract CodeBlock ParseStatementCode (CompilerContext cc);

	}
}
