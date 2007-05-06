using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace System.Xml.XPath
{
	public static class Extensions
	{
		public static XPathNavigator CreateNavigator (this XNode node)
		{
			return CreateNavigator (node, new NameTable ());
		}

		public static XPathNavigator CreateNavigator (this XNode node, XmlNameTable nameTable)
		{
			return new XNodeNavigator (node, nameTable);
		}

		public static object XPathEvaluate (this XNode node, string expression)
		{
			return XPathEvaluate (node, expression, null);
		}

		public static object XPathEvaluate (this XNode node, string expression, IXmlNamespaceResolver nsResolver)
		{
			return CreateNavigator (node).Evaluate (expression, nsResolver);
		}

		public static XElement XPathSelectElement (this XNode node, string xpath)
		{
			return XPathSelectElement (node, xpath, null);
		}

		public static XElement XPathSelectElement (this XNode node, string xpath, IXmlNamespaceResolver nsResolver)
		{
			XPathNavigator nav = CreateNavigator (node).SelectSingleNode (xpath, nsResolver);
			return nav.UnderlyingObject as XElement;
		}

		public static IEnumerable<XElement> XPathSelectElements (this XNode node, string xpath)
		{
			return XPathSelectElements (node, xpath, null);
		}

		public static IEnumerable<XElement> XPathSelectElements (this XNode node, string xpath, IXmlNamespaceResolver nsResolver)
		{
			XPathNodeIterator iter = CreateNavigator (node).Select (xpath, nsResolver);
			foreach (XPathNavigator nav in iter)
				if (nav.UnderlyingObject is XElement)
					yield return (XElement) nav.UnderlyingObject;
		}
	}
}

