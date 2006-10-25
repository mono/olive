using System;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Transform
{
	class Transform
	{
		public static void Main (string [] args)
		{
			//XmlDocument xml = new XmlDocument ();
			//xml.Load (args [0]);
			XPathDocument xml = new XPathDocument (args [0]);

			XslTransform xsl = new XslTransform ();
			xsl.Load (args [1]);

			XsltArgumentList xsltArgs = new XsltArgumentList ();
			for (int i = 2; i < args.Length; i++) {
				string [] pair = args [i].Split ('=');
				xsltArgs.AddParam (pair [0], String.Empty, pair [1]);
			}

			xsl.Transform (xml, xsltArgs, Console.Out);
		}
	}
}
