using System;
using System.Collections;
using System.IO;
using System.Security.Policy;
using System.Threading;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Mono.XsltDebugger
{
	public class XsltDebuggerService
	{
		XPathDocument style;
		XPathDocument input;
		XmlResolver xml_resolver;
		Evidence evidence;
		ArrayList breakpoints = new ArrayList ();
		XsltDebuggerSession current_run;
		XmlNamespaceManager nsmgr = new XmlNamespaceManager (new NameTable ());
		ThreadManager thread_manager;

		public XsltDebuggerService ()
		{
		}

		public event EventHandler BreakpointMatched;

		public event EventHandler TransformCompleted;

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
			thread_manager = new ThreadManager (current_run);

			// set breakpoints
			current_run.Executed += OnExecute;

			thread_manager.StartTransform ();
		}

		public virtual void Interrupt ()
		{
			if (thread_manager == null)
				throw new XsltDebuggerException ("No active transformation to interrupt");
			thread_manager.InterruptTransform ();
		}

		public virtual void Resume ()
		{
			if (thread_manager == null)
				throw new XsltDebuggerException ("No active transformation to interrupt");
			thread_manager.ResumeTransform ();
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

			OnTransformCompleted ();
		}

		// invoked inside transformation thread.
		void OnExecute (object o, XsltExecuteEventArgs args)
		{
			if (!Break (args.Context))
				return;
			thread_manager.DispatchBreakpointMatch (o, args);
		}

		// invoked from ThreadManager notification thread
		void OnBreakpointMatch (object o, XsltExecuteEventArgs args)
		{
			if (BreakpointMatched != null)
				BreakpointMatched (o, args);
		}

		void OnTransformCompleted ()
		{
			if (TransformCompleted != null)
				TransformCompleted (null, null);
			thread_manager.Dispose ();
		}

		bool Break (XsltDebuggerContext ctx)
		{
			// FIXME: support StepIn,StepNext,StepOut etc.

			foreach (XsltDebuggerBreakpoint bp in breakpoints)
				if (bp.Match (ctx))
					return true;
			return false;
		}

		class ThreadManager : IDisposable
		{
			XsltDebuggerSession session;
			Thread run_thread, notify_thread;
			ManualResetEvent notify_handle, trans_handle;

			// used between notification thread and transformation thread
			object event_sender;
			XsltExecuteEventArgs event_args;

			public ThreadManager (XsltDebuggerSession session)
			{
				this.session = session;
			}

			public void Dispose ()
			{
				if (notify_thread != null) {
					notify_thread.Abort ();
					notify_thread = null;
				}
				if (run_thread != null) {
					run_thread.Abort ();
					run_thread = null;
				}
			}

			// It kicks the transform thread and returns.
			public void StartTransform ()
			{
				notify_handle = new ManualResetEvent (false);
				trans_handle = new ManualResetEvent (false);

				run_thread = new Thread (delegate () {
					try {
						session.Run ();
					} catch (ThreadAbortException) {
						Thread.ResetAbort ();
					}
				});
				notify_thread = new Thread (delegate () {
					try {
						while (true) {
							notify_handle.Reset ();
							notify_handle.WaitOne ();
							session.Debugger.OnBreakpointMatch (event_sender, event_args);
						}
					} catch (ThreadAbortException) {
						Thread.ResetAbort ();
					}
				});

				notify_thread.Start ();
				run_thread.Start ();
			}

			public void InterruptTransform ()
			{
				trans_handle.WaitOne ();
			}

			public void ResumeTransform ()
			{
				trans_handle.Set ();
			}

			public void DispatchBreakpointMatch (object o, XsltExecuteEventArgs args)
			{
				this.event_sender = o;
				this.event_args = args;
				notify_handle.Set ();
				trans_handle.WaitOne ();
			}
		}
	}
}
