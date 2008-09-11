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
// Copyright (c) 2008 Novell, Inc. (http://www.novell.com)
//

namespace System.Windows.Markup {

	public class NamespaceMapEntry {

		public NamespaceMapEntry ()
		{
		}

		public NamespaceMapEntry (string xmlNamespace, string assemblyName, string clrNamespace)
		{
			if (xmlNamespace == null ||
			    assemblyName == null ||
			    clrNamespace == null)
				throw new ArgumentNullException ();

			this.xmlNamespace = xmlNamespace;
			this.assemblyName = assemblyName;
			this.clrNamespace = clrNamespace;
		}

		public string XmlNamespace {
			get { return xmlNamespace; }
			set {
				if (value == null)
					throw new ArgumentNullException ();
				xmlNamespace = value;
			}
		}

		public string AssemblyName {
			get { return assemblyName; }
			set {
				if (value == null)
					throw new ArgumentNullException ();
				assemblyName = value;
			}
		}

		public string ClrNamespace {
			get { return clrNamespace; }
			set {
				if (value == null)
					throw new ArgumentNullException ();
				clrNamespace = value;
			}
		}

		string xmlNamespace;
		string assemblyName;
		string clrNamespace;
	}

}