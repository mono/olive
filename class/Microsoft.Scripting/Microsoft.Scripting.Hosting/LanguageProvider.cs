using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Shell;

namespace Microsoft.Scripting.Hosting
{
	public abstract class LanguageProvider
	{
		protected LanguageProvider (ScriptDomainManager manager)
		{
		}

		public virtual CommandLine GetCommandLine ()
		{
			throw new NotImplementedException ();
		}

		public virtual ScriptEngine GetEngine (EngineOptions options)
		{
			throw new NotImplementedException ();
		}

		public virtual OptionsParser GetOptionsParser ()
		{
			throw new NotImplementedException ();
		}

		public virtual TokenCategorizer GetTokenCategorizer ()
		{
			throw new NotImplementedException ();
		}

		public abstract string LanguageDisplayName { get; }
	}
}
