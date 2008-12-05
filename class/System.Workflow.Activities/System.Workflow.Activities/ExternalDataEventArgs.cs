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
using System.ComponentModel;
using System.Workflow.ComponentModel;

#if RUNTIME_DEP
using System.Workflow.Runtime;
#endif

namespace System.Workflow.Activities
{
	[Serializable]
	public class ExternalDataEventArgs : EventArgs
	{
		private string identity;
		private Guid instance_id;
		private bool wait_idle;		
		private object work_item;

		public ExternalDataEventArgs (Guid instanceId)
		{

		}
#if RUNTIME_DEP
		public ExternalDataEventArgs (Guid instanceId, IPendingWork workHandler, object workItem)
		{

		}

		public ExternalDataEventArgs (Guid instanceId, IPendingWork workHandler, object workItem, bool waitForIdle)
		{

		}
#endif
		// Properties
		public string Identity {
			get { return identity; }
			set { identity = value; }
		}
		public Guid InstanceId {
			get { return instance_id; }
			set { instance_id = value; }
		}
		
		public bool WaitForIdle {
			get { return wait_idle; }
			set { wait_idle = value; }
		}
#if RUNTIME_DEP		
		private IPendingWork work_handler;
		public IPendingWork WorkHandler {
			get { return work_handler; }
			set { work_handler = value; }
		}
#endif		
		
		public object WorkItem {
			get { return work_item; }
			set { work_item = value; }
		}
	}
}

