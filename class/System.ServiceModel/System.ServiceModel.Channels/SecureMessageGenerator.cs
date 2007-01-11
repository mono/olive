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

		public override SupportingTokenInfoCollection CollectInitiatorSupportingTokens ()
		{
			return security.CollectInitiatorSupportingTokens (GetAction (), MessageTo);
		}
	}

	internal class RecipientMessageSecurityGenerator : MessageSecurityGenerator
	{
		RecipientMessageSecurityBindingSupport security;
		Uri listen_uri;

		public RecipientMessageSecurityGenerator (
			Message msg,
			RecipientMessageSecurityBindingSupport security,
			Uri listenUri)
			: base (msg, security)
		{
			this.security = security;
			this.listen_uri = listenUri;
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

		public override SupportingTokenInfoCollection CollectInitiatorSupportingTokens ()
		{
			return security.CollectRecipientSupportingTokens (GetAction (), listen_uri);
		}
	}

	internal abstract class MessageSecurityGenerator
	{
		Message msg;
		MessageSecurityBindingSupport security;

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

		public abstract SupportingTokenInfoCollection CollectInitiatorSupportingTokens ();

		public abstract bool ShouldIncludeToken (SecurityTokenInclusionMode mode, bool isInitialized);

		public Message SecureMessage ()
		{
			SecurityTokenParameters initiatorParams =
				security.InitiatorParameters;
			SecurityTokenParameters recipientParams =
				security.RecipientParameters;
			SecurityToken encToken =
				security.EncryptionToken;
			SecurityToken signToken =
				security.SigningToken;
			MessageProtectionOrder protectionOrder =
				security.MessageProtectionOrder;
			SecurityTokenSerializer serializer =
				security.TokenSerializer;
			SecurityBindingElement element =
				security.Element;
			SecurityAlgorithmSuite suite = element.DefaultAlgorithmSuite;

			// FIXME: is it correct? anyways we need to encrypt parts based on supporting tokens too.
			SecurityTokenParameters securingParams =
				Direction == MessageDirection.Input ?
				initiatorParams : recipientParams;

			string messageId = "uuid:" + Guid.NewGuid ();
			msg.Headers.Add (MessageHeader.CreateHeader ("MessageID", msg.Version.Addressing.Namespace, messageId));
			int identForMessageId = 1;

			// FIXME: get correct ReplyTo value
			msg.Headers.Add (MessageHeader.CreateHeader ("ReplyTo", msg.Version.Addressing.Namespace, EndpointAddress10.FromEndpointAddress (new EndpointAddress (Constants.WsaAnonymousUri))));

			if (MessageTo != null)
				msg.Headers.Add (MessageHeader.CreateHeader ("To", msg.Version.Addressing.Namespace, MessageTo.Uri.AbsoluteUri, true));

			// wss:Security
			WSSecurityMessageHeader header =
				new WSSecurityMessageHeader (serializer);
			// wss:Security/wsu:Timestamp
			if (element.IncludeTimestamp) {
				WsuTimestamp timestamp = new WsuTimestamp ();
				timestamp.Id = messageId + "-" + identForMessageId++;
				timestamp.Created = DateTime.Now;
				// FIXME: on service side, use element.LocalServiceSettings.TimestampValidityDuration
				timestamp.Expires = timestamp.Created.Add (element.LocalClientSettings.TimestampValidityDuration);
				header.Contents.Add (timestamp);
			}
			msg.Headers.Add (header);


			XmlDocument doc = new XmlDocument ();
			doc.PreserveWhitespace = true;
			XPathNavigator nav = doc.CreateNavigator ();
			using (XmlWriter w = nav.AppendChild ()) {
				msg.WriteMessage (w);
			}
			XmlNamespaceManager nsmgr = new XmlNamespaceManager (doc.NameTable);
			nsmgr.AddNamespace ("s", msg.Version.Envelope.Namespace);

			WrappedKeySecurityToken ekey = null;
			ReferenceList encRefList = null;
			Signature sig = null;
			EncryptedData sigenc = null;


			SupportingTokenInfoCollection tokens =
				CollectInitiatorSupportingTokens ();

{

			// SecurityTokenInclusionMode
			// - Initiator or Recipient
			// - done or notyet. FIXME: not implemented yet
			// It also affects on key reference output

			SecurityTokenInclusionMode appliedMode =
				securingParams.InclusionMode;
			bool msgIncludesToken = ShouldIncludeToken (appliedMode, false);

			SecurityKeyIdentifierClause encClause =
				initiatorParams.CallCreateKeyIdentifierClause (encToken, msgIncludesToken ? initiatorParams.ReferenceStyle : SecurityTokenReferenceStyle.External);
			SecurityKeyIdentifierClause signClause =
				recipientParams.CallCreateKeyIdentifierClause (signToken, msgIncludesToken ? recipientParams.ReferenceStyle : SecurityTokenReferenceStyle.External);

			AsymmetricSecurityKey encKey = (AsymmetricSecurityKey) 
				encToken.ResolveKeyIdentifierClause (encClause);
			AsymmetricSecurityKey signKey = (AsymmetricSecurityKey) 
				signToken.ResolveKeyIdentifierClause (signClause);

			// FIXME: it needs to choose message parts by 
			// ChannelProtectionRequirements.
			XmlElement body = doc.SelectSingleNode ("/s:Envelope/s:Body/*", nsmgr) as XmlElement;

			switch (protectionOrder) {
			case MessageProtectionOrder.EncryptBeforeSign:
				// FIXME: implement
				throw new NotImplementedException ();
			case MessageProtectionOrder.SignBeforeEncrypt:
			case MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature:

				MessagePartSpecification sigSpec = SignaturePart;

				// encryption key (possibly also used for signing)
				// FIXME: get correct SymmetricAlgorithm according to the algorithm suite
				RijndaelManaged aes = new RijndaelManaged ();
				aes.KeySize = 256;
				aes.Mode = CipherMode.CBC;
				aes.Padding = PaddingMode.ISO10126;

				// sign
				SignedXml sxml = new SignedXml (body);

				HMACSHA1 sigHash = null;
				if (security.DefaultSignatureAlgorithm == SignedXml.XmlDsigHMACSHA1Url)
					sigHash = new HMACSHA1 (aes.Key);
				else
					sxml.SigningKey = signKey.GetAsymmetricAlgorithm (security.DefaultSignatureAlgorithm, true);

				sig = sxml.Signature;
				sig.SignedInfo.CanonicalizationMethod =
					suite.DefaultCanonicalizationAlgorithm;
				foreach (XmlNode n in doc.SelectNodes ("/s:Envelope/s:Header/*", nsmgr)) {
					XmlElement el = n as XmlElement;
					if (el == null)
						continue;
					// FIXME: check sigSpec.HeaderTypes and skip it if not included.
					sig.SignedInfo.AddReference (CreateReference (el, suite));
				}
				foreach (XmlNode n in body.ChildNodes) {
					XmlElement el = n as XmlElement;
					if (el == null)
						continue;
					sig.SignedInfo.AddReference (CreateReference (el, suite));
				}
				if (sigHash != null)
					sxml.ComputeSignature (sigHash);
				else
					sxml.ComputeSignature ();
				sxml.KeyInfo = new KeyInfo ();
				SecurityTokenReferenceKeyInfo sigKeyInfo = new SecurityTokenReferenceKeyInfo (signClause, serializer, doc);
				sxml.KeyInfo.AddClause (sigKeyInfo);

				// encrypt
				string ekeyId = messageId + "-" + identForMessageId++;

				EncryptedXml exml = new EncryptedXml ();
				ekey = new WrappedKeySecurityToken (ekeyId,
					aes.Key,
					suite.DefaultAsymmetricKeyWrapAlgorithm,
					encToken,
					new SecurityKeyIdentifier (encClause));
				ReferenceList refList = new ReferenceList ();
				if (!initiatorParams.RequireDerivedKeys)
					ekey.ReferenceList = refList;
				else
					encRefList = refList;

				EncryptedData edata = Encrypt (body, aes, ekeyId, refList, encClause, exml, doc);
				edata.KeyInfo = null;
				EncryptedXml.ReplaceElement (body, edata, false);

				// encrypt signature
				if (protectionOrder == MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature) {
					XmlElement sigxml = sig.GetXml ();
					sigenc = Encrypt (sigxml, aes, ekeyId, refList, encClause, exml, doc);
				}
				break;
			}

			if (sig != null && msgIncludesToken)
				header.Contents.Add (signToken);
			if (signToken != encToken && msgIncludesToken)
				header.Contents.Add (encToken);

}

			Message ret = Message.CreateMessage (msg.Version, msg.Headers.Action, new XmlNodeReader (doc.SelectSingleNode ("/s:Envelope/s:Body/*", nsmgr) as XmlElement));

			ret.Headers.Clear ();
			ret.Headers.CopyHeadersFrom (msg);

			if (ekey != null)
				header.Contents.Add (ekey);

			// FIXME: it should be moved to encryption loop inside.
			// generate derived key if needed
			if (initiatorParams.RequireDerivedKeys) {
				RijndaelManaged deriv = new RijndaelManaged ();
				deriv.KeySize = 128;
				deriv.Mode = CipherMode.CBC;
				deriv.Padding = PaddingMode.ISO10126;
				deriv.GenerateKey ();
				WsscDerivedKeyToken derivedKey =
					new WsscDerivedKeyToken ();
				derivedKey.Id = GenerateId (doc);
				derivedKey.Offset = 0;
				derivedKey.Nonce = deriv.Key;
				derivedKey.Length = derivedKey.Nonce.Length;
				if (ekey != null)
					derivedKey.SecurityTokenReference =
						new LocalIdKeyIdentifierClause (ekey.Id);
				header.Contents.Add (derivedKey);
			}

			if (sigenc != null)
				header.Contents.Add (sigenc);
			else if (sig != null)
				header.Contents.Add (sig);

			if (encRefList != null)
				header.Contents.Add (encRefList);

			return ret;
		}

		Reference CreateReference (XmlElement el, SecurityAlgorithmSuite suite)
		{
			if (el.GetAttribute ("Id") == String.Empty)
				el.SetAttribute ("Id", GenerateId (el.OwnerDocument));
			Reference r = new Reference ("#" + el.GetAttribute ("Id"));
			r.AddTransform (CreateTransform (suite.DefaultCanonicalizationAlgorithm));
			r.DigestMethod = suite.DefaultDigestAlgorithm;
			return r;
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

		EncryptedData Encrypt (XmlElement target, SymmetricAlgorithm aes, string ekeyId, ReferenceList refList, SecurityKeyIdentifierClause encClause, EncryptedXml exml, XmlDocument doc)
		{
			SecurityAlgorithmSuite suite = security.Element.DefaultAlgorithmSuite;
			SecurityTokenSerializer serializer = security.TokenSerializer;

			byte [] encrypted = exml.EncryptData (target, aes, false);
			EncryptedData edata = new EncryptedData ();
			edata.Id = GenerateId (doc);
			edata.Type = EncryptedXml.XmlEncElementUrl;
			edata.EncryptionMethod = new EncryptionMethod (suite.DefaultEncryptionAlgorithm);
			// FIXME: here wsse:DigestMethod should be embedded 
			// inside EncryptionMethod. Since it is not possible 
			// with S.S.C.Xml.EncryptionMethod, we will have to
			// build our own XML encryption classes.

			edata.KeyInfo = new KeyInfo ();
			LocalIdKeyIdentifierClause ident =
				new LocalIdKeyIdentifierClause (ekeyId);
			KeyInfoClause kic = new SecurityTokenReferenceKeyInfo (ident, serializer, doc);
			edata.KeyInfo.AddClause (kic);
			edata.CipherData.CipherValue = encrypted;

			DataReference dr = new DataReference ();
			dr.Uri = "#" + edata.Id;
			refList.Add (dr);
			return edata;
		}

		static string GenerateId (XmlDocument doc)
		{
			int i = 1;
			while (doc.SelectSingleNode (String.Format (CultureInfo.InvariantCulture, "//*[@Id = '_{0}']", i)) != null ||
			       doc.SelectSingleNode (String.Format (CultureInfo.InvariantCulture, "//*[@Id = '_{0}']", i)) != null)
				i++;
			return "_" + i;
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
