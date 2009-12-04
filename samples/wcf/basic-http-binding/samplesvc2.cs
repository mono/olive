using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;

public class Tset
{
	public class MyHost: ServiceHost
	{
		public MyHost (Type type) : base (type)
		{
			OpenTimeout = TimeSpan.FromSeconds (10);
		}
	}
	public static void Main ()
	{
		ServiceHost host = new MyHost (typeof (Foo));
		var sc = new ServiceCredentials ();
		sc.UserNameAuthentication.UserNamePasswordValidationMode =
			UserNamePasswordValidationMode.Custom;
		sc.UserNameAuthentication.CustomUserNamePasswordValidator =
			UserNamePasswordValidator.None;
		host.Description.Behaviors.Add (sc);
		var binding = new BasicHttpBinding ();
		binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
		binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		host.AddServiceEndpoint ("IFoo", binding, new Uri ("http://localhost:8080"));
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
		return msg + msg;
		//throw new NotImplementedException ();
	}
}

