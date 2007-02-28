#if NET_2_0

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Xml.Linq
{
	public static class Extensions
	{
		public static IEnumerable<XElement> Ancestors<T> (this IEnumerable<T> source) where T : XNode
		{
			foreach (T item in source)
				for (XElement n = item.Parent as XElement; n != null; n = n.Parent as XElement)
					yield return n;
		}

		public static IEnumerable<XElement> Ancestors<T> (this IEnumerable<T> source, XName name) where T : XNode
		{
			foreach (T item in source)
				for (XElement n = item.Parent as XElement; n != null; n = n.Parent as XElement)
					if (n.Name == name)
						yield return n;
		}

		public static IEnumerable<XElement> AncestorsAndSelf (this IEnumerable<XElement> source)
		{
			foreach (XElement item in source)
				for (XElement n = item as XElement; n != null; n = n.Parent as XElement)
					yield return n;
		}

		public static IEnumerable<XElement> AncestorsAndSelf (this IEnumerable<XElement> source, XName name)
		{
			foreach (XElement item in source)
				for (XElement n = item as XElement; n != null; n = n.Parent as XElement)
					if (n.Name == name)
						yield return n;
		}

		public static IEnumerable <XAttribute> Attributes (this IEnumerable <XElement> source)
		{
			foreach (XElement item in source)
				foreach (XAttribute attr in item.Attributes ())
					yield return attr;
		}

		public static IEnumerable <XAttribute> Attributes (this IEnumerable <XElement> source, XName name)
		{
			foreach (XElement item in source)
				foreach (XAttribute attr in item.Attributes (name))
					yield return attr;
		}
	}
}
#endif
