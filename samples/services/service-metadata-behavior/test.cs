using System;
using System.ServiceModel;
using System.ServiceModel.Description;

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
		return msg;
	}
}

