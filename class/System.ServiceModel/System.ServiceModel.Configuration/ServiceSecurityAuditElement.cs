//
// ServiceSecurityAuditElement.cs
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
	public sealed partial class ServiceSecurityAuditElement
		 : BehaviorExtensionElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty audit_log_location;
		static ConfigurationProperty behavior_type;
		static ConfigurationProperty message_authentication_audit_level;
		static ConfigurationProperty service_authorization_audit_level;
		static ConfigurationProperty suppress_audit_failure;

		static ServiceSecurityAuditElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			audit_log_location = new ConfigurationProperty ("auditLogLocation",
				typeof (AuditLogLocation), "Default", null/* FIXME: get converter for AuditLogLocation*/, null,
				ConfigurationPropertyOptions.None);

			behavior_type = new ConfigurationProperty ("",
				typeof (Type), null, new TypeConverter (), null,
				ConfigurationPropertyOptions.None);

			message_authentication_audit_level = new ConfigurationProperty ("messageAuthenticationAuditLevel",
				typeof (AuditLevel), "None", null/* FIXME: get converter for AuditLevel*/, null,
				ConfigurationPropertyOptions.None);

			service_authorization_audit_level = new ConfigurationProperty ("serviceAuthorizationAuditLevel",
				typeof (AuditLevel), "None", null/* FIXME: get converter for AuditLevel*/, null,
				ConfigurationPropertyOptions.None);

			suppress_audit_failure = new ConfigurationProperty ("suppressAuditFailure",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			properties.Add (audit_log_location);
			properties.Add (behavior_type);
			properties.Add (message_authentication_audit_level);
			properties.Add (service_authorization_audit_level);
			properties.Add (suppress_audit_failure);
		}

		public ServiceSecurityAuditElement ()
		{
		}


		// Properties

		[ConfigurationProperty ("auditLogLocation",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "Default")]
		public AuditLogLocation AuditLogLocation {
			get { return (AuditLogLocation) base [audit_log_location]; }
			set { base [audit_log_location] = value; }
		}

		public override Type BehaviorType {
			get { return (Type) base [behavior_type]; }
		}

		[ConfigurationProperty ("messageAuthenticationAuditLevel",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "None")]
		public AuditLevel MessageAuthenticationAuditLevel {
			get { return (AuditLevel) base [message_authentication_audit_level]; }
			set { base [message_authentication_audit_level] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[ConfigurationProperty ("serviceAuthorizationAuditLevel",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "None")]
		public AuditLevel ServiceAuthorizationAuditLevel {
			get { return (AuditLevel) base [service_authorization_audit_level]; }
			set { base [service_authorization_audit_level] = value; }
		}

		[ConfigurationProperty ("suppressAuditFailure",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = true)]
		public bool SuppressAuditFailure {
			get { return (bool) base [suppress_audit_failure]; }
			set { base [suppress_audit_failure] = value; }
		}


	}

}
