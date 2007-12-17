//
// Atom10ItemFormatterTest.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using System.ServiceModel.Syndication;
using NUnit.Framework;

using QName = System.Xml.XmlQualifiedName;

namespace MonoTests.System.ServiceModel.Syndication
{
	[TestFixture]
	public class Atom10ItemFormatterTest
	{
		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNullItem ()
		{
			new Atom10ItemFormatter ((SyndicationItem) null);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNullType ()
		{
			new Atom10ItemFormatter ((Type) null);
		}

		/*
		[Test]
		public void ItemType ()
		{
			Atom10ItemFormatter f = new Atom10ItemFormatter ();
			Assert.IsNull (f.ItemType, "#1");
			f = new Atom10ItemFormatter (new SyndicationItem ());
			Assert.IsNull (f.ItemType, "#2");
		}
		*/

		[Test]
		public void Version ()
		{
			Atom10ItemFormatter f = new Atom10ItemFormatter ();
			Assert.AreEqual ("Atom10", f.Version, "#1");
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void DefaultConstructorThenWriteXml ()
		{
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Atom10ItemFormatter ().WriteTo (w);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void WriteToNull ()
		{
			SyndicationItem item = new SyndicationItem ();
			new Atom10ItemFormatter (item).WriteTo (null);
		}

		string DummyId (string s)
		{
			return Regex.Replace (s, "<id>.+</id>", "<id>XXX</id>");
		}

		string DummyId2 (string s)
		{
			return Regex.Replace (s, "<id xmlns=\"http://www.w3.org/2005/Atom\">.+</id>", "<id>XXX</id>");
		}

		string DummyUpdated (string s)
		{
			return Regex.Replace (s, "<updated>.+</updated>", "<updated>XXX</updated>");
		}

		string DummyUpdated2 (string s)
		{
			return Regex.Replace (s, "<updated xmlns=\"http://www.w3.org/2005/Atom\">.+</updated>", "<updated>XXX</updated>");
		}

		[Test]
		public void WriteTo_EmptyItem ()
		{
			// It however automatically fills id (very likely bug in .NET) and DateTimeOffset though.
			SyndicationItem item = new SyndicationItem ();
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Atom10ItemFormatter (item).WriteTo (w);
			Assert.IsNull (item.Id, "#1"); // automatically generated, but not automatically set.
			using (XmlWriter w = CreateWriter (sw))
				new Atom10ItemFormatter (item).WriteTo (w);
			Assert.AreEqual ("<entry xmlns=\"http://www.w3.org/2005/Atom\"><id>XXX</id><title type=\"text\"></title><updated>XXX</updated></entry>", DummyUpdated (DummyId (sw.ToString ())));
		}

		[Test]
		public void WriteTo_TitleOnlyItem ()
		{
			// It however automatically fills id (very likely bug in .NET) and DateTimeOffset though.
			SyndicationItem item = new SyndicationItem ();
			item.Title = new TextSyndicationContent ("title text");
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Atom10ItemFormatter (item).WriteTo (w);
			Assert.AreEqual ("<entry xmlns=\"http://www.w3.org/2005/Atom\"><id>XXX</id><title type=\"text\">title text</title><updated>XXX</updated></entry>", DummyUpdated (DummyId (sw.ToString ())));
		}

		[Test]
		public void WriteTo_CategoryAuthorsContributors ()
		{
			// It however automatically fills ...
			SyndicationItem item = new SyndicationItem ();
			item.Categories.Add (new SyndicationCategory ("myname", "myscheme", "mylabel"));
			item.Authors.Add (new SyndicationPerson ("john@doe.com", "John Doe", "http://john.doe.name"));
			item.Contributors.Add (new SyndicationPerson ("jane@doe.com", "Jane Doe", "http://jane.doe.name"));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Atom10ItemFormatter (item).WriteTo (w);
			// contributors are serialized as Atom extension
			Assert.AreEqual ("<entry xmlns=\"http://www.w3.org/2005/Atom\"><id>XXX</id><title type=\"text\"></title><updated>XXX</updated><author><name>John Doe</name><uri>http://john.doe.name</uri><email>john@doe.com</email></author><contributor><name>Jane Doe</name><uri>http://jane.doe.name</uri><email>jane@doe.com</email></contributor><category term=\"myname\" label=\"mylabel\" scheme=\"myscheme\" /></entry>", DummyUpdated (DummyId (sw.ToString ())));
		}

		[Test]
		public void WriteTo ()
		{
			SyndicationItem item = new SyndicationItem ();
			item.BaseUri = new Uri ("http://mono-project.com");
			item.Copyright = new TextSyndicationContent ("No rights reserved");
			item.Content = new XmlSyndicationContent (null, 5, (XmlObjectSerializer) null);
			// .NET bug: it ignores this value.
			item.Id = "urn:myid";
			item.PublishDate = new DateTimeOffset (DateTime.SpecifyKind (new DateTime (2000, 1, 1), DateTimeKind.Utc));
			item.LastUpdatedTime = new DateTimeOffset (DateTime.SpecifyKind (new DateTime (2008, 1, 1), DateTimeKind.Utc));
			//item.SourceFeed = new SyndicationFeed ();
			item.Summary = new TextSyndicationContent ("great text");

			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Atom10ItemFormatter (item).WriteTo (w);
			Assert.AreEqual ("<entry xml:base=\"http://mono-project.com/\" xmlns=\"http://www.w3.org/2005/Atom\"><id>XXX</id><title type=\"text\"></title><summary type=\"text\">great text</summary><published>2000-01-01T00:00:00Z</published><updated>2008-01-01T00:00:00Z</updated><content type=\"text/xml\"><int xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">5</int></content><rights type=\"text\">No rights reserved</rights></entry>", DummyId (sw.ToString ()));
		}

		[Test]
		public void ISerializableWriteXml ()
		{
			SyndicationItem item = new SyndicationItem ();
			item.Title = new TextSyndicationContent ("title text");
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw)) {
				w.WriteStartElement ("dummy");
				((IXmlSerializable) new Atom10ItemFormatter (item)).WriteXml (w);
				w.WriteEndElement ();
			}
			Assert.AreEqual ("<dummy><id>XXX</id><title type=\"text\" xmlns=\"http://www.w3.org/2005/Atom\">title text</title><updated>XXX</updated></dummy>", DummyUpdated2 (DummyId2 (sw.ToString ())));
		}

		XmlWriter CreateWriter (StringWriter sw)
		{
			XmlWriterSettings s = new XmlWriterSettings ();
			s.OmitXmlDeclaration = true;
			return XmlWriter.Create (sw, s);
		}
	}
}
