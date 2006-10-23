//
// WSTrustSecurityTokenService.cs
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

namespace Mono.SecurityTokenServices
{
	class WSTrustSecurityTokenService : IWSTrustSecurityTokenService
	{
		MessageVersion version = MessageVersion.Default;
		WSSecurityTokenSerializer serializer;

		public WSTrustSecurityTokenService ()
		{
			serializer = WSSecurityTokenSerializer.DefaultInstance;
		}

		public WstRequestSecurityToken ReadRequest (Message msg)
		{
			using (WSTrustRequestSecurityTokenReader reader =
				new WSTrustRequestSecurityTokenReader (msg.GetReaderAtBodyContents (), serializer)) {
				reader.Read ();
				return reader.Value;
			}
		}

		public Message CreateResponse (WstRequestSecurityTokenResponse response, string action)
		{
			return Message.CreateMessage (version, action,
				new WstRequestSecurityTokenResponseWriter (response, serializer));
		}

		public Message Issue (Message request)
		{
			WstRequestSecurityToken req = ReadRequest (request);
			WstRequestSecurityTokenResponse res = Issue (req);
			return CreateResponse (res, Constants.WstIssueReplyAction);
		}

		public Message Renew (Message request)
		{
			WstRequestSecurityToken req = ReadRequest (request);
			WstRequestSecurityTokenResponse res = Renew (req);
			return CreateResponse (res, Constants.WstRenewReplyAction);
		}

		public Message Cancel (Message request)
		{
			WstRequestSecurityToken req = ReadRequest (request);
			WstRequestSecurityTokenResponse res = Cancel (req);
			return CreateResponse (res, Constants.WstCancelReplyAction);
		}

		public Message Validate (Message request)
		{
			WstRequestSecurityToken req = ReadRequest (request);
			WstRequestSecurityTokenResponse res = Validate (req);
			return CreateResponse (res, Constants.WstValidateReplyAction);
		}

		public WstRequestSecurityTokenResponse Issue (WstRequestSecurityToken request)
		{
			if (request == null)
				throw new ArgumentNullException ("request");

foreach (FieldInfo fi in request.GetType ().GetFields ())
Console.WriteLine ("{0}: {1}", fi, fi.GetValue (request));

			WstRequestSecurityTokenResponse response =
				new WstRequestSecurityTokenResponse ();
			Rijndael aes = Rijndael.Create ();
			response.TokenType = "http://schemas.xmlsoap.org/ws/2005/02/trust/SymmetricKey";
			string id = new UniqueId ().ToString ();
			response.RequestedSecurityToken =
				new BinarySecretSecurityToken (id, aes.Key);

			return response;
		}

		public WstRequestSecurityTokenResponse Renew (WstRequestSecurityToken request)
		{
			throw new NotImplementedException ();
		}

		public WstRequestSecurityTokenResponse Cancel (WstRequestSecurityToken request)
		{
			throw new NotImplementedException ();
		}

		public WstRequestSecurityTokenResponse Validate (WstRequestSecurityToken request)
		{
			throw new NotImplementedException ();
		}
	}
}

