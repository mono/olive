using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Workflow.Runtime.Hosting;
using System.Workflow.ComponentModel;
using System.Workflow.Activities;

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

			#region We publish protected methods just to test them
			internal static byte [] GetDefaultSerializedFormForTesting (Activity activityForSerialization) {
				return GetDefaultSerializedForm (activityForSerialization);
			}

			internal static Activity RestoreFromDefaultSerializedFormForTesting (byte [] serializedActivity, Activity outerActivity) {
				return RestoreFromDefaultSerializedForm (serializedActivity, outerActivity);
			}
			#endregion
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

		[Test]
		public void TestActivitySaveLoadMethods () {
			CodeActivity expected = new CodeActivity ("TestCode");

			byte [] serialized;
			using (MemoryStream ms = new MemoryStream ()) {
				expected.Save (ms);
				ms.Position = 0L;
				serialized = ms.ToArray ();
			}

			Activity actual = null;
			using (MemoryStream ms2 = new MemoryStream (serialized)) {
				ms2.Position = 0L;
				actual = Activity.Load (ms2, null);
			}

			Assert.IsNotNull (actual, "#C2#1");
			Assert.IsTrue (actual is CodeActivity, "#C2#2");
			Assert.AreEqual (expected.Name, actual.Name, "#C2#3");
			Assert.AreEqual (expected.QualifiedName, ((CodeActivity)actual).QualifiedName, "#C2#4");
		}

		[Test]
		public void TestDefaultSaveLoadMethods () {
			Activity expected = new Activity ("BornToSerialize");

			byte [] serialized = CustomPersistenceService.GetDefaultSerializedFormForTesting (expected);

			Activity actual = CustomPersistenceService.RestoreFromDefaultSerializedFormForTesting (serialized, null);

			Assert.IsNotNull (actual, "#C4#1");
			Assert.IsTrue (actual is Activity, "#C4#2");
			Assert.AreEqual (expected.Name, actual.Name, "#C4#3");
		}
	}
}
