using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using MyApp.Service;

using System.Reflection;

namespace MyApp.Application
{
    class Program
    {
        static void Main(string[] args)
        {
for (Type t = typeof (MyApp.Common.ServiceResult<string>); t != null; t = t.BaseType)
foreach (var fi in t.GetFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) Console.WriteLine (fi);

            Type iserviceType = typeof(ITestApplication);
            Type serviceType = typeof(TestApplication);
            string baseAddress = "http://localhost:4321/";
            ServiceHost host = new ServiceHost(serviceType, new Uri[] { new Uri(baseAddress) });
            var se = host.AddServiceEndpoint(iserviceType, new BasicHttpBinding(), serviceType.Name);
	    var ib = new InspectionBehavior ();
	    ib.RequestReceived += delegate (ref Message msg, IClientChannel channel, InstanceContext instanceContext) {
		var mb = msg.CreateBufferedCopy (0x10000);
		msg = mb.CreateMessage ();
		Console.WriteLine (mb.CreateMessage ());
		return null;
		};
	    ib.ReplySending += delegate (ref Message msg, object state) {
		var mb = msg.CreateBufferedCopy (0x10000);
		msg = mb.CreateMessage ();
		Console.WriteLine (mb.CreateMessage ());
		};
            se.Behaviors.Add (ib);
            host.Open();

            Console.WriteLine("Service published:\n");
            Console.WriteLine(baseAddress + serviceType.Name);
            Console.Out.WriteLine("\n--- Press <return> to quit ---\n");
            Console.ReadLine();
            System.Environment.Exit(0);
        }
    }
}
