using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace System.Xml.Linq
{
	public class XDeclaration
	{
		string encoding, standalone, version;

		public XDeclaration (string version, string encoding, string standalone)
		{
			this.version = version;
			this.encoding = encoding;
			this.standalone = standalone;
		}

		public XDeclaration (XDeclaration other)
		{
			if (other == null)
				throw new ArgumentNullException ("other");
			this.version = other.version;
			this.encoding = other.encoding;
			this.standalone = other.standalone;
		}

		public string Encoding {
			get { return encoding; }
			set { encoding = value; }
		}

		public string Standalone {
			get { return standalone; }
			set { standalone = value; }
		}

		public string Version {
			get { return version; }
			set { version = value; }
		}

		public override string ToString ()
		{
			return String.Concat ("<?xml",
				version != null ? " version=\"" : null,
				version != null ?  version : null,
				version != null ? "\"" : null,
				encoding != null ? " encoding=\"" : null,
				encoding != null ?  encoding : null,
				encoding != null ? "\"" : null,
				standalone != null ? " standalone=\"" : null,
				standalone != null ?  standalone : null,
				standalone != null ? "\"" : null,
				"?>");
		}

		/*
		public override void WriteTo (XmlWriter w)
		{
			StringBuilder sb = new StringBuilder ();
			sb.AppendFormat ("version=\"{0}\"", version);
			if (encoding != null)
				sb.AppendFormat (" encoding=\"{0}\"", encoding);
			if (standalone != null)
				sb.AppendFormat (" standalone=\"{0}\"", standalone);
			// "xml" is not allowed PI, but because of nasty
			// XmlWriter API design it must pass.
			w.WriteProcessingInstruction ("xml", sb.ToString ());
		}
		*/
	}
}
