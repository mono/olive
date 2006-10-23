//
// BinaryMessageEncodingElement.cs
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
	public sealed partial class BinaryMessageEncodingElement
		 : BindingElementExtensionElement
	{
		// Static Fields
		static ConfigurationPropertyCollection properties;
		static ConfigurationProperty binding_element_type;
		static ConfigurationProperty max_read_pool_size;
		static ConfigurationProperty max_session_size;
		static ConfigurationProperty max_write_pool_size;
		static ConfigurationProperty reader_quotas;

		static BinaryMessageEncodingElement ()
		{
			properties = new ConfigurationPropertyCollection ();
			binding_element_type = new ConfigurationProperty ("",
				typeof (Type), null, new TypeConverter (), null,
				ConfigurationPropertyOptions.None);

			max_read_pool_size = new ConfigurationProperty ("maxReadPoolSize",
				typeof (int), "64", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			max_session_size = new ConfigurationProperty ("maxSessionSize",
				typeof (int), "2048", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			max_write_pool_size = new ConfigurationProperty ("maxWritePoolSize",
				typeof (int), "16", null/* FIXME: get converter for int*/, null,
				ConfigurationPropertyOptions.None);

			reader_quotas = new ConfigurationProperty ("readerQuotas",
				typeof (XmlDictionaryReaderQuotasElement), null, null/* FIXME: get converter for XmlDictionaryReaderQuotasElement*/, null,
				ConfigurationPropertyOptions.None);

			properties.Add (binding_element_type);
			properties.Add (max_read_pool_size);
			properties.Add (max_session_size);
			properties.Add (max_write_pool_size);
			properties.Add (reader_quotas);
		}

		public BinaryMessageEncodingElement ()
		{
		}


		// Properties

		public override Type BindingElementType {
			get { return (Type) base [binding_element_type]; }
		}

		[IntegerValidator ( MinValue = 1,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		[ConfigurationProperty ("maxReadPoolSize",
			 DefaultValue = "64",
			 Options = ConfigurationPropertyOptions.None)]
		public int MaxReadPoolSize {
			get { return (int) base [max_read_pool_size]; }
			set { base [max_read_pool_size] = value; }
		}

		[IntegerValidator ( MinValue = 0,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		[ConfigurationProperty ("maxSessionSize",
			 DefaultValue = "2048",
			 Options = ConfigurationPropertyOptions.None)]
		public int MaxSessionSize {
			get { return (int) base [max_session_size]; }
			set { base [max_session_size] = value; }
		}

		[ConfigurationProperty ("maxWritePoolSize",
			 DefaultValue = "16",
			 Options = ConfigurationPropertyOptions.None)]
		[IntegerValidator ( MinValue = 1,
			MaxValue = int.MaxValue,
			ExcludeRange = false)]
		public int MaxWritePoolSize {
			get { return (int) base [max_write_pool_size]; }
			set { base [max_write_pool_size] = value; }
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

		[ConfigurationProperty ("readerQuotas",
			 Options = ConfigurationPropertyOptions.None)]
		public XmlDictionaryReaderQuotasElement ReaderQuotas {
			get { return (XmlDictionaryReaderQuotasElement) base [reader_quotas]; }
		}


	}

}
