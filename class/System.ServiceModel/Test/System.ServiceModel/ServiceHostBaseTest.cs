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
using System.ServiceModel.Dispatcher;
using SMMessage = System.ServiceModel.Channels.Message;
using System.ServiceModel.Channels;

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

		[Test]
		[Category("NotWorking")]
		public void ChannelDispatchers_NoDebug () {
			ServiceHost h = new ServiceHost (typeof (AllActions), new Uri ("http://localhost:8080"));
			h.AddServiceEndpoint (typeof (AllActions).FullName, new BasicHttpBinding (), "address");

			ServiceDebugBehavior b = h.Description.Behaviors.Find<ServiceDebugBehavior> ();
			b.HttpHelpPageEnabled = false;						

			h.Open ();
			Assert.AreEqual (h.ChannelDispatchers.Count, 1);
			ChannelDispatcher channelDispatcher =  h.ChannelDispatchers[0] as ChannelDispatcher;
			Assert.IsNotNull (channelDispatcher, "#1");
			Assert.IsTrue (channelDispatcher.Endpoints.Count == 1, "#2");
			EndpointAddressMessageFilter filter = channelDispatcher.Endpoints [0].AddressFilter as EndpointAddressMessageFilter;
			Assert.IsNotNull (filter, "#3");
			Assert.IsTrue (filter.Address.Equals (new EndpointAddress ("http://localhost:8080/address")), "#4");
			Assert.IsFalse (filter.IncludeHostNameInComparison, "#5");
			Assert.IsTrue (channelDispatcher.Endpoints [0].ContractFilter is MatchAllMessageFilter, "#6");
			h.Close ();
		}

		[Test]
		[Category ("NotWorking")]
		public void ChannelDispatchers_WithDebug () {
			ServiceHost h = new ServiceHost (typeof (AllActions), new Uri ("http://localhost:8080"));
			h.AddServiceEndpoint (typeof (AllActions).FullName, new BasicHttpBinding (), "address");
			ServiceMetadataBehavior b = new ServiceMetadataBehavior ();
			b.HttpGetEnabled = true;
			b.HttpGetUrl = new Uri( "http://localhost:8080" );
			h.Description.Behaviors.Add (b);
			h.Open ();

			Assert.AreEqual (h.ChannelDispatchers.Count, 2, "#1");
			ChannelDispatcher channelDispatcher = h.ChannelDispatchers[1] as ChannelDispatcher;
			Assert.IsNotNull (channelDispatcher, "#2");
			Assert.IsTrue (channelDispatcher.Endpoints.Count == 1, "#3");
			EndpointAddressMessageFilter filter = channelDispatcher.Endpoints [0].AddressFilter as EndpointAddressMessageFilter;
			Assert.IsNotNull (filter, "#4");
			Assert.IsTrue (filter.Address.Equals (new EndpointAddress ("http://localhost:8080")), "#5");
			Assert.IsFalse (filter.IncludeHostNameInComparison, "#6");
			Assert.IsTrue (channelDispatcher.Endpoints [0].ContractFilter is MatchAllMessageFilter, "#7");
			h.Close ();
		}

		[Test]
		[Category ("NotWorking")]
		public void SpecificActionTest () {
			//EndpointDispatcher d = new EndpointDispatcher(
			ServiceHost h = new ServiceHost (typeof (SpecificAction), new Uri ("http://localhost:8080"));
			h.AddServiceEndpoint (typeof (SpecificAction).FullName, new BasicHttpBinding (), "address");
						
			h.Open ();
			ChannelDispatcher d = h.ChannelDispatchers [0] as ChannelDispatcher;
			EndpointDispatcher ed = d.Endpoints [0] as EndpointDispatcher;
			ActionMessageFilter actionFilter = ed.ContractFilter as ActionMessageFilter;
			Assert.IsNotNull (actionFilter, "#1");
			Assert.IsTrue (actionFilter.Actions.Count == 1, "#2");
			h.Close();
		}

		[Test]
		[Category ("NotWorking")]
		public void Attach () {
			ServiceHost h = new ServiceHost (typeof (AllActions), new Uri ("http://localhost:8080"));
			h.AddServiceEndpoint (typeof (AllActions).FullName, new BasicHttpBinding (), "address");
			MyChannelDispatcher d = new MyChannelDispatcher (new MyChannelListener());
			h.ChannelDispatchers.Add (d);
			Assert.IsTrue (d.Attached, "#1");
		}

		[ServiceContract]
		class AllActions
		{
			[OperationContract (Action = "*", ReplyAction = "*")]
			public SMMessage Get (SMMessage req) {
				return null;
			}
		}

		[ServiceContract]
		class SpecificAction
		{
			[OperationContract (Action = "Specific", ReplyAction = "*")]
			public SMMessage Get (SMMessage req) {
				return null;
			}
		}

		class MyChannelDispatcher : ChannelDispatcher
		{
			public bool Attached = false;

			public MyChannelDispatcher (IChannelListener l) : base (l) { }
			protected override void Attach (ServiceHostBase host) {
				base.Attach (host);
				Attached = true;
			}
		}

		class MyChannelListener : IChannelListener
		{
			#region IChannelListener Members

			public IAsyncResult BeginWaitForChannel (TimeSpan timeout, AsyncCallback callback, object state) {
				throw new NotImplementedException ();
			}

			public bool EndWaitForChannel (IAsyncResult result) {
				throw new NotImplementedException ();
			}

			public T GetProperty<T> () where T : class {
				throw new NotImplementedException ();
			}

			public Uri Uri {
				get { throw new NotImplementedException (); }
			}

			public bool WaitForChannel (TimeSpan timeout) {
				throw new NotImplementedException ();
			}

			#endregion

			#region ICommunicationObject Members

			public void Abort () {
				throw new NotImplementedException ();
			}

			public IAsyncResult BeginClose (TimeSpan timeout, AsyncCallback callback, object state) {
				throw new NotImplementedException ();
			}

			public IAsyncResult BeginClose (AsyncCallback callback, object state) {
				throw new NotImplementedException ();
			}

			public IAsyncResult BeginOpen (TimeSpan timeout, AsyncCallback callback, object state) {
				throw new NotImplementedException ();
			}

			public IAsyncResult BeginOpen (AsyncCallback callback, object state) {
				throw new NotImplementedException ();
			}

			public void Close (TimeSpan timeout) {
				throw new NotImplementedException ();
			}

			public void Close () {
				throw new NotImplementedException ();
			}

			public event EventHandler Closed;

			public event EventHandler Closing;

			public void EndClose (IAsyncResult result) {
				throw new NotImplementedException ();
			}

			public void EndOpen (IAsyncResult result) {
				throw new NotImplementedException ();
			}

			public event EventHandler Faulted;

			public void Open (TimeSpan timeout) {
				throw new NotImplementedException ();
			}

			public void Open () {
				throw new NotImplementedException ();
			}

			public event EventHandler Opened;

			public event EventHandler Opening;

			public CommunicationState State {
				get { throw new NotImplementedException (); }
			}

			#endregion
		}
	}
}
