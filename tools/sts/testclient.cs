using System;
using System.IO;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace Sample
{
	public class Test
	{
		public static void Main (string [] args)
		{
			bool no_nego = false, no_sc = false;
			foreach (string arg in args) {
				if (arg == "--no-nego")
					no_nego = true;
				else if (arg == "--no-sc")
					no_sc = true;
				else {
					Console.WriteLine ("Unrecognized option '{0}'", arg);
					return;
				}
			}

			X509Certificate2 cert = new X509Certificate2 ("test.pfx", "mono");
			IssuedSecurityTokenProvider p =
				new IssuedSecurityTokenProvider ();
			p.IssuerAddress = new EndpointAddress (new Uri ("http://localhost:8080"), new X509CertificateEndpointIdentity (cert));
			p.TargetAddress = new EndpointAddress ("http://localhost:8080");
			WSHttpBinding binding = new WSHttpBinding ();

			// the following lines are required to not depend on
			// MessageCredentialType.Windows (which uses SSPI).
			binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
			ClientCredentials cred = new ClientCredentials ();
			cred.ClientCertificate.Certificate = cert;
			cred.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
			p.IssuerChannelBehaviors.Add (cred);

			if (no_sc)
				binding.Security.Message.EstablishSecurityContext = false;
			if (no_nego)
				binding.Security.Message.NegotiateServiceCredential = false;

			p.IssuerBinding = binding;
			p.SecurityTokenSerializer = new WSSecurityTokenSerializer ();
			p.SecurityAlgorithmSuite = SecurityAlgorithmSuite.Default;
			p.KeyEntropyMode = SecurityKeyEntropyMode.ClientEntropy;
			p.Open ();
			SecurityToken token = p.GetToken (TimeSpan.FromSeconds (10));
			p.Close ();

			XmlWriter writer = XmlWriter.Create (Console.Out);
			new ClientCredentialsSecurityTokenManager (cred).CreateSecurityTokenSerializer (MessageSecurityVersion.Default.SecurityTokenVersion).WriteToken (writer, token);
			writer.Close ();
		}
	}
}

