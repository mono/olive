using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace System.Xml.Linq
{
	public abstract class XContainer : XNode
	{
		internal XContainer ()
		{
		}

		XNode first;
		XNode last;

		public XNode FirstNode {
			get { return first; }
			internal set { first = value; }
		}

		public XNode LastNode {
			get { return last; }
			internal set { last = value; }
		}

		void CheckChildType (object o, bool addFirst)
		{
			if (o == null || o is string || o is XNode)
				return;
			if (o is IEnumerable) {
				foreach (object oc in ((IEnumerable) o))
					CheckChildType (oc, addFirst);
				return;
			}
			else
				throw new ArgumentException ("Invalid child type: " + o.GetType ());
		}

/*
		private void AddAttribute (XAttribute attr)
		{
			if (this is XElement)
				((XElement) this).SetAttributeNode (attr);
			else
				throw new ArgumentException ("Attribute is not allowed here.");
		}
*/

		public void Add (object content)
		{
			if (content == null)
				return;

			XNode n = XUtil.ToNode (content);
			CheckChildType (n, false);
			OnAdded (n, false);
			n.SetOwner (this);
			if (first == null)
				last = first = n;
			else {
				last.NextNode = n;
				n.PreviousNode = last;
				last = n;
			}
		}

		public void Add (params object [] content)
		{
			foreach (object o in XUtil.ShrinkArray (content))
				Add (o);
		}

		public void AddFirst (object content)
		{
			if (first == null)
				Add (content);
			else
				first.AddBeforeSelf (content);
		}

		public void AddFirst (params object [] content)
		{
			if (content == null)
				return;
			if (first == null)
				Add (content);
			else
				first.AddBeforeSelf (content);
		}

		[MonoTODO]
		public XmlWriter CreateWriter ()
		{
			throw new NotImplementedException ();
		}

		public IEnumerable <XNode> Nodes ()
		{
			XNode next;
			for (XNode n = FirstNode; n != null; n = next) {
				next = n.NextNode;
				yield return n;
			}
		}

		public IEnumerable<XNode> DescendantNodes ()
		{
			foreach (XNode n in Nodes ()) {
				yield return n;
				XContainer c = n as XContainer;
				if (c != null)
					foreach (XNode d in c.DescendantNodes ())
						yield return d;
			}
		}

		public IEnumerable <XElement> Descendants ()
		{
			foreach (XNode n in DescendantNodes ()) {
				XElement el = n as XElement;
				if (el != null)
					yield return el;
			}
		}

		public IEnumerable <XElement> Descendants (XName name)
		{
			foreach (XElement el in Descendants ())
				if (el.Name == name)
					yield return el;
		}

		public IEnumerable <XElement> Elements ()
		{
			foreach (XNode n in Nodes ()) {
				XElement el = n as XElement;
				if (el != null)
					yield return el;
			}
		}

		public IEnumerable <XElement> Elements (XName name)
		{
			foreach (XElement el in Elements ())
				if (el.Name == name)
					yield return el;
		}

		public XElement Element (XName name)
		{
			foreach (XElement el in Elements ())
				if (el.Name == name)
					return el;
			return null;
		}

		internal void ReadContentFrom (XmlReader reader)
		{
			while (!reader.EOF) {
				if (reader.NodeType == XmlNodeType.EndElement)
					// end of the element.
					break;
				Add (XNode.ReadFrom (reader));
			}
		}

		public void RemoveNodes ()
		{
			foreach (XNode n in Nodes ())
				n.Remove ();
		}

		public void ReplaceNodes (object content)
		{
			RemoveNodes ();
			Add (content);
		}

		public void ReplaceNodes (params object [] content)
		{
			RemoveNodes ();
			Add (content);
		}

		/*
		public void WriteContentTo (XmlWriter writer)
		{
			foreach (object o in Content ()) {
				if (o is string)
					writer.WriteString ((string) o);
				else if (o is XNode)
					((XNode) o).WriteTo (writer);
				else
					throw new SystemException ("INTERNAL ERROR: list content item was " + o.GetType ());
			}
		}
		*/

		internal virtual void OnAdded (XNode item, bool addFirst)
		{
		}
	}
}
