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
//	Copyright (C) 2008 Anton Kytmanov <carga@mail.ru>
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime;

namespace System.Workflow.Runtime.Hosting {
	public abstract class WorkflowPersistenceService : WorkflowRuntimeService {
		protected WorkflowPersistenceService () {
		}

#region Static methods
		protected static byte [] GetDefaultSerializedForm (Activity activityForSerialization) {
			throw new NotImplementedException ();
		}

		protected static Activity RestoreFromDefaultSerializedForm (byte [] serializedActivity, Activity outerActivity) {
			throw new NotImplementedException ();
		}

		internal protected static WorkflowStatus GetWorkflowStatus (Activity activity) {
			throw new NotImplementedException ();
		}

		internal protected static bool GetIsBlocked (Activity activity) {
			throw new NotImplementedException ();
		}

		internal protected static string GetSuspendOrTerminateInfo (Activity activity) {
			throw new NotImplementedException ();
		}
#endregion

		internal protected abstract void SaveWorkflowInstanceState (Activity rootActivity, bool leaveUnlockedAfterSaving);

		internal protected abstract Activity LoadWorkflowInstanceState (Guid instanceId);

		internal protected abstract void SaveCompletedContextActivity (Activity rootActivity);

		internal protected abstract Activity LoadCompletedContextActivity (Guid instanceId, Activity outerActivity);

		internal protected abstract bool UnloadOnIdle (Activity activity);

		internal protected abstract void UnlockWorkflowInstanceState (Activity activity);
	}
}
