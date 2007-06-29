using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Mono.XsltDebugger
{
	public class XsltDebuggerContext
	{
		XsltDebuggerSession session;
		XPathNodeIterator nodes;
		XPathNavigator style;
		XsltContext xsltctx;

		public XsltDebuggerContext (XsltDebuggerSession session, XPathNodeIterator currentNodeset, XPathNavigator stylesheetElement, XsltContext xsltContext)
		{
			this.session = session;
			this.nodes = currentNodeset;
			this.style = stylesheetElement;
			this.xsltctx = xsltContext;
		}

		public XsltDebuggerSession Session {
			get { return session; }
		}

		// I wonder if we should expose current nodeset

		// It is not desirable to have it public, but it is needed
		// to set XmlNamespaceManager to XPathExpression in the
		// debugger. So, users who write custom breakpoint rules
		// may also need it.
		public XsltContext XsltContext {
			get { return xsltctx; }
		}

		public XPathNavigator StylesheetElement {
			get { return style; }
		}
	}
}

