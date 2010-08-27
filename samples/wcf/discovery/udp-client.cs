using System;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Discovery;

public class Tset
{
	public static void Main ()
	{
		var uri = new Uri ("soap.udp://239.255.255.250:3802");
		for (int i = 0; i < 2; i++) {
		var binding = new UdpAnnouncementEndpoint (uri).Binding;
		IFooChannel proxy = new ChannelFactory<IFooChannel> (
			binding,
			new EndpointAddress (uri)
			).CreateChannel ();
		proxy.Open ();
		proxy.SendMsg ("TEST FOR ECHO");
		}
	}
}

public interface IFooChannel : IFoo, IClientChannel
{
}

[ServiceContract]
public interface IFoo
{
	[OperationContract (IsOneWay = true)]
	void SendMsg (string msg);
}

