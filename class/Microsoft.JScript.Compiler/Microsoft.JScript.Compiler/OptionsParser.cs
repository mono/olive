using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Shell;
using Microsoft.Scripting;

namespace Microsoft.JScript.Compiler
{
	public class OptionsParser : Microsoft.Scripting.OptionsParser
	{
		public OptionsParser()
		{
			ConsoleOptions = GetDefaultConsoleOptions ();
			EngineOptions = GetDefaultEngineOptions ();
			//this.GlobalOptions = 
		}

		private ConsoleOptions consoleOptions;
		private Microsoft.Scripting.EngineOptions engineOptions;

		public override ConsoleOptions GetDefaultConsoleOptions()
		{
			return new Microsoft.JScript.Compiler.Shell.ConsoleOptions ();
		}

		public override Microsoft.Scripting.EngineOptions GetDefaultEngineOptions()
		{
			return new EngineOptions ();
		}

		public override void GetHelp(out string commandLine, out string[,] options, out string[,] environmentVariables, out string comments)
		{
			commandLine = "[options] [file|- [arguments]]";
			options = new string [,] {{ "-c cmd", "Program passed in as string (terminates option list)" },
									{ "-h", "Display usage" }, 
									{ "-V", "Print the engine version number and exit" }, 
									{ "-O", "Enable optimizations" }, 
									{ "-i", "Inspect interactively after running script" }, 
									{ "-v", "Verbose" }, 
									{ "-D", "EngineDebug mode" }, 
									{ "-u", "Unbuffered stdout & stderr" }, 
									{ "-OO", "Remove doc-strings in addition to the -O optimizations" }, 
									{ "-X:AutoIndent", "" }, 
									{ "-X:AssembliesDir", "Set the directory for saving generated assemblies" }, 
									{ "-X:ColorfulConsole", "Enable ColorfulConsole" }, 
									{ "-X:ExceptionDetail", "Enable ExceptionDetail mode" }, 
									{ "-X:FastEval", "Enable fast eval" }, 
									{ "-X:Frames", "Generate custom frames" }, 
									{ "-X:GenerateAsSnippets", "Generate code to run in snippet mode" }, 
									{ "-X:ILDebug", "Output generated IL code to a text file for debugging" }, 
									{ "-X:MaxRecursion", "Set the maximum recursion level" }, 
									{ "-X:MTA", "Run in multithreaded apartment" }, 
									{ "-X:NoOptimize", "Disable JIT optimization in generated code" }, 
									{ "-X:NoTraceback", "Do not emit traceback code" }, 
									{ "-X:PassExceptions", "Do not catch exceptions that are unhandled by jscript code" }, 
									{ "-X:PrivateBinding", "Enable binding to private members" }, 
									{ "-X:SaveAssemblies", "Save generated assemblies" }, 
									{ "-X:ShowClrExceptions", "Display CLS Exception information" }, 
									{ "-X:SlowOps", "Enable fast ops" }, 
									{ "-X:StaticMethods", "Generate static methods only" }, 
									{ "-X:TabCompletion", "Enable TabCompletion mode" }, 
									{ "-X:TrackPerformance", "Track performance sensitive areas" }};

			environmentVariables = null;
			comments = null;

		}

		public override void Parse(string[] args)
		{
			base.Parse (args);
		}

		protected override void ParseArgument(string arg)
		{
			//TODO usage parsing
			throw new NotImplementedException();
		}
		
		public override ConsoleOptions ConsoleOptions {
			get { return consoleOptions; }
			set { consoleOptions = value; }
		}

		public override Microsoft.Scripting.EngineOptions EngineOptions	{
			get { return engineOptions; }
			set { engineOptions = value; }
		}
	}
}
