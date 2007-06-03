using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Scripting.Shell
{
	public abstract class CommandLine
	{
		protected abstract int RunCommand (string command);

		protected virtual string Logo { get { throw new NotImplementedException (); } }
		protected virtual string Prompt { get { throw new NotImplementedException (); } }
		protected virtual string PromptContinuation { get { throw new NotImplementedException (); } }

	}
}
