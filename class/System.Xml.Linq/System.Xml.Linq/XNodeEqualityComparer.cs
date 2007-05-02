using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Xml.Linq
{
	[MonoTODO]
	public sealed class XNodeEqualityComparer : IEqualityComparer, IEqualityComparer<XNode>
	{
		public XNodeEqualityComparer ()
		{
		}

		[MonoTODO]
		public bool Equals (XNode n1, XNode n2)
		{
			throw new NotImplementedException ();
		}

		bool IEqualityComparer.Equals (object n1, object n2)
		{
			return Equals ((XNode) n1, (XNode) n2);
		}

		[MonoTODO]
		public int GetHashCode (XNode node)
		{
			throw new NotImplementedException ();
		}

		int IEqualityComparer.GetHashCode (object node)
		{
			return GetHashCode ((XNode) node);
		}
	}
}
