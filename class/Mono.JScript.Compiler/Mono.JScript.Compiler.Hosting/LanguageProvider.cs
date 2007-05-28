using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Shell;
using Microsoft.Scripting;

namespace Mono.JScript.Compiler.Hosting
{
	public sealed class LanguageProvider : Microsoft.Scripting.Hosting.LanguageProvider
	{
		public LanguageProvider(ScriptDomainManager environment) : base(environment)
		{
			throw new NotImplementedException();
		}

		public override CommandLine GetCommandLine()
		{
			throw new NotImplementedException();
		}

		public override ScriptEngine GetEngine(Microsoft.Scripting.EngineOptions options)
		{
			throw new NotImplementedException();
		}

		public override Microsoft.Scripting.OptionsParser GetOptionsParser()
		{
			throw new NotImplementedException();
		}

		public override Microsoft.Scripting.Hosting.TokenCategorizer GetTokenCategorizer()
		{
			throw new NotImplementedException();
		}

		public override string LanguageDisplayName {
			get { throw new NotImplementedException(); }
		}
	}


}
