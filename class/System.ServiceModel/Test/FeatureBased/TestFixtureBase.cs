using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using NUnit.Framework;

namespace MonoTests.Features
{
	public abstract class TestFixtureBase<TClient, TServer> where TClient : new()
	{
		TClient _client;		
		ServiceHost _hostBase;

		protected TestFixtureBase () { }		

		[SetUp]
		protected virtual void Run (){
			Run (true, true);			
		}

		protected void Run (bool runServer, bool runClient) {

			if (runServer) {
				_hostBase = InitializeServiceHost ();				
				_hostBase.Open ();
			}

			if (runClient)
				_client = InitializeClient ();			
		}				

		protected virtual TClient InitializeClient () {			
			return new TClient ();
		}

		protected virtual ServiceHost InitializeServiceHost () {
			return new ServiceHost (typeof (TServer));
		}

		protected TClient Client {
			get {
				return _client;
			}			
		}

		protected ServiceHost Host {
			get {
				return _hostBase;
			}
		}

		[TearDown]
		protected virtual void Close () {
			if (Host.State == CommunicationState.Opened)
				Host.Close ();
		}
	}
}
