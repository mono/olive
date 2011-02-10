using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Discovery;

public class Test
{
	static string hostname;

	public static void Main (string [] args)
	{
		hostname = args.Length > 0 ? args [0] : "localhost";
		RunCodeUnderDiscoveryHost (new Uri ("http://localhost:37564"), UseCase1Core);
	}

	static void RunCodeUnderDiscoveryHost (Uri serviceUri, Action<Uri,DiscoveryEndpoint> action)
	{
		var dBinding = new CustomBinding (new TextMessageEncodingBindingElement (), new TcpTransportBindingElement ());
		var dEndpoint = new DiscoveryEndpoint (DiscoveryVersion.WSDiscovery11, ServiceDiscoveryMode.Adhoc, dBinding, new EndpointAddress ("net.tcp://" + hostname + ":9090/"));
		var ib = new InspectionBehavior ();
		ib.RequestSending += delegate (ref Message msg, IClientChannel channel) {
			var mb = msg.CreateBufferedCopy (0x10000);
			msg = mb.CreateMessage ();
			Console.WriteLine (mb.CreateMessage ());
			return null;
			};
		ib.ReplyReceived += delegate (ref Message msg, object id) {
			var mb = msg.CreateBufferedCopy (0x10000);
			msg = mb.CreateMessage ();
			Console.WriteLine (mb.CreateMessage ());
			}; 
                ib.ReplySending += delegate (ref Message msg, object o) {
                        var mb = msg.CreateBufferedCopy (0x10000);
                        msg = mb.CreateMessage ();
                        Console.Error.WriteLine (mb.CreateMessage ());
                        };
                ib.RequestReceived += delegate (ref Message msg, IClientChannel channel, InstanceContext instanceContext) {
                        var mb = msg.CreateBufferedCopy (0x10000);
                        msg = mb.CreateMessage ();
                        Console.Error.WriteLine (mb.CreateMessage ());
                        return null;
                        };
		dEndpoint.Behaviors.Add (ib);

		action (serviceUri, dEndpoint);
	}

	static void UseCase1Core (Uri serviceUri, DiscoveryEndpoint dEndpoint)
	{
		// actual client, with DiscoveryClientBindingElement
		var be = new DiscoveryClientBindingElement () { DiscoveryEndpointProvider = new ManagedDiscoveryEndpointProvider (dEndpoint) };
		var clientBinding = new CustomBinding (new BasicHttpBinding ());
		clientBinding.Elements.Insert (0, be);
		clientBinding.SendTimeout = TimeSpan.FromSeconds (10);
		clientBinding.ReceiveTimeout = TimeSpan.FromSeconds (10);
		var cf = new ChannelFactory<ITestService> (clientBinding, DiscoveryClientBindingElement.DiscoveryEndpointAddress);
cf.Endpoint.Behaviors.Add (dEndpoint.Behaviors.Find<InspectionBehavior> ());
		var ch = cf.CreateChannel ();
		Console.WriteLine (ch.Echo ("TEST"));
	}

		class ManagedDiscoveryEndpointProvider : DiscoveryEndpointProvider
		{
			public ManagedDiscoveryEndpointProvider (DiscoveryEndpoint endpoint)
			{
				this.endpoint = endpoint;
			}
			
			DiscoveryEndpoint endpoint;
			
			public override DiscoveryEndpoint GetDiscoveryEndpoint ()
			{
				return endpoint;
			}
		}

}

