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
using System.Reflection;
using System.ComponentModel;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;

namespace System.Workflow.Activities
{

	public class CallExternalMethodActivity : Activity
	//IDynamicPropertyTypeProvider
	{
		public static readonly DependencyProperty CorrelationTokenProperty;
		public static readonly DependencyProperty InterfaceTypeProperty;
		public static readonly DependencyProperty MethodInvokingEvent;
		public static readonly DependencyProperty MethodNameProperty;
		public static readonly DependencyProperty ParameterBindingsProperty;

		static CallExternalMethodActivity ()
		{
			CorrelationTokenProperty = DependencyProperty.Register ("CorrelationToken",
				typeof (CorrelationToken), typeof (CallExternalMethodActivity));

			InterfaceTypeProperty = DependencyProperty.Register ("InterfaceType",
				typeof (Type), typeof (CallExternalMethodActivity));

			MethodInvokingEvent = DependencyProperty.Register ("MethodInvoking",
				typeof (CorrelationToken), typeof (CallExternalMethodActivity));

			MethodNameProperty = DependencyProperty.Register ("MethodName",
				typeof (string), typeof (CallExternalMethodActivity));

			ParameterBindingsProperty = DependencyProperty.Register ("ParameterBindings",
				typeof (WorkflowParameterBindingCollection), typeof (CallExternalMethodActivity));
		}

		public CallExternalMethodActivity ()
		{
			ParameterBindings =  new WorkflowParameterBindingCollection (this);
		}

		public CallExternalMethodActivity (string name) : base ()
		{
			MethodName = name;
		}

		// Properties
		public virtual CorrelationToken CorrelationToken {
			get { return  (CorrelationToken) GetValue (CorrelationTokenProperty); }
			set { SetValue (CorrelationTokenProperty, value); }
		}

		public virtual Type InterfaceType {
			get { return  (Type) GetValue (InterfaceTypeProperty); }
			set { SetValue (InterfaceTypeProperty, value); }
		}

		public virtual string MethodName {
			get { return  (string) GetValue (MethodNameProperty); }
			set { SetValue (MethodNameProperty, value); }
		}

		public WorkflowParameterBindingCollection ParameterBindings {
			get { return  (WorkflowParameterBindingCollection) GetValue (ParameterBindingsProperty); }
			set { SetValue (ParameterBindingsProperty, value);}
		}

		// Events
		public event EventHandler MethodInvoking;

		protected sealed override ActivityExecutionStatus Execute (ActivityExecutionContext executionContext)
		{
			object[] parameters;
			object data = executionContext.GetService (InterfaceType);
			MethodInfo invoke = InterfaceType.GetMethod (MethodName);
			ParameterInfo[] pars = invoke.GetParameters ();

			parameters = new object [pars.Length];
			for (int i = 0; i < pars.Length; i++) {
				ParameterBindings.Add (new WorkflowParameterBinding (pars[i].Name));
			}

			// User may set the ParameterBindings
			OnMethodInvoking (new EventArgs ());

			for (int i = 0; i < pars.Length; i++) {
				parameters[i] = (ParameterBindings [pars[i].Name]).Value;
			}

			InterfaceType.InvokeMember (MethodName,
				BindingFlags.InvokeMethod,
				null, data,
				parameters);

			OnMethodInvoked (new EventArgs ());

			NeedsExecution = false;
			return ActivityExecutionStatus.Closed;
		}

		// Methods
		protected override void InitializeProperties ()
		{
			if (CorrelationToken == null)
				return;
		}

		protected virtual void OnMethodInvoked (EventArgs e)
		{

		}

		protected virtual void OnMethodInvoking (EventArgs e)
		{

		}
	}
}

#endif