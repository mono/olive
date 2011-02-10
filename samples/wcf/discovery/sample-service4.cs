using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Discovery;

public class Test
{
	public static void Main ()
	{
		RunCodeUnderDiscoveryHost (new Uri ("http://localhost:37564"), new Uri ("http://localhost:4989"), UseCase1Core);
	}

	static void RunCodeUnderDiscoveryHost (Uri serviceUri, Uri aHostUri, Action<Uri,AnnouncementEndpoint,DiscoveryEndpoint> action)
	{
		var abinding = new CustomBinding (new HttpTransportBindingElement ());
		var aAddress = new EndpointAddress (aHostUri);
		var aEndpoint = new AnnouncementEndpoint (abinding, aAddress);
		var dBinding = new CustomBinding (new TextMessageEncodingBindingElement (), new TcpTransportBindingElement ());
		var dEndpoint = new DiscoveryEndpoint (DiscoveryVersion.WSDiscovery11, ServiceDiscoveryMode.Adhoc, dBinding, new EndpointAddress ("net.tcp://localhost:9090/"));

		var ib = new InspectionBehavior ();
		ib.RequestReceived += delegate (ref Message msg, IClientChannel
channel, InstanceContext instanceContext) {
			var mb = msg.CreateBufferedCopy (0x10000);
			msg = mb.CreateMessage ();
			Console.Error.WriteLine (mb.CreateMessage ());
			return null;
			};
		ib.ReplySending += delegate (ref Message msg, object o) {
			var mb = msg.CreateBufferedCopy (0x10000);
			msg = mb.CreateMessage ();
			Console.Error.WriteLine (mb.CreateMessage ());
			};
		dEndpoint.Behaviors.Add (ib);
		aEndpoint.Behaviors.Add (ib);

		action (serviceUri, aEndpoint, dEndpoint);
	}

	static void UseCase1Core (Uri serviceUri, AnnouncementEndpoint aEndpoint, DiscoveryEndpoint dEndpoint)
	{
		var host = new ServiceHost (typeof (TestService));
		var sdb = new ServiceDiscoveryBehavior ();
		sdb.AnnouncementEndpoints.Add (aEndpoint);
		host.Description.Behaviors.Add (sdb);
		host.AddServiceEndpoint (typeof (ITestService), new BasicHttpBinding (), serviceUri);
		host.Open ();
		Console.WriteLine ("Type [CR] to quit ...");
		Console.ReadLine ();
		host.Close ();
	}
}

