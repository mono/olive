using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

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
		var binding = new NetTcpBinding ();
		binding.Security.Mode = SecurityMode.Message;
		binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
		X509Certificate2 cert = new X509Certificate2 ("test.pfx", "mono");
		FooProxy proxy = new FooProxy (binding,
			new EndpointAddress (new Uri ("net.tcp://localhost:8080/"), new X509CertificateEndpointIdentity (cert)));
		proxy.ClientCredentials.ClientCertificate.Certificate = cert;
		proxy.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
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

