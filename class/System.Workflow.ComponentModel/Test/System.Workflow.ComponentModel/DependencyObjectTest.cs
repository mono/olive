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
using System.Workflow.Runtime;
using System.Threading;

namespace MonoTests.System.Workflow.ComponentModel
{
	[TestFixture]
	public class DependencyObjectTest
	{
		static AutoResetEvent waitHandle = new AutoResetEvent (false);

		public sealed class ourCodeActivity : Activity
		{
			public static readonly DependencyProperty ExecuteCodeEvent;
			public static readonly DependencyProperty DataProperty;
			public static string DataValue;

			static ourCodeActivity ()
			{
				ExecuteCodeEvent = DependencyProperty.Register ("ExecuteCode", typeof (EventHandler),
					typeof (ourCodeActivity));

				DataProperty = DependencyProperty.Register ("Data", typeof (string), typeof (ourCodeActivity));
			}

			public ourCodeActivity ()
			{

			}

			protected sealed override ActivityExecutionStatus Execute (ActivityExecutionContext executionContext)
			{
				DataValue = (string) GetValue (DataProperty);
				return base.Execute (executionContext);
			}

			// Event handlers
			public event EventHandler ExecuteCode
			{
				add { AddHandler (ExecuteCodeEvent, value); }
				remove { RemoveHandler (ExecuteCodeEvent, value); }
			}

			public T[] ourGetInvocationList <T> (DependencyProperty dependencyEvent)
			{
				return GetInvocationList <T> (dependencyEvent);
			}
		}

		public class WorkFlowDataBinding : SequentialWorkflowActivity
		{
			protected IfElseBranchActivity branch2;
			private string address = "Default";

			public string Address {
				get { return address; }
				set { address = value; }
			}

			public WorkFlowDataBinding ()
			{
				IfElseActivity ifelse_activity = new IfElseActivity ();
				IfElseBranchActivity branch1 = new IfElseBranchActivity ();
				IfElseBranchActivity branch2 = new IfElseBranchActivity ();
				CodeCondition ifelse_condition1 = new CodeCondition ();
				CodeActivity code_branch1 = new CodeActivity ();
				ourCodeActivity code_branch2 = new ourCodeActivity ();

				code_branch1.Name ="Code1";
				code_branch2.Name ="Code2";
				code_branch1.ExecuteCode += new EventHandler (ExecuteCode1);

				branch1.Activities.Add (code_branch1);
				branch2.Activities.Add (code_branch2);

				ifelse_condition1.Condition += new EventHandler <ConditionalEventArgs> (IfElseCondition1);
				branch1.Condition = ifelse_condition1;

				ifelse_activity.Activities.Add (branch1);
				ifelse_activity.Activities.Add (branch2);

				ActivityBind activitybind1 = new ActivityBind ();
	            		activitybind1.Name = "WorkFlowDataBinding";
	            		activitybind1.Path = "Address";

	            		//Console.WriteLine ("DependecyParent {0}", this.GetType ().FullName);
	            		code_branch2.SetBinding (ourCodeActivity.DataProperty, activitybind1);
				Activities.Add (ifelse_activity);
			}

			private void IfElseCondition1 (object sender, ConditionalEventArgs e)
			{				
			}

			private void ExecuteCode1 (object sender, EventArgs e)
		        {
		        }

		        static public void OnWorkflowCompleted (object sender, WorkflowCompletedEventArgs e)
	        	{
	          		waitHandle.Set ();
	       		}
		}

		public class ClassProp2
		{
			public ClassProp2 () {}

			public static DependencyProperty ToProperty = DependencyProperty.Register
				("To", typeof(string), typeof(ClassProp2), new PropertyMetadata("someone@example.com"));
		}

		public class ClassProp4 : DependencyObject
		{
			public ClassProp4 () {}

			public static DependencyProperty FromProperty = DependencyProperty.Register
				("From", typeof(string), typeof(ClassProp4), new PropertyMetadata("someone@example.com"));
		}

		public class ClassPropEv
		{
			public static readonly DependencyProperty ExecuteCodeEvent;

			public ClassPropEv ()
			{

			}

			public static DependencyProperty FromProperty = DependencyProperty.Register
				("From", typeof(string), typeof(ClassProp4), new PropertyMetadata("someone@example.com"));
		}

		private void EvHandler (object sender, EventArgs e)
		{

		}

		private ClassProp4 prop = new ClassProp4 ();
		private DependencyProperty dp_test = DependencyProperty.RegisterAttached ("To", typeof(string),
				typeof (ClassProp2));

		private DependencyProperty dp_event = DependencyProperty.Register ("ExecuteCode",
			typeof (EventHandler), typeof (ClassPropEv));

		[Test]
		public void SetGet ()
		{
			Assert.AreEqual ("someone@example.com", prop.GetValue (ClassProp4.FromProperty), "C1#1");
			prop.SetValue (ClassProp4.FromProperty,  "Hola");
			Assert.AreEqual ("Hola", prop.GetValue (ClassProp4.FromProperty), "C1#2");
		}

		[Test]
		public void SetGetOverride ()
		{
			prop.SetValue (ClassProp4.FromProperty, "Hola");
			prop.SetValue (ClassProp4.FromProperty, "Adeu");
			Assert.AreEqual ("Adeu", prop.GetValue (ClassProp4.FromProperty), "C1#2");
		}

		[Test]
		public void AddHandlerRemove ()
		{
			EventHandler [] evs;
			EventHandler ev = new EventHandler (EvHandler);
			EventHandler ev2 = new EventHandler (EvHandler);

			ourCodeActivity ca = new ourCodeActivity ();
			evs = ca.ourGetInvocationList <EventHandler> (ourCodeActivity.ExecuteCodeEvent);
			Assert.AreEqual (0, evs.Length, "C1#1");

			ca.AddHandler (ourCodeActivity.ExecuteCodeEvent, ev);
			evs = ca.ourGetInvocationList <EventHandler> (ourCodeActivity.ExecuteCodeEvent);
			Assert.AreEqual (1, evs.Length, "C1#2");
			Assert.AreEqual (ev, evs[0], "C1#3");

			ca.AddHandler (ourCodeActivity.ExecuteCodeEvent, ev);
			evs = ca.ourGetInvocationList <EventHandler> (ourCodeActivity.ExecuteCodeEvent);
			Assert.AreEqual (2, evs.Length, "C1#4");
			Assert.AreEqual (ev, evs[0], "C1#5");
			Assert.AreEqual (ev2, evs[1], "C1#6");
		}

		// Test ActivityBinding and DepedencyObject binding
		[Test]
		public void SetGetBinding ()
		{
			WorkflowRuntime workflowRuntime = new WorkflowRuntime ();

			Type type = typeof (WorkFlowDataBinding);
			workflowRuntime.WorkflowCompleted += WorkFlowDataBinding.OnWorkflowCompleted;
			workflowRuntime.CreateWorkflow (type).Start ();
            		waitHandle.WaitOne ();

            		Assert.AreEqual ("Default", ourCodeActivity.DataValue, "C1#1");

			workflowRuntime.Dispose ();
		}

		// Exceptions

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void SetException ()
		{
			prop.SetValue (null,  null);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void GetException ()
		{
			prop.GetValue (null);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))] // DependencyProperty is not an event.
		public void AddHandler ()
		{
			CodeActivity ca = new CodeActivity ();
			ca.AddHandler (dp_test, new EventHandler (EvHandler));
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void AddHandlerParm1 ()
		{
			CodeActivity ca = new CodeActivity ();
			ca.AddHandler (null, new EventHandler (EvHandler));
		}

		[ExpectedException (typeof (ArgumentNullException))]
		[Test]
		public void AddHandlerParm2 ()
		{
			CodeActivity ca = new CodeActivity ();
			ca.AddHandler (dp_test, null);
		}
	}
}

