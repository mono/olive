//
// HttpTransportElement.cs
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
	public partial class HttpTransportElement
		 : TransportElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty allow_cookies;
		static ConfigurationProperty authentication_scheme;
		static ConfigurationProperty binding_element_type;
		static ConfigurationProperty bypass_proxy_on_local;
		static ConfigurationProperty host_name_comparison_mode;
		static ConfigurationProperty keep_alive_enabled;
		static ConfigurationProperty max_buffer_size;
		static ConfigurationProperty proxy_address;
		static ConfigurationProperty proxy_authentication_scheme;
		static ConfigurationProperty realm;
		static ConfigurationProperty transfer_mode;
		static ConfigurationProperty unsafe_connection_ntlm_authentication;
		static ConfigurationProperty use_default_web_proxy;

		static HttpTransportElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			allow_cookies = new ConfigurationProperty ("allowCookies",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			authentication_scheme = new ConfigurationProperty ("authenticationScheme",
				typeof (AuthenticationSchemes), "Anonymous", null/* FIXME: get converter for AuthenticationSchemes*/, null,
				ConfigurationPropertyOptions.None);

			binding_element_type = new ConfigurationProperty ("",
				typeof (Type), null, new TypeConverter (), null,
				ConfigurationPropertyOptions.None);

			bypass_proxy_on_local = new ConfigurationProperty ("bypassProxyOnLocal",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			host_name_comparison_mode = new ConfigurationProperty ("hostNameComparisonMode",
				typeof (HostNameComparisonMode), "StrongWildcard", null/* FIXME: get converter for HostNameComparisonMode*/, null,
				ConfigurationPropertyOptions.None);

			keep_alive_enabled = new ConfigurationProperty ("keepAliveEnabled",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			max_buffer_size = new ConfigurationProperty ("maxBufferSize",
				typeof (int), "65536", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			proxy_address = new ConfigurationProperty ("proxyAddress",
				typeof (Uri), null, new UriTypeConverter (), null,
				ConfigurationPropertyOptions.None);

			proxy_authentication_scheme = new ConfigurationProperty ("proxyAuthenticationScheme",
				typeof (AuthenticationSchemes), "Anonymous", null/* FIXME: get converter for AuthenticationSchemes*/, null,
				ConfigurationPropertyOptions.None);

			realm = new ConfigurationProperty ("realm",
				typeof (string), "", new StringConverter (), null,
				ConfigurationPropertyOptions.None);

			transfer_mode = new ConfigurationProperty ("transferMode",
				typeof (TransferMode), "Buffered", null/* FIXME: get converter for TransferMode*/, null,
				ConfigurationPropertyOptions.None);

			unsafe_connection_ntlm_authentication = new ConfigurationProperty ("unsafeConnectionNtlmAuthentication",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			use_default_web_proxy = new ConfigurationProperty ("useDefaultWebProxy",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			properties.Add (allow_cookies);
			properties.Add (authentication_scheme);
			properties.Add (binding_element_type);
			properties.Add (bypass_proxy_on_local);
			properties.Add (host_name_comparison_mode);
			properties.Add (keep_alive_enabled);
			properties.Add (max_buffer_size);
			properties.Add (proxy_address);
			properties.Add (proxy_authentication_scheme);
			properties.Add (realm);
			properties.Add (transfer_mode);
			properties.Add (unsafe_connection_ntlm_authentication);
			properties.Add (use_default_web_proxy);
		}

		public HttpTransportElement ()
		{
		}


		// Properties

		[ConfigurationProperty ("allowCookies",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool AllowCookies {
			get { return (bool) base [allow_cookies]; }
			set { base [allow_cookies] = value; }
		}

		[ConfigurationProperty ("authenticationScheme",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "Anonymous")]
		public AuthenticationSchemes AuthenticationScheme {
			get { return (AuthenticationSchemes) base [authentication_scheme]; }
			set { base [authentication_scheme] = value; }
		}

		public override Type BindingElementType {
			get { return (Type) base [binding_element_type]; }
		}

		[ConfigurationProperty ("bypassProxyOnLocal",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool BypassProxyOnLocal {
			get { return (bool) base [bypass_proxy_on_local]; }
			set { base [bypass_proxy_on_local] = value; }
		}

		[ConfigurationProperty ("hostNameComparisonMode",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "StrongWildcard")]
		public HostNameComparisonMode HostNameComparisonMode {
			get { return (HostNameComparisonMode) base [host_name_comparison_mode]; }
			set { base [host_name_comparison_mode] = value; }
		}

		[ConfigurationProperty ("keepAliveEnabled",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = true)]
		public bool KeepAliveEnabled {
			get { return (bool) base [keep_alive_enabled]; }
			set { base [keep_alive_enabled] = value; }
		}

		[IntegerValidator ( MinValue = 1,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		[ConfigurationProperty ("maxBufferSize",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "65536")]
		public int MaxBufferSize {
			get { return (int) base [max_buffer_size]; }
			set { base [max_buffer_size] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[ConfigurationProperty ("proxyAddress",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = null)]
		public Uri ProxyAddress {
			get { return (Uri) base [proxy_address]; }
			set { base [proxy_address] = value; }
		}

		[ConfigurationProperty ("proxyAuthenticationScheme",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "Anonymous")]
		public AuthenticationSchemes ProxyAuthenticationScheme {
			get { return (AuthenticationSchemes) base [proxy_authentication_scheme]; }
			set { base [proxy_authentication_scheme] = value; }
		}

		[ConfigurationProperty ("realm",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "")]
		[StringValidator ( MinLength = 0,
			MaxLength = int.MaxValue,
			 InvalidCharacters = null)]
		public string Realm {
			get { return (string) base [realm]; }
			set { base [realm] = value; }
		}

		[ConfigurationProperty ("transferMode",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "Buffered")]
		public TransferMode TransferMode {
			get { return (TransferMode) base [transfer_mode]; }
			set { base [transfer_mode] = value; }
		}

		[ConfigurationProperty ("unsafeConnectionNtlmAuthentication",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool UnsafeConnectionNtlmAuthentication {
			get { return (bool) base [unsafe_connection_ntlm_authentication]; }
			set { base [unsafe_connection_ntlm_authentication] = value; }
		}

		[ConfigurationProperty ("useDefaultWebProxy",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = true)]
		public bool UseDefaultWebProxy {
			get { return (bool) base [use_default_web_proxy]; }
			set { base [use_default_web_proxy] = value; }
		}


	}

}
