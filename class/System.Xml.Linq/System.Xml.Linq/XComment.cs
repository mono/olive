using System;
using System.Xml;

namespace System.Xml.Linq
{
	public class XComment : XNode
	{
		string value;

		public XComment (string value)
		{
			this.value = value;
		}

		public XComment (XComment other)
		{
			this.value = other.value;
		}

		public override XmlNodeType NodeType {
			get { return XmlNodeType.Comment; }
		}

		public string Value {
			get { return value; }
			set { this.value = value; }
		}

		public override void WriteTo (XmlWriter w)
		{
			w.WriteComment (value);
		}
	}
}
