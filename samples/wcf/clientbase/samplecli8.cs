using System;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;

public class Tset
{
	public static void Main ()
	{
		var binding = new NetNamedPipeBinding ();
		binding.Security.Mode = NetNamedPipeSecurityMode.None;
		IFooChannel proxy = new ChannelFactory<IFooChannel> (
			binding,
			new EndpointAddress ("net.pipe://localhost/samplepipe")
			).CreateChannel ();
		proxy.Open ();
		Console.WriteLine (proxy.Echo ("TEST FOR ECHO"));
		Console.WriteLine (proxy.Add (1000, 2000));
	}
}

public interface IFooChannel : IFoo, IClientChannel
{
}

[ServiceContract]
public interface IFoo
{
	[OperationContract]
	string Echo (string msg);

	[OperationContract]
	uint Add (uint v1, uint v2);
}

