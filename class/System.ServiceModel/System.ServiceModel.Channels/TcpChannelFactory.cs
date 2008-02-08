// 
// TcpChannelFactory.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;

namespace System.ServiceModel.Channels
{
	internal class TcpChannelFactory<TChannel> : ChannelFactoryBase<TChannel>
	{
		// not sure if they are required.
		TcpTransportBindingElement source;
		MessageEncoder encoder;

		[MonoTODO]
		public TcpChannelFactory (TcpTransportBindingElement source, BindingContext ctx)
		{
			this.source = source;
			foreach (BindingElement be in ctx.RemainingBindingElements) {
				MessageEncodingBindingElement mbe = be as MessageEncodingBindingElement;
				if (mbe != null) {
					encoder = mbe.CreateMessageEncoderFactory ().Encoder;
					break;
				}
			}
			if (encoder == null)
				encoder = new TextMessageEncoder (MessageVersion.Default, Encoding.UTF8);
		}

		public MessageEncoder MessageEncoder {
			get { return encoder; }
		}

		[MonoTODO]
		protected override TChannel OnCreateChannel (
			EndpointAddress address, Uri via)
		{			
			ThrowIfDisposedOrNotOpen ();

			if (source.Scheme != address.Uri.Scheme)
				throw new ArgumentException (String.Format ("Argument EndpointAddress has unsupported URI scheme: {0}", address.Uri.Scheme));

			Type t = typeof (TChannel);
			
			if (t == typeof (IDuplexSessionChannel))
				return (TChannel) (object) new TcpDuplexSessionChannel ((TcpChannelFactory<IDuplexSessionChannel>) (object) this, address, via);
			
			throw new InvalidOperationException (String.Format ("Channel type {0} is not supported.", typeof (TChannel).Name));
		}

		[MonoTODO]
		protected override IAsyncResult OnBeginOpen (TimeSpan timeout,
			AsyncCallback callback, object state)
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
		}
	}
}
