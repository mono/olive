using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Mono.XsltDebugger
{
	public class XsltCompileEventArgs : EventArgs
	{
		XPathNavigator nav;

		public XsltCompileEventArgs (XPathNavigator nav)
		{
			this.nav = nav;
		}

		public XPathNavigator StyleElement {
			get { return nav; }
		}
	}
}

