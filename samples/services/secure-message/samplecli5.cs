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
		//sbe.IncludeTimestamp = false;
		//sbe.LocalClientSettings.DetectReplays = false;

		//X509SecurityTokenParameters p = new X509SecurityTokenParameters ();
		//sbe.EndpointSupportingTokenParameters.Endorsing.Add (p);
		sbe.ProtectionTokenParameters = new X509SecurityTokenParameters ();
		sbe.ProtectionTokenParameters.InclusionMode = SecurityTokenInclusionMode.Never;
		sbe.SetKeyDerivation (false);
		sbe.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt;
		HttpTransportBindingElement hbe =
			new HttpTransportBindingElement ();
		CustomBinding binding = new CustomBinding (new XBE (), sbe, hbe);
		X509Certificate2 cert = new X509Certificate2 ("test.pfx", "mono");
		X509Certificate2 cert2 = cert;//new X509Certificate2 ("test2.cer");
		FooProxy proxy = new FooProxy (binding,
			new EndpointAddress (new Uri ("http://localhost:8080"), new X509CertificateEndpointIdentity (cert2)));
		//proxy.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
		proxy.ClientCredentials.ClientCertificate.Certificate = cert;
		proxy.Endpoint.Behaviors.Add (new StdErrInspectionBehavior ());
		proxy.Open ();
		Console.WriteLine (proxy.Echo (Message.CreateMessage (MessageVersion.Default, "http://tempuri.org/IFoo/Echo", "Request Input text.")));
	}

	class XBE : BindingElement
	{
		public override bool CanBuildChannelFactory<T> (BindingContext ctx)
		{
			return ctx.CanBuildInnerChannelFactory<T> ();
		}

		public override bool CanBuildChannelListener<T> (BindingContext ctx)
		{
			return ctx.CanBuildInnerChannelListener<T> ();
		}

		void DumpParts (ScopedMessagePartSpecification smp)
		{
			foreach (string name in smp.Actions) {
				MessagePartSpecification mp;
				smp.TryGetParts (name, out mp);
				Console.WriteLine ("{0}: {1}", name, mp.IsBodyIncluded);
				foreach (XmlQualifiedName qn in mp.HeaderTypes)
					Console.WriteLine (qn);
			}
			Console.WriteLine ("ChannelParts: {0}", smp.ChannelParts.IsBodyIncluded);
			foreach (XmlQualifiedName qn in smp.ChannelParts.HeaderTypes)
				Console.WriteLine (qn);
		}

		public override IChannelFactory<T> BuildChannelFactory<T> (BindingContext ctx)
		{
			ChannelProtectionRequirements cp = ctx.BindingParameters.Find<ChannelProtectionRequirements> ();
			DumpParts (cp.IncomingEncryptionParts);
			DumpParts (cp.IncomingSignatureParts);
			DumpParts (cp.OutgoingEncryptionParts);
			DumpParts (cp.OutgoingSignatureParts);
			return ctx.BuildInnerChannelFactory<T> ();
		}

		public override IChannelListener<T> BuildChannelListener<T> (BindingContext ctx)
		{
			return ctx.BuildInnerChannelListener<T> ();
		}

		public override BindingElement Clone ()
		{
			return this;
		}

		public override T GetProperty<T> (BindingContext ctx)
		{
			return ctx.GetInnerProperty<T> ();
		}
	}
}

//[ServiceContract (ProtectionLevel = ProtectionLevel.None)]// (SessionMode = SessionMode.NotAllowed)]
[ServiceContract]
public interface IFoo
{
	[OperationContract]
	Message Echo (Message msg);
}

public class FooProxy : ClientBase<IFoo>, IFoo
{
	public FooProxy (Binding binding, EndpointAddress address)
		: base (binding, address)
	{
	}

	public Message Echo (Message msg)
	{
		return Channel.Echo (msg);
	}
}

