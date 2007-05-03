using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using NUnit.Framework;

namespace MonoTests.System.Xml.Linq
{
	[TestFixture]
	public class XDocumentTest
	{
		[Test]
		public void Load1 ()
		{
			string xml = "<?xml version='1.0'?><root />";

			XDocument doc = XDocument.Load (new StringReader (xml));
			Assert.IsTrue (doc.FirstNode is XElement, "#1");
			Assert.IsTrue (doc.LastNode is XElement, "#2");
			Assert.IsNull (doc.NextNode, "#3");
			Assert.IsNull (doc.PreviousNode, "#4");
			Assert.AreEqual (1, new List<XNode> (doc.Nodes ()).Count, "#5");
		}
	}
}
