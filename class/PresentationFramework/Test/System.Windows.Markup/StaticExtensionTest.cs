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
	public class StaticExtensionTest
	{
		[Test]
		public void CtorTest ()
		{
			StaticExtension s = new StaticExtension ();
			Assert.IsNull (s.Member);

			s = new StaticExtension ("hi");
			Assert.AreEqual ("hi", s.Member);
		}

		class ProviderPoker : IServiceProvider
		{
			public ProviderPoker (object provider)
			{
				this.provider = provider;
			}

			public object GetService (Type serviceType)
			{
				return provider;
			}

			object provider;
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void ProvideValueTest_nonIXamlTypeResolver ()
		{
			StaticExtension se = new StaticExtension ("Test.Field");

			ProviderPoker p = new ProviderPoker (new object());

			Assert.IsNull (se.ProvideValue (p));
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void ProvideValueTest_nullService ()
		{
			StaticExtension se = new StaticExtension ("Test.Field");

			ProviderPoker p = new ProviderPoker (null);

			Assert.IsNull (se.ProvideValue (p));
		}

		class StaticFieldTest {
			public static int Field = 5;
		}

		class StaticPropertyTest {
			public static int Property {
				get { return 5; }
			}
		}

		class PrivateStaticFieldTest {
			static int Field = 5;
		}

		class PrivateStaticPropertyTest {
			static int Property {
				get { return 5; }
			}
		}

		enum EnumTest {
			Foo = 1
		}

		class ProviderPoker2 : IServiceProvider
		{
			class TypeResolver : IXamlTypeResolver {
				public TypeResolver (Type type)
				{
					this.type = type;
				}

				public Type Resolve (string typeName)
				{
					if (typeName == "Test")
						return type;
					return null;
				}

				Type type;
			}

			public ProviderPoker2 (Type t)
			{
				this.type = t;
			}

			public object GetService (Type serviceType)
			{
				if (typeof(IXamlTypeResolver).IsAssignableFrom (serviceType))
					return new TypeResolver (type);
				return null;
			}

			Type type;
		}

		[Test]
		[ExpectedException (typeof (NullReferenceException))]
		public void ProvideValueTest_IXamlTypeResolver_MissingType ()
		{
			StaticExtension ne = new StaticExtension ("Tester.Field");

			ProviderPoker2 p = new ProviderPoker2 (typeof (StaticFieldTest));

			ne.ProvideValue (p);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void ProvideValueTest_IXamlTypeResolver_MissingField ()
		{
			StaticExtension ne = new StaticExtension ("Test.Field2");

			ProviderPoker2 p = new ProviderPoker2 (typeof (StaticFieldTest));

			ne.ProvideValue (p);
		}

		[Test]
		public void ProvideValueTest_IXamlTypeResolver_StaticField ()
		{
			StaticExtension ne = new StaticExtension ("Test.Field");

			ProviderPoker2 p = new ProviderPoker2 (typeof (StaticFieldTest));

			Assert.AreEqual (5, ne.ProvideValue (p));
		}

		[Test]
		public void ProvideValueTest_IXamlTypeResolver_StaticProperty ()
		{
			StaticExtension ne = new StaticExtension ("Test.Property");

			ProviderPoker2 p = new ProviderPoker2 (typeof (StaticPropertyTest));

			Assert.AreEqual (5, ne.ProvideValue (p));
		}

		[Test]
		public void ProvideValueTest_IXamlTypeResolver_Enum ()
		{
			StaticExtension ne = new StaticExtension ("Test.Foo");

			ProviderPoker2 p = new ProviderPoker2 (typeof (EnumTest));

			Assert.AreEqual (EnumTest.Foo, ne.ProvideValue (p));
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void ProvideValueTest_IXamlTypeResolver_PrivateStaticField ()
		{
			StaticExtension ne = new StaticExtension ("Test.Field");

			ProviderPoker2 p = new ProviderPoker2 (typeof (PrivateStaticFieldTest));

			Assert.AreEqual (5, ne.ProvideValue (p));
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void ProvideValueTest_IXamlTypeResolver_PrivateStaticProperty ()
		{
			StaticExtension ne = new StaticExtension ("Test.Property");

			ProviderPoker2 p = new ProviderPoker2 (typeof (PrivateStaticPropertyTest));

			Assert.AreEqual (5, ne.ProvideValue (p));
		}
	}
}
