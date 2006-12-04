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
	}
}

[ServiceContract]
public interface IFoo
{
	[OperationContract]
	string Echo (string msg);
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
}

