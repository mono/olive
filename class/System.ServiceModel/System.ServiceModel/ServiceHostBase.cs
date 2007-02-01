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
		ServiceAuthorizationBehavior svc_auth_behavior =
			new ServiceAuthorizationBehavior ();
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

		[MonoTODO]
		public ServiceAuthorizationBehavior Authorization {
			get { return svc_auth_behavior; }
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
					throw new InvalidOperationException ("Could not find base address "
						+ "that matches Scheme " + binding.Scheme + " for endpoint " + binding.Name);

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
			se.ListenUri = listenUri;
			Description.Endpoints.Add (se);
			return se;
		}

		[MonoTODO]
		protected virtual void ApplyConfiguration ()
		{
			throw new NotImplementedException ();
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
		}

		[MonoTODO]
		protected virtual void InitializeRuntime ()
		{
		}

		[MonoTODO]
		protected void LoadConfigurationSection (ServiceElement element)
		{
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
				// FIXME: there might be decent way to supply channel dispatcher to endpoint dispatcher
				cd.Attach (this);

				// Apply contract/operation behaviors.
				//EndpointDispatcher d = new EndpointDispatcher (se.Address,
				//	se.Contract.Name, se.Contract.Namespace);
				EndpointDispatcher d = cd.InternalEndpointDispatcher;

				foreach (IEndpointBehavior b in se.Behaviors)
					b.ApplyDispatchBehavior (se, d);

				DispatchRuntime db = d.DispatchRuntime;
				foreach (IContractBehavior b in se.Contract.Behaviors)
					b.ApplyDispatchBehavior (se.Contract, se, db);
				foreach (OperationDescription od in se.Contract.Operations) {
					if (!db.Operations.Contains (od.Name))
						PopulateDispatchOperation (db, od);
					foreach (IOperationBehavior ob in od.Behaviors)
						ob.ApplyDispatchBehavior (od, d.DispatchRuntime.Operations [od.Name]);
				}

				cd.Open ();
			}

			// FIXME: Apply service behaviors
			foreach (IServiceBehavior b in description.Behaviors)
				b.ApplyDispatchBehavior (description, this);
		}

		void PopulateDispatchOperation (DispatchRuntime db, OperationDescription od)
		{
			string reqA = null, resA = null;
			foreach (MessageDescription m in od.Messages) {
				if (m.Direction == MessageDirection.Input)
					reqA = m.Action;
				else
					resA = m.Action;
			}
			DispatchOperation o =
				od.IsOneWay ?
				new DispatchOperation (db, od.Name, reqA) :
				new DispatchOperation (db, od.Name, reqA, resA);
			bool has_void_reply = false;
			foreach (MessageDescription md in od.Messages) {
				if (md.Direction == MessageDirection.Input &&
				    md.Body.Parts.Count == 1 &&
				    md.Body.Parts [0].Type == typeof (Message))
					o.DeserializeRequest = false;
				if (md.Direction == MessageDirection.Output &&
				    md.Body.ReturnValue != null) {
					if (md.Body.ReturnValue.Type == typeof (Message))
						o.SerializeReply = false;
					else if (md.Body.ReturnValue.Type == typeof (void))
						has_void_reply = true;
				}
			}

			if (o.Action == "*" && o.ReplyAction == "*") {
				//Signature : Message  (Message)
				//	    : void  (Message)
				//FIXME: void (IChannel)
				if (!o.DeserializeRequest && (!o.SerializeReply || has_void_reply))
					db.UnhandledDispatchOperation = o;
			}

			db.Operations.Add (o);
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
			return null;
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
