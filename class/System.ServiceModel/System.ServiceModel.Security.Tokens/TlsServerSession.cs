//
// TlsServerSession.cs
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
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Mono.Security.Protocol.Tls;
using Mono.Security.Protocol.Tls.Handshake;
using Mono.Security.Protocol.Tls.Handshake.Server;

namespace System.ServiceModel.Security.Tokens
{
	internal class TlsServerSession : TlsSession
	{
		SslServerStream ssl;

		public TlsServerSession (X509Certificate2 cert, bool clientCertificateRequired)
		{
			ssl = new SslServerStream (new MemoryStream (), cert, clientCertificateRequired, true, SecurityProtocolType.Tls);
		}

		protected override Context Context {
			get { return ssl.context; }
		}

		public void ProcessClientHello (byte [] raw)
		{
			MemoryStream ms = new MemoryStream (raw);
			ReadChangeCipherSpec (ms);
			// ClientHello
			byte [] bytes = ReadNextOperation (ms, HandshakeType.ClientHello);
			TlsClientHello c = new TlsClientHello (ssl.context, bytes);
			c.Process ();
			c.Update ();

			VerifyEndOfTransmit (ms);
		}

		// ServerHello, ServerCertificate and ServerHelloDone
		public byte [] ProcessServerHello ()
		{
			MemoryStream ms = new MemoryStream ();

			WriteChangeCipherSpec (ms);

			WriteOperation (ms, new TlsServerHello (ssl.context));
			WriteOperation (ms, new TlsServerCertificate (ssl.context));
			WriteOperation (ms, new TlsServerHelloDone (ssl.context));

			return ms.ToArray ();
		}
	}
}
