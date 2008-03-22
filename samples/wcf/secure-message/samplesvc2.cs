using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;

	public class GodUserNamePasswordValidator : UserNamePasswordValidator
	{
		public override void Validate (string userName, string password)
		{
			// God allows everyone.
		}
	}

public class Tset
{
	public static void Main ()
	{
		ServiceHost host = new ServiceHost (typeof (Foo));
		WSHttpBinding binding = new WSHttpBinding ();
		binding.Security.Message.EstablishSecurityContext = false;
		binding.Security.Message.NegotiateServiceCredential = false;
		binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("http://localhost:8080"));
		host.Description.Behaviors.Find<ServiceDebugBehavior> ().IncludeExceptionDetailInFaults = true;
		ServiceCredentials cred = new ServiceCredentials ();
		cred.ServiceCertificate.Certificate = new X509Certificate2 ("test.pfx", "mono");
		cred.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
		cred.UserNameAuthentication.CustomUserNamePasswordValidator =
			new GodUserNamePasswordValidator ();
		host.Description.Behaviors.Add (cred);
		foreach (ServiceEndpoint se in host.Description.Endpoints)
			se.Behaviors.Add (new StdErrInspectionBehavior ());
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
Console.WriteLine (msg);
		return msg + msg;
		//throw new NotImplementedException ();
	}
}

