using System;
using System.ServiceModel;
using MyApp.Service;
using MyApp.Common;

namespace MyApp.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            RunClientTest();
        }

        private static void RunClientTest()
        {
            ITestApplication application;
            string address = "http://localhost:4321/TestApplication";
            try
            {
                Random r = new Random();
                ChannelFactory<ITestApplication> channelFactory = new ChannelFactory<ITestApplication>(new BasicHttpBinding(), address);
                application = channelFactory.CreateChannel();
                using (application as IDisposable)
                {
                    Console.Out.WriteLine("Call (" + address + ")...\n");
                    ServiceResult<string> serviceResult = application.TestMethod("Test", r.Next(1000));
                    string result = serviceResult.Value;
                    Console.Out.WriteLine("TestMethod OK: " + result);
                }
                try { channelFactory.Close(); }
                catch { }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
            }
        }
    }
}
