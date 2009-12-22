using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

public class Tset
{
	public static void Main ()
	{
		ServiceHost host = new ServiceHost (typeof (Foo));
		//NetTcpBinding binding = new NetTcpBinding ();
		//binding.Security.Mode = SecurityMode.None;
		var binding = new CustomBinding (new BindingElement [] {
			new BinaryMessageEncodingBindingElement (),
			new TcpTransportBindingElement () });
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		binding.OpenTimeout = TimeSpan.FromSeconds (20);
		var se = host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("urn:foo"));
		se.ListenUri = new Uri ("net.tcp://localhost:8088");
		host.Description.Behaviors.Find<ServiceBehaviorAttribute> ()
			.IncludeExceptionDetailInFaults = true;
		host.Open ();
		Console.WriteLine ("Hit [CR] key to close ...");
		Console.ReadLine ();
		host.Close ();
	}
}

[ServiceContract]
public interface IFoo
{
	[OperationContract]
	string Echo (string msg);

	[OperationContract]
	uint Add (uint v1, uint v2);
}

class Foo : IFoo
{
	public string Echo (string msg) 
	{
Console.WriteLine (OperationContext.Current.IncomingMessageHeaders.Action);
Console.WriteLine (OperationContext.Current.Channel.GetHashCode ());
//foreach (var ch in OperationContext.Current.InstanceContext.IncomingChannels) Console.WriteLine (((IDuplexContextChannel) ch).CallbackInstance == OperationContext.Current.InstanceContext);
Console.WriteLine (OperationContext.Current.SessionId);
		return msg + msg;
		//throw new NotImplementedException ();
	}

	public uint Add (uint v1, uint v2)
	{
Console.WriteLine (OperationContext.Current.IncomingMessageHeaders.Action + "/" + v1 + "/" + v2);
Console.WriteLine (OperationContext.Current.Channel.GetHashCode ());
//foreach (var ch in OperationContext.Current.InstanceContext.IncomingChannels) Console.WriteLine (((IDuplexContextChannel) ch).CallbackInstance);
Console.WriteLine (OperationContext.Current.SessionId);
		return v1 + v2;
	}
}

