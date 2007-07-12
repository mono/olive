using System;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;

public class TestService : ITestService
{
	public static void Main ()
	{
		ServiceHost host = new ServiceHost (typeof (TestService));

		NetMsmqBinding b = new NetMsmqBinding ();
		b.ExactlyOnce = false; // non-tx
		b.Security.Transport.MsmqAuthenticationMode =
			MsmqAuthenticationMode.None;
		b.Security.Transport.MsmqProtectionLevel = ProtectionLevel.None;

		host.AddServiceEndpoint ("ITestService", b, new Uri ("net.msmq://localhost/private/monowcftest"));

		host.Open ();
		Console.WriteLine ("Hit [CR] key to close ...");
		Console.ReadLine ();
		host.Close ();
	}

	public void SayToNowhere (string input)
	{
		Console.WriteLine (input);
	}
}

[ServiceContract]
public interface ITestService
{
	[OperationContract (IsOneWay = true)]
	void SayToNowhere (string input);
}

