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
		var smb = new ServiceMetadataBehavior ();
		smb.HttpGetEnabled = true;
		smb.HttpGetUrl = new Uri ("http://localhost:8080/wsdl");
		host.Description.Behaviors.Add (smb);
		Binding binding = new BasicHttpBinding ();
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		ServiceEndpoint se = host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("http://localhost:8080"));
		host.Open ();
		Console.WriteLine ("Hit [CR] key to close ...");
		Console.ReadLine ();
		host.Close ();
	}
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
	}
}

