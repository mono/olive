using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Xml;
using System.Xml.Serialization;

public class Test
{
	public static void Main ()
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
			new EndpointAddress (new Uri ("http://localhost:9090"),
				new X509CertificateEndpointIdentity (cert))
				.WriteTo (AddressingVersion.WSAddressing10, w);

		}
		string wst = "http://schemas.xmlsoap.org/ws/2005/02/trust";
		string infocard = "http://schemas.xmlsoap.org/ws/2005/05/identity";
		XmlElement p = doc.CreateElement ("Claims", wst);
		p.SetAttribute ("Dialect", ClaimTypes.Name);
		p.AppendChild (doc.CreateElement ("Name", infocard));
		XmlElement issuer = doc.DocumentElement.LastChild as XmlElement;
		CardSpaceSelector.GetToken (endpoint, new XmlElement [] {p.FirstChild as XmlElement},
			issuer, WSSecurityTokenSerializer.DefaultInstance);
	}
}

