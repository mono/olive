//
// OperationContext.cs
//
// Author: Atsushi Enomoto (atsushi@ximian.com)
//
// Copyright (C) 2005,2007 Novell, Inc (http://www.novell.com)
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
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;
using System.Threading;

namespace System.ServiceModel
{
	public sealed class OperationContext : IExtensibleObject<OperationContext>
	{
		// generated guid (no special meaning)
		const string operation_context_name = "c15795e2-bb44-4cfb-a89c-8529feb170cb";

		public static OperationContext Current {
			get { return Thread.GetData (Thread.GetNamedDataSlot (operation_context_name)) as OperationContext; }
			set { Thread.SetData (Thread.GetNamedDataSlot (operation_context_name), value); }
		}

		EndpointDispatcher dispatcher;
		IContextChannel channel;
		RequestContext request_ctx;
		ExtensionCollection<OperationContext> extensions;

		public OperationContext (IContextChannel channel)
		{
			if (channel == null)
				throw new ArgumentNullException ("channel");
			this.channel = channel;
		}

		public event EventHandler OperationCompleted;

		public IContextChannel Channel {
			get { return channel; }
		}

		public EndpointDispatcher EndpointDispatcher {
			get { return dispatcher; }
			set { dispatcher = value; }
		}

		public IExtensionCollection<OperationContext> Extensions {
			get {
				if (extensions == null)
					extensions = new ExtensionCollection<OperationContext> (this);
				return extensions;
			}
		}

		public bool HasSupportingTokens {
			get { return SupportingTokens != null ? SupportingTokens.Count > 0 : false; }
		}

		public ServiceHostBase Host {
			get { return dispatcher != null ? dispatcher.ChannelDispatcher.Host : null; }
		}

		public MessageHeaders IncomingMessageHeaders {
			get { return request_ctx != null ? request_ctx.RequestMessage.Headers : null; }
		}

		public MessageProperties IncomingMessageProperties {
			get { return request_ctx != null ? request_ctx.RequestMessage.Properties : null; }
		}

		public MessageVersion IncomingMessageVersion {
			get { return request_ctx != null ? request_ctx.RequestMessage.Version : null; }
		}

		[MonoTODO]
		public InstanceContext InstanceContext {
			get {
				if (EndpointDispatcher == null)
					return null;
				IInstanceContextProvider p = EndpointDispatcher.DispatchRuntime.InstanceContextProvider;
				InstanceContext i = p.GetExistingInstanceContext (request_ctx.RequestMessage, channel);
				// FIXME: I guess GetExistingInstanceContext()
				// subsequently creates a new InstanceContext,
				// but it is documented as possible to return
				// null, while InitializeInstanceContext() is
				// documented as subsequently invoked when there
				// is no existing instance.
				if (i == null) {
					// FIXME: consider ServiceThrottle.
					// FIXME: is there no way to pass service instance?
					i = new InstanceContext (Host);
					p.InitializeInstanceContext (i, request_ctx.RequestMessage, channel);

					// There is no public way to set
					// instance to the provider...
					throw new NotImplementedException ();
				}
				return i;
			}
		}

		[MonoTODO]
		public bool IsUserContext {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public MessageHeaders OutgoingMessageHeaders {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public MessageProperties OutgoingMessageProperties {
			get { throw new NotImplementedException (); }
		}

		public RequestContext RequestContext {
			get { return request_ctx; }
			set { request_ctx = value; }
		}

		public ServiceSecurityContext ServiceSecurityContext {
			get { return IncomingMessageProperties != null ? IncomingMessageProperties.Security.ServiceSecurityContext : null; }
		}

		[MonoTODO]
		public string SessionId {
			get { throw new NotImplementedException (); }
		}

		public ICollection<SupportingTokenSpecification> SupportingTokens {
			get { return IncomingMessageProperties != null ? IncomingMessageProperties.Security.IncomingSupportingTokens : null; }
		}

		public T GetCallbackChannel<T> ()
		{
			if (!(channel is IDuplexContextChannel))
				return default (T);
			IDuplexContextChannel duplex = (IDuplexContextChannel) channel;
			foreach (IChannel ch in duplex.CallbackInstance.IncomingChannels)
				if (typeof (T).IsAssignableFrom (ch.GetType ()))
					return (T) (object) ch;
			foreach (IChannel ch in duplex.CallbackInstance.OutgoingChannels)
				if (typeof (T).IsAssignableFrom (ch.GetType ()))
					return (T) (object) ch;
			return default (T);
		}

		[MonoTODO]
		public void SetTransactionComplete ()
		{
			throw new NotImplementedException ();
		}
	}
}
