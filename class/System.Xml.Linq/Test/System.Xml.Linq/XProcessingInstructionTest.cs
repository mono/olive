using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

using NUnit.Framework;

using XPI = System.Xml.Linq.XProcessingInstruction;

namespace MonoTests.System.Xml.Linq
{
	[TestFixture]
	public class XProcessingInstructionTest
	{
		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void NameNull ()
		{
			XPI pi = new XPI (null, String.Empty);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void DataNull ()
		{
			XPI pi = new XPI ("mytarget", null);
		}

		[Test]
		public void Data ()
		{
			XPI pi = new XPI ("mytarget", String.Empty);
			Assert.AreEqual ("mytarget", pi.Target, "#1");
			Assert.AreEqual (String.Empty, pi.Data, "#2");
		}
	}
}
