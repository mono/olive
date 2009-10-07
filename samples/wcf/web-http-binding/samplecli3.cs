using System;
using System.Runtime.Serialization;
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
		Console.WriteLine (((Wrapper) s.Greet ("hogehoge")).Value);
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
	[WebGet (RequestFormat = WebMessageFormat.Json)]
	// This contract is not symmetric between server and client, because
	// with WebScriptEnablingBehavior the return value is wrapped with "d"
	Wrapper Greet (string input);
}

[DataContract]
public class Wrapper
{
	[DataMember (Name = "d")]
	public object Value;
}
