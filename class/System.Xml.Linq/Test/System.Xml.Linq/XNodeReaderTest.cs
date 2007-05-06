using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using NUnit.Framework;

namespace MonoTests.System.Xml.Linq
{
	[TestFixture]
	public class XNodeReaderTest
	{
		[Test]
		public void CreateReader1 ()
		{
			string xml = "<root><foo a='v' /><bar></bar><baz>simple text<!-- comment --><mixed1 /><mixed2><![CDATA[cdata]]><?some-pi with-data ?></mixed2></baz></root>";
			XDocument doc = XDocument.Parse (xml);
Console.WriteLine (((XElement) ((XElement) doc.Root.LastNode).LastNode).LastNode.PreviousNode.NodeType);
			XmlReader xr = doc.CreateReader ();
			StringWriter sw = new StringWriter ();
			XmlWriterSettings s = new XmlWriterSettings ();
			s.OmitXmlDeclaration = true;
			XmlWriter xw = XmlWriter.Create (sw, s);
			while (!xr.EOF)
				xw.WriteNode (xr, false);
			xw.Close ();
			Assert.AreEqual (xml.Replace ('\'', '"'), sw.ToString ());
		}

		[Test]
		public void CreateReader2 ()
		{
			string xml = "<?xml version='1.0' encoding='utf-16'?><root><foo a='v' /><bar></bar><baz>simple text<!-- comment --><mixed1 /><mixed2><![CDATA[cdata]]><?some-pi with-data ?></mixed2></baz></root>";
			XDocument doc = XDocument.Parse (xml);
Console.WriteLine (((XElement) ((XElement) doc.Root.LastNode).LastNode).LastNode.PreviousNode.NodeType);
			XmlReader xr = doc.CreateReader ();
			StringWriter sw = new StringWriter ();
			XmlWriter xw = XmlWriter.Create (sw);
			while (!xr.EOF)
				xw.WriteNode (xr, false);
			xw.Close ();
			Assert.AreEqual (xml.Replace ('\'', '"'), sw.ToString ());
		}
	}
}
