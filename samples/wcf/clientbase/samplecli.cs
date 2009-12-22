using System;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;

public class Tset
{
	public static void Main ()
	{
		FooProxy proxy = new FooProxy (
			new BasicHttpBinding (),
			new EndpointAddress ("http://localhost:8080/"));
		proxy.Open ();
		Console.WriteLine (proxy.Echo ("TEST FOR ECHO"));
		Console.WriteLine (proxy.Add (1000, 2000));
		Console.WriteLine ("done");
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
		return Channel.Add (v1, v2);
	}
}

