using System;
using System.Collections.Generic;
using System.Text;
using Proxy.MonoTests.Features.Client;
using NUnit.Framework;
using System.ServiceModel;
using MonoTests.Features.Contracts;

namespace MonoTests.Features.Serialization
{
	[TestFixture]
    public class FaultsTest : TestFixtureBase<FaultsTesterContractClient, FaultsTester, MonoTests.Features.Contracts.IFaultsTesterContract>
	{
		[Test]
		public void TestFault ()
		{
			try {
				Client.FaultMethod ("heh");
			}
			catch (FaultException e) {
            } 
            catch (Exception e) {
                Assert.Fail("Exception is not FaultException");
			}
		}
	}

	[TestFixture]
	[Category ("NotWorking")] // Failure on client side to deserialize the FaultException
    public class FaultsTestIncludeDetails : TestFixtureBase<FaultsTesterContractClientIncludeDetails, MonoTests.Features.Contracts.FaultsTesterIncludeDetails, MonoTests.Features.Contracts.IFaultsTesterContractIncludeDetails>
	{
		[Test]
		public void TestFault ()
		{
			try {
				Client.FaultMethod ("heh");
			}
			catch (Exception e) {
				Assert.AreEqual ("heh", e.Message);
			}
		}
	}
}
