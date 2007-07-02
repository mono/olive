using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Mono.XsltDebugger
{
	public class XsltDebuggerSession : IDisposable
	{
		XsltDebuggerService debugger;
		XsltInjector injector;
		XslTransform transform;
		XmlNodeWriter output;
		Hashtable custom_cache;

		public XsltDebuggerSession (XsltDebuggerService debugger)
		{
			this.debugger = debugger;
			Init ();
		}

		public XsltDebuggerService Debugger {
			get { return debugger; }
		}

		public XmlNode OutputNode {
			get { return output.Current; }
		}

		public XmlWriter Output {
			get { return output; }
		}

		public Hashtable CustomCache {
			get { return custom_cache; }
		}

		public void Dispose ()
		{
			debugger = null;
			transform = null;
			output = null;
		}

		// It is indicated by ThreadManager.StartDebug().
		internal void Run ()
		{
			custom_cache = new Hashtable ();
			transform = (XslTransform) Activator.CreateInstance (typeof (XslTransform), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance, null, new object [] {injector}, CultureInfo.CurrentCulture);
			debugger.LoadStylesheet (transform);
			output = new XmlNodeWriter (false);
			debugger.Transform (transform, output);

			if (Completed != null)
				Completed (this, new XsltCompleteEventArgs ());
		}

		public XsltDebuggerContext CreateContext (XPathNodeIterator currentNodeset, XPathNavigator stylesheetElement, XsltContext xsltContext)
		{
			return new XsltDebuggerContext (this, currentNodeset, stylesheetElement, xsltContext);
		}

		void Init ()
		{
			injector = new XsltInjector (this);
			injector.Compiled += OnCompiled;
			injector.Executed += OnExecute;
		}

		void OnCompiled (object o, XsltCompileEventArgs e)
		{
			if (Compiled != null)
				Compiled (o, e);
		}

		void OnExecute (object o, XsltExecuteEventArgs e)
		{
			if (Executed != null)
				Executed (o, e);
		}

		public event XsltCompileEventHandler Compiled;
		public event XsltExecuteEventHandler Executed;
		public event XsltCompleteEventHandler Completed;
	}
}

