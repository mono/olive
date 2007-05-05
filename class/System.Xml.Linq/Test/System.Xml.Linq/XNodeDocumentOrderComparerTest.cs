using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

using NUnit.Framework;

namespace MonoTests.System.Xml.Linq
{
	[TestFixture]
	public class XNodeDocumentOrderComparerTest
	{
		[Test]
		public void CompareNulls ()
		{
			Assert.AreEqual (0, XNode.DocumentOrderComparer.Compare (null, null));
		}

		[Test]
		public void Compare1 ()
		{
			// ancestors/descendants
			XNodeDocumentOrderComparer c = XNode.DocumentOrderComparer;
			XElement el = XElement.Parse ("<foo><bar/></foo>");
			Assert.IsTrue (c.Compare (el, el.FirstNode) < 0, "#1-1");
			Assert.IsTrue (c.Compare (el.FirstNode, el) > 0, "#1-2");

			XDocument doc = XDocument.Parse ("<foo><bar/></foo>");
			Assert.IsTrue (c.Compare (doc, doc.FirstNode) < 0, "#2-1");
			Assert.IsTrue (c.Compare (doc.FirstNode, doc) > 0, "#2-2");
		}

		[Test]
		public void Compare2 ()
		{
			// sibling/following/preceding
			XNodeDocumentOrderComparer c = XNode.DocumentOrderComparer;
			XElement el = XElement.Parse ("<n1><n11><n111/><n112/></n11><n12><n121><n1211/><n1212/></n121></n12></n1>");
			Assert.IsTrue (c.Compare (el.FirstNode, el.LastNode) < 0, "#3-1"); // following-sibling
			Assert.IsTrue (c.Compare (el.LastNode, el.FirstNode) > 0, "#3-2"); // preceding-sibling
			Assert.IsTrue (c.Compare (el.FirstNode, ((XContainer) el.LastNode).FirstNode) < 0, "#3-3"); // following
			Assert.IsTrue (c.Compare (((XContainer) el.LastNode).FirstNode, el.FirstNode) > 0, "#3-4"); // preceding
		}
	}
}
