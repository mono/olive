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
	}

	internal class InitiatorSecureMessageDecryptor : SecureMessageDecryptor
	{
		InitiatorMessageSecurityBindingSupport security;

		public InitiatorSecureMessageDecryptor (
			Message source, InitiatorMessageSecurityBindingSupport security)
			: base (source, security)
		{
			this.security = security;
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

		static SecurityKey ResolveKey (SecurityToken token, SecurityTokenParameters p)
		{
			SecurityKeyIdentifierClause clause =
				p.CallCreateKeyIdentifierClause (token, p.ReferenceStyle);
			return token.ResolveKeyIdentifierClause (clause);
		}

		public Message DecryptMessage ()
		{
			SecurityTokenSerializer serializer =
				security.TokenSerializer;
			SecurityTokenResolver resolver =
				security.OutOfBandTokenResolver;
			SecurityToken token =
				security.EncryptionToken;
			SecurityTokenParameters parameters =
				security.RecipientParameters;

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

			DecryptDocument (token, parameters);

			Message msg = Message.CreateMessage (new XmlNodeReader (doc), srcmsg.Headers.Count, srcmsg.Version);

			// FIXME: when Local[Client|Service]SecuritySettings.DetectReplays
			// is true, reject such messages which don't have <wsu:Timestamp>

			WSSecurityMessageHeader sheader = null;

			for (int i = 0; i < srcmsg.Headers.Count; i++) {
				MessageHeaderInfo header = srcmsg.Headers [i];
				if (header.Namespace == Constants.WssNamespace &&
				    header.Name == "Security") {
					sheader = WSSecurityMessageHeader.Read (
						srcmsg.Headers.GetReaderAtHeader (i),
						serializer, resolver);
					msg.Headers.Add (sheader);
				}
				else
					msg.Headers.CopyHeaderFrom (srcmsg.Headers, i);
			}

			// FIXME: verify signature.

			if (sheader == null)
				throw new InvalidOperationException ("Message security header was not found in the request message.");
			return msg;
		}

		void DecryptDocument (SecurityToken token, SecurityTokenParameters parameters)
		{
			SecurityKey securityKey = ResolveKey (token, parameters);

			XmlNodeList securityHeaders = doc.SelectNodes ("/s:Envelope/s:Header/o:Security", nsmgr);
			if (securityHeaders.Count == 0)
				throw new MessageSecurityException ("In this service that contains the security binding element, a security header is required in the reply message.");

			foreach (XmlElement secElem in securityHeaders)
				DecryptSingleSecurity (secElem, token, parameters, securityKey);
		}

		void DecryptSingleSecurity (XmlElement secElem, SecurityToken token, SecurityTokenParameters parameters, SecurityKey securityKey)
		{
			// decrypt the key with service certificate privkey
			EncryptedXml encXml = new EncryptedXml (doc);

			if (security.MessageProtectionOrder == MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature &&
			    secElem.SelectSingleNode ("dsig:Signature", nsmgr) != null)
				throw new MessageSecurityException ("The security binding element expects that the message signature is encrypted, while it isn't.");

			XmlElement keyElem = secElem.SelectSingleNode ("e:EncryptedKey", nsmgr) as XmlElement;
			EncryptedKey encryptedKey = new EncryptedKey ();
			encryptedKey.LoadXml (keyElem);

			byte [] decryptedKey = securityKey.DecryptKey (
				encryptedKey.EncryptionMethod.KeyAlgorithm,
				encryptedKey.CipherData.CipherValue);

			// create derived keys
			// FIXME: an alternative approach is to make use of
			// EncryptedXml.AddKeyNameMapping().
			Dictionary<string,byte[]> map = ResolveDerivedKeys (secElem, decryptedKey);
			if (encryptedKey.Id != null)
				map [encryptedKey.Id] = decryptedKey;
			Rijndael aes = RijndaelManaged.Create (); // it is reused with every key
			aes.Key = map [String.Empty];
			aes.Mode = CipherMode.CBC;

			// decrypt the body with the decrypted key
			Collection<string> references = new Collection<string> ();
			foreach (XmlElement rlist in secElem.SelectNodes ("e:ReferenceList", nsmgr))
				foreach (XmlElement encref in rlist.SelectNodes ("e:DataReference | e:KeyReference", nsmgr))
					references.Add (StripUri (encref.GetAttribute ("URI")));
			foreach (EncryptedReference er in encryptedKey.ReferenceList)
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
				byte [] key = GetEncryptionKeyForData (ed2, encXml, map);
				aes.Key = key != null ? key : decryptedKey;
				if (ed2.GetXml () == null) throw new Exception ("Gyabo");
				encXml.ReplaceData (el, DecryptLax (encXml, ed2, aes));
			}

Console.WriteLine ("======== Decrypted Document ========");
doc.PreserveWhitespace = false;
doc.Save (Console.Out);
doc.PreserveWhitespace = true;

			if (secElem.SelectSingleNode ("dsig:Signature", nsmgr) == null)
				throw new MessageSecurityException ("The the message signature is expected but not found.");
		}

		byte [] GetEncryptionKeyForData (EncryptedData ed2, EncryptedXml encXml, Dictionary<string,byte[]> map)
		{
			SecurityTokenSerializer serializer =
				security.TokenSerializer;

			if (ed2.KeyInfo == null)
				return null;
			foreach (KeyInfoClause kic in ed2.KeyInfo) {
				KeyInfoNode n = kic as KeyInfoNode;
				if (n == null)
					continue; // FIXME: probably other kinds of KeyInfoClause could be used.
				if (n.Value == null || n.Value.LocalName != "SecurityTokenReference" || n.Value.NamespaceURI != Constants.WssNamespace)
					continue; // FIXME: probably other kinds of KeyInfoClause could be used.

				SecurityKeyIdentifierClause skic = serializer.ReadKeyIdentifierClause (new XmlNodeReader (n.Value));
				LocalIdKeyIdentifierClause lskic = skic as LocalIdKeyIdentifierClause;
				string keyUri = (lskic != null) ?
					lskic.LocalId : String.Empty;
				if (lskic != null && map.ContainsKey (keyUri))
					return map [keyUri];
				else
					throw new XmlException (String.Format ("Encryption key for '{0}' was not found. URI is '{1}'", ed2.Id, keyUri));
			}
			return null; // no applicable key info clause.
		}

		// FIXME: this should consider the referent SecurityToken of
		// each DerivedKeyToken element.
		Dictionary<string,byte[]> ResolveDerivedKeys (XmlElement secElem, byte [] decryptedKey)
		{
			// create mapping from Id to derived keys
			Dictionary<string,byte[]> keys = new Dictionary<string,byte[]> ();
			// default, unless overriden by the default DerivedKeyToken.
			keys [String.Empty] = decryptedKey;

			InMemorySymmetricSecurityKey skey =
				new InMemorySymmetricSecurityKey (decryptedKey);

			byte [] currentKey = decryptedKey;
			foreach (XmlNode n in secElem.ChildNodes) {
				XmlElement el = n as XmlElement;
				if (el == null)
					continue;
				if (el.LocalName == "DerivedKeyToken" &&
				    el.NamespaceURI == Constants.WsscNamespace) {
					byte [] key = GetDerivedKeyBytes (el, skey);
					string id = el.GetAttribute ("Id", Constants.WsuNamespace);
					id = (id == null) ? String.Empty : id;
					keys [id] = key;
				}
			}

			return keys;
		}

		string StripUri (string src)
		{
			if (src == null || src.Length == 0)
				return String.Empty;
			if (src [0] != '#')
				throw new NotSupportedException (String.Format ("Non-fragment URI in DataReference and KeyReference is not supported: '{0}'", src));
			return src.Substring (1);
		}

		byte [] GetDerivedKeyBytes (XmlElement el, InMemorySymmetricSecurityKey skey)
		{
			XmlNode n = el.SelectSingleNode ("c:Offset", nsmgr);
			int offset = (n == null) ? 0 :
				int.Parse (n.InnerText, CultureInfo.InvariantCulture);
			n = el.SelectSingleNode ("c:Length", nsmgr);
			int length = (n == null) ? 32 :
				int.Parse (n.InnerText, CultureInfo.InvariantCulture);
			n = el.SelectSingleNode ("c:Label", nsmgr);
			string inLabel = n == null ? "WS-SecureConversation" : n.InnerText;
			byte [] label = Encoding.UTF8.GetBytes (
				inLabel + "WS-SecureConversation");
			n = el.SelectSingleNode ("c:Nonce", nsmgr);
			byte [] nonce = (n == null) ? new byte [0] :
				Convert.FromBase64String (n.InnerText);
			return skey.GenerateDerivedKey (
				SecurityAlgorithms.Psha1KeyDerivation,
				label, nonce, length * 8, offset);
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
