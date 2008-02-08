// 
// TcpChannelListener.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel.Description;
using System.Text;

namespace System.ServiceModel.Channels
{
	internal class TcpChannelListener<TChannel> : ChannelListenerBase<TChannel> 
		where TChannel : class, IChannel
	{
		List<IChannel> channels = new List<IChannel> ();
		BindingContext context;
		MessageEncoder encoder;
		Stream s;
		IDuplexSession session;		
		TcpTransportBindingElement source;
		Uri listen_uri;
		TcpListener tcp_listener;
		
		[MonoTODO]
		public TcpChannelListener (TcpTransportBindingElement source, 
		                           BindingContext context) : base (context.Binding)
		{
			this.source = source;
			
			if (context.ListenUriMode == ListenUriMode.Explicit)
				listen_uri =
					context.ListenUriRelativeAddress != null ?
					new Uri (context.ListenUriBaseAddress, context.ListenUriRelativeAddress) :
					context.ListenUriBaseAddress;
			else
				throw new NotImplementedException ();
			
			foreach (BindingElement be in context.RemainingBindingElements) {
				MessageEncodingBindingElement mbe = be as MessageEncodingBindingElement;
				if (mbe != null) {
					encoder = mbe.CreateMessageEncoderFactory ().Encoder;
					break;
				}
			}
			
			if (encoder == null)
				encoder = new BinaryMessageEncoder ();
		}
		
		public MessageEncoder MessageEncoder {
			get { return encoder; }
		}
		
		public Stream ClientStream {
			get { return s; }
		}

		public override Uri Uri {
			get { return listen_uri; }
		}
		
		[MonoTODO]
		protected override TChannel OnAcceptChannel (TimeSpan timeout)
		{
			TcpClient cli = tcp_listener.AcceptTcpClient ();
			s = cli.GetStream ();

			//while (s.CanRead)
			//	Console.Write ("{0:X02} ", s.ReadByte ());
			
			for (int i = 0; i < 6; i++)
				s.ReadByte ();
			
			int size = s.ReadByte ();
			
			for (int i = 0; i < size; i++)
				s.ReadByte (); // URI
			
			s.ReadByte ();
			s.ReadByte ();
			s.ReadByte ();
			s.WriteByte (0x0B);
			TChannel channel = PopulateChannel (timeout);			
			channels.Add (channel);
			
			return channel;
		}
		
		TChannel PopulateChannel (TimeSpan timeout)
		{
			if (typeof (TChannel) == typeof (IDuplexSessionChannel))
				return (TChannel) (object) new TcpDuplexSessionChannel (
					(TcpChannelListener<IDuplexSessionChannel>) (object) this, timeout);

			// FIXME: To implement more.
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override IAsyncResult OnBeginAcceptChannel (TimeSpan timeout,
			AsyncCallback callback, object asyncState)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override TChannel OnEndAcceptChannel (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		protected override IAsyncResult OnBeginWaitForChannel (
			TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override bool OnEndWaitForChannel (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override bool OnWaitForChannel (TimeSpan timeout)
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
			tcp_listener.Stop ();
			tcp_listener = null;
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
			IPHostEntry entry = Dns.GetHostEntry (listen_uri.Host);
			
			if (entry.AddressList.Length ==0)
				throw new ArgumentException (String.Format ("Invalid listen URI: {0}", listen_uri));
			
			int explicitPort = listen_uri.Port;
			tcp_listener = new TcpListener (entry.AddressList [0], explicitPort <= 0 ? TcpTransportBindingElement.DefaultPort : explicitPort);
			tcp_listener.Start ();
		}
	}
}
