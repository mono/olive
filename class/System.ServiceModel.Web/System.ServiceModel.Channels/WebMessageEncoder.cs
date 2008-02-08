//
// WebMessageEncoder.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
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
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Xml;

namespace System.ServiceModel.Channels
{
	internal class WebMessageEncoder : MessageEncoder
	{
		WebMessageEncodingBindingElement source;

		public WebMessageEncoder (WebMessageEncodingBindingElement source)
		{
			this.source = source;
		}

		public override string ContentType {
			get { return MediaType + "; charset=" + source.WriteEncoding.HeaderName; }
		}

		// FIXME: find out how it can be customized.
		public override string MediaType {
			get { return "application/xml"; }
		}

		public override MessageVersion MessageVersion {
			get { return MessageVersion.None; }
		}

		public override Message ReadMessage (ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
		{
			throw new NotImplementedException ();
		}

		public override Message ReadMessage (Stream stream, int maxSizeOfHeaders, string contentType)
		{
			throw new NotImplementedException ();
		}

		WebContentFormat GetContentFormat ()
		{
			if (source.ContentTypeMapper != null)
				return source.ContentTypeMapper.GetMessageFormatForContentType (ContentType);
			switch (MediaType) {
			case "application/xml":
			case "text/xml":
				return WebContentFormat.Xml;
			case "application/json":
			case "text/json":
				return WebContentFormat.Json;
			case "application/octet-stream":
				return WebContentFormat.Raw;
			default:
				return WebContentFormat.Default;
			}
		}

		public override void WriteMessage (Message message, Stream stream)
		{
			if (message == null)
				throw new ArgumentNullException ("message");
			if (!MessageVersion.Equals (message.Version))
				throw new ProtocolException (String.Format ("MessageVersion {0} is not supported", message.Version));
			if (stream == null)
				throw new ArgumentNullException ("stream");

			switch (GetContentFormat ()) {
			case WebContentFormat.Xml:
				using (XmlWriter w = XmlDictionaryWriter.CreateTextWriter (stream, source.WriteEncoding))
					message.WriteMessage (w);
				break;
			case WebContentFormat.Json:
				using (XmlWriter w = JsonReaderWriterFactory.CreateJsonWriter (stream, source.WriteEncoding))
					message.WriteMessage (w);
				break;
			case WebContentFormat.Raw:
				throw new NotImplementedException ();
			case WebContentFormat.Default:
				throw new SystemException ("INTERNAL ERROR: cannot determine content format");
			}
		}

		public override ArraySegment<byte> WriteMessage (Message message, int maxMessageSize, BufferManager bufferManager,
								 int messageOffset)
		{
			throw new NotImplementedException ();
		}
	}
}
