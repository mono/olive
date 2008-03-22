using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;

public class Tset
{
	public static void Main ()
	{
		ServiceHost host = new ServiceHost (typeof (Foo));
		Binding binding = new WSHttpBinding ();
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("http://localhost:8080"));
		host.Description.Behaviors.Find<ServiceDebugBehavior> ().IncludeExceptionDetailInFaults = true;
		host.Open ();
		Console.WriteLine ("Hit [CR] key to close ...");
		Console.ReadLine ();
		host.Close ();
	}
}

[ServiceContract]
public interface IFoo
{
	[OperationContract (Action = "http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue")]
	Message Echo (Message msg);
}

class Foo : IFoo
{
	public Message Echo (Message msg) 
	{
		using (XmlWriter w = XmlWriter.Create (Console.Out)) {
			msg.WriteMessage (w);
		}
		throw new NotImplementedException ("you are here.");
	}
}

