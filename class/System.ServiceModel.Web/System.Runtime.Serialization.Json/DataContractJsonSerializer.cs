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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace System.Runtime.Serialization.Json
{
	public sealed class DataContractJsonSerializer : XmlObjectSerializer
	{
		const string default_root_name = "root";

		#region lengthy constructor list

		public DataContractJsonSerializer (Type type)
			: this (type, Type.EmptyTypes)
		{
		}

		public DataContractJsonSerializer (Type type, IEnumerable<Type> knownTypes)
			: this (type, default_root_name, Type.EmptyTypes)
		{
		}

		public DataContractJsonSerializer (Type type, string rootName)
			: this (type, rootName, Type.EmptyTypes)
		{
		}

		public DataContractJsonSerializer (Type type, XmlDictionaryString rootName)
			: this (type, rootName != null ? rootName.Value : default_root_name, Type.EmptyTypes)
		{
		}

		public DataContractJsonSerializer (Type type, string rootName, IEnumerable<Type> knownTypes)
			: this (type, rootName, knownTypes, int.MaxValue, false, null, true)
		{
		}

		public DataContractJsonSerializer (Type type, XmlDictionaryString rootName, IEnumerable<Type> knownTypes)
			: this (type, rootName != null ? rootName.Value : default_root_name, knownTypes)
		{
		}

		public DataContractJsonSerializer (Type type, IEnumerable<Type> knownTypes, int maxItemsInObjectGraph, bool ignoreExtensionDataObject, IDataContractSurrogate dataContractSurrogate, bool alwaysEmitTypeInformation)
			: this (type, default_root_name, knownTypes, maxItemsInObjectGraph, ignoreExtensionDataObject, dataContractSurrogate, alwaysEmitTypeInformation)
		{
		}

		[MonoTODO]
		public DataContractJsonSerializer (Type type, string rootName, IEnumerable<Type> knownTypes, int maxItemsInObjectGraph, bool ignoreExtensionDataObject, IDataContractSurrogate dataContractSurrogate, bool alwaysEmitTypeInformation)
		{
			if (type == null)
				throw new ArgumentNullException ("type");
			if (rootName == null)
				throw new ArgumentNullException ("rootName");
			if (maxItemsInObjectGraph < 0)
				throw new ArgumentOutOfRangeException ("maxItemsInObjectGraph");

			List<Type> types = new List<Type> ();
			types.Add (type);
			if (knownTypes != null)
				types.AddRange (knownTypes);

			this.type = type;
			known_types = new ReadOnlyCollection<Type> (types);
			root = rootName;
			max_items = maxItemsInObjectGraph;
			ignore_extension = ignoreExtensionDataObject;
			surrogate = dataContractSurrogate;
			always_emit_type = alwaysEmitTypeInformation;
		}

		public DataContractJsonSerializer (Type type, XmlDictionaryString rootName, IEnumerable<Type> knownTypes, int maxItemsInObjectGraph, bool ignoreExtensionDataObject, IDataContractSurrogate dataContractSurrogate, bool alwaysEmitTypeInformation)
			: this (type, rootName != null ? rootName.Value : null, knownTypes, maxItemsInObjectGraph, ignoreExtensionDataObject, dataContractSurrogate, alwaysEmitTypeInformation)
		{
		}

		#endregion

		Type type;
		string root;
		ReadOnlyCollection<Type> known_types;
		int max_items;
		bool ignore_extension;
		IDataContractSurrogate surrogate;
		bool always_emit_type;

		[MonoTODO]
		public IDataContractSurrogate DataContractSurrogate {
			get { return surrogate; }
		}

		[MonoTODO]
		public bool IgnoreExtensionDataObject {
			get { return ignore_extension; }
		}

		[MonoTODO]
		public ReadOnlyCollection<Type> KnownTypes {
			get { return known_types; }
		}

		public int MaxItemsInObjectGraph {
			get { return max_items; }
		}

		public override bool IsStartObject (XmlReader reader)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");
			reader.MoveToContent ();
			return reader.IsStartElement (root, String.Empty);
		}

		public override bool IsStartObject (XmlDictionaryReader reader)
		{
			return IsStartObject ((XmlReader) reader);
		}

		public override object ReadObject (Stream stream)
		{
			return ReadObject (JsonReaderWriterFactory.CreateJsonReader (stream, new XmlDictionaryReaderQuotas ()));
		}

		public override object ReadObject (XmlDictionaryReader reader)
		{
			return ReadObject (reader, true);
		}

		public override object ReadObject (XmlReader reader)
		{
			return ReadObject (reader, true);
		}

		public override object ReadObject (XmlDictionaryReader reader, bool verifyObjectName)
		{
			return ReadObject ((XmlReader) reader, verifyObjectName);
		}

		[MonoTODO]
		public override object ReadObject (XmlReader reader, bool verifyObjectName)
		{
			if (reader == null)
				throw new ArgumentNullException ("reader");
			if (verifyObjectName && !IsStartObject (reader))
				throw new SerializationException (String.Format ("Expected element was '{0}', but the actual input element was '{1}' in namespace '{2}'", root, reader.LocalName, reader.NamespaceURI));

			throw new NotImplementedException ();
		}

		public override void WriteObject (Stream stream, object graph)
		{
			WriteObject (JsonReaderWriterFactory.CreateJsonWriter (stream), graph);
		}

		public override void WriteObject (XmlWriter writer, object graph)
		{
			try {
				WriteStartObject (writer, graph);
				WriteObjectContent (writer, graph);
				WriteEndObject (writer);
			} catch (NotImplementedException) {
				throw;
			} catch (InvalidDataContractException) {
				throw;
			} catch (Exception ex) {
				throw new SerializationException (String.Format ("There was an error during serialization for object of type {0}", graph != null ? graph.GetType () : null), ex);
			}
		}

		public override void WriteObject (XmlDictionaryWriter writer, object graph)
		{
			WriteObject ((XmlWriter) writer, graph);
		}

		public override void WriteStartObject (XmlDictionaryWriter writer, object graph)
		{
			WriteStartObject ((XmlWriter) writer, graph);
		}

		public override void WriteStartObject (XmlWriter writer, object graph)
		{
			if (writer == null)
				throw new ArgumentNullException ("writer");
			writer.WriteStartElement (root);
		}

		public override void WriteObjectContent (XmlDictionaryWriter writer, object graph)
		{
			WriteObjectContent ((XmlWriter) writer, graph);
		}

		[MonoTODO]
		public override void WriteObjectContent (XmlWriter writer, object graph)
		{
			new Outputter (this, writer, type, always_emit_type).WriteObjectContent (graph, true, false);
		}

		public override void WriteEndObject (XmlDictionaryWriter writer)
		{
			WriteEndObject ((XmlWriter) writer);
		}

		public override void WriteEndObject (XmlWriter writer)
		{
			if (writer == null)
				throw new ArgumentNullException ("writer");
			writer.WriteEndElement ();
		}
	}

	class Outputter
	{
		DataContractJsonSerializer serializer;
		XmlWriter writer;
		int serialized_object_count;
		bool always_emit_type;
		Dictionary<Type, TypeMap> typemaps = new Dictionary<Type, TypeMap> ();
		Type root_type;

		public Outputter (DataContractJsonSerializer serializer, XmlWriter writer, Type rootType, bool alwaysEmitTypeInformation)
		{
			this.serializer = serializer;
			this.writer = writer;
			this.root_type = rootType;
			this.always_emit_type = alwaysEmitTypeInformation;
		}

		public XmlWriter Writer {
			get { return writer; }
		}

		public void WriteObjectContent (object graph, bool top, bool outputTypeName)
		{
			if (graph == null) {
				if (top)
					GetTypeMap (root_type); // to make sure to reject invalid contracts
				return;
			}

			if (serialized_object_count ++ == serializer.MaxItemsInObjectGraph)
				throw new SerializationException (String.Format ("The object graph exceeded the maximum object count '{0}' specified in the serializer", serializer.MaxItemsInObjectGraph));

			switch (Type.GetTypeCode (graph.GetType ())) {
			case TypeCode.String:
				writer.WriteString ((string) graph);
				break;
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				if (always_emit_type)
					writer.WriteAttributeString ("type", "number");
				writer.WriteString (((IFormattable) graph).ToString ("R", CultureInfo.InvariantCulture));
				break;
			case TypeCode.Byte:
			case TypeCode.SByte:
			case TypeCode.Int16:
			case TypeCode.Int32:
			case TypeCode.Int64:
			case TypeCode.UInt16:
			case TypeCode.UInt32:
			case TypeCode.UInt64:
				if (always_emit_type)
					writer.WriteAttributeString ("type", "number");
				if (graph.GetType ().IsEnum)
					graph = ((IConvertible) graph).ToType (Enum.GetUnderlyingType (graph.GetType ()), CultureInfo.InvariantCulture);
				writer.WriteString (((IFormattable) graph).ToString ("G", CultureInfo.InvariantCulture));
				break;
			case TypeCode.Boolean:
				if ((bool) graph)
					writer.WriteString ("true");
				else
					writer.WriteString ("false");
				break;
			default:
				if (graph is ICollection) { // array
					writer.WriteAttributeString ("type", "array");
					foreach (object o in (ICollection) graph) {
						writer.WriteStartElement ("item");
						// when it is typed, then no need to output "__type"
						WriteObjectContent (o, false, !(graph is Array && graph.GetType ().GetElementType () != typeof (object)));
						writer.WriteEndElement ();
					}
				} else { // object
					TypeMap tm = GetTypeMap (graph.GetType ());
					if (tm != null) {
						// FIXME: I'm not sure how it is determined whether __type is written or not...
						if (outputTypeName)
							writer.WriteAttributeString ("__type", FormatTypeName (graph.GetType ()));
						if (always_emit_type)
							writer.WriteAttributeString ("type", "object");
						tm.Serialize (this, graph);
					}
					else
						// it does not emit type="object" (as the graph is regarded as a string)
//						writer.WriteString (graph.ToString ());
throw new InvalidDataContractException (String.Format ("Type {0} cannot be serialized by this JSON serializer", graph.GetType ()));
				}
				break;
			}
		}

		string FormatTypeName (Type type)
		{
			return type.Namespace == null ? type.Name : String.Format ("{0}:#{1}", type.Name, type.Namespace);
		}

		TypeMap GetTypeMap (Type type)
		{
			TypeMap map;
			if (!typemaps.TryGetValue (type, out map)) {
				map = TypeMap.CreateTypeMap (type);
				typemaps [type] = map;
			}
			return map;
		}
	}

	class TypeMap
	{
		static bool IsInvalidNCName (string name)
		{
			if (name == null || name.Length == 0)
				return true;
			try {
				XmlConvert.VerifyNCName (name);
			} catch (XmlException) {
				return true;
			}
			return false;
		}

		public static TypeMap CreateTypeMap (Type type)
		{
			object [] atts = type.GetCustomAttributes (typeof (DataContractAttribute), true);
			if (atts.Length == 1)
				return CreateTypeMap (type, (DataContractAttribute) atts [0]);

			atts = type.GetCustomAttributes (typeof (SerializableAttribute), false);
			if (atts.Length == 1)
				return CreateTypeMap (type, null);

			return null;
		}

		static TypeMap CreateTypeMap (Type type, DataContractAttribute dca)
		{
			if (dca != null && dca.Name != null && IsInvalidNCName (dca.Name))
				throw new InvalidDataContractException (String.Format ("DataContractAttribute for type '{0}' has an invalid name", type));

			List<TypeMapMember> members = new List<TypeMapMember> ();

			foreach (FieldInfo fi in type.GetFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
				if (dca != null) {
					object [] atts = fi.GetCustomAttributes (typeof (DataMemberAttribute), true);
					if (atts.Length == 0)
						continue;
					DataMemberAttribute dma = (DataMemberAttribute) atts [0];
					members.Add (new TypeMapField (fi, dma));
				} else {
					if (fi.GetCustomAttributes (typeof (NonSerializedAttribute), false).Length > 0)
						continue;
					members.Add (new TypeMapField (fi, null));
				}
			}

			if (dca != null) {
				foreach (PropertyInfo pi in type.GetProperties (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
					if (pi.GetIndexParameters ().Length > 0)
						continue;
					if (!pi.CanRead || !pi.CanWrite)
						throw new InvalidDataContractException (String.Format ("Property {0} must have both getter and setter", pi));
					object [] atts = pi.GetCustomAttributes (typeof (DataMemberAttribute), true);
					if (atts.Length == 0)
						continue;
					DataMemberAttribute dma = (DataMemberAttribute) atts [0];
					members.Add (new TypeMapProperty (pi, dma));
				}
			}

			members.Sort (delegate (TypeMapMember m1, TypeMapMember m2) { return m1.Order - m2.Order; });
			return new TypeMap (type, dca == null ? null : dca.Name, members.ToArray ());
		}

		Type type;
		string element;
		TypeMapMember [] members;

		public TypeMap (Type type, string element, TypeMapMember [] orderedMembers)
		{
			this.type = type;
			this.element = element;
			this.members = orderedMembers;
		}

		public void Serialize (Outputter outputter, object graph)
		{
			foreach (TypeMapMember member in members) {
				object memberObj = member.GetMemberOf (graph);
				// FIXME: consider EmitDefaultValue
				outputter.Writer.WriteStartElement (member.Name);
				outputter.WriteObjectContent (memberObj, false, false);
				outputter.Writer.WriteEndElement ();
			}
		}
	}

	abstract class TypeMapMember
	{
		MemberInfo mi;
		DataMemberAttribute dma;

		protected TypeMapMember (MemberInfo mi, DataMemberAttribute dma)
		{
			this.mi = mi;
			this.dma = dma;
		}

		public string Name {
			get { return dma == null ? mi.Name : dma.Name ?? mi.Name; }
		}

		// FIXME: Fill 3.5 member in s.r.serialization.
//		public bool EmitDefaultValue {
//			get { return dma != null && dma.EmitDefaultValue; }
//		}

		public bool IsRequired {
			get { return dma != null && dma.IsRequired; }
		}

		public int Order {
			get { return dma != null ? dma.Order : -1; }
		}

		public abstract object GetMemberOf (object owner);
	}

	class TypeMapField : TypeMapMember
	{
		FieldInfo field;

		public TypeMapField (FieldInfo fi, DataMemberAttribute dma)
			: base (fi, dma)
		{
			this.field = fi;
		}

		public override object GetMemberOf (object owner)
		{
			return field.GetValue (owner);
		}
	}

	class TypeMapProperty : TypeMapMember
	{
		PropertyInfo property;

		public TypeMapProperty (PropertyInfo pi, DataMemberAttribute dma)
			: base (pi, dma)
		{
			this.property = pi;
		}

		public override object GetMemberOf (object owner)
		{
			return property.GetValue (owner, null);
		}
	}
}
