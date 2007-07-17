// 
// TcpDuplexSessionChannel.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel.Channels;

namespace System.ServiceModel.Channels
{
	internal class TcpDuplexSessionChannel : DuplexSessionChannelBase
	{
		TcpChannelFactory<IDuplexSessionChannel> channel_factory;
		TcpChannelListener<IDuplexSessionChannel> channel_listener;
		TcpClient client;
		EndpointAddress local_address;
		EndpointAddress remote_address;
		IDuplexSession session;
		TcpListener tcp_listener;
		TimeSpan timeout;
		Uri via;
		
		public TcpDuplexSessionChannel (TcpChannelFactory<IDuplexSessionChannel> factory, 
		                                EndpointAddress address, Uri via) : base (factory)
		{
			channel_factory = factory;
			remote_address = address;
			this.via = via;
		}
		
		public TcpDuplexSessionChannel (TcpChannelListener<IDuplexSessionChannel> listener, 
		                                TimeSpan timeout) : base (listener)
		{
			channel_listener = listener;
			this.timeout = timeout;
		}
		
		public MessageEncoder Encoder {
			get {
				// Client side.
				if (channel_factory != null)
					return channel_factory.MessageEncoder;
				// Service side.
				else
					return channel_listener.MessageEncoder;
			}
		}

		public override EndpointAddress LocalAddress {
			get { return local_address; }
		}
		
		public override EndpointAddress RemoteAddress {
			get { return remote_address; }
		}
		
		public override IDuplexSession Session {
			get { return session; }
		}
		
		public override Uri Via {
			get { return via; }
		}
		
		[MonoTODO]
		public override IAsyncResult BeginSend (Message message, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override IAsyncResult BeginSend (Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override void EndSend (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void Send (Message message)
		{
			MemoryStream ms = new MemoryStream ();
			BinaryFormatter bf = new BinaryFormatter ();
			
			try
			{
				NetworkStream stream = client.GetStream ();
				MyBinaryWriter bw = new MyBinaryWriter (stream);
				bw.Write ((byte) 6);
				Encoder.WriteMessage (message, ms);
				bw.WriteBytes (ms.ToArray ());
				bw.Write ((byte) 7);
				bw.Flush ();

				stream.ReadByte (); // 7

				stream.Close ();
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		[MonoTODO]
		public override void Send (Message message, TimeSpan timeout)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override IAsyncResult BeginReceive (AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override IAsyncResult BeginReceive (TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override IAsyncResult BeginTryReceive (TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override IAsyncResult BeginWaitForMessage (TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override Message EndReceive (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override bool EndTryReceive (IAsyncResult result, out Message message)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override bool EndWaitForMessage (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override Message Receive ()
		{
			Stream s = channel_listener.ClientStream;
			
			s.ReadByte (); // 6
			BinaryReader br = new BinaryReader (s);
			string msg = br.ReadString ();
			
//			Message msg = null;
			
			// FIXME: To supply maxSizeOfHeaders.
//			msg = Encoder.ReadMessage (s, 0x10000);
			
			s.ReadByte (); // 7

			Console.WriteLine (msg);

			s.WriteByte (7);
			
			s.Close ();
			
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override Message Receive (TimeSpan timeout)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override bool TryReceive (TimeSpan timeout, out Message message)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override bool WaitForMessage (TimeSpan timeout)
		{
			throw new NotImplementedException ();
		}
		
		// CommunicationObject
		
		[MonoTODO]
		protected override void OnAbort ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override IAsyncResult OnBeginClose (TimeSpan timeout,
			AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override IAsyncResult OnBeginOpen (TimeSpan timeout,
			AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override void OnClose (TimeSpan timeout)
		{
			client.Close ();
		}
		
		[MonoTODO]
		protected override void OnEndClose (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override void OnEndOpen (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		protected override void OnOpen (TimeSpan timeout)
		{
			// Client side.
			if (RemoteAddress != null) {
				int explicitPort = RemoteAddress.Uri.Port;
				client = new TcpClient (RemoteAddress.Uri.Host, explicitPort <= 0 ? TcpTransportBindingElement.DefaultPort : explicitPort);
				                        //RemoteAddress.Uri.Port);
				
				NetworkStream ns = client.GetStream ();
				ns.WriteByte (0);
				ns.WriteByte (1);
				ns.WriteByte (0);
				ns.WriteByte (1);
				ns.WriteByte (2);
				ns.WriteByte (2);
				byte [] bytes = System.Text.Encoding.UTF8.GetBytes (RemoteAddress.Uri.ToString ());
				ns.WriteByte ((byte) bytes.Length);
				ns.Write (bytes, 0, bytes.Length);
				ns.WriteByte (3);
				ns.WriteByte (3);
				ns.WriteByte (0xC);
				int hoge = ns.ReadByte ();
				//while (ns.CanRead)
				//	Console.Write ("{0:X02} ", ns.ReadByte ());
			}
			// Service side.
			/*
			else
				Console.WriteLine ("Server side.");
			*/
		}
		
		class MyBinaryWriter : BinaryWriter
		{
			public MyBinaryWriter (Stream s)
				: base (s)
			{
			}
			public void WriteBytes (byte [] bytes)
			{
				Write7BitEncodedInt (bytes.Length);
				Write (bytes);
			}
		}
	}
}
