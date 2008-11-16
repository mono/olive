using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Workflow.Runtime.Hosting;
using System.Workflow.ComponentModel;

namespace System.Workflow.Runtime.Tests {
	[TestFixture]
	public class WorkflowPersistenceServiceTest {
		private class CustomPersistenceService : WorkflowPersistenceService {
			protected override void SaveWorkflowInstanceState (Activity rootActivity, bool leaveUnlockedAfterSaving) {
				throw new NotImplementedException ();
			}

			protected override Activity LoadWorkflowInstanceState (Guid instanceId) {
				throw new NotImplementedException ();
			}

			protected override void SaveCompletedContextActivity (Activity rootActivity) {
				throw new NotImplementedException ();
			}

			protected override Activity LoadCompletedContextActivity (Guid instanceId, Activity outerActivity) {
				throw new NotImplementedException ();
			}

			protected override bool UnloadOnIdle (Activity activity) {
				throw new NotImplementedException ();
			}

			protected override void UnlockWorkflowInstanceState (Activity activity) {
				throw new NotImplementedException ();
			}
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void ThereCanBeOnlyOne () {
			CustomPersistenceService cp1 = new CustomPersistenceService ();
			CustomPersistenceService cp2 = new CustomPersistenceService ();

			WorkflowRuntime wr = new WorkflowRuntime ();
			wr.AddService (cp1);
			wr.AddService (cp2);
		}
	}
}
