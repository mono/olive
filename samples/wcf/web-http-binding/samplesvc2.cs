using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

public class Test
{
	public static void Main ()
	{
		var host = new WebServiceHost (typeof (HogeService));
		/*
		host.Description.Behaviors.Add (
			new ServiceMetadataBehavior () { HttpGetEnabled = true,
				HttpGetUrl = new Uri ("http://localhost:8080/HogeService/wsdl") });
		*/
		var binding = new WebHttpBinding ();
		host.AddServiceEndpoint (typeof (IHogeService),
			binding, "http://localhost:8080");
		host.Open ();
		Console.WriteLine ("Type [CR] to close");
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

	[WebGet (BodyStyle = WebMessageBodyStyle.Wrapped)]
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
