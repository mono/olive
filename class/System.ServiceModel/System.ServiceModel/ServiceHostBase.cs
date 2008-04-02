//
// ServiceHostBase.cs
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
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;

namespace System.ServiceModel
{
	public abstract class ServiceHostBase
		: CommunicationObject, IExtensibleObject<ServiceHostBase>, IDisposable
	{
		ServiceCredentials credentials;
		ServiceDescription description;
		UriSchemeKeyedCollection base_addresses;
		TimeSpan open_timeout, close_timeout, instance_idle_timeout;
		ServiceThrottle throttle;
		List<InstanceContext> contexts;
		ReadOnlyCollection<InstanceContext> exposed_contexts;
		ChannelDispatcherCollection channel_dispatchers;
		IDictionary<string,ContractDescription> contracts;
		int flow_limit = int.MaxValue;
		IExtensionCollection<ServiceHostBase> extensions;

		protected ServiceHostBase ()
		{
			open_timeout = DefaultOpenTimeout;
			close_timeout = DefaultCloseTimeout;

			credentials = new ServiceCredentials ();
			throttle = new ServiceThrottle ();
			contexts = new List<InstanceContext> ();
			exposed_contexts = new ReadOnlyCollection<InstanceContext> (contexts);
			channel_dispatchers = new ChannelDispatcherCollection ();
		}

		public event EventHandler<UnknownMessageReceivedEventArgs>
			UnknownMessageReceived;

		public ReadOnlyCollection<Uri> BaseAddresses {
			get { return new ReadOnlyCollection<Uri> (base_addresses.InternalItems); }
		}

		[MonoTODO]
		public ChannelDispatcherCollection ChannelDispatchers {
			get { return channel_dispatchers; }
		}

		public ServiceAuthorizationBehavior Authorization {
			get;
			private set;
		}

		[MonoTODO]
		public ServiceCredentials Credentials {
			get { return credentials; }
		}

		public ServiceDescription Description {
			get { return description; }
		}

		protected IDictionary<string,ContractDescription> ImplementedContracts {
			get { return contracts; }
		}

		[MonoTODO]
		public IExtensionCollection<ServiceHostBase> Extensions {
			get {
				if (extensions == null)
					extensions = new ExtensionCollection<ServiceHostBase> (this);
				return extensions;
			}
		}

		protected internal override TimeSpan DefaultCloseTimeout {
			get { return DefaultCommunicationTimeouts.Instance.CloseTimeout; }
		}

		protected internal override TimeSpan DefaultOpenTimeout {
			get { return DefaultCommunicationTimeouts.Instance.OpenTimeout; }
		}

		public TimeSpan CloseTimeout {
			get { return close_timeout; }
			set { close_timeout = value; }
		}

		public TimeSpan OpenTimeout {
			get { return open_timeout; }
			set { open_timeout = value; }
		}

		public int ManualFlowControlLimit {
			get { return flow_limit; }
			set { flow_limit = value; }
		}

		public ServiceEndpoint AddServiceEndpoint (
			string implementedContract, Binding binding, string address)
		{
			return AddServiceEndpoint (implementedContract,
				binding,
				new Uri (address, UriKind.RelativeOrAbsolute));
		}

		[MonoTODO]
		public ServiceEndpoint AddServiceEndpoint (
			string implementedContract, Binding binding,
			string address, Uri listenUri)
		{
			Uri uri = new Uri (address, UriKind.RelativeOrAbsolute);
			return AddServiceEndpoint (
				implementedContract, binding, uri, uri);
		}

		[MonoTODO]
		public ServiceEndpoint AddServiceEndpoint (
			string implementedContract, Binding binding,
			Uri address)
		{
			return AddServiceEndpoint (implementedContract, binding, address, address);
		}

		[MonoTODO]
		public ServiceEndpoint AddServiceEndpoint (
			string implementedContract, Binding binding,
			Uri address, Uri listenUri)
		{
			EndpointAddress ea = BuildEndpointAddress (address, binding);
			ContractDescription cd = GetContract (implementedContract);
			if (cd == null)
				throw new InvalidOperationException (String.Format ("Contract '{0}' was not found in the implemented contracts in this service host.", implementedContract));
			return AddServiceEndpointCore (cd, binding, ea, listenUri);
		}

		Type PopulateType (string typeName)
		{
			Type type = Type.GetType (typeName);
			if (type != null)
				return type;
			foreach (ContractDescription cd in ImplementedContracts.Values) {
				type = cd.ContractType.Assembly.GetType (typeName);
				if (type != null)
					return type;
			}
			return null;
		}

		ContractDescription GetContract (string typeName)
		{
			//FIXME: hack hack hack
			ImplementedContracts [ServiceMetadataBehavior.HttpGetWsdlContractName] =
				ContractDescription.GetContract (typeof (HttpGetWsdl));

			// FIXME: As long as I tried, *only* IMetadataExchange
			// is the exception case that does not require full
			// type name. Hence I treat it as a special case.
			if (typeName == ServiceMetadataBehavior.MexContractName) {
				if (!Description.Behaviors.Contains (typeof (ServiceMetadataBehavior)) && Array.IndexOf (Description.ServiceType.GetInterfaces (), typeof (IMetadataExchange)) < 0)
					throw new InvalidOperationException (
						"Add ServiceMetadataBehavior to the ServiceHost to add a endpoint for IMetadataExchange contract.");
					
				ImplementedContracts [ServiceMetadataBehavior.MexContractName] =
					ContractDescription.GetContract (typeof (IMetadataExchange));

				foreach (ContractDescription cd in ImplementedContracts.Values)
					if (cd.ContractType == typeof (IMetadataExchange))
						return cd;
				return null;
			}

			Type type = PopulateType (typeName);
			if (type == null)
				return null;

			foreach (ContractDescription cd in ImplementedContracts.Values) {
				// FIXME: This check is a negative side effect 
				// of the above hack.
				if (cd.ContractType == typeof (IMetadataExchange))
					continue;

				if (cd.ContractType == type ||
				    cd.ContractType.IsSubclassOf (type) ||
				    type.IsInterface && cd.ContractType.GetInterface (type.FullName) == type)
					return cd;
			}
			return null;
		}

		internal EndpointAddress BuildEndpointAddress (Uri address, Binding binding)
		{
			if (!address.IsAbsoluteUri) {
				// Find a Base address with matching scheme,
				// and build new absolute address
				if (!base_addresses.Contains (binding.Scheme))
					throw new InvalidOperationException (String.Format ("Could not find base address that matches Scheme {0} for endpoint {1}", binding.Scheme, binding.Name));

				Uri baseaddr = base_addresses [binding.Scheme];

				if (!baseaddr.AbsoluteUri.EndsWith ("/"))
					baseaddr = new Uri (baseaddr.AbsoluteUri + "/");
				address = new Uri (baseaddr, address);
			}
			return new EndpointAddress (address);
		}

		internal ServiceEndpoint AddServiceEndpointCore (
			ContractDescription cd, Binding binding, EndpointAddress address, Uri listenUri)
		{
			foreach (ServiceEndpoint e in Description.Endpoints)
				if (e.Contract == cd)
					return e;
			ServiceEndpoint se = new ServiceEndpoint (cd, binding, address);
			se.ListenUri = listenUri.IsAbsoluteUri ? listenUri : new Uri (address.Uri, listenUri);
			Description.Endpoints.Add (se);
			return se;
		}

		[MonoTODO]
		protected virtual void ApplyConfiguration ()
		{
			foreach (ServiceElement service in ConfigUtil.ServicesSection.Services) {

				//base addresses
				HostElement host = service.Host;
				foreach (BaseAddressElement baseAddress in host.BaseAddresses) {
					this.base_addresses.Add (new Uri (baseAddress.BaseAddress));
				}

				// services
				foreach (ServiceEndpointElement endpoint in service.Endpoints) {
					// FIXME: consider BindingName as well
					ServiceEndpoint se = AddServiceEndpoint (
						endpoint.Contract,
						ConfigUtil.CreateBinding (endpoint.Binding, endpoint.BindingConfiguration),
						endpoint.Address.ToString ());
				}
				// behaviors
				ServiceBehaviorElement behavior = ConfigUtil.BehaviorsSection.ServiceBehaviors.Find (service.BehaviorConfiguration);
				if (behavior != null) {
					foreach (BehaviorExtensionElement bxel in behavior) {
						IServiceBehavior b = null;
						ServiceMetadataPublishingElement meta = bxel as ServiceMetadataPublishingElement;
						if (meta != null) {
							ServiceMetadataBehavior smb = meta.CreateBehavior () as ServiceMetadataBehavior;
							smb.HttpGetUrl = null;
							b = smb;
						}
						if (b != null)
							Description.Behaviors.Add (b);
					}
				}
			}

			// TODO: consider commonBehaviors here

			// ensure ServiceAuthorizationBehavior
			Authorization = Description.Behaviors.Find<ServiceAuthorizationBehavior> ();
			if (Authorization == null) {
				Authorization = new ServiceAuthorizationBehavior ();
				Description.Behaviors.Add (Authorization);
			}

			// ensure ServiceDebugBehavior
			ServiceDebugBehavior debugBehavior = Description.Behaviors.Find<ServiceDebugBehavior> ();
			if (debugBehavior == null) {
				debugBehavior = new ServiceDebugBehavior ();
				Description.Behaviors.Add (debugBehavior);
			}
		}

		internal ContractDescription GetContract (string name, string ns)
		{
			foreach (ContractDescription d in ImplementedContracts.Values)
				if (d.Name == name && d.Namespace == ns)
					return d;
			return null;
		}

		protected abstract ServiceDescription CreateDescription (
			out IDictionary<string,ContractDescription> implementedContracts);

		[MonoTODO]
		protected void InitializeDescription (UriSchemeKeyedCollection baseAddresses)
		{
			this.base_addresses = baseAddresses;
			IDictionary<string,ContractDescription> retContracts;
			description = CreateDescription (out retContracts);
			contracts = retContracts;

			ApplyConfiguration ();
		}

		[MonoTODO]
		protected virtual void InitializeRuntime ()
		{
		}

		[MonoTODO]
		protected void LoadConfigurationSection (ServiceElement element)
		{
			ServicesSection services = ConfigUtil.ServicesSection;
		}

		void DoOpen (TimeSpan timeout)
		{
			BindingParameterCollection commonParams =
				new BindingParameterCollection ();

			foreach (IServiceBehavior b in Description.Behaviors)
				b.AddBindingParameters (
					Description,
					this,
					Description.Endpoints,
					commonParams);

			// create endpoint listeners
			foreach (ServiceEndpoint se in Description.Endpoints) {
				// Apply service behaviors and
				// Build IChannelListener
				BindingParameterCollection parameters =
					new BindingParameterCollection ();
				foreach (object p in commonParams)
					parameters.Add (p);

				parameters.Add (ChannelProtectionRequirements.CreateFromContract (se.Contract));

				foreach (IEndpointBehavior b in se.Behaviors)
					b.AddBindingParameters (se, parameters);
				foreach (IContractBehavior b in se.Contract.Behaviors)
					b.AddBindingParameters (se.Contract, se, parameters);

				IChannelListener lf = BuildListener (se, parameters);

				ChannelDispatcher cd = new ChannelDispatcher (
					lf, se.Binding.Name);
				cd.MessageVersion = se.Binding.MessageVersion;
				if (cd.MessageVersion == null)
					cd.MessageVersion = MessageVersion.Default;
				cd.Attach (this);
				cd.Open ();
			}

			foreach (IServiceBehavior b in description.Behaviors)
				b.ApplyDispatchBehavior (description, this);
		}

		IChannelListener BuildListener (ServiceEndpoint se,
			BindingParameterCollection pl)
		{
			Binding b = se.Binding;
			if (b.CanBuildChannelListener<IReplySessionChannel> (pl))
				return b.BuildChannelListener<IReplySessionChannel> (se.ListenUri, "", se.ListenUriMode, pl);
			if (b.CanBuildChannelListener<IReplyChannel> (pl))
				return b.BuildChannelListener<IReplyChannel> (se.ListenUri, "", se.ListenUriMode, pl);
			if (b.CanBuildChannelListener<IInputSessionChannel> (pl))
				return b.BuildChannelListener<IInputSessionChannel> (se.ListenUri, "", se.ListenUriMode, pl);
			if (b.CanBuildChannelListener<IInputChannel> (pl))
				return b.BuildChannelListener<IInputChannel> (se.ListenUri, "", se.ListenUriMode, pl);
			throw new InvalidOperationException ("None of the listener channel types is supported");
		}

		[MonoTODO]
		protected override sealed void OnAbort ()
		{
		}

		[MonoTODO]
		protected override sealed IAsyncResult OnBeginClose (
			TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override sealed IAsyncResult OnBeginOpen (
			TimeSpan timeout, AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override void OnClose (TimeSpan timeout)
		{
			ReleasePerformanceCounters ();
			List<ChannelDispatcherBase> l = new List<ChannelDispatcherBase> (ChannelDispatchers);
			foreach (ChannelDispatcherBase e in l)
				e.Close ();
		}

		protected override sealed void OnOpen (TimeSpan timeout)
		{
			InitializeRuntime ();
			DoOpen (timeout);
		}

		[MonoTODO]
		protected override void OnEndClose (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override sealed void OnEndOpen (IAsyncResult result)
		{
			throw new NotImplementedException ();
		}

		protected override void OnOpened ()
		{
		}

		[MonoTODO]
		protected void ReleasePerformanceCounters ()
		{
		}

		void IDisposable.Dispose ()
		{
			Close ();
		}
	}
}
