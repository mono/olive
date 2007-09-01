//
// JsonReaderWriterFactory.cs
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
using System.IO;
using System.Text;

namespace System.Xml
{
	public static class JsonReaderWriterFactory
	{
		public static XmlDictionaryReader CreateJsonReader (byte [] source, XmlDictionaryReaderQuotas quotas)
		{
			return CreateJsonReader (source, 0, source.Length, quotas);
		}

		public static XmlDictionaryReader CreateJsonReader (byte [] source, int offset, int length, XmlDictionaryReaderQuotas quotas)
		{
			return CreateJsonReader (source, offset, length, Encoding.UTF8, quotas, null);
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateJsonReader (byte [] source, int offset, int length, Encoding encoding, XmlDictionaryReaderQuotas quotas, OnXmlDictionaryReaderClose readerClose)
		{
			throw new NotImplementedException ();
		}

		public static XmlDictionaryReader CreateJsonReader (Stream source, XmlDictionaryReaderQuotas quotas)
		{
			return CreateJsonReader (source, Encoding.UTF8, quotas, null);
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateJsonReader (Stream source, Encoding encoding, XmlDictionaryReaderQuotas quotas, OnXmlDictionaryReaderClose readerClose)
		{
			throw new NotImplementedException ();
		}

		public static XmlDictionaryWriter CreateJsonWriter (Stream stream)
		{
			return CreateJsonWriter (stream, new UTF8Encoding (false, true));
		}

		public static XmlDictionaryWriter CreateJsonWriter (Stream stream, Encoding encoding)
		{
			return CreateJsonWriter (stream, encoding, false);
		}

		public static XmlDictionaryWriter CreateJsonWriter (Stream stream, Encoding encoding, bool closeOutput)
		{
			return new JsonWriter (stream, encoding, closeOutput);
		}
	}
}
