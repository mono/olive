using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Mono.XsltDebugger
{
	public class XsltInjector
	{
		XsltDebuggerSession session;

		public XsltInjector (XsltDebuggerSession session)
		{
			this.session = session;
		}

		public XsltDebuggerSession Session {
			get { return session; }
		}

		protected virtual void OnCompile (XPathNavigator stylesheetElement)
		{
			if (Compiled != null)
				Compiled (this, new XsltCompileEventArgs (stylesheetElement));
		}

		protected virtual void OnExecute (XPathNodeIterator currentNodeset, XPathNavigator stylesheetElement, XsltContext xsltContext)
		{
			if (Executed != null)
				Executed (this, new XsltExecuteEventArgs (new XsltDebuggerContext (session, currentNodeset, stylesheetElement, xsltContext)));
		}

		public event XsltCompileEventHandler Compiled;
		public event XsltExecuteEventHandler Executed;
	}
}

