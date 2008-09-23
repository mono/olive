//
// Microsoft.JScript.Compiler
//
// Author:
//   Olivier Dufour (olivier.duff@gmail.com)
//
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using NUnit.Core;
using NUnit.Framework;
using Microsoft.JScript.Compiler;

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
