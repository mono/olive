using NUnit.Core;
using NUnit.Framework;
using Microsoft.JScript.Compiler;

namespace MonoTests.Microsoft.JScript.Compiler
{
	class SplayExt : SplayTree {
		int key;
		public SplayExt (int k)
			: base ()
		{
			key = k;
		}

		public int Key {
			get { return key; }
		}
	}


	[TestFixture]
	public class SplayTreeTest
	{
		[Test]
		public void CtorTest ()
		{
			SplayTree t = new SplayTree ();

			Assert.IsNotNull (t, "A1");
			Assert.IsNull (t.Left, "A2");
			Assert.IsNull (t.Right, "A3");
		}

		[Test]
		public void SplayToRootTest ()
		{
			{
				SplayExt a;

				a = new SplayExt (1);
				a.SplayToRoot ();
				Assert.AreEqual (1, a.Key, "B1");
			}
			{
				SplayExt a, b;

				a = new SplayExt (1);
				b = new SplayExt (2);
				a.AddAsRightChild (b);
				b.SplayToRoot ();

				Assert.AreEqual (2, b.Key, "B2");
				Assert.AreEqual (1, ((SplayExt)(b.Left)).Key, "B3");
			}
			{
				SplayExt a, b;

				a = new SplayExt (2);
				b = new SplayExt (1);
				a.AddAsLeftChild (b);
				b.SplayToRoot ();

				Assert.AreEqual (1, b.Key, "B4");
				Assert.AreEqual (2, ((SplayExt)(b.Right)).Key, "B5");
			}
			{
				SplayExt a, b, c;

				a = new SplayExt (1);
				b = new SplayExt (2);
				c = new SplayExt (3);
				a.AddAsRightChild (b);
				b.AddAsRightChild (c);
				c.SplayToRoot ();

				Assert.AreEqual (3, c.Key, "B6");
				Assert.AreEqual (2, ((SplayExt)(c.Left)).Key, "B7");
				Assert.AreEqual (1, ((SplayExt)(b.Left)).Key, "B8");
			}
			{
				SplayExt a, b, c;

				a = new SplayExt (3);
				b = new SplayExt (2);
				c = new SplayExt (1);
				a.AddAsLeftChild (b);
				b.AddAsLeftChild (c);
				c.SplayToRoot ();

				Assert.AreEqual (1, c.Key, "B9");
				Assert.AreEqual (2, ((SplayExt)(c.Right)).Key, "B10");
				Assert.AreEqual (3, ((SplayExt)(b.Right)).Key, "B11");
			}
			{
				SplayExt a, b, c;

				a = new SplayExt (1);
				b = new SplayExt (3);
				c = new SplayExt (2);
				a.AddAsRightChild (b);
				b.AddAsLeftChild (c);
				c.SplayToRoot ();

				Assert.AreEqual (2, c.Key, "B12");
				Assert.AreEqual (1, ((SplayExt)(c.Left)).Key, "B13");
				Assert.AreEqual (3, ((SplayExt)(c.Right)).Key, "B14");
			}
			{
				SplayExt a, b, c;

				a = new SplayExt (3);
				b = new SplayExt (1);
				c = new SplayExt (2);
				a.AddAsLeftChild (b);
				b.AddAsRightChild (c);
				c.SplayToRoot ();

				Assert.AreEqual (2, c.Key, "B15");
				Assert.AreEqual (1, ((SplayExt)(c.Left)).Key, "B16");
				Assert.AreEqual (3, ((SplayExt)(c.Right)).Key, "B17");
			}
		}
	}
}
