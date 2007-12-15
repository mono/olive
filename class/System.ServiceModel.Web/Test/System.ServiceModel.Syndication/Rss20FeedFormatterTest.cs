//
// Rss20FeedFormatterTest.cs
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
using System.Xml;
using System.Xml.Serialization;
using System.ServiceModel.Syndication;
using NUnit.Framework;

using QName = System.Xml.XmlQualifiedName;

namespace MonoTests.System.ServiceModel.Syndication
{
	[TestFixture]
	public class Rss20FeedFormatterTest
	{
		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNullFeed ()
		{
			new Rss20FeedFormatter ((SyndicationFeed) null);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNullType ()
		{
			new Rss20FeedFormatter ((Type) null);
		}

		/*
		[Test]
		public void FeedType ()
		{
			Rss20FeedFormatter f = new Rss20FeedFormatter ();
			Assert.IsNull (f.FeedType, "#1");
			f = new Rss20FeedFormatter (new SyndicationFeed ());
			Assert.IsNull (f.FeedType, "#2");
		}
		*/

		[Test]
		public void Version ()
		{
			Rss20FeedFormatter f = new Rss20FeedFormatter ();
			Assert.AreEqual ("Rss20", f.Version, "#1");
		}

		[Test]
		public void SerializeExtensionsAsAtom ()
		{
			Rss20FeedFormatter f = new Rss20FeedFormatter ();
			Assert.IsTrue (f.SerializeExtensionsAsAtom, "#1");
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void DefaultConstructorThenWriteXml ()
		{
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Rss20FeedFormatter ().WriteTo (w);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void WriteToNull ()
		{
			SyndicationFeed item = new SyndicationFeed ();
			new Rss20FeedFormatter (item).WriteTo (null);
		}

		[Test]
		public void WriteTo_EmptyFeed ()
		{
			SyndicationFeed item = new SyndicationFeed ();
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Rss20FeedFormatter (item).WriteTo (w);
			// either title or description must exist (RSS 2.0 spec)
			Assert.AreEqual ("<rss xmlns:a10=\"http://www.w3.org/2005/Atom\" version=\"2.0\"><channel><title /><description /></channel></rss>", sw.ToString ());
		}

		[Test]
		public void WriteTo_TitleOnlyFeed ()
		{
			SyndicationFeed item = new SyndicationFeed ();
			item.Title = new TextSyndicationContent ("title text");
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Rss20FeedFormatter (item).WriteTo (w);
			Assert.AreEqual ("<rss xmlns:a10=\"http://www.w3.org/2005/Atom\" version=\"2.0\"><channel><title>title text</title><description /></channel></rss>", sw.ToString ());
		}

		[Test]
		public void WriteTo_CategoryAuthorsContributors ()
		{
			SyndicationFeed item = new SyndicationFeed ();
			item.Categories.Add (new SyndicationCategory ("myname", "myscheme", "mylabel"));
			item.Authors.Add (new SyndicationPerson ("john@doe.com", "John Doe", "http://john.doe.name"));
			item.Contributors.Add (new SyndicationPerson ("jane@doe.com", "Jane Doe", "http://jane.doe.name"));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Rss20FeedFormatter (item).WriteTo (w);
			// contributors are serialized as Atom extension
			Assert.AreEqual ("<rss xmlns:a10=\"http://www.w3.org/2005/Atom\" version=\"2.0\"><channel><title /><description /><managingEditor>john@doe.com</managingEditor><category domain=\"myscheme\">myname</category><a10:contributor><a10:name>Jane Doe</a10:name><a10:uri>http://jane.doe.name</a10:uri><a10:email>jane@doe.com</a10:email></a10:contributor></channel></rss>", sw.ToString ());
		}

		[Test]
		public void WriteTo ()
		{
			SyndicationFeed item = new SyndicationFeed ();
			item.BaseUri = new Uri ("http://mono-project.com");
			item.Copyright = new TextSyndicationContent ("No rights reserved");
			item.Generator = "mono test generator";
			item.Id = "urn:myid";
			item.ImageUrl = new Uri ("http://mono-project.com/images/mono.png");
			item.LastUpdatedTime = new DateTimeOffset (DateTime.SpecifyKind (new DateTime (2008, 1, 1), DateTimeKind.Utc));

			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Rss20FeedFormatter (item).WriteTo (w);
			Assert.AreEqual ("<rss xmlns:a10=\"http://www.w3.org/2005/Atom\" version=\"2.0\"><channel xml:base=\"http://mono-project.com/\"><title /><description /><copyright>No rights reserved</copyright><lastBuildDate>Tue, 01 Jan 2008 00:00:00 Z</lastBuildDate><generator>mono test generator</generator><image><url>http://mono-project.com/images/mono.png</url><title /><link /></image><a10:id>urn:myid</a10:id></channel></rss>", sw.ToString ());
		}

		[Test]
		public void SerializeExtensionsAsAtomFalse ()
		{
			SyndicationFeed item = new SyndicationFeed ();
			item.Contributors.Add (new SyndicationPerson ("jane@doe.com", "Jane Doe", "http://jane.doe.name"));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Rss20FeedFormatter (item, false).WriteTo (w);
			// skip contributors
			Assert.AreEqual ("<rss version=\"2.0\"><channel><title /><description /></channel></rss>", sw.ToString ());
		}

		[Test]
		public void ISerializableWriteXml ()
		{
			SyndicationFeed item = new SyndicationFeed ();
			item.Title = new TextSyndicationContent ("title text");
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw)) {
				w.WriteStartElement ("dummy");
				((IXmlSerializable) new Rss20FeedFormatter (item)).WriteXml (w);
				w.WriteEndElement ();
			}
			Assert.AreEqual ("<dummy xmlns:a10=\"http://www.w3.org/2005/Atom\" version=\"2.0\"><channel><title>title text</title><description /></channel></dummy>", sw.ToString ());
		}

		XmlWriter CreateWriter (StringWriter sw)
		{
			XmlWriterSettings s = new XmlWriterSettings ();
			s.OmitXmlDeclaration = true;
			return XmlWriter.Create (sw, s);
		}
	}
}
