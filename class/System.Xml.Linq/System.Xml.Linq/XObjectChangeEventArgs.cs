using System;
using System.Xml;

namespace System.Xml.Linq
{
	public class XObjectChangeEventArgs : EventArgs
	{
		public XObjectChangeEventArgs (XObjectChange change)
		{
			this.type = change;
		}

		// Note that those fields cannot be directly referenced in
		// any object comparisons, as there could be other instances.
		public static readonly XObjectChangeEventArgs Add =
			new XObjectChangeEventArgs (XObjectChange.Add);
		public static readonly XObjectChangeEventArgs Name =
			new XObjectChangeEventArgs (XObjectChange.Name);
		public static readonly XObjectChangeEventArgs Remove =
			new XObjectChangeEventArgs (XObjectChange.Remove);
		public static readonly XObjectChangeEventArgs Value =
			new XObjectChangeEventArgs (XObjectChange.Value);

		public XObjectChange ObjectChange {
			get { return type; }
		}

		XObjectChange type;
	}
}
