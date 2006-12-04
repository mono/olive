using System;
using System.Configuration;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;

public class Tset
{
	public static void Main ()
	{
		FooProxy proxy = new FooProxy (String.Empty);
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
	public FooProxy (string endpointConfigurationName)
		: base (endpointConfigurationName)
	{
	}

	public string Echo (string msg)
	{
		return Channel.Echo (msg);
	}
}

