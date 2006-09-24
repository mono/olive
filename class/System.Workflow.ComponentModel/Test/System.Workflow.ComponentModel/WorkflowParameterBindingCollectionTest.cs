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
using System.Workflow.ComponentModel;
using System.Workflow.Activities;

namespace MonoTests.System.Workflow.ComponentModel
{
	[TestFixture]
	public class WorkflowParameterBindingCollectionTest
	{
		[Test]
		public void TestAddRemove ()
		{
			WorkflowParameterBindingCollection wc = new WorkflowParameterBindingCollection (new ParallelActivity ());

			WorkflowParameterBinding pb1 = new WorkflowParameterBinding ("Name1");
			WorkflowParameterBinding pb2 = new WorkflowParameterBinding ("Name2");
			WorkflowParameterBinding pb3 = new WorkflowParameterBinding ("Name3");

			wc.Add (pb1);
			wc.Add (pb2);
			wc.Add (pb3);

			Assert.AreEqual (3, wc.Count, "C1#1");
			Assert.AreEqual (pb1, wc[0], "C1#2");
			Assert.AreEqual (pb2, wc[1], "C1#3");
			Assert.AreEqual (pb3, wc[2], "C1#4");
		}

		// Exceptions
		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void TestConstructorNullException ()
		{
			WorkflowParameterBindingCollection wc = new WorkflowParameterBindingCollection (new ParallelActivity ());
			WorkflowParameterBinding pb1 = new WorkflowParameterBinding ();
			wc.Add (pb1);
		}
	}
}

