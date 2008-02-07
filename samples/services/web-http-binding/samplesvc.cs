using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

public class Test
{
	// It is not working with mono!
	public static void Main ()
	{
		string url = "http://localhost:8080/";
		WebHttpBinding b = new WebHttpBinding ();
		var host = new WebServiceHost (typeof (MyService), new Uri (url));
		host.AddServiceEndpoint ("MyService", b, "");
		host.Description.Behaviors.Find<ServiceDebugBehavior> ().IncludeExceptionDetailInFaults = true;
		host.Description.Behaviors.Find<ServiceDebugBehavior> ().HttpHelpPageEnabled = true;
		host.Open ();
		Console.WriteLine ("--- enter ---");
		Console.ReadLine ();
		host.Close ();
	}
}

[ServiceContract]
public class MyService
{
	[OperationContract]
	[WebGet]
	public string Greet (string input)
	{
		return "huh? " + input;
	}
}

