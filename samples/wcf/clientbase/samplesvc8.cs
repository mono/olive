using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

public class Tset
{
	public static void Main ()
	{
		var host = new ServiceHost (typeof (Foo));
		var binding = new NetNamedPipeBinding ();
		binding.TransferMode = TransferMode.Streamed;
		binding.Security.Mode = NetNamedPipeSecurityMode.None;
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		binding.OpenTimeout = TimeSpan.FromSeconds (20);
		host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("net.pipe://localhost/samplepipe"));
		host.Description.Behaviors.Find<ServiceBehaviorAttribute> ()
			.IncludeExceptionDetailInFaults = true;
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

	[OperationContract]
	uint Add (uint v1, uint v2);
}

class Foo : IFoo
{
	public string Echo (string msg) 
	{
		return msg + msg;
	}

	public uint Add (uint v1, uint v2)
	{
		return v1 + v2;
	}
}

