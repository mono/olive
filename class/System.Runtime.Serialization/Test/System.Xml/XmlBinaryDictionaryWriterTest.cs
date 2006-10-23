//
// XmlSimpleDictionaryWriterTest.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005 Novell, Inc.  http://www.novell.com

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
using System.IO;
using System.Text;
using System.Xml;
using NUnit.Framework;

namespace MonoTests.System.Xml
{
	[TestFixture]
	public class XmlBinaryDictionaryWriterTest
	{
		[Test]
		public void UseCase1 ()
		{
			MemoryStream ms = new MemoryStream ();
			XmlBinaryWriterSession session = new XmlBinaryWriterSession ();
			XmlDictionaryWriter w = XmlDictionaryWriter.CreateBinaryWriter (ms, null, session);

			w.WriteStartDocument (true);
			w.WriteStartElement ("root");
			w.WriteAttributeString ("a", "");
			w.WriteComment ("");

			w.WriteWhitespace ("     ");
			w.WriteStartElement ("AAA", "urn:AAA");
			w.WriteEndElement ();
			w.WriteStartElement ("ePfix", "AAA", "urn:AAABBB");
			w.WriteEndElement ();
			w.WriteStartElement ("AAA");
			w.WriteCData ("CCC\u3005\u4E00CCC");
			w.WriteString ("AAA&AAA");
			w.WriteRaw ("DDD&DDD");
			w.WriteCharEntity ('\u4E01');
			w.WriteComment ("COMMENT");
			w.WriteEndElement ();
			w.WriteStartElement ("AAA");
			w.WriteAttributeString ("BBB", "bbb");
			// mhm, how namespace URIs are serialized then?
			w.WriteAttributeString ("pfix", "BBB", "urn:bbb", "bbbbb");
			// FIXME: They are not working
			// w.WriteAttributeString ("CCC", "urn:ccc", "ccccc");
			// w.WriteAttributeString ("DDD", "urn:ddd", "ddddd");
			// w.WriteAttributeString ("CCC", "urn:ddd", "cdcdc");

			// XmlLang
			w.WriteXmlAttribute ("lang", "ja");
			Assert.AreEqual ("ja", w.XmlLang, "XmlLang");

			// XmlSpace
			w.WriteStartAttribute ("xml", "space", "http://www.w3.org/XML/1998/namespace");
			w.WriteString ("pre");
			w.WriteString ("serve");
			w.WriteEndAttribute ();
			Assert.AreEqual (XmlSpace.Preserve, w.XmlSpace, "XmlSpace");

			w.WriteAttributeString ("xml", "base", "http://www.w3.org/XML/1998/namespace", "local:hogehoge");

			w.WriteString ("CCC");
			w.WriteBase64 (new byte [] {0x20, 0x20, 0x20, 0xFF, 0x80, 0x30}, 0, 6);
			w.WriteEndElement ();
			// FIXME: this WriteEndElement() should result in
			// one more 0x3C, but WinFX beta1 does not output it.
			//w.WriteEndElement ();
			w.WriteEndDocument ();

			w.Close ();

			Assert.AreEqual (usecase1_result, ms.ToArray ());
		}

		// $ : kind
		// ! : length
		// FIXME: see fixmes in the test itself.
		static readonly byte [] usecase1_result = new byte [] {
			// $!root$!  a....!__  ___.!AAA  $!urn:AA  A$$!ePfi
			0x3F, 0x04, 0x72, 0x6F, 0x6F, 0x74, 0x00, 0x01,
			0x61, 0x8B, 0x3D, 0x00, 0x83, 0x05, 0x20, 0x20,
			0x20, 0x20, 0x20, 0x3F, 0x03, 0x41, 0x41, 0x41,
			0x04, 0x07, 0x75, 0x72, 0x6E, 0x3A, 0x41, 0x41,
			0x41, 0x3C, 0x40, 0x05, 0x65, 0x50, 0x66, 0x69,// 40
			// x!AAA$!e  Pfix!urn  :AAABBB$  $!AAA$!C  CC......
			0x78, 0x03, 0x41, 0x41, 0x41, 0x05, 0x05, 0x65,
			0x50, 0x66, 0x69, 0x78, 0x0A, 0x75, 0x72, 0x6E,
			0x3A, 0x41, 0x41, 0x41, 0x42, 0x42, 0x42, 0x3C,
			0x3F, 0x03, 0x41, 0x41, 0x41, 0x83, 0x0C, 0x43,
			0x43, 0x43, 0xE3, 0x80, 0x85, 0xE4, 0xB8, 0x80,// 80
			// AAA$!DDD  $AAA$!DD  D$DDD...  ..$!COMM  ENT$$!AA
			0x43, 0x43, 0x43, 0x83, 0x07, 0x41, 0x41, 0x41,
			0x26, 0x41, 0x41, 0x41, 0x83, 0x07, 0x44, 0x44,
			0x44, 0x26, 0x44, 0x44, 0x44, 0x83, 0x03, 0xE4,
			0xB8, 0x81, 0x3D, 0x07, 0x43, 0x4F, 0x4D, 0x4D,
			0x45, 0x4E, 0x54, 0x3C, 0x3F, 0x03, 0x41, 0x41,// 120
			// A$!BBB$!  bbb$!pfi  x!BBB$!B  BBBB$!CC  C$!CCCCC
			0x41, 0x00, 0x03, 0x42, 0x42, 0x42, 0x83, 0x03,
			0x62, 0x62, 0x62, 0x01, 0x04, 0x70, 0x66, 0x69,
			0x78, 0x03, 0x42, 0x42, 0x42, 0x83, 0x05, 0x62,
			0x62, 0x62, 0x62, 0x62, 0x01, 0x03, 0x78, 0x6D,
			0x6C, 0x04, 0x6C, 0x61, 0x6E, 0x67, 0x83, 0x02,// 160
			0x6A, 0x61, 0x01, 0x03, 0x78, 0x6D, 0x6C, 0x05,
			0x73, 0x70, 0x61, 0x63, 0x65, 0x83, 0x08, 0x70,
			0x72, 0x65, 0x73, 0x65, 0x72, 0x76, 0x65, 0x01,
			0x03, 0x78, 0x6D, 0x6C, 0x04, 0x62, 0x61, 0x73,
			0x65, 0x83, 0x0E, 0x6C, 0x6F, 0x63, 0x61, 0x6C,// 200
			0x3A, 0x68, 0x6F, 0x67, 0x65, 0x68, 0x6F, 0x67,
			0x65, 0x05, 0x04, 0x70, 0x66, 0x69, 0x78, 0x07,
			0x75, 0x72, 0x6E, 0x3A, 0x62, 0x62, 0x62, 0x83,
			0x03, 0x43, 0x43, 0x43, 0xA4, 0x06, 0x20, 0x20,
			0x20, 0xFF, 0x80, 0x30, 0x3C, /*0x3C*/
			};
	}
}
