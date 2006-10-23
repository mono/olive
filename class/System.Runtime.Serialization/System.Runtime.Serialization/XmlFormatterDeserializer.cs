//
// XmlFormatterDeserializer.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
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
#if NET_2_0
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Schema;

using QName = System.Xml.XmlQualifiedName;

namespace System.Runtime.Serialization
{
	internal class XmlFormatterDeserializer
	{
		public static object Deserialize (XmlReader reader, Type type,
			KnownTypeCollection knownTypes,
			IDataContractSurrogate surrogate, bool fromContent)
		{
			return new XmlFormatterDeserializer (knownTypes, 
				surrogate).Deserialize (type, reader, fromContent);
		}

		KnownTypeCollection types;
		IDataContractSurrogate surrogate;

		public XmlFormatterDeserializer (
			KnownTypeCollection knownTypes,
			IDataContractSurrogate surrogate)
		{
			this.types = knownTypes;
			this.surrogate = surrogate;
		}

		// At the beginning phase, we still have to instantiate a new
		// target object even if fromContent is true.
		public object Deserialize (Type type, XmlReader reader, bool fromContent)
		{
			if (!fromContent)
				reader.MoveToContent ();

			QName name = KnownTypeCollection.GetPredefinedTypeName (type);
			if (name != QName.Empty)
				return DeserializePrimitive (type, reader, name, true);
			else
				return DeserializeCustom (type, reader,
					types.FindUserMap (type));
		}

		object DeserializePrimitive (Type type, XmlReader reader,
			QName name, bool fromContent)
		{
			if (!fromContent) {
				reader.ReadStartElement (name.Name, name.Namespace);
				if (reader.GetAttribute ("nil", XmlSchema.InstanceNamespace) == "true")
					return type.IsValueType ? Activator.CreateInstance (type) : null;
			}
			return KnownTypeCollection.PredefinedTypeStringToObject (
				reader.ReadElementContentAsString (), name.Name, reader);
		}

		object DeserializeCustom (Type type, XmlReader reader,
			SerializationMap map)
		{
			if (map == null)
				throw new SerializationException (String.Format ("Unknown type {0} is used for DataContract. Any derived types of a data contract or a data member should be added to KnownTypes.", type));

			return map.Deserialize (reader, this);
		}
	}
}
#endif
