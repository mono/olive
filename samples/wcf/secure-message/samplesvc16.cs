using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;

public class Tset
{
	public static void Main ()
	{
		ServiceHost host = new ServiceHost (typeof (Foo));
		var binding = new NetTcpBinding ();
		binding.Security.Mode = SecurityMode.Message;
		binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("net.tcp://localhost:8080"));
		ServiceCredentials cred = new ServiceCredentials ();
		cred.ServiceCertificate.Certificate =
			new X509Certificate2 ("test.pfx", "mono");
		cred.ClientCertificate.Authentication.CertificateValidationMode =
			X509CertificateValidationMode.None;
		host.Description.Behaviors.Add (cred);
		host.Description.Behaviors.Find<ServiceDebugBehavior> ()
			.IncludeExceptionDetailInFaults = true;
		host.Open ();
		Console.WriteLine ("Hit [CR] key to close ...");
		Console.ReadLine ();
		host.Close ();
	}
}

[ServiceContract]
public interface IFoo
{
	[OperationContract]
	string Echo (string msg);
}

class Foo : IFoo
{
	public string Echo (string msg) 
	{
/*
foreach (ClaimSet cs in OperationContext.Current.ServiceSecurityContext.AuthorizationContext.ClaimSets)
  foreach (Claim c in cs)
    Console.WriteLine (c);
*/
		return msg + msg;
		//throw new NotImplementedException ();
	}
}

