using System;
using System.Xml;

namespace System.Xml.Linq
{
	public class XProcessingInstruction : XNode
	{
		string name;
		string value;

		public XProcessingInstruction (string name, string value)
		{
			this.name = name;
			this.value = value;
		}

		public XProcessingInstruction (XProcessingInstruction other)
		{
			if (other == null)
				throw new ArgumentNullException ("other");
			this.name = other.name;
			this.value = other.value;
		}

		public string Data {
			get { return value; }
			set { this.value = value; }
		}

		public override XmlNodeType NodeType {
			get { return XmlNodeType.ProcessingInstruction; }
		}

		public string Target {
			get { return name; }
			set { name = value; }
		}

		public override void WriteTo (XmlWriter w)
		{
			w.WriteProcessingInstruction (name, value);
		}
	}
}
