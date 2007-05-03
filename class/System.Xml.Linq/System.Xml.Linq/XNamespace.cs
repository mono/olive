using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace System.Xml.Linq
{
	public sealed class XNamespace
	{
		static readonly XNamespace blank = Get (String.Empty);
		static readonly XNamespace xml = Get ("http://www.w3.org/XML/1998/namespace");
		static readonly XNamespace xmlns = Get ("http://www.w3.org/2000/xmlns/");

		public static XNamespace Blank {
			get { return blank; }
		}

		public static XNamespace Xml {
			get { return xml; }
		}

		public static XNamespace Xmlns {
			get { return xmlns; }
		}

		[MonoTODO]
		public static XNamespace Get (string uri)
		{
			return new XNamespace (uri);
		}

		[MonoTODO]
		public XName GetName (string localName)
		{
			return new XName (localName, this);
		}

		string uri;

		XNamespace (string namespaceName)
		{
			if (namespaceName == null)
				throw new ArgumentNullException ("namespaceName");
			uri = namespaceName;
		}

		public string NamespaceName {
			get { return uri; }
		}

		public override bool Equals (object other)
		{
			XNamespace ns = other as XNamespace;
			return ns != null && uri == ns.uri;
		}

		public static bool operator == (XNamespace o1, XNamespace o2)
		{
			return (object) o1 != null ? o1.Equals (o2) : (object) o2 == null;
		}

		public static bool operator != (XNamespace o1, XNamespace o2)
		{
			return ! (o1 == o2);
		}

		public override int GetHashCode ()
		{
			return uri.GetHashCode ();
		}

		[MonoTODO]
		public override string ToString ()
		{
			return uri.ToString ();
		}
	}
}
