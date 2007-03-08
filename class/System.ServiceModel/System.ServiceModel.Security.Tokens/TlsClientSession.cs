//
// TlsClientSession.cs
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
using System.IO;
using Mono.Security.Protocol.Tls;
using Mono.Security.Protocol.Tls.Handshake;
using Mono.Security.Protocol.Tls.Handshake.Client;

namespace System.ServiceModel.Security.Tokens
{
	internal abstract class TlsSession
	{
		protected abstract Context Context { get; }

		protected void WriteHandshake (MemoryStream ms)
		{
			Context.SupportedCiphers = CipherSuiteFactory.GetSupportedCiphers (SecurityProtocolType.Tls);
			ms.WriteByte (0x16); // Handshake
			ms.WriteByte (3); // version-major
			ms.WriteByte (1); // version-minor
		}

		protected void WriteChangeCipherSpec (MemoryStream ms)
		{
			ms.WriteByte (0x14); // Handshake
			ms.WriteByte (3); // version-major
			ms.WriteByte (1); // version-minor
			ms.WriteByte (0); // size-upper
			ms.WriteByte (1); // size-lower
			ms.WriteByte (1); // ChangeCipherSpec content (1 byte)
		}

		protected void ReadHandshake (MemoryStream ms)
		{
			if (ms.ReadByte () != 0x16)
				throw new Exception ("INTERNAL ERROR: handshake is expected");
			Context.ChangeProtocol ((short) (ms.ReadByte () * 0x100 + ms.ReadByte ()));
		}

		protected void ReadChangeCipherSpec (MemoryStream ms)
		{
			if (ms.ReadByte () != 0x14)
				throw new Exception ("INTERNAL ERROR: ChangeCipherSpec is expected");
			Context.ChangeProtocol ((short) (ms.ReadByte () * 0x100 + ms.ReadByte ()));
			if (ms.ReadByte () * 0x100 + ms.ReadByte () != 1)
				throw new Exception ("INTERNAL ERROR: unexpected ChangeCipherSpec length");
			ms.ReadByte (); // ChangeCipherSpec content (1 byte) ... anything is OK?
		}

		protected byte [] ReadNextOperation (MemoryStream ms, HandshakeType expected)
		{
			if (ms.ReadByte () != (int) expected)
				throw new Exception ("INTERNAL ERROR: unexpected server response");
			int size = ms.ReadByte () * 0x10000 + ms.ReadByte () * 0x100 + ms.ReadByte ();
			// FIXME: use correct valid input range
			if (size > 0x100000)
				throw new Exception ("rejected massive input size.");
			byte [] bytes = new byte [size];
			ms.Read (bytes, 0, size);
			return bytes;
		}

		protected void WriteOperations (MemoryStream ms, params HandshakeMessage [] msgs)
		{
			List<byte []> rawbufs = new List<byte []> ();
			int total = 0;
			for (int i = 0; i < msgs.Length; i++) {
				HandshakeMessage msg = msgs [i];
				msg.Process ();
				rawbufs.Add (msg.EncodeMessage ());
				total += rawbufs [i].Length;
				msg.Update ();
			}
			// FIXME: split packets when the size exceeded 0x10000 (or so)
			ms.WriteByte ((byte) (total / 0x100));
			ms.WriteByte ((byte) (total % 0x100));
			foreach (byte [] bytes in rawbufs)
				ms.Write (bytes, 0, bytes.Length);
		}

		protected void VerifyEndOfTransmit (MemoryStream ms)
		{
			if (ms.Position == ms.Length)
				return;

			/*
			byte [] bytes = new byte [ms.Length - ms.Position];
			ms.Read (bytes, 0, bytes.Length);
			foreach (byte b in bytes)
				Console.Write ("{0:X02} ", b);
			Console.WriteLine (" - total {0} bytes remained.", bytes.Length);
			*/

			throw new Exception ("INTERNAL ERROR: unexpected server response");
		}
	}

	internal class TlsClientSession : TlsSession
	{
		SslClientStream ssl;

		public TlsClientSession (string host)
		{
			ssl = new SslClientStream (new MemoryStream (), host, true, SecurityProtocolType.Tls);
		}

		protected override Context Context {
			get { return ssl.context; }
		}

		public byte [] ProcessClientHello ()
		{
			MemoryStream ms = new MemoryStream ();
			// ClientHello
			WriteHandshake (ms);
			TlsClientHello c = new TlsClientHello (ssl.context);
			WriteOperations (ms, c);

			return ms.ToArray ();
		}

		// ServerHello, ServerCertificate and ServerHelloDone
		public void ProcessServerHello (byte [] raw)
		{
			MemoryStream ms = new MemoryStream (raw);

			ReadHandshake (ms);
			// FIXME: use this size info?
			int size = ms.ReadByte () * 0x100 + ms.ReadByte ();

			// ServerHello
			byte [] bytes = ReadNextOperation (ms, HandshakeType.ServerHello);
			TlsServerHello sh = new TlsServerHello (ssl.context, bytes);
			sh.Process ();
			sh.Update ();

			// ServerCertificate
			bytes = ReadNextOperation (ms, HandshakeType.Certificate);
			TlsServerCertificate sc = new TlsServerCertificate (ssl.context, bytes);
			sc.Process ();
			sc.Update ();

			// ServerHelloDone
			bytes = ReadNextOperation (ms, HandshakeType.ServerHelloDone);
			TlsServerHelloDone shd = new TlsServerHelloDone (ssl.context, bytes);
			shd.Process ();
			shd.Update ();

			VerifyEndOfTransmit (ms);
		}

		public byte [] ProcessClientKeyExchange ()
		{
			// ClientKeyExchange
			MemoryStream ms = new MemoryStream ();
			WriteHandshake (ms);
			TlsClientKeyExchange ckx = new TlsClientKeyExchange (ssl.context);
			ckx.Process ();
			byte [] bytes = ckx.EncodeMessage ();
			ckx.Update ();
			ms.WriteByte ((byte) (bytes.Length / 0x100));
			ms.WriteByte ((byte) (bytes.Length % 0x100));
			ms.Write (bytes, 0, bytes.Length);

			WriteChangeCipherSpec (ms);

			WriteHandshake (ms);

			// FIXME: probably encrypted something goes here,
			// but dunno what it is.
			ms.WriteByte (0); // size-upper
			ms.WriteByte (0x20); // size-lower
			bytes = new byte [0x20];
			ms.Write (bytes, 0, bytes.Length);

			return ms.ToArray ();
		}
	}
}
