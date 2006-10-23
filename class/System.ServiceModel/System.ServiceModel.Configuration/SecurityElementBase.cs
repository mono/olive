//
// SecurityElementBase.cs
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
	public partial class SecurityElementBase
		 : BindingElementExtensionElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty allow_serialized_signing_token_on_reply;
		static ConfigurationProperty authentication_mode;
		static ConfigurationProperty binding_element_type;
		static ConfigurationProperty default_algorithm_suite;
		static ConfigurationProperty include_timestamp;
		static ConfigurationProperty issued_token_parameters;
		static ConfigurationProperty key_entropy_mode;
		static ConfigurationProperty local_client_settings;
		static ConfigurationProperty local_service_settings;
		static ConfigurationProperty message_protection_order;
		static ConfigurationProperty message_security_version;
		static ConfigurationProperty require_derived_keys;
		static ConfigurationProperty require_security_context_cancellation;
		static ConfigurationProperty require_signature_confirmation;
		static ConfigurationProperty security_header_layout;

		static SecurityElementBase ()
		{
			properties = new ConfigurationPropertyCollection ();
			allow_serialized_signing_token_on_reply = new ConfigurationProperty ("allowSerializedSigningTokenOnReply",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			authentication_mode = new ConfigurationProperty ("authenticationMode",
				typeof (AuthenticationMode), "SspiNegotiated", null/* FIXME: get converter for AuthenticationMode*/, null,
				ConfigurationPropertyOptions.None);

			binding_element_type = new ConfigurationProperty ("",
				typeof (Type), null, new TypeConverter (), null,
				ConfigurationPropertyOptions.None);

			default_algorithm_suite = new ConfigurationProperty ("defaultAlgorithmSuite",
				typeof (SecurityAlgorithmSuite), "Default", null/* FIXME: get converter for SecurityAlgorithmSuite*/, null,
				ConfigurationPropertyOptions.None);

			include_timestamp = new ConfigurationProperty ("includeTimestamp",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			issued_token_parameters = new ConfigurationProperty ("issuedTokenParameters",
				typeof (IssuedTokenParametersElement), null, null/* FIXME: get converter for IssuedTokenParametersElement*/, null,
				ConfigurationPropertyOptions.None);

			key_entropy_mode = new ConfigurationProperty ("keyEntropyMode",
				typeof (SecurityKeyEntropyMode), "CombinedEntropy", null/* FIXME: get converter for SecurityKeyEntropyMode*/, null,
				ConfigurationPropertyOptions.None);

			local_client_settings = new ConfigurationProperty ("localClientSettings",
				typeof (LocalClientSecuritySettingsElement), null, null/* FIXME: get converter for LocalClientSecuritySettingsElement*/, null,
				ConfigurationPropertyOptions.None);

			local_service_settings = new ConfigurationProperty ("localServiceSettings",
				typeof (LocalServiceSecuritySettingsElement), null, null/* FIXME: get converter for LocalServiceSecuritySettingsElement*/, null,
				ConfigurationPropertyOptions.None);

			message_protection_order = new ConfigurationProperty ("messageProtectionOrder",
				typeof (MessageProtectionOrder), "SignBeforeEncryptAndEncryptSignature", null/* FIXME: get converter for MessageProtectionOrder*/, null,
				ConfigurationPropertyOptions.None);

			message_security_version = new ConfigurationProperty ("messageSecurityVersion",
				typeof (MessageSecurityVersion), "Default", null/* FIXME: get converter for MessageSecurityVersion*/, null,
				ConfigurationPropertyOptions.None);

			require_derived_keys = new ConfigurationProperty ("requireDerivedKeys",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			require_security_context_cancellation = new ConfigurationProperty ("requireSecurityContextCancellation",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			require_signature_confirmation = new ConfigurationProperty ("requireSignatureConfirmation",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			security_header_layout = new ConfigurationProperty ("securityHeaderLayout",
				typeof (SecurityHeaderLayout), "Strict", null/* FIXME: get converter for SecurityHeaderLayout*/, null,
				ConfigurationPropertyOptions.None);

			properties.Add (allow_serialized_signing_token_on_reply);
			properties.Add (authentication_mode);
			properties.Add (binding_element_type);
			properties.Add (default_algorithm_suite);
			properties.Add (include_timestamp);
			properties.Add (issued_token_parameters);
			properties.Add (key_entropy_mode);
			properties.Add (local_client_settings);
			properties.Add (local_service_settings);
			properties.Add (message_protection_order);
			properties.Add (message_security_version);
			properties.Add (require_derived_keys);
			properties.Add (require_security_context_cancellation);
			properties.Add (require_signature_confirmation);
			properties.Add (security_header_layout);
		}

		public SecurityElementBase ()
		{
		}


		// Properties

		[ConfigurationProperty ("allowSerializedSigningTokenOnReply",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool AllowSerializedSigningTokenOnReply {
			get { return (bool) base [allow_serialized_signing_token_on_reply]; }
			set { base [allow_serialized_signing_token_on_reply] = value; }
		}

		[ConfigurationProperty ("authenticationMode",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "SspiNegotiated")]
		public AuthenticationMode AuthenticationMode {
			get { return (AuthenticationMode) base [authentication_mode]; }
			set { base [authentication_mode] = value; }
		}

		public override Type BindingElementType {
			get { return (Type) base [binding_element_type]; }
		}

		[ConfigurationProperty ("defaultAlgorithmSuite",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "Default")]
		[TypeConverter ()]
		public SecurityAlgorithmSuite DefaultAlgorithmSuite {
			get { return (SecurityAlgorithmSuite) base [default_algorithm_suite]; }
			set { base [default_algorithm_suite] = value; }
		}

		[ConfigurationProperty ("includeTimestamp",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = true)]
		public bool IncludeTimestamp {
			get { return (bool) base [include_timestamp]; }
			set { base [include_timestamp] = value; }
		}

		[ConfigurationProperty ("issuedTokenParameters",
			 Options = ConfigurationPropertyOptions.None)]
		public IssuedTokenParametersElement IssuedTokenParameters {
			get { return (IssuedTokenParametersElement) base [issued_token_parameters]; }
		}

		[ConfigurationProperty ("keyEntropyMode",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "CombinedEntropy")]
		public SecurityKeyEntropyMode KeyEntropyMode {
			get { return (SecurityKeyEntropyMode) base [key_entropy_mode]; }
			set { base [key_entropy_mode] = value; }
		}

		[ConfigurationProperty ("localClientSettings",
			 Options = ConfigurationPropertyOptions.None)]
		public LocalClientSecuritySettingsElement LocalClientSettings {
			get { return (LocalClientSecuritySettingsElement) base [local_client_settings]; }
		}

		[ConfigurationProperty ("localServiceSettings",
			 Options = ConfigurationPropertyOptions.None)]
		public LocalServiceSecuritySettingsElement LocalServiceSettings {
			get { return (LocalServiceSecuritySettingsElement) base [local_service_settings]; }
		}

		[ConfigurationProperty ("messageProtectionOrder",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "SignBeforeEncryptAndEncryptSignature")]
		public MessageProtectionOrder MessageProtectionOrder {
			get { return (MessageProtectionOrder) base [message_protection_order]; }
			set { base [message_protection_order] = value; }
		}

		[ConfigurationProperty ("messageSecurityVersion",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "Default")]
		[TypeConverter ()]
		public MessageSecurityVersion MessageSecurityVersion {
			get { return (MessageSecurityVersion) base [message_security_version]; }
			set { base [message_security_version] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[ConfigurationProperty ("requireDerivedKeys",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = true)]
		public bool RequireDerivedKeys {
			get { return (bool) base [require_derived_keys]; }
			set { base [require_derived_keys] = value; }
		}

		[ConfigurationProperty ("requireSecurityContextCancellation",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = true)]
		public bool RequireSecurityContextCancellation {
			get { return (bool) base [require_security_context_cancellation]; }
			set { base [require_security_context_cancellation] = value; }
		}

		[ConfigurationProperty ("requireSignatureConfirmation",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool RequireSignatureConfirmation {
			get { return (bool) base [require_signature_confirmation]; }
			set { base [require_signature_confirmation] = value; }
		}

		[ConfigurationProperty ("securityHeaderLayout",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "Strict")]
		public SecurityHeaderLayout SecurityHeaderLayout {
			get { return (SecurityHeaderLayout) base [security_header_layout]; }
			set { base [security_header_layout] = value; }
		}


	}

}
