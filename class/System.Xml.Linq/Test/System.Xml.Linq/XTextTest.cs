using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using NUnit.Framework;

namespace MonoTests.System.Xml.Linq
{
	[TestFixture]
	public class XTextTest
	{
		[Test]
		public void NodeType ()
		{
			Assert.AreEqual (XmlNodeType.Text, new XText ("test").NodeType, "#1");
			Assert.AreEqual (XmlNodeType.Text, new XText ("    ").NodeType, "#2");
		}
	}
}
