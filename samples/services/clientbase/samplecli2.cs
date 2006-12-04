using System;
using System.IO;
using System.Net;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

public class Test
{
	public static void Main ()
	{
		try {
			Run ();
		} catch (WebException ex) {
			Console.WriteLine (new StreamReader (ex.Response.GetResponseStream ()).ReadToEnd ());
		}
	}

	static void Run ()
	{
		FooProxy proxy = new FooProxy (
			new BasicHttpBinding (),
			new EndpointAddress ("http://localhost:8080/"));
		proxy.Open ();
			
		Message req = Message.CreateMessage (MessageVersion.Soap11, "http://tempuri.org/IFoo/Echo");
		Message res = proxy.Echo (req);
		using (XmlWriter w = XmlWriter.Create (Console.Out)) {
			res.WriteMessage (w);
		}
	}
}

public class FooProxy : ClientBase<IFoo>, IFoo
{
	public FooProxy (Binding binding, EndpointAddress address)
		: base (binding, address)
	{
	}

	public Message Echo (Message request)
	{
		return Channel.Echo (request);
	}
}

[ServiceContract]
public interface IFoo
{
	[OperationContract]
	Message Echo (Message request);
}
