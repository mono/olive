//
// UserNameServiceElement.cs
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
	public sealed partial class UserNameServiceElement
		 : ConfigurationElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty cached_logon_token_lifetime;
		static ConfigurationProperty cache_logon_tokens;
		static ConfigurationProperty custom_user_name_password_validator_type;
		static ConfigurationProperty include_windows_groups;
		static ConfigurationProperty max_cached_logon_tokens;
		static ConfigurationProperty membership_provider_name;
		static ConfigurationProperty user_name_password_validation_mode;

		static UserNameServiceElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			cached_logon_token_lifetime = new ConfigurationProperty ("cachedLogonTokenLifetime",
				typeof (TimeSpan), "00:15:00", null/* FIXME: get converter for TimeSpan*/, null,
				ConfigurationPropertyOptions.None);

			cache_logon_tokens = new ConfigurationProperty ("cacheLogonTokens",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			custom_user_name_password_validator_type = new ConfigurationProperty ("customUserNamePasswordValidatorType",
				typeof (string), "", new StringConverter (), null,
				ConfigurationPropertyOptions.None);

			include_windows_groups = new ConfigurationProperty ("includeWindowsGroups",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			max_cached_logon_tokens = new ConfigurationProperty ("maxCachedLogonTokens",
				typeof (int), "128", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			membership_provider_name = new ConfigurationProperty ("membershipProviderName",
				typeof (string), "", new StringConverter (), null,
				ConfigurationPropertyOptions.None);

			user_name_password_validation_mode = new ConfigurationProperty ("userNamePasswordValidationMode",
				typeof (UserNamePasswordValidationMode), "Windows", null/* FIXME: get converter for UserNamePasswordValidationMode*/, null,
				ConfigurationPropertyOptions.None);

			properties.Add (cached_logon_token_lifetime);
			properties.Add (cache_logon_tokens);
			properties.Add (custom_user_name_password_validator_type);
			properties.Add (include_windows_groups);
			properties.Add (max_cached_logon_tokens);
			properties.Add (membership_provider_name);
			properties.Add (user_name_password_validation_mode);
		}

		public UserNameServiceElement ()
		{
		}


		// Properties

		[ConfigurationProperty ("cachedLogonTokenLifetime",
			 DefaultValue = "00:15:00",
			 Options = ConfigurationPropertyOptions.None)]
		[TypeConverter ()]
		public TimeSpan CachedLogonTokenLifetime {
			get { return (TimeSpan) base [cached_logon_token_lifetime]; }
			set { base [cached_logon_token_lifetime] = value; }
		}

		[ConfigurationProperty ("cacheLogonTokens",
			DefaultValue = false,
			 Options = ConfigurationPropertyOptions.None)]
		public bool CacheLogonTokens {
			get { return (bool) base [cache_logon_tokens]; }
			set { base [cache_logon_tokens] = value; }
		}

		[ConfigurationProperty ("customUserNamePasswordValidatorType",
			 DefaultValue = "",
			 Options = ConfigurationPropertyOptions.None)]
		[StringValidator ( MinLength = 0,
			MaxLength = int.MaxValue,
			 InvalidCharacters = null)]
		public string CustomUserNamePasswordValidatorType {
			get { return (string) base [custom_user_name_password_validator_type]; }
			set { base [custom_user_name_password_validator_type] = value; }
		}

		[ConfigurationProperty ("includeWindowsGroups",
			DefaultValue = true,
			 Options = ConfigurationPropertyOptions.None)]
		public bool IncludeWindowsGroups {
			get { return (bool) base [include_windows_groups]; }
			set { base [include_windows_groups] = value; }
		}

		[ConfigurationProperty ("maxCachedLogonTokens",
			 DefaultValue = "128",
			 Options = ConfigurationPropertyOptions.None)]
		[IntegerValidator ( MinValue = 1,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		public int MaxCachedLogonTokens {
			get { return (int) base [max_cached_logon_tokens]; }
			set { base [max_cached_logon_tokens] = value; }
		}

		[StringValidator ( MinLength = 0,
			MaxLength = int.MaxValue,
			 InvalidCharacters = null)]
		[ConfigurationProperty ("membershipProviderName",
			 DefaultValue = "",
			 Options = ConfigurationPropertyOptions.None)]
		public string MembershipProviderName {
			get { return (string) base [membership_provider_name]; }
			set { base [membership_provider_name] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[ConfigurationProperty ("userNamePasswordValidationMode",
			 DefaultValue = "Windows",
			 Options = ConfigurationPropertyOptions.None)]
		public UserNamePasswordValidationMode UserNamePasswordValidationMode {
			get { return (UserNamePasswordValidationMode) base [user_name_password_validation_mode]; }
			set { base [user_name_password_validation_mode] = value; }
		}


	}

}
