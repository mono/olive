//
// IssuedTokenParametersElement.cs
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
	public sealed partial class IssuedTokenParametersElement
		 : ConfigurationElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty additional_request_parameters;
		static ConfigurationProperty claim_type_requirements;
		static ConfigurationProperty issuer;
		static ConfigurationProperty issuer_metadata;
		static ConfigurationProperty key_size;
		static ConfigurationProperty key_type;
		static ConfigurationProperty token_type;

		static IssuedTokenParametersElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			additional_request_parameters = new ConfigurationProperty ("additionalRequestParameters",
				typeof (XmlElementElementCollection), null, null/* FIXME: get converter for XmlElementElementCollection*/, null,
				ConfigurationPropertyOptions.None);

			claim_type_requirements = new ConfigurationProperty ("claimTypeRequirements",
				typeof (ClaimTypeElementCollection), null, null/* FIXME: get converter for ClaimTypeElementCollection*/, null,
				ConfigurationPropertyOptions.None);

			issuer = new ConfigurationProperty ("issuer",
				typeof (IssuedTokenParametersEndpointAddressElement), null, null/* FIXME: get converter for IssuedTokenParametersEndpointAddressElement*/, null,
				ConfigurationPropertyOptions.None);

			issuer_metadata = new ConfigurationProperty ("issuerMetadata",
				typeof (EndpointAddressElementBase), null, null/* FIXME: get converter for EndpointAddressElementBase*/, null,
				ConfigurationPropertyOptions.None);

			key_size = new ConfigurationProperty ("keySize",
				typeof (int), "0", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			key_type = new ConfigurationProperty ("keyType",
				typeof (SecurityKeyType), "SymmetricKey", null/* FIXME: get converter for SecurityKeyType*/, null,
				ConfigurationPropertyOptions.None);

			token_type = new ConfigurationProperty ("tokenType",
				typeof (string), "", new StringConverter (), null,
				ConfigurationPropertyOptions.None);

			properties.Add (additional_request_parameters);
			properties.Add (claim_type_requirements);
			properties.Add (issuer);
			properties.Add (issuer_metadata);
			properties.Add (key_size);
			properties.Add (key_type);
			properties.Add (token_type);
		}

		public IssuedTokenParametersElement ()
		{
		}


		// Properties

		[ConfigurationProperty ("additionalRequestParameters",
			 Options = ConfigurationPropertyOptions.None)]
		public XmlElementElementCollection AdditionalRequestParameters {
			get { return (XmlElementElementCollection) base [additional_request_parameters]; }
		}

		[ConfigurationProperty ("claimTypeRequirements",
			 Options = ConfigurationPropertyOptions.None)]
		public ClaimTypeElementCollection ClaimTypeRequirements {
			get { return (ClaimTypeElementCollection) base [claim_type_requirements]; }
		}

		[ConfigurationProperty ("issuer",
			 Options = ConfigurationPropertyOptions.None)]
		public IssuedTokenParametersEndpointAddressElement Issuer {
			get { return (IssuedTokenParametersEndpointAddressElement) base [issuer]; }
		}

		[ConfigurationProperty ("issuerMetadata",
			 Options = ConfigurationPropertyOptions.None)]
		public EndpointAddressElementBase IssuerMetadata {
			get { return (EndpointAddressElementBase) base [issuer_metadata]; }
		}

		[ConfigurationProperty ("keySize",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "0")]
		[IntegerValidator ( MinValue = 0,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		public int KeySize {
			get { return (int) base [key_size]; }
			set { base [key_size] = value; }
		}

		[ConfigurationProperty ("keyType",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "SymmetricKey")]
		public SecurityKeyType KeyType {
			get { return (SecurityKeyType) base [key_type]; }
			set { base [key_type] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[StringValidator ( MinLength = 0,
			MaxLength = int.MaxValue,
			 InvalidCharacters = null)]
		[ConfigurationProperty ("tokenType",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "")]
		public string TokenType {
			get { return (string) base [token_type]; }
			set { base [token_type] = value; }
		}


	}

}
