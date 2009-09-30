using System;
using System.ServiceModel;
using System.ServiceModel.Description;

#if CONSOLE
public class Test
{
	public static void Main ()
	{
		var host = new ServiceHost (typeof (TestService), new Uri ("http://localhost:8080/test.svc"));
		host.Open ();
		Console.WriteLine ("Type [CR] to quit...");
		Console.ReadLine ();
		host.Close ();
	}
}
#endif

[ServiceContract]
public interface ITestService
{
	[OperationContract]
	string Echo (string msg);
}

public class TestService : ITestService
{
	public string Echo (string msg)
	{
Console.WriteLine (OperationContext.Current.Host.ChannelDispatchers.Count);
		return msg;
	}
}

