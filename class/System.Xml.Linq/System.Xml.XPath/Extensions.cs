using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace System.Xml.XPath
{
	[MonoTODO]
	public static class Extensions
	{
		[MonoTODO]
		public static XPathNavigator CreateNavigator (this XNode node)
		{
			return CreateNavigator (node, new NameTable ());
		}

		[MonoTODO]
		public static XPathNavigator CreateNavigator (this XNode node, XmlNameTable nameTable)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static object XPathEvaluate (this XNode node, string expression)
		{
			return XPathEvaluate (node, expression, null);
		}

		[MonoTODO]
		public static object XPathEvaluate (this XNode node, string expression, IXmlNamespaceResolver nsResolver)
		{
			return CreateNavigator (node).Evaluate (expression, nsResolver);
		}

		[MonoTODO]
		public static XElement XPathSelectElement (this XNode node, string xpath)
		{
			return XPathSelectElement (node, xpath, null);
		}

		[MonoTODO]
		public static XElement XPathSelectElement (this XNode node, string xpath, IXmlNamespaceResolver nsResolver)
		{
			XPathNavigator nav = CreateNavigator (node).SelectSingleNode (xpath, nsResolver);
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static IEnumerable<XElement> XPathSelectElements (this XNode node, string xpath)
		{
			return XPathSelectElements (node, xpath, null);
		}

		[MonoTODO]
		public static IEnumerable<XElement> XPathSelectElements (this XNode node, string xpath, IXmlNamespaceResolver nsResolver)
		{
			XPathNodeIterator iter = CreateNavigator (node).Select (xpath, nsResolver);
			throw new NotImplementedException ();
		}
	}
}

