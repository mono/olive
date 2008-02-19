//
// StandardBindingElement.cs
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
	public abstract partial class StandardBindingElement
		 : ConfigurationElement,  IBindingConfigurationElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty close_timeout;
		static ConfigurationProperty name;
		static ConfigurationProperty open_timeout;
		static ConfigurationProperty receive_timeout;
		static ConfigurationProperty send_timeout;

		internal static ConfigurationPropertyCollection PropertiesInternal {
			get { return properties; }
		}

		static StandardBindingElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			close_timeout = new ConfigurationProperty ("closeTimeout",
				typeof (TimeSpan), "00:01:00", null/* FIXME: get converter for TimeSpan*/, null,
				ConfigurationPropertyOptions.None);

			name = new ConfigurationProperty ("name",
				typeof (string), null, new StringConverter (), null,
				ConfigurationPropertyOptions.IsRequired| ConfigurationPropertyOptions.IsKey);

			open_timeout = new ConfigurationProperty ("openTimeout",
				typeof (TimeSpan), "00:01:00", null/* FIXME: get converter for TimeSpan*/, null,
				ConfigurationPropertyOptions.None);

			receive_timeout = new ConfigurationProperty ("receiveTimeout",
				typeof (TimeSpan), "00:10:00", null/* FIXME: get converter for TimeSpan*/, null,
				ConfigurationPropertyOptions.None);

			send_timeout = new ConfigurationProperty ("sendTimeout",
				typeof (TimeSpan), "00:01:00", null/* FIXME: get converter for TimeSpan*/, null,
				ConfigurationPropertyOptions.None);

			properties.Add (close_timeout);
			properties.Add (name);
			properties.Add (open_timeout);
			properties.Add (receive_timeout);
			properties.Add (send_timeout);
		}

		protected StandardBindingElement ()
		{
		}
		
		protected StandardBindingElement (string name) {
			Name = name;
		}


		// Properties
		protected abstract Type BindingElementType { get;  }

		[ConfigurationProperty ("closeTimeout",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "00:01:00")]
		[TypeConverter ()]
		public TimeSpan CloseTimeout {
			get { return (TimeSpan) base [close_timeout]; }
			set { base [close_timeout] = value; }
		}

		[StringValidator ( MinLength = 1,
			MaxLength = int.MaxValue,
			 InvalidCharacters = null)]
		[ConfigurationProperty ("name",
			 Options = ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsKey,
			IsRequired = true,
			IsKey = true)]
		public string Name {
			get { return (string) base [name]; }
			set { base [name] = value; }
		}

		[TypeConverter ()]
		[ConfigurationProperty ("openTimeout",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "00:01:00")]
		public TimeSpan OpenTimeout {
			get { return (TimeSpan) base [open_timeout]; }
			set { base [open_timeout] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[TypeConverter ()]
		[ConfigurationProperty ("receiveTimeout",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "00:10:00")]
		public TimeSpan ReceiveTimeout {
			get { return (TimeSpan) base [receive_timeout]; }
			set { base [receive_timeout] = value; }
		}

		[TypeConverter ()]
		[ConfigurationProperty ("sendTimeout",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "00:01:00")]
		public TimeSpan SendTimeout {
			get { return (TimeSpan) base [send_timeout]; }
			set { base [send_timeout] = value; }
		}


	}

}
