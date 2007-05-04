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

		[Test]
		public void SetAttribute ()
		{
			XElement el = new XElement (XName.Get ("foo"));
			el.SetAttributeValue (XName.Get ("a1"), "v1");
			XAttribute a = el.FirstAttribute;
			Assert.IsNotNull (a, "#1-1");
			Assert.AreEqual (el, a.Parent, "#1-2");
			Assert.IsNotNull (el.LastAttribute, "#1-3");
			Assert.AreEqual (a, el.LastAttribute, "#1-4");
			Assert.AreEqual ("a1", a.Name.LocalName, "#1-5");
			Assert.AreEqual ("v1", a.Value, "#1-6");
			Assert.IsNull (a.PreviousAttribute, "#1-7");
			Assert.IsNull (a.NextAttribute, "#1-8");

			el.SetAttributeValue (XName.Get ("a2"), "v2");
			Assert.IsFalse (el.FirstAttribute == el.LastAttribute, "#2-1");
			Assert.AreEqual ("a2", el.LastAttribute.Name.LocalName, "#2-2");

			el.SetAttributeValue (XName.Get ("a1"), "v3");
			XAttribute b = el.FirstAttribute;
			Assert.IsNotNull (b, "#2-3");
			Assert.IsNotNull (el.LastAttribute, "#2-4");
			Assert.AreEqual ("a1", b.Name.LocalName, "#2-5");
			Assert.AreEqual ("v3", b.Value, "#2-6");
			Assert.AreEqual (a, b, "#2-7");
			XAttribute c = el.LastAttribute;
			Assert.AreEqual (a, c.PreviousAttribute, "#2-8");

			a.Remove ();
			Assert.IsNull (a.Parent, "#3-1");
			Assert.IsNull (a.PreviousAttribute, "#3-2");
			Assert.IsNull (a.NextAttribute, "#3-3");
			Assert.IsNull (c.PreviousAttribute, "#3-4");
			Assert.IsNull (c.NextAttribute, "#3-5");

			el.RemoveAttributes ();
			Assert.IsFalse (el.HasAttributes, "#4-1");
			Assert.IsNull (b.Parent, "#4-2");
			Assert.IsNull (c.Parent, "#4-3");
			Assert.IsNull (el.FirstAttribute, "#4-4");
			Assert.IsNull (el.LastAttribute, "#4-5");
		}

		[Test]
		public void AddAfterSelf ()
		{
			XElement el = XElement.Parse ("<root><foo/><bar/></root>");
			el.FirstNode.AddAfterSelf ("text");
			XText t = el.FirstNode.NextNode as XText;
			Assert.IsNotNull (t, "#1");
			Assert.AreEqual ("text", t.Value, "#2");
			XElement bar = t.NextNode as XElement;
			Assert.IsNotNull (bar, "#3");
			Assert.AreEqual ("bar", bar.Name.LocalName, "#4");
		}

		[Test]
		public void AddAfterSelfList ()
		{
			XElement el = XElement.Parse ("<root><foo/><bar/></root>");
			el.FirstNode.AddAfterSelf (new XText [] {
				new XText ("t1"),
				new XText ("t2"),
				new XText ("t3")});
			XText t = el.FirstNode.NextNode as XText;
			Assert.IsNotNull (t, "#1");
			Assert.AreEqual ("t1", t.Value, "#2");
			Assert.AreEqual ("t2", ((XText) t.NextNode).Value, "#3");
			Assert.AreEqual ("t3", ((XText) t.NextNode.NextNode).Value, "#4");
			XElement bar = t.NextNode.NextNode.NextNode as XElement;
			Assert.IsNotNull (bar, "#5");
			Assert.AreEqual ("bar", bar.Name.LocalName, "#6");
		}

		[Test]
		public void AddBeforeSelf ()
		{
			XElement el = XElement.Parse ("<root><foo/><bar/></root>");
			el.FirstNode.AddBeforeSelf ("text");
			XText t = el.FirstNode as XText;
			Assert.IsNotNull (t, "#1");
			Assert.AreEqual ("text", t.Value, "#2");
			XElement foo = t.NextNode as XElement;
			Assert.IsNotNull (foo, "#3");
			Assert.AreEqual ("foo", foo.Name.LocalName, "#4");
		}

		[Test]
		public void AddBeforeSelfList ()
		{
			XElement el = XElement.Parse ("<root><foo/><bar/></root>");
			el.FirstNode.AddBeforeSelf (new XText [] {
				new XText ("t1"),
				new XText ("t2"),
				new XText ("t3")});
			XText t = el.FirstNode as XText;
			Assert.IsNotNull (t, "#1");
			Assert.AreEqual ("t1", t.Value, "#2");
			Assert.AreEqual ("t2", ((XText) t.NextNode).Value, "#3");
			Assert.AreEqual ("t3", ((XText) t.NextNode.NextNode).Value, "#4");
			XElement foo = t.NextNode.NextNode.NextNode as XElement;
			Assert.IsNotNull (foo, "#5");
			Assert.AreEqual ("foo", foo.Name.LocalName, "#6");
		}

		[Test]
		public void ReplaceWith ()
		{
			XElement el = XElement.Parse ("<root><foo/><bar/></root>");
			XNode fc = el.FirstNode;
			fc.ReplaceWith("test");
			XText t = el.FirstNode as XText;
			Assert.IsNotNull (t, "#1");
			Assert.AreEqual ("test", t.Value, "#2");
		}
	}
}
