using System;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

public class Tset
{
	public static void Main ()
	{
		WSHttpBinding binding = new WSHttpBinding ();
binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
		binding.Security.Message.EstablishSecurityContext = false;
		binding.Security.Message.NegotiateServiceCredential = false;
		binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
		X509Certificate2 cert = new X509Certificate2 ("test.pfx", "mono");
		FooProxy proxy = new FooProxy (binding,
			new EndpointAddress (new Uri ("http://localhost:8080/"), new X509CertificateEndpointIdentity (cert)));
		//proxy.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
		//proxy.ClientCredentials.ClientCertificate.Certificate = cert;
		proxy.ClientCredentials.UserName.UserName = "mono";
		proxy.Endpoint.Behaviors.Add (new StdErrInspectionBehavior ());
		proxy.Open ();
		try {
			Console.WriteLine (proxy.Echo ("TEST FOR ECHO"));
		} catch (MessageSecurityException ex) {
			FaultException inner = ex.InnerException as FaultException;
			if (inner == null)
				throw;
			Console.WriteLine (inner.Reason);
			Console.WriteLine (ex);
		}
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

