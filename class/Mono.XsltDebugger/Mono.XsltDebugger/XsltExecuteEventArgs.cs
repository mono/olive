using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Mono.XsltDebugger
{
	public class XsltExecuteEventArgs : EventArgs
	{
		XsltDebuggerContext ctx;

		public XsltExecuteEventArgs (XsltDebuggerContext ctx)
		{
			this.ctx = ctx;
		}

		public XsltDebuggerContext Context {
			get { return ctx; }
		}
	}
}
