using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

using NUnit.Framework;

namespace MonoTests.System.Xml.Linq
{
	[TestFixture]
	public class XAttributeTest
	{
		[Test]
		public void IsNamespaceDeclaration ()
		{
			string xml = "<root a='v' xmlns='urn:foo' xmlns:x='urn:x' x:a='v' xmlns:xml='http://www.w3.org/XML/1998/namespace' />";
			XElement el = XElement.Parse (xml);
			List<XAttribute> l = new List<XAttribute> (el.Attributes ());
			Assert.IsFalse (l [0].IsNamespaceDeclaration, "#1");
			Assert.IsTrue (l [1].IsNamespaceDeclaration, "#2");
			Assert.IsTrue (l [2].IsNamespaceDeclaration, "#3");
			Assert.IsFalse (l [3].IsNamespaceDeclaration, "#4");
			Assert.IsTrue (l [4].IsNamespaceDeclaration, "#5");

			Assert.AreEqual ("a", l [0].Name.LocalName, "#2-1");
			Assert.AreEqual ("xmlns", l [1].Name.LocalName, "#2-2");
			Assert.AreEqual ("x", l [2].Name.LocalName, "#2-3");
			Assert.AreEqual ("a", l [3].Name.LocalName, "#2-4");
			Assert.AreEqual ("xml", l [4].Name.LocalName, "#2-5");

			Assert.AreEqual ("", l [0].Name.NamespaceName, "#3-1");
			// not sure how current Orcas behavior makes sense here though ...
			Assert.AreEqual ("", l [1].Name.NamespaceName, "#3-2");
			Assert.AreEqual ("http://www.w3.org/2000/xmlns/", l [2].Name.NamespaceName, "#3-3");
			Assert.AreEqual ("urn:x", l [3].Name.NamespaceName, "#3-4");
			Assert.AreEqual ("http://www.w3.org/2000/xmlns/", l [4].Name.NamespaceName, "#3-5");
		}

		[Test]
		public void Document ()
		{
			XDocument doc = XDocument.Parse ("<root a='v' />");
			Assert.AreEqual (doc, doc.Root.Document, "#1");
			foreach (XAttribute a in doc.Root.Attributes ())
				Assert.AreEqual (doc, a.Document, "#2");
			Assert.AreEqual (doc, doc.Document, "#3");
		}
	}
}