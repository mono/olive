using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using NUnit.Framework;

namespace MonoTests.System.ServiceModel
{
	[TestFixture]
	public class WebMessageEncodingBindingElementTest
	{
		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void Constructor ()
		{
			new WebMessageEncodingBindingElement (null);
		}

		[Test]
		public void DefaultPropertyValues ()
		{
			WebMessageEncodingBindingElement be = new WebMessageEncodingBindingElement ();
			Assert.AreEqual (Encoding.UTF8, be.WriteEncoding, "#1");
		}
	}
}
