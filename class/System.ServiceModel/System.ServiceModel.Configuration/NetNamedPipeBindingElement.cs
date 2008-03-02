//
// NetNamedPipeBindingElement.cs
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
	public partial class NetNamedPipeBindingElement
		 : StandardBindingElement,  IBindingConfigurationElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty host_name_comparison_mode;
		static ConfigurationProperty max_buffer_pool_size;
		static ConfigurationProperty max_buffer_size;
		static ConfigurationProperty max_connections;
		static ConfigurationProperty max_received_message_size;
		static ConfigurationProperty reader_quotas;
		static ConfigurationProperty security;
		static ConfigurationProperty transaction_flow;
		static ConfigurationProperty transaction_protocol;
		static ConfigurationProperty transfer_mode;

		static NetNamedPipeBindingElement ()
		{
			properties = StandardBindingElement.CreateBaseProperties ();

			host_name_comparison_mode = new ConfigurationProperty ("hostNameComparisonMode",
				typeof (HostNameComparisonMode), "StrongWildcard", null/* FIXME: get converter for HostNameComparisonMode*/, null,
				ConfigurationPropertyOptions.None);

			max_buffer_pool_size = new ConfigurationProperty ("maxBufferPoolSize",
				typeof (long), "524288", null/* FIXME: get converter for long*/, null,
				ConfigurationPropertyOptions.None);

			max_buffer_size = new ConfigurationProperty ("maxBufferSize",
				typeof (int), "65536", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			max_connections = new ConfigurationProperty ("maxConnections",
				typeof (int), "10", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			max_received_message_size = new ConfigurationProperty ("maxReceivedMessageSize",
				typeof (long), "65536", null/* FIXME: get converter for long*/, null,
				ConfigurationPropertyOptions.None);

			reader_quotas = new ConfigurationProperty ("readerQuotas",
				typeof (XmlDictionaryReaderQuotasElement), null, null/* FIXME: get converter for XmlDictionaryReaderQuotasElement*/, null,
				ConfigurationPropertyOptions.None);

			security = new ConfigurationProperty ("security",
				typeof (NetNamedPipeSecurityElement), null, null/* FIXME: get converter for NetNamedPipeSecurityElement*/, null,
				ConfigurationPropertyOptions.None);

			transaction_flow = new ConfigurationProperty ("transactionFlow",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			transaction_protocol = new ConfigurationProperty ("transactionProtocol",
				typeof (TransactionProtocol), "OleTransactions", TransactionProtocolConverter.Instance, null,
				ConfigurationPropertyOptions.None);

			transfer_mode = new ConfigurationProperty ("transferMode",
				typeof (TransferMode), "Buffered", null/* FIXME: get converter for TransferMode*/, null,
				ConfigurationPropertyOptions.None);

			properties.Add (host_name_comparison_mode);
			properties.Add (max_buffer_pool_size);
			properties.Add (max_buffer_size);
			properties.Add (max_connections);
			properties.Add (max_received_message_size);
			properties.Add (reader_quotas);
			properties.Add (security);
			properties.Add (transaction_flow);
			properties.Add (transaction_protocol);
			properties.Add (transfer_mode);
		}

		public NetNamedPipeBindingElement ()
		{
		}

		public NetNamedPipeBindingElement (string name) : base (name) { }

		// Properties

		protected override Type BindingElementType {
			get { return typeof (NetNamedPipeBinding); }
		}

		[ConfigurationProperty ("hostNameComparisonMode",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "StrongWildcard")]
		public HostNameComparisonMode HostNameComparisonMode {
			get { return (HostNameComparisonMode) base [host_name_comparison_mode]; }
			set { base [host_name_comparison_mode] = value; }
		}

		[ConfigurationProperty ("maxBufferPoolSize",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "524288")]
		[LongValidator ( MinValue = 0,
			 MaxValue = 9223372036854775807,
			ExcludeRange = false)]
		public long MaxBufferPoolSize {
			get { return (long) base [max_buffer_pool_size]; }
			set { base [max_buffer_pool_size] = value; }
		}

		[ConfigurationProperty ("maxBufferSize",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "65536")]
		[IntegerValidator ( MinValue = 1,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		public int MaxBufferSize {
			get { return (int) base [max_buffer_size]; }
			set { base [max_buffer_size] = value; }
		}

		[IntegerValidator ( MinValue = 1,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		[ConfigurationProperty ("maxConnections",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "10")]
		public int MaxConnections {
			get { return (int) base [max_connections]; }
			set { base [max_connections] = value; }
		}

		[ConfigurationProperty ("maxReceivedMessageSize",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "65536")]
		[LongValidator ( MinValue = 1,
			 MaxValue = 9223372036854775807,
			ExcludeRange = false)]
		public long MaxReceivedMessageSize {
			get { return (long) base [max_received_message_size]; }
			set { base [max_received_message_size] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[ConfigurationProperty ("readerQuotas",
			 Options = ConfigurationPropertyOptions.None)]
		public XmlDictionaryReaderQuotasElement ReaderQuotas {
			get { return (XmlDictionaryReaderQuotasElement) base [reader_quotas]; }
		}

		[ConfigurationProperty ("security",
			 Options = ConfigurationPropertyOptions.None)]
		public NetNamedPipeSecurityElement Security {
			get { return (NetNamedPipeSecurityElement) base [security]; }
		}

		[ConfigurationProperty ("transactionFlow",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool TransactionFlow {
			get { return (bool) base [transaction_flow]; }
			set { base [transaction_flow] = value; }
		}

		[ConfigurationProperty ("transactionProtocol",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "OleTransactions")]
		[TypeConverter ()]
		public TransactionProtocol TransactionProtocol {
			get { return (TransactionProtocol) base [transaction_protocol]; }
			set { base [transaction_protocol] = value; }
		}

		[ConfigurationProperty ("transferMode",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "Buffered")]
		public TransferMode TransferMode {
			get { return (TransferMode) base [transfer_mode]; }
			set { base [transfer_mode] = value; }
		}


	}

}
