using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace WcfTest
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void DoWork(IEnumerable<string> die);
    }

    public class Service1 : IService1
    {
        public void DoWork(IEnumerable<string> die)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Service1));
            host.Open();
            Console.WriteLine("Started");
            Console.ReadKey();
            host.Close();
        }
    }
}

