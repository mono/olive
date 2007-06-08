using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.Shell
{
	public sealed class CommandLine : Microsoft.Scripting.Shell.CommandLine
	{
		public CommandLine ()
		{
			throw new NotImplementedException();
		}

		protected override int RunCommand (string command)
		{
			throw new NotImplementedException();
		}

		protected override string Logo {
			get { throw new NotImplementedException(); } 
		}
		protected override string Prompt {
			get { throw new NotImplementedException(); }
		}
		protected override string PromptContinuation {
			get { throw new NotImplementedException(); }
		}

#if !SILVERLIGHT
		protected override int RunFile (string filename)
		{
			throw new NotImplementedException ();
		}
#endif
	}

}
