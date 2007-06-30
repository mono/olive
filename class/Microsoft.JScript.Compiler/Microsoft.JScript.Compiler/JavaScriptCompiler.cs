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
using Microsoft.Scripting.Internal.Ast;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;

namespace Microsoft.JScript.Compiler
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

#if !SILVERLIGHT
		public override SourceUnit ParseCodeDom (System.CodeDom.CodeObject codeDom)
		{
			throw new NotImplementedException ();
		}
#endif
	}
}
