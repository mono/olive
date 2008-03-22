using System;
using System.Xml;
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
		ServiceHost host = new ServiceHost (typeof (Foo));
		host.Description.Behaviors.Find<ServiceDebugBehavior> ().IncludeExceptionDetailInFaults = true;
		Binding binding = new BasicHttpBinding ();
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		host.AddServiceEndpoint ("IFoo",
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
	Message Echo (Message request);
}

class Foo : IFoo
{
	public Message Echo (Message request) 
	{
		Message msg = Message.CreateMessage (request.Version, request.Headers.Action + "Response");
		msg.Headers.Add (MessageHeader.CreateHeader ("hoge", "urn:hoge", "heh"));
		//msg.Headers.Add (MessageHeader.CreateHeader ("test", "http://schemas.microsoft.com/ws/2005/05/addressing/none", "testing"));
		return msg;
	}
}

