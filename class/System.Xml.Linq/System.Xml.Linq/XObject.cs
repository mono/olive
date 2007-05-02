using System;
using System.Collections.Generic;

namespace System.Xml.Linq
{
	public abstract class XObject
	{
		internal XObject ()
		{
		}

		XElement parent;
		List<object> annotations;

		public event XObjectChangeEventHandler Changing;
		public event XObjectChangeEventHandler Changed;

		public XDocument Document {
			get {
				XContainer e = Parent;
				if (e == null)
					return null;
				do {
					XContainer p = e.Parent;
					if (p == null)
						return e as XDocument; // might be XElement
				} while (true);
			}
		}

		public abstract XmlNodeType NodeType { get; }

		public XElement Parent {
			get { return parent; }
			internal set { parent = value; }
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
	}
}
