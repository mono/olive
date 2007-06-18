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

		//TODO Test to get exact name maybe + version or "JScript"
		public override string LanguageDisplayName {
			get { return "JavaScript"; }
		}
	}


}
