using System;
using System.Runtime.Serialization;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

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
		var b = new BasicHttpBinding ();
		b.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
		b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
		var cc = new ClientCredentials ();
		cc.UserName.UserName = "mono";
		IChannelFactory<IRequestChannel> cf = b.BuildChannelFactory<IRequestChannel> (cc);
		cf.Open ();
		IRequestChannel req  = cf.CreateChannel (
			new EndpointAddress ("http://localhost:8080/"));
		Console.WriteLine (cf.GetProperty<ClientCredentials> ());
		req.Open ();
		Message msg = Message.CreateMessage (MessageVersion.Soap11, "http://tempuri.org/IFoo/Echo", new EchoType ("hoge"));

		//Message ret = req.Request (msg);
		IAsyncResult result = req.BeginRequest (msg, null, null);
		//return;
		Message ret = req.EndRequest (result);
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


