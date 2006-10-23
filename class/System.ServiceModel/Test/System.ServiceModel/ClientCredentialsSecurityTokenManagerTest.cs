//
// ClientCredentialsSecurityTokenManagerTest.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.  http://www.novell.com
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
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;
using NUnit.Framework;

using MonoTests.System.ServiceModel.Channels;

using ReqType = System.ServiceModel.Security.Tokens.ServiceModelSecurityTokenRequirement;

namespace MonoTests.System.ServiceModel
{
	[TestFixture]
	public class ClientCredentialsSecurityTokenManagerTest
	{
		class MyManager : ClientCredentialsSecurityTokenManager
		{
			public MyManager ()
				: base (new ClientCredentials ())
			{
			}

			public bool IsIssued (SecurityTokenRequirement r)
			{
				return IsIssuedSecurityTokenRequirement (r);
			}
		}

		MyManager def_c;

		[SetUp]
		public void Initialize ()
		{
			def_c = new MyManager ();
		}

/*
		[Test]
		public void IsIssuedSecurityTokenRequirement ()
		{
			IsIssuedSecurityTokenRequirement (
				new RsaSecurityTokenParameters (), false, "#1");
			IsIssuedSecurityTokenRequirement (
				new X509SecurityTokenParameters (), false, "#2");
			IsIssuedSecurityTokenRequirement (
				new SslSecurityTokenParameters (), false, "#3");
			IsIssuedSecurityTokenRequirement (
				new SecureConversationSecurityTokenParameters (), false, "#4");
			IsIssuedSecurityTokenRequirement (
				new IssuedSecurityTokenParameters (), true, "#1");
		}

		void IsIssuedSecurityTokenRequirement (
			SecurityTokenParameters p, bool expected, string label)
		{
			ServiceModelSecurityTokenRequirement r =
				new ServiceModelSecurityTokenRequirement ();
			p.InitializeSecurityTokenRequirement (r);
			Assert.AreEqual (expected, def_c.IsIssued (r), label);
		}
*/

		[Test]
		[ExpectedException (typeof (NotSupportedException))]
		public void CreateProviderDefault ()
		{
			SecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void CreateProviderUserNameWithoutName ()
		{
			SecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.UserName;
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		public void CreateProviderUserName ()
		{
			SecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.UserName;
			def_c.ClientCredentials.UserName.UserName = "mono";
			UserNameSecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r)
				as UserNameSecurityTokenProvider;
			Assert.IsNotNull (p, "#1");
		}

		[Test]
		[ExpectedException (typeof (NotSupportedException))]
		public void CreateProviderRsaDefault ()
		{
			// actually is Rsa usable here??

			SecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.Rsa;
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void CreateProviderX509WithoutCert ()
		{
			SecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.X509Certificate;
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void CreateProviderX509WithX509EndpointIdentity ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.X509Certificate;
			// X509CertificateEndpointIdentity does not work like
			// a client certificate; it still requires client cert
			X509Certificate2 cert = new X509Certificate2 ("Test/Resources/test.pfx", "mono");
			r.TargetAddress = new EndpointAddress (
				new Uri ("http://localhost:8080"),
				new X509CertificateEndpointIdentity (cert));
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		public void CreateProviderX509WithX509IdentityKeyExchange ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.X509Certificate;
			// ... however when it is KeyExchange mode, this
			// endpoint identity is used.
			r.KeyUsage = SecurityKeyUsage.Exchange;
			X509Certificate2 cert = new X509Certificate2 ("Test/Resources/test.pfx", "mono");
			r.TargetAddress = new EndpointAddress (
				new Uri ("http://localhost:8080"),
				new X509CertificateEndpointIdentity (cert));
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void CreateProviderX509WithClientCertKeyExchange ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.X509Certificate;
			// ... and in such case ClientCertificate makes no sense.
			r.KeyUsage = SecurityKeyUsage.Exchange;
			def_c.ClientCredentials.ClientCertificate.Certificate =
				new X509Certificate2 ("Test/Resources/test.pfx", "mono");
			r.TargetAddress = new EndpointAddress ("http://localhost:8080");
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		public void CreateProviderX509 ()
		{
			SecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.X509Certificate;
			def_c.ClientCredentials.ClientCertificate.Certificate =
				new X509Certificate2 ("Test/Resources/test.pfx", "mono");
			X509SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r)
				as X509SecurityTokenProvider;
			Assert.IsNotNull (p, "#1");
		}

		[Test]
		[ExpectedException (typeof (NotSupportedException))]
		public void CreateProviderX509RecipientNoKeyUsage ()
		{
			RecipientServiceModelSecurityTokenRequirement r =
				new RecipientServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.X509Certificate;
			def_c.ClientCredentials.ClientCertificate.Certificate =
				new X509Certificate2 ("Test/Resources/test.pfx", "mono");

			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		public void CreateProviderX509Recipient ()
		{
			RecipientServiceModelSecurityTokenRequirement r =
				new RecipientServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.X509Certificate;
			r.KeyUsage = SecurityKeyUsage.Exchange;
			def_c.ClientCredentials.ClientCertificate.Certificate =
				new X509Certificate2 ("Test/Resources/test.pfx", "mono");

			X509SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r)
				as X509SecurityTokenProvider;
			Assert.IsNotNull (p, "#1");
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void CreateProviderAnonSslNoTargetAddress ()
		{
			SecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = ServiceModelSecurityTokenTypes.AnonymousSslnego;
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void CreateProviderAnonSslNoBindingElement ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = ServiceModelSecurityTokenTypes.AnonymousSslnego;
			r.TargetAddress = new EndpointAddress ("http://localhost:8080");
			SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r);
			Assert.IsNotNull (p, "#1");
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void CreateProviderAnonSslNoIssuerBindingContext ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = ServiceModelSecurityTokenTypes.AnonymousSslnego;
			r.TargetAddress = new EndpointAddress ("http://localhost:8080");
			r.SecurityBindingElement = new SymmetricSecurityBindingElement ();
			SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r);
			Assert.IsNotNull (p, "#1");
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void CreateProviderAnonSslNoMessageSecurityVersion ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = ServiceModelSecurityTokenTypes.AnonymousSslnego;
			r.TargetAddress = new EndpointAddress ("http://localhost:8080");
			r.SecurityBindingElement = new SymmetricSecurityBindingElement ();
			r.Properties [ReqType.IssuerBindingContextProperty] =
				new BindingContext (new CustomBinding (), new BindingParameterCollection ());
			SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r);
			Assert.IsNotNull (p, "#1");
		}

		EndpointAddress CreateEndpointAddress (string s, bool publicOnly)
		{
			return new EndpointAddress (new Uri (s),
				new X509CertificateEndpointIdentity (
					publicOnly ?
					new X509Certificate2 ("Test/Resources/test.cer") :
					new X509Certificate2 ("Test/Resources/test.pfx", "mono")));
		}

		InitiatorServiceModelSecurityTokenRequirement  GetAnonSslProviderRequirement (bool useTransport)
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = ServiceModelSecurityTokenTypes.AnonymousSslnego;
			r.TargetAddress = new EndpointAddress ("http://localhost:8080");
//			r.TargetAddress = CreateEndpointAddress ("http://localhost:8080", true);
			r.SecurityBindingElement = SecurityBindingElement.CreateUserNameForSslBindingElement ();
			CustomBinding binding =
				useTransport ?
				new CustomBinding (new HandlerTransportBindingElement (null)) :
				new CustomBinding ();
			r.Properties [ReqType.IssuerBindingContextProperty] =
				new BindingContext (binding, new BindingParameterCollection ());
			r.MessageSecurityVersion =
				MessageSecurityVersion.Default.SecurityTokenVersion;
			r.SecurityAlgorithmSuite =
				SecurityAlgorithmSuite.Default;
			return r;
		}

		[Test]
		public void CreateProviderAnonSsl (bool useTransport)
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				GetAnonSslProviderRequirement (useTransport);
			SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r);
			Assert.IsNotNull (p, "#1");

			ICommunicationObject comm = p as ICommunicationObject;
			Assert.IsNotNull (comm, "#2");
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		[Category ("NotWorking")]
		public void GetAnonSslProviderSecurityTokenNoTransport ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				GetAnonSslProviderRequirement (false);
			SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r);
			Assert.IsNotNull (p, "#1");

			ICommunicationObject comm = p as ICommunicationObject;
			Assert.IsNotNull (comm, "#2");
			comm.Open ();
			try {
				p.GetToken (TimeSpan.FromSeconds (5));
			} finally {
				comm.Close ();
			}
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void GetAnonSslProviderSecurityTokenNoAlgorithmSuite ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				GetAnonSslProviderRequirement (true);
			r.Properties.Remove (ReqType.SecurityAlgorithmSuiteProperty);
			SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r);
			Assert.IsNotNull (p, "#1");

			ICommunicationObject comm = p as ICommunicationObject;
			Assert.IsNotNull (comm, "#2");
			comm.Open ();
			try {
				p.GetToken (TimeSpan.FromSeconds (5));
			} finally {
				comm.Close ();
			}
		}

		[Test]
		[Ignore ("it somehow causes NRE - smells .NET bug.")]
		public void GetAnonSslProviderSecurityToken ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				GetAnonSslProviderRequirement (true);

			// What causes NRE!?
			def_c.ClientCredentials.ClientCertificate.Certificate =
				new X509Certificate2 ("Test/Resources/test.cer");
			r.Properties [ReqType.IssuedSecurityTokenParametersProperty] =
				new X509SecurityTokenParameters ();
			r.TargetAddress = CreateEndpointAddress ("http://localhost:8080", true);
			r.IssuerAddress = CreateEndpointAddress ("http://localhost:8080", true);
			r.IssuerBinding = new CustomBinding (new HandlerTransportBindingElement (null));
			def_c.ClientCredentials.ServiceCertificate.DefaultCertificate =
				new X509Certificate2 ("Test/Resources/test.cer");

			SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r);
			Assert.IsNotNull (p, "#1");

			ICommunicationObject comm = p as ICommunicationObject;
			Assert.IsNotNull (comm, "#2");
			comm.Open ();
			try {
				p.GetToken (TimeSpan.FromSeconds (5));
			} finally {
				comm.Close ();
			}
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void CreateProviderSecureConvNoTargetAddress ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				CreateRequirement ();
			r.Properties.Remove (ReqType.TargetAddressProperty);
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void CreateProviderSecureConvNoSecurityBindingElement ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				CreateRequirement ();
			r.Properties.Remove (ReqType.SecurityBindingElementProperty);
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void CreateProviderSecureConvNoIssuerBindingContext ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				CreateRequirement ();
			r.Properties.Remove (ReqType.IssuerBindingContextProperty);
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void CreateProviderSecureConvNoKeySize ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = ServiceModelSecurityTokenTypes.SecureConversation;
			r.TargetAddress = new EndpointAddress ("http://localhost:8080");
			r.SecurityBindingElement =
				new SymmetricSecurityBindingElement ();
			r.Properties [ReqType.IssuerBindingContextProperty] =
				new BindingContext (new CustomBinding (), new BindingParameterCollection ());
/* it somehow does not cause an error ...
			InitiatorServiceModelSecurityTokenRequirement r =
				CreateRequirement ();
			r.Properties.Remove (SecurityTokenRequirement.KeySizeProperty);
*/
			def_c.CreateSecurityTokenProvider (r);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void CreateProviderSecureConvNoMessageSecurityVersion ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				CreateRequirement ();
			r.Properties.Remove (ReqType.MessageSecurityVersionProperty);
			def_c.CreateSecurityTokenProvider (r);
		}

		InitiatorServiceModelSecurityTokenRequirement CreateRequirement ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = ServiceModelSecurityTokenTypes.SecureConversation;
			r.TargetAddress = new EndpointAddress ("http://localhost:8080");
			r.SecurityBindingElement =
				new SymmetricSecurityBindingElement ();

			// Without it, mysterious "The key length (blabla) 
			// is not a multiple of 8 for symmetric keys." occurs.
			r.SecureConversationSecurityBindingElement =
				new SymmetricSecurityBindingElement ();

			r.MessageSecurityVersion = MessageSecurityVersion.Default.SecurityTokenVersion;
			r.Properties [ReqType.IssuerBindingContextProperty] =
				new BindingContext (new CustomBinding (new HttpTransportBindingElement ()), new BindingParameterCollection ());
			r.KeySize = 256;
			return r;
		}

		[Test]
		[Category ("NotWorking")]
		public void CreateProviderSecureConv ()
		{
			SecurityTokenRequirement r = CreateRequirement ();
			SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r);
			Assert.IsNotNull (p, "#1");
			// non-standard provider, it looks similar to IssuedSecurityTokenProvider.
		}

		[Test]
		[Ignore ("it ends up to require running service on .NET, and it's anyways too implementation dependent.")]
		public void SecureConvProviderGetToken ()
		{
			X509Certificate2 cert = new X509Certificate2 ("Test/Resources/test.pfx", "mono");

			InitiatorServiceModelSecurityTokenRequirement r =
				CreateRequirement ();
			// it still requires SecurityAlgorithmSuite on GetToken().
			r.SecurityAlgorithmSuite = SecurityAlgorithmSuite.Default;
			// the actual security binding element requires
			// ProtectionTokenParameters.
			r.SecureConversationSecurityBindingElement =
				SecurityBindingElement.CreateAnonymousForCertificateBindingElement ();
			// the above requires service certificate
			BindingContext ctx = r.GetProperty<BindingContext> (ReqType.IssuerBindingContextProperty);
			ClientCredentials cred = new ClientCredentials ();
			cred.ServiceCertificate.DefaultCertificate = cert;
			ctx.BindingParameters.Add (cred);

			// without it, identity check fails on IssuerAddress
			// (TargetAddress is used when IssuerAddress is not set)
			r.TargetAddress = new EndpointAddress (new Uri ("http://localhost:8080"), new X509CertificateEndpointIdentity (cert));

			SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r);
			Assert.IsNotNull (p, "#1");
			// non-standard provider, it looks similar to IssuedSecurityTokenProvider.
			((ICommunicationObject) p).Open ();
			p.GetToken (TimeSpan.FromSeconds (5));
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		[Category ("NotWorking")]
		public void SecureConvProviderOnlyWithIssuedParameters ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = ServiceModelSecurityTokenTypes.SecureConversation;
			IssuedSecurityTokenParameters ip =
				new IssuedSecurityTokenParameters ();
			ip.IssuerAddress = new EndpointAddress ("http://localhost:8080");
			ip.IssuerBinding = new WSHttpBinding ();

			r.Properties [ReqType.IssuedSecurityTokenParametersProperty] = ip;

			SecurityTokenProvider p =
				def_c.CreateSecurityTokenProvider (r);
		}

		// CreateSecurityTokenAuthenticator

		[Test]
		[ExpectedException (typeof (NotSupportedException))]
		public void CreateAuthenticatorUserName ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.UserName;
			def_c.ClientCredentials.UserName.UserName = "mono";
			SecurityTokenResolver resolver;
			def_c.CreateSecurityTokenAuthenticator (r, out resolver);
		}

		[Test]
		public void CreateAuthenticatorRsa ()
		{
			InitiatorServiceModelSecurityTokenRequirement r =
				new InitiatorServiceModelSecurityTokenRequirement ();
			r.TokenType = SecurityTokenTypes.Rsa;
			SecurityTokenResolver resolver;
			RsaSecurityTokenAuthenticator rsa =
				def_c.CreateSecurityTokenAuthenticator (r, out resolver)
				as RsaSecurityTokenAuthenticator;
			Assert.IsNotNull (rsa, "#1");
		}
	}
}
