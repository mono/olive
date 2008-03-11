//
// ServiceAuthorizationElement.cs
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
	public sealed class ServiceAuthorizationElement
		 : BehaviorExtensionElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty authorization_policies;
		static ConfigurationProperty impersonate_caller_for_all_operations;
		static ConfigurationProperty principal_permission_mode;
		static ConfigurationProperty role_provider_name;
		static ConfigurationProperty service_authorization_manager_type;

		static ServiceAuthorizationElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			authorization_policies = new ConfigurationProperty ("authorizationPolicies",
				typeof (AuthorizationPolicyTypeElementCollection), null, null, null,
				ConfigurationPropertyOptions.None);

			impersonate_caller_for_all_operations = new ConfigurationProperty ("impersonateCallerForAllOperations",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			principal_permission_mode = new ConfigurationProperty ("principalPermissionMode",
				typeof (PrincipalPermissionMode), "UseWindowsGroups", null, null,
				ConfigurationPropertyOptions.None);

			role_provider_name = new ConfigurationProperty ("roleProviderName",
				typeof (string), "", new StringConverter (), new StringValidator (0, int.MaxValue),
				ConfigurationPropertyOptions.None);

			service_authorization_manager_type = new ConfigurationProperty ("serviceAuthorizationManagerType",
				typeof (string), "", new StringConverter (), new StringValidator (0, int.MaxValue),
				ConfigurationPropertyOptions.None);

			properties.Add (authorization_policies);
			properties.Add (impersonate_caller_for_all_operations);
			properties.Add (principal_permission_mode);
			properties.Add (role_provider_name);
			properties.Add (service_authorization_manager_type);
		}

		public ServiceAuthorizationElement ()
		{
		}


		// Properties

		[ConfigurationProperty ("authorizationPolicies",
			 Options = ConfigurationPropertyOptions.None)]
		public AuthorizationPolicyTypeElementCollection AuthorizationPolicies {
			get { return (AuthorizationPolicyTypeElementCollection) base [authorization_policies]; }
		}

		public override Type BehaviorType {
			get { return typeof(ServiceAuthorizationBehavior); }
		}

		[ConfigurationProperty ("impersonateCallerForAllOperations",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool ImpersonateCallerForAllOperations {
			get { return (bool) base [impersonate_caller_for_all_operations]; }
			set { base [impersonate_caller_for_all_operations] = value; }
		}

		[ConfigurationProperty ("principalPermissionMode",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "UseWindowsGroups")]
		public PrincipalPermissionMode PrincipalPermissionMode {
			get { return (PrincipalPermissionMode) base [principal_permission_mode]; }
			set { base [principal_permission_mode] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[StringValidator ( MinLength = 0,
			MaxLength = int.MaxValue,
			 InvalidCharacters = null)]
		[ConfigurationProperty ("roleProviderName",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "")]
		public string RoleProviderName {
			get { return (string) base [role_provider_name]; }
			set { base [role_provider_name] = value; }
		}

		[StringValidator ( MinLength = 0,
			MaxLength = int.MaxValue,
			 InvalidCharacters = null)]
		[ConfigurationProperty ("serviceAuthorizationManagerType",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "")]
		public string ServiceAuthorizationManagerType {
			get { return (string) base [service_authorization_manager_type]; }
			set { base [service_authorization_manager_type] = value; }
		}

		[MonoTODO]
		protected internal override object CreateBehavior () {
			throw new NotImplementedException ();
		}

	}

}
