//
// ServiceThrottlingElement.cs
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
	public sealed partial class ServiceThrottlingElement
		 : BehaviorExtensionElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty behavior_type;
		static ConfigurationProperty max_concurrent_calls;
		static ConfigurationProperty max_concurrent_instances;
		static ConfigurationProperty max_concurrent_sessions;

		static ServiceThrottlingElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			behavior_type = new ConfigurationProperty ("",
				typeof (Type), null, new TypeConverter (), null,
				ConfigurationPropertyOptions.None);

			max_concurrent_calls = new ConfigurationProperty ("maxConcurrentCalls",
				typeof (int), "16", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			max_concurrent_instances = new ConfigurationProperty ("maxConcurrentInstances",
				typeof (int), "int.MaxValue", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			max_concurrent_sessions = new ConfigurationProperty ("maxConcurrentSessions",
				typeof (int), "10", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			properties.Add (behavior_type);
			properties.Add (max_concurrent_calls);
			properties.Add (max_concurrent_instances);
			properties.Add (max_concurrent_sessions);
		}

		public ServiceThrottlingElement ()
		{
		}


		// Properties

		public override Type BehaviorType {
			get { return (Type) base [behavior_type]; }
		}

		[IntegerValidator ( MinValue = 1,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		[ConfigurationProperty ("maxConcurrentCalls",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "16")]
		public int MaxConcurrentCalls {
			get { return (int) base [max_concurrent_calls]; }
			set { base [max_concurrent_calls] = value; }
		}

		[ConfigurationProperty ("maxConcurrentInstances",
			 Options = ConfigurationPropertyOptions.None,
			DefaultValue = int.MaxValue)]
		[IntegerValidator ( MinValue = 1,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		public int MaxConcurrentInstances {
			get { return (int) base [max_concurrent_instances]; }
			set { base [max_concurrent_instances] = value; }
		}

		[IntegerValidator ( MinValue = 1,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		[ConfigurationProperty ("maxConcurrentSessions",
			 Options = ConfigurationPropertyOptions.None,
			 DefaultValue = "10")]
		public int MaxConcurrentSessions {
			get { return (int) base [max_concurrent_sessions]; }
			set { base [max_concurrent_sessions] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}


	}

}
