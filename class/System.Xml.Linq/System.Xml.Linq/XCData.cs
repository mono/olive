using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace System.Xml.Linq
{
	public class XCData : XText
	{
		public XCData (string value)
			: base (value)
		{
		}

		public XCData (XCData other)
			: base (other)
		{
		}

		public override XmlNodeType NodeType {
			get { return XmlNodeType.CDATA; }
		}

		public override void WriteTo (XmlWriter w)
		{
			int start = 0;
			StringBuilder sb = null;
			for (int i = 0; i < Value.Length - 2; i++) {
				if (Value [i] == ']' && Value [i + 1] == ']'
					&& Value [i + 2] == '>') {
					if (sb == null)
						sb = new StringBuilder ();
					sb.Append (Value, start, i - start);
					sb.Append ("]]&gt;");
					start = i + 3;
				}
			}
			if (start != 0 && start != Value.Length)
				sb.Append (Value, start, Value.Length - start);
			w.WriteCData (sb == null ? Value : sb.ToString ());
		}
	}
}
