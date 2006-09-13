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
// This is simple console workflow sample
//


using System;
using System.Threading;
using System.Workflow.Activities;
using System.Workflow.Runtime;

namespace MonoTests.System.Workflow.Activities
{
	public class WorkFlowIfElse : SequentialWorkflowActivity
	{
		protected IfElseBranchActivity branch2;

		public WorkFlowIfElse ()
		{
			IfElseActivity ifelse_activity = new IfElseActivity ();
			IfElseBranchActivity branch1 = new IfElseBranchActivity ();
			CodeCondition ifelse_condition1 = new CodeCondition ();
			DelayActivity delay_activity = new DelayActivity ();
			CodeActivity code_branch1 = new CodeActivity ();
			CodeActivity code_branch2 = new CodeActivity ();
			branch2 = new IfElseBranchActivity ();

			delay_activity.Name = "DelayActivity";
			delay_activity.TimeoutDuration = TimeSpan.Parse ("00:00:05");
			delay_activity.InitializeTimeoutDuration += new EventHandler (DelayActivity_InitializeTimeoutDuration);

			code_branch1.Name ="Code1";
			code_branch2.Name ="Code2";
			code_branch1.ExecuteCode += new EventHandler (ExecuteCode1);
			code_branch2.ExecuteCode += new EventHandler (ExecuteCode2);

			branch1.Activities.Add (code_branch1);
			branch2.Activities.Add (code_branch2);

			ifelse_condition1.Condition += new EventHandler <ConditionalEventArgs> (IfElseCondition1);
			branch1.Condition = ifelse_condition1;

			ifelse_activity.Activities.Add (branch1);
			ifelse_activity.Activities.Add (branch2);

			Activities.Add (delay_activity);
			Activities.Add (ifelse_activity);
		}

		private void DelayActivity_InitializeTimeoutDuration (object sender, EventArgs e)
		{
			Console.WriteLine ("DelayActivity InitializeTimeoutDuration called");
		}

		private void IfElseCondition1 (object sender, ConditionalEventArgs e)
		{
			Console.WriteLine ("Setting IfElse condition to {0}", e.Result);
		}

		private void ExecuteCode1 (object sender, EventArgs e)
	        {
	        	Console.WriteLine ("ExecuteCode1 activity branch");
	        }

	        private void ExecuteCode2 (object sender, EventArgs e)
	        {
	        	Console.WriteLine ("ExecuteCode2 activity branch");
	        }
	}

	public class SimpleWorkflow
	{
		static AutoResetEvent waitHandle = new AutoResetEvent (false);

		static void Main ()
        	{
			WorkflowRuntime workflowRuntime = new WorkflowRuntime ();

			Type type = typeof (WorkFlowIfElse);
			workflowRuntime.WorkflowCompleted += OnWorkflowCompleted;

			workflowRuntime.CreateWorkflow (type).Start ();
            		waitHandle.WaitOne ();
			workflowRuntime.Dispose ();
		}

	        static void OnWorkflowCompleted (object sender, WorkflowCompletedEventArgs e)
        	{
        		Console.WriteLine ("Workflow completed");
          		waitHandle.Set ();
       		}
	}
}

