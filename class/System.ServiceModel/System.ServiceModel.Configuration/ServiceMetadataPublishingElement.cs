//
// ServiceMetadataPublishingElement.cs
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
	public sealed partial class ServiceMetadataPublishingElement
		 : BehaviorExtensionElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty behavior_type;
		static ConfigurationProperty external_metadata_location;
		static ConfigurationProperty http_get_enabled;
		static ConfigurationProperty http_get_url;
		static ConfigurationProperty https_get_enabled;
		static ConfigurationProperty https_get_url;

		static ServiceMetadataPublishingElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			behavior_type = new ConfigurationProperty ("",
				typeof (Type), null, new TypeConverter (), null,
				ConfigurationPropertyOptions.None);

			external_metadata_location = new ConfigurationProperty ("externalMetadataLocation",
				typeof (Uri), null, new UriTypeConverter (), null,
				ConfigurationPropertyOptions.None);

			http_get_enabled = new ConfigurationProperty ("httpGetEnabled",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			http_get_url = new ConfigurationProperty ("httpGetUrl",
				typeof (Uri), null, new UriTypeConverter (), null,
				ConfigurationPropertyOptions.None);

			https_get_enabled = new ConfigurationProperty ("httpsGetEnabled",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			https_get_url = new ConfigurationProperty ("httpsGetUrl",
				typeof (Uri), null, new UriTypeConverter (), null,
				ConfigurationPropertyOptions.None);

			properties.Add (behavior_type);
			properties.Add (external_metadata_location);
			properties.Add (http_get_enabled);
			properties.Add (http_get_url);
			properties.Add (https_get_enabled);
			properties.Add (https_get_url);
		}

		public ServiceMetadataPublishingElement ()
		{
		}


		// Properties

		public override Type BehaviorType {
			get { return (Type) base [behavior_type]; }
		}

		[ConfigurationProperty ("externalMetadataLocation",
			 Options = ConfigurationPropertyOptions.None)]
		public Uri ExternalMetadataLocation {
			get { return (Uri) base [external_metadata_location]; }
			set { base [external_metadata_location] = value; }
		}

		[ConfigurationProperty ("httpGetEnabled",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool HttpGetEnabled {
			get { return (bool) base [http_get_enabled]; }
			set { base [http_get_enabled] = value; }
		}

		[ConfigurationProperty ("httpGetUrl",
			 Options = ConfigurationPropertyOptions.None)]
		public Uri HttpGetUrl {
			get { return (Uri) base [http_get_url]; }
			set { base [http_get_url] = value; }
		}

		[ConfigurationProperty ("httpsGetEnabled",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool HttpsGetEnabled {
			get { return (bool) base [https_get_enabled]; }
			set { base [https_get_enabled] = value; }
		}

		[ConfigurationProperty ("httpsGetUrl",
			 Options = ConfigurationPropertyOptions.None)]
		public Uri HttpsGetUrl {
			get { return (Uri) base [https_get_url]; }
			set { base [https_get_url] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}


	}

}
