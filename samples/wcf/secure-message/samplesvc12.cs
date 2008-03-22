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
using System.Xml;

public class Test
{
	class MyEncoder : SecurityStateEncoder
	{
		protected override byte [] DecodeSecurityState (byte [] src)
		{
foreach (byte b in src) Console.Write ("{0:X02} ", b); Console.WriteLine ();
			return src;
		}
		protected override byte [] EncodeSecurityState (byte [] src)
		{
foreach (byte b in src) Console.Write ("{0:X02} ", b); Console.WriteLine ();
			// this show how it is LAMESPEC.
			//Array.Reverse (src);
XmlDictionary dic = new XmlDictionary ();
for (int i = 0; i < 60; i++)
	dic.Add ("n" + i);
XmlDictionaryReaderQuotas quotas =
	new XmlDictionaryReaderQuotas ();
XmlDictionaryReader cr = XmlDictionaryReader.CreateBinaryReader (src, 0, src.Length, dic, quotas);
cr.Read ();
XmlWriter w = XmlWriter.Create (Console.Out);
while (!cr.EOF)
	switch (cr.NodeType) {
	case XmlNodeType.Element:
		int dummy;
		w.WriteStartElement (cr.Prefix, cr.LocalName, cr.NamespaceURI);
		for (int i = 0; i < cr.AttributeCount; i++) {
			cr.MoveToAttribute (i);
			w.WriteStartAttribute (cr.Prefix, cr.LocalName, cr.NamespaceURI);
			bool b64 = cr.LocalName == "n41";
			while (cr.ReadAttributeValue ()) {
				if (b64)
					foreach (byte b in Convert.FromBase64String (cr.Value)) w.WriteString (String.Format ("{0:X02}-", b));
				else
					w.WriteString (cr.Value);
			}
			w.WriteEndAttribute ();
		}
		//w.WriteAttributes (cr, false);
		cr.MoveToElement ();
		if (cr.IsEmptyElement)
			w.WriteEndElement ();
		cr.Read ();
		break;
	case XmlNodeType.EndElement:
		w.WriteEndElement ();
		cr.Read ();
		break;
	default:
		if (cr.TryGetBase64ContentLength (out dummy)) {
			foreach (byte b in cr.ReadContentAsBase64 ()) w.WriteString (String.Format ("{0:X02} ", b));
		}
		else
			w.WriteNode (cr, false);
		break;
	}
w.Close ();

			return src;
		}
	}

	public static void Main ()
	{
		SymmetricSecurityBindingElement sbe =
			new SymmetricSecurityBindingElement ();
		sbe.ProtectionTokenParameters =
			new SspiSecurityTokenParameters ();
		ServiceHost host = new ServiceHost (typeof (Foo));
		HttpTransportBindingElement hbe =
			new HttpTransportBindingElement ();
		CustomBinding binding = new CustomBinding (sbe, hbe);
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("http://localhost:8080"));
		ServiceCredentials cred = new ServiceCredentials ();
		cred.SecureConversationAuthentication.SecurityStateEncoder =
			new MyEncoder ();

		host.Description.Behaviors.Add (cred);
		host.Description.Behaviors.Find<ServiceDebugBehavior> ()
			.IncludeExceptionDetailInFaults = true;
/*
		ServiceMetadataBehavior smb = new ServiceMetadataBehavior ();
		smb.HttpGetEnabled = true;
		smb.HttpGetUrl = new Uri ("http://localhost:8080/wsdl");
		host.Description.Behaviors.Add (smb);
*/
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
XmlWriterSettings xws = new XmlWriterSettings ();
xws.Indent = true;
using (XmlWriter xw = XmlWriter.Create (Console.Out, xws)) {
	xw.WriteStartElement ("root");
	MessageHeaders hs = OperationContext.Current.IncomingMessageHeaders;
	for (int i = 0; i < hs.Count; i++) hs.WriteHeader (i, xw);
}
Console.WriteLine (msg);
		return msg + msg;
		//throw new NotImplementedException ();
	}
}

