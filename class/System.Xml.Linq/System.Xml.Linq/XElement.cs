using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

using XPI = System.Xml.Linq.XProcessingInstruction;


namespace System.Xml.Linq
{
	public class XElement : XContainer
	{
		static IEnumerable <XElement> emptySequence =
			new List <XElement> ();

		public static IEnumerable <XElement> EmptySequence {
			get { return emptySequence; }
		}

		XName name;
		List <XAttribute> attributes;

		public XElement (XName name, object value)
		{
			SetElementValue (name, value);
		}

		public XElement (XElement source)
		{
			name = source.name;
			Add (source.Nodes ());
		}

		// for Load()
		XElement (XmlReader source)
		{
			if (source.NodeType != XmlNodeType.Element)
				throw new InvalidOperationException ();
			name = XName.Get (source.LocalName, source.NamespaceURI);
			if (source.MoveToFirstAttribute ()) {
				do {
					SetAttributeValue (XName.Get (source.LocalName, source.NamespaceURI), source.Value);
				} while (source.MoveToNextAttribute ());
				source.MoveToElement ();
			}
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

		internal List <XAttribute> SafeAttributes {
			get {
				if (attributes == null)
					attributes = new List <XAttribute> ();
				return attributes;
			}
		}

		[MonoTODO]
		public XAttribute FirstAttribute {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public XAttribute LastAttribute {
			get { throw new NotImplementedException (); }
		}

		public bool HasAttributes {
			get { return attributes != null && attributes.Count > 0; }
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
			if (attributes == null)
				return null;
			foreach (XAttribute a in attributes)
				if (a.Name == name)
					return a;
			return null;
		}

		public IEnumerable <XAttribute> Attributes ()
		{
			return attributes != null ? attributes : XAttribute.EmptySequence;
		}

		public IEnumerable <XAttribute> Attributes (XName name)
		{
			XAttribute a = Attribute (name);
			if (a == null)
				return XAttribute.EmptySequence;
			List <XAttribute> list = new List <XAttribute> ();
			list.Add (a);
			return list;
		}

		/*
		public override bool Equals (object obj)
		{
			XElement e = obj as XElement;
			if (e == null || name != e.name)
				return false;
			IEnumerator e1 = Nodes ().GetEnumerator ();
			IEnumerator e2 = e.Nodes ().GetEnumerator ();
			do {
				if (e1.MoveNext ()) {
					if (e2.MoveNext ()) {
						if (!e1.Equals (e2.Current))
							return false;
					}
					else
						return false;
				}
				else if (e2.MoveNext ())
					return false;
			} while (true);
		}

		public override int GetHashCode ()
		{
			int i = name.GetHashCode ();
			foreach (XAttribute a in Attributes ())
				i ^= a.GetHashCode ();
			foreach (object o in Content ())
				i ^= o.GetHashCode ();
			return i;
		}
		*/

		// Only XAttribute.set_Parent() can invoke this.
		internal void InternalAppendAttribute (XAttribute attr)
		{
			if (attr.Parent != this)
				throw new SystemException ("INTERNAL ERROR: should not happen.");
			SafeAttributes.Add (attr);
		}

		internal void InternalRemoveAttribute (XAttribute attr)
		{
			if (attr.Parent != this)
				throw new SystemException ("INTERNAL ERROR: should not happen.");
			attributes.Remove (attr);
		}

		public static XElement Load (string uri)
		{
			return Load (uri, false);
		}

		public static XElement Load (string uri, bool preserveWhitespaces)
		{
			XmlReaderSettings s = new XmlReaderSettings ();
			s.IgnoreWhitespace = !preserveWhitespaces;
			using (XmlReader r = XmlReader.Create (uri, s)) {
				return Load (r);
			}
		}

		public static XElement Load (TextReader tr)
		{
			return Load (tr, false);
		}

		public static XElement Load (TextReader tr, bool preserveWhitespaces)
		{
			XmlReaderSettings s = new XmlReaderSettings ();
			s.IgnoreWhitespace = !preserveWhitespaces;
			using (XmlReader r = XmlReader.Create (tr, s)) {
				return Load (r);
			}
		}

		public static XElement Load (XmlReader r)
		{
			XElement e = new XElement (r);
			using (XmlWriter w = e.CreateWriter ()) {
				if (r.ReadState == ReadState.Initial) {
					while (!r.EOF)
						w.WriteNode (r, false);
				}
				else
					w.WriteNode (r, false);
			}
			return e;
		}

		/*
		public static explicit operator bool (XElement e)
		{
			return e.Value == "true";
		}

		// FIXME: similar operator overloads should go here.
		*/

		public static XElement Parse (string s)
		{
			return Parse (s, false);
		}

		public static XElement Parse (string s, bool preserveWhitespaces)
		{
			return Load (new StringReader (s), preserveWhitespaces);
		}

		public void RemoveAll ()
		{
			RemoveAttributes ();
			RemoveNodes ();
		}

		public void RemoveAttributes ()
		{
			if (attributes != null)
				foreach (XAttribute a in attributes)
					a.Parent = null;
			attributes = null;
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
					new XAttribute (name, value).Parent = this;
				}
				else
					a.Value = XUtil.ToString (value);
			}
		}

		/*
		public void SetAttributeNode (XAttribute attr)
		{
			foreach (XAttribute a in Attributes (attr.Name))
				a.Remove ();
			attr.Parent = this;
		}

		public void SetElement (XName name, object value)
		{
			IEnumerator <XElement> en = Elements (name).GetEnumerator ();
			XElement e = en.MoveNext () ? en.Current : null;
			if (value == null) {
				if (e != null)
					e.Remove ();
			} else {
				if (e == null)
					Add (new XElement (name, value));
				else
					e.Value = XUtil.ToString (value);
			}
		}
		*/

		public override void WriteTo (XmlWriter w)
		{
			w.WriteStartElement (name.LocalName, name.Namespace.Uri);

			if (attributes != null) {
				foreach (XAttribute a in attributes) {
					if (a.Name.Namespace == XNamespace.Xmlns && a.Name.LocalName != String.Empty)
						w.WriteAttributeString ("xmlns", a.Name.LocalName, XNamespace.Xmlns.Uri, a.Value);
					else
						w.WriteAttributeString (a.Name.LocalName, a.Name.Namespace.Uri, a.Value);
				}
			}

			foreach (XNode node in Nodes ())
				node.WriteTo (w);

			w.WriteEndElement ();
		}

		[MonoTODO]
		public XNamespace GetDefaultNamespace ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public XNamespace GetNamespaceOfPrefix (string prefix)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public string GetPrefixOfNamespace (XNamespace ns)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void ReplaceAll (object item)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void ReplaceAll (params object [] items)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void ReplaceAttributes (object item)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void ReplaceAttributes (params object [] items)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void SetElementValue (XName name, object value)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void SetValue (object value)
		{
			throw new NotImplementedException ();
		}
	}
}
