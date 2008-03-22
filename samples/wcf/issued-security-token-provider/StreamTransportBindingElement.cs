//
// HttpTransportBindingElement.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005 Novell, Inc.  http://www.novell.com
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
using System.Net;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

	public class StreamTransportBindingElement : TransportBindingElement
	{
		MemoryStream stream;

		public StreamTransportBindingElement (MemoryStream stream)
		{
			this.stream = stream;
		}

		public override string Scheme {
			get { return "stream"; }
		}

		public override BindingElement Clone ()
		{
			return new StreamTransportBindingElement (
				new MemoryStream (stream.ToArray ()));
		}

		public override bool CanBuildChannelFactory<TChannel> (BindingContext context)
		{
			return typeof (TChannel) == typeof (IRequestChannel);
		}

		public override bool CanBuildChannelListener<TChannel> (BindingContext context)
		{
			return typeof (TChannel) == typeof (IReplyChannel);
		}

		public override IChannelFactory<TChannel> BuildChannelFactory<TChannel> (BindingContext context)
		{
			return new StreamTransportChannelFactory<TChannel> ();
		}
	}

	public class StreamTransportChannelFactory<TChannel> : ChannelFactoryBase<TChannel>
	{
		protected override TChannel OnCreateChannel (EndpointAddress address, Uri via)
		{
			if (typeof (TChannel) == typeof (IRequestChannel))
				return (TChannel) (object) new StreamTransportRequestChannel ((StreamTransportChannelFactory<IRequestChannel>) (object) this, address, via);

			throw new NotSupportedException ();
		}

		protected override IAsyncResult OnBeginOpen (TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotSupportedException ();
		}

		protected override void OnEndOpen (IAsyncResult result)
		{
			throw new NotSupportedException ();
		}

		protected override void OnOpen (TimeSpan timeout)
		{
			// do nothing
		}
	}

	public class StreamTransportRequestChannel : RequestChannelBase
	{
		StreamTransportChannelFactory<IRequestChannel> source;
		EndpointAddress address;
		Uri via;

		public StreamTransportRequestChannel (StreamTransportChannelFactory<IRequestChannel> source, EndpointAddress address, Uri via)
			: base (source)
		{
			this.source = source;
			this.address = address;
			this.via = via;
		}

		public override EndpointAddress RemoteAddress {
			get { return address; }
		}

		public override Uri Via {
			get { return via; }
		}

		public override Message Request (Message input, TimeSpan timeout)
		{
			throw new NotImplementedException ("Request");
		}

		public override IAsyncResult BeginRequest (Message input, TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ("BeginRequest");
		}

		public override Message EndRequest (IAsyncResult result)
		{
			throw new NotImplementedException ("EndRequest");
		}

		protected override void OnAbort ()
		{
			throw new NotImplementedException ("OnAbort");
		}

		protected override void OnOpen (TimeSpan timeout)
		{
			throw new NotImplementedException ("OnOpen");
		}

		protected override IAsyncResult OnBeginOpen (TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ("OnBeginOpen");
		}

		protected override void OnEndOpen (IAsyncResult result)
		{
			throw new NotImplementedException ("EndOpen");
		}

		protected override void OnClose (TimeSpan timeout)
		{
			throw new NotImplementedException ("Close");
		}

		protected override IAsyncResult OnBeginClose (TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ("OnBeginClose");
		}

		protected override void OnEndClose (IAsyncResult result)
		{
			throw new NotImplementedException ("OnEndClose");
		}
	}

