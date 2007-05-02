using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Xml.Linq
{
	[MonoTODO]
	public sealed class XNodeDocumentOrderComparer : IComparer, IComparer<XNode>
	{
		public XNodeDocumentOrderComparer ()
		{
		}

		[MonoTODO]
		public int Compare (XNode n1, XNode n2)
		{
			throw new NotImplementedException ();
		}

		int IComparer.Compare (object n1, object n2)
		{
			return Compare ((XNode) n1, (XNode) n2);
		}
	}
}
