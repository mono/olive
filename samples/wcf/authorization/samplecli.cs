using System;
using System.Linq;
using System.Text;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;

public class Tset
{
	static bool aspx;

	public static void Main (string [] args)
	{
		aspx = args.FirstOrDefault (s => s == "--aspx") != null;
		Run ("user", "right");
		Run ("user", "wrong");
	}

	static void Run (string user, string pass)
	{
		var binding = new BasicHttpBinding ();
		binding.Security.Mode =
			BasicHttpSecurityMode.TransportCredentialOnly;
		binding.Security.Transport.ClientCredentialType =
			HttpClientCredentialType.Basic;
		FooProxy proxy = new FooProxy (binding,
			new EndpointAddress ("http://localhost:8080/" + (aspx ? "auth.svc" : "")));
		proxy.ClientCredentials.UserName.UserName = user;
		proxy.ClientCredentials.UserName.Password = pass;
		proxy.Open ();
		Console.WriteLine (proxy.Echo ("TEST FOR ECHO"));
		Console.WriteLine (proxy.Add (1000, 2000));
		Console.WriteLine ("done");
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

public class FooProxy : ClientBase<IFoo>, IFoo
{
	public FooProxy (Binding binding, EndpointAddress address)
		: base (binding, address)
	{
	}

	public string Echo (string msg)
	{
		return Channel.Echo (msg);
	}

	public uint Add (uint v1, uint v2)
	{
		return Channel.Add (v1, v2);
	}
}

