//
// System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement
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

namespace System.Workflow.Runtime.Configuration {

	public sealed class WorkflowRuntimeServiceElement : ConfigurationElement
	{
		NameValueCollection parameters;
		static ConfigurationProperty typeProp;
		static ConfigurationPropertyCollection properties;

		static WorkflowRuntimeServiceElement ()
			{
				typeProp = new ConfigurationProperty ("type", typeof (string), "");
				properties = new ConfigurationPropertyCollection ();

				properties.Add (typeProp);
			}

		protected override bool OnDeserializeUnrecognizedAttribute (string name, string value)
		{
			if (parameters == null)
				parameters = new NameValueCollection ();

			parameters [name] = value;
			return true;
		}

		[ConfigurationProperty ("type")]
			public string Type {
			get { return (string) base [typeProp];}
			set { base[typeProp] = value; }
		}

		public NameValueCollection Parameters {
			get {
				if (parameters == null)
					parameters = new NameValueCollection ();
				return parameters;
			}
		}

		protected override ConfigurationPropertyCollection Properties {
			get { return properties; }
		}

	}

}
