using System;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;

public class Tset
{
	public static void Main ()
	{
		var binding = new NetTcpBinding ();
		binding.Security.Mode = SecurityMode.None;
		IFooChannel proxy = new ChannelFactory<IFooChannel> (
			binding,
			new EndpointAddress ("net.tcp://localhost:8080/")
			).CreateChannel ();
		proxy.Open ();
		Console.WriteLine (proxy.Echo ("TEST FOR ECHO"));
		Console.WriteLine (proxy.SessionId);
		Console.WriteLine (proxy.Add (1000, 2000));
		Console.WriteLine (proxy.SessionId);
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

public class FooProxy : ClientBase<IFoo>, IFoo
{
	public FooProxy (Binding binding, EndpointAddress address)
		: base (binding, address)
	{
	}

	public string Echo (string msg)
	{
		return Channel.Echo (msg);
	}

	public uint Add (uint v1, uint v2)
	{
Console.WriteLine ("Calling Add()");
		return Channel.Add (v1, v2);
	}
}

