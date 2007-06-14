using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.JScript.Runtime;
using Microsoft.Scripting;
using NUnit.Framework;

namespace MonoTests.Microsoft.JScript.Runtime {
	[TestFixture]
	public class JSObjectTest {

		[Test]
		public void TestCtor ()
		{
			JSObject o = new JSObject (null);
			JSObject child = new JSObject (o);
		}

		[Test]
		public void TestAdd ()
		{
			JSObject o = new JSObject (null);
			SymbolId si = new SymbolId (0);

			o.Add (si, 1);
			Assert.AreEqual (1, o.Count, "A1");
			Assert.IsTrue (o.ContainsKey (si), "A2");
		}

		[Test]
		public void TestAddObjectKey ()
		{
			JSObject o = new JSObject (null);
			o.AddObjectKey (0, 1);

			Assert.AreEqual (1, o.Count, "A1");
			Assert.IsTrue (o.ContainsObjectKey (0), "A2");
		}

		[Test]
		public void TestAsObjectKeyedDictionary ()
		{
			JSObject o = new JSObject (null);
			o.AddObjectKey ("1", 2);
			o.AddObjectKey ("2", 4);
			o.AddObjectKey ("3", 4);
			o.AddObjectKey (3, 5);
			o.AddObjectKey ("a", 6);

			IDictionary<object, object> dict = o.AsObjectKeyedDictionary ();

			Assert.AreEqual (2, dict ["1"], "B1");
			Assert.AreEqual (4, dict ["2"], "B2");
			Assert.AreEqual (5, dict ["3"], "B3");
			Assert.AreEqual (6, dict ["a"], "B4");
		}

		[Test]
		public void TestContainsKey ()
		{
			JSObject o = new JSObject (null);
			SymbolId si = new SymbolId (0);
			o.Add (si, 1);

			Assert.IsTrue (o.ContainsKey (si));
		}

		[Test]
		public void TestContainsObjectKey ()
		{
			JSObject o = new JSObject (null);
			o.AddObjectKey (1, 2);

			Assert.IsTrue (o.ContainsObjectKey (1));
		}

		[Test]
		[Category ("NotDotNet")]
		// Not implemented in .NET
		public void TestContainsValue ()
		{
			JSObject o = new JSObject (null);
			o.AddObjectKey (1, 2);
			o.AddObjectKey (2, 3);
			o.AddObjectKey (1, 3);

			Assert.IsTrue (o.ContainsValue (3));
		}

		[Test]
		public void TestDeleteItem ()
		{
			JSObject o = new JSObject (null);
			o.AddObjectKey (1, 2);
			o.DeleteItem (1);

			Assert.AreEqual (0, o.Count);
		}

		[Test]
		public void TestGetClassName ()
		{
			JSObject o = new JSObject (null);
			Assert.AreEqual ("Object", o.GetClassName ());
		}

		[Test]
		public void TestRemove ()
		{
			JSObject o = new JSObject (null);
			SymbolId si = new SymbolId (0);
			o.Add (si, 1);
			o.Remove (si);

			Assert.AreEqual (0, o.Count);
		}

		[Test]
		public void TestRemoveObjectKey ()
		{
			JSObject o = new JSObject (null);
			o.AddObjectKey (1, 2);
			o.RemoveObjectKey (1);

			Assert.AreEqual (0, o.Count);
		}
	}
}
