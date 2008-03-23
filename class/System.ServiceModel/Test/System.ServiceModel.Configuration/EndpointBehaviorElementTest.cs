//
// EndpointBehaviorElementTest.cs
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
using System.ServiceModel.Configuration;
using System.Configuration;
using System.ServiceModel.Description;

namespace MonoTests.System.ServiceModel.Configuration
{
	[TestFixture]
	public class EndpointBehaviorElementTest
	{
		EndpointBehaviorElement OpenConfig () {
			ServiceModelSectionGroup config = (ServiceModelSectionGroup) ConfigurationManager.OpenExeConfiguration ("Test/config/endpointBehaviors").GetSectionGroup ("system.serviceModel");
			return config.Behaviors.EndpointBehaviors [0];
		}

		[Test]
		public void CallbackDebugElement () {
			EndpointBehaviorElement behavior = OpenConfig ();
			CallbackDebugElement callbackDebug = (CallbackDebugElement) behavior [typeof (CallbackDebugElement)];

			if (callbackDebug == null)
				Assert.Fail ("CallbackDebugElement is not exist in collection.");

			Assert.AreEqual (typeof (CallbackDebugBehavior), callbackDebug.BehaviorType, "RoleProviderName");
			Assert.AreEqual ("callbackDebug", callbackDebug.ConfigurationElementName, "RoleProviderName");
			Assert.AreEqual (true, callbackDebug.IncludeExceptionDetailInFaults, "IncludeExceptionDetailInFaults");
		}
	}
}
