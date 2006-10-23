//
// WSTrustMessageConverters.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.
//

using System;
using System.Reflection;
using System.Security.Cryptography;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;
using System.Xml.Serialization;

namespace System.ServiceModel.Description
{
	class WSTrustRequestSecurityTokenReader : IDisposable
	{
		WstRequestSecurityToken req = new WstRequestSecurityToken ();
		XmlDictionaryReader reader;
		SecurityTokenSerializer serializer;

		public WSTrustRequestSecurityTokenReader (XmlDictionaryReader reader, SecurityTokenSerializer serializer)
		{
			this.reader = reader;
			this.serializer = serializer;
		}

		public WstRequestSecurityToken Value {
			get { return req; }
		}

		string LineInfo ()
		{
			IXmlLineInfo li = reader as IXmlLineInfo;
			return li != null && li.HasLineInfo () ?
				String.Format ("({0},{1})", li.LineNumber, li.LinePosition) : String.Empty;
		}

		public void Dispose ()
		{
			reader.Close ();
		}

		public WstRequestSecurityToken Read ()
		{
			reader.MoveToContent ();
			reader.ReadStartElement ("RequestSecurityToken", Constants.WstNamespace);
			do {
				reader.MoveToContent ();
				switch (reader.NodeType) {
				case XmlNodeType.EndElement:
					reader.Read (); // consume RequestSecurityToken end element.
					return req;
				case XmlNodeType.Element:
					ReadTokenContent ();
					break;
				default:
					throw new XmlException (String.Format ("Unexpected request XML {0} node, name {1}{2}", reader.NodeType, reader.Name, LineInfo ()));
				}
			} while (true);
		}

		void ReadTokenContent ()
		{
			switch (reader.NamespaceURI) {
			case Constants.WstNamespace:
				switch (reader.LocalName) {
				case "RequestType":
					req.RequestType = reader.ReadElementContentAsString ();
					return;
				case "Entropy":
					ReadEntropy ();
					return;
				case "KeySize":
					req.KeySize = reader.ReadElementContentAsInt ();
					return;
				case "KeyType":
					req.KeyType = reader.ReadElementContentAsString ();
					return;
				case "ComputedKeyAlgorithm":
					req.ComputedKeyAlgorithm = reader.ReadElementContentAsString ();
					return;
				}
				break;
			case Constants.WspNamespace:
				switch (reader.LocalName) {
				case "AppliesTo":
					ReadAppliesTo ();
					return;
				}
				break;
			}
			throw new XmlException (String.Format ("Unexpected RequestSecurityToken content element. Name is {0} and namespace URI is {1}{2}", reader.Name, reader.NamespaceURI, LineInfo ()));
		}

		void ReadEntropy ()
		{
			if (reader.IsEmptyElement)
				throw new XmlException (String.Format ("WS-Trust Entropy element is empty.{2}", LineInfo ()));
			reader.ReadStartElement ("Entropy", Constants.WstNamespace);
			reader.MoveToContent ();

			req.Entropy = serializer.ReadToken (reader, null);
			// after reading a token, </Entropy> should follow.
			reader.MoveToContent ();
			reader.ReadEndElement ();
		}

		void ReadAppliesTo ()
		{
			WspAppliesTo aTo = new WspAppliesTo ();

			if (reader.IsEmptyElement)
				throw new XmlException (String.Format ("WS-Policy AppliesTo element is empty.{2}", LineInfo ()));
			reader.ReadStartElement ();
			reader.MoveToContent ();
			reader.ReadStartElement ("EndpointReference", Constants.WsaNamespace);
			reader.MoveToContent ();
			WsaEndpointReference er = new WsaEndpointReference ();
			er.Address = reader.ReadElementContentAsString ("Address", Constants.WsaNamespace);
			reader.MoveToContent ();
			reader.ReadEndElement (); // </EndpointReference>
			aTo.EndpointReference = er;
			reader.MoveToContent ();
			reader.ReadEndElement (); // </wsp:AppliesTo>
			req.AppliesTo = aTo;
		}
	}

	class WstRequestSecurityTokenWriter : BodyWriter
	{
		WstRequestSecurityToken value;
		SecurityTokenSerializer serializer;

		public WstRequestSecurityTokenWriter (WstRequestSecurityToken value, SecurityTokenSerializer serializer)
			: base (true)
		{
			this.value = value;
			this.serializer = serializer;
		}

		protected override void OnWriteBodyContents (XmlDictionaryWriter w)
		{
			w.WriteStartElement ("RequestSecurityToken", Constants.WstNamespace);
			w.WriteEndElement ();
		}
	}

	class WSTrustRequestSecurityTokenResponseReader : IDisposable
	{
		WstRequestSecurityTokenResponse res = new WstRequestSecurityTokenResponse ();
		XmlDictionaryReader reader;
		SecurityTokenSerializer serializer;
		SecurityTokenResolver resolver;

		public WSTrustRequestSecurityTokenResponseReader (
			XmlDictionaryReader reader,
			SecurityTokenSerializer serializer,
			SecurityTokenResolver resolver)
		{
			this.reader = reader;
			this.serializer = serializer;
			this.resolver = resolver;
		}

		public WstRequestSecurityTokenResponse Value {
			get { return res; }
		}

		string LineInfo ()
		{
			IXmlLineInfo li = reader as IXmlLineInfo;
			return li != null && li.HasLineInfo () ?
				String.Format ("({0},{1})", li.LineNumber, li.LinePosition) : String.Empty;
		}

		public void Dispose ()
		{
			reader.Close ();
		}

		public WstRequestSecurityTokenResponse Read ()
		{
			reader.MoveToContent ();
			reader.ReadStartElement ("RequestSecurityTokenResponse", Constants.WstNamespace);
			do {
				reader.MoveToContent ();
				switch (reader.NodeType) {
				case XmlNodeType.EndElement:
					reader.Read (); // consume RequestSecurityTokenResponse end element.
					return res;
				case XmlNodeType.Element:
					ReadTokenContent ();
					break;
				default:
					throw new XmlException (String.Format ("Unexpected request XML {0} node, name {1}{2}", reader.NodeType, reader.Name, LineInfo ()));
				}
			} while (true);
		}

		void ReadTokenContent ()
		{
			switch (reader.NamespaceURI) {
			case Constants.WstNamespace:
				switch (reader.LocalName) {
				case "RequestedSecurityToken":
					ReadRequestedSecurityToken ();
					return;
				}
				break;
			}
			throw new XmlException (String.Format ("Unexpected RequestSecurityToken content element. Name is {0} and namespace URI is {1}{2}", reader.Name, reader.NamespaceURI, LineInfo ()));
		}

		void ReadRequestedSecurityToken ()
		{
			if (reader.IsEmptyElement)
				throw new XmlException (String.Format ("Requested security token body is expected.{0}", LineInfo ()));
			reader.Read ();
			reader.MoveToContent ();
			res.RequestedSecurityToken = serializer.ReadToken (reader, resolver);
			reader.ReadEndElement (); // </RequestedSecurityToken>
		}
	}

	internal class WstRequestSecurityTokenResponseWriter : BodyWriter
	{
		WstRequestSecurityTokenResponse res;
		SecurityTokenSerializer serializer;

		public WstRequestSecurityTokenResponseWriter (WstRequestSecurityTokenResponse res, SecurityTokenSerializer serializer)
			: base (true)
		{
			this.res = res;
			this.serializer = serializer;
		}

		protected override void OnWriteBodyContents (XmlDictionaryWriter writer)
		{
try {
			writer.WriteStartElement ("RequestSecurityTokenResponse", Constants.WstNamespace);

			// RequestedSecurityToken
			writer.WriteStartElement ("RequestedSecurityToken", Constants.WstNamespace);

			serializer.WriteToken (writer, res.RequestedSecurityToken);

			writer.WriteEndElement ();

/*
			// Entropy
			writer.WriteStartElement ("Entropy", Constants.WstNamespace);
			// FIXME: keep generated key
			serializer.WriteToken (writer,
				new BinarySecretSecurityToken (Rijndael.Create ().Key));
			writer.WriteEndElement ();
*/

			writer.WriteEndElement ();
} catch (Exception ex) {
Console.WriteLine (ex);
throw;
}
		}
	}
}

