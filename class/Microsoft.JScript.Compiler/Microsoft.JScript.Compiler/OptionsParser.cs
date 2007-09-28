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
			GlobalOptions = GetDefaultGlobalOptions ();
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

		private Microsoft.Scripting.Hosting.ScriptDomainOptions GetDefaultGlobalOptions ()
		{
			return new Microsoft.Scripting.Hosting.ScriptDomainOptions ();
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
			switch (arg) {
				case "-c" :
					this.consoleOptions.Command = PopNextArg ();
					break;
				case "-h":
					this.ConsoleOptions.PrintUsageAndExit = true;
					break;
				case "-V":
					this.ConsoleOptions.PrintVersionAndExit = true;
					break;
				case "-O":
					this.GlobalOptions.OptimizeEnvironments = true;
					break;
				case "-i":
					this.ConsoleOptions.Introspection = true;
					break;
				case "-v":
					this.GlobalOptions.Verbose = true;
					break;
				case "-D":
					this.GlobalOptions.EngineDebug = true; // not sure for this one be cause lot of debug bool
					break;
				case "-u":
					this.GlobalOptions.BufferedStandardOutAndError = false;
					break;
				case "-OO":
					this.GlobalOptions.StripDocStrings = true;
					break;
				case "-X:AutoIndent" :
					this.ConsoleOptions.AutoIndent = true;
					break;
				case "-X:AssembliesDir":
					this.GlobalOptions.BinariesDirectory = PopNextArg ();
					break;
				case "-X:ColorfulConsole":
					this.ConsoleOptions.ColorfulConsole = true;
					break;
				case "-X:ExceptionDetail":
					this.EngineOptions.ExceptionDetail = true;
					break;
				case "-X:FastEval":
					this.EngineOptions.FastEvaluation = true;
					break;
				case "-X:Frames":
					this.GlobalOptions.Frames = true;
					break;
				case "-X:GenerateAsSnippets":
					this.GlobalOptions.GenerateModulesAsSnippets = true;
					break;
				case "-X:ILDebug":
					// not sure here
					this.EngineOptions.ClrDebuggingEnabled = true;
					this.GlobalOptions.AssemblyGenAttributes |= Microsoft.Scripting.Internal.Generation.AssemblyGenAttributes.ILDebug;
					break;
				case "-X:MaxRecursion":
					int result =0;
					try {
						result = Int32.Parse (PopNextArg ());
						((Microsoft.JScript.Compiler.EngineOptions)EngineOptions).MaximumRecursion = result;
					} catch {
						Console.WriteLine ("Max recursion must be a number");
						//TODO find the out better than console
					}
					break;
				case "-X:MTA":
					//TODO here not found!
					break;
				case "-X:NoOptimize":
					// not sure here
					this.GlobalOptions.OptimizeEnvironments = false;
					this.GlobalOptions.AssemblyGenAttributes |= Microsoft.Scripting.Internal.Generation.AssemblyGenAttributes.DisableOptimizations;
					break;
				case "-X:NoTraceback":
					this.GlobalOptions.DynamicStackTraceSupport = false;
					break;
				case "-X:PassExceptions" :
					this.ConsoleOptions.HandleExceptions = false;
					break;
				case "-X:PrivateBinding":
					this.GlobalOptions.PrivateBinding = true;
					break;
				case "-X:SaveAssemblies":
					this.GlobalOptions.AssemblyGenAttributes |= Microsoft.Scripting.Internal.Generation.AssemblyGenAttributes.SaveAndReloadAssemblies;
					break;
				case "-X:ShowClrExceptions":
					this.engineOptions.ShowClrExceptions = true;
					break;
				case "-X:SlowOps":
					this.GlobalOptions.FastOps = true; // not sure for this one but no other talking about ops
					break;
				case "-X:StaticMethods":
					this.GlobalOptions.AssemblyGenAttributes |= Microsoft.Scripting.Internal.Generation.AssemblyGenAttributes.GenerateStaticMethods;
					break;
				case "-X:TabCompletion":
					this.ConsoleOptions.TabCompletion = true;
					break;
				case "-X:TrackPerformance":
					this.GlobalOptions.TrackPerformance = true;
					break;
				default:
					consoleOptions.FileName = arg;
					break;
			}
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
