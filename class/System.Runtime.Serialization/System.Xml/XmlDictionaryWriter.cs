//
// XmlDictionaryWriter.cs
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
using System.IO;
using System.Text;

namespace System.Xml
{
	public abstract partial class XmlDictionaryWriter : XmlWriter
	{
		protected XmlDictionaryWriter ()
		{
		}

		public virtual bool CanCanonicalize {
			get { return false; }
		}

		[MonoTODO]
		public static XmlDictionaryWriter CreateBinaryWriter (
			Stream stream)
		{
			return CreateBinaryWriter (stream, null, null, false);
		}

		[MonoTODO]
		public static XmlDictionaryWriter CreateBinaryWriter (
			Stream stream, IXmlDictionary dictionary)
		{
			return CreateBinaryWriter (stream, dictionary, null, false);
		}

		[MonoTODO]
		public static XmlDictionaryWriter CreateBinaryWriter (
			Stream stream, IXmlDictionary dictionary,
			XmlBinaryWriterSession session)
		{
			return CreateBinaryWriter (stream, dictionary, session, false);
		}

		[MonoTODO ("binary XmlWriter is incomplete")]
		public static XmlDictionaryWriter CreateBinaryWriter (
			Stream stream, IXmlDictionary dictionary,
			XmlBinaryWriterSession session, bool ownsStream)
		{
			return new XmlBinaryDictionaryWriter (stream,
				dictionary, session, ownsStream);
		}

		[MonoTODO]
		public static XmlDictionaryWriter CreateDictionaryWriter (XmlWriter writer)
		{
			return new XmlSimpleDictionaryWriter (writer);
		}

		[MonoTODO]
		public static XmlDictionaryWriter CreateMtomWriter (
			Stream stream, Encoding encoding, int maxSizeInBytes,
			string startInfo)
		{
			return CreateMtomWriter (stream, encoding,
				maxSizeInBytes, startInfo, null, null, false, false);
		}

		[MonoTODO]
		public static XmlDictionaryWriter CreateMtomWriter (
			Stream stream, Encoding encoding, int maxSizeInBytes,
			string startInfo, string boundary, string startUri,
			bool writeMessageHeaders, bool ownsStream)
		{
			throw new NotImplementedException ();
		}

		public static XmlDictionaryWriter CreateTextWriter (
			Stream stream)
		{
			XmlWriterSettings s = new XmlWriterSettings ();
			s.OmitXmlDeclaration = true;
			s.Encoding = new UTF8Encoding (false);
			return CreateDictionaryWriter (XmlWriter.Create (stream, s));
		}

		public static XmlDictionaryWriter CreateTextWriter (
			Stream stream, Encoding encoding)
		{
			return CreateTextWriter (stream, encoding, false);
		}

		[MonoTODO]
		public static XmlDictionaryWriter CreateTextWriter (
			Stream stream, Encoding encoding, bool ownsStream)
		{
			XmlWriterSettings s = new XmlWriterSettings ();
			s.Encoding = encoding;
			s.CloseOutput = ownsStream;
			s.OmitXmlDeclaration = true;
			return CreateDictionaryWriter (XmlWriter.Create (stream, s));
		}

		public virtual void EndCanonicalization ()
		{
			throw new NotSupportedException ();
		}

		public virtual void StartCanonicalization (
			Stream stream, bool includeComments,
			string [] inclusivePrefixes)
		{
			throw new NotSupportedException ();
		}

		// FIXME: add Write*Array() overloads.

		public void WriteAttributeString (
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri,
			string value)
		{
			WriteAttributeString (localName.Value, namespaceUri.Value, value);
		}

		public void WriteAttributeString (string prefix,
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri,
			string value)
		{
			WriteAttributeString (prefix, localName.Value, namespaceUri.Value, value);
		}

		public void WriteElementString (
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri,
			string value)
		{
			WriteElementString (localName.Value, namespaceUri.Value, value);
		}

		public void WriteElementString (string prefix,
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri,
			string value)
		{
			WriteElementString (prefix, localName.Value, namespaceUri.Value, value);
		}

		[MonoTODO ("make use of dictionary reader optimization")]
		public virtual void WriteNode (XmlDictionaryReader reader,
			bool defattr)
		{
			WriteNode ((XmlReader) reader, defattr);
		}

		[MonoTODO ("make use of dictionary reader optimization")]
		public virtual void WriteNode (XmlReader reader, bool defattr)
		{
			base.WriteNode (reader, defattr);
		}

		public virtual void WriteQualifiedName (
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri)
		{
			WriteQualifiedName (localName.Value, namespaceUri.Value);
		}

		public void WriteStartAttribute (
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri)
		{
			WriteStartAttribute (localName.Value, namespaceUri.Value);
		}

		public virtual void WriteStartAttribute (string prefix,
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri)
		{
			WriteStartAttribute (prefix, localName.Value, namespaceUri.Value);
		}

		public void WriteStartElement (
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri)
		{
			WriteStartElement (localName.Value, namespaceUri.Value);
		}

		public virtual void WriteStartElement (string prefix,
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri)
		{
			WriteStartElement (prefix, localName.Value, namespaceUri.Value);
		}

		public virtual void WriteString (XmlDictionaryString value)
		{
			WriteString (value.Value);
		}

		public virtual void WriteValue (Guid guid)
		{
			throw new NotSupportedException ();
		}

		public virtual void WriteValue (TimeSpan duration)
		{
			throw new NotSupportedException ();
		}

		public virtual void WriteValue (UniqueId id)
		{
			throw new NotSupportedException ();
		}

		public virtual void WriteValue (XmlDictionaryString value)
		{
			WriteValue (value.Value);
		}

		public virtual void WriteXmlAttribute (string localName, string value)
		{
			WriteAttributeString ("xml", localName, "http://www.w3.org/XML/1998/namespace", value);
		}

		public virtual void WriteXmlAttribute (XmlDictionaryString localName,
			XmlDictionaryString value)
		{
			WriteXmlAttribute (localName.Value, value.Value);
		}

		public virtual void WriteXmlnsAttribute (
			string prefix, string namespaceUri)
		{
			// BTW .NET 2.0 those XmlWriters from XmlWrite.Create()
			// rejects namespace overriding i.e.
			//
			//	xw.WriteStartElement ("foo", "urn:foo");
			//	xw.WriteXmlnsAttribute ("foo", "urn:bar");
			//
			// causes an XmlException. We need fix in sys.xml.dll
			if (prefix == String.Empty)
				WriteAttributeString ("xmlns", namespaceUri);
			else
				WriteAttributeString ("xmlns", prefix, "http://www.w3.org/2000/xmlns/", namespaceUri);
		}

		public virtual void WriteXmlnsAttribute (string prefix,
			XmlDictionaryString namespaceUri)
		{
			WriteXmlnsAttribute (prefix, namespaceUri.Value);
		}
	}
}
#endif
