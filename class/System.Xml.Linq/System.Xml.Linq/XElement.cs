using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.Xml.Linq
{
	[XmlRoot ("XElement")]
	[XmlSchemaProvider ("GetSchemaType")]
	public class XElement : XContainer, IXmlSerializable
	{
		static IEnumerable <XElement> emptySequence =
			new List <XElement> ();

		public static IEnumerable <XElement> EmptySequence {
			get { return emptySequence; }
		}

		XName name;
		XAttribute attr_first, attr_last;

		public XElement (XName name, object value)
		{
			SetElementValue (name, value);
		}

		public XElement (XElement source)
		{
			name = source.name;
			Add (source.Nodes ());
		}

		public XElement (XName name)
		{
			this.name = name;
		}

		public XElement (XName name, params object [] contents)
		{
			this.name = name;
			Add (contents);
		}

		public XAttribute FirstAttribute {
			get { return attr_first; }
			internal set { attr_first = value; }
		}

		public XAttribute LastAttribute {
			get { return attr_last; }
			internal set { attr_last = value; }
		}

		public bool HasAttributes {
			get { return attr_first != null; }
		}

		public bool HasElements {
			get {
				foreach (object o in Nodes ())
					if (o is XElement)
						return true;
				return false;
			}
		}

		public bool IsEmpty {
			get { return !Nodes ().GetEnumerator ().MoveNext (); }
		}

		public XName Name {
			get { return name; }
			set {
				if (name == null)
					throw new ArgumentNullException ("value");
				name = value;
			}
		}

		public override XmlNodeType NodeType {
			get { return XmlNodeType.Element; }
		}

		public string Value {
			get {
				StringBuilder sb = null;
				foreach (object s in Nodes ()) {
					if (sb == null)
						sb = new StringBuilder ();
					sb.Append (s);
				}
				return sb == null ? String.Empty : sb.ToString ();
			}
			set {
				RemoveNodes ();
				Add (value);
			}
		}

		IEnumerable <XElement> GetAncestorList (XName name, bool getMeIn)
		{
			List <XElement> list = new List <XElement> ();
			if (getMeIn)
				list.Add (this);
			for (XElement el = Parent as XElement; el != null; el = el.Parent as XElement)
				if (name == null || el.Name == name)
					list.Add (el);
			return list;
		}

		public XAttribute Attribute (XName name)
		{
			foreach (XAttribute a in Attributes ())
				if (a.Name == name)
					return a;
			return null;
		}

		public IEnumerable <XAttribute> Attributes ()
		{
			XAttribute next;
			for (XAttribute a = attr_first; a != null; a = next) {
				next = a.NextAttribute;
				yield return a;
			}
		}

		// huh?
		public IEnumerable <XAttribute> Attributes (XName name)
		{
			foreach (XAttribute a in Attributes ())
				if (a.Name == name)
					yield return a;
		}

		public static XElement Load (string uri)
		{
			return Load (uri, LoadOptions.None);
		}

		public static XElement Load (string uri, LoadOptions options)
		{
			XmlReaderSettings s = new XmlReaderSettings ();
			s.IgnoreWhitespace = (options & LoadOptions.PreserveWhitespace) == 0;
			using (XmlReader r = XmlReader.Create (uri, s)) {
				return LoadCore (r);
			}
		}

		public static XElement Load (TextReader tr)
		{
			return Load (tr, LoadOptions.None);
		}

		public static XElement Load (TextReader tr, LoadOptions options)
		{
			XmlReaderSettings s = new XmlReaderSettings ();
			s.IgnoreWhitespace = (options & LoadOptions.PreserveWhitespace) == 0;
			using (XmlReader r = XmlReader.Create (tr, s)) {
				return LoadCore (r);
			}
		}

		public static XElement Load (XmlReader reader)
		{
			return Load (reader, LoadOptions.None);
		}

		public static XElement Load (XmlReader reader, LoadOptions options)
		{
			XmlReaderSettings s = reader.Settings.Clone ();
			s.IgnoreWhitespace = (options & LoadOptions.PreserveWhitespace) == 0;
			using (XmlReader r = XmlReader.Create (reader, s)) {
				return LoadCore (r);
			}
		}

		static XElement LoadCore (XmlReader r)
		{
			r.MoveToContent ();
			if (r.NodeType != XmlNodeType.Element)
				throw new InvalidOperationException ("The XmlReader must be positioned at an element");
			XName name = XName.Get (r.LocalName, r.NamespaceURI);
			XElement e = new XElement (name);
			if (r.MoveToFirstAttribute ()) {
				do {
					// not sure how current Orcas behavior makes sense here though ...
					if (r.LocalName == "xmlns" && r.NamespaceURI == XNamespace.Xmlns.NamespaceName)
						e.SetAttributeValue (XNamespace.Blank.GetName ("xmlns"), r.Value);
					else
						e.SetAttributeValue (XName.Get (r.LocalName, r.NamespaceURI), r.Value);
				} while (r.MoveToNextAttribute ());
				r.MoveToElement ();
			}
			if (!r.IsEmptyElement) {
				r.Read ();
				e.ReadContentFrom (r);
				r.ReadEndElement ();
			}
			else
				r.Read ();
			return e;
		}

		public static XElement Parse (string s)
		{
			return Parse (s, LoadOptions.None);
		}

		public static XElement Parse (string s, LoadOptions options)
		{
			return Load (new StringReader (s), options);
		}

		public void RemoveAll ()
		{
			RemoveAttributes ();
			RemoveNodes ();
		}

		public void RemoveAttributes ()
		{
			while (attr_first != null)
				attr_last.Remove ();
		}

		public void Save (string filename)
		{
			Save (filename, SaveOptions.None);
		}

		public void Save (string filename, SaveOptions options)
		{
			XmlWriterSettings s = new XmlWriterSettings ();
			if ((options & SaveOptions.DisableFormatting) != 0) {
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
			if ((options & SaveOptions.DisableFormatting) != 0) {
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

		public IEnumerable <XElement> AncestorsAndSelf ()
		{
			return GetAncestorList (null, true);
		}

		public IEnumerable <XElement> AncestorsAndSelf (XName name)
		{
			return GetAncestorList (name, true);
		}

		public IEnumerable <XElement> DescendantsAndSelf ()
		{
			List <XElement> list = new List <XElement> ();
			list.Add (this);
			list.AddRange (Descendants ());
			return list;
		}

		public IEnumerable <XElement> DescendantsAndSelf (XName name)
		{
			List <XElement> list = new List <XElement> ();
			if (name == this.name)
				list.Add (this);
			list.AddRange (Descendants (name));
			return list;
		}

		public IEnumerable <XNode> DescendantNodesAndSelf ()
		{
			yield return this;
			foreach (XNode node in DescendantNodes ())
				yield return node;
		}

		public void SetAttributeValue (XName name, object value)
		{
			XAttribute a = Attribute (name);
			if (value == null) {
				if (a != null)
					a.Remove ();
			} else {
				if (a == null) {
					a = new XAttribute (name, value);
					a.SetOwner (this);
					if (attr_first == null) {
						attr_first = a;
						attr_last = a;
					} else {
						attr_last.NextAttribute = a;
						a.PreviousAttribute = attr_last;
						attr_last = a;
					}
				}
				else
					a.Value = XUtil.ToString (value);
			}
		}

		public override void WriteTo (XmlWriter w)
		{
			w.WriteStartElement (name.LocalName, name.Namespace.NamespaceName);

			foreach (XAttribute a in Attributes ()) {
				if (a.Name.Namespace == XNamespace.Xmlns && a.Name.LocalName != String.Empty)
					w.WriteAttributeString ("xmlns", a.Name.LocalName, XNamespace.Xmlns.NamespaceName, a.Value);
				else
					w.WriteAttributeString (a.Name.LocalName, a.Name.Namespace.NamespaceName, a.Value);
			}

			foreach (XNode node in Nodes ())
				node.WriteTo (w);

			w.WriteEndElement ();
		}

		public XNamespace GetDefaultNamespace ()
		{
			for (XElement el = this; el != null; el = el.Parent)
				foreach (XAttribute a in el.Attributes ())
					if (a.IsNamespaceDeclaration && a.Name.Namespace == XNamespace.Blank)
						return XNamespace.Get (a.Value);
			return XNamespace.Blank; // nothing is declared.
		}

		public XNamespace GetNamespaceOfPrefix (string prefix)
		{
			for (XElement el = this; el != null; el = el.Parent)
				foreach (XAttribute a in el.Attributes ())
					if (a.IsNamespaceDeclaration && a.Name.LocalName == prefix)
						return XNamespace.Get (a.Value);
			return XNamespace.Blank; // nothing is declared.
		}

		public string GetPrefixOfNamespace (XNamespace ns)
		{
			foreach (string prefix in GetPrefixOfNamespaceCore (ns))
				if (GetNamespaceOfPrefix (prefix) == ns)
					return prefix;
			return null; // nothing is declared
		}
		
		IEnumerable<string> GetPrefixOfNamespaceCore (XNamespace ns)
		{
			for (XElement el = this; el != null; el = el.Parent)
				foreach (XAttribute a in el.Attributes ())
					if (a.IsNamespaceDeclaration && a.Value == ns.NamespaceName)
						yield return a.Name.Namespace == XNamespace.Blank ? String.Empty : a.Name.LocalName;
		}

		public void ReplaceAll (object item)
		{
			RemoveNodes ();
			Add (item);
		}

		public void ReplaceAll (params object [] items)
		{
			RemoveNodes ();
			Add (items);
		}

		public void ReplaceAttributes (object item)
		{
			RemoveAttributes ();
			Add (item);
		}

		public void ReplaceAttributes (params object [] items)
		{
			RemoveAttributes ();
			Add (items);
		}

		public void SetElementValue (XName name, object value)
		{
			XElement el = new XElement (name, value);
			RemoveNodes ();
			Add (el);
		}

		public void SetValue (object value)
		{
			XNode n = XUtil.ToNode (value);
			RemoveNodes ();
			Add (n);
		}

		internal override void OnAdded (XNode node, bool addFirst)
		{
			if (node is XDocument || node is XDocumentType)
				throw new ArgumentException (String.Format ("A node of type {0} cannot be added as a content", node.GetType ()));
		}

		[MonoTODO]
		public static XmlSchemaType GetSchemaType (XmlSchemaSet schemas)
		{
			throw new NotImplementedException ();
		}

		void IXmlSerializable.WriteXml (XmlWriter writer)
		{
			Save (writer);
		}

		void IXmlSerializable.ReadXml (XmlReader reader)
		{
			ReadContentFrom (reader);
		}

		XmlSchema IXmlSerializable.GetSchema ()
		{
			return null;
		}
	}
}
