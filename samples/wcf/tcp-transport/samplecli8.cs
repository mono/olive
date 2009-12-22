using System;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;

public class Tset
{
	public static void Main ()
	{
		var binding = new CustomBinding (
			new BinaryMessageEncodingBindingElement (),
			new HttpTransportBindingElement ());
		var address = new EndpointAddress ("http://localhost:8080");
		var proxy = new ChannelFactory<IFoo> (binding, address)
			.CreateChannel ();
		Console.WriteLine (proxy.Echo ("TEST FOR ECHO"));
		Console.WriteLine (proxy.Add (1000, 2000));
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

