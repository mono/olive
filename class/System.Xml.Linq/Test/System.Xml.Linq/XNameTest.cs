using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using NUnit.Framework;

namespace MonoTests.System.Xml.Linq
{
	[TestFixture]
	public class XNameTest
	{
		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void GetNull ()
		{
			XName.Get (null);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void GetEmpty ()
		{
			XName.Get (String.Empty);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void GetBrokenFormat ()
		{
			XName.Get ("{");
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void GetBrokenFormat2 ()
		{
			XName.Get ("}");
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void GetBrokenFormat3 ()
		{
			XName.Get ("{x_x}");
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void GetBrokenFormat4 ()
		{
			XName.Get (":");
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void GetBrokenFormat5 ()
		{
			XName.Get ("whoa!");
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void GetBrokenFormat6 ()
		{
			XName.Get ("x{y}");
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void GetBrokenFormat7 ()
		{
			XName.Get (" {x}y");
		}

		[Test]
		[ExpectedException (typeof (XmlException))]
		public void GetBrokenFormat8 ()
		{
			XName.Get ("{x}y ");
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void GetBrokenFormat9 ()
		{
			XName.Get ("{xyz");
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void GetBrokenFormat10 ()
		{
			XName.Get ("{}x");
		}

		[Test]
		public void Get1 ()
		{
			XName n = XName.Get ("{{}}x");
			Assert.AreEqual ("x", n.LocalName, "#1");
			// huh, looks like there is no URI format validation.
			Assert.AreEqual ("{}", n.NamespaceName, "#2");
		}


	}
}
