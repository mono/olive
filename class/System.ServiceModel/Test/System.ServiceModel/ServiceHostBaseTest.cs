//
// ServiceHostBaseTest.cs
//
// Author:
//	Igor Zelmanovich <igorz@mainsoft.com>
//
// Copyright (C) 2008 Mainsoft, Inc.  http://www.mainsoft.com
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
using System.Text;
using NUnit.Framework;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace MonoTests.System.ServiceModel
{
	[TestFixture]
	public class ServiceHostBaseTest
	{
		class Poker : ServiceHostBase
		{
			public event EventHandler OnApplyConfiguration;

			protected override ServiceDescription CreateDescription (out IDictionary<string, ContractDescription> implementedContracts) {
				implementedContracts = new Dictionary<string, ContractDescription> ();
				ServiceDescription description = new ServiceDescription ();
				description.ServiceType = typeof (MyService);
				description.Behaviors.Add (new ServiceBehaviorAttribute ());
				return description;
			}

			protected override void ApplyConfiguration () {
				if (OnApplyConfiguration != null)
					OnApplyConfiguration (this, EventArgs.Empty);
				base.ApplyConfiguration ();
			}

			public void CallInitializeDescription () {
				InitializeDescription (new UriSchemeKeyedCollection ());
			}

			protected override void InitializeRuntime () {
				base.InitializeRuntime ();
			}

			public void CallInitializeRuntime () {
				InitializeRuntime ();
			}
		}

		[Test]
		public void Ctor () {
			Poker host = new Poker ();

			Assert.AreEqual (null, host.Description, "Description");
			Assert.AreEqual (null, host.Authorization, "Authorization");
		}

		[Test]
		public void DefaultConfiguration () {
			Poker host = new Poker ();
			host.OnApplyConfiguration += delegate (object sender, EventArgs e) {
				Assert.AreEqual (1, host.Description.Behaviors.Count, "Description.Behaviors.Count #1");
			};
			host.CallInitializeDescription ();

			Assert.AreEqual (true, host.Description.Behaviors.Count > 1, "Description.Behaviors.Count #2");

			Assert.IsNotNull (host.Description.Behaviors.Find<ServiceDebugBehavior> (), "ServiceDebugBehavior");
			Assert.IsNotNull (host.Description.Behaviors.Find<ServiceAuthorizationBehavior> (), "ServiceDebugBehavior");
			Assert.IsNotNull (host.Authorization, "Authorization #1");

			Assert.AreEqual (host.Description.Behaviors.Find<ServiceAuthorizationBehavior> (), host.Authorization, "Authorization #2");
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void ApplyConfigurationNoDescription () {
			CustomServiceHost customHost = new CustomServiceHost ();
			customHost.ApplyConfiguration ();
		}

		class CustomServiceHost : ServiceHostBase
		{

			public CustomServiceHost () {

			}

			public void ApplyConfiguration () {
				base.ApplyConfiguration ();
			}

			protected override ServiceDescription CreateDescription (out IDictionary<string, ContractDescription> implementedContracts) {
				throw new NotImplementedException ();
			}
		}

		[Test]
		public void InitializeRuntime () {
			Poker host = new Poker ();
			host.CallInitializeDescription ();
			EndpointAddress address = new EndpointAddress ("http://localhost:8090/");
			ContractDescription contract = ContractDescription.GetContract (typeof (IMyContract));
			ServiceEndpoint endpoint = new ServiceEndpoint (contract, new BasicHttpBinding (), address);
			endpoint.ListenUri = address.Uri;
			host.Description.Endpoints.Add (endpoint);

			Assert.AreEqual (0, host.ChannelDispatchers.Count, "ChannelDispatchers.Count #1");

			host.CallInitializeRuntime ();

			Assert.AreEqual (1, host.ChannelDispatchers.Count, "ChannelDispatchers.Count #1");
			Assert.AreEqual (CommunicationState.Created, host.ChannelDispatchers [0].State, "ChannelDispatchers.Count #1");
		}

		[ServiceContract]
		interface IMyContract
		{
			[OperationContract]
			string GetData ();
		}

		class MyService : IMyContract
		{
			public string GetData () {
				return "Hello World";
			}
		}
	}
}
