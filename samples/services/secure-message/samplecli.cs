using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;

public class Tset
{
	public static void Main ()
	{
		try {
			Run ();
		} catch (WebException ex) {
			Console.Error.WriteLine (ex);
			StreamReader sr = new StreamReader (ex.Response.GetResponseStream (), Encoding.UTF8);
			Console.Error.WriteLine (sr.ReadToEnd ());
		}
	}

	static void Run ()
	{
		WSHttpBinding binding = new WSHttpBinding ();
		binding.Security.Message.EstablishSecurityContext = false;
		binding.Security.Message.NegotiateServiceCredential = false;
		binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
		X509Certificate2 cert = new X509Certificate2 ("test.pfx", "mono");
		FooProxy proxy = new FooProxy (binding,
			new EndpointAddress (new Uri ("http://localhost:8080/"), new X509CertificateEndpointIdentity (cert)));
		proxy.Endpoint.Behaviors.Add (new StdErrInspectionBehavior ());
		proxy.ClientCredentials.ClientCertificate.Certificate = cert;
		proxy.Open ();
		Console.WriteLine (proxy.Echo ("TEST FOR ECHO"));
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

