//
// System.Workflow.Runtime.Configuration.WorkflowRuntimeSettings
//
// Authors:
//	Joel Reed (joelwreed@gmail.com)
//

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
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;

namespace System.Workflow.Runtime.Configuration {

	public sealed class WorkflowRuntimeSection : ConfigurationSection
	{
		static ConfigurationProperty commonParametersProp;
		static ConfigurationProperty nameProp;
		static ConfigurationProperty servicesProp;
		static ConfigurationProperty validateOnCreateProp;
		static ConfigurationPropertyCollection properties;

		static WorkflowRuntimeSection ()
		{
			commonParametersProp = new ConfigurationProperty ("commonParameters", typeof (NameValueConfigurationCollection), null,
																								null, null, ConfigurationPropertyOptions.None);
			nameProp = new ConfigurationProperty ("name", typeof (string), "");
			servicesProp = new ConfigurationProperty ("services", typeof (WorkflowRuntimeServiceElementCollection), null,
																								null, null, ConfigurationPropertyOptions.None);
			validateOnCreateProp = new ConfigurationProperty ("validateOnCreate", typeof (bool), true);

			properties = new ConfigurationPropertyCollection ();

			properties.Add (commonParametersProp);
			properties.Add (nameProp);
			properties.Add (servicesProp);
			properties.Add (validateOnCreateProp);
		}

		[ConfigurationProperty ("name")]
		public string Name {
			get { return (string) base [nameProp]; }
			set { base [nameProp] = value; }
		}

		[ConfigurationProperty ("servicesProp")]
		public WorkflowRuntimeServiceElementCollection Services {
			get { return (WorkflowRuntimeServiceElementCollection) base [servicesProp]; }
		}

		[ConfigurationProperty ("validateOnCreate")]
		public bool ValidateOnCreate {
			get { return (bool) base [validateOnCreateProp];}
			set { base [validateOnCreateProp] = value;}
		}

		[ConfigurationProperty ("commonParameters")]
		public NameValueConfigurationCollection CommonParameters {
			get { return (NameValueConfigurationCollection) base [commonParametersProp];}
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

	}

}
