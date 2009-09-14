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
foreach (var pi in typeof (IFooService).GetMethod ("DoWork").GetParameters ())
Console.WriteLine ("{0} {1}", pi.Name, pi.ParameterType.IsByRef);
		var ch = new ChannelFactory<IFooClient> (
			new BasicHttpBinding (),
			new EndpointAddress ("http://localhost:8080")
			).CreateChannel ();
		var s = "bar";
		Console.WriteLine (ch.DoWork ("foo", ref s));
		Console.WriteLine (s);
		Console.WriteLine (ch.DoWork2 (ref s, "bar"));
		Console.WriteLine (s);
	}
}

public interface IFooClient : IFooService, IClientChannel {}

[ServiceContract]
public interface IFooService
{
	[OperationContract]
	string DoWork (string s1, ref string s2);

	[OperationContract]
	string DoWork2 (ref string s1, string s2);
}

