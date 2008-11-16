using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Workflow.Runtime.Hosting;

namespace System.Workflow.Runtime.Tests.System.Workflow.Runtime
{
	[TestFixture]
	public class PersistenceExceptionTest
	{
		private int DivideBy0()
		{
			int denom = 0;
			return 1 / denom;
		}

		[Test]
		public void PersistenceExceptionCtorTest()
		{
			PersistenceException perex = new PersistenceException();
			Assert.IsNotNull(perex, "C1#1");

			string msg = Guid.NewGuid().ToString();
			perex = new PersistenceException(msg);
			Assert.AreEqual(msg, perex.Message, "C1#2");

			perex = null;
			msg = Guid.NewGuid().ToString();
			try
			{
				DivideBy0();
				Assert.Fail("C1#3");
			}
			catch(Exception ex)
			{
				perex = new PersistenceException(msg, ex);
			}
			Assert.AreEqual(msg, perex.Message, "C1#4");
			Assert.IsTrue(perex.InnerException is DivideByZeroException, "C1#5");
			Assert.IsNull(perex.InnerException.InnerException, "C1#6");
			Assert.IsTrue(perex.GetBaseException() is DivideByZeroException, "C1#7");

			// TODO: deserialization
		}
	}
}
