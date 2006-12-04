using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

public class Test
{
	public static void Main ()
	{
		SymmetricSecurityBindingElement sbe =
			new SymmetricSecurityBindingElement ();
		//sbe.IncludeTimestamp = false;
		//sbe.LocalServiceSettings.DetectReplays = false;

		sbe.ProtectionTokenParameters = new X509SecurityTokenParameters ();
		// This "Never" is somehow mandatory (though I wonder why ...)
		sbe.ProtectionTokenParameters.InclusionMode = SecurityTokenInclusionMode.Never;

		sbe.SetKeyDerivation (false);
		sbe.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt;
		ServiceHost host = new ServiceHost (typeof (Foo));
		HttpTransportBindingElement hbe =
			new HttpTransportBindingElement ();
		CustomBinding binding = new CustomBinding (sbe, hbe);
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("http://localhost:8080"));
		ServiceCredentials cred = new ServiceCredentials ();
		cred.ServiceCertificate.Certificate =
			new X509Certificate2 ("test.pfx", "mono");
		cred.ClientCertificate.Authentication.CertificateValidationMode =
			X509CertificateValidationMode.None;
		host.Description.Behaviors.Add (cred);
		host.Description.Behaviors.Find<ServiceDebugBehavior> ()
			.IncludeExceptionDetailInFaults = true;
		foreach (ServiceEndpoint se in host.Description.Endpoints)
			se.Behaviors.Add (new StdErrInspectionBehavior ());
		ServiceMetadataBehavior smb = new ServiceMetadataBehavior ();
		smb.HttpGetEnabled = true;
		smb.HttpGetUrl = new Uri ("http://localhost:8080/wsdl");
		host.Description.Behaviors.Add (smb);
		host.Open ();
		Console.WriteLine ("Hit [CR] key to close ...");
		Console.ReadLine ();
		host.Close ();
	}
}

[ServiceContract]// (SessionMode = SessionMode.NotAllowed)]
public interface IFoo
{
	[OperationContract]
	Message Echo (Message msg);
}

[ServiceBehavior (IncludeExceptionDetailInFaults = true)]
class Foo : IFoo
{
	public Message Echo (Message msg) 
	{
		if (msg.Properties.Security != null)
			ShowProperties (msg);
		return Message.CreateMessage (MessageVersion.Default, "http://tempuri.org/IFoo/EchoResponse", "Accepted");
	}

	void ShowProperties (Message msg)
	{
		SecurityMessageProperty p = msg.Properties.Security;
		Console.WriteLine (p.InitiatorToken);
		Console.WriteLine (p.RecipientToken);
		Console.WriteLine (p.ProtectionToken);
		Console.WriteLine (p.TransportToken);
		Console.WriteLine (p.HasIncomingSupportingTokens);
		Console.WriteLine (p.SenderIdPrefix);
		Console.WriteLine (p.ServiceSecurityContext);
		Console.WriteLine (p.ExternalAuthorizationPolicies);
	}
}

