//
// XmlObjectSerializerTest.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//	Ankit Jain <JAnkit@novell.com>
//
// Copyright (C) 2005 Novell, Inc.  http://www.novell.com

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

//
// This test code contains tests for both DataContractSerializer and
// NetDataContractSerializer. The code could be mostly common.
//

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using NUnit.Framework;

namespace MonoTests.System.Runtime.Serialization
{
	[TestFixture]
	public class DataContractSerializerTest
	{
		static readonly XmlWriterSettings settings;

		static DataContractSerializerTest ()
		{
			settings = new XmlWriterSettings ();
			settings.OmitXmlDeclaration = true;
		}

		[DataContract]
		class Sample1
		{
			[DataMember]
			public string Member1;
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorTypeNull ()
		{
			new DataContractSerializer (null);
		}

		[Test]
		public void ConstructorKnownTypesNull ()
		{
			// null knownTypes is allowed.
			new DataContractSerializer (typeof (Sample1), null);
			new DataContractSerializer (typeof (Sample1), "Foo", String.Empty, null);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNameNull ()
		{
			new DataContractSerializer (typeof (Sample1), null, String.Empty);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNamespaceNull ()
		{
			new DataContractSerializer (typeof (Sample1), "foo", null);
		}

		[Test]
		[ExpectedException (typeof (ArgumentOutOfRangeException))]
		public void ConstructorNegativeMaxObjects ()
		{
			new DataContractSerializer (typeof (Sample1), null,
				-1, false, false, null);
		}

		[Test]
		public void ConstructorMisc ()
		{
			new DataContractSerializer (typeof (GlobalSample1));
		}

		[Test]
		public void WriteObjectContent ()
		{
			StringWriter sw = new StringWriter ();
			using (XmlWriter xw = XmlWriter.Create (sw, settings)) {
				DataContractSerializer ser =
					new DataContractSerializer (typeof (string));
				xw.WriteStartElement ("my-element");
				ser.WriteObjectContent (xw, "TEST STRING");
				xw.WriteEndElement ();
			}
			Assert.AreEqual ("<my-element>TEST STRING</my-element>",
				sw.ToString ());
		}

		// int

		[Test]
		public void SerializeInt ()
		{
			DataContractSerializer ser =
				new DataContractSerializer (typeof (int));
			SerializeInt (ser, "<int xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">1</int>");
		}


		[Test]
		[Category ("NotWorking")]
		public void NetSerializeInt ()
		{
			NetDataContractSerializer ser =
				new NetDataContractSerializer ();
			// z:Assembly="0" ???
			SerializeInt (ser, String.Format ("<int z:Type=\"System.Int32\" z:Assembly=\"0\" xmlns:z=\"http://schemas.microsoft.com/2003/10/Serialization/\" xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">1</int>", typeof (int).Assembly.FullName));
		}

		void SerializeInt (XmlObjectSerializer ser, string expected)
		{
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, 1);
			}
			Assert.AreEqual (expected, sw.ToString ());
		}

		// pass typeof(DCEmpty), serialize int

		[Test]
		[Category ("NotWorking")]
		// this test needs XML-canonicalized comparison.
		public void SerializeIntForDCEmpty ()
		{
			DataContractSerializer ser =
				new DataContractSerializer (typeof (DCEmpty));
			// tricky!
			SerializeIntForDCEmpty (ser, "<DCEmpty xmlns:d1p1=\"http://www.w3.org/2001/XMLSchema\" i:type=\"d1p1:int\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization\">1</DCEmpty>");
		}

		void SerializeIntForDCEmpty (XmlObjectSerializer ser, string expected)
		{
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, 1);
			}
			Assert.AreEqual (expected, sw.ToString ());
		}

		// DCEmpty

		[Test]
		public void SerializeEmptyClass ()
		{
			DataContractSerializer ser =
				new DataContractSerializer (typeof (DCEmpty));
			SerializeEmptyClass (ser, "<DCEmpty xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization\" />");
		}

		[Test]
		[Category ("NotWorking")]
		public void NetSerializeEmptyClass ()
		{
			NetDataContractSerializer ser =
				new NetDataContractSerializer ();
			SerializeEmptyClass (ser, String.Format ("<DCEmpty xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" z:Id=\"1\" z:Type=\"MonoTests.System.Runtime.Serialization.DCEmpty\" z:Assembly=\"{0}\" xmlns:z=\"http://schemas.microsoft.com/2003/10/Serialization/\" xmlns=\"http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization\" />", this.GetType ().Assembly.FullName));
		}

		void SerializeEmptyClass (XmlObjectSerializer ser, string expected)
		{
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, new DCEmpty ());
			}
			Assert.AreEqual (expected, sw.ToString ());
		}

		// string (primitive)

		[Test]
		public void SerializePrimitiveString ()
		{
			XmlObjectSerializer ser =
				new DataContractSerializer (typeof (string));
			SerializePrimitiveString (ser, "<string xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">TEST</string>");
		}

		[Test]
		[Category ("NotWorking")]
		public void NetSerializePrimitiveString ()
		{
			XmlObjectSerializer ser = new NetDataContractSerializer ();
			SerializePrimitiveString (ser, "<string z:Type=\"System.String\" z:Assembly=\"0\" xmlns:z=\"http://schemas.microsoft.com/2003/10/Serialization/\" xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">TEST</string>");
		}

		void SerializePrimitiveString (XmlObjectSerializer ser, string expected)
		{
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, "TEST");
			}
			Assert.AreEqual (expected, sw.ToString ());
		}

		// QName (primitive but ...)

		[Test]
		[Ignore ("These tests would not make any sense right now since it's populated prefix is not testable.")]
		public void SerializePrimitiveQName ()
		{
			XmlObjectSerializer ser =
				new DataContractSerializer (typeof (XmlQualifiedName));
			SerializePrimitiveQName (ser, "<z:QName xmlns:d7=\"urn:foo\" xmlns:z=\"http://schemas.microsoft.com/2003/10/Serialization/\">d7:foo</z:QName>");
		}

		[Test]
		[Ignore ("These tests would not make any sense right now since it's populated prefix is not testable.")]
		public void NetSerializePrimitiveQName ()
		{
			XmlObjectSerializer ser = new NetDataContractSerializer ();
			SerializePrimitiveQName (ser, "<z:QName z:Type=\"System.Xml.XmlQualifiedName\" z:Assembly=\"System.Xml, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" xmlns:d7=\"urn:foo\" xmlns:z=\"http://schemas.microsoft.com/2003/10/Serialization/\">d7:foo</z:QName>");
		}

		void SerializePrimitiveQName (XmlObjectSerializer ser, string expected)
		{
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, new XmlQualifiedName ("foo", "urn:foo"));
			}
			Assert.AreEqual (expected, sw.ToString ());
		}

		// DCSimple1

		[Test]
		public void SerializeSimpleClass1 ()
		{
			DataContractSerializer ser =
				new DataContractSerializer (typeof (DCSimple1));
			SerializeSimpleClass1 (ser, "<DCSimple1 xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization\"><Foo>TEST</Foo></DCSimple1>");
		}

		[Test]
		[Category ("NotWorking")]
		public void NetSerializeSimpleClass1 ()
		{
			NetDataContractSerializer ser =
				new NetDataContractSerializer ();
			SerializeSimpleClass1 (ser, String.Format ("<DCSimple1 xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" z:Id=\"1\" z:Type=\"MonoTests.System.Runtime.Serialization.DCSimple1\" z:Assembly=\"{0}\" xmlns:z=\"http://schemas.microsoft.com/2003/10/Serialization/\" xmlns=\"http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization\"><Foo z:Id=\"2\">TEST</Foo></DCSimple1>", this.GetType ().Assembly.FullName));
		}

		void SerializeSimpleClass1 (XmlObjectSerializer ser, string expected)
		{
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, new DCSimple1 ());
			}
			Assert.AreEqual (expected, sw.ToString ());
		}

		// NonDC

		[Test]
		// NonDC is not a DataContract type.
		public void SerializeNonDCOnlyCtor ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (NonDC));
		}

		[Test]
		[ExpectedException (typeof (InvalidDataContractException))]
		// NonDC is not a DataContract type.
		public void SerializeNonDC ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (NonDC));
			using (XmlWriter w = XmlWriter.Create (TextWriter.Null, settings)) {
				ser.WriteObject (w, new NonDC ());
			}
		}

		// DCHasNonDC

		[Test]
		[ExpectedException (typeof (InvalidDataContractException))]
		// DCHasNonDC itself is a DataContract type whose field is
		// marked as DataMember but its type is not DataContract.
		public void SerializeDCHasNonDC ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (DCHasNonDC));
			using (XmlWriter w = XmlWriter.Create (TextWriter.Null, settings)) {
				ser.WriteObject (w, new DCHasNonDC ());
			}
		}

		// DCHasSerializable

		[Test]
		// DCHasSerializable itself is DataContract and has a field
		// whose type is not contract but serializable.
		public void SerializeSimpleSerializable1 ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (DCHasSerializable));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, new DCHasSerializable ());
			}
			Assert.AreEqual ("<DCHasSerializable xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization\"><Ser><Doh>doh!</Doh></Ser></DCHasSerializable>", sw.ToString ());
		}

		[Test]
		public void SerializeDCWithName ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (DCWithName));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, new DCWithName ());
			}
			Assert.AreEqual ("<Foo xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization\"><FooMember>value</FooMember></Foo>", sw.ToString ());
		}

		[Test]
		public void SerializeDCWithEmptyName1 ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (DCWithEmptyName));
			StringWriter sw = new StringWriter ();
			DCWithEmptyName dc = new DCWithEmptyName ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				try {
					ser.WriteObject (w, dc);
				} catch (InvalidDataContractException) {
					return;
				}
			}
			Assert.Fail ("Expected InvalidDataContractException");
		}

		[Test]
		[Category ("NotWorking")]
		public void SerializeDCWithEmptyName2 ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (DCWithName));
			StringWriter sw = new StringWriter ();

			/* DataContractAttribute.Name == "", not valid */
			DCWithEmptyName dc = new DCWithEmptyName ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				try {
					ser.WriteObject (w, dc);
				} catch (InvalidDataContractException) {
					return;
				}
			}
			Assert.Fail ("Expected InvalidDataContractException");
		}

		[Test]
		[Category ("NotWorking")]
		public void SerializeDCWithNullName ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (DCWithNullName));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				try {
					/* DataContractAttribute.Name == "", not valid */
					ser.WriteObject (w, new DCWithNullName ());
				} catch (InvalidDataContractException) {
					return;
				}
			}
			Assert.Fail ("Expected InvalidDataContractException");
		}

		[Test]
		public void SerializeDCWithEmptyNamespace1 ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (DCWithEmptyNamespace));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, new DCWithEmptyNamespace ());
			}
		}

		// Wrapper.DCWrapped

		[Test]
		public void SerializeWrappedClass ()
		{
			DataContractSerializer ser =
				new DataContractSerializer (typeof (Wrapper.DCWrapped));
			SerializeWrappedClass (ser, "<Wrapper.DCWrapped xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization\" />");
		}

		[Test]
		[Category ("NotWorking")]
		public void NetSerializeWrappedClass ()
		{
			NetDataContractSerializer ser =
				new NetDataContractSerializer ();
			SerializeWrappedClass (ser, String.Format ("<Wrapper.DCWrapped xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" z:Id=\"1\" z:Type=\"MonoTests.System.Runtime.Serialization.Wrapper+DCWrapped\" z:Assembly=\"{0}\" xmlns:z=\"http://schemas.microsoft.com/2003/10/Serialization/\" xmlns=\"http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization\" />", this.GetType ().Assembly.FullName));
		}

		void SerializeWrappedClass (XmlObjectSerializer ser, string expected)
		{
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, new Wrapper.DCWrapped ());
			}
			Assert.AreEqual (expected, sw.ToString ());
		}

		// CollectionContainer : Items must have a setter.
		[Test]
		[ExpectedException (typeof (InvalidDataContractException))]
		public void SerializeReadOnlyCollectionMember ()
		{
			DataContractSerializer ser =
				new DataContractSerializer (typeof (CollectionContainer));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, null);
			}
		}

		// DataCollectionContainer : Items must have a setter.
		[Test]
		[ExpectedException (typeof (InvalidDataContractException))]
		public void SerializeReadOnlyDataCollectionMember ()
		{
			DataContractSerializer ser =
				new DataContractSerializer (typeof (DataCollectionContainer));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, null);
			}
		}

		[Test]
		public void SerializeGuid ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (Guid));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, Guid.Empty);
			}
			Assert.AreEqual (
				"<guid xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">00000000-0000-0000-0000-000000000000</guid>",
				sw.ToString ());
		}

		[Test]
		public void SerializeEnum ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (Colors));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, new Colors ());
			}

			Assert.AreEqual (
				@"<Colors xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"">Red</Colors>",
				sw.ToString ());
		}

		[Test]
		[Category ("NotWorking")]
		//Proper xml comparison required
		public void SerializeEnum2 ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (Colors));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, 0);
			}

			Assert.AreEqual (
				@"<Colors xmlns:d1p1=""http://www.w3.org/2001/XMLSchema"" i:type=""d1p1:int"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"">0</Colors>",
				sw.ToString ());
		}

		[Test]
		public void SerializeEnumWithDC ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (ColorsWithDC));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, new ColorsWithDC ());
			}

			Assert.AreEqual (
				@"<_ColorsWithDC xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"">_Red</_ColorsWithDC>",
				sw.ToString ());
		}

		[Test]
		public void SerializeEnumWithNoDC ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (ColorsEnumMemberNoDC));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, new ColorsEnumMemberNoDC ());
			}

			Assert.AreEqual (
				@"<ColorsEnumMemberNoDC xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"">Red</ColorsEnumMemberNoDC>",
				sw.ToString ());
		}

		[Test]
		[Category ("NotWorking")]
		//Proper xml comparison required
		public void SerializeEnumWithDC2 ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (ColorsWithDC));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, 3);
			}

			Assert.AreEqual (
				@"<_ColorsWithDC xmlns:d1p1=""http://www.w3.org/2001/XMLSchema"" i:type=""d1p1:int"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"">3</_ColorsWithDC>",
				sw.ToString ());
		}

		[Test]
		[ExpectedException (typeof (SerializationException))]
		public void SerializeEnumWithDCInvalid ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (ColorsWithDC));
			StringWriter sw = new StringWriter ();
			ColorsWithDC cdc = ColorsWithDC.Blue;
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, cdc);
			}
		}

		[Test]
		public void SerializeDCWithEnum ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (DCWithEnum));
			StringWriter sw = new StringWriter ();
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, new DCWithEnum ());
			}
 
			Assert.AreEqual (
				@"<DCWithEnum xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization""><_colors>Red</_colors></DCWithEnum>",
				sw.ToString ());
		}

		[Test]
		[Category ("NotWorking")]
		public void SerializerDCArray ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (DCWithEnum []));
			StringWriter sw = new StringWriter ();
			DCWithEnum [] arr = new DCWithEnum [2];
			arr [0] = new DCWithEnum (); arr [0].colors = Colors.Red;
			arr [1] = new DCWithEnum (); arr [1].colors = Colors.Green;
			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, arr);
			}

			Assert.AreEqual (
				@"<ArrayOfDCWithEnum xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization""><DCWithEnum><_colors>Red</_colors></DCWithEnum><DCWithEnum><_colors>Green</_colors></DCWithEnum></ArrayOfDCWithEnum>",
				sw.ToString ());
		}

		[Test]
		[Category ("NotWorking")]
		public void SerializerDCArray2 ()
		{
			List<Type> known = new List<Type> ();
			known.Add (typeof (DCWithEnum));
			known.Add (typeof (DCSimple1));
			DataContractSerializer ser = new DataContractSerializer (typeof (object []), known);
			StringWriter sw = new StringWriter ();
			object [] arr = new object [2];
			arr [0] = new DCWithEnum (); ((DCWithEnum)arr [0]).colors = Colors.Red;
			arr [1] = new DCSimple1 (); ((DCSimple1) arr [1]).Foo = "hello";

			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, arr);
			}

			Assert.AreEqual (
				@"<ArrayOfanyType xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.microsoft.com/2003/10/Serialization/Arrays""><anyType xmlns:d2p1=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"" i:type=""d2p1:DCWithEnum""><d2p1:_colors>Red</d2p1:_colors></anyType><anyType xmlns:d2p1=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"" i:type=""d2p1:DCSimple1""><d2p1:Foo>hello</d2p1:Foo></anyType></ArrayOfanyType>",
				sw.ToString ());
		}

		[Test]
		[Category ("NotWorking")]
		public void SerializerDCArray3 ()
		{
			DataContractSerializer ser = new DataContractSerializer (typeof (int []));
			StringWriter sw = new StringWriter ();
			int [] arr = new int [2];
			arr [0] = 1; arr [1] = 2;

			using (XmlWriter w = XmlWriter.Create (sw, settings)) {
				ser.WriteObject (w, arr);
			}

			Assert.AreEqual (
				@"<ArrayOfint xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.microsoft.com/2003/10/Serialization/Arrays""><int>1</int><int>2</int></ArrayOfint>",
				sw.ToString ());
		}

		[Test]
		public void DeserializeEnum ()
		{
			object o = Deserialize (
				@"<Colors xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"">Red</Colors>",
				typeof (Colors));

			Assert.AreEqual (typeof (Colors), o.GetType (), "#de1");
			Colors c = (Colors) o;
			Assert.AreEqual (Colors.Red, c, "#de2");
		}

		[Test]
		public void DeserializeEnum2 ()
		{
			object o = Deserialize (
				@"<Colors xmlns:d1p1=""http://www.w3.org/2001/XMLSchema"" i:type=""d1p1:int"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"">0</Colors>",
				typeof (Colors));

			Assert.AreEqual (typeof (int), o.GetType (), "#de3");
			int i = (int) o;
			Assert.AreEqual (0, i, "#de4");
		}
		
		[Test]
		[ExpectedException (typeof (SerializationException))]
		public void DeserializeEnumInvalid1 ()
		{
			Deserialize (
				@"<Colors xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization""></Colors>",
				typeof (Colors));
		}

		[Test]
		[ExpectedException (typeof (SerializationException))]
		public void DeserializeEnumInvalid2 ()
		{
			Deserialize (
				@"<Colors xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization""/>",
				typeof (Colors));
		}

		[Test]
		[ExpectedException (typeof (SerializationException))]
		public void DeserializeEnumInvalid3 ()
		{
			//"red" instead of "Red"
			Deserialize (
				@"<Colors xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"">red</Colors>",
				typeof (Colors));
		}

		[Test]
		public void DeserializeEnumWithDC ()
		{
			object o = Deserialize (
				@"<_ColorsWithDC xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"">_Red</_ColorsWithDC>",
				typeof (ColorsWithDC));
			
			Assert.AreEqual (typeof (ColorsWithDC), o.GetType (), "#de5");
			ColorsWithDC cdc = (ColorsWithDC) o;
			Assert.AreEqual (ColorsWithDC.Red, o, "#de6");
		}

		[Test]
		[ExpectedException (typeof (SerializationException))]
		public void DeserializeEnumWithDCInvalid ()
		{
			Deserialize (
				@"<_ColorsWithDC xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization"">NonExistant</_ColorsWithDC>",
				typeof (ColorsWithDC));
		}

		[Test]
		public void DeserializeDCWithEnum ()
		{
			object o = Deserialize (
				@"<DCWithEnum xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/MonoTests.System.Runtime.Serialization""><_colors>Red</_colors></DCWithEnum>",
				typeof (DCWithEnum));

			Assert.AreEqual (typeof (DCWithEnum), o.GetType (), "#de7");
			DCWithEnum dc = (DCWithEnum) o;
			Assert.AreEqual (Colors.Red, dc.colors, "#de8");
		}

		private object Deserialize (string xml, Type type)
		{
			DataContractSerializer ser = new DataContractSerializer (type);
			XmlReader xr = XmlReader.Create (new StringReader (xml), new XmlReaderSettings ());
			return ser.ReadObject (xr);
		}

 	}
 
	public enum Colors {
		Red, Green, Blue
	}

	[DataContract (Name = "_ColorsWithDC")]
	public enum ColorsWithDC {

		[EnumMember (Value = "_Red")]
		Red, 
		[EnumMember]
		Green, 
		Blue
	}


	public enum ColorsEnumMemberNoDC {
		[EnumMember (Value = "_Red")]
		Red, 
		[EnumMember]
		Green, 
		Blue
	}

 	[DataContract]
	public class DCWithEnum {
		[DataMember (Name = "_colors")]
		public Colors colors;
	}

	[DataContract]
	public class DCEmpty
	{
		// serializer doesn't touch it.
		public string Foo = "TEST";
	}

	[DataContract]
	public class DCSimple1
	{
		[DataMember]
		public string Foo = "TEST";
	}

	[DataContract]
	public class DCHasNonDC
	{
		[DataMember]
		public NonDC Hoge= new NonDC ();
	}

	public class NonDC
	{
		public string Whee = "whee!";
	}

	[DataContract]
	public class DCHasSerializable
	{
		[DataMember]
		public SimpleSer1 Ser = new SimpleSer1 ();
	}

	[DataContract (Name = "Foo")]
	public class DCWithName
	{
		[DataMember (Name = "FooMember")]
		public string DMWithName = "value";
	}

	[DataContract (Name = "")]
	public class DCWithEmptyName
	{
	}

	[DataContract (Name = null)]
	public class DCWithNullName
	{
	}

	[DataContract (Namespace = "")]
	public class DCWithEmptyNamespace
	{
	}

	[Serializable]
	public class SimpleSer1
	{
		public string Doh = "doh!";
	}

	public class Wrapper
	{
		[DataContract]
		public class DCWrapped
		{
		}
	}

	[DataContract]
	public class CollectionContainer
	{
		Collection<string> items = new Collection<string> ();

		[DataMember]
		public Collection<string> Items {
			get { return items; }
		}
	}

	[CollectionDataContract]
	public class DataCollection<T> : Collection<T>
	{
	}

	[DataContract]
	public class DataCollectionContainer
	{
		DataCollection<string> items = new DataCollection<string> ();

		[DataMember]
		public DataCollection<string> Items {
			get { return items; }
		}
	}
}

[DataContract]
class GlobalSample1
{
}
