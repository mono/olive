using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel.Description;
using System.ServiceModel;

namespace MonoTests.Features.Contracts
{
	[ServiceContract (Namespace = "http://MonoTests.Features.Contracts")]
	interface IMessageContractTesterContract
	{
	}

	public class MessageContractTester : IMessageContractTesterContract
	{
	}
}
