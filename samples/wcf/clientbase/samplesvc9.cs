using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;

public class Test
{
	public static void Main ()
	{
		var host = new ServiceHost (typeof (FooService));
		host.AddServiceEndpoint (typeof (IFooService), 
			new BasicHttpBinding (),
			new Uri ("http://localhost:8080"));
		host.Open ();
		Console.WriteLine ("Type [CR] to quit...");
		Console.ReadLine ();
		host.Close ();
	}
}

[ServiceContract]
public interface IFooService
{
	[OperationContract]
	string DoWork (string s1, ref string s2);
	[OperationContract]
	string DoWork2 (ref string s1, string s2);
}

public class FooService : IFooService
{
	public string DoWork (string s1, ref string s2)
	{
		Console.WriteLine ("parameters: {0} {1}", s1, s2);
		string r = s2;
		s2 = s1;
		return r;
	}

	public string DoWork2 (ref string s1, string s2)
	{
		Console.WriteLine ("parameters: {0} {1}", s1, s2);
		string r = s2;
		s2 = s1;
		return r;
	}
}

