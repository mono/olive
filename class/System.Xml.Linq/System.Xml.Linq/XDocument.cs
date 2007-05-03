using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

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
			return Load (uri, LoadOptions.None);
		}

		public static XDocument Load (string uri, LoadOptions options)
		{
			XmlReaderSettings s = new XmlReaderSettings ();
			s.IgnoreWhitespace = (options & LoadOptions.PreserveWhitespace) == 0;
			using (XmlReader r = XmlReader.Create (uri, s)) {
				return LoadCore (r);
			}
		}

		public static XDocument Load (TextReader reader)
		{
			return Load (reader, LoadOptions.None);
		}

		public static XDocument Load (TextReader reader, LoadOptions options)
		{
			XmlReaderSettings s = new XmlReaderSettings ();
			s.IgnoreWhitespace = (options & LoadOptions.PreserveWhitespace) == 0;
			using (XmlReader r = XmlReader.Create (reader, s)) {
				return LoadCore (r);
			}
		}

		public static XDocument Load (XmlReader reader)
		{
			return Load (reader, LoadOptions.None);
		}

		public static XDocument Load (XmlReader reader, LoadOptions options)
		{
			XmlReaderSettings s = reader.Settings.Clone ();
			s.IgnoreWhitespace = (options & LoadOptions.PreserveWhitespace) == 0;
			using (XmlReader r = XmlReader.Create (reader, s)) {
				return LoadCore (r);
			}
		}

		static XDocument LoadCore (XmlReader reader)
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
			doc.ReadContentFrom (reader);
			if (doc.Root == null)
				throw new InvalidOperationException ("The document element is missing.");
			return doc;
		}

		static void ValidateWhitespace (string s)
		{
			for (int i = 0; i < s.Length; i++)
				switch (s [i]) {
				case ' ': case '\t': case '\n': case '\r':
					continue;
				default:
					throw new ArgumentException ("Non-whitespace text appears directly in the document.");
				}
		}

		public static XDocument Parse (string s)
		{
			return Parse (s, LoadOptions.None);
		}

		public static XDocument Parse (string s, LoadOptions options)
		{
			return Load (new StringReader (s), options);
		}

		public void Save (string filename)
		{
			Save (filename, SaveOptions.None);
		}

		public void Save (string filename, SaveOptions options)
		{
			XmlWriterSettings s = new XmlWriterSettings ();
			if ((options & SaveOptions.DisableFormatting) == 0) {
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
			Save (tw, SaveOptions.None);
		}

		public void Save (TextWriter tw, SaveOptions options)
		{
			XmlWriterSettings s = new XmlWriterSettings ();
			if ((options & SaveOptions.DisableFormatting) == 0) {
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

		internal override void OnAdded (XNode node, bool addFirst)
		{
			if (node == null)
				throw new InvalidOperationException ("Only a node is allowed here");

			if (node is XText)
				ValidateWhitespace (((XText) node).Value);
			else if (node is XDocumentType) {
				if (DocumentType != null)
					throw new InvalidOperationException ("There already is another document type declaration");
				if (Root != null && !addFirst)
					throw new InvalidOperationException ("A document type cannot be added after the document element");
			}
			else if (node is XElement) {
				if (Root != null)
					throw new InvalidOperationException ("There already is another document element");
				if (DocumentType != null && addFirst)
					throw new InvalidOperationException ("An element cannot be added before the document type declaration");
			}
		}
	}
}
