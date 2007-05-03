using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

using XPI = System.Xml.Linq.XProcessingInstruction;

namespace System.Xml.Linq
{
	public abstract class XNode : XObject
	{
		[MonoTODO]
		public static int CompareDocumentOrder (XNode n1, XNode n2)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static bool DeepEquals (XNode n1, XNode n2)
		{
			throw new NotImplementedException ();
		}

		static XNodeEqualityComparer eq_comparer =
			new XNodeEqualityComparer ();
		static XNodeDocumentOrderComparer order_comparer =
			new XNodeDocumentOrderComparer ();

		XNode previous;
		XNode next;

		internal XNode ()
		{
		}

		public static XNodeDocumentOrderComparer DocumentOrderComparer {
			get { return order_comparer; }
		}

		public static XNodeEqualityComparer EqualityComparer {
			get { return eq_comparer; }
		}

		public XNode PreviousNode {
			get { return previous; }
			internal set { previous = value; }
		}

		public XNode NextNode {
			get { return next; }
			internal set { next = value; }
		}

		public string ToString (SaveOptions options)
		{
			StringWriter sw = new StringWriter ();
			XmlWriterSettings s = new XmlWriterSettings ();
			if ((options & SaveOptions.DisableFormatting) == 0) {
				// hacky!
				s.Indent = true;
				s.IndentChars = String.Empty;
				s.NewLineChars = String.Empty;
			}
			XmlWriter xw = XmlWriter.Create (sw, s);
			WriteTo (xw);
			xw.Close ();
			return sw.ToString ();
		}

		public void AddAfterSelf (object content)
		{
			if (Parent == null)
				throw new InvalidOperationException ();
			XNode n = XUtil.ToNode (content);
			n.Parent = Parent;
			n.previous = this;
			next = n;
			if (Parent.LastNode == this)
				Parent.LastNode = n;
		}

		public void AddAfterSelf (params object [] content)
		{
			if (Parent == null)
				throw new InvalidOperationException ();
			foreach (object o in content)
				AddAfterSelf (o);
		}

		public void AddBeforeSelf (object content)
		{
			if (Parent == null)
				throw new InvalidOperationException ();
			XNode n = XUtil.ToNode (content);
			n.Parent = Parent;
			n.next = this;
			previous = n;
			if (Parent.FirstNode == this)
				Parent.FirstNode = n;
		}

		public void AddBeforeSelf (params object [] content)
		{
			if (Parent == null)
				throw new InvalidOperationException ();
			for (int i = content.Length - 1; i >= 0; i--)
				AddBeforeSelf (content [i]);
		}

		public static XNode ReadFrom (XmlReader r)
		{
			switch (r.NodeType) {
			case XmlNodeType.Element:
				return XElement.Load (r);
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
			case XmlNodeType.Text:
				XText t = new XText (r.Value);
				r.Read ();
				return t;
			case XmlNodeType.CDATA:
				XCData c = new XCData (r.Value);
				r.Read ();
				return c;
			case XmlNodeType.ProcessingInstruction:
				XPI pi = new XPI (r.Name, r.Value);
				r.Read ();
				return pi;
			case XmlNodeType.Comment:
				XComment cm = new XComment (r.Value);
				r.Read ();
				return cm;
			case XmlNodeType.DocumentType:
				XDocumentType d = new XDocumentType (r.Name,
					r.GetAttribute ("PUBLIC"),
					r.GetAttribute ("System"),
					r.Value);
				r.Read ();
				return d;
			default:
				throw new NotSupportedException (String.Format ("Node type {0} is not supported", r.NodeType));
			}
		}

		public void Remove ()
		{
			PreviousNode.next = NextNode;
			previous = null;
			next = null;
			Parent = null;
		}

		public override string ToString ()
		{
			return ToString (SaveOptions.None);
		}

		public abstract void WriteTo (XmlWriter w);

		public IEnumerable<XElement> Ancestors ()
		{
			for (XElement el = Parent; el != null; el = el.Parent)
				yield return el;
		}

		public IEnumerable<XElement> Ancestors (XName name)
		{
			foreach (XElement el in Ancestors ())
				if (el.Name == name)
					yield return el;
		}

		[MonoTODO]
		public XmlReader CreateReader ()
		{
			throw new NotImplementedException ();
		}

		public IEnumerable<XElement> ElementsAfterSelf ()
		{
			foreach (XNode n in NodesAfterSelf ())
				if (n is XElement)
					yield return (XElement) n;
		}

		public IEnumerable<XElement> ElementsAfterSelf (XName name)
		{
			foreach (XElement el in ElementsAfterSelf ())
				if (el.Name == name)
					yield return el;
		}

		public IEnumerable<XElement> ElementsBeforeSelf ()
		{
			foreach (XNode n in NodesBeforeSelf ())
				if (n is XElement)
					yield return (XElement) n;
		}

		public IEnumerable<XElement> ElementsBeforeSelf (XName name)
		{
			foreach (XElement el in ElementsBeforeSelf ())
				if (el.Name == name)
					yield return el;
		}

		public bool IsAfter (XNode other)
		{
			return XNode.DocumentOrderComparer.Compare (this, other) > 0;
		}

		public bool IsBefore (XNode other)
		{
			return XNode.DocumentOrderComparer.Compare (this, other) < 0;
		}

		public IEnumerable<XNode> NodesAfterSelf ()
		{
			if (Parent == null)
				yield break;
			for (XNode n = NextNode; n != null; n = n.NextNode)
				yield return n;
		}

		public IEnumerable<XNode> NodesBeforeSelf ()
		{
			for (XNode n = Parent.FirstNode; n != this; n = n.NextNode)
				yield return n;
		}

		[MonoTODO]
		public void ReplaceWith (object item)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void ReplaceWith (params object [] item)
		{
			throw new NotImplementedException ();
		}
	}
}
