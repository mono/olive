using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

using XPI = System.Xml.Linq.XProcessingInstruction;


namespace System.Xml.Linq
{
	public abstract class XContainer : XNode
	{
		internal XContainer ()
		{
		}

#if LIST_BASED
		List <object> list = new List <object> ();

		public XNode FirstNode {
			get { return list.Count > 0 ? (XNode) list [0] : null; }
		}

		public XNode LastNode{
			get { return list.Count > 0 ? (XNode) list [list.Count - 1] : null; }
		}
#else
		XNode lastChild;

		public XNode FirstNode {
			get { return lastChild != null ? lastChild.InternalNext : null; }
		}

		public XNode LastNode {
			get { return lastChild; }
		}
#endif

		void CheckChildType (object o)
		{
			if (o == null || o is string || o is XNode)
				return;
			if (o is IEnumerable) {
				foreach (object oc in ((IEnumerable) o))
					CheckChildType (oc);
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
//			if (content is XAttribute) {
//				AddAttribute ((XAttribute) content);
//				return;
//			}
			CheckChildType (content);
#if LIST_BASED
			if (content is XNode)
				((XNode) content).Parent = this as XElement;
			list.Add (content);
#else
			XNode n = XUtil.ToNode (content);
			n.Parent = this as XElement;
			if (lastChild == null) {
				lastChild = n;
				n.InternalNext = n;
			}
			else {
				XNode firstChild = lastChild != null ? lastChild.InternalNext : null;
				lastChild.UpdateTree (this, n);
				n.UpdateTree (this, firstChild);
			}
#endif
		}

		public void Add (params object [] content)
		{
			for (int i = 0; i < content.Length; i++)
				Add (content [i]);
		}

		public void AddFirst (object content)
		{
			if (content == null)
				return;
//			if (content is XAttribute) {
//				AddAttribute ((XAttribute) content);
//				return;
//			}
			CheckChildType (content);
#if LIST_BASED
			if (content is XNode)
				((XNode) content).Parent = this as XElement;
			list.Insert (0, content);
#else
			XNode n = XUtil.ToNode (content);
			n.Parent = this as XElement;
			if (lastChild == null) {
				lastChild = n;
				n.InternalNext = n;
			}
			else {
				n.UpdateTree (this, lastChild.InternalNext);
				lastChild.UpdateTree (this, n);
			}
#endif
		}

		public void AddFirst (params object [] content)
		{
			for (int i = content.Length - 1; i >= 0; i--)
				AddFirst (content [i]);
		}

		[MonoTODO]
		public XmlWriter CreateWriter ()
		{
			throw new NotImplementedException ();
		}

#if LIST_BASED
		internal object GetNextSibling (object target)
		{
			int i = list.IndexOf (target);
			return i + 1 == list.Count ? null : list [i + 1];
		}

		internal void InsertBefore (object from, object target)
		{
//			if (target is XAttribute) {
//				AddAttribute ((XAttribute) target);
//				return;
//			}
			CheckChildType (target);
			int index = list.IndexOf (from);
			if (target is XNode)
				((XNode) target).Parent = this as XElement;
			list.Insert (index, target);
		}

		internal void InsertBefore (object from, params object [] target)
		{
			foreach (object o in target)
				CheckChildType (o);
			if (target.Length == 0)
				return;
			int index = list.IndexOf (from);
			if (index == 0) {
				List <object> tmp = list;
				list = new List <object> (list.Count + target.Length);
				Add (target);
				list.AddRange (tmp);
			} else {
				InsertAfter (list [index - 1], target);
			}
		}

		internal void InsertAfter (object from, object target)
		{
//			if (target is XAttribute) {
//				AddAttribute ((XAttribute) target);
//				return;
//			}
			CheckChildType (target);
			int index = list.IndexOf (from);
			if (target is XNode)
				((XNode) target).Parent = this as XElement;
			list.Insert (index + 1, target);
		}

		internal void InsertAfter (object from, params object [] target)
		{
			for (int i = 0; i < target.Length; i++) {
				CheckChildType (target [i]);
				InsertAfter (from, target [i]);
				from = target [i];
			}
		}

		internal void RemoveChild (object target)
		{
			list.Remove (target);
		}
#endif

		public IEnumerable <XNode> Nodes ()
		{
#if LIST_BASED
			foreach (XNode n in list)
				yield return n;
#else
			//return new XChildrenIterator (this);
			for (XNode n = FirstNode; n != null; n = n.NextNode)
				yield return n;
#endif
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

		/*
		public void ReadContentFrom (XmlReader reader)
		{
			if (reader.IsEmptyElement)
				reader.Read ();
			else {
				reader.Read ();
				do {
					if (reader.NodeType == XmlNodeType.EndElement)
						// end of the element.
						break;
					if (reader.NodeType == XmlNodeType.Text)
						Add (reader.Value);
					else
						Add (XNode.ReadFrom (reader));
				} while (reader.Read ());
				reader.Read ();
			}
		}
		*/

		public void RemoveNodes ()
		{
#if LIST_BASED
			foreach (object o in list)
				if (o is XNode)
					((XNode) o).Parent = null;
#else
			foreach (XNode n in Nodes ())
				n.Remove ();
#endif
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
	}
}
