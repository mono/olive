using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

public class MyHostFactory : WebScriptServiceHostFactory
{
	// Calling CreateServiceHost(string,Uri[]) is not valid outside ASP.NET
	// so we have to use custom factory...
	public ServiceHost CreateServiceHost (Type type)
	{
		return CreateServiceHost (type, new Uri [0]);
	}
}

public class Test
{
	public static void Main ()
	{
		var url = "http://localhost:8080";
		var host = new MyHostFactory ().CreateServiceHost (typeof (HogeService));
		var binding = new WebHttpBinding ();
		host.AddServiceEndpoint (typeof (IHogeService), binding, url);
		host.Open ();
		//Console.WriteLine ("js:");
		//Console.WriteLine (new WebClient ()
		//	.DownloadString (url + "/js"));
		Console.WriteLine ("jsdebug:");
		Console.WriteLine (new WebClient ()
			.DownloadString (url + "/jsdebug"));
		Console.WriteLine (new WebClient ()
			.DownloadString (url + "/Join?s1=foo&s2=bar"));
		foreach (ChannelDispatcher cd in host.ChannelDispatchers) {
			Console.WriteLine ("BindingName: " + cd.BindingName);
			Console.WriteLine (cd.Listener.Uri);
			foreach (var o in cd.Endpoints [0].DispatchRuntime.Operations)
				Console.WriteLine ("OP: {0} {1}", o.Name, o.Action);
		}
		Console.WriteLine ("Type [CR] to close ...");
		Console.ReadLine ();
		host.Close ();
	}
}

[ServiceContract]
public interface IHogeService
{
	[WebGet]
	[OperationContract]
	string Echo (string s);

	[WebGet]
	// error -> [WebGet (BodyStyle = WebMessageBodyStyle.Wrapped)]
	[OperationContract]
	string Join (string s1, string s2);
}

public interface IHogeClient : IHogeService, IClientChannel
{
}

[ServiceBehavior (IncludeExceptionDetailInFaults = true)]
public class HogeService : IHogeService
{
	public string Echo (string s)
	{
		return "heh, I don't";
	}

	public string Join (string s1, string s2)
	{
		Console.WriteLine ("{0} + {1}", s1, s2);
		return s1 + s2;
	}
}
