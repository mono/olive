using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

public class Test
{
	// It is not working with mono!
	public static void Main ()
	{
		string url = "http://localhsot:8080";
		WebHttpBinding b = new WebHttpBinding ();
		var f = new WebChannelFactory<IMyService> (b, new Uri (url));
		// this causes NRE (even if the endpointaddress is specified at CreateChannel()).
		// var f = new WebChannelFactory<IMyService> (b); 
		f.Endpoint.Behaviors.Add (new WebHttpBehavior ());
		IMyService s = f.CreateChannel ();
		Console.WriteLine (s.Greet ("hogehoge"));
	}
}

[ServiceContract]
public interface IMyService
{
	[OperationContract]
	[WebGet]
	string Greet (string input);
}

public class MyService : IMyService
{
	public string Greet (string input)
	{
		return "huh? " + input;
	}
}

