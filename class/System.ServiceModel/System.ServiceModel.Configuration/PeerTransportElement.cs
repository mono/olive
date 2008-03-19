//
// PeerTransportElement.cs
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
	public partial class PeerTransportElement
		 : BindingElementExtensionElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty binding_element_type;
		static ConfigurationProperty listen_i_p_address;
		static ConfigurationProperty max_buffer_pool_size;
		static ConfigurationProperty max_received_message_size;
		static ConfigurationProperty port;
		static ConfigurationProperty security;

		static PeerTransportElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			binding_element_type = new ConfigurationProperty ("",
				typeof (Type), null, new TypeConverter (), null,
				ConfigurationPropertyOptions.None);

			listen_i_p_address = new ConfigurationProperty ("listenIPAddress",
				typeof (IPAddress), null, null/* FIXME: get converter for IPAddress*/, null,
				ConfigurationPropertyOptions.None);

			max_buffer_pool_size = new ConfigurationProperty ("maxBufferPoolSize",
				typeof (long), "524288", null/* FIXME: get converter for long*/, null,
				ConfigurationPropertyOptions.None);

			max_received_message_size = new ConfigurationProperty ("maxReceivedMessageSize",
				typeof (long), "65536", null/* FIXME: get converter for long*/, null,
				ConfigurationPropertyOptions.None);

			port = new ConfigurationProperty ("port",
				typeof (int), "0", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			security = new ConfigurationProperty ("security",
				typeof (PeerSecurityElement), null, null/* FIXME: get converter for PeerSecurityElement*/, null,
				ConfigurationPropertyOptions.None);

			properties.Add (binding_element_type);
			properties.Add (listen_i_p_address);
			properties.Add (max_buffer_pool_size);
			properties.Add (max_received_message_size);
			properties.Add (port);
			properties.Add (security);
		}

		public PeerTransportElement ()
		{
		}


		// Properties

		public override Type BindingElementType {
			get { return (Type) base [binding_element_type]; }
		}

		[TypeConverter ()]
		[ConfigurationProperty ("listenIPAddress",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = null)]
		public IPAddress ListenIPAddress {
			get { return (IPAddress) base [listen_i_p_address]; }
			set { base [listen_i_p_address] = value; }
		}

		[LongValidator ( MinValue = 1,
			 MaxValue = 9223372036854775807,
			ExcludeRange = false)]
		[ConfigurationProperty ("maxBufferPoolSize",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "524288")]
		public long MaxBufferPoolSize {
			get { return (long) base [max_buffer_pool_size]; }
			set { base [max_buffer_pool_size] = value; }
		}

		[LongValidator ( MinValue = 1,
			 MaxValue = 9223372036854775807,
			ExcludeRange = false)]
		[ConfigurationProperty ("maxReceivedMessageSize",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "65536")]
		public long MaxReceivedMessageSize {
			get { return (long) base [max_received_message_size]; }
			set { base [max_received_message_size] = value; }
		}

		[ConfigurationProperty ("port",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "0")]
		[IntegerValidator ( MinValue = 0,
			 MaxValue = 65535,
			ExcludeRange = false)]
		public int Port {
			get { return (int) base [port]; }
			set { base [port] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[ConfigurationProperty ("security",
			 Options = ConfigurationPropertyOptions.None)]
		public PeerSecurityElement Security {
			get { return (PeerSecurityElement) base [security]; }
		}

		[MonoTODO]
		protected internal override BindingElement CreateBindingElement () {
			throw new NotImplementedException ();
		}

	}

}
