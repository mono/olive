using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Core;
using NUnit.Framework;
using Microsoft.JScript.Compiler;
using Microsoft.JScript.Compiler.Shell;

namespace MonoTests.Microsoft.JScript.Compiler
{
	[TestFixture]
	public class OptionsParserTest
	{
		OptionsParser options;

		[Test]
		public void GetDefaultConsoleOptionsTest ()
		{
			options = new OptionsParser ();
			Assert.IsInstanceOfType (typeof (ConsoleOptions), options.GetDefaultConsoleOptions (), "#1");
		}

		[Test]
		public void GetDefaultEngineOptionsTest ()
		{
			options = new OptionsParser ();
			Assert.IsInstanceOfType (typeof (EngineOptions), options.GetDefaultEngineOptions (), "#2");
		}

		[Test]
		public void GetHelpTest ()
		{
			options = new OptionsParser ();
			string usage = string.Empty;
			string[,] optionsParsertext = new string[30, 2];
			string[,] environlentVariables = new string[10, 10];
			string comments = string.Empty;
			options.GetHelp (out usage, out optionsParsertext, out environlentVariables, out comments);
			Assert.AreEqual ("[options] [file|- [arguments]]", usage, "#2.1");

			Assert.AreEqual (58, optionsParsertext.Length, "#2.2.0");
			Assert.AreEqual ("-c cmd", optionsParsertext[0, 0], "#2.2.1");
			Assert.AreEqual ("Program passed in as string (terminates option list)", optionsParsertext[0, 1], "#2.2.2");
			Assert.AreEqual ("-h", optionsParsertext[1, 0], "#2.2.3");
			Assert.AreEqual ("Display usage", optionsParsertext[1, 1], "#2.2.4");
			Assert.AreEqual ("-V", optionsParsertext[2, 0], "#2.2.5");
			Assert.AreEqual ("Print the engine version number and exit", optionsParsertext[2, 1], "#2.2.6");
			Assert.AreEqual ("-O", optionsParsertext[3, 0], "#2.2.7");
			Assert.AreEqual ("Enable optimizations", optionsParsertext[3, 1], "#2.2.8");
			Assert.AreEqual ("-i", optionsParsertext[4, 0], "#2.2.9");
			Assert.AreEqual ("Inspect interactively after running script", optionsParsertext[4, 1], "#2.2.10");
			Assert.AreEqual ("-v", optionsParsertext[5, 0], "#2.2.11");
			Assert.AreEqual ("Verbose", optionsParsertext[5, 1], "#2.2.12");
			Assert.AreEqual ("-D", optionsParsertext[6, 0], "#2.2.13");
			Assert.AreEqual ("EngineDebug mode", optionsParsertext[6, 1], "#2.2.14");
			Assert.AreEqual ("-u", optionsParsertext[7, 0], "#2.2.15");
			Assert.AreEqual ("Unbuffered stdout & stderr", optionsParsertext[7, 1], "#2.2.16");
			Assert.AreEqual ("-OO", optionsParsertext[8, 0], "#2.2.17");
			Assert.AreEqual ("Remove doc-strings in addition to the -O optimizations", optionsParsertext[8, 1], "#2.2.18");
			Assert.AreEqual ("-X:AutoIndent", optionsParsertext[9, 0], "#2.2.19");
			Assert.AreEqual ("", optionsParsertext[9, 1], "#2.2.20");
			Assert.AreEqual ("-X:AssembliesDir", optionsParsertext[10, 0], "#2.2.21");
			Assert.AreEqual ("Set the directory for saving generated assemblies", optionsParsertext[10, 1], "#2.2.22");
			Assert.AreEqual ("-X:ColorfulConsole", optionsParsertext[11, 0], "#2.2.23");
			Assert.AreEqual ("Enable ColorfulConsole", optionsParsertext[11, 1], "#2.2.24");
			Assert.AreEqual ("-X:ExceptionDetail", optionsParsertext[12, 0], "#2.2.25");
			Assert.AreEqual ("Enable ExceptionDetail mode", optionsParsertext[12, 1], "#2.2.26");
			Assert.AreEqual ("-X:FastEval", optionsParsertext[13, 0], "#2.2.27");
			Assert.AreEqual ("Enable fast eval", optionsParsertext[13, 1], "#2.2.28");
			Assert.AreEqual ("-X:Frames", optionsParsertext[14, 0], "#2.2.29");
			Assert.AreEqual ("Generate custom frames", optionsParsertext[14, 1], "#2.2.30");
			Assert.AreEqual ("-X:GenerateAsSnippets", optionsParsertext[15, 0], "#2.2.31");
			Assert.AreEqual ("Generate code to run in snippet mode", optionsParsertext[15, 1], "#2.2.32");
			Assert.AreEqual ("-X:ILDebug", optionsParsertext[16, 0], "#2.2.33");
			Assert.AreEqual ("Output generated IL code to a text file for debugging", optionsParsertext[16, 1], "#2.2.34");
			Assert.AreEqual ("-X:MaxRecursion", optionsParsertext[17, 0], "#2.2.35");
			Assert.AreEqual ("Set the maximum recursion level", optionsParsertext[17, 1], "#2.2.36");
			Assert.AreEqual ("-X:MTA", optionsParsertext[18, 0], "#2.2.37");
			Assert.AreEqual ("Run in multithreaded apartment", optionsParsertext[18, 1], "#2.2.38");
			Assert.AreEqual ("-X:NoOptimize", optionsParsertext[19, 0], "#2.2.39");
			Assert.AreEqual ("Disable JIT optimization in generated code", optionsParsertext[19, 1], "#2.2.40");
			Assert.AreEqual ("-X:NoTraceback", optionsParsertext[20, 0], "#2.2.41");
			Assert.AreEqual ("Do not emit traceback code", optionsParsertext[20, 1], "#2.2.42");
			Assert.AreEqual ("-X:PassExceptions", optionsParsertext[21, 0], "#2.2.43");
			Assert.AreEqual ("Do not catch exceptions that are unhandled by jscript code", optionsParsertext[21, 1], "#2.2.44");
			Assert.AreEqual ("-X:PrivateBinding", optionsParsertext[22, 0], "#2.2.45");
			Assert.AreEqual ("Enable binding to private members", optionsParsertext[22, 1], "#2.2.46");
			Assert.AreEqual ("-X:SaveAssemblies", optionsParsertext[23, 0], "#2.2.47");
			Assert.AreEqual ("Save generated assemblies", optionsParsertext[23, 1], "#2.2.48");
			Assert.AreEqual ("-X:ShowClrExceptions", optionsParsertext[24, 0], "#2.2.49");
			Assert.AreEqual ("Display CLS Exception information", optionsParsertext[24, 1], "#2.2.50");
			Assert.AreEqual ("-X:SlowOps", optionsParsertext[25, 0], "#2.2.51");
			Assert.AreEqual ("Enable fast ops", optionsParsertext[25, 1], "#2.2.52");
			Assert.AreEqual ("-X:StaticMethods", optionsParsertext[26, 0], "#2.2.53");
			Assert.AreEqual ("Generate static methods only", optionsParsertext[26, 1], "#2.2.54");
			Assert.AreEqual ("-X:TabCompletion", optionsParsertext[27, 0], "#2.2.55");
			Assert.AreEqual ("Enable TabCompletion mode", optionsParsertext[27, 1], "#2.2.56");
			Assert.AreEqual ("-X:TrackPerformance", optionsParsertext[28, 0], "#2.2.57");
			Assert.AreEqual ("Track performance sensitive areas", optionsParsertext[28, 1], "#2.2.58");

			Assert.IsNull ( environlentVariables, "#2.3.0");

			Assert.IsNull (comments, "#2.4");
		}
	}
}
