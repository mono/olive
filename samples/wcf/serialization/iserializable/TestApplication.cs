using System;
using MyApp.Common;
using System.ServiceModel;

namespace MyApp.Service
{
    internal class TestApplication : ITestApplication
    {
        public ServiceResult<string> TestMethod(string varA, int varB)
        {
            ServiceResult<string> res = new ServiceResult<string>();
            res.Error = false;
            res.Value = varA + " - " + varB.ToString();
            Console.Out.WriteLine("TestMethod call: " + res.Value);
            return res;
        }
    }
}
