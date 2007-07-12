// 
// TcpChannelListener.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System;

namespace System.ServiceModel.Channels
{
	internal class TcpChannelListener<TChannel> : ChannelListenerBase<TChannel> 
		where TChannel : class, IChannel
	{
		MessageEncoder encoder;
		EndpointAddress local_address;
		EndpointAddress remote_address;
		IDuplexSession session;		
		TcpTransportBindingElement source;
		Uri via;
		
		[MonoTODO]
		public TcpChannelListener (TcpTransportBindingElement source, 
		                           BindingContext context) : base (context.Binding)
		{
			throw new NotImplementedException ();
		}
		
		public MessageEncoder Encoder {
			get { return encoder; }
		}
		
		public override Uri Uri {
			get { return via; }
		}
		
		[MonoTODO]
		protected override TChannel OnAcceptChannel (TimeSpan timeout)
		{
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
			throw new NotImplementedException ();
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
			throw new NotImplementedException ();
		}
	}
}
