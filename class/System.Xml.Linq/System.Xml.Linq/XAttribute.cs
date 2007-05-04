using System;
using System.Collections.Generic;
using System.Xml;

namespace System.Xml.Linq
{
	public class XAttribute : XObject
	{
		static readonly XAttribute [] empty_array = new XAttribute [0];

		public static IEnumerable <XAttribute> EmptySequence {
			get { return empty_array; }
		}

		XName name;
		object value;
		XAttribute next;
		XAttribute previous;

		public XAttribute (XAttribute other)
		{
			if (other == null)
				throw new ArgumentNullException ("other");
			name = other.name;
			value = other.value;
		}

		public XAttribute (XName name, object value)
		{
			if (name == null)
				throw new ArgumentNullException ("name");
			this.name = name;
			SetValue (value);
		}

		public bool IsNamespaceDeclaration {
			get { return name.Namespace == XNamespace.Xmlns || (name.LocalName == "xmlns" && name.Namespace == XNamespace.Blank); }
		}

		public XName Name {
			get { return name; }
		}

		public XAttribute NextAttribute {
			get { return next; }
			internal set { next = value; }
		}

		public override XmlNodeType NodeType {
			get { return XmlNodeType.Attribute; }
		}

		public XAttribute PreviousAttribute {
			get { return previous; }
			internal set { previous = value; }
		}

		public string Value {
			get { return XUtil.ToString (value); }
			set { this.value = value; }
		}

		public void Remove ()
		{
			if (Parent != null) {
				if (next != null)
					next.previous = previous;
				if (previous != null)
					previous.next = next;
				if (Parent.FirstAttribute == this)
					Parent.FirstAttribute = next;
				if (Parent.LastAttribute == this)
					Parent.LastAttribute = previous;
				SetOwner (null);
			}
			next = null;
			previous = null;
		}

		[MonoTODO]
		public void SetValue (object value)
		{
			this.value = XUtil.ToString (value);
		}

		[MonoTODO]
		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	}
}
