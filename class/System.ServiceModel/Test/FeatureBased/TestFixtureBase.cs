using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using NUnit.Framework;
using System.Reflection;

namespace MonoTests.Features
{
	public abstract class TestFixtureBase<TClient, TServer, IServer> where TClient : new() where TServer: new()
	{
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

        string getEndpoint()
        {
			return "http://localhost:9999/" + typeof(TServer).Name
        }

		TClient _client;
		protected virtual TClient InitializeClient () {
			//return new TClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:9999/" + typeof(TServer).Name));
			Type [] paramsTypes = new Type [] { typeof (Binding), typeof (EndpointAddress) };
			object [] parameters = new object [] { new BasicHttpBinding (), new EndpointAddress (getEndpoint())};

			ConstructorInfo info = typeof (TClient).GetConstructor (paramsTypes);
			return (TClient) info.Invoke (parameters);
		}

		protected TClient Client {
			get {
				return _client;
			}			
		}

		protected virtual ServiceHost InitializeServiceHost () {
            ServiceHost host = new ServiceHost(typeof(TServer));
            host.AddServiceEndpoint(typeof(IServer), new BasicHttpBinding(), getEndpoint());
            return host;
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
