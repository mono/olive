//
// Rss20ItemFormatterTest.cs
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
	public class Rss20ItemFormatterTest
	{
		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNullItem ()
		{
			new Rss20ItemFormatter ((SyndicationItem) null);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNullType ()
		{
			new Rss20ItemFormatter ((Type) null);
		}

		/*
		[Test]
		public void ItemType ()
		{
			Rss20ItemFormatter f = new Rss20ItemFormatter ();
			Assert.IsNull (f.ItemType, "#1");
			f = new Rss20ItemFormatter (new SyndicationItem ());
			Assert.IsNull (f.ItemType, "#2");
		}
		*/

		[Test]
		public void Version ()
		{
			Rss20ItemFormatter f = new Rss20ItemFormatter ();
			Assert.AreEqual ("Rss20", f.Version, "#1");
		}

		[Test]
		public void SerializeExtensionsAsAtom ()
		{
			Rss20ItemFormatter f = new Rss20ItemFormatter ();
			Assert.IsTrue (f.SerializeExtensionsAsAtom, "#1");
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void DefaultConstructorThenWriteXml ()
		{
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Rss20ItemFormatter ().WriteTo (w);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void WriteToNull ()
		{
			SyndicationItem item = new SyndicationItem ();
			new Rss20ItemFormatter (item).WriteTo (null);
		}

		[Test]
		public void WriteTo_EmptyItem ()
		{
			SyndicationItem item = new SyndicationItem ();
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Rss20ItemFormatter (item).WriteTo (w);
			// either title or description must exist (RSS 2.0 spec)
			Assert.AreEqual ("<item><description /></item>", sw.ToString ());
		}

		[Test]
		public void WriteTo_TitleOnlyItem ()
		{
			SyndicationItem item = new SyndicationItem ();
			item.Title = new TextSyndicationContent ("title text");
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Rss20ItemFormatter (item).WriteTo (w);
			Assert.AreEqual ("<item><title>title text</title></item>", sw.ToString ());
		}

		[Test]
		public void WriteTo_Category ()
		{
			SyndicationItem item = new SyndicationItem ();
			item.Categories.Add (new SyndicationCategory ("myname", "myscheme", "mylabel"));
			item.Authors.Add (new SyndicationPerson ("john@doe.com", "John Doe", "http://john.doe.name"));
			item.Contributors.Add (new SyndicationPerson ("jane@doe.com", "Jane Doe", "http://jane.doe.name"));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Rss20ItemFormatter (item).WriteTo (w);
			// contributors are serialized as Atom extension
			Assert.AreEqual ("<item><author>john@doe.com</author><category domain=\"myscheme\">myname</category><description /><contributor xmlns=\"http://www.w3.org/2005/Atom\"><name>Jane Doe</name><uri>http://jane.doe.name</uri><email>jane@doe.com</email></contributor></item>", sw.ToString ());
		}

		[Test]
		public void SerializeExtensionsAsAtomFalse ()
		{
			SyndicationItem item = new SyndicationItem ();
			item.Contributors.Add (new SyndicationPerson ("jane@doe.com", "Jane Doe", "http://jane.doe.name"));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				new Rss20ItemFormatter (item, false).WriteTo (w);
			// skip contributors
			Assert.AreEqual ("<item><description /></item>", sw.ToString ());
		}

		[Test]
		public void ISerializableWriteXml ()
		{
			SyndicationItem item = new SyndicationItem ();
			item.Title = new TextSyndicationContent ("title text");
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = CreateWriter (sw))
				((IXmlSerializable) new Rss20ItemFormatter (item)).WriteXml (w);
			Assert.AreEqual ("<title>title text</title>", sw.ToString ());
		}

		XmlWriter CreateWriter (StringWriter sw)
		{
			XmlWriterSettings s = new XmlWriterSettings ();
			s.OmitXmlDeclaration = true;
			return XmlWriter.Create (sw, s);
		}
	}
}
