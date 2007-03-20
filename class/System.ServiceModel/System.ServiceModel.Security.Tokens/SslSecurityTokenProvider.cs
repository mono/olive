//
// SslSecurityTokenProvider.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006-2007 Novell, Inc.  http://www.novell.com
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
using System.IO;
using System.Net.Security;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;

using ReqType = System.ServiceModel.Security.Tokens.ServiceModelSecurityTokenRequirement;

namespace System.ServiceModel.Security.Tokens
{
	class SslSecurityTokenProvider : CommunicationSecurityTokenProvider
	{
		SslCommunicationObject comm;

		public SslSecurityTokenProvider ()
		{
			comm = new SslCommunicationObject ();
		}

		public override ProviderCommunicationObject Communication {
			get { return comm; }
		}

		public override SecurityToken GetOnlineToken (TimeSpan timeout)
		{
			return comm.GetToken (timeout);
		}
	}

	class SslCommunicationObject : ProviderCommunicationObject
	{
		WSTrustSecurityTokenServiceProxy proxy;

		public SslCommunicationObject ()
		{
		}

		public SecurityToken GetToken (TimeSpan timeout)
		{
			TlsClientSession tls = new TlsClientSession (IssuerAddress.Uri.ToString ());
			WstRequestSecurityToken rst =
				new WstRequestSecurityToken ();

			// send ClientHello
			rst.BinaryExchange = new WstBinaryExchange ();
			rst.BinaryExchange.Value = tls.ProcessClientHello ();

			Message request = Message.CreateMessage (IssuerBinding.MessageVersion, Constants.WstIssueAction, rst);
			request.Headers.MessageId = new UniqueId ();
			request.Headers.ReplyTo = new EndpointAddress (Constants.WsaAnonymousUri);
			request.Headers.To = TargetAddress.Uri;
			Message response = proxy.Issue (request);

			// receive ServerHello
			WSTrustRequestSecurityTokenResponseReader reader =
				new WSTrustRequestSecurityTokenResponseReader (response.GetReaderAtBodyContents (), SecurityTokenSerializer, null);
			reader.Read ();
			if (reader.Value.RequestedSecurityToken != null)
				return reader.Value.RequestedSecurityToken;

			tls.ProcessServerHello (reader.Value.BinaryExchange.Value);

			// send ClientKeyExchange
			WstRequestSecurityTokenResponse rstr =
				new WstRequestSecurityTokenResponse (SecurityTokenSerializer);
			rstr.Context = reader.Value.Context;
			rstr.BinaryExchange = new WstBinaryExchange ();
			rstr.BinaryExchange.Value = tls.ProcessClientKeyExchange ();

			request = Message.CreateMessage (IssuerBinding.MessageVersion, Constants.WstIssueReplyAction, rstr);
			request.Headers.ReplyTo = new EndpointAddress (Constants.WsaAnonymousUri);
			request.Headers.To = TargetAddress.Uri;
			// FIXME: regeneration of this instance is somehow required, but should not be.
			proxy = new WSTrustSecurityTokenServiceProxy (
				IssuerBinding, IssuerAddress);
			response = proxy.IssueReply (request);

MessageBuffer bugg = response.CreateBufferedCopy (10000);
response = bugg.CreateMessage ();
Console.WriteLine (bugg.CreateMessage ());

			// FIXME: support simple RSTR
			WstRequestSecurityTokenResponseCollection coll =
				new WstRequestSecurityTokenResponseCollection ();
			coll.Read (response.GetReaderAtBodyContents (), SecurityTokenSerializer, null);

			WstRequestSecurityTokenResponse r = coll.Responses [0];
			tls.ProcessServerFinished (r.BinaryExchange.Value);
			SecurityContextSecurityToken sctSrc =
				r.RequestedSecurityToken;

			// the RequestedProofToken looks like below:
			// 17 03 01 00 30 1A 37 0A 80 3D 5E F7 6B 54 FA A0 FA 1B
			// C2 D6 B8 DB F0 4D E5 62 85 A7 31 0C 8E F9 F4 D9 5C 35
			// 99 DA C7 BE 45 8B 58 A1 B3 D0 B0 F8 8E C3 1C 46 A0
			// This looks like a TLS ApplicationData which consists
			// of 32 bytes of data. It smells like *the* shared key.
			byte [] key = tls.ProcessApplicationData (
				(byte []) r.RequestedProofToken);

			// FIXME: get correct parameter values.
			SecurityContextSecurityToken sct = new SecurityContextSecurityToken (sctSrc.ContextId, sctSrc.Id, key,
				r.Lifetime.Created, r.Lifetime.Expires, null,
				DateTime.MinValue, DateTime.MaxValue, null);
			// FIXME: authenticate token if required.

			// the input dnse:Cookie value is encrypted by the
			// server's SecurityStateEncoder
			// (setting error-raising encoder to ServiceCredentials.
			// SecureConversationAuthentication.SecurityStateEncoder
			// shows it).
			// FIXME: so, now we need to find out what the "raw"
			// value means. It wasn't either
			// - XML binary dictioanry reader value, or
			// - valid utf16 string.

			return sct;
		}

		protected internal override TimeSpan DefaultCloseTimeout {
			get { throw new NotImplementedException (); }
		}

		protected internal override TimeSpan DefaultOpenTimeout {
			get { throw new NotImplementedException (); }
		}

		protected override void OnAbort ()
		{
			throw new NotImplementedException ();
		}

		protected override void OnOpen (TimeSpan timeout)
		{
			if (State == CommunicationState.Opened)
				throw new InvalidOperationException ("Already opened.");

			EnsureProperties ();

			proxy = new WSTrustSecurityTokenServiceProxy (
				IssuerBinding, IssuerAddress);
		}

		protected override IAsyncResult OnBeginOpen (TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		protected override void OnEndOpen (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}

		protected override void OnClose (TimeSpan timeout)
		{
			if (proxy != null)
				proxy.Close ();
		}

		protected override IAsyncResult OnBeginClose (TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		protected override void OnEndClose (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}
	}
}
