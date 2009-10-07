using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

public class MyHostFactory : WebScriptServiceHostFactory
{
	public ServiceHostBase DoCreateServiceHost (Type type, params Uri [] baseAddresses)
	{
		return CreateServiceHost (type, baseAddresses);
	}
}

public class Test
{
	// It is not working with mono!
	public static void Main ()
	{
		string url = "http://localhost:8080/";
		WebHttpBinding b = new WebHttpBinding ();
		var host = new MyHostFactory ().DoCreateServiceHost (typeof (MyService), new Uri (url));
		ServiceEndpoint se = host.AddServiceEndpoint ("MyService", b, url);
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
	[WebGet (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
	public string Greet (string input)
	{
Console.WriteLine (ServiceHostingEnvironment.AspNetCompatibilityEnabled);
		Console.WriteLine ("Input: " + input);
		return "huh? " + input;
	}
}

