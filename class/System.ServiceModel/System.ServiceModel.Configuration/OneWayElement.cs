//
// OneWayElement.cs
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
	public sealed partial class OneWayElement
		 : BindingElementExtensionElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty binding_element_type;
		static ConfigurationProperty channel_pool_settings;
		static ConfigurationProperty max_accepted_channels;
		static ConfigurationProperty packet_routable;

		static OneWayElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			binding_element_type = new ConfigurationProperty ("",
				typeof (Type), null, new TypeConverter (), null,
				ConfigurationPropertyOptions.None);

			channel_pool_settings = new ConfigurationProperty ("channelPoolSettings",
				typeof (ChannelPoolSettingsElement), null, null/* FIXME: get converter for ChannelPoolSettingsElement*/, null,
				ConfigurationPropertyOptions.None);

			max_accepted_channels = new ConfigurationProperty ("maxAcceptedChannels",
				typeof (int), "10", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			packet_routable = new ConfigurationProperty ("packetRoutable",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			properties.Add (binding_element_type);
			properties.Add (channel_pool_settings);
			properties.Add (max_accepted_channels);
			properties.Add (packet_routable);
		}

		public OneWayElement ()
		{
		}


		// Properties

		public override Type BindingElementType {
			get { return (Type) base [binding_element_type]; }
		}

		[ConfigurationProperty ("channelPoolSettings",
			 Options = ConfigurationPropertyOptions.None)]
		public ChannelPoolSettingsElement ChannelPoolSettings {
			get { return (ChannelPoolSettingsElement) base [channel_pool_settings]; }
		}

		[ConfigurationProperty ("maxAcceptedChannels",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "10")]
		[IntegerValidator ( MinValue = 1,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		public int MaxAcceptedChannels {
			get { return (int) base [max_accepted_channels]; }
			set { base [max_accepted_channels] = value; }
		}

		[ConfigurationProperty ("packetRoutable",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool PacketRoutable {
			get { return (bool) base [packet_routable]; }
			set { base [packet_routable] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}


		[MonoTODO]
		protected internal override BindingElement CreateBindingElement () {
			throw new NotImplementedException ();
		}

	}

}
