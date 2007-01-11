//
// SecurityBindingElementTest.cs
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;
using NUnit.Framework;

namespace MonoTests.System.ServiceModel.Channels
{
	[TestFixture]
	public class SecurityBindingElementTest
	{
		#region Factory methods

		[Test]
		public void CreateAnonymousForCertificateBindingElement ()
		{
			SymmetricSecurityBindingElement be =
				SecurityBindingElement.CreateAnonymousForCertificateBindingElement ();

			SecurityAssert.AssertSymmetricSecurityBindingElement (
				SecurityAlgorithmSuite.Default,
				true, // IncludeTimestamp
				SecurityKeyEntropyMode.CombinedEntropy,
				MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature,
				MessageSecurityVersion.Default,
				true, // RequireSignatureConfirmation
				SecurityHeaderLayout.Strict,
				// EndpointSupportingTokenParameters: endorsing, signed, signedEncrypted, signedEndorsing (by count)
				0, 0, 0, 0,
				// ProtectionTokenParameters
				true, SecurityTokenInclusionMode.Never, SecurityTokenReferenceStyle.Internal, true,
				// LocalClientSettings
				true, 60, true,

				be, "");

			// test ProtectionTokenParameters
			X509SecurityTokenParameters tp =
				be.ProtectionTokenParameters
				as X509SecurityTokenParameters;
			Assert.IsNotNull (tp, "#2-1");
			SecurityAssert.AssertSecurityTokenParameters (
				SecurityTokenInclusionMode.Never,
				SecurityTokenReferenceStyle.Internal, 
				true, tp, "Protection");
			Assert.AreEqual (X509KeyIdentifierClauseType.Thumbprint, tp.X509ReferenceStyle, "#2-2");
		}

		[Test]
		public void CreateIssuedTokenBindingElement1 ()
		{
			IssuedSecurityTokenParameters tp =
				new IssuedSecurityTokenParameters ();
			SymmetricSecurityBindingElement be =
				SecurityBindingElement.CreateIssuedTokenBindingElement (tp);

			SecurityAssert.AssertSymmetricSecurityBindingElement (
				SecurityAlgorithmSuite.Default,
				true, // IncludeTimestamp
				SecurityKeyEntropyMode.CombinedEntropy,
				MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature,
				MessageSecurityVersion.Default,
				false, // RequireSignatureConfirmation
				SecurityHeaderLayout.Strict,
				// EndpointSupportingTokenParameters: endorsing, signed, signedEncrypted, signedEndorsing (by count)
				0, 0, 0, 0,
				// ProtectionTokenParameters
				true, SecurityTokenInclusionMode.AlwaysToRecipient, SecurityTokenReferenceStyle.Internal, true,
				// LocalClientSettings
				true, 60, true,

				be, "");

			// test ProtectionTokenParameters
			Assert.AreEqual (tp, be.ProtectionTokenParameters, "#2-1");
			SecurityAssert.AssertSecurityTokenParameters (
				SecurityTokenInclusionMode.AlwaysToRecipient,
				SecurityTokenReferenceStyle.Internal, 
				true, tp, "Protection");
		}

		[Test]
		public void CreateIssuedTokenForCertificateBindingElement1 ()
		{
			IssuedSecurityTokenParameters tp =
				new IssuedSecurityTokenParameters ();
			SymmetricSecurityBindingElement be =
				SecurityBindingElement.CreateIssuedTokenForCertificateBindingElement (tp);

			SecurityAssert.AssertSymmetricSecurityBindingElement (
				SecurityAlgorithmSuite.Default,
				true, // IncludeTimestamp
				SecurityKeyEntropyMode.CombinedEntropy,
				MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature,
				MessageSecurityVersion.Default,
				true, // RequireSignatureConfirmation
				SecurityHeaderLayout.Strict,
				// EndpointSupportingTokenParameters: endorsing, signed, signedEncrypted, signedEndorsing (by count)
				1, 0, 0, 0,
				// ProtectionTokenParameters
				true, SecurityTokenInclusionMode.Never, SecurityTokenReferenceStyle.Internal, true,
				// LocalClientSettings
				true, 60, true,

				be, "");

			// test ProtectionTokenParameters
			X509SecurityTokenParameters ptp =
				be.ProtectionTokenParameters
				as X509SecurityTokenParameters;
			Assert.IsNotNull (ptp, "#2-1");
			SecurityAssert.AssertSecurityTokenParameters (
				SecurityTokenInclusionMode.Never,
				SecurityTokenReferenceStyle.Internal, 
				true, ptp, "Protection");
			Assert.AreEqual (X509KeyIdentifierClauseType.Thumbprint, ptp.X509ReferenceStyle, "#2-2");

			Assert.AreEqual (tp, be.EndpointSupportingTokenParameters.Endorsing [0], "EndpointParams.Endorsing[0]");
		}

		[Test]
		public void CreateIssuedTokenForSslBindingElement1 ()
		{
			IssuedSecurityTokenParameters tp =
				new IssuedSecurityTokenParameters ();
			SymmetricSecurityBindingElement be =
				SecurityBindingElement.CreateIssuedTokenForSslBindingElement (tp);

			SecurityAssert.AssertSymmetricSecurityBindingElement (
				SecurityAlgorithmSuite.Default,
				true, // IncludeTimestamp
				SecurityKeyEntropyMode.CombinedEntropy,
				MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature,
				MessageSecurityVersion.Default,
				true, // RequireSignatureConfirmation
				SecurityHeaderLayout.Strict,
				// EndpointSupportingTokenParameters: endorsing, signed, signedEncrypted, signedEndorsing (by count)
				1, 0, 0, 0,
				// ProtectionTokenParameters
				true, SecurityTokenInclusionMode.AlwaysToRecipient, SecurityTokenReferenceStyle.Internal, true,
				// LocalClientSettings
				true, 60, true,

				be, "");

			Assert.AreEqual (tp, be.EndpointSupportingTokenParameters.Endorsing [0], "EndpointParams.Endorsing[0]");

			// FIXME: test ProtectionTokenParameters
		}

		[Test]
		public void CreateKerberosBindingElement ()
		{
			SymmetricSecurityBindingElement be =
				SecurityBindingElement.CreateKerberosBindingElement ();

			SecurityAssert.AssertSymmetricSecurityBindingElement (
				SecurityAlgorithmSuite.Basic128,
				true, // IncludeTimestamp
				SecurityKeyEntropyMode.CombinedEntropy,
				MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature,
				MessageSecurityVersion.Default,
				false, // RequireSignatureConfirmation
				SecurityHeaderLayout.Strict,
				// EndpointSupportingTokenParameters: endorsing, signed, signedEncrypted, signedEndorsing (by count)
				0, 0, 0, 0,
				// ProtectionTokenParameters
				true, SecurityTokenInclusionMode.Once, SecurityTokenReferenceStyle.Internal, true,
				// LocalClientSettings
				true, 60, true,

				be, "");

			// FIXME: test ProtectionTokenParameters
		}

		[Test]
		public void CreateSslNegotiationBindingElement ()
		{
			SymmetricSecurityBindingElement be =
				SecurityBindingElement.CreateSslNegotiationBindingElement (true, true);

			SecurityAssert.AssertSymmetricSecurityBindingElement (
				SecurityAlgorithmSuite.Default,
				true, // IncludeTimestamp
				SecurityKeyEntropyMode.CombinedEntropy,
				MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature,
				MessageSecurityVersion.Default,
				false, // RequireSignatureConfirmation
				SecurityHeaderLayout.Strict,
				// EndpointSupportingTokenParameters: endorsing, signed, signedEncrypted, signedEndorsing (by count)
				0, 0, 0, 0,
				// ProtectionTokenParameters
				true, SecurityTokenInclusionMode.AlwaysToRecipient, SecurityTokenReferenceStyle.Internal, true,
				// LocalClientSettings
				true, 60, true,

				be, "");

			// FIXME: also try different constructor arguments

			// FIXME: test ProtectionTokenParameters
		}

		[Test]
		public void CreateSspiNegotiationBindingElement ()
		{
			SymmetricSecurityBindingElement be =
				SecurityBindingElement.CreateSspiNegotiationBindingElement ();

			SecurityAssert.AssertSymmetricSecurityBindingElement (
				SecurityAlgorithmSuite.Default,
				true, // IncludeTimestamp
				SecurityKeyEntropyMode.CombinedEntropy,
				MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature,
				MessageSecurityVersion.Default,
				false, // RequireSignatureConfirmation
				SecurityHeaderLayout.Strict,
				// EndpointSupportingTokenParameters: endorsing, signed, signedEncrypted, signedEndorsing (by count)
				0, 0, 0, 0,
				// ProtectionTokenParameters
				true, SecurityTokenInclusionMode.AlwaysToRecipient, SecurityTokenReferenceStyle.Internal, true,
				// LocalClientSettings
				true, 60, true,

				be, "");

			// FIXME: Try boolean argument as well.

			// FIXME: test ProtectionTokenParameters
		}

		[Test]
		public void CreateUserNameForCertificateBindingElement ()
		{
			SymmetricSecurityBindingElement be =
				SecurityBindingElement.CreateUserNameForCertificateBindingElement ();

			SecurityAssert.AssertSymmetricSecurityBindingElement (
				SecurityAlgorithmSuite.Default,
				true, // IncludeTimestamp
				SecurityKeyEntropyMode.CombinedEntropy,
				MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature,
				MessageSecurityVersion.Default,
				false, // RequireSignatureConfirmation
				SecurityHeaderLayout.Strict,
				// EndpointSupportingTokenParameters: endorsing, signed, signedEncrypted, signedEndorsing (by count)
				0, 0, 1, 0,
				// ProtectionTokenParameters
				true, SecurityTokenInclusionMode.Never, SecurityTokenReferenceStyle.Internal, true,
				// LocalClientSettings
				true, 60, true,

				be, "");

			UserNameSecurityTokenParameters up =
				be.EndpointSupportingTokenParameters.SignedEncrypted [0] as UserNameSecurityTokenParameters;
			// FIXME: test it

			// FIXME: test ProtectionTokenParameters
		}

		[Test]
		public void CreateUserNameForSslBindingElement ()
		{
			SymmetricSecurityBindingElement be =
				SecurityBindingElement.CreateUserNameForSslBindingElement ();

			SecurityAssert.AssertSymmetricSecurityBindingElement (
				SecurityAlgorithmSuite.Default,
				true, // IncludeTimestamp
				SecurityKeyEntropyMode.CombinedEntropy,
				MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature,
				MessageSecurityVersion.Default,
				false, // RequireSignatureConfirmation
				SecurityHeaderLayout.Strict,
				// EndpointSupportingTokenParameters: endorsing, signed, signedEncrypted, signedEndorsing (by count)
				0, 0, 1, 0,
				// ProtectionTokenParameters
				true, SecurityTokenInclusionMode.AlwaysToRecipient, SecurityTokenReferenceStyle.Internal, true,
				// LocalClientSettings
				true, 60, true,

				be, "");

			UserNameSecurityTokenParameters up =
				be.EndpointSupportingTokenParameters.SignedEncrypted [0] as UserNameSecurityTokenParameters;
			// FIXME: test it

			// FIXME: test ProtectionTokenParameters
		}

		// non-symmetric return value by definition, but still
		// returns symmetric binding elements.

		[Test]
		public void CreateSecureConversationBindingElement ()
		{
			SymmetricSecurityBindingElement be =
				SecurityBindingElement.CreateSecureConversationBindingElement (new SymmetricSecurityBindingElement ())
				as SymmetricSecurityBindingElement;

			SecurityAssert.AssertSymmetricSecurityBindingElement (
				SecurityAlgorithmSuite.Default,
				true, // IncludeTimestamp
				SecurityKeyEntropyMode.CombinedEntropy,
				MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature,
				MessageSecurityVersion.Default,
				false, // RequireSignatureConfirmation
				SecurityHeaderLayout.Strict,
				// EndpointSupportingTokenParameters: endorsing, signed, signedEncrypted, signedEndorsing (by count)
				0, 0, 0, 0,
				// ProtectionTokenParameters
				true, SecurityTokenInclusionMode.AlwaysToRecipient, SecurityTokenReferenceStyle.Internal, true,
				// LocalClientSettings
				true, 60, true,

				be, "");

			// test ProtectionTokenParameters
			SecureConversationSecurityTokenParameters tp =
				be.ProtectionTokenParameters as SecureConversationSecurityTokenParameters;
			Assert.IsNotNull (tp, "#2-1");

			SecurityAssert.AssertSecurityTokenParameters (
				SecurityTokenInclusionMode.AlwaysToRecipient,
				SecurityTokenReferenceStyle.Internal,
				true, tp, "Protection");
		}

		#endregion

		[Test]
		public void SetKeyDerivation ()
		{
			SetKeyDerivationCorrect (new TransportSecurityBindingElement (), "transport");
			SetKeyDerivationIncorrect (new TransportSecurityBindingElement (), "transport");
			SetKeyDerivationCorrect (new SymmetricSecurityBindingElement (), "symmetric");
			SetKeyDerivationIncorrect (new SymmetricSecurityBindingElement (), "symmetric");
			SetKeyDerivationCorrect (new AsymmetricSecurityBindingElement (), "asymmetric");
			SetKeyDerivationIncorrect (new AsymmetricSecurityBindingElement (), "asymmetric");
		}

		void SetKeyDerivationCorrect (SecurityBindingElement be, string label)
		{
			X509SecurityTokenParameters p, p2;
			p = new X509SecurityTokenParameters ();
			p2 = new X509SecurityTokenParameters ();
			Assert.AreEqual (true, p.RequireDerivedKeys, label + "#1");
			Assert.AreEqual (true, p2.RequireDerivedKeys, label + "#2");
			be.EndpointSupportingTokenParameters.Endorsing.Add (p);
			be.EndpointSupportingTokenParameters.Endorsing.Add (p2);
			be.SetKeyDerivation (false);
			Assert.AreEqual (false, p.RequireDerivedKeys, label + "#3");
			Assert.AreEqual (false, p2.RequireDerivedKeys, label + "#4");
		}

		void SetKeyDerivationIncorrect (SecurityBindingElement be, string label)
		{
			X509SecurityTokenParameters p, p2;
			p = new X509SecurityTokenParameters ();
			p2 = new X509SecurityTokenParameters ();
			// setting in prior - makes no sense
			be.SetKeyDerivation (false);
			be.EndpointSupportingTokenParameters.Endorsing.Add (p);
			be.EndpointSupportingTokenParameters.Endorsing.Add (p2);
			Assert.AreEqual (true, p.RequireDerivedKeys, label + "#5");
			Assert.AreEqual (true, p2.RequireDerivedKeys, label + "#6");
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		[Category ("NotWorking")]
		public void CheckDuplicateAuthenticatorTypesClient ()
		{
			SymmetricSecurityBindingElement be =
				new SymmetricSecurityBindingElement ();
			be.ProtectionTokenParameters =
				new X509SecurityTokenParameters ();
			be.EndpointSupportingTokenParameters.Endorsing.Add (
				new X509SecurityTokenParameters ());
			// This causes multiple supporting token authenticator
			// of the same type.
			be.OptionalEndpointSupportingTokenParameters.Endorsing.Add (
				new X509SecurityTokenParameters ());
			Binding b = new CustomBinding (be, new HttpTransportBindingElement ());
			ClientCredentials cred = new ClientCredentials ();
			cred.ClientCertificate.Certificate =
				new X509Certificate2 ("Test/Resources/test.pfx", "mono");
			IChannelFactory<IReplyChannel> ch = b.BuildChannelFactory<IReplyChannel> (new Uri ("http://localhost:37564"), cred);
			ch.Open ();
			// in case Open() failed to raise an error...
			ch.Close ();
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		[Category ("NotWorking")]
		public void CheckDuplicateAuthenticatorTypesService ()
		{
			SymmetricSecurityBindingElement be =
				new SymmetricSecurityBindingElement ();
			be.ProtectionTokenParameters =
				new X509SecurityTokenParameters ();
			be.EndpointSupportingTokenParameters.Endorsing.Add (
				new X509SecurityTokenParameters ());
			// This causes multiple supporting token authenticator
			// of the same type.
			be.OptionalEndpointSupportingTokenParameters.Endorsing.Add (
				new X509SecurityTokenParameters ());
			Binding b = new CustomBinding (be, new HttpTransportBindingElement ());
			ServiceCredentials cred = new ServiceCredentials ();
			cred.ServiceCertificate.Certificate =
				new X509Certificate2 ("Test/Resources/test.pfx", "mono");
			IChannelListener<IReplyChannel> ch = b.BuildChannelListener<IReplyChannel> (new Uri ("http://localhost:37564"), cred);
			ch.Open ();
			// in case Open() failed to raise an error...
			ch.Close ();
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void NonEndorsibleParameterInEndorsingSupport ()
		{
			SymmetricSecurityBindingElement be =
				new SymmetricSecurityBindingElement ();
			be.ProtectionTokenParameters =
				new X509SecurityTokenParameters ();
			be.EndpointSupportingTokenParameters.Endorsing.Add (
				new UserNameSecurityTokenParameters ());
			Binding b = new CustomBinding (be, new HttpTransportBindingElement ());
			X509Certificate2 cert = new X509Certificate2 ("Test/Resources/test.pfx", "mono");
			EndpointAddress ea = new EndpointAddress (new Uri ("http://localhost:37564"), new X509CertificateEndpointIdentity (cert));
			CalcProxy client = new CalcProxy (b, ea);
			client.ClientCredentials.UserName.UserName = "rupert";
			client.Sum (1, 2);
		}
	}
}
