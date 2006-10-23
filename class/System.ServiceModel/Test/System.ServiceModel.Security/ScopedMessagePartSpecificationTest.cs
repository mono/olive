//
// ScopedMessagePartSpecificationTest.cs
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
using System.Net;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Security.Cryptography.Xml;
using NUnit.Framework;

namespace MonoTests.System.ServiceModel
{
	[TestFixture]
	public class ScopedMessagePartSpecificationTest
	{
		[Test]
		public void DefaultValues ()
		{
			ScopedMessagePartSpecification s =
				new ScopedMessagePartSpecification ();
			Assert.IsNotNull (s.ChannelParts, "#1");
			Assert.AreEqual (0, s.Actions.Count, "#2");
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void AddToReadOnlyCollection ()
		{
			ScopedMessagePartSpecification s =
				new ScopedMessagePartSpecification ();
			s.MakeReadOnly ();
			Assert.AreEqual (true, s.IsReadOnly, "#1");
			s.AddParts (new MessagePartSpecification (), "urn:myaction");
		}

		[Test]
		public void TryGetParts ()
		{
			ScopedMessagePartSpecification s =
				new ScopedMessagePartSpecification ();
			MessagePartSpecification ret;
			Assert.IsFalse (s.TryGetParts ("urn:myaction", out ret));
			Assert.IsFalse (s.TryGetParts ("urn:myaction", true, out ret));
			Assert.IsFalse (s.TryGetParts ("urn:myaction", false, out ret));

			s.AddParts (new MessagePartSpecification (), "urn:myaction");
			Assert.IsTrue (s.TryGetParts ("urn:myaction", out ret));
			Assert.IsTrue (s.TryGetParts ("urn:myaction", true, out ret));
			Assert.IsTrue (s.TryGetParts ("urn:myaction", false, out ret));
		}
	}
}
