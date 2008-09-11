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
// Copyright (c) 2007 Novell, Inc. (http://www.novell.com)
//

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Converters;
using System.Windows.Markup;
using NUnit.Framework;

namespace MonoTests.System.Windows.Markup {

	[TestFixture]
	public class NullExtensionTest
	{
		[Test]
		public void ProvideValueTest_nullProvider ()
		{
			NullExtension ne = new NullExtension ();

			Assert.IsNull (ne.ProvideValue (null));
		}

		class ProviderPoker : IServiceProvider
		{
			public ProviderPoker (object provider)
			{
				this.provider = provider;
			}

			public object GetService (Type serviceType)
			{
				Console.WriteLine ("looking up service for type {0}", serviceType);
				return provider;
			}

			object provider;
		}

		[Test]
		public void ProvideValueTest_nonIXamlTypeResolver ()
		{
			NullExtension ne = new NullExtension ();

			ProviderPoker p = new ProviderPoker (new object());

			Assert.IsNull (ne.ProvideValue (p));
		}

		[Test]
		public void ProvideValueTest_nullService ()
		{
			NullExtension ne = new NullExtension ();

			ProviderPoker p = new ProviderPoker (null);

			Assert.IsNull (ne.ProvideValue (p));
		}
	}
}
