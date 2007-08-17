//
// ServiceModelInternalConverter.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006-2007 Novell, Inc.  http://www.novell.com
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
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Reflection;
using System.Text;
using Mono.CodeGeneration;

namespace System.ServiceModel.Description
{
	internal class MessageDescriptionMapping
	{
		public Dictionary<Type,XmlObjectSerializer> Serializers =
			new Dictionary<Type,XmlObjectSerializer> ();
	}

	internal static class ServiceModelInternalConverter
	{
		public static MessageDescriptionMapping MessageBodyToDataContractType (MessageBodyDescription desc)
		{
			MessageDescriptionMapping map = new MessageDescriptionMapping ();

			List<MessagePartDescription> parts =
				new List<MessagePartDescription> ();
			parts.AddRange (desc.Parts);
			if (desc.ReturnValue != null)
				parts.Add (desc.ReturnValue);

			foreach (MessagePartDescription part in parts)
				if (!map.Serializers.ContainsKey (part.Type))
					map.Serializers [part.Type] = new DataContractSerializer (part.Type);

			return map;
		}

		public static Type ToXmlSerializableType (Type src, string defaultNS)
		{
			MessageBodyDescription desc =
				MessageContractToMessageBody (src);

			throw new NotImplementedException ();
		}

		public static MessageBodyDescription MessageContractToMessageBody (
			Type src)
		{
			MessageContractAttribute mca =
				ContractDescriptionGenerator.GetMessageContractAttribute (src);

			if (mca == null)
				throw new ArgumentException (String.Format ("Type {0} and its ancestor types do not have MessageContract attribute.", src));

			MessageBodyDescription mb = new MessageBodyDescription ();
			if (mca.IsWrapped) {
				mb.WrapperName = mca.WrapperName ?? src.Name;
				mb.WrapperNamespace = mca.WrapperNamespace ?? TypedMessageConverter.TempUri;
			}

			ContractDescriptionGenerator.FillMessageBodyDescriptionByContract (src, mb);

			return mb;
		}
	}
}
