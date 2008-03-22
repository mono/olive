using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

public class Test
{
	// It is not working with mono!
	public static void Main ()
	{
		string url = "http://localhost:8080/";
		WebHttpBinding b = new WebHttpBinding ();
		var host = new WebServiceHost (typeof (MyService), new Uri (url));
		ServiceEndpoint se = host.AddServiceEndpoint ("MyService", b, "");
		se.Behaviors.Add (new MyWebBehavior ());
		host.Open ();
		Console.WriteLine ("--- enter ---");
		Console.ReadLine ();
		host.Close ();
	}
}

public class MyDispatchMessageFormatter : IDispatchMessageFormatter
{
	IDispatchMessageFormatter src;

	public MyDispatchMessageFormatter (IDispatchMessageFormatter source)
	{
		this.src = source;
	}

	public void DeserializeRequest (Message msg, object [] parameters)
	{
Console.WriteLine ("!!! " + OperationContext.Current);
		src.DeserializeRequest (msg, parameters);
	}

	public Message SerializeReply (MessageVersion messageVersion, object [] parameters, object result)
	{
		return src.SerializeReply (messageVersion, parameters, result);
	}
}

public class MySelector : WebHttpDispatchOperationSelector
{
	public MySelector (ServiceEndpoint se)
		: base (se)
	{
		endpoint = se;
	}

	ServiceEndpoint endpoint;

	protected override string SelectOperation (ref Message message, out bool uriMatched)
	{
		/*
		foreach (OperationDescription od in endpoint.Contract.Operations)
			foreach (object obj in od.Behaviors)
				Console.WriteLine (obj);
		Console.WriteLine ("Message: " + message);
		Console.WriteLine ("To: " + message.Headers.To);
		foreach (string s in message.Properties.Keys)
			Console.WriteLine ("{0}: {1}", s, message.Properties [s]);
		HttpRequestMessageProperty p = message.Properties [HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
		Console.WriteLine ("p.QueryString: {0}", p.QueryString);
		foreach (string s in p.Headers.Keys)
			Console.WriteLine ("{0}: {1}", s, p.Headers [s]);
		*/
		string ret = base.SelectOperation (ref message, out uriMatched);
		// Console.WriteLine ("{0} {1}", ret, uriMatched);
		// Console.WriteLine ("_____________________");
		return ret;
	}
}

public class MyWebBehavior : WebHttpBehavior
{
	public override void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
	{
		base.ApplyDispatchBehavior (endpoint, endpointDispatcher);
Console.WriteLine (endpointDispatcher.AddressFilter);
		endpointDispatcher.AddressFilter = new MyEndpointAddressMessageFilter (endpoint.Address);
	}

	protected override IDispatchMessageFormatter GetRequestDispatchFormatter (OperationDescription operation, ServiceEndpoint endpoint)
	{
		return new MyDispatchMessageFormatter (base.GetRequestDispatchFormatter (operation, endpoint));
	}

	protected override WebHttpDispatchOperationSelector GetOperationSelector (ServiceEndpoint endpoint)
	{
		return new MySelector (endpoint);
	}
}

//public class MyEndpointAddressMessageFilter : EndpointAddressMessageFilter
public class MyEndpointAddressMessageFilter : PrefixEndpointAddressMessageFilter
{
	public MyEndpointAddressMessageFilter (EndpointAddress ea)
		: base (ea)
	{
	}
	protected override IMessageFilterTable<FilterData> CreateFilterTable<FilterData> ()
	{
		//throw new Exception ();
		return base.CreateFilterTable<FilterData> ();
	}

	public override bool Match (Message message)
	{
		Console.WriteLine ("*** To: " + message.Headers.To);
		return base.Match (message);
	}

	public override bool Match (MessageBuffer buffer)
	{
		Console.WriteLine (buffer.CreateMessage ().Headers.To);
		return base.Match (buffer);
	}
}

[ServiceContract]
public class MyService
{
	[OperationContract]
	[WebGet (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
	public string Greet (string input)
	{
		Console.WriteLine ("Input: " + input);
		return "huh? " + input;
	}
}

