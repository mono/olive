//
// DispatchRuntimeTest.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.  http://www.novell.com
//
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

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;
using System.Xml;
using NUnit.Framework;

namespace MonoTests.System.ServiceModel.Dispatcher
{
	[TestFixture]
	public class DispatchRuntimeTest
	{
		[Test]
		public void TestConstructor ()
		{
			// This test is rather to just detect implementation 
			// differences than digging in-depth meanings, so feel
			// free to change if MS implementation does not make 
			// sense.
			DispatchRuntime r = new EndpointDispatcher (
				new EndpointAddress ("http://localhost:8080"), "IFoo", "urn:foo").DispatchRuntime;
			Assert.AreEqual (AuditLogLocation.Default,
					 r.SecurityAuditLogLocation, "#1");

			Assert.IsTrue (r.AutomaticInputSessionShutdown, "#2");
			Assert.IsNotNull (r.CallbackClientRuntime, "#3");
			Assert.IsNull (r.ExternalAuthorizationPolicies, "#4");
			Assert.IsFalse (r.IgnoreTransactionMessageProperty, "#5");
			Assert.IsFalse (r.ImpersonateCallerForAllOperations, "#6");
			Assert.AreEqual (0, r.InputSessionShutdownHandlers.Count, "#7");
			Assert.AreEqual (0, r.InstanceContextInitializers.Count, "#8");
			//Assert.AreEqual (0, r.InstanceContextLifetimes.Count, "#9");
			Assert.IsNull (r.InstanceProvider, "#10");
			Assert.AreEqual (AuditLevel.None,
					 r.MessageAuthenticationAuditLevel, "#11");
			Assert.AreEqual (0, r.MessageInspectors.Count, "#12");
			Assert.AreEqual (0, r.Operations.Count, "#13");
			Assert.IsNull (r.OperationSelector, "#14");
			// This is silly, but anyways there will be similar 
			// functionality that just represents unix "Groups".
			Assert.AreEqual (PrincipalPermissionMode.UseWindowsGroups,
					 r.PrincipalPermissionMode, "#15");
			Assert.IsFalse (r.ReleaseServiceInstanceOnTransactionComplete, "#16");
			Assert.IsNull (r.RoleProvider, "#17");
			Assert.AreEqual (AuditLevel.None, r.ServiceAuthorizationAuditLevel, "#18");
			Assert.IsNull (r.ServiceAuthorizationManager, "#19");
			Assert.IsTrue (r.SuppressAuditFailure, "#20");
			Assert.IsNull (r.SynchronizationContext, "#21");
			Assert.IsFalse (r.TransactionAutoCompleteOnSessionClose, "#22");
			Assert.IsNull (r.Type, "#23");
			Assert.IsNotNull (r.UnhandledDispatchOperation, "#24");
			DispatchOperation udo = r.UnhandledDispatchOperation;
			Assert.AreEqual ("*", udo.Name, "#24-2");
			Assert.AreEqual ("*", udo.Action, "#24-3");
			Assert.AreEqual ("*", udo.ReplyAction, "#24-4");
			Assert.IsFalse (udo.IsOneWay, "#24-5");
		}
	}
}