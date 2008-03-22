using System;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;

public class TestProxy : ClientBase<ITestService>, ITestService
{
	public static void Main ()
	{
		NetMsmqBinding b = new NetMsmqBinding ();
		b.ExactlyOnce = false; // non-tx
		b.Security.Transport.MsmqAuthenticationMode =
			MsmqAuthenticationMode.None;
		b.Security.Transport.MsmqProtectionLevel = ProtectionLevel.None;
		new TestProxy (b, new EndpointAddress ("net.msmq://localhost/private/monowcftest")).SayToNowhere ("test message");
	}

	public TestProxy (Binding b, EndpointAddress e)
		: base (b, e)
	{
	}

	public void SayToNowhere (string input)
	{
		Channel.SayToNowhere (input);
	}
}

[ServiceContract]
public interface ITestService
{
	[OperationContract (IsOneWay = true)]
	void SayToNowhere (string input);
}

