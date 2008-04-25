//
// Authors:
//	Andreas Nahr (ClassDevelopment@A-SoftTech.com>)
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

using System;

namespace System.Workflow.ComponentModel.Serialization
{
	[AttributeUsage (AttributeTargets.Assembly, AllowMultiple = true)]
	public sealed class XmlnsPrefixAttribute : Attribute
	{
		private String prefix;
		private String xmlNamespace;

		public XmlnsPrefixAttribute (String xmlNamespace, String prefix)
		{
			if (xmlNamespace == null)
				throw new ArgumentNullException ("xmlNamespace");
			if (prefix == null)
				throw new ArgumentNullException ("prefix");

			this.xmlNamespace = xmlNamespace;
			this.prefix = prefix;
		}

		public String Prefix {
			get { return prefix; }
		}

		public String XmlNamespace {
			get { return xmlNamespace; }
		}
	}
}
