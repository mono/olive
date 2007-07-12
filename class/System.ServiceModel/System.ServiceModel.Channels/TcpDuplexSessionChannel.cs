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
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel.Channels;

namespace System.ServiceModel.Channels
{
	internal class TcpDuplexSessionChannel : DuplexSessionChannelBase
	{
		TcpChannelFactory<IDuplexSessionChannel> channel_factory;
		TcpClient client;
		EndpointAddress local_address;
		EndpointAddress remote_address;
		IDuplexSession session;
		Uri via;
		
		public TcpDuplexSessionChannel (TcpChannelFactory<IDuplexSessionChannel> factory, 
		                                EndpointAddress address, Uri via) : base (factory)
		{
			channel_factory = factory;
			remote_address = address;
			this.via = via;
		}
		
		public MessageEncoder Encoder {
			get { return channel_factory.MessageEncoder; }
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
		
		public override IAsyncResult BeginSend (Message message, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		public override IAsyncResult BeginSend (Message message, TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		public override void EndSend (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}
		
		public override void Send (Message message)
		{
			MemoryStream ms = new MemoryStream ();
			BinaryFormatter bf = new BinaryFormatter ();
			
			try
			{				
				Encoder.WriteMessage (message, ms);

				/*
				bf.Serialize (ms, message);
				
				Byte[] data = ms.ToArray();
				
				Console.WriteLine (data);
				
				NetworkStream stream = client.GetStream ();
				
				stream.Write (data, 0, data.Length);
				
				ms.Close ();
				stream.Close ();
				*/
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		
		public override void Send (Message message, TimeSpan timeout)
		{
			throw new NotImplementedException ();
		}
		
		public override IAsyncResult BeginReceive (AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		public override IAsyncResult BeginReceive (TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		public override IAsyncResult BeginTryReceive (TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		public override IAsyncResult BeginWaitForMessage (TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}
		
		public override Message EndReceive (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}
		
		public override bool EndTryReceive (IAsyncResult result, out Message message)
		{
			throw new NotImplementedException ();
		}
		
		public override bool EndWaitForMessage (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}
		
		public override Message Receive ()
		{
			throw new NotImplementedException ();
		}
		
		public override Message Receive (TimeSpan timeout)
		{
			throw new NotImplementedException ();
		}
		
		public override bool TryReceive (TimeSpan timeout, out Message message)
		{
			throw new NotImplementedException ();
		}
		
		public override bool WaitForMessage (TimeSpan timeout)
		{
			throw new NotImplementedException ();
		}
		
		// CommunicationObject
		
		protected override void OnAbort ()
		{
			throw new NotImplementedException ();
		}

		protected override IAsyncResult OnBeginClose (TimeSpan timeout,
			AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		protected override IAsyncResult OnBeginOpen (TimeSpan timeout,
			AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		protected override void OnClose (TimeSpan timeout)
		{
			client.Close ();
		}
		
		protected override void OnEndClose (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}

		protected override void OnEndOpen (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}
		
		protected override void OnOpen (TimeSpan timeout)
		{
			client = new TcpClient (RemoteAddress.Uri.Host, 808);
			                        //RemoteAddress.Uri.Port);
			
			/*
			NetworkStream ns = client.GetStream ();
			
			ns.WriteByte (new Byte ());
			*/
		}
		
//		private EndpointAddress address;
//		private int max_headers;
//		private TcpChannelFactory<IDuplexSessionChannel> source;
//		private Uri via;
//		
//		public TcpDuplexSessionChannel (TcpChannelFactory<IDuplexSessionChannel> factory, EndpointAddress address, Uri via) : base (factory)
//		{
//			this.max_headers = 0x10000;
//			this.source = factory;
//			this.address = address;
//			this.via = via;
//		}
//		
//		public EndpointAddress RemoteAddress { 
//			get { return address; }
//		}
//		
//		public Uri Via { 
//			get { return via; }
//		}
//		
//		[MonoTODO]
//		public IAsyncResult BeginSend (Message message, AsyncCallback callback, object state)
//		{
//			base.ThrowIfDisposedOrNotOpen ();
//			
//			return null;
//		}
//		
//		[MonoTODO]
//		public IAsyncResult BeginSend (Message message, TimeSpan timeout, AsyncCallback callback, object state)
//		{
//			base.ThrowIfDisposedOrNotOpen ();
//			
//			return this.BeginSend ();
//		}
//		
//		[MonoTODO]
//		public void EndSend (IAsyncResult result)
//		{
//		}
//		
//		[MonoTODO]
//		public void Send (Message message)
//		{
//			Console.WriteLine ("Send() called!");
//		}
//		
//		[MonoTODO]
//		public void Send (Message message, TimeSpan timeout)
//		{
//			Send (message);
//		}
	}
}
