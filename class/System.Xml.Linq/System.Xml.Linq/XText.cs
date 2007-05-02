using System;
using System.IO;
using System.Text;
using System.Xml;

namespace System.Xml.Linq
{
	public class XText : XNode
	{
		string value;

		public XText (string value)
		{
			this.value = value;
		}

		public XText (XText other)
		{
			value = other.value;
		}

		public override XmlNodeType NodeType {
			get { return XmlNodeType.Text; }
		}

		public string Value {
			get { return value; }
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				this.value = value;
			}
		}

		public override void WriteTo (XmlWriter w)
		{
			w.WriteString (value);
		}
	}
}
