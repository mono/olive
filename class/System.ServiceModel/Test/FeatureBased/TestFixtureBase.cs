using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using NUnit.Framework;
using System.Reflection;
using System.Threading;
using System.Configuration;

namespace MonoTests.Features
{
	public class Configuration
	{
		static Configuration() {
			onlyServers = Boolean.Parse (ConfigurationManager.AppSettings ["onlyServers"]  ?? "false");
			onlyClients = Boolean.Parse (ConfigurationManager.AppSettings ["onlyClients"]  ?? "false");
			endpointBase = ConfigurationManager.AppSettings ["endpointBase"] ?? "http://localhost:9999/";
			if (!endpointBase.EndsWith ("/"))
				endpointBase = endpointBase + '/';
		}
		public static bool onlyServers;
		public static bool onlyClients;
		public static string endpointBase;
	}


	public abstract class TestFixtureBase<TClient, TServer, IServer> where TClient : new() where TServer: new()
	{
		ServiceHost _hostBase;

		protected TestFixtureBase () { }		

		[SetUp]
		public virtual void Run (){
			bool runServer = true;
			bool runClient = true;
			if (Configuration.onlyClients)
				runServer = false;
			if (Configuration.onlyServers)
				runClient = false;
			Run (runServer, runClient);			
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
			return Configuration.endpointBase + typeof(TServer).Name;
        }

		TClient _client;
		protected virtual TClient InitializeClient () {
			//return new TClient(new BasicHttpBinding(), new EndpointAddress( getEndpoint) );
			Type [] paramsTypes = new Type [] { typeof (Binding), typeof (EndpointAddress) };
			object [] parameters = new object [] { new BasicHttpBinding (), new EndpointAddress (getEndpoint())};

			ConstructorInfo info = typeof (TClient).GetConstructor (paramsTypes);
			return (TClient) info.Invoke (parameters);
		}

		public TClient Client {
			get {
				return _client;
			}			
		}

		protected virtual ServiceHost InitializeServiceHost () {
            ServiceHost host = new ServiceHost(typeof(TServer));
            host.AddServiceEndpoint(typeof(IServer), new BasicHttpBinding(), getEndpoint());
			ServiceMetadataBehavior smb = new ServiceMetadataBehavior ();
			smb.HttpGetEnabled = true;
			smb.HttpGetUrl = new Uri (getEndpoint ());
			host.Description.Behaviors.Add (smb);
            return host;
		}


		protected ServiceHost Host {
			get {
				return _hostBase;
			}
		}

		[TearDown]
		protected virtual void Close () {
			if (!Configuration.onlyClients && !Configuration.onlyServers &&  Host.State == CommunicationState.Opened)
				Host.Close ();
		}
	}
}
