//
// ChannelFactory.cs
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
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace System.ServiceModel
{
	[MonoTODO ("Actually it should work like existing ClientBase minus the impact of proxying. Separate TChannel from IChannel")]
	public abstract class ChannelFactory : CommunicationObject,
		IChannelFactory, ICommunicationObject, IDisposable
	{
		// instance members

		ServiceEndpoint service_endpoint;

		protected ChannelFactory ()
		{
		}

		public ServiceEndpoint Endpoint {
			get { return service_endpoint; }
		}

		public ClientCredentials Credentials {
			get { return Endpoint.Behaviors.Find<ClientCredentials> (); }
		}

		protected internal override TimeSpan DefaultCloseTimeout {
			get { return Endpoint.Binding.CloseTimeout; }
		}

		protected internal override TimeSpan DefaultOpenTimeout {
			get { return Endpoint.Binding.OpenTimeout; }
		}

		[MonoTODO]
		protected virtual void ApplyConfiguration (
			string endpointConfigurationName)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected virtual IChannelFactory CreateFactory ()
		{
			throw new NotImplementedException ();
		}

		protected abstract ServiceEndpoint CreateDescription ();

		void IDisposable.Dispose ()
		{
			Close ();
		}

		[MonoTODO]
		public T GetProperty<T> () where T : class
		{
			throw new NotImplementedException ();
		}

		protected void EnsureOpened ()
		{
			if (State != CommunicationState.Opened)
				Open ();
		}

		[MonoTODO]
		protected void InitializeEndpoint (
			string endpointConfigurationName,
			EndpointAddress remoteAddress)
		{
			ApplyConfiguration (endpointConfigurationName);
		}

		protected void InitializeEndpoint (Binding binding,
			EndpointAddress remoteAddress)
		{
			// MS BUG: Under this contructor ContractDescription holds crappy type info.
			InitializeEndpoint (new ServiceEndpoint (
				ContractDescription.GetContract (typeof (UninitializedContract)),
				binding, remoteAddress));
		}

		[MonoTODO]
		protected void InitializeEndpoint (ServiceEndpoint endpoint)
		{
			service_endpoint = endpoint;
		}

		[MonoTODO]
		protected override void OnAbort ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override IAsyncResult OnBeginClose (
			TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override IAsyncResult OnBeginOpen (
			TimeSpan timeout, AsyncCallback callback, object state)
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
		protected override void OnClose (TimeSpan timeout)
		{
		}

		[MonoTODO]
		protected override void OnOpen (TimeSpan timeout)
		{
		}

		[MonoTODO]
		protected override void OnOpening ()
		{
		}

		[MonoTODO]
		protected override void OnOpened ()
		{
		}
	}

	[ServiceContract]
	interface UninitializedContract
	{
		[OperationContract]
		void ItShouldReallyGone ();
	}
}