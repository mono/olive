using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Shell;

namespace Microsoft.Scripting
{
	public abstract class OptionsParser
	{
		public virtual ConsoleOptions GetDefaultConsoleOptions ()
		{
			throw new NotImplementedException ();
		}

		public virtual EngineOptions GetDefaultEngineOptions ()
		{
			throw new NotImplementedException ();
		}

		public abstract void GetHelp (out string commandLine, out string[,] options, out string[,] environmentVariables, out string comments);

		public virtual void Parse (string[] args)
		{
			throw new NotImplementedException ();
		}

		protected virtual void ParseArgument (string arg)
		{
			throw new NotImplementedException ();
		}

		public virtual ConsoleOptions ConsoleOptions {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public virtual EngineOptions EngineOptions {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

	}
}
