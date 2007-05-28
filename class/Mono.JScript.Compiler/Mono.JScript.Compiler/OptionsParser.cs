using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Shell;

namespace Mono.JScript.Compiler
{
	public class OptionsParser : Microsoft.Scripting.OptionsParser
	{
		public OptionsParser()
		{
			throw new NotImplementedException();
		}

		public override ConsoleOptions GetDefaultConsoleOptions()
		{
			throw new NotImplementedException();
		}

		public override Microsoft.Scripting.EngineOptions GetDefaultEngineOptions()
		{
			throw new NotImplementedException();
		}

		public override void GetHelp(out string commandLine, out string[,] options, out string[,] environmentVariables, out string comments)
		{
			throw new NotImplementedException();
		}

		public override void Parse(string[] args)
		{
			throw new NotImplementedException();
		}

		protected override void ParseArgument(string arg)
		{
			throw new NotImplementedException();
		}
		
		public override ConsoleOptions ConsoleOptions {
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		public override Microsoft.Scripting.EngineOptions EngineOptions
		{
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
	}
}
