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
using System.Threading;
using NUnit.Framework;
using System.Security.Permissions;
using System.Workflow.Activities;
using System.Workflow.Runtime;

namespace MonoTests.System.Workflow.Activities
{
	public interface ISampleService1
	{
		[CorrelationInitializer]
		void CreateItem (string item);
	}

	public class SampleService1 : ISampleService1
	{
		public SampleService1 () {}
		public void CreateItem (string item) {}
	}

	[ExternalDataExchange]
	public interface ISampleService2
	{
		[CorrelationInitializer]
		void CreateItem (string item);
	}

	public class SampleService2 : ISampleService2
	{
		public SampleService2 () {}
		public void CreateItem (string item) {}
	}

	[TestFixture]
	public class ExternalDataExchangeServiceTest
	{
		[Test]
		public void AddGetRemoveTest ()
		{
			SampleService2 sample = new SampleService2 ();
			WorkflowRuntime workflow = new WorkflowRuntime ();
			ExternalDataExchangeService data_change = new ExternalDataExchangeService ();
			workflow.AddService (data_change);
			data_change.AddService (sample);

			Assert.AreEqual (sample, data_change.GetService (sample.GetType ()), "C1#1");
			data_change.RemoveService (sample);
			Assert.AreEqual (null, data_change.GetService (sample.GetType ()), "C1#2");
		}

		[ExpectedException (typeof (InvalidOperationException))]
		[Test]
		public void NoCorrelationParameter ()
		{
			SampleService1 sample = new SampleService1 ();
			WorkflowRuntime workflow = new WorkflowRuntime ();
			ExternalDataExchangeService data_change = new ExternalDataExchangeService ();
			workflow.AddService (data_change);
			data_change.AddService (sample);
		}

		[ExpectedException (typeof (InvalidOperationException))]
		[Test]
		public void AddingServiceTwice ()
		{
			SampleService2 sample = new SampleService2 ();
			WorkflowRuntime workflow = new WorkflowRuntime ();
			ExternalDataExchangeService data_change = new ExternalDataExchangeService ();
			workflow.AddService (data_change);
			data_change.AddService (sample);
			data_change.AddService (sample);
		}

		[ExpectedException (typeof (ArgumentNullException))]
		[Test]
		public void RemoveNullService ()
		{
			WorkflowRuntime workflow = new WorkflowRuntime ();
			ExternalDataExchangeService data_change = new ExternalDataExchangeService ();
			workflow.AddService (data_change);
			data_change.RemoveService (null);
		}
	}

}

