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
using System.Collections;
using System.Collections.Generic;
using System.Workflow.Runtime;
using System.Workflow.Activities;


namespace MonoTests.System.Workflow.Runtime
{
	[TestFixture]
	public class CorrelationTokenTest
	{
		[Test]
		public void DefaultValues ()
		{
			CorrelationToken ct = new CorrelationToken ();

			Assert.AreEqual (false, ct.Initialized, "C1#1");
			Assert.AreEqual (null, ct.Name, "C1#2");
			Assert.AreEqual (null, ct.OwnerActivityName, "C1#3");
		}

		[Test]
		public void GetSetValues ()
		{
			CorrelationToken ct = new CorrelationToken ();

			Assert.AreEqual (false, ct.Initialized, "C2#1");
			Assert.AreEqual (null, ct.Name, "C2#2");
			Assert.AreEqual (null, ct.OwnerActivityName, "C2#3");
		}

		[Test]
		public void Initialize ()
		{
			DelayActivity da = new DelayActivity ();
			CorrelationToken ct = new CorrelationToken ();
			List <CorrelationProperty> properties = new List <CorrelationProperty> ();
			ct.Initialize (da, properties);
			Assert.AreEqual (true, ct.Initialized, "C3#1");
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void InitTwice ()
		{
			DelayActivity da = new DelayActivity ();
			CorrelationToken ct = new CorrelationToken ();
			List <CorrelationProperty> properties = new List <CorrelationProperty> ();
			ct.Initialize (da, properties);
			ct.Initialize (da, properties);
		}
	}
}

