//
// ClientBaseTest.cs
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
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;
using NUnit.Framework;

namespace MonoTests.System.ServiceModel
{
	[TestFixture]
	public class ClientBaseTest
	{
/*
		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void GenericTypeArgumentIsServiceContract ()
		{
			new MyClientBase<ICloneable> (new BasicHttpBinding (), new EndpointAddress ("http://localhost:4126"));
		}
*/

/*
		public class MyClientBase<T> : ClientBase<T>
		{
			public MyClientBase (Binding binding, EndpointAddress address)
				: base (binding, address)
			{
			}
		}

		public class MyClientBase1 : ClientBase<TestService>
		{
			public MyClientBase1 (Binding binding, EndpointAddress address)
				: base (binding, address)
			{
			}
		}

		[Test]
		public void ClassTypeArg ()
		{
			new MyClientBase1 (new BasicHttpBinding (), new EndpointAddress ("urn:dummy"));
		}
*/

		[ServiceContract]
		public interface ITestService
		{
			[OperationContract]
			string Foo (string arg);
		}

		public class TestService : ITestService
		{
			public string Foo (string arg)
			{
				return arg;
			}
		}

		[ServiceContract]
		public interface ITestService2
		{
			[OperationContract]
			void Bar (string arg);
		}

		public class TestService2 : ITestService2
		{
			public void Bar (string arg)
			{
			}
		}

		[Test]
		[Ignore ("hmm, this test shows that MSDN documentation does not match the fact.")]
		public void Foo ()
		{
			Type t = typeof (ClientBase<ITestService>).GetGenericTypeDefinition ().GetGenericArguments () [0];
			Assert.IsTrue (t.IsGenericParameter);
			Assert.AreEqual (GenericParameterAttributes.None, t.GenericParameterAttributes);
		}

		class MyChannelFactory<T> : ChannelFactory<T>
		{
			public MyChannelFactory (Binding b, EndpointAddress e)
				: base (b, e)
			{
			}

			public IChannelFactory GimmeFactory ()
			{
				return CreateFactory ();
			}
		}

		#region UseCase1

		[Test]
		public void UseCase1Test ()
		{
			// almost equivalent to samples/clientbase/samplesvc.cs
			ServiceHost host = new ServiceHost (typeof (UseCase1));
			Binding binding = new BasicHttpBinding ();
			binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
			host.AddServiceEndpoint (typeof (IUseCase1).FullName,
				binding, new Uri ("http://localhost:37564"));
			host.Open ();
			try {
				// almost equivalent to samples/clientbase/samplecli.cs
				UseCase1Proxy proxy = new UseCase1Proxy (
					new BasicHttpBinding (),
					new EndpointAddress ("http://localhost:37564"));
				proxy.Open ();
				Assert.AreEqual ("TEST FOR ECHOTEST FOR ECHO",
					proxy.Echo ("TEST FOR ECHO"));
			} finally {
				host.Close ();
			}
		}

		[ServiceContract]
		public interface IUseCase1
		{
			[OperationContract]
			string Echo (string msg);
		}

		public class UseCase1 : IUseCase1
		{
			public string Echo (string msg)
			{
				return msg + msg;
			}
		}

		public class UseCase1Proxy : ClientBase<IUseCase1>, IUseCase1
		{
			public UseCase1Proxy (Binding binding, EndpointAddress address)
				: base (binding, address)
			{
			}

			public string Echo (string msg)
			{
				return Channel.Echo (msg);
			}
		}

		#endregion

		// For contract that directly receives and sends Message instances.
		#region UseCase2
		[Test]
		public void UseCase2Test ()
		{
			// almost equivalent to samples/clientbase/samplesvc2.cs
			ServiceHost host = new ServiceHost (typeof (UseCase2));
			Binding binding = new BasicHttpBinding ();
			binding.ReceiveTimeout = TimeSpan.FromSeconds (5);
			host.AddServiceEndpoint (typeof (IUseCase2).FullName,
			binding, new Uri ("http://localhost:37564"));
			host.Open ();

			try {
				// almost equivalent to samples/clientbase/samplecli2.cs
				Binding binging = new BasicHttpBinding ();
				binging.SendTimeout = TimeSpan.FromSeconds (5);
				binging.ReceiveTimeout = TimeSpan.FromSeconds (5);
				UseCase2Proxy proxy = new UseCase2Proxy (
					binding,
					new EndpointAddress ("http://localhost:37564/"));
				proxy.Open ();
				Message req = Message.CreateMessage (MessageVersion.Soap11, "http://tempuri.org/IUseCase2/Echo");
				Message res = proxy.Echo (req);
				using (XmlWriter w = XmlWriter.Create (TextWriter.Null)) {
					res.WriteMessage (w);
				}
			} finally {
				host.Close ();
			}
		}

		[ServiceContract]
		public interface IUseCase2
		{
			[OperationContract]
			Message Echo (Message request);
		}

		class UseCase2 : IUseCase2
		{
			public Message Echo (Message request)
			{
				Message msg = Message.CreateMessage (request.Version, request.Headers.Action + "Response");
				msg.Headers.Add (MessageHeader.CreateHeader ("hoge", "urn:hoge", "heh"));
				//msg.Headers.Add (MessageHeader.CreateHeader ("test", "http://schemas.microsoft.com/ws/2005/05/addressing/none", "testing"));
				return msg;
			}
		}

		public class UseCase2Proxy : ClientBase<IUseCase2>, IUseCase2
		{
			public UseCase2Proxy (Binding binding, EndpointAddress address)
				: base (binding, address)
			{
			}

			public Message Echo (Message request)
			{
				return Channel.Echo (request);
			}
		}

		#endregion

		public void UseCase3Test ()
		{
			// almost equivalent to samples/clientbase/samplesvc3.cs
			ServiceHost host = new ServiceHost (typeof (MetadataExchange));
			host.Description.Behaviors.Find<ServiceDebugBehavior> ()
				.IncludeExceptionDetailInFaults = true;
			Binding bs = new BasicHttpBinding ();
			bs.SendTimeout = TimeSpan.FromSeconds (5);
			bs.ReceiveTimeout = TimeSpan.FromSeconds (5);
			// magic name that does not require fully qualified name ...
			host.AddServiceEndpoint ("IMetadataExchange",
			        bs, new Uri ("http://localhost:37564"));
			host.Open ();
			try {
				// almost equivalent to samples/clientbase/samplecli3.cs
				Binding bc = new BasicHttpBinding ();
				bc.SendTimeout = TimeSpan.FromSeconds (5);
				bc.ReceiveTimeout = TimeSpan.FromSeconds (5);
				MetadataExchangeProxy proxy = new MetadataExchangeProxy (
					bc,
					new EndpointAddress ("http://localhost:37564/"));
				proxy.Open ();

				Message req = Message.CreateMessage (MessageVersion.Soap11, "http://schemas.xmlsoap.org/ws/2004/09/transfer/Get");
				Message res = proxy.Get (req);
				using (XmlWriter w = XmlWriter.Create (TextWriter.Null)) {
					res.WriteMessage (w);
				}
			} finally {
				host.Close ();
			}
		}

		class MetadataExchange : IMetadataExchange
		{
			public Message Get (Message request)
			{
				XmlDocument doc = new XmlDocument ();
				doc.AppendChild (doc.CreateElement ("Metadata", "http://schemas.xmlsoap.org/ws/2004/09/mex"));
				return Message.CreateMessage (request.Version,
				"http://schemas.xmlsoap.org/ws/2004/09/transfer/GetResponse",
				new XmlNodeReader (doc));
			}

			public IAsyncResult BeginGet (Message request, AsyncCallback cb, object state)
			{
				throw new NotImplementedException ();
			}

			public Message EndGet (IAsyncResult result)
			{
				throw new NotImplementedException ();
			}
		}
	}
}
