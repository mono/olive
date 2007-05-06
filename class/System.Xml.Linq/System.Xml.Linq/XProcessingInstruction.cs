using System;
using System.Xml;

namespace System.Xml.Linq
{
	public class XProcessingInstruction : XNode
	{
		string name;
		string data;

		public XProcessingInstruction (string name, string data)
		{
			if (name == null)
				throw new ArgumentNullException ("name");
			if (data == null)
				throw new ArgumentNullException ("data");
			this.name = name;
			this.data = data;
		}

		public XProcessingInstruction (XProcessingInstruction other)
		{
			if (other == null)
				throw new ArgumentNullException ("other");
			this.name = other.name;
			this.data = other.data;
		}

		public string Data {
			get { return data; }
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				this.data = value;
			}
		}

		public override XmlNodeType NodeType {
			get { return XmlNodeType.ProcessingInstruction; }
		}

		public string Target {
			get { return name; }
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				name = value;
			}
		}

		public override void WriteTo (XmlWriter w)
		{
			w.WriteProcessingInstruction (name, data);
		}
	}
}
