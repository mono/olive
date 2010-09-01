using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Discovery;

public class Test
{
	public static void Main ()
	{
		RunCodeUnderDiscoveryHost (new Uri ("http://localhost:37564"), new Uri ("http://localhost:4949"), new Uri ("http://localhost:4989"), UseCase1Core);
	}

	static void RunCodeUnderDiscoveryHost (Uri serviceUri, Uri dHostUri, Uri aHostUri, Action<Uri,AnnouncementEndpoint,DiscoveryEndpoint> action)
	{
		var abinding = new CustomBinding (new HttpTransportBindingElement ());
		var aAddress = new EndpointAddress (aHostUri);
		var aEndpoint = new AnnouncementEndpoint (abinding, aAddress);
		var dbinding = new CustomBinding (new HttpTransportBindingElement ());
		var dAddress = new EndpointAddress (dHostUri);
		var dEndpoint = new DiscoveryEndpoint (dbinding, dAddress);

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

