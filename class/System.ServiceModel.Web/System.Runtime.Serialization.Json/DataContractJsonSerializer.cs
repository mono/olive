//
// DataContractJsonSerializer.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
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
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;

namespace System.Runtime.Serialization.Json
{
	public sealed class DataContractJsonSerializer : XmlObjectSerializer
	{
		DataContractSerializer impl;

		#region lengthy constructor list

		public DataContractJsonSerializer (Type type)
			: this (type, Type.EmptyTypes)
		{
		}

		public DataContractJsonSerializer (Type type, IEnumerable<Type> knownTypes)
			: this (type, "root", Type.EmptyTypes)
		{
		}

		public DataContractJsonSerializer (Type type, string rootName)
			: this (type, rootName, Type.EmptyTypes)
		{
		}

		public DataContractJsonSerializer (Type type, XmlDictionaryString rootName)
			: this (type, rootName, Type.EmptyTypes)
		{
		}

		public DataContractJsonSerializer (Type type, string rootName, IEnumerable<Type> knownTypes)
			: this (type, new XmlDictionary ().Add (rootName), knownTypes)
		{
		}

		[MonoTODO]
		public DataContractJsonSerializer (Type type, XmlDictionaryString rootName, IEnumerable<Type> knownTypes)
		{
			impl = new DataContractSerializer (type, rootName, XmlDictionaryString.Empty, knownTypes);
			root = rootName;
		}

		[MonoTODO]
		public DataContractJsonSerializer (Type type, IEnumerable<Type> knownTypes, int maxItemsInObjectGraph, bool ignoreExtensionDataObject, IDataContractSurrogate dataContractSurrogate, bool alwaysEmitTypeInformation)
		{
			//impl = new DataContractSerializer (type, knownTypes, maxItemsInObjectGraph, ignoreExtensionDataObject, dataContractSurrogate, alwaysEmitTypeInformation);
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public DataContractJsonSerializer (Type type, string rootName, IEnumerable<Type> knownTypes, int maxItemsInObjectGraph, bool ignoreExtensionDataObject, IDataContractSurrogate dataContractSurrogate, bool alwaysEmitTypeInformation)
		{
//			impl = new DataContractSerializer (type, rootName, String.Empty, knownTypes, maxItemsInObjectGraph, ignoreExtensionDataObject, dataContractSurrogate, alwaysEmitTypeInformation);
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public DataContractJsonSerializer (Type type, XmlDictionaryString rootName, IEnumerable<Type> knownTypes, int maxItemsInObjectGraph, bool ignoreExtensionDataObject, IDataContractSurrogate dataContractSurrogate, bool alwaysEmitTypeInformation)
		{
//			impl = new DataContractSerializer (type, rootName, XmlDictionaryString.Empty, knownTypes, maxItemsInObjectGraph, ignoreExtensionDataObject, dataContractSurrogate, alwaysEmitTypeInformation);
			throw new NotImplementedException ();
		}

		#endregion

		Type type;
		XmlDictionaryString root;
		ReadOnlyCollection<Type> known_types;
		int max_items;
		bool ignore_extension;
		IDataContractSurrogate surrogate;
		bool always_emit_type;

		[MonoTODO]
		public IDataContractSurrogate DataContractSurrogate {
//			get { return surrogate; }
			get { return impl.DataContractSurrogate; }
		}

		[MonoTODO]
		public bool IgnoreExtensionDataObject {
//			get { return ignore_extension; }
			get { return impl.IgnoreExtensionDataObject; }
		}

		[MonoTODO]
		public ReadOnlyCollection<Type> KnownTypes {
//			get { return known_types; }
			get { return impl.KnownTypes; }
		}

		[MonoTODO]
		public int MaxItemsInObjectGraph {
//			get { return max_items; }
			get { return impl.MaxItemsInObjectGraph; }
		}

		[MonoTODO]
		public override bool IsStartObject (XmlReader reader)
		{
			return impl.IsStartObject (reader);
		}

		[MonoTODO]
		public override bool IsStartObject (XmlDictionaryReader reader)
		{
			return impl.IsStartObject (reader);
		}

		[MonoTODO]
		public override object ReadObject (Stream stream)
		{
			return ReadObject (JsonReaderWriterFactory.CreateJsonReader (stream, new XmlDictionaryReaderQuotas ()));
		}

		[MonoTODO]
		public override object ReadObject (XmlDictionaryReader reader)
		{
			return impl.ReadObject (reader);
		}

		[MonoTODO]
		public override object ReadObject (XmlReader reader)
		{
			return impl.ReadObject (reader);
		}

		[MonoTODO]
		public override object ReadObject (XmlDictionaryReader reader, bool verifyObjectName)
		{
			return impl.ReadObject (reader, verifyObjectName);
		}

		[MonoTODO]
		public override object ReadObject (XmlReader reader, bool verifyObjectName)
		{
			return impl.ReadObject (reader, verifyObjectName);
		}

		[MonoTODO]
		public override void WriteObject (Stream stream, object graph)
		{
			WriteObject (JsonReaderWriterFactory.CreateJsonWriter (stream), graph);
		}

		[MonoTODO]
		public override void WriteObject (XmlWriter writer, object graph)
		{
			impl.WriteObject (writer as XmlDictionaryWriter ?? XmlDictionaryWriter.CreateDictionaryWriter (writer), graph);
		}

		[MonoTODO]
		public override void WriteObject (XmlDictionaryWriter writer, object graph)
		{
			try {
				impl.WriteObject (writer, graph);
			} catch (Exception ex) {
				throw new SerializationException (String.Format ("There was an error during serialization for object of type {0}", graph != null ? graph.GetType () : null), ex);
			}
		}

		[MonoTODO]
		public override void WriteStartObject (XmlDictionaryWriter writer, object graph)
		{
			impl.WriteStartObject (writer, graph);
		}

		[MonoTODO]
		public override void WriteStartObject (XmlWriter writer, object graph)
		{
			impl.WriteStartObject (writer, graph);
		}

		[MonoTODO]
		public override void WriteObjectContent (XmlDictionaryWriter writer, object graph)
		{
			impl.WriteObjectContent (writer, graph);
		}

		[MonoTODO]
		public override void WriteObjectContent (XmlWriter writer, object graph)
		{
			impl.WriteObjectContent (writer, graph);
		}

		[MonoTODO]
		public override void WriteEndObject (XmlDictionaryWriter writer)
		{
			impl.WriteEndObject (writer);
		}

		[MonoTODO]
		public override void WriteEndObject (XmlWriter writer)
		{
			impl.WriteEndObject (writer);
		}
	}
}
