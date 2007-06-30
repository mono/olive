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

using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Shell;
using Microsoft.Scripting;

namespace Microsoft.JScript.Compiler.Hosting
{
	public sealed class LanguageProvider : Microsoft.Scripting.Hosting.LanguageProvider
	{
		public LanguageProvider(ScriptDomainManager environment) : base(environment)
		{
		}

		public override CommandLine GetCommandLine()
		{
			return new Microsoft.JScript.Compiler.Shell.CommandLine ();
		}

		public override ScriptEngine GetEngine(Microsoft.Scripting.EngineOptions options)
		{
			 return new Engine (this, (Microsoft.JScript.Compiler.EngineOptions)options);
		}

		public override Microsoft.Scripting.OptionsParser GetOptionsParser()
		{
			return new Microsoft.JScript.Compiler.OptionsParser ();
		}

		public override Microsoft.Scripting.Hosting.TokenCategorizer GetTokenCategorizer()
		{
			return new Microsoft.JScript.Compiler.TokenCategorizer ();
		}

		public override string LanguageDisplayName {
			get { return "JavaScript"; }
		}
	}


}
