using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

using XPI = System.Xml.Linq.XProcessingInstruction;


namespace System.Xml.Linq
{
	public class XDocument : XContainer
	{
		XDeclaration xmldecl;

		public XDocument ()
		{
		}

		public XDocument (params object [] content)
		{
			Add (content);
		}

		public XDocument (XDeclaration xmldecl, params object [] content)
		{
			Declaration = xmldecl;
			Add (content);
		}

		public XDocument (XDocument other)
		{
			foreach (object o in other.Nodes ())
				Add (XUtil.Clone (o));
		}

		public XDeclaration Declaration {
			get { return xmldecl; }
			set { xmldecl = value; }
		}

		public XDocumentType DocumentType {
			get {
				foreach (object o in Nodes ())
					if (o is XDocumentType)
						return (XDocumentType) o;
				return null;
			}
		}

		public override XmlNodeType NodeType {
			get { return XmlNodeType.Document; }
		}

		public XElement Root {
			get {
				foreach (object o in Nodes ())
					if (o is XElement)
						return (XElement) o;
				return null;
			}
		}

		public static XDocument Load (string uri)
		{
			return Load (uri, false);
		}

		public static XDocument Load (string uri, bool preserveWhitespaces)
		{
			XmlReaderSettings s = new XmlReaderSettings ();
			s.IgnoreWhitespace = !preserveWhitespaces;
			using (XmlReader r = XmlReader.Create (uri, s)) {
				return Load (r);
			}
		}

		public static XDocument Load (TextReader reader)
		{
			return Load (reader, false);
		}

		public static XDocument Load (TextReader reader, bool preserveWhitespaces)
		{
			XmlReaderSettings s = new XmlReaderSettings ();
			s.IgnoreWhitespace = !preserveWhitespaces;
			using (XmlReader r = XmlReader.Create (reader, s)) {
				return Load (r);
			}
		}

		public static XDocument Load (XmlReader reader)
		{
			XDocument doc = new XDocument ();
			if (reader.ReadState == ReadState.Initial)
				reader.Read ();
			if (reader.NodeType == XmlNodeType.XmlDeclaration) {
				doc.Declaration = new XDeclaration (
					reader.GetAttribute ("version"),
					reader.GetAttribute ("encoding"),
					reader.GetAttribute ("standalone"));
				reader.Read ();
			}
			/*
			if (reader.NodeType == XmlNodeType.DocumentType) {
				doc.Add (new XDocumentType (
					reader.Name,
					reader.GetAttribute ("PUBLIC"),
					reader.GetAttribute ("SYSTEM"),
					reader.Value));
				reader.Read ();
			}
			*/
			for (; !reader.EOF; reader.Read ())
				if (reader.NodeType == XmlNodeType.Text)
					doc.Add (reader.Value);
				else
					doc.Add (XNode.ReadFrom (reader));
			return doc;
		}

		public static XDocument Parse (string s)
		{
			return Parse (s, false);
		}

		public static XDocument Parse (string s, bool preserveWhitespaces)
		{
			return Load (new StringReader (s), preserveWhitespaces);
		}

		public void Save (string filename)
		{
			Save (filename, false);
		}

		public void Save (string filename, bool ignoreWhitespaces)
		{
			XmlWriterSettings s = new XmlWriterSettings ();
			if (ignoreWhitespaces) {
				// hacky!
				s.Indent = true;
				s.IndentChars = String.Empty;
				s.NewLineChars = String.Empty;
			}
			using (XmlWriter w = XmlWriter.Create (filename)) {
				Save (w);
			}
		}

		public void Save (TextWriter tw)
		{
			Save (tw, false);
		}

		public void Save (TextWriter tw, bool ignoreWhitespaces)
		{
			XmlWriterSettings s = new XmlWriterSettings ();
			if (ignoreWhitespaces) {
				// hacky!
				s.Indent = true;
				s.IndentChars = String.Empty;
				s.NewLineChars = String.Empty;
			}
			using (XmlWriter w = XmlWriter.Create (tw)) {
				Save (w);
			}
		}

		public void Save (XmlWriter w)
		{
			WriteTo (w);
		}

		public override void WriteTo (XmlWriter w)
		{
			if (xmldecl != null) {
				if (xmldecl.Standalone != null)
					w.WriteStartDocument (xmldecl.Standalone == "yes");
				else
					w.WriteStartDocument ();
			}
			foreach (XNode node in Nodes ())
				node.WriteTo (w);
		}
	}
}
