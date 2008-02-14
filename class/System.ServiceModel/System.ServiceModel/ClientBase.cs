//
// generic ClientBase.cs
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
using System.Configuration;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

using ConfigurationType = System.Configuration.Configuration;

namespace System.ServiceModel
{
	[MonoTODO ("It somehow rejects classes, but dunno how we can do that besides our code level.")]
	public abstract class ClientBase<TChannel>
		: IDisposable, ICommunicationObject
	{
		ChannelFactory<TChannel> factory;
		ClientRuntimeChannel inner_channel;
		CommunicationState state;

		protected ClientBase ()
			: this ((InstanceContext) null)
		{
		}

		protected ClientBase (string endpointConfigurationName)
			: this ((InstanceContext) null, endpointConfigurationName)
		{
		}

		protected ClientBase (Binding binding,
			EndpointAddress remoteAddress)
		{
			Initialize (null, binding, remoteAddress);
		}

		protected ClientBase (string configurationName,
			EndpointAddress remoteAddress)
		{
			Initialize (null,
				GetBindingFromConfig (configurationName),
				remoteAddress);
		}

		protected ClientBase (string configurationName,
			string remoteAddress)
		{
			if (remoteAddress == null)
				throw new ArgumentNullException ("endpointAddress");
			Initialize (null,
				GetBindingFromConfig (configurationName),
				new EndpointAddress (remoteAddress));
		}

		protected ClientBase (InstanceContext instance)
			: this (instance, String.Empty)
		{
		}

		protected ClientBase (InstanceContext instance,
			string endpointConfigurationName)
		{
			ChannelEndpointElement el = GetEndpointConfig (endpointConfigurationName);
			Initialize (null,
				ConfigUtil.CreateBinding (el.Binding, el.BindingConfiguration),
				new EndpointAddress (el.Address));
		}

		protected ClientBase (InstanceContext instance,
			string endpointConfigurationName,
			EndpointAddress remoteAddress)
		{
			Initialize (instance,
				GetBindingFromConfig (endpointConfigurationName),
				remoteAddress);
		}

		protected ClientBase (InstanceContext instance,
			string endpointConfigurationName, string remoteAddress)
		{
			if (remoteAddress == null)
				throw new ArgumentNullException ("endpointAddress");
			Initialize (instance,
				GetBindingFromConfig (endpointConfigurationName),
				new EndpointAddress (remoteAddress));
		}

		protected ClientBase (InstanceContext instance,
			Binding binding, EndpointAddress remoteAddress)
		{
			if (instance == null)
				throw new ArgumentNullException ("instance");
			Initialize (instance, binding, remoteAddress);
		}

		static ChannelEndpointElement GetEndpointConfig (string name)
		{
			if (name == null)
				throw new ArgumentNullException ("endpointConfigurationName");
//			ClientSection client = ConfigUtil.ExeConfig.Client;
			// FIXME: the above should work here.
			ClientSection client = (ClientSection) ConfigurationManager.GetSection ("system.serviceModel/client");
			foreach (ChannelEndpointElement el in client.Endpoints)
				if (el.Name == name || el.Name == null && name.Length == 0)
					return el;
			throw new ArgumentException (String.Format ("Client endpoint configuration '{0}' was not found in {1} endpoints.", name, client.Endpoints.Count));
		}

		static Binding GetBindingFromConfig (string endpointConfigurationName)
		{
			if (endpointConfigurationName == null)
				throw new ArgumentNullException ("endpointConfigurationName");
			ChannelEndpointElement el = GetEndpointConfig (endpointConfigurationName);
			return ConfigUtil.CreateBinding (el.Binding, el.BindingConfiguration);
		}

		void Initialize (InstanceContext instance,
			Binding binding, EndpointAddress remoteAddress)
		{
			if (binding == null)
				throw new ArgumentNullException ("binding");
			if (remoteAddress == null)
				throw new ArgumentNullException ("remoteAddress");

			factory = new ChannelFactory<TChannel> (binding, remoteAddress);
		}

		public ChannelFactory<TChannel> ChannelFactory {
			get { return factory; }
		}

		public ClientCredentials ClientCredentials {
			get { return ChannelFactory.Credentials; }
		}

		public ServiceEndpoint Endpoint {
			get { return factory.Endpoint; }
		}

		public IClientChannel InnerChannel {
			get {
				if (inner_channel == null)
					inner_channel = (ClientRuntimeChannel) (object) factory.CreateChannel ();
				return inner_channel;
			}
		}

		protected TChannel Channel {
			get { return (TChannel) (object) InnerChannel; }
		}

		public CommunicationState State {
			get { return InnerChannel.State; }
		}

		[MonoTODO]
		public void Abort ()
		{
			InnerChannel.Abort ();
		}

		[MonoTODO]
		public void Close ()
		{
			InnerChannel.Close ();
		}

		[MonoTODO]
		public void DisplayInitializationUI ()
		{
		}

		[MonoTODO]
		void IDisposable.Dispose ()
		{
			Close ();
		}

		protected virtual TChannel CreateChannel ()
		{
			return ChannelFactory.CreateChannel ();
		}

		public void Open ()
		{
			InnerChannel.Open ();
		}

		#region ICommunicationObject implementation

		[MonoTODO]
		IAsyncResult ICommunicationObject.BeginOpen (
			AsyncCallback callback, object state)
		{
			return InnerChannel.BeginOpen (callback, state);
		}

		[MonoTODO]
		IAsyncResult ICommunicationObject.BeginOpen (
			TimeSpan timeout, AsyncCallback callback, object state)
		{
			return InnerChannel.BeginOpen (timeout, callback, state);
		}

		[MonoTODO]
		void ICommunicationObject.EndOpen (IAsyncResult result)
		{
			InnerChannel.EndOpen (result);
		}

		[MonoTODO]
		IAsyncResult ICommunicationObject.BeginClose (
			AsyncCallback callback, object state)
		{
			return InnerChannel.BeginClose (callback, state);
		}

		[MonoTODO]
		IAsyncResult ICommunicationObject.BeginClose (
			TimeSpan timeout, AsyncCallback callback, object state)
		{
			return InnerChannel.BeginClose (timeout, callback, state);
		}

		[MonoTODO]
		void ICommunicationObject.EndClose (IAsyncResult result)
		{
			InnerChannel.EndClose (result);
		}

		[MonoTODO]
		void ICommunicationObject.Close (TimeSpan timeout)
		{
			InnerChannel.Close (timeout);
		}

		[MonoTODO]
		void ICommunicationObject.Open (TimeSpan timeout)
		{
			InnerChannel.Open (timeout);
		}

		event EventHandler ICommunicationObject.Opening {
			add { InnerChannel.Opening += value; }
			remove { InnerChannel.Opening -= value; }
		}
		event EventHandler ICommunicationObject.Opened {
			add { InnerChannel.Opened += value; }
			remove { InnerChannel.Opened -= value; }
		}
		event EventHandler ICommunicationObject.Closing {
			add { InnerChannel.Closing += value; }
			remove { InnerChannel.Closing -= value; }
		}
		event EventHandler ICommunicationObject.Closed {
			add { InnerChannel.Closed += value; }
			remove { InnerChannel.Closed -= value; }
		}
		event EventHandler ICommunicationObject.Faulted {
			add { InnerChannel.Faulted += value; }
			remove { InnerChannel.Faulted -= value; }
		}

		#endregion
	}
}
