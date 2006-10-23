//
// TransportElement.cs
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
	public abstract partial class TransportElement
		 : BindingElementExtensionElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty manual_addressing;
		static ConfigurationProperty max_buffer_pool_size;
		static ConfigurationProperty max_received_message_size;

		static TransportElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			manual_addressing = new ConfigurationProperty ("manualAddressing",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			max_buffer_pool_size = new ConfigurationProperty ("maxBufferPoolSize",
				typeof (long), "524288", null/* FIXME: get converter for long*/, null,
				ConfigurationPropertyOptions.None);

			max_received_message_size = new ConfigurationProperty ("maxReceivedMessageSize",
				typeof (long), "65536", null/* FIXME: get converter for long*/, null,
				ConfigurationPropertyOptions.None);

			properties.Add (manual_addressing);
			properties.Add (max_buffer_pool_size);
			properties.Add (max_received_message_size);
		}

		protected TransportElement ()
		{
		}


		// Properties

		[ConfigurationProperty ("manualAddressing",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool ManualAddressing {
			get { return (bool) base [manual_addressing]; }
			set { base [manual_addressing] = value; }
		}

		[ConfigurationProperty ("maxBufferPoolSize",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "524288")]
		[LongValidator ( MinValue = 1,
			 MaxValue = 9223372036854775807,
			ExcludeRange = false)]
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

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}


	}

}
