//
// BindingsSection.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.  http://www.novell.com
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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Diagnostics;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.MsmqIntegration;
using System.ServiceModel.PeerResolvers;
using System.ServiceModel.Security;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Configuration
{
	[MonoTODO]
	public sealed partial class BindingsSection
		 : ConfigurationSection
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty basic_http_binding;
		static ConfigurationProperty binding_collections;
		static ConfigurationProperty custom_binding;
		static ConfigurationProperty msmq_integration_binding;
		static ConfigurationProperty net_msmq_binding;
		static ConfigurationProperty net_named_pipe_binding;
		static ConfigurationProperty net_peer_tcp_binding;
		static ConfigurationProperty net_tcp_binding;
		static ConfigurationProperty w_s_dual_http_binding;
		static ConfigurationProperty w_s_federation_http_binding;
		static ConfigurationProperty w_s_http_binding;

		static BindingsSection ()
		{
			properties = new ConfigurationPropertyCollection ();
			basic_http_binding = new ConfigurationProperty ("basicHttpBinding",
				typeof (BasicHttpBindingCollectionElement), null, null/* FIXME: get converter for BasicHttpBindingCollectionElement*/, null,
				ConfigurationPropertyOptions.None);

			binding_collections = new ConfigurationProperty ("",
				typeof (List<BindingCollectionElement>), null, null/* FIXME: get converter for List<BindingCollectionElement>*/, null,
				ConfigurationPropertyOptions.None);

			custom_binding = new ConfigurationProperty ("customBinding",
				typeof (CustomBindingCollectionElement), null, null/* FIXME: get converter for CustomBindingCollectionElement*/, null,
				ConfigurationPropertyOptions.None);

			msmq_integration_binding = new ConfigurationProperty ("msmqIntegrationBinding",
				typeof (MsmqIntegrationBindingCollectionElement), null, null/* FIXME: get converter for MsmqIntegrationBindingCollectionElement*/, null,
				ConfigurationPropertyOptions.None);

			net_msmq_binding = new ConfigurationProperty ("netMsmqBinding",
				typeof (NetMsmqBindingCollectionElement), null, null/* FIXME: get converter for NetMsmqBindingCollectionElement*/, null,
				ConfigurationPropertyOptions.None);

			net_named_pipe_binding = new ConfigurationProperty ("netNamedPipeBinding",
				typeof (NetNamedPipeBindingCollectionElement), null, null/* FIXME: get converter for NetNamedPipeBindingCollectionElement*/, null,
				ConfigurationPropertyOptions.None);

			net_peer_tcp_binding = new ConfigurationProperty ("netPeerTcpBinding",
				typeof (NetPeerTcpBindingCollectionElement), null, null/* FIXME: get converter for NetPeerTcpBindingCollectionElement*/, null,
				ConfigurationPropertyOptions.None);

			net_tcp_binding = new ConfigurationProperty ("netTcpBinding",
				typeof (NetTcpBindingCollectionElement), null, null/* FIXME: get converter for NetTcpBindingCollectionElement*/, null,
				ConfigurationPropertyOptions.None);

			w_s_dual_http_binding = new ConfigurationProperty ("wsDualHttpBinding",
				typeof (WSDualHttpBindingCollectionElement), null, null/* FIXME: get converter for WSDualHttpBindingCollectionElement*/, null,
				ConfigurationPropertyOptions.None);

			w_s_federation_http_binding = new ConfigurationProperty ("wsFederationHttpBinding",
				typeof (WSFederationHttpBindingCollectionElement), null, null/* FIXME: get converter for WSFederationHttpBindingCollectionElement*/, null,
				ConfigurationPropertyOptions.None);

			w_s_http_binding = new ConfigurationProperty ("wsHttpBinding",
				typeof (WSHttpBindingCollectionElement), null, null/* FIXME: get converter for WSHttpBindingCollectionElement*/, null,
				ConfigurationPropertyOptions.None);

			properties.Add (basic_http_binding);
			properties.Add (binding_collections);
			properties.Add (custom_binding);
			properties.Add (msmq_integration_binding);
			properties.Add (net_msmq_binding);
			properties.Add (net_named_pipe_binding);
			properties.Add (net_peer_tcp_binding);
			properties.Add (net_tcp_binding);
			properties.Add (w_s_dual_http_binding);
			properties.Add (w_s_federation_http_binding);
			properties.Add (w_s_http_binding);
		}

		public BindingsSection ()
		{
		}


		// Properties

		[ConfigurationProperty ("basicHttpBinding",
			 Options = ConfigurationPropertyOptions.None)]
		public BasicHttpBindingCollectionElement BasicHttpBinding {
			get { return (BasicHttpBindingCollectionElement) base [basic_http_binding]; }
		}

		public List<BindingCollectionElement> BindingCollections {
			get { return (List<BindingCollectionElement>) base [binding_collections]; }
		}

		[ConfigurationProperty ("customBinding",
			 Options = ConfigurationPropertyOptions.None)]
		public CustomBindingCollectionElement CustomBinding {
			get { return (CustomBindingCollectionElement) base [custom_binding]; }
		}

		[ConfigurationProperty ("msmqIntegrationBinding",
			 Options = ConfigurationPropertyOptions.None)]
		public MsmqIntegrationBindingCollectionElement MsmqIntegrationBinding {
			get { return (MsmqIntegrationBindingCollectionElement) base [msmq_integration_binding]; }
		}

		[ConfigurationProperty ("netMsmqBinding",
			 Options = ConfigurationPropertyOptions.None)]
		public NetMsmqBindingCollectionElement NetMsmqBinding {
			get { return (NetMsmqBindingCollectionElement) base [net_msmq_binding]; }
		}

		[ConfigurationProperty ("netNamedPipeBinding",
			 Options = ConfigurationPropertyOptions.None)]
		public NetNamedPipeBindingCollectionElement NetNamedPipeBinding {
			get { return (NetNamedPipeBindingCollectionElement) base [net_named_pipe_binding]; }
		}

		[ConfigurationProperty ("netPeerTcpBinding",
			 Options = ConfigurationPropertyOptions.None)]
		public NetPeerTcpBindingCollectionElement NetPeerTcpBinding {
			get { return (NetPeerTcpBindingCollectionElement) base [net_peer_tcp_binding]; }
		}

		[ConfigurationProperty ("netTcpBinding",
			 Options = ConfigurationPropertyOptions.None)]
		public NetTcpBindingCollectionElement NetTcpBinding {
			get { return (NetTcpBindingCollectionElement) base [net_tcp_binding]; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[ConfigurationProperty ("wsDualHttpBinding",
			 Options = ConfigurationPropertyOptions.None)]
		public WSDualHttpBindingCollectionElement WSDualHttpBinding {
			get { return (WSDualHttpBindingCollectionElement) base [w_s_dual_http_binding]; }
		}

		[ConfigurationProperty ("wsFederationHttpBinding",
			 Options = ConfigurationPropertyOptions.None)]
		public WSFederationHttpBindingCollectionElement WSFederationHttpBinding {
			get { return (WSFederationHttpBindingCollectionElement) base [w_s_federation_http_binding]; }
		}

		[ConfigurationProperty ("wsHttpBinding",
			 Options = ConfigurationPropertyOptions.None)]
		public WSHttpBindingCollectionElement WSHttpBinding {
			get { return (WSHttpBindingCollectionElement) base [w_s_http_binding]; }
		}


	}

}
