//
// ServiceDebugElement.cs
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
	public sealed partial class ServiceDebugElement
		 : BehaviorExtensionElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty behavior_type;
		static ConfigurationProperty http_help_page_enabled;
		static ConfigurationProperty http_help_page_url;
		static ConfigurationProperty https_help_page_enabled;
		static ConfigurationProperty https_help_page_url;
		static ConfigurationProperty include_exception_detail_in_faults;

		static ServiceDebugElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			behavior_type = new ConfigurationProperty ("",
				typeof (Type), null, new TypeConverter (), null,
				ConfigurationPropertyOptions.None);

			http_help_page_enabled = new ConfigurationProperty ("httpHelpPageEnabled",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			http_help_page_url = new ConfigurationProperty ("httpHelpPageUrl",
				typeof (Uri), null, new UriTypeConverter (), null,
				ConfigurationPropertyOptions.None);

			https_help_page_enabled = new ConfigurationProperty ("httpsHelpPageEnabled",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			https_help_page_url = new ConfigurationProperty ("httpsHelpPageUrl",
				typeof (Uri), null, new UriTypeConverter (), null,
				ConfigurationPropertyOptions.None);

			include_exception_detail_in_faults = new ConfigurationProperty ("includeExceptionDetailInFaults",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			properties.Add (behavior_type);
			properties.Add (http_help_page_enabled);
			properties.Add (http_help_page_url);
			properties.Add (https_help_page_enabled);
			properties.Add (https_help_page_url);
			properties.Add (include_exception_detail_in_faults);
		}

		public ServiceDebugElement ()
		{
		}


		// Properties

		public override Type BehaviorType {
			get { return (Type) base [behavior_type]; }
		}

		[ConfigurationProperty ("httpHelpPageEnabled",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = true)]
		public bool HttpHelpPageEnabled {
			get { return (bool) base [http_help_page_enabled]; }
			set { base [http_help_page_enabled] = value; }
		}

		[ConfigurationProperty ("httpHelpPageUrl",
			 Options = ConfigurationPropertyOptions.None)]
		public Uri HttpHelpPageUrl {
			get { return (Uri) base [http_help_page_url]; }
			set { base [http_help_page_url] = value; }
		}

		[ConfigurationProperty ("httpsHelpPageEnabled",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = true)]
		public bool HttpsHelpPageEnabled {
			get { return (bool) base [https_help_page_enabled]; }
			set { base [https_help_page_enabled] = value; }
		}

		[ConfigurationProperty ("httpsHelpPageUrl",
			 Options = ConfigurationPropertyOptions.None)]
		public Uri HttpsHelpPageUrl {
			get { return (Uri) base [https_help_page_url]; }
			set { base [https_help_page_url] = value; }
		}

		[ConfigurationProperty ("includeExceptionDetailInFaults",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool IncludeExceptionDetailInFaults {
			get { return (bool) base [include_exception_detail_in_faults]; }
			set { base [include_exception_detail_in_faults] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}


	}

}
