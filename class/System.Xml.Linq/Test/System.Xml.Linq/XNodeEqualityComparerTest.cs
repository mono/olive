using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

using NUnit.Framework;

namespace MonoTests.System.Xml.Linq
{
	[TestFixture]
	public class XNodeEqualityComparerTest
	{
		[Test]
		public void CompareNulls ()
		{
			Assert.IsTrue (XNode.EqualityComparer.Equals (null, null));
		}

		[Test]
//		[ExpectedException (typeof (ArgumentNullException))]
		public void GetHashCodeNull ()
		{
			XNode.EqualityComparer.GetHashCode (null);
		}

		[Test]
		public void Compare1 ()
		{
			XNodeEqualityComparer c = XNode.EqualityComparer;
			XDocument doc = XDocument.Parse ("<root><foo/><bar/><foo/></root>");
			Assert.IsTrue (c.Equals (doc.Root.FirstNode, doc.Root.LastNode), "#1");
			Assert.IsFalse (c.Equals (doc.Root.FirstNode, doc.Root.FirstNode.NextNode), "#2");

			doc = XDocument.Parse ("<root><foo/><foo a='v'/><foo a='v2' /><foo a='v' b='v' /><foo a='v' b='v' /><foo b='v' a='v' /></root>");
			Assert.IsFalse (c.Equals (doc.Root.FirstNode, doc.Root.LastNode.NextNode), "#3");
			Assert.IsFalse (c.Equals (doc.Root.FirstNode, doc.Root.FirstNode.NextNode.NextNode), "#4");
			Assert.IsFalse (c.Equals (doc.Root.FirstNode, doc.Root.LastNode.PreviousNode), "#5");
			// huh?
			Assert.IsFalse (c.Equals (doc.Root.LastNode.PreviousNode, doc.Root.LastNode), "#6");
			Assert.IsTrue (c.Equals (doc.Root.LastNode.PreviousNode.PreviousNode, doc.Root.LastNode.PreviousNode), "#7");
		}

		[Test]
		public void Compare2 ()
		{
			XNodeEqualityComparer c = XNode.EqualityComparer;
			XElement e1 = XElement.Parse ("<foo><bar/></foo>");
			XElement e2 = XElement.Parse ("<foo><bar/></foo>");
			Assert.IsTrue (c.Equals (e1, e2), "#1");
			Assert.IsTrue (c.Equals (e1.FirstNode, e2.FirstNode), "#2");
		}
	}
}
