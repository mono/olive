//
// ServiceMetadataBehavior.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//	Ankit Jain  <jankit@novell.com>
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;

namespace System.ServiceModel.Description
{
	[MonoTODO]
	public class ServiceMetadataBehavior : IServiceBehavior
	{
		public const string MexContractName = "IMetadataExchange";
		//FIXME: Change to an interface
		internal const string HttpGetWsdlContractName = "HttpGetWsdl";

		bool enable_http, enable_https;
		Uri http_url, https_url, location;
		MetadataExporter exporter;

		public ServiceMetadataBehavior ()
		{
		}

		public bool HttpGetEnabled {
			get { return enable_http; }
			set { enable_http = value; }
		}

		public bool HttpsGetEnabled {
			get { return enable_https; }
			set { enable_https = value; }
		}

		public MetadataExporter MetadataExporter {
			get { return exporter; }
			set { exporter = value; }
		}

		public Uri ExternalMetadataLocation {
			get { return location; }
			set { location = value; }
		}

		public Uri HttpGetUrl {
			get { return http_url; }
			set { http_url = value; }
		}

		public Uri HttpsGetUrl {
			get { return https_url; }
			set { https_url = value; }
		}

		[MonoTODO]
		void IServiceBehavior.AddBindingParameters (
			ServiceDescription description,
			ServiceHostBase serviceHostBase,
			Collection<ServiceEndpoint> endpoints,
			BindingParameterCollection parameters)
		{
			if (HttpGetEnabled) {
				//FIXME: Create the binding manually here?
				BasicHttpBinding b = new BasicHttpBinding ();
				BindingElementCollection elements = new BindingElementCollection ();
				foreach (BindingElement be in b.CreateBindingElements ()) {
					MessageEncodingBindingElement me = be as MessageEncodingBindingElement;
					if (me != null)
						me.MessageVersion = MessageVersion.None;
					elements.Add (be);
				}
				CustomBinding cb = new CustomBinding (elements);
				cb.Name = "HttpGetWsdlBinding"; //http://tempuri.org/:HttpGetWsdl

				//FIXME: Extra endpoint for this should _not_ be there
				//in Description.Endpoints collection
				//Only ChannelDispatcher should get added
				//FIXME: This should get added irrespective of whether
				//ServiceMetadataBehavior is added or not (for the help page)
				Uri url = HttpGetUrl ?? serviceHostBase.BaseAddresses [0];
				serviceHostBase.AddServiceEndpointCore (
					ContractDescription.GetContract (typeof (HttpGetWsdl)),
					cb,
					new EndpointAddress (url),
					url);
			}
		}

		void IServiceBehavior.ApplyDispatchBehavior (
			ServiceDescription description,
			ServiceHostBase serviceHostBase)
		{
			if (exporter == null)
				exporter = new WsdlExporter ();
			foreach (ServiceEndpoint ep in description.Endpoints) {
				if (ep.Contract.Name == MexContractName ||
					ep.Contract.Name == HttpGetWsdlContractName)
					continue;

				exporter.ExportEndpoint (ep);
			}
			
			ServiceMetadataExtension sme = new ServiceMetadataExtension ();
			sme.Metadata = exporter.GetGeneratedMetadata ();
			serviceHostBase.Extensions.Add (sme);
			((IExtension<ServiceHostBase>)sme).Attach (serviceHostBase);
		}

		[MonoTODO]
		void IServiceBehavior.Validate (
			ServiceDescription description,
			ServiceHostBase serviceHostBase)
		{			
		}
	}
}
