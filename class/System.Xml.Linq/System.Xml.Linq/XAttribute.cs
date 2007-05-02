using System;
using System.Collections.Generic;
using System.Xml;

namespace System.Xml.Linq
{
	public class XAttribute : XObject
	{
		static IEnumerable <XAttribute> emptySequence =
			new List <XAttribute> ();

		public static IEnumerable <XAttribute> EmptySequence {
			get { return emptySequence; }
		}

		XName name;
		object value;
		XAttribute next;
		XAttribute previous;

		public XAttribute (XAttribute source)
		{
			name = source.name;
			value = source.value;
		}

		public XAttribute (XName name, object value)
		{
			this.name = name;
			this.value = XUtil.ToString (value);
		}

		[MonoTODO]
		public bool IsNamespaceDeclaration {
			get { throw new NotImplementedException (); }
		}

		public XName Name {
			get { return name; }
		}

		[MonoTODO]
		public XAttribute NextAttribute {
			get { return next; }
		}

		[MonoTODO]
		public override XmlNodeType NodeType {
			get { return XmlNodeType.Attribute; }
		}

		[MonoTODO]
		public XAttribute PreviousAttribute {
			get { return previous; }
		}

		public string Value {
			get { return XUtil.ToString (value); }
			set { this.value = value; }
		}

		/*
		public override bool Equals (object obj)
		{
			XAttribute a = obj as XAttribute;
			if (a == null)
				return false;
			return a.Name == name && a.value == value;
		}

		public override int GetHashCode ()
		{
			return name.GetHashCode () ^ value.GetHashCode ();
		}

		public static explicit operator bool (XAttribute a)
		{
			return XUtil.ToBoolean (a.value);
		}

		public static explicit operator Nullable <bool> (XAttribute a)
		{
			return a.value == null || String.Empty == a.value as string ?
				null : XUtil.ToNullableBoolean (a.value);
		}

		// FIXME: similar conversion methods follow.
		*/

		public void Remove ()
		{
			next = null;
			previous = null;

			if (Parent != null) {
				Parent.InternalRemoveAttribute (this);
				Parent = null;
			}
		}

		[MonoTODO]
		public void SetValue (object value)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	}
}
