using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;

public class Test
{
	public static void Main ()
	{
		var ch = new WebChannelFactory<IHogeClient> (
			//new CustomBinding (new WebMessageEncodingBindingElement (), new HttpTransportBindingElement () { ManualAddressing = true }),
			new WebHttpBinding (),
			new Uri ("http://localhost:8080"))
			.CreateChannel ();

		//new OperationContextScope ((IContextChannel) ch);
		//WebOperationContext.Current.OutgoingRequest.Method = "GET";
		//OperationContext.Current.OutgoingMessageHeaders.To =
		//	new Uri ("http://localhost:8080/Join?s1=foo");

		Console.WriteLine (ch.Echo ("really?"));
		Console.WriteLine (ch.Join ("foo", "bar"));
	}
}

[ServiceContract]
public interface IHogeService
{
	[WebGet]
	[OperationContract]
	string Echo (string s);

	[OperationContract]
	[WebInvoke (Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped)]
	string Join (string s1, string s2);
}

public interface IHogeClient : IHogeService, IClientChannel
{
}

