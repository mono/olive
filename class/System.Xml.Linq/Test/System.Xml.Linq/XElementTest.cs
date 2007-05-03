using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using NUnit.Framework;

namespace MonoTests.System.Xml.Linq
{
	[TestFixture]
	public class XElementTest
	{
		[Test] // xml declaration is skipped.
		public void LoadWithXmldecl ()
		{
			string xml = "<?xml version='1.0'?><root />";
			XElement.Load (new StringReader (xml));
		}

		[Test]
		public void Load1 ()
		{
			string xml = "<root><foo/></root>";

			XElement el = XElement.Load (new StringReader (xml));
			XElement first = el.FirstNode as XElement;
			Assert.IsNotNull (first, "#1");
			Assert.IsTrue (el.LastNode is XElement, "#2");
			Assert.IsNull (el.NextNode, "#3");
			Assert.IsNull (el.PreviousNode, "#4");
			Assert.AreEqual (1, new List<XNode> (el.Nodes ()).Count, "#5");
			Assert.AreEqual (el, first.Parent, "#6");
			Assert.AreEqual (first, el.LastNode, "#7");

			Assert.AreEqual ("root", el.Name.ToString (), "#8");
			Assert.AreEqual ("foo", first.Name.ToString (), "#9");
			Assert.IsFalse (el.Attributes ().GetEnumerator ().MoveNext (), "#10");
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void LoadInvalid ()
		{
			string xml = "text";
			XmlReaderSettings s = new XmlReaderSettings ();
			s.ConformanceLevel = ConformanceLevel.Fragment;

			XElement.Load (XmlReader.Create (new StringReader (xml), s));
		}

		[Test]
		public void PrecedingWhitespaces ()
		{
			string xml = "  <root/>";
			XmlReaderSettings s = new XmlReaderSettings ();
			s.ConformanceLevel = ConformanceLevel.Fragment;

			XElement.Load (XmlReader.Create (new StringReader (xml), s));
		}

		[Test]
		public void PrecedingWhitespaces2 ()
		{
			string xml = "  <root/>";
			XmlReaderSettings s = new XmlReaderSettings ();
			s.ConformanceLevel = ConformanceLevel.Fragment;

			XmlReader r = XmlReader.Create (new StringReader (xml), s);
			r.Read (); // at whitespace
			XElement.Load (r);
		}

		[Test]
		public void Load2 ()
		{
			string xml = "<root>foo</root>";

			XElement el = XElement.Load (new StringReader (xml));
			XText first = el.FirstNode as XText;
			Assert.IsNotNull (first, "#1");
			Assert.IsTrue (el.LastNode is XText, "#2");
			Assert.AreEqual (1, new List<XNode> (el.Nodes ()).Count, "#3");
			Assert.AreEqual (el, first.Parent, "#4");
			Assert.AreEqual (first, el.LastNode, "#5");

			Assert.AreEqual ("foo", first.Value, "#6");
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void AddDocumentTypeToElement ()
		{
			XElement el = new XElement (XName.Get ("foo"));
			el.Add (new XDocumentType ("foo", null, null, null));
		}

		[Test]
		public void AddXDeclarationToElement ()
		{
			XElement el = new XElement (XName.Get ("foo"));
			// XDeclaration is treated as a general object and
			// hence converted to a string. No error here.
			el.Add (new XDeclaration ("1.0", null, null));
			Assert.AreEqual ("<?xml version=\"1.0\"?>", ((XText) el.FirstNode).Value, "#1");
		}
	}
}
