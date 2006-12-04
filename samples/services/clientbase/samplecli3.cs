using System;
using System.IO;
using System.Net;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

public class Tset
{
	public static void Main ()
	{
		try {
			Run ();
		} catch (WebException ex) {
			Console.WriteLine ("WebException: " + ex.Message);
			Console.WriteLine (new StreamReader (ex.Response.GetResponseStream ()).ReadToEnd ());
		}
	}

	static void Run ()
	{
		MetadataExchangeProxy proxy = new MetadataExchangeProxy (
			new BasicHttpBinding (),
			new EndpointAddress ("http://localhost:8080/"));
		proxy.Open ();
			
		Message req = Message.CreateMessage (MessageVersion.Soap11, "http://schemas.xmlsoap.org/ws/2004/09/transfer/Get");
		Message res = proxy.Get (req);
		using (XmlWriter w = XmlWriter.Create (Console.Out)) {
			res.WriteMessage (w);
		}
	}
}

public class MetadataExchangeProxy : ClientBase<IMetadataExchange>, IMetadataExchange
{
	public MetadataExchangeProxy (Binding binding, EndpointAddress address)
		: base (binding, address)
	{
	}

	public Message Get (Message request)
	{
		return Channel.Get (request);
	}

	public IAsyncResult BeginGet (Message request, AsyncCallback callback, object state)
	{
		throw new NotImplementedException ();
	}

	public Message EndGet (IAsyncResult result)
	{
		throw new NotImplementedException ();
	}
}

