//
// WSSecurityTokenSerializerTest.cs
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
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Xml;
using NUnit.Framework;

namespace MonoTests.System.ServiceModel.Security
{
	[TestFixture]
	public class WSSecurityTokenSerializerTest
	{
		static X509Certificate2 cert = new X509Certificate2 ("Test/Resources/test.pfx", "mono");

		const string derived_key_token1 = @"<c:DerivedKeyToken xmlns:c='http://schemas.xmlsoap.org/ws/2005/02/sc'>
        <o:SecurityTokenReference xmlns:o='http://docs.oasis-open.org/wss/2004/0
1/oasis-200401-wss-wssecurity-secext-1.0.xsd'>
          <o:Reference ValueType='http://docs.oasis-open.org/wss/oasis-wss-soap-
message-security-1.1#EncryptedKey' URI='#uuid:urn:abc' />
        </o:SecurityTokenReference>
        <c:Offset>0</c:Offset>
        <c:Length>24</c:Length>
        <c:Nonce>BIUeTKeOhR5HeE646ZyA+w==</c:Nonce>
      </c:DerivedKeyToken>";

		XmlWriterSettings GetWriterSettings ()
		{
			XmlWriterSettings s = new XmlWriterSettings ();
			s.OmitXmlDeclaration = true;
			return s;
		}

		[Test]
		public void DefaultValues ()
		{
			WSSecurityTokenSerializer ser = new WSSecurityTokenSerializer ();
			DefaultValues (ser);
			DefaultValues (WSSecurityTokenSerializer.DefaultInstance);
		}

		void DefaultValues (WSSecurityTokenSerializer ser)
		{
			Assert.AreEqual (false, ser.EmitBspRequiredAttributes, "#1");
			Assert.AreEqual (128, ser.MaximumKeyDerivationLabelLength, "#2");
			Assert.AreEqual (128, ser.MaximumKeyDerivationNonceLength, "#3");
			Assert.AreEqual (64, ser.MaximumKeyDerivationOffset, "#4");
			Assert.AreEqual (SecurityVersion.WSSecurity11, ser.SecurityVersion, "#5");
		}

		[Test]
		public void WriteX509SecurityToken1 ()
		{
			StringWriter sw = new StringWriter ();
			X509SecurityToken t = new X509SecurityToken (cert, "urn:x509:1");
			Assert.IsNotNull (cert.GetRawCertData (), "premise: X509Certificate2.RawData");
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteToken (w, t);
			}
			string rawdata = Convert.ToBase64String (cert.RawData);
			Assert.AreEqual ("<o:BinarySecurityToken u:Id=\"urn:x509:1\" ValueType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\">" + rawdata + "</o:BinarySecurityToken>", sw.ToString ());
		}

		[Test]
		public void WriteUserNameSecurityToken1 ()
		{
			StringWriter sw = new StringWriter ();
			UserNameSecurityToken t = new UserNameSecurityToken ("mono", "poly", "urn:username:1");
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteToken (w, t);
			}
			// Hmm, no PasswordToken (and TokenType) ?
			Assert.AreEqual ("<o:UsernameToken u:Id=\"urn:username:1\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\"><o:Username>mono</o:Username><o:Password>poly</o:Password></o:UsernameToken>", sw.ToString ());
		}

		[Test]
		public void WriteBinarySecretSecurityToken1 ()
		{
			StringWriter sw = new StringWriter ();
			byte [] bytes = new byte [] {0, 1, 2, 3, 4, 5, 6, 7};
			BinarySecretSecurityToken t = new BinarySecretSecurityToken ("urn:binary:1", bytes);
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteToken (w, t);
			}
			// AAECAwQFBgc=
			string base64 = Convert.ToBase64String (bytes);
			Assert.AreEqual ("<t:BinarySecret u:Id=\"urn:binary:1\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:t=\"http://schemas.xmlsoap.org/ws/2005/02/trust\">" + base64 + "</t:BinarySecret>", sw.ToString ());
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void WriteRsaSecurityToken ()
		{
			StringWriter sw = new StringWriter ();
			RSA rsa = (RSA) cert.PublicKey.Key;
			RsaSecurityToken t = new RsaSecurityToken (rsa, "urn:rsa:1");
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteToken (w, t);
			}
		}

		[Test]
		[Category ("NotWorking")]
		public void WriteGenericXmlSecurityToken1 ()
		{
			StringWriter sw = new StringWriter ();

			XmlElement xml = new XmlDocument ().CreateElement ("foo");
			SecurityToken token = new X509SecurityToken (new X509Certificate2 ("Test/Resources/test.pfx", "mono"));
			SecurityKeyIdentifierClause intref =
				token.CreateKeyIdentifierClause<X509IssuerSerialKeyIdentifierClause> ();
			SecurityKeyIdentifierClause extref =
			null; //	token.CreateKeyIdentifierClause<X509IssuerSerialKeyIdentifierClause> ();
			ReadOnlyCollection<IAuthorizationPolicy> policies =
				new ReadOnlyCollection<IAuthorizationPolicy> (
					new IAuthorizationPolicy [0]);

			GenericXmlSecurityToken t = new GenericXmlSecurityToken (xml, token, DateTime.Now, new DateTime (2112, 9, 3), intref, extref, policies);
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteToken (w, t);
			}
			// Huh?
			Assert.AreEqual ("<foo />", sw.ToString ());
		}

		[Test]
		public void WriteWrappedKeySecurityToken ()
		{
			StringWriter sw = new StringWriter ();
			byte [] bytes = new byte [64];
			for (byte i = 1; i < 64; i++)
				bytes [i] = i;

			SecurityToken wt = new X509SecurityToken (cert);
			SecurityKeyIdentifier ski = new SecurityKeyIdentifier (
				wt.CreateKeyIdentifierClause< X509ThumbprintKeyIdentifierClause> ());
			WrappedKeySecurityToken t = new WrappedKeySecurityToken (
				"urn:wrapper-key:1", bytes, SecurityAlgorithms.RsaOaepKeyWrap, wt, ski);

			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteToken (w, t);
			}
			string actual = sw.ToString ();
			int idx = actual.IndexOf ("<e:CipherValue>", StringComparison.Ordinal);
			Assert.IsTrue (idx >= 0, "No <CipherValue>");
			actual = 
				actual.Substring (0, idx) +
				"<e:CipherValue>removed here" +
				actual.Substring (actual.IndexOf ("</e:CipherValue>", StringComparison.Ordinal));
			Assert.AreEqual ("GQ3YHlGQhDF1bvMixHliX4uLjlY=", Convert.ToBase64String (cert.GetCertHash ()), "premise#1");
			Assert.AreEqual (
				String.Format ("<e:EncryptedKey Id=\"urn:wrapper-key:1\" xmlns:e=\"{0}\"><e:EncryptionMethod Algorithm=\"{1}\"><DigestMethod Algorithm=\"{2}\" xmlns=\"{3}\" /></e:EncryptionMethod><KeyInfo xmlns=\"{3}\"><o:SecurityTokenReference xmlns:o=\"{4}\"><o:KeyIdentifier ValueType=\"{5}\">{6}</o:KeyIdentifier></o:SecurityTokenReference></KeyInfo><e:CipherData><e:CipherValue>removed here</e:CipherValue></e:CipherData></e:EncryptedKey>",
					EncryptedXml.XmlEncNamespaceUrl,
					SecurityAlgorithms.RsaOaepKeyWrap,
					SignedXml.XmlDsigSHA1Url,
					SignedXml.XmlDsigNamespaceUrl,
					"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd",
					"http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#ThumbprintSHA1",
					Convert.ToBase64String (cert.GetCertHash ())),// "GQ3YHlGQhDF1bvMixHliX4uLjlY="
				actual);
		}

		[Test]
		[Category ("NotWorking")]
		public void WriteSecurityContextSecurityToken ()
		{
			StringWriter sw = new StringWriter ();
			SecurityContextSecurityToken t = new SecurityContextSecurityToken (
				new UniqueId ("urn:unique-id:securitycontext:1"),
				"urn:securitycontext:1",
				Convert.FromBase64String ("o/ilseZu+keLBBWGGPlUHweqxIPc4gzZEFWr2nBt640="),
				new DateTime (2006, 9, 26), new DateTime (2006, 9, 27));
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteToken (w, t);
			}
			Assert.AreEqual ("<c:SecurityContextToken u:Id=\"urn:securitycontext:1\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:c=\"http://schemas.xmlsoap.org/ws/2005/02/sc\"><c:Identifier>urn:unique-id:securitycontext:1</c:Identifier></c:SecurityContextToken>", sw.ToString ());
		}

		[Test]
		public void WriteX509IssuerSerialKeyIdentifierClause1 ()
		{
			StringWriter sw = new StringWriter ();
			X509IssuerSerialKeyIdentifierClause ic = new X509IssuerSerialKeyIdentifierClause  (cert);
			string expected = "<o:SecurityTokenReference xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\"><X509Data xmlns=\"http://www.w3.org/2000/09/xmldsig#\"><X509IssuerSerial><X509IssuerName>CN=Mono Test Root Agency</X509IssuerName><X509SerialNumber>22491767666218099257720700881460366085</X509SerialNumber></X509IssuerSerial></X509Data></o:SecurityTokenReference>";

			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteKeyIdentifierClause (w, ic);
			}
			Assert.AreEqual (expected, sw.ToString (), "WSS1.1");

			sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				new WSSecurityTokenSerializer (SecurityVersion.WSSecurity10).WriteKeyIdentifierClause (w, ic);
			Assert.AreEqual (expected, sw.ToString (), "WSS1.0");
			}
		}

		[Test]
		public void WriteX509ThumbprintKeyIdentifierClause1 ()
		{
			StringWriter sw = new StringWriter ();
			X509ThumbprintKeyIdentifierClause ic = new X509ThumbprintKeyIdentifierClause (cert);
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteKeyIdentifierClause (w, ic);
			}
			Assert.AreEqual ("<o:SecurityTokenReference xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\"><o:KeyIdentifier ValueType=\"http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#ThumbprintSHA1\">GQ3YHlGQhDF1bvMixHliX4uLjlY=</o:KeyIdentifier></o:SecurityTokenReference>", sw.ToString ());
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void WriteX509ThumbprintKeyIdentifierClause2 ()
		{
			using (XmlWriter w = XmlWriter.Create (TextWriter.Null)) {
				new WSSecurityTokenSerializer (SecurityVersion.WSSecurity10)
					.WriteKeyIdentifierClause (w, new X509ThumbprintKeyIdentifierClause (cert));
			}
		}

		[Test]
		public void WriteEncryptedKeyIdentifierClause ()
		{
			StringWriter sw = new StringWriter ();
			byte [] bytes = new byte [32];
			SecurityKeyIdentifier cki = new SecurityKeyIdentifier ();
			cki.Add (new X509ThumbprintKeyIdentifierClause (cert));
			EncryptedKeyIdentifierClause ic =
				new EncryptedKeyIdentifierClause (bytes, SecurityAlgorithms.Aes256KeyWrap, cki);
			
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteKeyIdentifierClause (w, ic);
			}
			string expected = String.Format ("<e:EncryptedKey xmlns:e=\"{0}\"><e:EncryptionMethod Algorithm=\"{1}\" /><KeyInfo xmlns=\"{2}\"><o:SecurityTokenReference xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\"><o:KeyIdentifier ValueType=\"{3}\">GQ3YHlGQhDF1bvMixHliX4uLjlY=</o:KeyIdentifier></o:SecurityTokenReference></KeyInfo><e:CipherData><e:CipherValue>AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=</e:CipherValue></e:CipherData></e:EncryptedKey>",
				EncryptedXml.XmlEncNamespaceUrl,
				SecurityAlgorithms.Aes256KeyWrap,
				SignedXml.XmlDsigNamespaceUrl,
				"http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#ThumbprintSHA1");
			Assert.AreEqual (expected, sw.ToString ());
		}

		[Test]
		public void WriteLocalIdKeyIdentifierClause1 ()
		{
			StringWriter sw = new StringWriter ();
			LocalIdKeyIdentifierClause ic = new LocalIdKeyIdentifierClause ("urn:myIDValue");
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteKeyIdentifierClause (w, ic);
			}
			Assert.AreEqual ("<o:SecurityTokenReference xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\"><o:Reference URI=\"#urn:myIDValue\" /></o:SecurityTokenReference>", sw.ToString (), "#1");
		}

		[Test]
		public void WriteLocalIdKeyIdentifierClause2 ()
		{
			StringWriter sw = new StringWriter ();
			LocalIdKeyIdentifierClause ic = new LocalIdKeyIdentifierClause ("#urn:myIDValue");
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteKeyIdentifierClause (w, ic);
			}
			// ... so, specifying an URI including '#' does not make sense
			Assert.AreEqual ("<o:SecurityTokenReference xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\"><o:Reference URI=\"##urn:myIDValue\" /></o:SecurityTokenReference>", sw.ToString (), "#2");
		}

		[Test]
		[Category ("NotWorking")] // I believe it should output ValueType attribute, but .net does not.
		public void WriteLocalIdKeyIdentifierClause3 ()
		{
			StringWriter sw = new StringWriter ();
			LocalIdKeyIdentifierClause ic = new LocalIdKeyIdentifierClause ("urn:myIDValue", typeof (WrappedKeySecurityToken));
			using (XmlWriter w = XmlWriter.Create (sw, GetWriterSettings ())) {
				WSSecurityTokenSerializer.DefaultInstance.WriteKeyIdentifierClause (w, ic);
			}
			Assert.AreEqual ("<o:SecurityTokenReference xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\"><o:Reference URI=\"#urn:myIDValue\" /></o:SecurityTokenReference>", sw.ToString (), "#1");
		}

		[Test]
		public void ReadKeyIdentifierClause ()
		{
			string xml = @"<o:SecurityTokenReference xmlns:o='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>
            <o:Reference URI='#uuid-9c90d2c7-c82f-4c63-9b28-fc24479ee3a7-2' />
          </o:SecurityTokenReference>";
			WSSecurityTokenSerializer serializer =
				WSSecurityTokenSerializer.DefaultInstance;
			using (XmlReader xr = XmlReader.Create (new StringReader (xml))) {
				SecurityKeyIdentifierClause kic = serializer.ReadKeyIdentifierClause (xr);
				Assert.IsTrue (kic is LocalIdKeyIdentifierClause, "#1");
			}
		}

		[Test]
		public void ReadEncryptedKeyIdentifierClause ()
		{
			string xml = @"<e:EncryptedKey xmlns:ds='http://www.w3.org/2000/09/xmldsig#' xmlns:e='http://www.w3.org/2001/04/xmlenc#' Id='ID_EncryptedKeyClause'>  <e:EncryptionMethod Algorithm='http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p'>  <ds:DigestMethod Algorithm='http://www.w3.org/2000/09/xmldsig#sha1' />  </e:EncryptionMethod>  <ds:KeyInfo>  <o:SecurityTokenReference xmlns:o='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>  <o:Reference URI='#uuid-9c90d2c7-c82f-4c63-9b28-fc24479ee3a7-2' />  </o:SecurityTokenReference>  </ds:KeyInfo>  <e:CipherData>  <e:CipherValue>Iwg585s5eQP5If4/bY/PPBmHVFt23z6MaHDaD9/u1Ua7hveRfoER3d6sJTk7PL4LoLHjwaAa6EGHZyrgq7He+efvsiAhJYTeh/C/RYO7jKdSr8Gp1IIY7wA+/CBhV7SUhRZs4YJ1GE+rIQ/No6FPk/MbpIALEZ6RpqiLYVVCvUI=</e:CipherValue>  </e:CipherData></e:EncryptedKey>";
			WSSecurityTokenSerializer serializer =
				WSSecurityTokenSerializer.DefaultInstance;
			EncryptedKeyIdentifierClause kic;
			using (XmlReader xr = XmlReader.Create (new StringReader (xml))) {
				kic = serializer.ReadKeyIdentifierClause (xr) as EncryptedKeyIdentifierClause;
			}
			Assert.IsNotNull (kic, "#1");
			Assert.IsNull (kic.CarriedKeyName, "#2");
			Assert.AreEqual (EncryptedXml.XmlEncRSAOAEPUrl, kic.EncryptionMethod, "#3");
			Assert.AreEqual (1, kic.EncryptingKeyIdentifier.Count, "#4");
			LocalIdKeyIdentifierClause ekic = kic.EncryptingKeyIdentifier [0] as LocalIdKeyIdentifierClause;
			Assert.IsNotNull (ekic, "#5");
			Assert.AreEqual ("uuid-9c90d2c7-c82f-4c63-9b28-fc24479ee3a7-2", ekic.LocalId, "#6");
		}

		[Test]
		[ExpectedException (typeof (XmlException))] // KeyIdentifier is not the expected element.
		public void ReadKeyIdentifierReference ()
		{
			string xml = @"<o:SecurityTokenReference xmlns:o='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd'>
            <o:KeyIdentifier ValueType='http://docs.oasis-open.org/wss/oasis-wss
-soap-message-security-1.1#ThumbprintSHA1' EncodingType='http://docs.oasis-open.
org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary'>xr42fAK
DBNItO0aRPKFqc0kaiiU=</o:KeyIdentifier>
          </o:SecurityTokenReference>";
			WSSecurityTokenSerializer serializer =
				WSSecurityTokenSerializer.DefaultInstance;
			using (XmlReader xr = XmlReader.Create (new StringReader (xml))) {
				SecurityKeyIdentifierClause kic = serializer.ReadKeyIdentifierClause (xr);
				Assert.IsTrue (kic is X509ThumbprintKeyIdentifierClause, "#1");
			}
		}

		[Test]
		[ExpectedException (typeof (XmlException))] // tokenResolver is null
		[Category ("NotWorking")]
		public void ReadTokenDerivedKeyTokenNullResolver ()
		{
			WSSecurityTokenSerializer serializer =
				WSSecurityTokenSerializer.DefaultInstance;
			using (XmlReader xr = XmlReader.Create (new StringReader (derived_key_token1))) {
				SecurityToken token = serializer.ReadToken (xr, null);
			}
		}

		[Test]
		[ExpectedException (typeof (XmlException))] // DerivedKeyToken requires a reference to an existent token.
		[Category ("NotWorking")]
		public void ReadTokenDerivedKeyTokenRefToNonExistent ()
		{
			WSSecurityTokenSerializer serializer =
				WSSecurityTokenSerializer.DefaultInstance;
			using (XmlReader xr = XmlReader.Create (new StringReader (derived_key_token1))) {
				SecurityToken token = serializer.ReadToken (xr, GetResolver ());
			}
		}

		[Test]
		[Ignore ("still fails")]
		public void ReadTokenDerivedKeyTokenRefToExistent ()
		{
			WSSecurityTokenSerializer serializer =
				WSSecurityTokenSerializer.DefaultInstance;
			using (XmlReader xr = XmlReader.Create (new StringReader (derived_key_token1))) {
				SecurityToken token = serializer.ReadToken (xr,
					GetResolver (new X509SecurityToken (cert, "uuid:urn:abc")));
				Assert.IsTrue (token is SecurityContextSecurityToken, "#1");
			}
		}

		[Test]
		[Category ("NotWorking")]
		public void ReadSecurityContextSecurityTokenNoRegisteredToken ()
		{
			try {
				ReadSecurityContextSecurityTokenNoRegisteredTokenCore ();
				Assert.Fail ("Exception expected.");
			} catch (SecurityTokenException) {
			}
		}

		void ReadSecurityContextSecurityTokenNoRegisteredTokenCore ()
		{
			string xml = "<c:SecurityContextToken u:Id=\"urn:securitycontext:1\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:c=\"http://schemas.xmlsoap.org/ws/2005/02/sc\"><c:Identifier>urn:unique-id:securitycontext:1</c:Identifier></c:SecurityContextToken>";

			WSSecurityTokenSerializer serializer =
				WSSecurityTokenSerializer.DefaultInstance;
			using (XmlReader xr = XmlReader.Create (new StringReader (xml))) {
				SecurityToken token = serializer.ReadToken (xr, GetResolver (new X509SecurityToken (cert, "urn:unique-id:securitycontext:1")));
				Assert.IsTrue (token is SecurityContextSecurityToken, "#1");
			}
		}

		class MyResolver : SecurityTokenResolver
		{
			protected override bool TryResolveTokenCore (SecurityKeyIdentifier ident, out SecurityToken token)
			{
throw new Exception ("1");
				token = null;
				return false;
			}

			protected override bool TryResolveTokenCore (SecurityKeyIdentifierClause clause, out SecurityToken token)
			{
throw new Exception ("2");
				token = null;
				return false;
			}

			protected override bool TryResolveSecurityKeyCore (SecurityKeyIdentifierClause clause, out SecurityKey key)
			{
throw new Exception ("3");
				key = null;
				return false;
			}
		}

		SecurityTokenResolver GetResolver (params SecurityToken [] tokens)
		{
			return SecurityTokenResolver.CreateDefaultSecurityTokenResolver (
				new ReadOnlyCollection<SecurityToken> (tokens), true);
		}

		[Test]
		public void GetTokenTypeUri ()
		{
			new MyWSSecurityTokenSerializer ().TestGetTokenTypeUri ();
		}
	}

	class MyWSSecurityTokenSerializer : WSSecurityTokenSerializer
	{
		public void TestGetTokenTypeUri ()
		{
			Assert.IsNull (GetTokenTypeUri (GetType ()), "#1");
			Assert.AreEqual ("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3",
				GetTokenTypeUri (typeof (X509SecurityToken)), "#2");
			Assert.IsNull (GetTokenTypeUri (typeof (RsaSecurityToken)), "#3");
			Assert.AreEqual ("http://docs.oasis-open.org/wss/oasis-wss-saml-token-profile-1.1#SAMLV1.1",
				GetTokenTypeUri (typeof (SamlSecurityToken)), "#4");
			Assert.AreEqual ("http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#UsernameToken",
				GetTokenTypeUri (typeof (UserNameSecurityToken)), "#5");
			Assert.IsNull (GetTokenTypeUri (typeof (SspiSecurityToken)), "#6");
			Assert.AreEqual ("http://schemas.xmlsoap.org/ws/2005/02/sc/sct",
				GetTokenTypeUri (typeof (SecurityContextSecurityToken)), "#7");
			Assert.IsNull (GetTokenTypeUri (typeof (GenericXmlSecurityToken)), "#8");
			Assert.AreEqual ("http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1#GSS_Kerberosv5_AP_REQ",
				GetTokenTypeUri (typeof (KerberosRequestorSecurityToken)), "#9");
			Assert.AreEqual ("http://docs.oasis-open.org/wss/oasis-wss-soap-message-security-1.1#EncryptedKey",
				GetTokenTypeUri (typeof (WrappedKeySecurityToken)), "#10");
		}
	}
}
