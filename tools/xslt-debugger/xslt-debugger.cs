using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace Mono.XsltDebugger
{
	public class XsltDebuggerConsole
	{
		static readonly char [] wsChars = new char [] {' ', '\n', '\r', '\t'};

		public static void Main (string [] args)
		{
			new XsltDebuggerConsole ().Run (args);
		}

		int verbose; // 1: report exception details
		XsltDebugger debugger = new XsltDebugger ();
		bool completed, debugger_exit;
		ArrayList commands = new ArrayList ();

		public XsltDebuggerConsole ()
		{
			commands.Add (new HelpCommand ());
			commands.Add (new QuitCommand ());
			commands.Add (new RunCommand ());
			commands.Add (new AddXPathBreakCommand ());
			commands.Add (new AddStylesheetBreakCommand ());
			commands.Add (new ListBreakpointCommand ());
			commands.Add (new AddXmlnsCommand ());
			commands.Add (new RemoveXmlnsCommand ());
			commands.Add (new ListXmlnsCommand ());
			commands.Add (new ShowOutputCommand ());
			commands.Add (new BatchProcessCommand ());
		}

		void ShowUsage ()
		{
			Console.Error.WriteLine ("xslt-debugger [-v] [stylesheet] [input-document]");
		}

		public void SignalQuitDebugger ()
		{
			debugger_exit = true;
		}

		public void Run (string [] args)
		{
			try {
/*
				// FIXME: CurrentRun does not exist yet
				debugger.CurrentRun.Completed += delegate (object o, XsltCompleteEventArgs e) {
					Console.WriteLine ("XSL Transformation completed.");
					completed = true;
				};
*/

				foreach (string arg in args) {
					if (arg == "--verbose" || arg == "-v")
						verbose++;
					else if (debugger.Stylesheet == null)
						debugger.Stylesheet = new XPathDocument (arg);
					else
						debugger.Input = new XPathDocument (arg);
				}

				ProcessUserInteraction ();

			} catch (Exception ex) {
				if (verbose > 0)
					Console.WriteLine (ex);
				else
					Console.WriteLine (ex.Message);
			}
		}

		void ProcessUserInteraction ()
		{
			// continue until user select quit command
			while (!debugger_exit) {
				Console.Write ("[xslt] ");
				string cmdline = Console.ReadLine ();
				ProcessCommand (cmdline);
			}
		}

		void ProcessCommand (string cmdline)
		{
			int idx = cmdline.IndexOfAny (wsChars);
			string cmd = idx < 0 ? cmdline : cmdline.Substring (0, idx);
			string [] args = SplitString (cmdline);
			bool done = false;
			foreach (XsltDebuggerConsoleCommand cmdobj in commands) {
				if (!cmdobj.Match (cmd, args))
					continue;
				if (done)
					throw new XsltDebuggerException (String.Format ("Duplicate command match : {0}", cmdline));
				try {
					cmdobj.Process (this, args);
				} catch (XsltDebuggerException ex) {
					if (verbose > 0)
						Console.WriteLine (ex);
					else
						Console.WriteLine (ex.Message);
				}
				done = true;
			}
		}

		string [] SplitString (string s)
		{
			ArrayList args = new ArrayList (s.Split (wsChars));
			for (int i = 0; i < args.Count;) {
				if (String.Empty == args [i] as string)
					args.RemoveAt (i);
				else
					i++;
			}
			return args.ToArray (typeof (string)) as string [];
		}

		// commands

		public abstract class XsltDebuggerConsoleCommand
		{
			public abstract string UsageSummary { get; }
			public abstract string UsageDetails { get; }

			public abstract bool Match (string cmd, string [] args);

			public abstract void Process (XsltDebuggerConsole owner, string [] args);
		}

		public class QuitCommand : XsltDebuggerConsoleCommand
		{
			public override bool Match (string cmd, string [] args)
			{
				return cmd == "q" || cmd == "quit" || cmd == "exit";
			}

			public override string UsageSummary {
				get { return "quit (q)\nexit"; }
			}

			public override string UsageDetails {
				get { return "Quits the debugger."; }
			}

			public override void Process (XsltDebuggerConsole owner, string [] args)
			{
				owner.SignalQuitDebugger ();
			}
		}

		public class HelpCommand : XsltDebuggerConsoleCommand
		{
			public override bool Match (string cmd, string [] args)
			{
				return cmd == "help";
			}

			public override string UsageSummary {
				get { return "help"; }
			}

			public override string UsageDetails {
				get { return "Show this help."; }
			}

			public override void Process (XsltDebuggerConsole owner, string [] args)
			{
				foreach (XsltDebuggerConsoleCommand cmdobj in owner.commands) {
					Console.WriteLine (cmdobj.UsageSummary);
					foreach (string s in cmdobj.UsageDetails.Split ('\n')) {
						Console.Write ("\t");
						Console.WriteLine (s);
					}
				}
				Console.WriteLine ("clear [number]");
				Console.WriteLine ("\t Removes the specified breakpoint by breakpoint index.");
				Console.WriteLine ("list breakpoints (bp)");
				Console.WriteLine ("\t Shows the list of breakpoints.");
			}
		}

		public class RunCommand : XsltDebuggerConsoleCommand
		{
			public override bool Match (string cmd, string [] args)
			{
				return cmd == "run";
			}

			public override string UsageSummary {
				get { return "run"; }
			}

			public override string UsageDetails {
				get { return "Runs a transform."; }
			}

			public override void Process (XsltDebuggerConsole owner, string [] args)
			{
				owner.debugger.Run ();
			}
		}

		public abstract class AddBreakpointCommand : XsltDebuggerConsoleCommand
		{
			public abstract XsltDebuggerBreakpoint CreateBreakpoint (string [] args);

			public override void Process (XsltDebuggerConsole run, string [] args)
			{
				run.debugger.AddBreakpoint (CreateBreakpoint (args));
			}
		}

		public class AddXPathBreakCommand : AddBreakpointCommand
		{
			public override bool Match (string cmd, string [] args)
			{
				// FIXME: remove this extra "list" check hack.
				return cmd == "break" && args.Length == 2 && args [1] != "list";
			}

			public override string UsageSummary {
				get { return "break <xpath>"; }
			}

			public override string UsageDetails {
				get { return "Sets a breakpoint for output to hit XPath match."; }
			}

			public override XsltDebuggerBreakpoint CreateBreakpoint (string [] args)
			{
				return new XsltOutputXPathBreakpoint (args [1]);
			}
		}

		public class AddStylesheetBreakCommand : AddBreakpointCommand
		{
			public override bool Match (string cmd, string [] args)
			{
				return cmd == "break" && (args.Length == 3 || args.Length == 4);
			}

			public override string UsageSummary {
				get { return "break <line> <column> [uri]"; }
			}

			public override string UsageDetails {
				get { return @"Sets a breakpoint to match specified stylesheet element
at (<line>,<column>) ([uri] is the primary stylesheet by default)."; }
			}

			public override XsltDebuggerBreakpoint CreateBreakpoint (string [] args)
			{
				return new XsltStylesheetBreakpoint (args.Length == 3 ? null : args [3], int.Parse (args [1]), int.Parse (args [2]));
			}
		}

		public class ListBreakpointCommand : XsltDebuggerConsoleCommand
		{
			public override bool Match (string cmd, string [] args)
			{
				return cmd == "break" && args.Length > 1 && args [1] == "list";
			}

			public override string UsageSummary {
				get { return "break list"; }
			}

			public override string UsageDetails {
				get { return "Lists the registered breakpoints."; }
			}

			public override void Process (XsltDebuggerConsole run, string [] args)
			{
				int i = 0;
				foreach (XsltDebuggerBreakpoint bp in run.debugger.Breakpoints) {
					Console.WriteLine ("{0} {1}", i, bp.ToSummaryString ());
					i++;
				}
			}
		}

		public class AddXmlnsCommand : XsltDebuggerConsoleCommand
		{
			public override bool Match (string cmd, string [] args)
			{
				return cmd == "xmlns" && (args.Length == 3 || args.Length == 4) && args [1] == "add";
			}

			public override string UsageSummary {
				get { return "xmlns add [prefix] <uri>"; }
			}

			public override string UsageDetails {
				get { return @"Adds a namespace mapping from [prefix] ('' by default) to <uri> used
to resolve prefixes in XPath."; }
			}

			public override void Process (XsltDebuggerConsole run, string [] args)
			{
				string prefix = args.Length == 4 ? args [2] : String.Empty;
				string ns = args [args.Length - 1];
				run.debugger.NamespaceManager.AddNamespace (prefix, ns);
				Console.WriteLine ("Added xmlns {0}->{1}", prefix, ns);
			}
		}

		public class RemoveXmlnsCommand : XsltDebuggerConsoleCommand
		{
			public override bool Match (string cmd, string [] args)
			{
				return cmd == "xmlns" && (args.Length == 2 || args.Length == 3) && args [1] == "remove";
			}

			public override string UsageSummary {
				get { return "xmlns remove [prefix]"; }
			}

			public override string UsageDetails {
				get { return @"Removes a namespace mapping by [prefix] ('' by default) used to
resolve prefixes in XPath."; }
			}

			public override void Process (XsltDebuggerConsole run, string [] args)
			{
				XmlNamespaceManager n = run.debugger.NamespaceManager;
				string prefix = args.Length == 3 ? args [2] : String.Empty;
				string ns = n.LookupNamespace (prefix);
				if (ns == null)
					throw new XsltDebuggerException ("Specified namespace prefix is not defined.");
				n.RemoveNamespace (prefix, ns);
				Console.WriteLine ("Removed xmlns {0}->{1}", prefix, ns);
			}
		}

		public class ListXmlnsCommand : XsltDebuggerConsoleCommand
		{
			public override bool Match (string cmd, string [] args)
			{
				return cmd == "xmlns" && args.Length > 1 && args [1] == "list";
			}

			public override string UsageSummary {
				get { return "xmlns list"; }
			}

			public override string UsageDetails {
				get { return "Lists a namespace mapping used to resolve prefixes in XPath."; }
			}

			public override void Process (XsltDebuggerConsole run, string [] args)
			{
				XmlNamespaceManager n = run.debugger.NamespaceManager;
				Console.WriteLine ("Default namespace : {0}", n.DefaultNamespace);
				foreach (string prefix in n)
					if (prefix.Length > 0)
						Console.WriteLine ("{0} -> {1}", prefix, n.LookupNamespace (prefix));
			}
		}

		public class ShowOutputCommand : XsltDebuggerConsoleCommand
		{
			public override bool Match (string cmd, string [] args)
			{
				return cmd == "output";
			}

			public override string UsageSummary {
				get { return "output [lines]"; }
			}

			public override string UsageDetails {
				get { return "Shows the transformation result within [lines] (default = 10)."; }
			}

			public override void Process (XsltDebuggerConsole run, string [] args)
			{
				StringWriter sw = new StringWriter ();
				XmlTextWriter xw = new XmlTextWriter (sw);
				xw.Formatting = Formatting.Indented;
				run.debugger.CurrentRun.OutputNode.WriteTo (xw);
				xw.Close ();
				int lines = args.Length > 1 ? int.Parse (args [1]) : 10;
				PrintLastLines (sw.ToString (), lines);
			}

			void PrintLastLines (string s, int lines)
			{
				ArrayList al = new ArrayList ();
				int start = s.Length - 1, pos;
				while ((pos = s.LastIndexOf ('\n', start)) >= 0) {
					al.Add (s.Substring (pos, start - pos + 1));
					if (lines == al.Count)
						break;
					start = pos - 1;
				}
				if (al.Count < lines && start >= 0)
					al.Add (s.Substring (0, start + 1));
				al.Reverse ();
				foreach (string l in al)
					Console.Write (l);
				Console.WriteLine ();
			}
		}

		public class BatchProcessCommand : XsltDebuggerConsoleCommand
		{
			public override bool Match (string cmd, string [] args)
			{
				return cmd == "batch";
			}

			public override string UsageSummary {
				get { return "batch <filename>"; }
			}

			public override string UsageDetails {
				get { return "Processes batch commands listed in <filename>."; }
			}

			public override void Process (XsltDebuggerConsole run, string [] args)
			{
				if (!File.Exists (args [1]))
					throw new XsltDebuggerException (String.Format ("File {0} does not exist", args [1]));
				Encoding enc = args.Length > 2 ? Encoding.GetEncoding (args [2]) : Encoding.Default;
				string content = null;
				using (StreamReader reader = new StreamReader (args [1], enc)) {
					content = reader.ReadToEnd ();
				}
				string [] lines = content.Split ('\n');
				for (int i = 1; i < lines.Length; i++) {
					string s = lines [i].Trim ();
					if (s.Length > 0)
						run.ProcessCommand (s);
				}
			}
		}
	}
}
