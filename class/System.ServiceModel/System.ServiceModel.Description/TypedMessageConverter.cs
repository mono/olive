//
// TypedMessageConverter.cs
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace System.ServiceModel.Description
{
	[MonoTODO ("Check how isBuffered works.")]
	internal class TypedMessageConverterBodyWriter : BodyWriter
	{
		static object [] emptyArgs = new object [0];

		object body;
		XmlObjectSerializer formatter;
		TypedMessageMapping map;

		public TypedMessageConverterBodyWriter (
			object body, TypedMessageMapping map, XmlObjectSerializer formatter)
			: base (true)
		{
			this.body = body;
			this.map = map;
			this.formatter = formatter;
		}

		protected override BodyWriter OnCreateBufferedCopy (
			int maxBufferSize)
		{
			return new XmlObjectSerializerBodyWriter (body, formatter);
		}

		protected override void OnWriteBodyContents (
			XmlDictionaryWriter writer)
		{
			formatter.WriteObject (writer, body);
		}
	}

	internal class TypedMessageMapping
	{
		public Type ProxyType;
		public List<PropertyInfo> Properties = new List<PropertyInfo> ();
	}

	internal class TypedMessageConverterDC : TypedMessageConverter
	{
		DataContractFormatAttribute attr;
		XmlObjectSerializer serializer;
		MessageBodyDescription desc;
		TypedMessageMapping map;

		public TypedMessageConverterDC (Type type, string action,
			string defaultNamespace,
			DataContractFormatAttribute formatterAttribute)
			: base (type, action, defaultNamespace)
		{
			this.attr = formatterAttribute;

			// FIXME: handle format style (Document|RPC)

			map = ServiceModelInternalConverter.MessageContractToDataContractMap (type, defaultNamespace);
			Collection<Type> types = new Collection<Type> ();
			foreach (PropertyInfo pi in map.Properties)
				types.Add (pi.PropertyType);
			serializer = new DataContractSerializer (map.ProxyType);
		}

		public override object FromMessage (Message message)
		{
			return serializer.ReadObject (message.GetReaderAtBodyContents ());;
		}

		public override Message ToMessage (object typedMessage)
		{
			return ToMessage (typedMessage, MessageVersion.Default);
		}

		public override Message ToMessage (
			object typedMessage, MessageVersion version)
		{
			object proxy = Activator.CreateInstance (map.ProxyType, typedMessage);
			BodyWriter writer =
				new TypedMessageConverterBodyWriter (proxy, map,  serializer);
			return Message.CreateMessage (version, Action, writer);
		}
	}

	internal class TypedMessageConverterXS : TypedMessageConverter
	{
		XmlSerializerFormatAttribute attr;
		XmlSerializer serializer;

		public TypedMessageConverterXS (Type type, string action,
			string defaultNamespace,
			XmlSerializerFormatAttribute formatterAttribute)
			: base (type, action, defaultNamespace)
		{
			this.attr = formatterAttribute;

			// FIXME: handle format style (Document|RPC, Encoded|Literal)
			serializer = new XmlSerializer (
				ServiceModelInternalConverter.ToXmlSerializableType (type, defaultNamespace),
				null,
				Type.EmptyTypes,
				null,
				defaultNamespace);
		}

		public override object FromMessage (Message message)
		{
			throw new NotImplementedException ();
		}

		public override Message ToMessage (object typedMessage)
		{
			return ToMessage (typedMessage, MessageVersion.Default);
		}

		public override Message ToMessage (
			object typedMessage, MessageVersion version)
		{
			return Message.CreateMessage (version,
				Action,
				new XmlSerializerBodyWriter (serializer, typedMessage));
		}
	}

	public abstract class TypedMessageConverter
	{
		const string TempUri = "http://tempuri.org/";

		Type contract_type;
		string action, default_ns;

		protected TypedMessageConverter ()
		{
		}

		internal TypedMessageConverter (Type type,
			string action, string defaultNS)
		{
			contract_type = type;
			this.action = action;
			default_ns = defaultNS;
		}

		public static TypedMessageConverter Create (
			Type type, string action)
		{
			return Create (type, action, TempUri);
		}

		public static TypedMessageConverter Create (
			Type type, string action,
			string defaultNamespace)
		{
			return new TypedMessageConverterDC (type, action,
				defaultNamespace, null);
		}

		public static TypedMessageConverter Create (
			Type type, string action,
			DataContractFormatAttribute formatterAttribute)
		{
			return Create (type, action, TempUri, formatterAttribute);
		}

		public static TypedMessageConverter Create (
			Type type,
			string action, string defaultNamespace,
			DataContractFormatAttribute formatterAttribute)
		{
			return new TypedMessageConverterDC (type, action,
				defaultNamespace, formatterAttribute);
		}

		public static TypedMessageConverter Create (
			Type type, string action,
			XmlSerializerFormatAttribute formatterAttribute)
		{
			return Create (type, action, TempUri, formatterAttribute);
		}

		public static TypedMessageConverter Create (
			Type type, string action, string defaultNamespace,
			XmlSerializerFormatAttribute formatterAttribute)
		{
			return new TypedMessageConverterXS (type, action,
				defaultNamespace, formatterAttribute);
		}

		internal Type ContractType {
			get { return contract_type; }
		}

		internal string Action {
			get { return action; }
		}

		internal string DefaultNS {
			get { return default_ns; }
		}

		[MonoTODO]
		public abstract object FromMessage (Message message);

		[MonoTODO]
		public abstract Message ToMessage (object typedMessage);

		[MonoTODO]
		public abstract Message ToMessage (
			object typedMessage, MessageVersion version);
	}
}
