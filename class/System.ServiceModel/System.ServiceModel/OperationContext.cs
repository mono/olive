//
// OperationContext.cs
//
// Author: Atsushi Enomoto (atsushi@ximian.com)
//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
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

namespace System.ServiceModel
{
	public sealed class OperationContext : IExtensibleObject<OperationContext>
	{
		public static OperationContext Current {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		ServiceHostBase host;
		EndpointDispatcher dispatcher;
		IContextChannel channel;
		RequestContext request_ctx;

		public OperationContext (IContextChannel channel)
		{
			this.channel = channel;
		}

		internal OperationContext (ServiceHostBase host)
		{
			this.host = host;
		}

		public event EventHandler OperationCompleted;

		public IContextChannel Channel {
			get { return channel; }
		}

		public EndpointDispatcher EndpointDispatcher {
			get { return dispatcher; }
			set { dispatcher = value; }
		}

		[MonoTODO]
		public IExtensionCollection<OperationContext> Extensions {
			get { throw new NotImplementedException (); }
		}

		public bool HasSupportingTokens {
			get { return SupportingTokens.Count > 0; }
		}

		public ServiceHostBase Host {
			get { return host; }
		}

		[MonoTODO]
		public MessageHeaders IncomingMessageHeaders {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public MessageProperties IncomingMessageProperties {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public MessageVersion IncomingMessageVersion {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public InstanceContext InstanceContext {
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
			get { return IncomingMessageProperties.Security.ServiceSecurityContext; }
		}

		[MonoTODO]
		public string SessionId {
			get { throw new NotImplementedException (); }
		}

		public ICollection<SupportingTokenSpecification> SupportingTokens {
			get { return IncomingMessageProperties.Security.IncomingSupportingTokens; }
		}

		[MonoTODO]
		public T GetCallbackChannel<T> ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void SetTransactionComplete ()
		{
			throw new NotImplementedException ();
		}
	}
}
