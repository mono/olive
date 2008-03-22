using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

public class Tset
{
	public static void Main ()
	{
		try {
			Run ();
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

	static void Run ()
	{
		SymmetricSecurityBindingElement sbe =
			new SymmetricSecurityBindingElement ();
		sbe.ProtectionTokenParameters =
			new SspiSecurityTokenParameters ();
		HttpTransportBindingElement hbe =
			new HttpTransportBindingElement ();
		CustomBinding binding = new CustomBinding (sbe, hbe);
		X509Certificate2 cert = new X509Certificate2 ("test.cer");
		FooProxy proxy = new FooProxy (binding,
			//new EndpointAddress (new Uri ("http://localhost:8080")));
			new EndpointAddress (new Uri ("http://localhost:8080"), new UpnEndpointIdentity ("PC\\atsushi")));
			//new EndpointAddress (new Uri ("http://localhost:8080"), new SpnEndpointIdentity ("PC/atsushi")));
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

