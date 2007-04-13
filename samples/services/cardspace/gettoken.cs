using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Xml;
using System.Xml.Serialization;

public class Test
{
	// This sample requires managed card.
	// You can get one from e.g. http://itickr.com/index.php/?p=41

	// usage: gettoken.exe issuerURI issuerCertificate
	// example:
	// gettoken.exe https://infocard.pingidentity.com/idpdemo/sts ping.cer
	public static void Main (string [] args)
	{
		XmlDocument doc = new XmlDocument ();
		doc.AppendChild (doc.CreateElement ("root"));
		X509Certificate2 cert = new X509Certificate2 ("test.cer");
		using (XmlWriter w = doc.DocumentElement.CreateNavigator ().AppendChild ()) {
			new EndpointAddress (new Uri ("http://localhost:8080"),
				new X509CertificateEndpointIdentity (cert))
				.WriteTo (AddressingVersion.WSAddressing10, w);
		}
		XmlElement endpoint = doc.DocumentElement.FirstChild as XmlElement;
		using (XmlWriter w = doc.DocumentElement.CreateNavigator ().AppendChild ()) {
			new EndpointAddress (new Uri (args [0]),
				new X509CertificateEndpointIdentity (new X509Certificate2 (args [1])))
				.WriteTo (AddressingVersion.WSAddressing10, w);

		}
		XmlElement issuer = null;//doc.DocumentElement.LastChild as XmlElement;
		string wst = "http://schemas.xmlsoap.org/ws/2005/02/trust";
		string infocard = "http://schemas.xmlsoap.org/ws/2005/05/identity";
		XmlElement p = doc.CreateElement ("Claims", wst);
		p.SetAttribute ("Dialect", ClaimTypes.Name);
		XmlElement ct = doc.CreateElement ("ClaimType", infocard);
		//ct.SetAttribute ("Uri", ClaimTypes.Email);
		ct.SetAttribute ("Uri", ClaimTypes.PPID);
		p.AppendChild (ct);
		GenericXmlSecurityToken token = CardSpaceSelector.GetToken (
			endpoint, new XmlElement [] {p}, issuer, WSSecurityTokenSerializer.DefaultInstance);
		XmlWriterSettings s = new XmlWriterSettings ();
		s.Indent = true;
		using (XmlWriter xw = XmlWriter.Create (Console.Out, s)) {
			WSSecurityTokenSerializer.DefaultInstance.WriteToken (
				xw, token);
			// This cannot be serialized.
			//WSSecurityTokenSerializer.DefaultInstance.WriteToken (
			//	xw, token.ProofToken);
		}
		AsymmetricSecurityKey pk = token.ProofToken.SecurityKeys [0]
			as AsymmetricSecurityKey;
		Console.WriteLine (pk.HasPrivateKey ());
	}
}

