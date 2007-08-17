//
// DefaultMessageOperationFormatter.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005-2007 Novell, Inc.  http://www.novell.com
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
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Dispatcher
{
	internal class DefaultResponseBodyWriter : BodyWriter
	{
		MessageBodyDescription desc;
		object obj;
		object [] parameters;
		MessageDescriptionMapping map;

		public DefaultResponseBodyWriter (MessageBodyDescription desc, MessageDescriptionMapping map, object obj, object [] parameters)
			: base (false)
		{
			this.desc = desc;
			this.map = map;
			this.obj = obj;
			this.parameters = parameters;
		}

		protected override void OnWriteBodyContents (XmlDictionaryWriter writer)
		{
			if (desc.WrapperName != null)
				writer.WriteStartElement (desc.WrapperName, desc.WrapperNamespace);
			if (desc.ReturnValue != null)
				WriteMessagePart (writer, desc.ReturnValue, obj);
			foreach (MessagePartDescription part in desc.Parts)
				WriteMessagePart (writer, part, parameters [part.Index]);
			if (desc.WrapperName != null)
				writer.WriteEndElement ();
		}

		void WriteMessagePart (XmlDictionaryWriter writer, MessagePartDescription part, object obj)
		{
			writer.WriteStartElement (part.Name, part.Namespace);
			map.Serializers [part.Type].WriteObjectContent (writer, obj);
			writer.WriteEndElement ();
		}
	}

	internal class DefaultMessageOperationFormatter
		: IDispatchMessageFormatter, IClientMessageFormatter
	{
		public DefaultMessageOperationFormatter (OperationDescription operation)
		{
			this.operation = operation;
		}

		Dictionary<MessageDescription,MessageDescriptionMapping> message_typemaps
			= new Dictionary<MessageDescription,MessageDescriptionMapping> ();
		Dictionary<MessageDescription,XmlObjectSerializer> serializers
			= new Dictionary<MessageDescription,XmlObjectSerializer> ();
		Dictionary<MessageDescription,TypedMessageConverter> converters
			= new Dictionary<MessageDescription,TypedMessageConverter> ();
		OperationDescription operation;

		public Message SerializeRequest (
			MessageVersion version, object [] parameters)
		{
			MessageDescription md = null;
			foreach (MessageDescription mdi in operation.Messages)
				if (mdi.Direction == MessageDirection.Input)
					md = mdi;

			if (md.MessageType != null)
				return GetConverter (md).ToMessage (parameters [0], version);
			return Message.CreateMessage (version, md.Action,
				new DefaultResponseBodyWriter (md.Body, GetMapping (md), null, parameters));
		}

		public Message SerializeReply (
			MessageVersion version, object [] parameters, object result)
		{
			// use_response_converter

			MessageDescription md = null;
			foreach (MessageDescription mdi in operation.Messages)
				if (mdi.Direction == MessageDirection.Output)
					md = mdi;

			if (md.MessageType != null)
				return GetConverter (md).ToMessage (parameters [0], version);
			string replyAction = version.Addressing == AddressingVersion.None ? null : md.Action;
			return Message.CreateMessage (version, replyAction,
				new DefaultResponseBodyWriter (md.Body, GetMapping (md), result, parameters));
		}

		TypedMessageConverter GetConverter (MessageDescription md)
		{
			if (converters.ContainsKey (md))
				return converters [md];
			// FIXME: support DataContractFormatAttribute and XmlSerializerFormatAttribute.
			TypedMessageConverter c = TypedMessageConverter.Create (md.MessageType, md.Action);
			converters [md] = c;
			return c;
		}

		MessageDescriptionMapping GetMapping (MessageDescription md)
		{
			if (message_typemaps.ContainsKey (md))
				return message_typemaps [md];
			MessageDescriptionMapping map = ServiceModelInternalConverter.MessageBodyToDataContractType (md.Body);
			message_typemaps [md] = map;
			return map;
		}

		public void DeserializeRequest (
			Message message, object [] parameters)
		{
			string action = message.Headers.Action;
			MessageDescription md =
				operation.Messages.Find (action);
			if (md == null)
				throw new ActionNotSupportedException (String.Format ("Action '{0}' is not supported by this operation.", action));

			if (md.MessageType != null) {
				parameters [0] = GetConverter (md).FromMessage (message);
				return;
			}

			MessageDescriptionMapping map = GetMapping (md);

			if (!message.IsEmpty) {
				XmlDictionaryReader r = message.GetReaderAtBodyContents ();
				if (md.Body.WrapperName != null)
					r.ReadStartElement (md.Body.WrapperName, md.Body.WrapperNamespace);
				for (r.MoveToContent (); r.NodeType == XmlNodeType.Element; r.MoveToContent ()) {
					MessagePartDescription p = md.Body.Parts [new XmlQualifiedName (r.LocalName, r.NamespaceURI)];
					parameters [p.Index] = map.Serializers [p.Type].ReadObject (r);
				}
				if (md.Body.WrapperName != null)
					r.ReadEndElement ();
			}
		}

		public object DeserializeReply (
			Message message, object [] parameters)
		{
			MessageDescription md = null;
			foreach (MessageDescription mdi in operation.Messages)
				if (mdi.Direction == MessageDirection.Output)
					md = mdi;

			if (md.MessageType != null)
				return GetConverter (md).FromMessage (message);

			MessageDescriptionMapping map = GetMapping (md);

			object ret = null;
			if (!message.IsEmpty) {
				XmlDictionaryReader r = message.GetReaderAtBodyContents ();
				if (md.Body.WrapperName != null)
					r.ReadStartElement (md.Body.WrapperName, md.Body.WrapperNamespace);
				for (r.MoveToContent (); r.NodeType == XmlNodeType.Element; r.MoveToContent ()) {
					MessagePartDescription p = md.Body.ReturnValue;

					object obj = map.Serializers [p.Type].ReadObject (r);
					if (p == md.Body.ReturnValue)
						ret = obj;
					else
						parameters [p.Index] = obj;
				}
				if (md.Body.WrapperName != null)
					r.ReadEndElement ();
			}
			return ret;
		}
	}
}
