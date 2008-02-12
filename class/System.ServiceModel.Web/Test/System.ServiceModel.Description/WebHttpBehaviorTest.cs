using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using NUnit.Framework;

namespace MonoTests.System.ServiceModel.Description
{
	[TestFixture]
	public class WebHttpBehaviorTest
	{
		[Test]
		public void AddBiningParameters ()
		{
			var se = new ServiceEndpoint (
				ContractDescription.GetContract (typeof (IMyService)),
				new WebHttpBinding (),
				new EndpointAddress ("http://localhost:37564"));
			var b = new WebHttpBehavior ();
			var pl = new BindingParameterCollection ();
			b.AddBindingParameters (se, pl);
			Assert.AreEqual (0, pl.Count, "#1");
		}

		[ServiceContract]
		public interface IMyService
		{
			[OperationContract]
			string Echo (string input);
		}
	}
}
