//
// sts.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.
//

//
// basic usage example:
//	mono sts.exe --certfile:test.pfx --certpass:mono
//

using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;
using System.Xml.Serialization;

namespace Mono.SecurityTokenServices
{
	public class Driver
	{
		static void Usage ()
		{
			Console.WriteLine ("monosts [--port:xxx] [--help] [--no-sc] [--no-nego] --certfile:(certificate-filename) --certpass:(certificate-password)");
		}

		public static void Main (string [] args)
		{
			int port = 0;
			string certfile = null;
			string certpass = null;
			bool no_sc = false, no_nego = false;

			foreach (string arg in args) {
				if (arg == "--help") {
					Usage ();
					return;
				}
				if (arg.StartsWith ("--port:")) {
					int.TryParse (arg.Substring (7), out port);
					continue;
				}
				if (arg == "--no-sc") {
					no_sc = true;
					continue;
				}
				if (arg == "--no-nego") {
					no_nego = true;
					continue;
				}
				if (arg.StartsWith ("--certfile:")) {
					certfile = arg.Substring (11);
					continue;
				}
				if (arg.StartsWith ("--certpass:")) {
					certpass = arg.Substring (11);
					continue;
				}
				Console.WriteLine ("unrecognized option: " + arg);
				return;
			}
			if (certfile == null || certpass == null) {
				Console.WriteLine ("specify certificate information to identify this service.");
				return;
			}

			if (port <= 0)
				port = 8080;
			Uri listeningUri = new Uri ("http://localhost:" + port);

			ServiceHost host = new ServiceHost (
				typeof (WSTrustSecurityTokenService), listeningUri);
			host.Description.Behaviors.Find<ServiceDebugBehavior> ().IncludeExceptionDetailInFaults = true;
			ServiceMetadataBehavior smb = new ServiceMetadataBehavior ();
			smb.HttpGetEnabled = true;
			host.Description.Behaviors.Add (smb);

			WSHttpBinding binding = new WSHttpBinding ();
			binding.Security.Message.ClientCredentialType = MessageCredentialType.None;
			if (no_sc)
				binding.Security.Message.EstablishSecurityContext = false;
			if (no_nego)
				binding.Security.Message.NegotiateServiceCredential = false;
			ServiceCredentials credentials = new ServiceCredentials ();
			credentials.ServiceCertificate.Certificate = new X509Certificate2 (certfile, certpass);
			//credentials.IssuedTokenAuthentication.AllowUntrustedRsaIssuers = true;
			host.Description.Behaviors.Add (credentials);

			host.AddServiceEndpoint (
				typeof (IWSTrustSecurityTokenService),
				binding,
				listeningUri);

			host.Open ();
			Console.WriteLine ("Type [ENTER] to close ...");
			Console.ReadLine ();
			host.Close ();
		}
	}
}

