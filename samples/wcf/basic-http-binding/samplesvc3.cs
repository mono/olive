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
		host.Description.Behaviors.Find<ServiceDebugBehavior> ()
			.IncludeExceptionDetailInFaults = true;
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
	Message ProcessMessage (Message msg);
}

class Foo : IFoo
{
	public Message ProcessMessage (Message msg) 
	{
Console.WriteLine (msg);
		var ret = Message.CreateMessage (msg.Version,
			MessageFault.CreateFault (new FaultCode ("mycode"), "private affair"),
			"http://tempuri.org/IFoo/ProcessMessageResponse"
			);
Console.WriteLine (ret.IsFault);
		return ret;
	}
}

