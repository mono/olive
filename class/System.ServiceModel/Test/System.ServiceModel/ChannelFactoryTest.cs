//
// ChannelFactoryTest.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.  http://www.novell.com
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using NUnit.Framework;

namespace MonoTests.System.ServiceModel
{
	[TestFixture]
	public class ChannelFactoryTest
	{
		class NullChannelFactory
			: ChannelFactory
		{
			public NullChannelFactory ()
				: base ()
			{
			}

			protected override TimeSpan DefaultCloseTimeout {
				get { return TimeSpan.FromMinutes (1); }
			}

			protected override TimeSpan DefaultOpenTimeout {
				get { return TimeSpan.FromMinutes (1); }
			}

			protected override ServiceEndpoint CreateDescription ()
			{
				throw new NotSupportedException ();
			}
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNullServiceEndpoint ()
		{
			new ChannelFactory<IFoo> ((ServiceEndpoint) null);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNullBinding ()
		{
			new ChannelFactory<IFoo> ((Binding) null);
		}

		[Test]
		public void DescriptionProperties ()
		{
			Binding b = new BasicHttpBinding ();
			ChannelFactory<IFoo> f = new ChannelFactory<IFoo> (b);

			// FIXME: it's not working now (though this test is silly to me.)
			//Assert.IsNull (f.Description.ChannelType, "ChannelType");

			// FIXME: it's not working now
			//Assert.AreEqual (1, f.Endpoint.Behaviors.Count, "Behaviors.Count");
			//ClientCredentials cred = f.Endpoint.Behaviors [0] as ClientCredentials;
			//Assert.IsNotNull (cred, "Behaviors contains ClientCredentials");

			Assert.IsNotNull (f.Endpoint, "Endpoint");
			Assert.AreEqual (b, f.Endpoint.Binding, "Endpoint.Binding");
			Assert.IsNull (f.Endpoint.Address, "Endpoint.Address");
			// You can examine this silly test on .NET.
			// Funky, ContractDescription.GetContract(
			//   typeof (IRequestChannel)) also fails to raise an 
			// error.
			//Assert.AreEqual ("IRequestChannel", f.Description.Endpoint.Contract.Name, "Endpoint.Contract");
		}

		public class MyChannelFactory<TChannel> 
			: ChannelFactory<TChannel>
		{
			public MyChannelFactory (Type type)
				: base (type)
			{
			}
		}

		[ServiceContract]
		public interface IFoo
		{
			[OperationContract]
			string Echo (string msg);
		}

		public class Foo : IFoo
		{
			public string Echo (string msg)
			{
				return msg;
			}
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void ArgumentTypeNotInterface ()
		{
			new MyChannelFactory<IFoo> (typeof (Foo));
		}
	}
}
