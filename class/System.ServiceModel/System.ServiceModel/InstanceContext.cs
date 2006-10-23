//
// InstanceContext.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005-2006 Novell, Inc.  http://www.novell.com
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
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace System.ServiceModel
{
	[MonoTODO]
	public sealed class InstanceContext : CommunicationObject,
		IExtensibleObject<InstanceContext>
	{
		ServiceHostBase host;
		object implementation;
		int manual_flow_limit;

		public InstanceContext (object implementation)
			: this (null, implementation)
		{
		}

		public InstanceContext (ServiceHostBase host)
			: this (host, null)
		{
		}

		public InstanceContext (ServiceHostBase host,
			object implementation)
		{
			this.host = host;
			this.implementation = implementation;
		}

		protected internal override TimeSpan DefaultCloseTimeout {
			get { return host.DefaultCloseTimeout; }
		}

		protected internal override TimeSpan DefaultOpenTimeout {
			get { return host.DefaultOpenTimeout; }
		}

		public IExtensionCollection<InstanceContext> Extensions {
			get { throw new NotImplementedException (); }
		}

		public ServiceHostBase Host {
			get { return host; }
		}

		public ICollection<IChannel> IncomingChannels {
			get { throw new NotImplementedException (); }
		}

		public int ManualFlowControlLimit {
			get { return manual_flow_limit; }
			set { manual_flow_limit = value; }
		}

		public ICollection<IChannel> OutgoingChannels {
			get { throw new NotImplementedException (); }
		}

		public object GetServiceInstance ()
		{
			return implementation;
		}

		public object GetServiceInstance (Message message)
		{
			throw new NotImplementedException ();
		}

		public void IncrementManualFlowControlLimit (int incrementBy)
		{
			throw new NotImplementedException ();
		}

		public void ReleaseServiceInstance ()
		{
			throw new NotImplementedException ();
		}

		protected override void OnAbort ()
		{
		}

		protected override void OnClosed ()
		{
		}

		protected override void OnOpened ()
		{
		}

		protected override IAsyncResult OnBeginOpen (
			TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		protected override void OnEndOpen (IAsyncResult result)
		{
		}

		protected override void OnOpen (TimeSpan timeout)
		{
		}

		protected override IAsyncResult OnBeginClose (
			TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		protected override void OnEndClose (IAsyncResult result)
		{
		}

		protected override void OnClose (TimeSpan timeout)
		{
		}
	}
}
