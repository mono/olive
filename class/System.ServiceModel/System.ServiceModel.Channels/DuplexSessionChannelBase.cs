// 
// DuplexSessionChannelBase.cs
// 
// Author:
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System;
using System.ServiceModel.Channels;

namespace System.ServiceModel.Channels
{
	internal abstract class DuplexSessionChannelBase : ChannelBase, IDuplexSessionChannel
	{
		ChannelFactoryBase channel_factory_base;
		EndpointAddress local_address;
		EndpointAddress remote_address;
		IDuplexSession session;
		Uri via;
		
		public DuplexSessionChannelBase (ChannelFactoryBase factory) : base (factory)
		{
			channel_factory_base = factory;
		}

		public abstract EndpointAddress LocalAddress { get; }
		
		public abstract EndpointAddress RemoteAddress { get; }
		
		public abstract IDuplexSession Session { get; }
		
		public abstract Uri Via { get; }
		
		public abstract IAsyncResult BeginSend (Message message, AsyncCallback callback, object state);
		
		public abstract IAsyncResult BeginSend (Message message, TimeSpan timeout, AsyncCallback callback, object state);
		
		public abstract void EndSend (IAsyncResult result);
		
		public abstract void Send (Message message);
		
		public abstract void Send (Message message, TimeSpan timeout);
		
		public abstract IAsyncResult BeginReceive (AsyncCallback callback, object state);
		
		public abstract IAsyncResult BeginReceive (TimeSpan timeout, AsyncCallback callback, object state);
		
		public abstract IAsyncResult BeginTryReceive (TimeSpan timeout, AsyncCallback callback, object state);
		
		public abstract IAsyncResult BeginWaitForMessage (TimeSpan timeout, AsyncCallback callback, object state);
		
		public abstract Message EndReceive (IAsyncResult result);
		
		public abstract bool EndTryReceive (IAsyncResult result, out Message message);
		
		public abstract bool EndWaitForMessage (IAsyncResult result);
		
		public abstract Message Receive ();
		
		public abstract Message Receive (TimeSpan timeout);
		
		public abstract bool TryReceive (TimeSpan timeout, out Message message);
		
		public abstract bool WaitForMessage (TimeSpan timeout);
	}
}
