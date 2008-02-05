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

		[Test]
		public void MessageEncoder ()
		{
			WebMessageEncodingBindingElement m = new WebMessageEncodingBindingElement ();
			MessageEncoder e = m.CreateMessageEncoderFactory ().Encoder;
			Assert.AreEqual ("application/xml", e.MediaType, "#1");
			Assert.AreEqual ("application/xml; charset=utf-8", e.ContentType, "#2");
		}
	}
}
