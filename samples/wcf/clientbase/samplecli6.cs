using System;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.PeerResolvers;

public class Tset
{
	public static void Main ()
	{
		var binding = new NetPeerTcpBinding ();
		binding.Resolver.Mode = PeerResolverMode.Custom;
		binding.Resolver.Custom.Address = new EndpointAddress ("net.tcp://localhost:8086");
		var tcp = new NetTcpBinding () { TransactionFlow = false };
		tcp.Security.Mode = SecurityMode.None;
		binding.Resolver.Custom.Binding = tcp;

		binding.Security.Mode = SecurityMode.None;
		IFooChannel proxy = new DuplexChannelFactory<IFooChannel> (
			new Foo (),
			binding,
			new EndpointAddress ("net.p2p://samplemesh/SampleService")
			).CreateChannel ();
		proxy.Open ();
		proxy.SendMessage ("TEST FOR ECHO");
		Console.WriteLine (proxy.SessionId);
		Console.WriteLine ("type [CR] to quit");
		Console.ReadLine ();
	}
}

public interface IFooChannel : IFoo, IClientChannel
{
}

[ServiceContract (CallbackContract = typeof (IFoo))]
public interface IFoo
{
	[OperationContract (IsOneWay = true)]
	[TransactionFlow (TransactionFlowOption.NotAllowed)]
	void SendMessage (string msg);

}

public interface ICallbackFoo
{
	[OperationContract (IsOneWay = true)]
	[TransactionFlow (TransactionFlowOption.NotAllowed)]
	void CallbackFoo (string reply);
}

[CallbackBehavior (ConcurrencyMode = ConcurrencyMode.Reentrant)]
class Foo : IFoo, ICallbackFoo
{
	public void SendMessage (string msg)
	{
		Console.WriteLine ("SendMessage: " + msg);
	}

	public void CallbackFoo (string msg)
	{
		Console.WriteLine ("CallbackFoo: " + msg);
	}
}
