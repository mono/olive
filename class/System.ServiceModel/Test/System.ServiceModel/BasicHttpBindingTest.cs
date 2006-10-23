//
// BasicHttpBindingTest.cs
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
using System.Collections.ObjectModel;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using NUnit.Framework;

namespace MonoTests.System.ServiceModel
{
	[TestFixture]
	public class BasicHttpBindingTest
	{
		[Test]
		public void DefaultValues ()
		{
			BasicHttpBinding b = new BasicHttpBinding ();
			DefaultValues (b);

			// BasicHttpSecurity
			BasicHttpSecurity sec = b.Security;
			Assert.IsNotNull (sec, "#2-1");
			Assert.AreEqual (BasicHttpSecurityMode.None, sec.Mode, "#2-2");
			BasicHttpMessageSecurity msg = sec.Message;
			Assert.IsNotNull (msg, "#2-3-1");
			Assert.AreEqual (SecurityAlgorithmSuite.Default, msg.AlgorithmSuite, "#2-3-2");
			Assert.AreEqual (BasicHttpMessageCredentialType.UserName, msg.ClientCredentialType, "#2-3-3");
			HttpTransportSecurity trans = sec.Transport;
			Assert.IsNotNull (trans, "#2-4-1");
			Assert.AreEqual (HttpClientCredentialType.None, trans.ClientCredentialType, "#2-4-2");
			Assert.AreEqual (HttpProxyCredentialType.None, trans.ProxyCredentialType, "#2-4-3");
			Assert.AreEqual ("", trans.Realm, "#2-4-4");

			// Binding elements
			BindingElementCollection bec = b.CreateBindingElements ();
			Assert.AreEqual (2, bec.Count, "#5-1");
			Assert.AreEqual (typeof (TextMessageEncodingBindingElement),
				bec [0].GetType (), "#5-2");
			Assert.AreEqual (typeof (HttpTransportBindingElement),
				bec [1].GetType (), "#5-3");
		}

		[Test]
		public void DefaultValueSecurityModeMessage ()
		{
			BasicHttpBinding b = new BasicHttpBinding (BasicHttpSecurityMode.Message);
			b.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.Certificate;
			DefaultValues (b);

			// BasicHttpSecurity
			BasicHttpSecurity sec = b.Security;
			Assert.IsNotNull (sec, "#2-1");
			Assert.AreEqual (BasicHttpSecurityMode.Message, sec.Mode, "#2-2");
			BasicHttpMessageSecurity msg = sec.Message;
			Assert.IsNotNull (msg, "#2-3-1");
			Assert.AreEqual (SecurityAlgorithmSuite.Default, msg.AlgorithmSuite, "#2-3-2");
			Assert.AreEqual (BasicHttpMessageCredentialType.Certificate, msg.ClientCredentialType, "#2-3-3");
			HttpTransportSecurity trans = sec.Transport;
			Assert.IsNotNull (trans, "#2-4-1");
			Assert.AreEqual (HttpClientCredentialType.None, trans.ClientCredentialType, "#2-4-2");
			Assert.AreEqual (HttpProxyCredentialType.None, trans.ProxyCredentialType, "#2-4-3");
			Assert.AreEqual ("", trans.Realm, "#2-4-4");

			// Binding elements
			BindingElementCollection bec = b.CreateBindingElements ();
			Assert.AreEqual (3, bec.Count, "#5-1");
			Assert.AreEqual (typeof (AsymmetricSecurityBindingElement),
				bec [0].GetType (), "#5-2");
			Assert.AreEqual (typeof (TextMessageEncodingBindingElement),
				bec [1].GetType (), "#5-3");
			Assert.AreEqual (typeof (HttpTransportBindingElement),
				bec [2].GetType (), "#5-4");
		}

		void DefaultValues (BasicHttpBinding b)
		{
			Assert.AreEqual (false, b.BypassProxyOnLocal, "#1");
			Assert.AreEqual (HostNameComparisonMode.StrongWildcard,
				b.HostNameComparisonMode, "#2");
			Assert.AreEqual (0x80000, b.MaxBufferPoolSize, "#3");
			Assert.AreEqual (0x10000, b.MaxBufferSize, "#4");
			Assert.AreEqual (0x10000, b.MaxReceivedMessageSize, "#5");
			Assert.AreEqual (WSMessageEncoding.Text, b.MessageEncoding, "#6");
			Assert.IsNull (b.ProxyAddress, "#7");
			// FIXME: test b.ReaderQuotas
			Assert.AreEqual ("http", b.Scheme, "#8");
			Assert.AreEqual (EnvelopeVersion.Soap11, b.EnvelopeVersion, "#9");
			Assert.AreEqual (65001, b.TextEncoding.CodePage, "#10"); // utf-8
			Assert.AreEqual (TransferMode.Buffered, b.TransferMode, "#11");
			Assert.AreEqual (true, b.UseDefaultWebProxy, "#12");

/*
			// Interfaces
			IBindingDeliveryCapabilities ib = (IBindingDeliveryCapabilities ) b;
			Assert.AreEqual (false, ib.AssuresOrderedDelivery, "#2-1");
			Assert.AreEqual (false, ib.QueuedDelivery, "#2-3");

			IBindingMulticastCapabilities imc = (IBindingMulticastCapabilities) b;
			Assert.AreEqual (false, imc.IsMulticast, "#2.2-1");

			IBindingRuntimePreferences ir =
				(IBindingRuntimePreferences) b;
			Assert.AreEqual (false, ir.ReceiveSynchronously, "#3-1");

			ISecurityCapabilities ic = b as ISecurityCapabilities;
			Assert.AreEqual (ProtectionLevel.None,
				ic.SupportedRequestProtectionLevel, "#4-1");
			Assert.AreEqual (ProtectionLevel.None,
				ic.SupportedResponseProtectionLevel, "#4-2");
			Assert.AreEqual (false, ic.SupportsClientAuthentication, "#4-3");
			Assert.AreEqual (false, ic.SupportsClientWindowsIdentity, "#4-4");
			Assert.AreEqual (false, ic.SupportsServerAuthentication, "#4-5");
*/
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void DefaultValueSecurityModeMessageError ()
		{
			BasicHttpBinding b = new BasicHttpBinding (BasicHttpSecurityMode.Message);
			// "BasicHttp binding requires that BasicHttpBinding.Security.Message.ClientCredentialType be equivalent to the BasicHttpMessageCredentialType.Certificate credential type for secure messages. Select Transport or TransportWithMessageCredential security for UserName credentials."
			b.CreateBindingElements ();
		}

		[Test]
		public void MessageEncoding ()
		{
			BasicHttpBinding b = new BasicHttpBinding ();
			foreach (BindingElement be in b.CreateBindingElements ()) {
				MessageEncodingBindingElement mbe =
					be as MessageEncodingBindingElement;
				if (mbe != null) {
					MessageEncoderFactory f = mbe.CreateMessageEncoderFactory ();
					MessageEncoder e = f.Encoder;

					Assert.AreEqual (typeof (TextMessageEncodingBindingElement), mbe.GetType (), "#1-1");
					Assert.AreEqual (MessageVersion.Soap11, f.MessageVersion, "#2-1");
					Assert.AreEqual ("text/xml; charset=utf-8", e.ContentType, "#3-1");
					Assert.AreEqual ("text/xml", e.MediaType, "#3-2");
					return;
				}
			}
			Assert.Fail ("No message encodiing binding element.");
		}
	}
}
