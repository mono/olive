using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;

#if !WITHOUT_DRIVER

public class Tset
{
	public static void Main ()
	{
		ServiceHost host = new ServiceHost (typeof (Foo), new Uri ("http://localhost:8080/auth.svc"));
/*
		ServiceHost host = new ServiceHost (typeof (Foo));
		var sc = new ServiceCredentials ();
		sc.UserNameAuthentication.UserNamePasswordValidationMode =
			UserNamePasswordValidationMode.Custom;
		sc.UserNameAuthentication.CustomUserNamePasswordValidator =
			new TestUserNamePasswordValidator ();
		host.Description.Behaviors.Add (sc);
		var binding = new BasicHttpBinding ();
		binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
		binding.Security.Transport.ClientCredentialType =
			HttpClientCredentialType.Basic;
		binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
		binding.OpenTimeout = TimeSpan.FromSeconds (20);
		host.AddServiceEndpoint ("IFoo",
			binding, new Uri ("http://localhost:8080"));
*/
		host.Open ();
		Console.WriteLine ("Hit [CR] key to close ...");
		Console.ReadLine ();
		host.Close ();
		((IDisposable) host).Dispose ();
	}
}

#endif

[ServiceContract]
public interface IFoo
{
	[OperationContract]
	string Echo (string msg);

	[OperationContract]
	uint Add (uint v1, uint v2);
}

class Foo : IFoo
{
	public string Echo (string msg) 
	{
Console.WriteLine (OperationContext.Current.IncomingMessageHeaders.Action);
Console.WriteLine (OperationContext.Current.Channel.GetType ());
		return msg + msg;
		//throw new NotImplementedException ();
	}

	public uint Add (uint v1, uint v2)
	{
Console.WriteLine ("ADD");
Console.WriteLine (OperationContext.Current.Channel.GetType ());
		return v1 + v2;
	}
}


public class TestUserNamePasswordValidator : UserNamePasswordValidator
{
	public override void Validate (string user, string pass)
	{
		Console.WriteLine ("User {0} / Pass {1}", user, pass);
		if (user != "user" || pass != "right")
			throw new Exception (String.Format ("Authentication failed for {0} and {1}", user, pass));
	}
}
