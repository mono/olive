//
// MessageSecurityGenerator.cs
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
	internal class InitiatorMessageSecurityGenerator : MessageSecurityGenerator
	{
		EndpointAddress message_to;
		InitiatorMessageSecurityBindingSupport security;

		public InitiatorMessageSecurityGenerator (
			Message msg,
			InitiatorMessageSecurityBindingSupport security,
			EndpointAddress messageTo)
			: base (msg, security)
		{
			// FIXME: I believe it should be done at channel
			// creation phase, but WinFX does not.
			if (!security.InitiatorParameters.InternalHasAsymmetricKey)
				throw new InvalidOperationException ("Wrong security token parameters: it must have an asymmetric key (HasAsymmetricKey). There is likely a misconfiguration in the custom security binding element.");

			this.security = security;
			this.message_to = messageTo;
		}

		public override SecurityRequestContext RequestContext {
			get { return null; }
		}

		public override UniqueId RelatesTo {
			get { return null; }
		}

		public override SecurityTokenParameters Parameters {
			get { return security.InitiatorParameters; }
		}

		public override SecurityTokenParameters CounterParameters {
			get { return security.RecipientParameters; }
		}

		public override MessageDirection Direction {
			get { return MessageDirection.Input; }
		}

		public override EndpointAddress MessageTo {
			get { return message_to; }
		}

		public override bool ShouldIncludeToken (SecurityTokenInclusionMode mode, bool isInitialized)
		{
			switch (mode) {
			case SecurityTokenInclusionMode.Never:
			case SecurityTokenInclusionMode.AlwaysToInitiator:
				return false;
			case SecurityTokenInclusionMode.AlwaysToRecipient:
				return true;
			case SecurityTokenInclusionMode.Once:
				return !isInitialized;
			}
			throw new Exception ("Internal Error: should not happen.");
		}

		public override ScopedMessagePartSpecification SignatureParts { 
			get { return Security.ChannelRequirements.IncomingSignatureParts; }
		}

		public override ScopedMessagePartSpecification EncryptionParts { 
			get { return Security.ChannelRequirements.IncomingEncryptionParts; }
		}
	}

	internal class RecipientMessageSecurityGenerator : MessageSecurityGenerator
	{
		RecipientMessageSecurityBindingSupport security;
		SecurityRequestContext req_ctx;

		public RecipientMessageSecurityGenerator (
			Message msg,
			SecurityRequestContext requestContext,
			RecipientMessageSecurityBindingSupport security)
			: base (msg, security)
		{
			this.security = security;
			req_ctx = requestContext;
			SecurityMessageProperty secprop =
				(SecurityMessageProperty) req_ctx.RequestMessage.Properties.Security.CreateCopy ();
			msg.Properties.Security = secprop;
		}

		public override SecurityRequestContext RequestContext {
			get { return req_ctx; }
		}

		public override UniqueId RelatesTo {
			get { return req_ctx.RequestMessage.Headers.MessageId; }
		}

		public override SecurityTokenParameters Parameters {
			get { return security.RecipientParameters; }
		}

		public override SecurityTokenParameters CounterParameters {
			get { return security.InitiatorParameters; }
		}

		public override MessageDirection Direction {
			get { return MessageDirection.Output; }
		}

		public override EndpointAddress MessageTo {
			get { return null; }
		}

		public override bool ShouldIncludeToken (SecurityTokenInclusionMode mode, bool isInitialized)
		{
			switch (mode) {
			case SecurityTokenInclusionMode.Never:
			case SecurityTokenInclusionMode.AlwaysToRecipient:
				return false;
			case SecurityTokenInclusionMode.AlwaysToInitiator:
				return true;
			case SecurityTokenInclusionMode.Once:
				return !isInitialized;
			}
			throw new Exception ("Internal Error: should not happen.");
		}

		public override ScopedMessagePartSpecification SignatureParts { 
			get { return Security.ChannelRequirements.OutgoingSignatureParts; }
		}

		public override ScopedMessagePartSpecification EncryptionParts { 
			get { return Security.ChannelRequirements.OutgoingEncryptionParts; }
		}
	}

	internal abstract class MessageSecurityGenerator
	{
		Message msg;
		SecurityMessageProperty secprop;
		MessageSecurityBindingSupport security;
		int idbase;

		public MessageSecurityGenerator (Message msg, 
			MessageSecurityBindingSupport security)
		{
			this.msg = msg;
			this.security = security;
		}

		public Message Message {
			get { return msg; }
		}

		public MessageSecurityBindingSupport Security {
			get { return security; }
		}

		public abstract SecurityTokenParameters Parameters { get; }

		public abstract SecurityTokenParameters CounterParameters { get; }

		public abstract MessageDirection Direction { get; }

		public abstract EndpointAddress MessageTo { get; }

		public abstract ScopedMessagePartSpecification SignatureParts { get; }

		public abstract ScopedMessagePartSpecification EncryptionParts { get; }

		public MessagePartSpecification SignaturePart {
			get {
				MessagePartSpecification spec;
				if (!SignatureParts.TryGetParts (GetAction (), false, out spec))
					spec = SignatureParts.ChannelParts;
				return spec;
			}
		}

		public MessagePartSpecification EncryptionPart {
			get {
				MessagePartSpecification spec;
				if (!EncryptionParts.TryGetParts (GetAction (), false, out spec))
					spec = EncryptionParts.ChannelParts;
				return spec;
			}
		}

		public abstract bool ShouldIncludeToken (SecurityTokenInclusionMode mode, bool isInitialized);

		public bool ShouldOutputEncryptedKey {
			get { return RequestContext == null || RequestContext.RequestMessage.Properties.Security.ProtectionToken == null; } //security.Element is AsymmetricSecurityBindingElement; }
		}

		public abstract UniqueId RelatesTo { get; }

		public abstract SecurityRequestContext RequestContext { get; }

		public Message SecureMessage ()
		{
			secprop = Message.Properties.Security ?? new SecurityMessageProperty ();

			SecurityToken encToken =
				secprop.InitiatorToken != null ? secprop.InitiatorToken.SecurityToken : security.EncryptionToken;
			SecurityToken signToken = null;
			MessageProtectionOrder protectionOrder =
				security.MessageProtectionOrder;
			SecurityTokenSerializer serializer =
				security.TokenSerializer;
			SecurityBindingElement element =
				security.Element;
			SecurityAlgorithmSuite suite = element.DefaultAlgorithmSuite;

// FIXME: remove this hack
if (!ShouldOutputEncryptedKey)
	encToken = new BinarySecretSecurityToken (secprop.EncryptionKey);

			string messageId = "uuid-" + Guid.NewGuid ();
			int identForMessageId = 1;
			XmlDocument doc = new XmlDocument ();
			doc.PreserveWhitespace = true;

			UniqueId relatesTo = RelatesTo;
			if (relatesTo != null)
				msg.Headers.RelatesTo = relatesTo;
			else // FIXME: probably it is always added when it is stateful ?
				msg.Headers.MessageId = new UniqueId ("urn:" + messageId);

			// FIXME: get correct ReplyTo value
			if (Direction == MessageDirection.Input)
				msg.Headers.Add (MessageHeader.CreateHeader ("ReplyTo", msg.Version.Addressing.Namespace, EndpointAddress10.FromEndpointAddress (new EndpointAddress (Constants.WsaAnonymousUri))));

			if (MessageTo != null)
				msg.Headers.Add (MessageHeader.CreateHeader ("To", msg.Version.Addressing.Namespace, MessageTo.Uri.AbsoluteUri, true));

			// wss:Security
			WSSecurityMessageHeader header =
				new WSSecurityMessageHeader (serializer);
			msg.Headers.Add (header);
			// 1. [Timestamp]
			if (element.IncludeTimestamp) {
				WsuTimestamp timestamp = new WsuTimestamp ();
				timestamp.Id = messageId + "-" + identForMessageId++;
				timestamp.Created = DateTime.Now;
				// FIXME: on service side, use element.LocalServiceSettings.TimestampValidityDuration
				timestamp.Expires = timestamp.Created.Add (element.LocalClientSettings.TimestampValidityDuration);
				header.Contents.Add (timestamp);
			}
			// 1.5 [Signature Confirmation]
			if (security.RequireSignatureConfirmation && secprop.ConfirmedSignatures.Count > 0)
				foreach (string value in secprop.ConfirmedSignatures)
					header.Contents.Add (new Wss11SignatureConfirmation (GenerateId (doc), value));

			SupportingTokenInfoCollection tokenInfos =
				Direction == MessageDirection.Input ?
				security.CollectSupportingTokens (GetAction ()) :
				new SupportingTokenInfoCollection (); // empty
			foreach (SupportingTokenInfo tokenInfo in tokenInfos)
				if (tokenInfo.Mode != SecurityTokenAttachmentMode.Endorsing)
					header.Contents.Add (tokenInfo.Token);

			// populate DOM to sign.
			XPathNavigator nav = doc.CreateNavigator ();
			using (XmlWriter w = nav.AppendChild ()) {
				msg.WriteMessage (w);
			}
			XmlNamespaceManager nsmgr = new XmlNamespaceManager (doc.NameTable);
			nsmgr.AddNamespace ("s", msg.Version.Envelope.Namespace);
			nsmgr.AddNamespace ("o", Constants.WssNamespace);
			nsmgr.AddNamespace ("u", Constants.WsuNamespace);
			nsmgr.AddNamespace ("o11", Constants.Wss11Namespace);

			WrappedKeySecurityToken primaryToken = null;
			DerivedKeySecurityToken dkeyToken = null;
			SecurityToken actualToken = null;
			SecurityKeyIdentifierClause actualClause = null;
			Signature sig = null;
			EncryptedData sigenc = null;

			List<DerivedKeySecurityToken> derivedKeys =
				new List<DerivedKeySecurityToken> ();

			XmlElement body = doc.SelectSingleNode ("/s:Envelope/s:Body/*", nsmgr) as XmlElement;
			string bodyId = null;

			SymmetricAlgorithm masterKey = new RijndaelManaged ();
			masterKey.KeySize = suite.DefaultSymmetricKeyLength;
			masterKey.Mode = CipherMode.CBC;
			masterKey.Padding = PaddingMode.ISO10126;
			SymmetricAlgorithm actualKey = masterKey;

			// FIXME: use specified hash algorithm in the SecurityAlgorithmSuite.
			HMAC sha1 = HMACSHA1.Create ();
			sha1.Initialize ();
{
			// 2. [Encryption Token]

			// SecurityTokenInclusionMode
			// - Initiator or Recipient
			// - done or notyet. FIXME: not implemented yet
			// It also affects on key reference output

			bool includeEncToken = ShouldIncludeToken (
				Security.RecipientParameters.InclusionMode, false);
			bool includeSigToken = ShouldIncludeToken (
				Security.InitiatorParameters.InclusionMode, false);

			SecurityKeyIdentifierClause encClause = ShouldOutputEncryptedKey ?
				CounterParameters.CallCreateKeyIdentifierClause (encToken, !ShouldOutputEncryptedKey ? SecurityTokenReferenceStyle.Internal : includeEncToken ? Parameters.ReferenceStyle : SecurityTokenReferenceStyle.External) : null;

			MessagePartSpecification sigSpec = SignaturePart;
			MessagePartSpecification encSpec = EncryptionPart;

			// encryption key (possibly also used for signing)
			// FIXME: get correct SymmetricAlgorithm according to the algorithm suite
			if (secprop.EncryptionKey != null)
				actualKey.Key = secprop.EncryptionKey;

// FIXME: remove thid hack
if (!ShouldOutputEncryptedKey)
primaryToken = RequestContext.RequestMessage.Properties.Security.ProtectionToken.SecurityToken as WrappedKeySecurityToken;
else
			primaryToken = new WrappedKeySecurityToken (messageId + "-" + identForMessageId++,
				actualKey.Key,
				// security.DefaultKeyWrapAlgorithm,
				ShouldOutputEncryptedKey ?
					suite.DefaultAsymmetricKeyWrapAlgorithm :
					suite.DefaultSymmetricKeyWrapAlgorithm,
				encToken,
				encClause != null ? new SecurityKeyIdentifier (encClause) : null);

			actualToken = primaryToken;

			// FIXME: I doubt it is correct...
			WrappedKeySecurityToken requestEncKey = ShouldOutputEncryptedKey ? null : primaryToken;
			actualClause = requestEncKey == null ? (SecurityKeyIdentifierClause)
				new LocalIdKeyIdentifierClause (actualToken.Id, typeof (WrappedKeySecurityToken)) :
				new InternalEncryptedKeyIdentifierClause (sha1.ComputeHash (requestEncKey.GetWrappedKey ()));

			// generate derived key if needed
			if (CounterParameters.RequireDerivedKeys) {
				RijndaelManaged deriv = new RijndaelManaged ();
				deriv.KeySize = suite.DefaultEncryptionKeyDerivationLength;
				deriv.Mode = CipherMode.CBC;
				deriv.Padding = PaddingMode.ISO10126;
				deriv.GenerateKey ();
				dkeyToken = new DerivedKeySecurityToken (
					GenerateId (doc),
					null, // algorithm
					actualClause,
					new InMemorySymmetricSecurityKey (actualKey.Key),
					null, // name
					null, // generation
					null, // offset
					deriv.Key.Length,
					null, // label
					deriv.Key);
				derivedKeys.Add (dkeyToken);
				actualToken = dkeyToken;
				actualKey.Key = ((SymmetricSecurityKey) dkeyToken.SecurityKeys [0]).GetSymmetricKey ();
				actualClause = new LocalIdKeyIdentifierClause (dkeyToken.Id);
			}

			switch (protectionOrder) {
			case MessageProtectionOrder.EncryptBeforeSign:
				// FIXME: implement
				throw new NotImplementedException ();
			case MessageProtectionOrder.SignBeforeEncrypt:
			case MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature:

				// sign
				WSSignedXml sxml = new WSSignedXml (nsmgr, doc);
				SecurityTokenReferenceKeyInfo sigKeyInfo;

				sig = sxml.Signature;
				sig.SignedInfo.CanonicalizationMethod =
					suite.DefaultCanonicalizationAlgorithm;
				XmlNodeList nodes = doc.SelectNodes ("/s:Envelope/s:Header/*", nsmgr);
				for (int i = 0; i < msg.Headers.Count; i++) {
					MessageHeaderInfo h = msg.Headers [i];
					if (h.Name == "Security" && h.Namespace == Constants.WssNamespace)
						continue;
					if (sigSpec.HeaderTypes.Count == 0 ||
					    sigSpec.HeaderTypes.Contains (new XmlQualifiedName (h.Name, h.Namespace))) {
						string id = GenerateId (doc);
						h.Id = id;
						CreateReference (sig, nodes [i] as XmlElement, id);
					}
				}
				if (sigSpec.IsBodyIncluded) {
					bodyId = GenerateId (doc);
					CreateReference (sig, body.ParentNode as XmlElement, bodyId);
				}
				foreach (XmlElement elem in doc.SelectNodes ("/s:Envelope/s:Header/o:Security/*", nsmgr))
					CreateReference (sig, elem, elem.GetAttribute ("Id", Constants.WsuNamespace));

				if (security.DefaultSignatureAlgorithm == SignedXml.XmlDsigHMACSHA1Url) {
					sha1.Key = actualKey.Key;
					sxml.ComputeSignature (sha1);
					sigKeyInfo = new SecurityTokenReferenceKeyInfo (actualClause, serializer, doc);
				}
				else {
					signToken = security.SigningToken;
					SecurityKeyIdentifierClause signClause =
						CounterParameters.CallCreateKeyIdentifierClause (signToken, includeSigToken ? CounterParameters.ReferenceStyle : SecurityTokenReferenceStyle.External);
					AsymmetricSecurityKey signKey = (AsymmetricSecurityKey) signToken.ResolveKeyIdentifierClause (signClause);
					sxml.SigningKey = signKey.GetAsymmetricAlgorithm (security.DefaultSignatureAlgorithm, true);
					sxml.ComputeSignature ();
					sigKeyInfo = new SecurityTokenReferenceKeyInfo (signClause, serializer, doc);
				}

				sxml.KeyInfo = new KeyInfo ();
				sxml.KeyInfo.AddClause (sigKeyInfo);

				// encrypt

				EncryptedXml exml = new EncryptedXml ();
				ReferenceList refList = new ReferenceList ();
				// When encrypted with DerivedKeyToken, put
				// references inside o:Security, not inside
				// EncryptedKey.
				if (CounterParameters.RequireDerivedKeys)
					dkeyToken.ReferenceList = refList;
				else
					primaryToken.ReferenceList = refList;

				EncryptedData edata = Encrypt (body, actualKey, actualToken.Id, refList, actualClause, exml, doc);
				EncryptedXml.ReplaceElement (body, edata, false);

				// encrypt signature
				if (protectionOrder == MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature) {
					XmlElement sigxml = sig.GetXml ();
					sigenc = Encrypt (sigxml, actualKey, actualToken.Id, refList, actualClause, exml, doc);
				}
				break;
			}

			if (sig != null && includeSigToken)
				header.Contents.Add (signToken);
			if (signToken != encToken && includeEncToken)
				header.Contents.Add (encToken);

}

			Message ret = Message.CreateMessage (msg.Version, msg.Headers.Action, new XmlNodeReader (doc.SelectSingleNode ("/s:Envelope/s:Body/*", nsmgr) as XmlElement));
			ret.Properties.Security = (SecurityMessageProperty) secprop.CreateCopy ();
			ret.Properties.Security.EncryptionKey = masterKey.Key;
			ret.BodyId = bodyId;

			// FIXME: set below items:
			//	- ExternalAuthorizationPolicies
			//	- IncomingSupportingTokens (? only for incoming?)
			//	- TransportToken (can we support it here?)
			//	- ServiceSecurityContext
			if (element is AsymmetricSecurityBindingElement) {
				ret.Properties.Security.InitiatorToken = new SecurityTokenSpecification (encToken, null); // FIXME: second argument
				ret.Properties.Security.InitiatorToken = new SecurityTokenSpecification (signToken, null); // FIXME: second argument
			}
			else
				ret.Properties.Security.ProtectionToken = new SecurityTokenSpecification (primaryToken, null);

			ret.Headers.Clear ();
			ret.Headers.CopyHeadersFrom (msg);

			// FIXME: Header contents should be:
			//	- Timestamp
			//	- EncryptionToken if included
			//	- derived key token for EncryptionToken
			//	- ReferenceList for encrypted items
			//	- signed supporting tokens
			//	- signed endorsing supporting tokens
			//	- Signature Token if != EncryptionToken
			//	- derived key token for SignatureToken
			//	- Signature for:
			//		- Timestamp
			//		- supporting tokens (regardless of
			//		  its inclusion)
			//		- message parts in SignedParts
			//		- SignatureToken if TokenProtection
			//		  (regardless of its inclusion)
			//	- Signatures for the main signature (above),
			//	  for every endorsing token and signed
			//	  endorsing token.
			//	

			// If it reuses request's encryption key, do not output.
			if (ShouldOutputEncryptedKey)
				header.Contents.Add (primaryToken);

			foreach (DerivedKeySecurityToken dk in derivedKeys) {
				header.Contents.Add (dk);
				if (dk.ReferenceList != null)
					header.Contents.Add (dk.ReferenceList);
			}

			// When we do not output EncryptedKey, output ReferenceList here.
			if (!ShouldOutputEncryptedKey)
				header.Contents.Add (primaryToken.ReferenceList);

			if (sigenc != null) // [Signature Protection]
				header.Contents.Add (sigenc);
			else if (sig != null) // ![Signature Protection]
				header.Contents.Add (sig);

//MessageBuffer zzz = ret.CreateBufferedCopy (100000);
//ret = zzz.CreateMessage ();
//Console.WriteLine (zzz.CreateMessage ());
			return ret;
		}

		void CreateReference (Signature sig, XmlElement el, string id)
		{
			SecurityAlgorithmSuite suite = security.Element.DefaultAlgorithmSuite;
			if (id == String.Empty)
				id = GenerateId (el.OwnerDocument);
			Reference r = new Reference ("#" + id);
			r.AddTransform (CreateTransform (suite.DefaultCanonicalizationAlgorithm));
			r.DigestMethod = suite.DefaultDigestAlgorithm;
			if (el.GetAttribute ("Id", Constants.WsuNamespace) != id) {
				XmlAttribute a = el.SetAttributeNode ("Id", Constants.WsuNamespace);
				a.Prefix = "u";
				a.Value = id;
			}
			sig.SignedInfo.AddReference (r);
		}

		Transform CreateTransform (string url)
		{
			switch (url) {
			case SignedXml.XmlDsigC14NTransformUrl:
				return new XmlDsigC14NTransform ();
			case SignedXml.XmlDsigC14NWithCommentsTransformUrl:
				return new XmlDsigC14NWithCommentsTransform ();
			case SignedXml.XmlDsigExcC14NTransformUrl:
				return new XmlDsigExcC14NTransform ();
			case SignedXml.XmlDsigExcC14NWithCommentsTransformUrl:
				return new XmlDsigExcC14NWithCommentsTransform ();
			}
			throw new Exception (String.Format ("INTERNAL ERROR: Invalid canonicalization URL: {0}", url));
		}

		EncryptedData Encrypt (XmlElement target, SymmetricAlgorithm actualKey, string ekeyId, ReferenceList refList, SecurityKeyIdentifierClause encClause, EncryptedXml exml, XmlDocument doc)
		{
			SecurityAlgorithmSuite suite = security.Element.DefaultAlgorithmSuite;
			SecurityTokenSerializer serializer = security.TokenSerializer;

			byte [] encrypted = exml.EncryptData (target, actualKey, false);
			EncryptedData edata = new EncryptedData ();
			edata.Id = GenerateId (doc);
			edata.Type = EncryptedXml.XmlEncElementContentUrl;
			edata.EncryptionMethod = new EncryptionMethod (suite.DefaultEncryptionAlgorithm);
			// FIXME: here wsse:DigestMethod should be embedded 
			// inside EncryptionMethod. Since it is not possible 
			// with S.S.C.Xml.EncryptionMethod, we will have to
			// build our own XML encryption classes.

			edata.CipherData.CipherValue = encrypted;

			DataReference dr = new DataReference ();
			dr.Uri = "#" + edata.Id;
			refList.Add (dr);

			if (ShouldOutputEncryptedKey && !CounterParameters.RequireDerivedKeys)
				edata.KeyInfo = null;
			else {
				edata.KeyInfo = new KeyInfo ();
				edata.KeyInfo.AddClause (new SecurityTokenReferenceKeyInfo (encClause, serializer, doc));
			}

			return edata;
		}

		string GenerateId (XmlDocument doc)
		{
			idbase++;
			return secprop.SenderIdPrefix + idbase;
		}

		public string GetAction ()
		{
			string ret = msg.Headers.Action;
			if (ret == null) {
				HttpRequestMessageProperty reqprop =
					msg.Properties ["Action"] as HttpRequestMessageProperty;
				if (reqprop != null)
					ret = reqprop.Headers ["Action"];
			}
			return ret;
		}
	}
}
