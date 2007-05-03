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
			Assert.IsNull (doc.FirstNode.Parent, "#6");
			Assert.AreEqual (doc.FirstNode, doc.LastNode, "#7");
			Assert.AreEqual (XmlNodeType.Document, doc.NodeType, "#8");
			Assert.AreEqual (doc.FirstNode, doc.Root, "#7");
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void LoadInvalid ()
		{
			string xml = "text";
			XmlReaderSettings s = new XmlReaderSettings ();
			s.ConformanceLevel = ConformanceLevel.Fragment;

			XDocument.Load (XmlReader.Create (new StringReader (xml), s));
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void LoadWhitespaces ()
		{
			string xml = "   ";
			XmlReaderSettings s = new XmlReaderSettings ();
			s.ConformanceLevel = ConformanceLevel.Fragment;

			XDocument.Load (XmlReader.Create (new StringReader (xml), s));
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void AddTextToDocument ()
		{
			XDocument doc = new XDocument ();
			doc.Add ("test");
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void AddXDeclarationToDocument ()
		{
			XDocument doc = new XDocument ();
			// XDeclaration is treated as a general object and
			// hence converted to a string -> error
			doc.Add (new XDeclaration ("1.0", null, null));
		}
	}
}
