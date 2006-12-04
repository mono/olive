using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

public class Tset
{
	public class MyHost: ServiceHost
	{
		public MyHost (Type type) : base (type)
		{
			OpenTimeout = TimeSpan.FromSeconds (10);
		}
	}
	public static void Main ()
	{
		ServiceHost host = new MyHost (typeof (Foo));
		Binding binding = new BasicHttpBinding ();
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		ServiceEndpoint se = host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("http://localhost:8080"));
		host.Open ();
		Console.WriteLine ("Hit [CR] key to close ...");
		Console.ReadLine ();
		host.Close ();
	}

	/*
	class SvcWatcher : IServiceBehavior
	{
		public void AddBindingParameters (
			ServiceDescription description,
			ServiceHostBase serviceHostBase,
			Collection<ServiceEndpoint> behaviors,
			BindingParameterCollection parameters)
		{
			Console.WriteLine ("Svc.AddBindingParameters");
			Console.WriteLine (parameters.Count);
		}

		public void ApplyDispatchBehavior (
			ServiceDescription description,
			ServiceHostBase serviceHostBase)
		{
			Console.WriteLine ("Svc.ApplyDispatchBehavior");
			Console.WriteLine ("description : " + description.Endpoints.Count);
		}

		public void Validate (
			ServiceDescription description,
			ServiceHostBase serviceHostBase)
		{
			Console.WriteLine ("Svc.Validate");
		}
	}

	class CWatcher : IContractBehavior
	{
		public void AddBindingParameters (
			ContractDescription description,
			ServiceEndpoint endpoint,
			BindingParameterCollection parameters)
		{
			Console.WriteLine ("Contract.AddBindingParameters");
		}

		public void ApplyClientBehavior (
			ContractDescription description,
			ServiceEndpoint endpoint,
			ClientRuntime runtime)
		{
			Console.WriteLine ("Contract.ApplyClientBehavior");
		}

		public void ApplyDispatchBehavior (
			ContractDescription description,
			IEnumerable<ServiceEndpoint> endpoint,
			DispatchRuntime runtime)
		{
			Console.WriteLine ("Contract.ApplyDispatchBehavior");
		}

		public void Validate (
			ContractDescription description,
			ServiceEndpoint endpoint)
		{
			Console.WriteLine ("Contract.Validate");
		}

	}

	class SEWatcher : IEndpointBehavior
	{
		public void BindServiceEndpoint (ServiceEndpoint se,
			EndpointDispatcher el, BindingParameterCollection pl)
		{
			Console.WriteLine ("Endpoint");
			Console.WriteLine ("endpoint: " + se);
			Console.WriteLine ("listener: " + el);
			foreach (object o in pl)
				Console.WriteLine ("parameter: " + o);
		}
	}
	*/
}

[ServiceContract]
public interface IFoo
{
	[OperationContract]
	string Echo (string msg);
}

class Foo : IFoo
{
	public string Echo (string msg) 
	{
		return msg + msg;
		//throw new NotImplementedException ();
	}
}

