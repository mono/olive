//
// SecureMessageDecryptor.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2006-2007 Novell, Inc (http://www.novell.com)
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
using System.Globalization;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Xml;
using System.Xml.XPath;

using ReqType = System.ServiceModel.Security.Tokens.ServiceModelSecurityTokenRequirement;

namespace System.ServiceModel.Channels
{
	internal class RecipientSecureMessageDecryptor : SecureMessageDecryptor
	{
		RecipientMessageSecurityBindingSupport security;

		public RecipientSecureMessageDecryptor (
			Message source, RecipientMessageSecurityBindingSupport security)
			: base (source, security)
		{
			this.security = security;
		}

		public override MessageDirection Direction {
			get { return MessageDirection.Input; }
		}

		public override SecurityMessageProperty RequestSecurity {
			get { return null; }
		}

		public override SecurityTokenParameters Parameters {
			get { return security.RecipientParameters; }
		}

		public override SecurityTokenParameters CounterParameters {
			get { return security.InitiatorParameters; }
		}
	}

	internal class InitiatorSecureMessageDecryptor : SecureMessageDecryptor
	{
		InitiatorMessageSecurityBindingSupport security;
		SecurityMessageProperty request_security;

		public InitiatorSecureMessageDecryptor (
			Message source, SecurityMessageProperty secprop, InitiatorMessageSecurityBindingSupport security)
			: base (source, security)
		{
			this.security = security;
			request_security = secprop;
		}

		public override SecurityMessageProperty RequestSecurity {
			get { return request_security; }
		}

		public override MessageDirection Direction {
			get { return MessageDirection.Output; }
		}

		public override SecurityTokenParameters Parameters {
			get { return security.InitiatorParameters; }
		}

		public override SecurityTokenParameters CounterParameters {
			get { return security.RecipientParameters; }
		}
	}

	internal abstract class SecureMessageDecryptor
	{
		Message source_message;
		MessageBuffer buf;
		MessageSecurityBindingSupport security;

		XmlDocument doc;
		XmlNamespaceManager nsmgr; // for XPath query

		SecurityMessageProperty sec_prop =
			new SecurityMessageProperty ();
		WSSecurityMessageHeader wss_header = null;
		List<MessageHeaderInfo> headers = new List<MessageHeaderInfo> ();
		SecurityTokenResolver token_resolver;
		List<SecurityToken> tokens;

		protected SecureMessageDecryptor (
			Message source, MessageSecurityBindingSupport security)
		{
			source_message = source;
			this.security = security;

			// FIXME: use proper max buffer
			buf = source.CreateBufferedCopy (int.MaxValue);

			doc = new XmlDocument ();
			doc.PreserveWhitespace = true;

			nsmgr = new XmlNamespaceManager (doc.NameTable);
			nsmgr.AddNamespace ("s", "http://www.w3.org/2003/05/soap-envelope");
			nsmgr.AddNamespace ("c", Constants.WsscNamespace);
			nsmgr.AddNamespace ("o", Constants.WssNamespace);
			nsmgr.AddNamespace ("e", EncryptedXml.XmlEncNamespaceUrl);
			nsmgr.AddNamespace ("u", Constants.WsuNamespace);
			nsmgr.AddNamespace ("dsig", SignedXml.XmlDsigNamespaceUrl);

		}

		public abstract MessageDirection Direction { get; }
		public abstract SecurityTokenParameters Parameters { get; }
		public abstract SecurityTokenParameters CounterParameters { get; }
		public abstract SecurityMessageProperty RequestSecurity { get; }

		public SecurityTokenResolver TokenResolver {
			get { return token_resolver; }
		}

		public Message DecryptMessage ()
		{
			Message srcmsg = buf.CreateMessage ();
			if (srcmsg.Version.Envelope == EnvelopeVersion.None)
				throw new ArgumentException ("The message to decrypt is not an expected SOAP envelope.");

			string action = GetAction ();
			if (action == null)
				throw new ArgumentException ("SOAP action could not be retrieved from the message to decrypt.");

			XPathNavigator nav = doc.CreateNavigator ();
			using (XmlWriter writer = nav.AppendChild ()) {
				buf.CreateMessage ().WriteMessage (writer);
			}

			// read and store headers, wsse:Security and setup in-band resolver.
			ReadHeaders (srcmsg);

			XmlNodeList securityHeaders = doc.SelectNodes ("/s:Envelope/s:Header/o:Security", nsmgr);
			foreach (XmlElement secElem in securityHeaders)
				// FIXME: check Actor. There is only one o:Security which we should handle.
				ExtractSecurity (secElem);

			Message msg = Message.CreateMessage (new XmlNodeReader (doc), srcmsg.Headers.Count, srcmsg.Version);
			for (int i = 0; i < srcmsg.Headers.Count; i++) {
				MessageHeaderInfo header = srcmsg.Headers [i];
				if (header == wss_header)
					msg.Headers.Add (wss_header);
				else
					msg.Headers.CopyHeaderFrom (srcmsg, i);
			}

			// FIXME: when Local[Client|Service]SecuritySettings.DetectReplays
			// is true, reject such messages which don't have <wsu:Timestamp>

			msg.Properties.Add ("Security", sec_prop);
			return msg;
		}

		void ReadHeaders (Message srcmsg)
		{
			SecurityTokenSerializer serializer =
				security.TokenSerializer;

			tokens = new List<SecurityToken> ();
			token_resolver = SecurityTokenResolver.CreateDefaultSecurityTokenResolver (
				new ReadOnlyCollection <SecurityToken> (tokens),
				true);
			token_resolver = new UnionSecurityTokenResolver (token_resolver, security.OutOfBandTokenResolver);

			// Add relevant protection token and supporting tokens.
			tokens.Add (security.EncryptionToken);
			// FIXME: this is just a workaround for symmetric binding to not require extra client certificate.
			if (security.Element is AsymmetricSecurityBindingElement)
				tokens.Add (security.SigningToken);
			if (RequestSecurity != null && RequestSecurity.ProtectionToken != null)
				tokens.Add (RequestSecurity.ProtectionToken.SecurityToken);
			// FIXME: handle supporting tokens

			for (int i = 0; i < srcmsg.Headers.Count; i++) {
				MessageHeaderInfo header = srcmsg.Headers [i];
				// FIXME: check SOAP Actor.
				// MessageHeaderDescription.Actor needs to be accessible from here.
				if (header.Namespace == Constants.WssNamespace &&
				    header.Name == "Security") {
					wss_header = WSSecurityMessageHeader.Read (
						srcmsg.Headers.GetReaderAtHeader (i),
						serializer, TokenResolver, doc, nsmgr, tokens);
					headers.Add (wss_header);
				}
				else
					headers.Add (header);
			}
			if (wss_header == null)
				throw new InvalidOperationException ("In this service contract, a WS-Security header is required in the Message, but was not found.");
		}

		void ExtractSecurity (XmlElement secElem)
		{
			// decrypt the key with service certificate privkey
			EncryptedXml encXml = new EncryptedXml (doc);

			if (security.MessageProtectionOrder == MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature &&
			    secElem.SelectSingleNode ("dsig:Signature", nsmgr) != null)
				throw new MessageSecurityException ("The security binding element expects that the message signature is encrypted, while it isn't.");

			byte [] decryptedKey = RequestSecurity != null ? RequestSecurity.EncryptionKey : null; // default
			// default, unless overriden by the default DerivedKeyToken.
			Rijndael aes = RijndaelManaged.Create (); // it is reused with every key
			aes.Mode = CipherMode.CBC;

			WrappedKeySecurityToken wk = wss_header.Find<WrappedKeySecurityToken> ();
			if (wk != null) {
				SymmetricSecurityKey sym = wk.SecurityKeys [0] as SymmetricSecurityKey;
				decryptedKey = sym.GetSymmetricKey ();
			}

			// decrypt the body with the decrypted key
			Collection<string> references = new Collection<string> ();

			foreach (XmlElement rlist in secElem.SelectNodes ("e:ReferenceList", nsmgr))
				foreach (XmlElement encref in rlist.SelectNodes ("e:DataReference | e:KeyReference", nsmgr))
					references.Add (StripUri (encref.GetAttribute ("URI")));
			if (wk != null)
				foreach (EncryptedReference er in wk.ReferenceList)
					references.Add (StripUri (er.Uri));

			Collection<XmlElement> list = new Collection<XmlElement> ();
			foreach (string uri in references) {
				XmlElement el = doc.SelectSingleNode ("//e:EncryptedData [@Id='" + uri + "' or @u:Id='" + uri + "']", nsmgr) as XmlElement;
				if (el != null)
					list.Add (el);
				else
					throw new MessageSecurityException (String.Format ("On decryption, EncryptedData with Id '{0}', referenced by ReferenceData, was not found.", uri));
			}

			foreach (XmlElement el in list) {
				EncryptedData ed2 = new EncryptedData ();
				ed2.LoadXml (el);
				byte [] key = GetEncryptionKeyForData (ed2, encXml);
				aes.Key = key != null ? key : decryptedKey;
				encXml.ReplaceData (el, DecryptLax (encXml, ed2, aes));
			}

Console.WriteLine ("======== Decrypted Document ========");
doc.PreserveWhitespace = false;
doc.Save (Console.Out);
doc.PreserveWhitespace = true;

			// signature confirmation
			XmlElement sigElem = secElem.SelectSingleNode ("dsig:Signature", nsmgr) as XmlElement;
			if (sigElem == null)
				throw new MessageSecurityException ("The the message signature is expected but not found.");

			WSSignedXml sxml = wss_header.Find<WSSignedXml> ();

			bool confirmed = false;

			SecurityKeyIdentifierClause sigClause = null;
			foreach (KeyInfoClause kic in sxml.KeyInfo) {
				SecurityTokenReferenceKeyInfo r = kic as SecurityTokenReferenceKeyInfo;
				if (r != null)
					sigClause = r.Clause;
			}
			if (sigClause == null)
				throw new MessageSecurityException ("SecurityTokenReference was not found in dsig:Signature KeyInfo.");

			SecurityToken signToken;
			SecurityKey signKey;

			// FIXME: (?) Since .NET does not return 
			// EncryptedKeySHA1 hash value based on the identical
			// EncryptedKey as it (the initiator) sent, the token
			// resolution will always fail. So, whenever 
			// EncryptedKeySHA1 is returned, just use the same key
			// as it sent before. I guess this is .NET bug, though
			// it is still mystery that why .NET could *not*
			// resolve our EncryptedKeySHA1.
			if (sigClause is InternalEncryptedKeyIdentifierClause &&
			    RequestSecurity.ProtectionToken != null) {
				signToken = RequestSecurity.ProtectionToken.SecurityToken;
				signKey = signToken.SecurityKeys [0];
			} else {
				signToken = TokenResolver.ResolveToken (sigClause);
				signKey = signToken.ResolveKeyIdentifierClause (sigClause);
			}
			SymmetricSecurityKey symkey = signKey as SymmetricSecurityKey;
			if (symkey != null) {
				confirmed = sxml.CheckSignature (new HMACSHA1 (symkey.GetSymmetricKey ()));
				if (wk != null)
					// FIXME: authenticate token
					sec_prop.ProtectionToken = new SecurityTokenSpecification (wk, null);
			} else {
				AsymmetricAlgorithm alg = ((AsymmetricSecurityKey) signKey).GetAsymmetricAlgorithm (security.DefaultSignatureAlgorithm, false);
				confirmed = sxml.CheckSignature (alg);
				sec_prop.InitiatorToken = new SecurityTokenSpecification (
					signToken,
					security.TokenAuthenticator.ValidateToken (signToken));
			}
			if (!confirmed)
				throw new MessageSecurityException ("Message signature is invalid.");

			// token authentication
			// FIXME: it might not be limited to recipient
			if (Direction == MessageDirection.Input)
				ProcessSupportingTokens (sxml);

			sec_prop.EncryptionKey = decryptedKey;
			sec_prop.ConfirmedSignatures.Add (Convert.ToBase64String (sxml.SignatureValue));
		}

		#region supporting token processing

		// authenticate and map supporting tokens to proper SupportingTokenSpecification list.
		void ProcessSupportingTokens (SignedXml sxml)
		{
			List<SupportingTokenInfo> tokens = new List<SupportingTokenInfo> ();
		
			// First, categorize those tokens in the Security
			// header:
			// - Endorsing		signing
			// - Signed			signed
			// - SignedEncrypted		signed	encrypted
			// - SignedEndorsing	signing	signed

			foreach (object obj in wss_header.Contents) {
				SecurityToken token = obj as SecurityToken;
				if (token == null)
					continue;
				bool signed = false, endorsing = false, encrypted = false;
				// signed
				foreach (Reference r in sxml.SignedInfo.References)
					if (r.Uri.Substring (1) == token.Id) {
						signed = true;
						break;
					}
				// FIXME: how to get 'encrypted' state?
				// FIXME: endorsing

				SecurityTokenAttachmentMode mode =
					signed ? encrypted ? SecurityTokenAttachmentMode.SignedEncrypted :
					endorsing ? SecurityTokenAttachmentMode.SignedEndorsing :
					SecurityTokenAttachmentMode.Signed :
					SecurityTokenAttachmentMode.Endorsing;
				tokens.Add (new SupportingTokenInfo (token, mode, false));
			}

			// then,
			// 1. validate every mandatory supporting token
			// parameters (Endpoint-, Operation-). To do that,
			// iterate all tokens in the header against every
			// parameter in the mandatory list.
			// 2. validate every token that is not validated.
			// To do that, iterate all supporting token parameters
			// and check if any of them can validate it.
			SupportingTokenParameters supp;
			string action = GetAction ();
			ValidateTokensByParameters (security.Element.EndpointSupportingTokenParameters, tokens, false);
			if (security.Element.OperationSupportingTokenParameters.TryGetValue (action, out supp))
				ValidateTokensByParameters (supp, tokens, false);
			ValidateTokensByParameters (security.Element.OptionalEndpointSupportingTokenParameters, tokens, true);
			if (security.Element.OptionalOperationSupportingTokenParameters.TryGetValue (action, out supp))
				ValidateTokensByParameters (supp, tokens, true);
		}

		void ValidateTokensByParameters (SupportingTokenParameters supp, List<SupportingTokenInfo> tokens, bool optional)
		{
			ValidateTokensByParameters (supp.Endorsing, tokens, optional);
			ValidateTokensByParameters (supp.Signed, tokens, optional);
			ValidateTokensByParameters (supp.SignedEndorsing, tokens, optional);
			ValidateTokensByParameters (supp.SignedEncrypted, tokens, optional);
		}

		void ValidateTokensByParameters (IEnumerable<SecurityTokenParameters> plist, List<SupportingTokenInfo> tokens, bool optional)
		{
			foreach (SecurityTokenParameters p in plist) {
				SecurityTokenResolver r;
				SecurityTokenAuthenticator a =
					security.CreateTokenAuthenticator (p, out r);
				SupportingTokenSpecification spec = ValidateTokensByParameters (a, r, tokens);
				if (spec == null) {
					if (optional)
						continue;
					else
						throw new MessageSecurityException ("Security token '{0}' cannot be validated according to the security settings.");
				}
				sec_prop.IncomingSupportingTokens.Add (spec);
			}
		}

		SupportingTokenSpecification ValidateTokensByParameters (SecurityTokenAuthenticator a, SecurityTokenResolver r, List<SupportingTokenInfo> tokens)
		{
			foreach (SupportingTokenInfo info in tokens)
				if (a.CanValidateToken (info.Token))
					return new SupportingTokenSpecification (
						info.Token,
						a.ValidateToken (info.Token),
						info.Mode);
			return null;
		}

		#endregion

		byte [] GetEncryptionKeyForData (EncryptedData ed2, EncryptedXml encXml)
		{
			// Since ReferenceList could be embedded directly in wss_header without
			// key indication, it must iterate all the derived keys to find out
			// appropriate one.
			foreach (DerivedKeySecurityToken dk in wss_header.FindAll<DerivedKeySecurityToken> ()) {
				if (dk.ReferenceList == null)
					continue;
				foreach (DataReference dr in dk.ReferenceList)
					if (StripUri (dr.Uri) == ed2.Id)
						return ((SymmetricSecurityKey) dk.SecurityKeys [0]).GetSymmetricKey ();
			}

			SecurityTokenSerializer serializer =
				security.TokenSerializer;

			if (ed2.KeyInfo == null)
				return null;
			foreach (KeyInfoClause kic in ed2.KeyInfo) {
				SecurityKeyIdentifierClause skic = serializer.ReadKeyIdentifierClause (new XmlNodeReader (kic.GetXml ()));

#if true // FIXME: this is the same workaround as we have for resolving signing key, as noted above.
				InternalEncryptedKeyIdentifierClause eskic = skic as InternalEncryptedKeyIdentifierClause;
				if (eskic != null)
					return RequestSecurity != null ? RequestSecurity.EncryptionKey : null;
#endif

				SecurityKey skey = null;
				if (!TokenResolver.TryResolveSecurityKey (skic, out skey))
					throw new MessageSecurityException (String.Format ("The signing key could not be resolved from {0}", skic));
				SymmetricSecurityKey ssk = skey as SymmetricSecurityKey;
				if (ssk != null)
					return ssk.GetSymmetricKey ();
			}
			return null; // no applicable key info clause.
		}

		string StripUri (string src)
		{
			if (src == null || src.Length == 0)
				return String.Empty;
			if (src [0] != '#')
				throw new NotSupportedException (String.Format ("Non-fragment URI in DataReference and KeyReference is not supported: '{0}'", src));
			return src.Substring (1);
		}

		// Probably it is a bug in .NET, but sometimes it does not contain
		// proper padding bytes. For such cases, use PaddingMode.None
		// instead. It must not be done in EncryptedXml class as it
		// correctly rejects improper ISO10126 padding.
		byte [] DecryptLax (EncryptedXml encXml, EncryptedData ed, SymmetricAlgorithm symAlg)
		{
			PaddingMode bak = symAlg.Padding;
			try {
				byte [] bytes = ed.CipherData.CipherValue;

				if (encXml.Padding != PaddingMode.None &&
				    encXml.Padding != PaddingMode.Zeros &&
				    bytes [bytes.Length - 1] > symAlg.BlockSize / 8)
					symAlg.Padding = PaddingMode.None;
				return encXml.DecryptData (ed, symAlg);
			} finally {
				symAlg.Padding = bak;
			}
		}

		string GetAction ()
		{
			string ret = source_message.Headers.Action;
			if (ret == null) {
				HttpRequestMessageProperty reqprop =
					source_message.Properties ["Action"] as HttpRequestMessageProperty;
				if (reqprop != null)
					ret = reqprop.Headers ["Action"];
			}
			return ret;
		}
	}
}
