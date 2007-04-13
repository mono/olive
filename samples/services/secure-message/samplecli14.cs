using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

public class Tset
{
	public static void Main (string [] args)
	{
		try {
			if (args.Length > 1)
				Run (args [0], args [1]);
			else
				Run (null, null);
		} catch (MessageSecurityException ex) {
			Console.WriteLine ("MessageSecurityException::::::");
			FaultException f = ex.InnerException as FaultException;
			if (f != null) 
				using (XmlWriter w = XmlWriter.Create (Console.Out)) {
					f.CreateMessageFault ().WriteTo (w, EnvelopeVersion.Soap12);
				}
			else
				Console.WriteLine (ex);
		} catch (WebException ex) {
			Console.WriteLine (ex);
			using (StreamReader sr = new StreamReader (ex.Response.GetResponseStream ()))
				Console.WriteLine (sr.ReadToEnd ());
		}
	}

	static void Run (string issuerUri, string issuerCertFile)
	{
		SymmetricSecurityBindingElement sbe =
			new SymmetricSecurityBindingElement ();
		IssuedSecurityTokenParameters ip =
			new IssuedSecurityTokenParameters ();
		ip.ClaimTypeRequirements.Add (new ClaimTypeRequirement (
			ClaimTypes.PPID));
			//ClaimTypes.Email));
		if (issuerUri != null) {
			// if exists, then a managed card is required.
			ip.IssuerAddress = new EndpointAddress (new Uri (issuerUri),
				new X509CertificateEndpointIdentity (new X509Certificate2 (issuerCertFile)));
		}
		X509Certificate2 cert2 = new X509Certificate2 ("test.cer");
		EndpointAddress target = 
			new EndpointAddress (new Uri ("http://localhost:8080"),
				new X509CertificateEndpointIdentity (cert2));
		sbe.ProtectionTokenParameters = ip;
		sbe.LocalClientSettings.IdentityVerifier =
			new MyVerifier ();
		HttpTransportBindingElement hbe =
			new HttpTransportBindingElement ();
		CustomBinding binding = new CustomBinding (sbe, hbe);
		// DefaultCertificate does not work here...
		FooProxy proxy = new FooProxy (binding, target);
		proxy.ClientCredentials.ServiceCertificate.Authentication
			.CertificateValidationMode =
			X509CertificateValidationMode.None;
		proxy.ClientCredentials.ServiceCertificate.Authentication
			.RevocationMode = X509RevocationMode.NoCheck;
		//proxy.ClientCredentials.IssuedToken.LocalIssuerAddress = ip.IssuerAddress;
		//proxy.ClientCredentials.IssuedToken.LocalIssuerBinding = ip.IssuerBinding;
		Console.WriteLine (proxy.Echo ("TEST FOR ECHO"));
	}
}

class MyVerifier : IdentityVerifier
{
	public override bool CheckAccess (EndpointIdentity identity, AuthorizationContext authContext)
	{
Console.WriteLine ("CheckAccess: {0} {1} {2}", identity, authContext.ClaimSets.Count, authContext.Properties.Count);
foreach (ClaimSet cs in authContext.ClaimSets) Console.Write (cs);
Console.WriteLine ();
foreach (object o in authContext.Properties.Values) Console.WriteLine (o);
		return true;
	}

	public override bool TryGetIdentity (EndpointAddress reference, out EndpointIdentity identity)
	{
Console.WriteLine ("TryGetIdentity: " + reference);
		identity = reference.Identity;
		return true;
	}
}

//[ServiceContract (ProtectionLevel = ProtectionLevel.None)]// (SessionMode = SessionMode.NotAllowed)]
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

