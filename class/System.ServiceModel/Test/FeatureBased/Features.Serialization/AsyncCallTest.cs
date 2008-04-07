using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Proxy.MonoTests.Features.Client;

namespace MonoTests.Features.Serialization
{
	[TestFixture]
	[Category ("NotWorking")]
	public class AsyncCallTest : TestFixtureBase<AsyncCallTesterContractClient, MonoTests.Features.Contracts.AsyncCallTester>
	{
		bool client_QueryCompleted;
		string s = string.Empty;

		[Test]
		public void TestAsyncCall ()
		{
			client_QueryCompleted = false;

			Client.QueryCompleted += new EventHandler<QueryCompletedEventArgs>(Client_QueryCompleted);
			Client.QueryAsync ("heh");
		}

		private void Client_QueryCompleted (object sender, QueryCompletedEventArgs e)
		{
			client_QueryCompleted = true;
			s = e.Result;
			Assert.AreEqual ("hehheh", s, "#1");
		}
	}
}
