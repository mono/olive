using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Proxy.MonoTests.Features.Client;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace MonoTests.Features.Serialization
{
	[TestFixture]
	[Category ("NotWorking")]
	public class UntypedMessageTest : TestFixtureBase<UntypedMessageTesterContractClient, MonoTests.Features.Contracts.UntypedMessageTester>
	{
		[Test]
		public void TestUntypedMessage ()
		{
			String action = "http://localhost/UntypedMessageTester/Message_RequestAction";
			using (new OperationContextScope (Client.InnerChannel)) {
				// Call the Sum service operation.
				string [] strings = { "a", "b", "c" };
				Message request = Message.CreateMessage (OperationContext.Current.OutgoingMessageHeaders.MessageVersion, action, strings);
				Message reply = Client.ConcatStrings (request);
				string r = reply.GetBody<string> ();

				Assert.AreEqual (r, "abc", "#1");
			}


		}
	}
}
