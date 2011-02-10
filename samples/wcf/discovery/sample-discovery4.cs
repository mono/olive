using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;

public class Test
{
	static string hostname;
	public static void Main (string [] args)
	{
		hostname = args.Length > 0 ? args [0] : "localhost";
		RunCodeUnderDiscoveryHost (new Uri ("http://localhost:37564"), new Uri ("http://localhost:4989"));
	}

	static void RunCodeUnderDiscoveryHost (Uri serviceUri, Uri aHostUri)
	{
		// announcement service
		var abinding = new CustomBinding (new HttpTransportBindingElement ());
		var aAddress = new EndpointAddress (aHostUri);
		var aEndpoint = new AnnouncementEndpoint (abinding, aAddress);
		
		// discovery service
		var dBinding = new CustomBinding (new TextMessageEncodingBindingElement (), new TcpTransportBindingElement ());
		var dEndpoint = new DiscoveryEndpoint (DiscoveryVersion.WSDiscovery11, ServiceDiscoveryMode.Adhoc, dBinding, new EndpointAddress ("net.tcp://" + hostname + ":9090/"));
		// Without this, .NET rejects the host as if it had no service.
		dEndpoint.IsSystemEndpoint = false;
		var ib = new InspectionBehavior ();
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
		ib.ReplyReceived += delegate (ref Message msg, object o) {
			var mb = msg.CreateBufferedCopy (0x10000);
			msg = mb.CreateMessage ();
			Console.Error.WriteLine (mb.CreateMessage ());
			};
		ib.RequestSending += delegate (ref Message msg, IClientChannel channel) {
			var mb = msg.CreateBufferedCopy (0x10000);
			msg = mb.CreateMessage ();
			Console.Error.WriteLine (mb.CreateMessage ());
			return null;
			};

		dEndpoint.Behaviors.Add (ib);
		aEndpoint.Behaviors.Add (ib);

		// it internally hosts an AnnouncementService
		using (var inst = new AnnouncementBoundDiscoveryService (aEndpoint)) {
			var host = new ServiceHost (inst);
			host.AddServiceEndpoint (dEndpoint);
			host.Description.Behaviors.Find<ServiceDebugBehavior> ()
				.IncludeExceptionDetailInFaults = true;
			host.Open ();
			Console.WriteLine ("Type [CR] to quit...");
			Console.ReadLine ();
			host.Close ();
		}
	}
}


