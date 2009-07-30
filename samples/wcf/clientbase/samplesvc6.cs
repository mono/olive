using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.PeerResolvers;

public class Tset
{
	static ServiceHost peer_resolver;
	static void SetupPeerResolverService ()
	{
		var cprs = new CustomPeerResolverService ();
		cprs.Open ();
		var host = new ServiceHost (cprs);
		host.Description.Behaviors.Find<ServiceBehaviorAttribute> ()
			.IncludeExceptionDetailInFaults = true;
		var tcp = new NetTcpBinding () { TransactionFlow = false };
		tcp.Security.Mode = SecurityMode.None;
		host.AddServiceEndpoint (typeof (IPeerResolverContract), tcp,
			"net.tcp://localhost:8086");
		host.Open ();
		peer_resolver = host;
	}

	public static void Main ()
	{
		SetupPeerResolverService ();

		ServiceHost host = new ServiceHost (typeof (Foo));
		NetPeerTcpBinding binding = new NetPeerTcpBinding ();
		binding.Resolver.Mode = PeerResolverMode.Custom;
		binding.Resolver.Custom.Address = new EndpointAddress ("net.tcp://localhost:8086");
		var tcp = new NetTcpBinding () { TransactionFlow = false };
		tcp.Security.Mode = SecurityMode.None;
		binding.Resolver.Custom.Binding = tcp;

		binding.Security.Mode = SecurityMode.None;
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		binding.OpenTimeout = TimeSpan.FromSeconds (20);
		host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("net.p2p://localhost:8080"));
		host.Description.Behaviors.Find<ServiceBehaviorAttribute> ()
			.IncludeExceptionDetailInFaults = true;
		host.Open ();
		Console.WriteLine ("Hit [CR] key to close ...");
		Console.ReadLine ();
		host.Close ();

		peer_resolver.Close ();
	}
}

[ServiceContract (CallbackContract = typeof (ICallbackFoo))]
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
Console.WriteLine (OperationContext.Current.IncomingMessageHeaders.Action);
Console.WriteLine (OperationContext.Current.Channel.GetHashCode ());
//foreach (var ch in OperationContext.Current.InstanceContext.IncomingChannels) Console.WriteLine (((IDuplexContextChannel) ch).CallbackInstance == OperationContext.Current.InstanceContext);
Console.WriteLine ("Session: " + OperationContext.Current.SessionId);

try {
		// There seems .NET bugs around here that fails to invoke callback method (TransactionFlowProperty evaluated twice).
		//var proxy = OperationContext.Current.GetCallbackChannel<ICallbackFoo> ();
		//proxy.CallbackFoo (msg);
		//Console.WriteLine ("Foo callback invoked: " + proxy);
		foreach (var ch in OperationContext.Current.InstanceContext.IncomingChannels) {
			ICallbackFoo cb = (ICallbackFoo) ((IDuplexContextChannel) ch).CallbackInstance.GetServiceInstance ();
			cb.CallbackFoo ("foobar");
		}
} catch (Exception ex) {
Console.WriteLine (ex); throw;
}
	}

	public void CallbackFoo (string msg)
	{
Console.WriteLine ("CallbackFoo: " + msg);
Console.WriteLine (OperationContext.Current.IncomingMessageHeaders.Action);
Console.WriteLine (OperationContext.Current.Channel.GetHashCode ());
//foreach (var ch in OperationContext.Current.InstanceContext.IncomingChannels) Console.WriteLine (((IDuplexContextChannel) ch).CallbackInstance);
Console.WriteLine (OperationContext.Current.SessionId);
	}
}

