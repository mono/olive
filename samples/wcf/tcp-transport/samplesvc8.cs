using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

public class Test
{
	public static void Main ()
	{
		ServiceHost host = new ServiceHost (typeof (Foo));
		var binding = new CustomBinding (new BindingElement [] {
			new BinaryMessageEncodingBindingElement (),
			new HttpTransportBindingElement () });
		var address = new Uri ("http://localhost:8080");
		host.AddServiceEndpoint ("IFoo", binding, address);
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

