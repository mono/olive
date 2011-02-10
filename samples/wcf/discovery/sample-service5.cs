using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Discovery;

public class Test
{
	public static void Main ()
	{
		RunCodeUnderDiscoveryHost (new Uri ("http://localhost:37564"), new Uri ("http://localhost:4949"), UseCase1Core);
	}

	static void RunCodeUnderDiscoveryHost (Uri serviceUri, Uri dHostUri, Action<Uri,AnnouncementEndpoint,DiscoveryEndpoint> action)
	{
		var aEndpoint = new UdpAnnouncementEndpoint (DiscoveryVersion.WSDiscoveryApril2005, new Uri ("soap.udp://239.255.255.250:3802/"));
		var dEndpoint = new UdpDiscoveryEndpoint (DiscoveryVersion.WSDiscoveryApril2005, new Uri ("soap.udp://239.255.255.250:3802/"));

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
		// actual service, announcing to 4989
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

