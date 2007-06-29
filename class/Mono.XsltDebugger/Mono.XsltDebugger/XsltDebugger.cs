using System;
using System.Collections;
using System.IO;
using System.Security.Policy;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Mono.XsltDebugger
{
	public class XsltDebugger
	{
		XPathDocument style;
		XPathDocument input;
		XmlResolver xml_resolver;
		Evidence evidence;
		ArrayList breakpoints = new ArrayList ();
		XsltDebuggerSession current_run;
		XmlNamespaceManager nsmgr = new XmlNamespaceManager (new NameTable ());

		public XsltDebugger ()
		{
		}

		public XmlNamespaceManager NamespaceManager {
			get { return nsmgr; }
		}

		public XsltDebuggerSession CurrentRun {
			get { return current_run; }
		}

		public XPathDocument Stylesheet {
			get { return style; }
			set {
				if (current_run != null)
					throw new InvalidOperationException ("Cannot set stylesheet because debug is in progress");
				style = value;
			}
		}

		public XPathDocument Input {
			get { return input; }
			set {
				if (current_run != null)
					throw new InvalidOperationException ("Cannot set input document because debug is in progress");
				input = value;
			}
		}

		public XmlResolver XmlResolver {
			set { xml_resolver = value; }
		}

		public Evidence Evidence {
			get { return evidence; }
			set { evidence = value; }
		}

		public IList Breakpoints {
			get { return breakpoints; }
		}

		public void AddBreakpoint (XsltDebuggerBreakpoint point)
		{
			if (point == null)
				throw new ArgumentNullException ("point");
			foreach (XsltDebuggerBreakpoint bp in breakpoints)
				if (bp.Equals (point))
					return;
			breakpoints.Add (point);
		}

		public void RemoveBreakpoint (XsltDebuggerBreakpoint point)
		{
			if (point == null)
				throw new ArgumentNullException ("point");
			for (int i = 0; i < breakpoints.Count; i++)
				if (point.Equals (breakpoints [i])) {
					breakpoints.RemoveAt (i);
					return;
				}
		}

		public void Run ()
		{
			if (current_run != null) {
				if (WarnAndQueryExistingRun ())
					return;
				Abort ();
			}
			current_run = new XsltDebuggerSession (this);

			// set breakpoints
			current_run.Executed += OnExecute;

			current_run.Run ();
		}

		public virtual void Interrupt ()
		{
			throw new NotImplementedException ();
		}

		public virtual void Resume ()
		{
			throw new NotImplementedException ();
		}

		public virtual void Abort ()
		{
			if (current_run != null)
				current_run.Dispose ();
			current_run = null;
		}

		protected virtual bool WarnAndQueryExistingRun ()
		{
			// warn something and return true if it should stop new run.
			return false;
		}

		// customizible
		protected internal virtual void LoadStylesheet (XslTransform transform)
		{
			if (transform == null)
				throw new ArgumentNullException ("transform");
			if (style == null)
				throw new XsltDebuggerException ("Stylesheet document is not specified");
			transform.Load (style, xml_resolver, evidence);
		}

		// customizible
		protected internal virtual void Transform (XslTransform transform, XmlWriter writer)
		{
			if (transform == null)
				throw new ArgumentNullException ("transform");
			if (writer == null)
				throw new ArgumentNullException ("writer");
			if (input == null)
				throw new XsltDebuggerException ("Input document is not specified");
			transform.Transform (input, null, writer, xml_resolver);
		}

		void OnExecute (object o, XsltExecuteEventArgs args)
		{
			if (!Break (args.Context))
				return;
Console.WriteLine ("Match");
		}

		bool Break (XsltDebuggerContext ctx)
		{
			// FIXME: support StepIn,StepNext,StepOut etc.

			foreach (XsltDebuggerBreakpoint bp in breakpoints)
				if (bp.Match (ctx))
					return true;
			return false;
		}
	}
}
