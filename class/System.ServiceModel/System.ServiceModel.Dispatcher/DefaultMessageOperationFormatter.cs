//
// DefaultMessageOperationFormatter.cs
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
		XmlObjectSerializer serializer;

		public DefaultResponseBodyWriter (MessageBodyDescription desc, XmlObjectSerializer serializer, object obj, object [] parameters)
			: base (false)
		{
			this.desc = desc;
			this.serializer = serializer;
			this.obj = obj;
			this.parameters = parameters;
		}

		protected override void OnWriteBodyContents (XmlDictionaryWriter writer)
		{
			writer.WriteStartElement (desc.WrapperName, desc.WrapperNamespace);
			if (desc.ReturnValue != null)
				WriteMessagePart (writer, desc.ReturnValue, obj);
			foreach (MessagePartDescription part in desc.Parts)
				WriteMessagePart (writer, part, parameters [part.Index]);
			writer.WriteEndElement ();
		}

		void WriteMessagePart (XmlDictionaryWriter writer, MessagePartDescription part, object obj)
		{
			writer.WriteStartElement (part.Name, part.Namespace);
			serializer.WriteObjectContent (writer, obj);
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
		OperationDescription operation;

		public Message SerializeRequest (
			MessageVersion version, object [] parameters)
		{
			MessageDescription md = null;
			foreach (MessageDescription mdi in operation.Messages)
				if (mdi.Direction == MessageDirection.Input)
					md = mdi;

			// FIXME: consider ref/out parameters.
			return Message.CreateMessage (version, md.Action,
				new DefaultResponseBodyWriter (md.Body, GetSerializer (md), null, parameters));
		}

		public Message SerializeReply (
			MessageVersion version, object [] parameters, object result)
		{
			// use_response_converter

			MessageDescription md = null;
			foreach (MessageDescription mdi in operation.Messages)
				if (mdi.Direction == MessageDirection.Output)
					md = mdi;

			// FIXME: handle (ref/out) parameters.
			string replyAction = version.Addressing == AddressingVersion.None ? null : md.Action;
			return Message.CreateMessage (version, replyAction,
				new DefaultResponseBodyWriter (md.Body, GetSerializer (md), result, parameters));
		}

		XmlObjectSerializer GetSerializer (MessageDescription md)
		{
			if (serializers.ContainsKey (md))
				return serializers [md];
			MessageDescriptionMapping map = GetMapping (md);
			// since MessageDescription.MessageType could be null,
			// we cannot use it.
			XmlObjectSerializer ret = new DataContractSerializer (map.ProxyType);
			serializers [md] = ret;
			return ret;
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

			MessageDescriptionMapping map = GetMapping (md);

			if (!message.IsEmpty) {
				XmlDictionaryReader r = message.GetReaderAtBodyContents ();

				object obj = GetSerializer (md).ReadObject (r);
				foreach (MessagePartDescription p in md.Body.Parts)
					parameters [p.Index] = map.Fields [p.Index].GetValue (obj);
			}
		}

		public object DeserializeReply (
			Message message, object [] parameters)
		{
			MessageDescription md = null;
			foreach (MessageDescription mdi in operation.Messages)
				if (mdi.Direction == MessageDirection.Output)
					md = mdi;

			MessageDescriptionMapping map = GetMapping (md);

			XmlDictionaryReader r = message.GetReaderAtBodyContents ();

			object obj = GetSerializer (md).ReadObject (r);
			// out/ref parameters
			foreach (MessagePartDescription p in md.Body.Parts)
				parameters [p.Index] = map.Fields [p.Index].GetValue (obj);
			// return value
			return map.Fields [md.Body.ReturnValue.Index].GetValue (obj);
		}
	}
}
