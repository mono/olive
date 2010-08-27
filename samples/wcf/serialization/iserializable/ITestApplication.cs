using System;
using System.ServiceModel;
using MyApp.Common;

namespace MyApp.Service
{
    [ServiceContract]
    public interface ITestApplication
    {
        [OperationContract]
        ServiceResult<string> TestMethod(string varA, int varB);
    }
}
