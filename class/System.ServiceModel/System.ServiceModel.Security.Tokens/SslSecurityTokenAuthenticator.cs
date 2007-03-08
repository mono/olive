//
// SslSecurityTokenAuthenticator.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2007 Novell, Inc.  http://www.novell.com
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
using System.Net.Security;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

using ReqType = System.ServiceModel.Security.Tokens.ServiceModelSecurityTokenRequirement;

namespace System.ServiceModel.Security.Tokens
{
	// FIXME: implement all
	class SslSecurityTokenAuthenticator : CommunicationSecurityTokenAuthenticator
	{
		ServiceCredentialsSecurityTokenManager manager;
		SslAuthenticatorCommunicationObject comm;
		bool mutual;

		public SslSecurityTokenAuthenticator (
			ServiceCredentialsSecurityTokenManager manager, 
			SecurityTokenRequirement r)
		{
			this.manager = manager;
			mutual = (r.TokenType == ServiceModelSecurityTokenTypes.MutualSslnego);
			comm = new SslAuthenticatorCommunicationObject (this);
		}

		public bool IsMutual {
			get { return mutual; }
		}

		public ServiceCredentialsSecurityTokenManager Manager {
			get { return manager; }
		}

		public override AuthenticatorCommunicationObject Communication {
			get { return comm; }
		}

		protected override bool CanValidateTokenCore (SecurityToken token)
		{
			throw new NotImplementedException ();
		}

		protected override ReadOnlyCollection<IAuthorizationPolicy>
			ValidateTokenCore (SecurityToken token)
		{
			throw new NotImplementedException ();
		}
	}

	class SslAuthenticatorCommunicationObject : AuthenticatorCommunicationObject
	{
		SslSecurityTokenAuthenticator owner;

		public SslAuthenticatorCommunicationObject (SslSecurityTokenAuthenticator owner)
		{
			this.owner = owner;
		}

		WSTrustSecurityTokenServiceProxy proxy;

		protected internal override TimeSpan DefaultCloseTimeout {
			get { throw new NotImplementedException (); }
		}

		protected internal override TimeSpan DefaultOpenTimeout {
			get { throw new NotImplementedException (); }
		}

		public override Message ProcessNegotiation (Message request)
		{
			if (request.Headers.Action == Constants.WstIssueAction)
				return ProcessClientHello (request);
			else
				return ProcessClientKeyExchange (request);
		}

		Dictionary<string,TlsServerSession> sessions =
			new Dictionary<string,TlsServerSession> ();

		Message ProcessClientHello (Message request)
		{
			WSTrustRequestSecurityTokenReader reader =
				new WSTrustRequestSecurityTokenReader (request.GetReaderAtBodyContents (), SecurityTokenSerializer);
			reader.Read ();

			if (sessions.ContainsKey (reader.Value.Context))
				throw new InvalidOperationException (String.Format ("The context '{0}' already exists in this SSL negotiation manager", reader.Value.Context));

			TlsServerSession tls = new TlsServerSession (owner.Manager.ServiceCredentials.ServiceCertificate.Certificate, owner.IsMutual);

			tls.ProcessClientHello (reader.Value.BinaryExchange.Value);
			WstRequestSecurityTokenResponse rstr =
				new WstRequestSecurityTokenResponse ();
			rstr.Context = reader.Value.Context;
			rstr.BinaryExchange = new WstBinaryExchange ();
			rstr.BinaryExchange.Value = tls.ProcessServerHello ();

			Message reply = Message.CreateMessage (request.Version, Constants.WstIssueReplyAction, rstr);
			reply.Headers.RelatesTo = request.Headers.MessageId;

			sessions [reader.Value.Context] = tls;

			return reply;
		}

		Message ProcessClientKeyExchange (Message request)
		{
			WSTrustRequestSecurityTokenResponseReader reader =
				new WSTrustRequestSecurityTokenResponseReader (request.GetReaderAtBodyContents (), SecurityTokenSerializer, null);
			reader.Read ();

foreach (byte b in reader.Value.BinaryExchange.Value) Console.Write ("{0:X02} ", b); Console.WriteLine ();

			TlsServerSession tls;
			if (!sessions.TryGetValue (reader.Value.Context, out tls))
				throw new InvalidOperationException (String.Format ("The context '{0}' does not exist in this SSL negotiation manager", reader.Value.Context));
			tls.ProcessClientKeyExchange (reader.Value.BinaryExchange.Value);

			// ... so, I dunno what to do next here

			throw new NotImplementedException ();
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
