using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using NUnit.Framework;

namespace MonoTests.System.Xml.Linq
{
	[TestFixture]
	public class XNamespaceTest
	{
		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void GetNull ()
		{
			XNamespace.Get (null);
		}

		[Test]
		public void GetEmpty ()
		{
			XNamespace n = XNamespace.Get (String.Empty);
			Assert.AreEqual (String.Empty, n.NamespaceName);
		}

		[Test]
		//[ExpectedException (typeof (ArgumentException))]
		public void GetBrokenFormat ()
		{
			XNamespace n = XNamespace.Get ("{");
			Assert.AreEqual ("{", n.NamespaceName, "#1");
		}

		[Test]
		//[ExpectedException (typeof (XmlException))]
		public void GetBrokenFormat2 ()
		{
			XNamespace n = XNamespace.Get ("}");
			Assert.AreEqual ("}", n.NamespaceName, "#1");
		}

		[Test]
		//[ExpectedException (typeof (ArgumentException))]
		public void GetBrokenFormat3 ()
		{
			XNamespace n = XNamespace.Get ("{{}}x");
			Assert.AreEqual ("{{}}x", n.NamespaceName, "#1");
		}

		[Test]
		public void GetBrokenFormat4 ()
		{
			XNamespace n = XNamespace.Get ("{}x}");
			Assert.AreEqual ("{}x}", n.NamespaceName, "#1");
		}

		[Test]
		public void Get1 ()
		{
			XNamespace n = XNamespace.Get ("{x_x}");
			Assert.AreEqual ("{x_x}", n.NamespaceName, "#1");

			n = XNamespace.Get ("x_x"); // looks like this is the ordinal use.
			Assert.AreEqual ("x_x", n.NamespaceName, "#2");
		}

		[Test]
		public void Predefined ()
		{
			Assert.AreEqual ("http://www.w3.org/XML/1998/namespace", XNamespace.Xml.NamespaceName, "#1");
			Assert.AreEqual ("http://www.w3.org/2000/xmlns/", XNamespace.Xmlns.NamespaceName, "#2");
		}
	}
}
