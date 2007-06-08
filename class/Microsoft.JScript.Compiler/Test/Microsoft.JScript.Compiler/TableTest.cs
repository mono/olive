using NUnit.Core;
using NUnit.Framework;
using Mono.JScript.Compiler;

namespace MonoTests.Microsoft.JScript.Compiler
{
	[TestFixture]
	public class TableTest
	{
		[Test]
		public void InsertTest ()
		{
			Table<int, string> table = new Table<int, string> ();

			table.Insert (1, "one", false);
			table.Insert (2, "two", false);
			table.Insert (3, "three", false);

			Assert.AreEqual ("one", table.Lookup (1), "A1");
			Assert.AreEqual ("two", table.Lookup (2), "A2");
			Assert.AreEqual ("three", table.Lookup (3), "A3");
			Assert.AreEqual (null, table.Lookup (4), "A4");

			table.Insert (1, "four", true);
			table.Insert (1, "one", false);

			Assert.AreEqual ("four", table.Lookup (1), "A5");
		}

		[Test]
		public void InsertIfNotPresentTest ()
		{
			Table<int, string> table = new Table<int, string> ();

			table.Insert (1, "one", false);
			table.InsertIfNotPresent (1, "two");

			Assert.AreEqual ("one", table.Lookup (1), "B1");
		}
	}
}
