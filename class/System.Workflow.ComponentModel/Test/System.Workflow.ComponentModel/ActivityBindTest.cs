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
// Authors:
//
//	Copyright (C) 2006 Jordi Mas i Hernandez <jordimash@gmail.com>
//

using System;
using NUnit.Framework;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;
using System.Collections;
using System.Collections.Generic;

namespace MonoTests.System.Workflow.ComponentModel
{
	[TestFixture]
	public class ActivityBindTest
	{
		public sealed class ClassProvider : SequenceActivity
		{
			string name;

			public ClassProvider ()
			{
				name = "Hello";
			}

			public string Name {
				get { return name; }
				set { name = value; }
			}
		}

		[Test]
		public void SetGetRuntimeValue ()
		{
			object obj;
			string st = string.Empty;
			ClassProvider cp = new ClassProvider ();
			ActivityBind ab = new ActivityBind ("ClassProvider", "Name");

			obj = ab.GetRuntimeValue (cp, st.GetType ());
			Assert.AreEqual ("Hello", obj.ToString (), "C1#1");
			ab.SetRuntimeValue (cp, "Bye");

			obj = ab.GetRuntimeValue (cp, st.GetType ());
			Assert.AreEqual ("Bye", obj.ToString (), "C1#2");		
		}

		[Test]
		public void ProvideValue ()
		{
			ActivityBind ab = new ActivityBind ("ClassProvider", "Name");			
			Assert.AreEqual (ab, ab.ProvideValue (null), "C2#1");
		}

		[ExpectedException (typeof (ArgumentNullException))]
		[Test]
		public void GetRuntimeValueNull ()
		{
			string st = string.Empty;
			ActivityBind ab = new ActivityBind ("ClassProvider", "Name");
			object obj = ab.GetRuntimeValue (null, st.GetType ());
		}

		[ExpectedException (typeof (ArgumentNullException))]
		[Test]
		public void SetRuntimeValueNull ()
		{
			string st = string.Empty;
			ActivityBind ab = new ActivityBind ("ClassProvider", "Name");
			ab.SetRuntimeValue (null, null);
		}
	}
}

