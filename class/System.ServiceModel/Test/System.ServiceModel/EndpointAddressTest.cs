//
// EndpointBehaviorCollectionTest.cs
//
// Authors:
//	Duncan Mak <duncan@ximian.com>
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005-2006 Novell, Inc.  http://www.novell.com
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
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.ServiceModel.Channels;
using NUnit.Framework;
using System.Xml.Serialization;

namespace MonoTests.System.ServiceModel
{
	[TestFixture]
	public class EndpointAddressTest
	{
		EndpointAddress address;
		string namespace_uri = "http://schemas.xmlsoap.org/ws/2004/08/addressing";

		[Test]
		public void AnonymousUri ()
		{
			Assert.AreEqual ("http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/Anonymous", EndpointAddress.AnonymousUri.AbsoluteUri, "#1");

			address = new EndpointAddress ("http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/Anonymous");
			Assert.IsTrue (address.IsAnonymous, "#2");
			Assert.IsFalse (address.IsNone, "#3");
		}

		[Test]
		public void AnonymousUri2 ()
		{
			address = new EndpointAddress ("http://www.w3.org/2005/08/addressing/anonymous");
			Assert.AreEqual ("http://www.w3.org/2005/08/addressing/anonymous", address.Uri.AbsoluteUri, "#1");
			Assert.IsFalse (address.IsAnonymous, "#2");
			Assert.IsFalse (address.IsNone, "#3");
		}

		[Test]
		public void NoneUri ()
		{
			Assert.AreEqual ("http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/None", EndpointAddress.NoneUri.AbsoluteUri, "#1");

			address = new EndpointAddress ("http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/None");
			Assert.IsFalse (address.IsAnonymous, "#2");
			Assert.IsTrue (address.IsNone, "#3");
		}

/* it does not exist anymore
		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNullUri ()
		{
			new EndpointAddress ((Uri) null);
		}
*/

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNullString ()
		{
			new EndpointAddress ((string) null);
		}

		[Test]
		public void Headers ()
		{
			EndpointAddress e = new EndpointAddress ("urn:foo");
			Assert.IsNotNull (e.Headers, "#1");
			// This code results in NullReferenceException, which
			// is nasty.
			//Assert.AreEqual (0, e.Headers.Count, "#2");
		}

		[Test]
		public void EqualsTest ()
		{
			address = new EndpointAddress ("urn:foo");
			Assert.IsFalse (address == null, "#1"); // don't throw NullReferenceException
			Assert.IsTrue ((EndpointAddress) null == null, "#2");

			Assert.IsTrue (address == new EndpointAddress ("urn:foo"), "#3");
		}

		[Test]
		public void ReadFrom0 ()
		{
			string xml = @"<a:ReplyTo xmlns:a='http://www.w3.org/2005/08/addressing'><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo>";
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);
			EndpointAddress a = EndpointAddress.ReadFrom (reader);
			Assert.IsNotNull (a, "#1");
			Assert.AreEqual ("http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/Anonymous", a.Uri.AbsoluteUri, "#2");
			Assert.IsTrue (a.IsAnonymous, "#3");
		}

		[Test]
		public void ReadFrom1 ()
		{
			string xml = @"<a:ReplyTo xmlns:a='http://schemas.xmlsoap.org/ws/2004/08/addressing'><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo>";
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);
			EndpointAddress a = EndpointAddress.ReadFrom (reader);
			Assert.IsNotNull (a, "#1");
			Assert.AreEqual ("http://www.w3.org/2005/08/addressing/anonymous", a.Uri.AbsoluteUri, "#2");
			Assert.IsFalse (a.IsAnonymous, "#3");
		}

		[Test]
		public void ReadFrom2 ()
		{
			string xml = @"<a:ReplyTo xmlns:a='http://www.w3.org/2005/08/addressing'><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo>";
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);
			EndpointAddress a = EndpointAddress.ReadFrom (AddressingVersion.WSAddressing10, reader);

			Assert.IsNotNull (a, "#1");
			Assert.AreEqual ("http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/Anonymous", a.Uri.AbsoluteUri, "#2");
			Assert.IsTrue (a.IsAnonymous, "#3");
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void ReadFrom2Error ()
		{
			
			string xml = @"<a:ReplyTo xmlns:a='http://www.w3.org/2005/08/addressing'><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo>";
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);

			//Reading address with e10 address!
			EndpointAddress a = EndpointAddress.ReadFrom (AddressingVersion.WSAddressingAugust2004, reader);
		}

		[Test]
		public void ReadFrom3 ()
		{
			string xml = @"<a:ReplyTo xmlns:a='http://schemas.xmlsoap.org/ws/2004/08/addressing'><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo>";
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);
			EndpointAddress a = EndpointAddress.ReadFrom (AddressingVersion.WSAddressingAugust2004, reader);
			
			Assert.AreEqual ("http://www.w3.org/2005/08/addressing/anonymous", a.Uri.AbsoluteUri, "#1");
			Assert.IsFalse (a.IsAnonymous, "#2");
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void ReadFrom3Error ()
		{
			string xml = @"<a:ReplyTo xmlns:a='http://schemas.xmlsoap.org/ws/2004/08/addressing'><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo>";
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);
			EndpointAddress a = EndpointAddress.ReadFrom (AddressingVersion.WSAddressing10, reader);
		}

		[Test]
		public void ReadFromE10 ()
		{
			string xml = @"<a:ReplyTo xmlns:a='http://www.w3.org/2005/08/addressing'><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo>";
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);
			
			EndpointAddress10 e10 = EndpointAddress10.FromEndpointAddress (new EndpointAddress (("http://test")));
			((IXmlSerializable) e10).ReadXml (reader);

			EndpointAddress a = e10.ToEndpointAddress ();
			Assert.AreEqual ("http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/Anonymous", a.Uri.AbsoluteUri, "#1");
			Assert.IsTrue (a.IsAnonymous, "#2");
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void ReadFromE10Error ()
		{
			//Address is from August2004 namespace, but reading it with EndpointAddress10
			string xml = @"<a:ReplyTo xmlns:a='http://schemas.xmlsoap.org/ws/2004/08/addressing'><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo>";
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);

			EndpointAddress10 e10 = EndpointAddress10.FromEndpointAddress (new EndpointAddress (("http://test")));
			((IXmlSerializable) e10).ReadXml (reader);
			
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void ReadFromE10Error2 ()
		{
			//Missing <Address> element
			string xml = @"<a:ReplyTo xmlns:a='http://www.w3.org/2005/08/addressing'>http://www.w3.org/2005/08/addressing/anonymous</a:ReplyTo>";
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);

			EndpointAddress10 e10 = EndpointAddress10.FromEndpointAddress (new EndpointAddress (("http://test")));
			((IXmlSerializable) e10).ReadXml (reader);

		}

		[Test]
		public void ReadFromAugust2004 ()
		{
			string xml = @"<a:ReplyTo xmlns:a='http://schemas.xmlsoap.org/ws/2004/08/addressing'><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo>";
			
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);

			EndpointAddressAugust2004 e2k4 = EndpointAddressAugust2004.FromEndpointAddress (new EndpointAddress ("http://test"));
			
			((IXmlSerializable) e2k4).ReadXml (reader);
			Console.WriteLine (e2k4.ToEndpointAddress ().Uri.AbsoluteUri);

			EndpointAddress a = e2k4.ToEndpointAddress ();
			Assert.AreEqual ("http://www.w3.org/2005/08/addressing/anonymous", a.Uri.AbsoluteUri, "#1");
			Assert.IsFalse (a.IsAnonymous, "#2");
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void ReadFromAugust2004Error ()
		{
			//Reading address from EndpointAddress10 namespace with EndpointAddressAugust2004
			string xml = @"<a:ReplyTo xmlns:a='http://www.w3.org/2005/08/addressing'><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo>";

			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);

			EndpointAddressAugust2004 e2k4 = EndpointAddressAugust2004.FromEndpointAddress (new EndpointAddress ("http://test"));

			((IXmlSerializable) e2k4).ReadXml (reader);
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void ReadFromAugust2004Error2 ()
		{
			//Missing <Address> element
			string xml = @"<a:ReplyTo xmlns:a='http://schemas.xmlsoap.org/ws/2004/08/addressing'>http://www.w3.org/2005/08/addressing/anonymous</a:ReplyTo>";

			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);

			EndpointAddressAugust2004 e2k4 = EndpointAddressAugust2004.FromEndpointAddress (new EndpointAddress ("http://test"));

			((IXmlSerializable) e2k4).ReadXml (reader);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void ReadFromWrongXml ()
		{
			string xml = @"<a:Address xmlns:a='http://www.w3.org/2005/08/addressing'>http://www.w3.org/2005/08/addressing/anonymous</a:Address>";
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);
			EndpointAddress a = EndpointAddress.ReadFrom (reader);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void ReadFromWrongXml2 ()
		{
			string xml = @"<a:ReplyTo xmlns:a='http://www.w3.org/2005/08/addressing'>http://www.w3.org/2005/08/addressing/anonymous</a:ReplyTo>";
			XmlReader src = XmlReader.Create (new StringReader (xml));
			XmlDictionaryReader reader =
				XmlDictionaryReader.CreateDictionaryReader (src);
			EndpointAddress a = EndpointAddress.ReadFrom (reader);
			Assert.IsNotNull (a, "#1");
			Assert.AreEqual ("http://schemas.microsoft.com/2005/12/ServiceModel/Addressing/Anonymous", a.Uri.AbsoluteUri, "#2");
			Assert.IsTrue (a.IsAnonymous, "#3");
		}

		[Test]
		public void WriteTo ()
		{
			EndpointAddress a = new EndpointAddress ("http://localhost:8080");
			StringWriter sw = new StringWriter ();
			XmlWriterSettings xws = new XmlWriterSettings ();
			xws.OmitXmlDeclaration = true;
			// #1
			using (XmlDictionaryWriter xw = XmlDictionaryWriter.CreateDictionaryWriter (XmlWriter.Create (sw, xws))) {
				a.WriteTo (AddressingVersion.None, xw, "From", "http://www.w3.org/2005/08/addressing");
			}
			Assert.AreEqual ("<From xmlns=\"http://www.w3.org/2005/08/addressing\">http://localhost:8080/</From>", sw.ToString (), "#1");

			// #2
			sw = new StringWriter ();
			using (XmlDictionaryWriter xw = XmlDictionaryWriter.CreateDictionaryWriter (XmlWriter.Create (sw, xws))) {
				a.WriteTo (AddressingVersion.None, xw);
			}
			Assert.AreEqual ("<EndpointReference xmlns=\"http://schemas.microsoft.com/ws/2005/05/addressing/none\">http://localhost:8080/</EndpointReference>", sw.ToString (), "#2");
		}

/* GetSchema() does not exist anymore
		[Test]
		public void GetSchemaTest ()
		{
			address = new EndpointAddress ("http://tempuri.org/foo");
			Assert.IsNull (address.GetSchema ());
		}

		[Test]
		[Category ("NotWorking")]
		public void GetSchemaTestWithEmptySet ()
		{
			XmlSchemaSet set = new XmlSchemaSet ();
			Assert.AreEqual (0, set.Count, "#1");
			Assert.IsFalse (set.Contains (namespace_uri), "#2");

			XmlQualifiedName n = EndpointAddress.GetSchema (set);

			// A complete copy of the schema for EndpointReference is added.
			Assert.AreEqual (1, set.Count, "#3");
			Assert.IsTrue (set.Contains (namespace_uri), "#4");

			int count = 5;
			foreach (XmlSchema schema in set.Schemas ()) {
				Assert.AreEqual (schema.TargetNamespace, n.Namespace, "#" + count++);
				Assert.IsTrue (schema.SchemaTypes.Contains (n), "#" + count++);
				// This prints out the entire Schema!
				// schema.Write (Console.Out);
			}
		}
*/
	}
}

