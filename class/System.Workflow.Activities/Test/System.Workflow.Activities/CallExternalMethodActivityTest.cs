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

#if RUNTIME_DEP

using System;
using System.Threading;
using NUnit.Framework;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;
using System.Workflow.Runtime;

namespace MonoTests.System.Workflow.Activities
{
	public class DocumentEventArgs : ExternalDataEventArgs
	{
		private string id;

		public DocumentEventArgs (Guid instanceId, string id) :base (instanceId)
		{
			this.id = id;
		}

		public string Id {
			get { return id; }
			set { id = value; }
		}
	}

	[ExternalDataExchange]
	[CorrelationParameter ("DocumentId")]
	public interface IDocumentService
	{
		[CorrelationInitializer]
		void CreateDocument (string DocumentId, string text);

	}
	
	public class DocumentService : IDocumentService
	{
		public void CreateDocument (string documentId, string text)
		{
			CallExternalMethodActivityTest.document = documentId;
			CallExternalMethodActivityTest.text = text;	
		}

	}

	public class CreateDocument : CallExternalMethodActivity
	{
		// Properties on the task
		public static DependencyProperty TextProperty = DependencyProperty.Register
			("Text", typeof (string), typeof (CreateDocument));

		public static DependencyProperty DocumentIdProperty = DependencyProperty.Register
			("DocumentId", typeof (string), typeof (CreateDocument));
		
		public CreateDocument ()
		{
			this.InterfaceType = typeof (IDocumentService);
			this.MethodName = "CreateDocument";
		}

		public string Text {
			get { return ((string)(base.GetValue (TextProperty)));}
			set { SetValue (TextProperty, value); }
		}

		public string DocumentId {
			get { return ((string)(GetValue (DocumentIdProperty)));	}
			set { SetValue (DocumentIdProperty, value); }
		}

		protected override void OnMethodInvoking (EventArgs e)
		{
			ParameterBindings["text"].Value = this.Text;
			ParameterBindings["DocumentId"].Value = this.DocumentId;
		}
	}


	public class WorkFlowCallExternal : SequentialWorkflowActivity
	{
		
		
		public WorkFlowCallExternal ()
		{
			CreateDocument createDocument1 = new CreateDocument ();
			CorrelationToken correlator1 = new CorrelationToken ();

			CanModifyActivities = true;
			Name = "WorkFlowCallExternal";

			
			correlator1.Name = "c1";
			correlator1.OwnerActivityName = "WorkFlowCallExternal";
			createDocument1.CorrelationToken = correlator1;
			createDocument1.Name = "createDocument1";
			createDocument1.DocumentId = "First";
			createDocument1.Text = "Joan Martinez";

			Activities.Add (createDocument1);
            		CanModifyActivities = false;
		}
	}

	[TestFixture]
	public class CallExternalMethodActivityTest
	{
		static AutoResetEvent waitHandle = new AutoResetEvent (false);
		public static string text;
		public static string document;

		[Test]
		public void TestActivity ()
        	{
			WorkflowRuntime workflowRuntime = new WorkflowRuntime ();
			DocumentService DocumentService = new DocumentService ();

			Type type = typeof (WorkFlowCallExternal);
			workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;

			ExternalDataExchangeService dataExchangeService = new ExternalDataExchangeService ();
            		workflowRuntime.AddService (dataExchangeService);
            		dataExchangeService.AddService (DocumentService);

			workflowRuntime.CreateWorkflow (type).Start ();
            		waitHandle.WaitOne ();
			workflowRuntime.Dispose ();
			
			Assert.AreEqual ("Joan Martinez", text, "C1#1");
			Assert.AreEqual ("First", document, "C1#2");
		}

	        static void OnWorkflowCompleted (object sender, WorkflowCompletedEventArgs e)
		{
          		waitHandle.Set ();
		}
	}
}

#endif
