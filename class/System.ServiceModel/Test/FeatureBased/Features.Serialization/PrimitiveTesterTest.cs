using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using MonoTests.Features;
using MonoTests.Features.Contracts;
using NUnit.Framework;

namespace MonoTests.Features.Serialization
{
	[TestFixture]
	[Category("NotWorking")]
	public class PrimitiveTesterTest : TestFixtureBase<PrimitiveTesterContractClient, PrimitiveTester>
	{
		[Test]
		public void TestDouble () {
			Assert.IsTrue (Client.AddDouble (1, 1) == 2);
		}

		[Test]
		public void TestByte () {
			Assert.IsTrue (Client.AddByte (1, 1) == 2);
		}

		[Test]
		public void TestSByte () {
			Assert.IsTrue (Client.AddSByte (1, 1) == 2);
		}

		[Test]
		public void TestShort () {
			Assert.IsTrue (Client.AddShort (1, 1) == 2);
		}

		[Test]
		public void TestUShort () {
			Assert.IsTrue (Client.AddUShort (1, 1) == 2);
		}

		[Test]
		public void TestInt () {
			Assert.IsTrue (Client.AddInt (1, 1) == 2);
		}

		[Test]
		public void TestUInt () {
			Assert.IsTrue (Client.AddUInt (1, 1) == 2);
		}

		[Test]
		public void TestLong () {
			Assert.IsTrue (Client.AddLong (1, 1) == 2);
		}

		[Test]
		public void TestULong () {
			Assert.IsTrue (Client.AddULong (1, 1) == 2);
		}

		[Test]
		public void TestFloat () {
			Assert.IsTrue (Client.AddFloat (1, 1) == 2);
		}

		[Test]
		public void TestByRef () {
			double d;
			double res = Client.AddByRef (out d, 1, 1);
			Assert.IsTrue(d == res);
		}
	}
}
