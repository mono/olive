//
// IssuedTokenServiceElement.cs
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
	public sealed partial class IssuedTokenServiceElement
		 : ConfigurationElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty allow_untrusted_rsa_issuers;
		static ConfigurationProperty known_certificates;
		static ConfigurationProperty saml_serializer_type;

		static IssuedTokenServiceElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			allow_untrusted_rsa_issuers = new ConfigurationProperty ("allowUntrustedRsaIssuers",
				typeof (bool), "false", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			known_certificates = new ConfigurationProperty ("knownCertificates",
				typeof (X509CertificateTrustedIssuerElementCollection), null, null/* FIXME: get converter for X509CertificateTrustedIssuerElementCollection*/, null,
				ConfigurationPropertyOptions.None);

			saml_serializer_type = new ConfigurationProperty ("samlSerializerType",
				typeof (string), "", new StringConverter (), null,
				ConfigurationPropertyOptions.None);

			properties.Add (allow_untrusted_rsa_issuers);
			properties.Add (known_certificates);
			properties.Add (saml_serializer_type);
		}

		public IssuedTokenServiceElement ()
		{
		}


		// Properties

		[ConfigurationProperty ("allowUntrustedRsaIssuers",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = false)]
		public bool AllowUntrustedRsaIssuers {
			get { return (bool) base [allow_untrusted_rsa_issuers]; }
			set { base [allow_untrusted_rsa_issuers] = value; }
		}

		[ConfigurationProperty ("knownCertificates",
			 Options = ConfigurationPropertyOptions.None)]
		public X509CertificateTrustedIssuerElementCollection KnownCertificates {
			get { return (X509CertificateTrustedIssuerElementCollection) base [known_certificates]; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[ConfigurationProperty ("samlSerializerType",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "")]
		[StringValidator ( MinLength = 0,
			MaxLength = int.MaxValue,
			 InvalidCharacters = null)]
		public string SamlSerializerType {
			get { return (string) base [saml_serializer_type]; }
			set { base [saml_serializer_type] = value; }
		}


	}

}
