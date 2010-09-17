using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;

#if CONSOLE
public class Test
{
	public static void Main ()
	{
Console.WriteLine (new ProtocolMappingElementCollection ().Count);
var cfg = ConfigurationManager.OpenMachineConfiguration ();
var pm = ServiceModelSectionGroup.GetSectionGroup (cfg).ProtocolMapping;
Console.WriteLine (pm);
foreach (ProtocolMappingElement pme in pm.ProtocolMappingCollection) Console.WriteLine ("{0} {1} {2}", pme.Scheme, pme.Binding, pme.BindingConfiguration);
		var host = new ServiceHost (typeof (TestService), new Uri ("http://localhost:8080/test.svc"));
		host.Open ();
		Console.WriteLine ("Type [CR] to quit...");
		Console.ReadLine ();
		host.Close ();
	}
}
#endif

[ServiceContract]
public interface ITestService
{
	[OperationContract]
	string Echo (string msg);
}

public class TestService : ITestService
{
	public string Echo (string msg)
	{
Console.WriteLine (OperationContext.Current.Host.ChannelDispatchers.Count);
		return msg;
	}
}

