//
// AddressHeaderCollectionElementTest.cs
//
// Author:
//	Igor Zelmanovich <igorz@mainsoft.com>
//
// Copyright (C) 2008 Mainsoft, Inc.  http://www.mainsoft.com
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
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Configuration;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;

namespace MonoTests.System.ServiceModel.Configuration
{
	[TestFixture]
	public class CustomBindingElementTest
	{
		CustomBindingCollectionElement OpenConfig () {
			ServiceModelSectionGroup config = (ServiceModelSectionGroup) ConfigurationManager.OpenExeConfiguration ("Test/config/customBinding").GetSectionGroup ("system.serviceModel");
			return config.Bindings.CustomBinding;
		}

		[Test]
		public void CustomBindingElement () {
			CustomBindingElement binding = OpenConfig ().Bindings [0];

			Assert.AreEqual ("CustomBinding_1", binding.Name, "Name");
			Assert.AreEqual (new TimeSpan (0, 2, 0), binding.CloseTimeout, "CloseTimeout");
			Assert.AreEqual (new TimeSpan (0, 2, 0), binding.OpenTimeout, "OpenTimeout");
			Assert.AreEqual (new TimeSpan (0, 20, 0), binding.ReceiveTimeout, "ReceiveTimeout");
			Assert.AreEqual (new TimeSpan (0, 2, 0), binding.SendTimeout, "SendTimeout");

		}

		[Test]
		public void BinaryMessageEncodingElement () {

			CustomBindingElement binding = OpenConfig ().Bindings [0];
			BinaryMessageEncodingElement binaryMessageEncoding = (BinaryMessageEncodingElement) binding [typeof (BinaryMessageEncodingElement)];

			if (binaryMessageEncoding == null)
				Assert.Fail ("BinaryMessageEncodingElement is not exist in collection.");

			Assert.AreEqual (typeof (BinaryMessageEncodingBindingElement), binaryMessageEncoding.BindingElementType, "BindingElementType");
			Assert.AreEqual ("binaryMessageEncoding", binaryMessageEncoding.ConfigurationElementName, "ConfigurationElementName");
			Assert.AreEqual (128, binaryMessageEncoding.MaxReadPoolSize, "MaxReadPoolSize");
			Assert.AreEqual (1024, binaryMessageEncoding.MaxSessionSize, "MaxSessionSize");
			Assert.AreEqual (32, binaryMessageEncoding.MaxWritePoolSize, "MaxWritePoolSize");
			Assert.AreEqual (1024, binaryMessageEncoding.ReaderQuotas.MaxArrayLength, "ReaderQuotas.MaxArrayLength");
			Assert.AreEqual (1024, binaryMessageEncoding.ReaderQuotas.MaxBytesPerRead, "ReaderQuotas.MaxBytesPerRead");
			Assert.AreEqual (1024, binaryMessageEncoding.ReaderQuotas.MaxDepth, "ReaderQuotas.MaxDepth");
			Assert.AreEqual (1024, binaryMessageEncoding.ReaderQuotas.MaxNameTableCharCount, "ReaderQuotas.MaxNameTableCharCount");
			Assert.AreEqual (1024, binaryMessageEncoding.ReaderQuotas.MaxStringContentLength, "ReaderQuotas.MaxStringContentLength");
		}
	}
}
