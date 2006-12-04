using System;
using System.Runtime.Serialization;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;

[DataContract (Name = "Echo", Namespace = "http://tempuri.org/")]
public class EchoType
{
	public EchoType (string msg)
	{
		this.msg = msg;
	}

	[DataMember]
	public string msg = "test";
}

public class Tset
{
	public static void Main ()
	{
		Binding b = new BasicHttpBinding ();
		IChannelFactory<IRequestChannel> cf = b.BuildChannelFactory<IRequestChannel> (
			new BindingParameterCollection ());
		cf.Open ();
		IRequestChannel req  = cf.CreateChannel (
			new EndpointAddress ("http://localhost:8080/"));
		Console.WriteLine (req.State);
		req.Open ();
		Message msg = Message.CreateMessage (MessageVersion.Soap11, "http://tempuri.org/IFoo/Echo", new EchoType ("hoge"));

		//Message ret = req.Request (msg);
		IAsyncResult result = req.BeginRequest (msg, null, null);
		//return;
		Message ret = req.EndRequest (result);
		Console.WriteLine (req.State);
		using (XmlWriter w = XmlWriter.Create (Console.Out)) {
			ret.WriteMessage (w);
		}
	}
}

[ServiceContract]
public interface IFoo
{
	[OperationContract]
	string Echo (string msg);
}


