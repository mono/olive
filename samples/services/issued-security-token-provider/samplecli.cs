using System;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

public class Tset
{
	public static void Main ()
	{
		IssuedSecurityTokenProvider p =
				new IssuedSecurityTokenProvider ();
		p.SecurityTokenSerializer = WSSecurityTokenSerializer.DefaultInstance;
		p.IssuerAddress = new EndpointAddress ("http://localhost:8080");
		WSHttpBinding binding = new WSHttpBinding ();
		//binding.Security.Mode = SecurityMode.Message;
		p.IssuerBinding = binding;
		p.SecurityAlgorithmSuite = SecurityAlgorithmSuite.Default;
		p.TargetAddress = new EndpointAddress ("http://localhost:8080");

		p.Open ();
		p.GetToken (TimeSpan.FromSeconds (10));
		p.Close ();
	}
}

[ServiceContract]
public interface IFoo
{
	[OperationContract]
	string Echo (string msg);
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
}

