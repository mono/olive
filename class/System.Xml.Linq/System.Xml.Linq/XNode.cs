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

#if !LIST_BASED
		XNode next;
#endif
		static XNodeEqualityComparer eq_comparer =
			new XNodeEqualityComparer ();
		static XNodeDocumentOrderComparer order_comparer =
			new XNodeDocumentOrderComparer ();

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
			get {
				if (Parent == null || object.ReferenceEquals (Parent.FirstNode, this))
					return null;
#if LIST_BASED
				IEnumerator e = Parent.Nodes ().GetEnumerator ();
				for (object o = null; e.MoveNext (); o = e.Current)
					if (object.ReferenceEquals (e.Current, this))
						return (XNode) o;
				return null;
#else
				for (XNode n = Parent.LastNode.next; n != null; n = n.next)
					if (n.next == this)
						return n;
				return null;
#endif
			}
		}

		public XNode NextNode {
			get {
				if (Parent == null || object.ReferenceEquals (Parent.LastNode, this))
					return null;
#if LIST_BASED
				return (XNode) Parent.GetNextSibling (this);
#else
				return next;
#endif
			}
		}

#if !LIST_BASED
		internal XNode InternalNext {
			get { return next; }
			set { next = value; }
		}
#endif

#if !LIST_BASED
		internal void UpdateTree (XContainer parent, XNode next)
		{
			this.Parent = parent as XElement;
			this.next = next;
		}
#endif

		public string Xml {
			get {
				StringWriter sw = new StringWriter ();
				XmlWriter xw = XmlWriter.Create (sw);
				WriteTo (xw);
				xw.Close ();
				return sw.ToString ();
			}
		}

		public void AddAfterSelf (object content)
		{
			if (Parent == null)
				throw new InvalidOperationException ();
#if LIST_BASED
			Parent.InsertAfter (this, content);
#else
			/*
			XNode n = XUtil.ToNode (content);
			n.Parent = Parent;
			n.next = next;
			next = n;
			if (Parent.LastNode == null || object.ReferenceEquals (Parent.LastNode, this))
				Parent.LastNode = n;
			*/
			throw new NotImplementedException ();
#endif
		}

		public void AddAfterSelf (params object [] content)
		{
			if (Parent == null)
				throw new InvalidOperationException ();
#if LIST_BASED
			Parent.InsertAfter (this, content);
#else
			/*
			foreach (object o in new XFilterIterator <object> (content, null))
				AddAfterSelf (o);
			*/
			throw new NotImplementedException ();
#endif
		}

		public void AddBeforeSelf (object content)
		{
			if (Parent == null)
				throw new InvalidOperationException ();
#if LIST_BASED
			Parent.InsertBefore (this, content);
#else
			/*
			XNode n = XUtil.ToNode (content);
			n.Parent = Parent;
			n.next = this;
			XNode p = PreviousSibling;
			if (p != null)
				PreviousSibling.next = n;
			else
				Parent.LastChild.next = this;
			if (Parent.LastChild == null || object.ReferenceEquals (Parent.LastChild, this))
				Parent.LastChild = n;
			*/
			throw new NotImplementedException ();
#endif
		}

		public void AddBeforeSelf (params object [] content)
		{
			if (Parent == null)
				throw new InvalidOperationException ();
#if LIST_BASED
			Parent.InsertBefore (this, content);
#else
			/*
			foreach (object o in new XFilterIterator <object> (content, null))
				AddBeforeSelf (o);
			*/
			throw new NotImplementedException ();
#endif
		}

		public static XNode ReadFrom (XmlReader r)
		{
			switch (r.NodeType) {
			case XmlNodeType.Element:
				return XElement.Load (r);
			case XmlNodeType.Text:
				throw new InvalidOperationException ();
			case XmlNodeType.CDATA:
				return new XCData (r.Value);
			case XmlNodeType.ProcessingInstruction:
				return new XPI (r.Name, r.Value);
			case XmlNodeType.Comment:
				return new XComment (r.Value);
			case XmlNodeType.DocumentType:
				return new XDocumentType (r.Name,
					r.GetAttribute ("PUBLIC"),
					r.GetAttribute ("System"),
					r.Value);
			default:
				throw new NotSupportedException ();
			}
		}

		public void Remove ()
		{
#if LIST_BASED
			Parent.RemoveChild (this);
#else
			PreviousNode.next = NextNode;
			Parent = null;
#endif
		}

		public override string ToString ()
		{
			return Xml;
		}

		public abstract void WriteTo (XmlWriter w);

		[MonoTODO]
		public IEnumerable<XElement> Ancestors ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public IEnumerable<XElement> Ancestors (XName name)
		{
			throw new NotImplementedException ();
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
