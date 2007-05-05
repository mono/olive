using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Xml.Linq
{
	public sealed class XNodeDocumentOrderComparer : IComparer, IComparer<XNode>
	{
		public XNodeDocumentOrderComparer ()
		{
		}

		enum CompareResult
		{
			Same,
			Random,
			Parent,
			Child,
			Ancestor,
			Descendant,
			Preceding,
			Following
		}

		public int Compare (XNode n1, XNode n2)
		{
			switch (CompareCore (n1, n2)) {
			case CompareResult.Same:
				return 0;
			case CompareResult.Random:
				return DateTime.Now.Ticks % 2 == 1 ? 1 : -1;
			case CompareResult.Parent:
			case CompareResult.Ancestor:
			case CompareResult.Preceding:
				return 1;
			default:
				return -1;
			}
		}

		CompareResult CompareCore (XNode n1, XNode n2)
		{
			if (n1 == n2)
				return CompareResult.Same;
			if (n1.Owner == null) {
				if (n2.Owner == null)
					// n1 and n2 do not share the same
					// top-level node, so return semi-
					// random value.
					return CompareResult.Random;

				CompareResult result = CompareCore (n1, n2.Owner);
				switch (result) {
				case CompareResult.Same:
					return CompareResult.Child;
				case CompareResult.Child:
				case CompareResult.Descendant:
					return CompareResult.Descendant;
				case CompareResult.Parent:
				case CompareResult.Ancestor:
					throw new Exception ("INTERNAL ERROR: should not happen");
				default:
					return result;
				}
			}
			// else
			if (n2.Owner == null) {
				// do reverse
				CompareResult rev = CompareCore (n2, n1);
				switch (rev) {
				case CompareResult.Parent:
					return CompareResult.Child;
				case CompareResult.Child:
					return CompareResult.Parent;
				case CompareResult.Ancestor:
					return CompareResult.Descendant;
				case CompareResult.Descendant:
					return CompareResult.Ancestor;
				case CompareResult.Following:
					return CompareResult.Preceding;
				case CompareResult.Preceding:
					return CompareResult.Following;
				case CompareResult.Same:
				case CompareResult.Random:
					return rev;
				}
			}
			// both have parents
			CompareResult ret = CompareCore (n1.Owner, n2.Owner);
			switch (ret) {
			case CompareResult.Same:
				// n1 and n2 are sibling each other.
				return CompareSibling (n1, n2);
			case CompareResult.Child:
				return CompareSibling (n1, n2.Owner);
			case CompareResult.Parent:
				return CompareSibling (n1.Owner, n2);
			case CompareResult.Descendant:
				for (XNode i2 = n2; ; i2 = i2.Owner)
					if (i2.Owner == n1.Owner)
						return CompareSibling (n1, i2);
			case CompareResult.Ancestor:
				for (XNode i1 = n1; ; i1 = i1.Owner)
					if (i1.Owner == n2.Owner)
						return CompareSibling (i1, n2);
			default:
				return ret;
			}
		}

		// results are returned as following/preceding, as it is also
		// used for comparing parents.
		CompareResult CompareSibling (XNode n1, XNode n2)
		{
			for (XNode n = n1.NextNode; n != null; n = n.NextNode)
				if (n == n2)
					return CompareResult.Following;
			return CompareResult.Preceding;
		}

		int IComparer.Compare (object n1, object n2)
		{
			return Compare ((XNode) n1, (XNode) n2);
		}
	}
}
