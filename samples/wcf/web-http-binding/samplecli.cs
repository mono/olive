using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

public class Test
{
	// It is not working with mono!
	public static void Main ()
	{
		string url = "http://localhost:8080";
		//WebHttpBinding b = new WebHttpBinding ();
		CustomBinding b = new CustomBinding (
			new WebMessageEncodingBindingElement (),
			new InterceptorBindingElement (),
			new HttpTransportBindingElement () { ManualAddressing = true });
		var f = new WebChannelFactory<IMyService> (b, new Uri (url));
		// this causes NRE (even if the endpointaddress is specified at CreateChannel()).
		// var f = new WebChannelFactory<IMyService> (b); 
		IMyService s = f.CreateChannel ();
		Console.WriteLine (s.Greet ("hogehoge"));
	}
}

public class InterceptorBindingElement : BindingElement
{
	public override T GetProperty<T> (BindingContext context)
	{
Console.WriteLine (context.BindingParameters.Count);
foreach (object o in context.BindingParameters) Console.WriteLine (o.GetType ());
		return context.GetInnerProperty<T> ();
		//throw new NotImplementedException ();
	}

	public override BindingElement Clone ()
	{
		return this;
	}
}

[ServiceContract]
public interface IMyService
{
	[OperationContract]
	//[WebGet (RequestFormat = WebMessageFormat.Json, UriTemplate = "/{foo}/{foo}")]
	//[WebGet (RequestFormat = WebMessageFormat.Json)]
	[WebGet]
	string Greet (string input);
}

