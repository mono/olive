//
// ChannelFactory_1Test.cs
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
using System.Xml;
using NUnit.Framework;
using MonoTests.System.ServiceModel.Channels;

namespace MonoTests.System.ServiceModel
{
	[TestFixture]
	public class ChannelFactory_1Test
	{
		class MyChannelFactory<T> : ChannelFactory<T>
		{
			public MyChannelFactory (Binding b, EndpointAddress a)
				: base (b, a)
			{
			}

			public void OpenAnyways ()
			{
				EnsureOpened ();
			}
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void CreateChannelForClass ()
		{
			//ChannelFactory<TestService> f =
				new ChannelFactory<TestService> (
					new BasicHttpBinding (),
					new EndpointAddress ("http://localhost:37564"));
		}

		[Test]
		public void EnsureOpened ()
		{
			MyChannelFactory<ITestService> f =
				new MyChannelFactory<ITestService> (
					new BasicHttpBinding (),
					new EndpointAddress ("http://localhost:37564"));
			Assert.AreEqual (CommunicationState.Created,
				f.State, "#1");
			f.OpenAnyways ();
			Assert.AreEqual (CommunicationState.Opened,
				f.State, "#1");
		}

		[Test]
		// I was deceived by MSDN and currently ChannelFactory<T>
		// only accepts IChannel as T. It will be fixed. -> done.
		public void CreateChannel ()
		{
			ChannelFactory<ITestService> f =
				new ChannelFactory<ITestService> (
					new BasicHttpBinding (),
					new EndpointAddress ("http://localhost:37564"));
			f.CreateChannel ();
		}

		[Test]
		public void CreateChannelAndInvoke ()
		{
			CustomBinding b = new CustomBinding (new HandlerTransportBindingElement (delegate (Message input) {
				BodyWriter bw = new HandlerBodyWriter (delegate (XmlDictionaryWriter writer) {
					writer.WriteStartElement ("BarResponse", "http://tempuri.org/");
					writer.WriteStartElement ("BarResponse", "http://tempuri.org/");
					writer.WriteEndElement ();
					writer.WriteEndElement ();
					});
				return Message.CreateMessage (input.Version, input.Headers.Action + "Response", bw);
				}));
			ChannelFactory<ITestService> f =
				new ChannelFactory<ITestService> (
					b, new EndpointAddress ("urn:dummy"));
			ITestService ts = f.CreateChannel ();
			// no need to open anything.
			ts.Bar ("il offre sa confiance et son amour");
		}

		[Test]
		[Ignore ("puzzled: how could it return a meaningful value??")]
		public void CreateChannelAndInvoke2 ()
		{
			CustomBinding b = new CustomBinding (new HandlerTransportBindingElement (delegate (Message input) {
				BodyWriter bw = new HandlerBodyWriter (delegate (XmlDictionaryWriter writer) {
					writer.WriteStartElement ("FooResponse", "http://tempuri.org/");
					writer.WriteElementString ("FooResponse", "http://tempuri.org/", "cecil");
					writer.WriteEndElement ();
					});
				return Message.CreateMessage (input.Version, input.Headers.Action + "Response", bw);
				}));
			ChannelFactory<ITestService> f =
				new ChannelFactory<ITestService> (
					b, new EndpointAddress ("urn:dummy"));
			ITestService ts = f.CreateChannel ();
			Assert.AreEqual ("", ts.Foo ("il offre sa confiance et son amour"));
		}

		[ServiceContract]
		interface ITestService
		{
			[OperationContract]
			string Foo (string arg);

			[OperationContract]
			void Bar (string arg);
		}

		class TestService
		{
			public string Foo (string arg)
			{
				return arg;
			}
		}
	}
}
