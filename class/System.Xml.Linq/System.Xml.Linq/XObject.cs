using System;
using System.Collections.Generic;
using System.Xml;

namespace System.Xml.Linq
{
	public abstract class XObject : IXmlLineInfo
	{
		internal XObject ()
		{
		}

		XContainer owner;
		List<object> annotations;
		string baseuri;
		int line, column;

		public event XObjectChangeEventHandler Changing;
		public event XObjectChangeEventHandler Changed;

		public string BaseUri {
			get { return baseuri; }
			internal set { baseuri = value; }
		}

		public XDocument Document {
			get {
				if (this is XDocument)
					return (XDocument) this;

				for (XContainer e = owner; e != null; e = e.owner)
					if (e is XDocument)
						return (XDocument) e;
				return null;
			}
		}

		public abstract XmlNodeType NodeType { get; }

		public XElement Parent {
			get { return owner as XElement; }
		}

		internal XContainer Owner {
			get { return owner; }
		}

		internal void SetOwner (XContainer node)
		{
			owner = node;
		}

		public void AddAnnotation (object annotation)
		{
			if (annotation == null)
				throw new ArgumentNullException ("annotation");
			if (annotations == null)
				annotations = new List<object> ();
			annotations.Add (annotation);
		}

		public T Annotation<T> () where T : class
		{
			return (T) Annotation (typeof (T));
		}

		public object Annotation (Type type)
		{
			if (annotations != null)
				foreach (object o in annotations)
					if (o.GetType () == type)
						return o;
			throw new ArgumentException ();
		}

		public IEnumerable<T> Annotations<T> () where T : class
		{
			foreach (T o in Annotations (typeof (T)))
				yield return o;
		}

		public IEnumerable<object> Annotations (Type type)
		{
			if (annotations == null)
				yield break;
			foreach (object o in annotations)
				if (o.GetType () == type)
					yield return o;
		}

		public void RemoveAnnotations<T> () where T : class
		{
			RemoveAnnotations (typeof (T));
		}

		public void RemoveAnnotations (Type type)
		{
			if (annotations == null)
				return;
			for (int i = 0; i < annotations.Count; i++)
				if (annotations [i].GetType () == type)
					annotations.RemoveAt (i);
		}

		[MonoTODO]
		int IXmlLineInfo.LineNumber {
			get { return line; }
		}

		[MonoTODO]
		int IXmlLineInfo.LinePosition {
			get { return column; }
		}

		[MonoTODO]
		bool IXmlLineInfo.HasLineInfo ()
		{
			return line > 0;
		}
	}
}
