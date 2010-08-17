using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;
using System.ServiceModel.Dispatcher;

public class Tset
{
	public static void Main ()
	{
		ServiceHost host = new ServiceHost (typeof (Foo));
		var binding = new UdpAnnouncementEndpoint ().Binding;
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		binding.OpenTimeout = TimeSpan.FromSeconds (20);
		host.AddServiceEndpoint ("IFoo",
			binding, UdpAnnouncementEndpoint.DefaultIPv4MulticastAddress);
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
	[OperationContract (IsOneWay = true)]
	void SendMsg (string msg);
}

class Foo : IFoo
{
	public void SendMsg (string msg) 
	{
		Console.WriteLine (msg);
	}
}

