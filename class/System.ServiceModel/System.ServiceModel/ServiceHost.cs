//
// ServiceHost.cs
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

namespace System.ServiceModel
{
	public class ServiceHost : ServiceHostBase
	{
		Type service_type;
		object instance;
		Dictionary<string,ContractDescription> contracts;

		protected ServiceHost ()
		{
		}

		public ServiceHost (object serviceInstance,
			params Uri [] baseAddresses)
		{
			if (serviceInstance == null)
				throw new ArgumentNullException ("serviceInstance");
			InitializeDescription (serviceInstance,
				new UriSchemeKeyedCollection (baseAddresses));
		}

		public ServiceHost (Type serviceType,
			params Uri [] baseAddresses)
		{
			InitializeDescription (serviceType,
				new UriSchemeKeyedCollection (baseAddresses));
		}

		public object SingletonInstance {
			get { return instance; }
		}

		[MonoTODO]
		public ServiceEndpoint AddServiceEndpoint (
			Type implementedContract, Binding binding, string address)
		{
			return AddServiceEndpoint (implementedContract, binding,
				new Uri (address, UriKind.RelativeOrAbsolute));
		}

		[MonoTODO]
		public ServiceEndpoint AddServiceEndpoint (
			Type implementedContract, Binding binding, string address, Uri listenUri)
		{
			return AddServiceEndpoint (implementedContract, binding,
				new Uri (address, UriKind.RelativeOrAbsolute), listenUri);
		}

		[MonoTODO]
		public ServiceEndpoint AddServiceEndpoint (
			Type implementedContract, Binding binding, Uri address)
		{
			return AddServiceEndpoint (implementedContract,
				binding, address, address);
		}

		[MonoTODO]
		public ServiceEndpoint AddServiceEndpoint (
			Type implementedContract, Binding binding, Uri address, Uri listenUri)
		{
			EndpointAddress ea = BuildEndpointAddress (address, binding);

			ContractDescription cd = GetExistingContract (implementedContract);
			if (cd == null) {
				cd = ContractDescription.GetContract (implementedContract);
				contracts.Add (cd.ContractType.FullName, cd);
			}

			return AddServiceEndpointCore (cd, binding, ea, listenUri);
		}

		ContractDescription GetExistingContract (Type implementedContract)
		{
			foreach (ContractDescription cd in ImplementedContracts.Values)
				if (cd.ContractType == implementedContract)
					return cd;
			return null;
		}

		protected override ServiceDescription CreateDescription (
			out IDictionary<string,ContractDescription> implementedContracts)
		{
			contracts = new Dictionary<string,ContractDescription> ();
			implementedContracts = contracts;
			ServiceDescription sd;
			ContractDescription cd;
			if (SingletonInstance != null) {
				sd = ServiceDescription.GetService (instance);
				cd = ContractDescription.GetContract (
					service_type, SingletonInstance);
			} else {
				sd = ServiceDescription.GetService (service_type);
				cd = ContractDescription.GetContract (service_type);
			}
			contracts.Add (cd.ContractType.FullName, cd);

			// FIXME: find out where to get type.
			// description = ServiceDescription.GetService (serviceType);
			sd.Behaviors.Add (
				new ServiceBehaviorAttribute ());
			sd.Behaviors.Add (
				new ServiceAuthorizationBehavior ());
			sd.Behaviors.Add (
				new ServiceDebugBehavior ());

			return sd;
		}

		[MonoTODO]
		protected void InitializeDescription (Type serviceType, UriSchemeKeyedCollection baseAddresses)
		{
			if (!serviceType.IsClass)
				throw new ArgumentException ("ServiceHost only supports 'class' service types.");

			service_type = serviceType;

			InitializeDescription (baseAddresses);
		}

		[MonoTODO]
		protected void InitializeDescription (object serviceInstance, UriSchemeKeyedCollection baseAddresses)
		{
			InitializeDescription (serviceInstance.GetType (), baseAddresses);
			instance = serviceInstance;
		}
	}
}
