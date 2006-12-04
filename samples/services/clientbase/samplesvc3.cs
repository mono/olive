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
		ServiceHost host = new ServiceHost (typeof (MetadataExchange));
		host.Description.Behaviors.Find<ServiceDebugBehavior> ().IncludeExceptionDetailInFaults = true;
		Binding binding = new BasicHttpBinding ();
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		host.AddServiceEndpoint ("IMetadataExchange",
			binding, new Uri ("http://localhost:8080"));
		host.Open ();
		Console.WriteLine ("Hit [CR] key to close ...");
		Console.ReadLine ();
		host.Close ();
	}
}


class MetadataExchange : IMetadataExchange
{
	public Message Get (Message request)
	{
		XmlDocument doc = new XmlDocument ();
		doc.AppendChild (doc.CreateElement ("Metadata", "http://schemas.xmlsoap.org/ws/2004/09/mex"));
		return Message.CreateMessage (request.Version,
			"http://schemas.xmlsoap.org/ws/2004/09/transfer/GetResponse",
			new XmlNodeReader (doc));
	}

	public IAsyncResult BeginGet (Message request, AsyncCallback cb, object state)
	{
		throw new NotImplementedException ();
	}

	public Message EndGet (IAsyncResult result)
	{
		throw new NotImplementedException ();
	}
}

