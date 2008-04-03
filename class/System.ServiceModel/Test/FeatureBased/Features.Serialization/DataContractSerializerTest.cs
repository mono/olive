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
	[Category ("NotWorking")]
	public class DataContractSerializerTest : TestFixtureBase<DataContractTesterContractClient,  DataContractTester>
	{		

		[Test]
		public void TestPrimitiveComplexType () {
			monotests.features.client.ComplexPrimitiveClass n1 = GetNewDataInstance ();
			monotests.features.client.ComplexPrimitiveClass n2 = GetNewDataInstance ();
			monotests.features.client.ComplexPrimitiveClass result = Client.Add (n1, n2);
			Assert.IsTrue (result.byteMember == 2);
			Assert.IsTrue (result.sbyteMember == 2);
			Assert.IsTrue (result.shortMember == 2);
			Assert.IsTrue (result.ushortMember == 2);
			Assert.IsTrue (result.intMember == 2);
			Assert.IsTrue (result.uintMember == 2);
			Assert.IsTrue (result.longMember == 2);
			Assert.IsTrue (result.ulongMember == 2);
			Assert.IsTrue (result.doubleMember == 2);
			Assert.IsTrue (result.floatMember == 2);
		}

		[Test]
		public void TestPrimitiveComplexTypeByRef () {
			monotests.features.client.ComplexPrimitiveClass n1 = GetNewDataInstance ();
			monotests.features.client.ComplexPrimitiveClass n2 = GetNewDataInstance ();
			monotests.features.client.ComplexPrimitiveClass result = null;
			result = Client.AddByRef (n1, n2);
			Assert.IsTrue (result.byteMember == 2);
			Assert.IsTrue (result.sbyteMember == 2);
			Assert.IsTrue (result.shortMember == 2);
			Assert.IsTrue (result.ushortMember == 2);
			Assert.IsTrue (result.intMember == 2);
			Assert.IsTrue (result.uintMember == 2);
			Assert.IsTrue (result.longMember == 2);
			Assert.IsTrue (result.ulongMember == 2);
			Assert.IsTrue (result.doubleMember == 2);
			Assert.IsTrue (result.floatMember == 2);
		}

		private monotests.features.client.ComplexPrimitiveClass GetNewDataInstance () {
			monotests.features.client.ComplexPrimitiveClass inst = new monotests.features.client.ComplexPrimitiveClass ();
			inst.byteMember = 1;
			inst.sbyteMember = 1;
			inst.intMember = 1;
			inst.uintMember = 1;
			inst.shortMember = 1;
			inst.ushortMember = 1;
			inst.longMember = 1;
			inst.ulongMember = 1;
			inst.doubleMember = 1;
			inst.floatMember = 1;
			return inst;
		}
	}
}
