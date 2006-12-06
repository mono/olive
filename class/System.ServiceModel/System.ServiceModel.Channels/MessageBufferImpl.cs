//
// MessageBufferImpl.cs
//
// Author:
//	Duncan Mak (duncan@novell.com)
//
// Copyright (C) 2006 Novell, Inc.  http://www.novell.com
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
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.XPath;

namespace System.ServiceModel.Channels
{
	internal class DefaultMessageBuffer : MessageBuffer
	{
		MessageHeaders headers;
		BodyWriter body;
		bool closed, is_fault;
		
		internal DefaultMessageBuffer (MessageHeaders headers)
			: this (headers, null, false)
		{
		}

		internal DefaultMessageBuffer (MessageHeaders headers, BodyWriter body, bool isFault)
		{
			this.headers = headers;
			this.body = body;
			this.closed = false;
			this.is_fault = isFault;
		}

		public override void Close ()
		{
			if (closed) 
				return;
			
			headers = null;
			body = null;
			closed = true;
		}
		

		public override Message CreateMessage ()
		{
			if (closed)
				throw new ObjectDisposedException ("The message buffer has already been closed.");
			
			if (body == null)
				return new EmptyMessage (headers.MessageVersion, headers.Action);
			else
				return new SimpleMessage (headers.MessageVersion, headers.Action, body, is_fault);
		}

		public override int BufferSize {
			get { return 0; }
		}
	}

	/*
	internal class XmlReaderMessageBuffer : MessageBuffer
	{
		MessageVersion version;
		XmlDictionaryReader reader;
		int max_headers;

		bool closed;
		
		internal XmlReaderMessageBuffer (MessageVersion version, XmlDictionaryReader reader, int maxSizeOfHeaders)
		{
			this.version = version;
			this.reader = reader;
			this.max_headers = maxSizeOfHeaders;
			this.closed = false;
		}

		public override void Close ()
		{
			if (closed)
				return;

			version = null;
			reader = null;
			max_headers = 0;
			closed = true;
		}

		public override Message CreateMessage ()
		{
			if (closed)
				throw new ArgumentNullException ();

			return new XmlReaderMessage (version, reader, max_headers);
		}
		

		public override int BufferSize {
			get { throw new NotImplementedException (); }
		}
	}
	*/

	internal class XPathMessageBuffer : MessageBuffer
	{
		IXPathNavigable source;
		MessageVersion version;
		int max_header_size;

		public XPathMessageBuffer (IXPathNavigable source, MessageVersion version, int maxSizeOfHeaders)
		{
			this.source = source;
			this.version = version;
			this.max_header_size = maxSizeOfHeaders;
		}

		public override void Close ()
		{
		}

		public override Message CreateMessage ()
		{
			XmlDictionaryReader r = XmlDictionaryReader.CreateDictionaryReader (source.CreateNavigator ().ReadSubtree ());
			return new XmlReaderMessage (version, r, max_header_size);
		}

		public override int BufferSize {
			// FIXME: implement
			get { return 0; }
		}
	}
}