using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using NUnit.Framework;

namespace MonoTests.System.Xml.Linq
{
	[TestFixture]
	public class ExtensionsTest
	{
		[Test]
		public void Remove ()
		{
			XDocument doc = XDocument.Parse ("<root><foo/><bar/><baz/></root>");
			doc.Root.Nodes ().Remove ();
			Assert.IsNull (doc.Root.FirstNode, "#1");
		}
	}
}
