//
// ClientCredentialsElement.cs
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
	public partial class ClientCredentialsElement
		 : BehaviorExtensionElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty behavior_type;
		static ConfigurationProperty client_certificate;
		static ConfigurationProperty http_digest;
		static ConfigurationProperty issued_token;
		static ConfigurationProperty peer;
		static ConfigurationProperty service_certificate;
		static ConfigurationProperty support_interactive;
		static ConfigurationProperty type;
		static ConfigurationProperty windows;

		static ClientCredentialsElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			behavior_type = new ConfigurationProperty ("",
				typeof (Type), null, new TypeConverter (), null,
				ConfigurationPropertyOptions.None);

			client_certificate = new ConfigurationProperty ("clientCertificate",
				typeof (X509InitiatorCertificateClientElement), null, null/* FIXME: get converter for X509InitiatorCertificateClientElement*/, null,
				ConfigurationPropertyOptions.None);

			http_digest = new ConfigurationProperty ("httpDigest",
				typeof (HttpDigestClientElement), null, null/* FIXME: get converter for HttpDigestClientElement*/, null,
				ConfigurationPropertyOptions.None);

			issued_token = new ConfigurationProperty ("issuedToken",
				typeof (IssuedTokenClientElement), null, null/* FIXME: get converter for IssuedTokenClientElement*/, null,
				ConfigurationPropertyOptions.None);

			peer = new ConfigurationProperty ("peer",
				typeof (PeerCredentialElement), null, null/* FIXME: get converter for PeerCredentialElement*/, null,
				ConfigurationPropertyOptions.None);

			service_certificate = new ConfigurationProperty ("serviceCertificate",
				typeof (X509RecipientCertificateClientElement), null, null/* FIXME: get converter for X509RecipientCertificateClientElement*/, null,
				ConfigurationPropertyOptions.None);

			support_interactive = new ConfigurationProperty ("supportInteractive",
				typeof (bool), "true", new BooleanConverter (), null,
				ConfigurationPropertyOptions.None);

			type = new ConfigurationProperty ("type",
				typeof (string), "", new StringConverter (), null,
				ConfigurationPropertyOptions.None);

			windows = new ConfigurationProperty ("windows",
				typeof (WindowsClientElement), null, null/* FIXME: get converter for WindowsClientElement*/, null,
				ConfigurationPropertyOptions.None);

			properties.Add (behavior_type);
			properties.Add (client_certificate);
			properties.Add (http_digest);
			properties.Add (issued_token);
			properties.Add (peer);
			properties.Add (service_certificate);
			properties.Add (support_interactive);
			properties.Add (type);
			properties.Add (windows);
		}

		public ClientCredentialsElement ()
		{
		}


		// Properties

		public override Type BehaviorType {
			get { return (Type) base [behavior_type]; }
		}

		[ConfigurationProperty ("clientCertificate",
			 Options = ConfigurationPropertyOptions.None)]
		public X509InitiatorCertificateClientElement ClientCertificate {
			get { return (X509InitiatorCertificateClientElement) base [client_certificate]; }
		}

		[ConfigurationProperty ("httpDigest",
			 Options = ConfigurationPropertyOptions.None)]
		public HttpDigestClientElement HttpDigest {
			get { return (HttpDigestClientElement) base [http_digest]; }
		}

		[ConfigurationProperty ("issuedToken",
			 Options = ConfigurationPropertyOptions.None)]
		public IssuedTokenClientElement IssuedToken {
			get { return (IssuedTokenClientElement) base [issued_token]; }
		}

		[ConfigurationProperty ("peer",
			 Options = ConfigurationPropertyOptions.None)]
		public PeerCredentialElement Peer {
			get { return (PeerCredentialElement) base [peer]; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[ConfigurationProperty ("serviceCertificate",
			 Options = ConfigurationPropertyOptions.None)]
		public X509RecipientCertificateClientElement ServiceCertificate {
			get { return (X509RecipientCertificateClientElement) base [service_certificate]; }
		}

		[ConfigurationProperty ("supportInteractive",
			DefaultValue = true,
			 Options = ConfigurationPropertyOptions.None)]
		public bool SupportInteractive {
			get { return (bool) base [support_interactive]; }
			set { base [support_interactive] = value; }
		}

		[ConfigurationProperty ("type",
			 DefaultValue = "",
			 Options = ConfigurationPropertyOptions.None)]
		[StringValidator ( MinLength = 0,
			MaxLength = int.MaxValue,
			 InvalidCharacters = null)]
		public string Type {
			get { return (string) base [type]; }
			set { base [type] = value; }
		}

		[ConfigurationProperty ("windows",
			 Options = ConfigurationPropertyOptions.None)]
		public WindowsClientElement Windows {
			get { return (WindowsClientElement) base [windows]; }
		}


	}

}
