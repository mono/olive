using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

using XPI = System.Xml.Linq.XProcessingInstruction;


namespace System.Xml.Linq
{
	public class XDocumentType : XNode
	{
		string name, pubid, sysid, intSubset;

		public XDocumentType (string name, string publicId, string systemId, string internalSubset)
		{
			this.name = name;
			pubid = publicId;
			sysid = systemId;
			intSubset = internalSubset;
		}

		public XDocumentType (XDocumentType other)
		{
			if (other == null)
				throw new ArgumentNullException ("other");
			name = other.name;
			pubid = other.pubid;
			sysid = other.sysid;
			intSubset = other.intSubset;
		}

		public string Name {
			get { return name; }
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				name = value;
			}
		}

		public string PublicId {
			get { return pubid; }
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				pubid = value;
			}
		}

		public string SystemId {
			get { return sysid; }
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				sysid = value;
			}
		}

		public string InternalSubset {
			get { return intSubset; }
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				intSubset = value;
			}
		}

		public override XmlNodeType NodeType {
			get { return XmlNodeType.DocumentType; }
		}

		public override void WriteTo (XmlWriter w)
		{
			XDocument doc = Document;
			XElement root = doc.Root;
			if (root != null)
				w.WriteDocType (root.Name.LocalName, pubid, sysid, intSubset);
		}
	}
}
