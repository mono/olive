//
// XmlDictionaryReader.cs
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
using System.Xml;

namespace System.Xml
{
	public abstract class XmlDictionaryReader : XmlReader
	{
		protected XmlDictionaryReader ()
		{
		}

		public virtual bool CanCanonicalize {
			get { return false; }
		}

		public virtual XmlDictionaryReaderQuotas Quotas {
			get { return null; }
		}

		[MonoTODO]
		public virtual void EndCanonicalization ()
		{
			throw new NotSupportedException ();
		}

		public virtual string GetAttribute (
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri)
		{
			if (localName == null)
				throw new ArgumentNullException ("localName");
			if (namespaceUri == null)
				throw new ArgumentNullException ("namespaceUri");
			return GetAttribute (localName.Value, namespaceUri.Value);
		}

		public virtual int IndexOfLocalName (
			string [] localNames, string namespaceUri)
		{
			if (localNames == null)
				throw new ArgumentNullException ("localNames");
			if (namespaceUri == null)
				throw new ArgumentNullException ("namespaceUri");
			if (NamespaceURI != namespaceUri)
				return -1;
			for (int i = 0; i < localNames.Length; i++)
				if (localNames [i] == LocalName)
					return i;
			return -1;
		}

		public virtual int IndexOfLocalName (
			XmlDictionaryString [] localNames,
			XmlDictionaryString namespaceUri)
		{
			if (localNames == null)
				throw new ArgumentNullException ("localNames");
			if (namespaceUri == null)
				throw new ArgumentNullException ("namespaceUri");
			if (NamespaceURI != namespaceUri.Value)
				return -1;
			XmlDictionaryString localName;
			if (!TryGetLocalNameAsDictionaryString (out localName))
				return -1;
			IXmlDictionary dict = localName.Dictionary;
			XmlDictionaryString iter;
			for (int i = 0; i < localNames.Length; i++)
				if (dict.TryLookup (localNames [i], out iter) && object.ReferenceEquals (iter, localName))
					return i;
			return -1;
		}

		public virtual bool IsLocalName (string localName)
		{
			return LocalName == localName;
		}

		public virtual bool IsLocalName (XmlDictionaryString localName)
		{
			if (localName == null)
				throw new ArgumentNullException ("localName");
			return LocalName == localName.Value;
		}

		public virtual bool IsNamespaceUri (string namespaceUri)
		{
			return NamespaceURI == namespaceUri;
		}

		public virtual bool IsNamespaceUri (XmlDictionaryString namespaceUri)
		{
			if (namespaceUri == null)
				throw new ArgumentNullException ("namespaceUri");
			return NamespaceURI == namespaceUri.Value;
		}

		[MonoTODO]
		public virtual bool IsStartArray (out Type type)
		{
			throw new NotImplementedException ();
		}

		public virtual bool IsStartElement (
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri)
		{
			if (localName == null)
				throw new ArgumentNullException ("localName");
			if (namespaceUri == null)
				throw new ArgumentNullException ("namespaceUri");
			return IsStartElement (localName.Value, namespaceUri.Value);
		}

		[MonoTODO]
		public virtual void MoveToStartElement ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual void MoveToStartElement (string name)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual void MoveToStartElement (
			string localName, string namespaceUri)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual void MoveToStartElement (
			XmlDictionaryString localName,
			XmlDictionaryString namespaceUri)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual void StartCanonicalization (
			Stream stream, bool includeComments,
			string [] inclusivePrefixes)
		{
			throw new NotSupportedException ();
		}

		[MonoTODO]
		public virtual bool TryGetArrayLength (out int count)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual bool TryGetBase64ContentLength (out int count)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual bool TryGetLocalNameAsDictionaryString (
			out XmlDictionaryString localName)
		{
			localName = null;
			return false;
		}

		[MonoTODO]
		public virtual bool TryGetNamespaceUriAsDictionaryString (
			out XmlDictionaryString namespaceUri)
		{
			namespaceUri = null;
			return false;
		}

		// FIXME: add Read*Array() overloads


		#region Factory Methods

		public static XmlDictionaryReader CreateBinaryReader (
			byte [] buffer, XmlDictionaryReaderQuotas quotas)
		{
			return CreateBinaryReader (buffer, 0, buffer.Length, quotas);
		}

		public static XmlDictionaryReader CreateBinaryReader (
			byte [] buffer, int offset, int count, 
			XmlDictionaryReaderQuotas quotas)
		{
			return CreateBinaryReader (buffer, offset, count, new XmlDictionary (), quotas);
		}

		public static XmlDictionaryReader CreateBinaryReader (
			byte [] buffer, int offset, int count,
			IXmlDictionary dictionary,
			XmlDictionaryReaderQuotas quotas)
		{
			return CreateBinaryReader (buffer, offset, count,
				dictionary, quotas,
				new XmlBinaryReaderSession (), null);
		}

		public static XmlDictionaryReader CreateBinaryReader (
			byte [] buffer, int offset, int count,
			IXmlDictionary dictionary,
			XmlDictionaryReaderQuotas quotas,
			XmlBinaryReaderSession session)
		{
			return CreateBinaryReader (buffer, offset, count,
				dictionary, quotas,
				session, null);
		}

		public static XmlDictionaryReader CreateBinaryReader (
			byte [] buffer, int offset, int count,
			IXmlDictionary dictionary,
			XmlDictionaryReaderQuotas quotas,
			XmlBinaryReaderSession session,
			OnXmlDictionaryReaderClose onClose)
		{
			return new XmlBinaryDictionaryReader (buffer,
				offset, count,
				dictionary, quotas, session, onClose);
		}

		public static XmlDictionaryReader CreateBinaryReader (
			Stream stream, XmlDictionaryReaderQuotas quotas)
		{
			return CreateBinaryReader (stream, new XmlDictionary (), quotas);
		}

		public static XmlDictionaryReader CreateBinaryReader (
			Stream stream, IXmlDictionary dictionary, 
			XmlDictionaryReaderQuotas quotas)
		{
			return CreateBinaryReader (stream, dictionary, quotas,
				new XmlBinaryReaderSession (), null);
		}

		public static XmlDictionaryReader CreateBinaryReader (
			Stream stream, IXmlDictionary dictionary, 
			XmlDictionaryReaderQuotas quotas,
			XmlBinaryReaderSession session)
		{
			return CreateBinaryReader (stream, dictionary, quotas,
				session, null);
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateBinaryReader (
			Stream stream, IXmlDictionary dictionary,
			XmlDictionaryReaderQuotas quotas,
			XmlBinaryReaderSession session,
			OnXmlDictionaryReaderClose onClose)
		{
			return new XmlBinaryDictionaryReader (stream,
				dictionary, quotas, session, onClose);
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateDictionaryReader (
			XmlReader reader)
		{
			return new XmlSimpleDictionaryReader (reader);
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateMtomReader (
			Stream stream, Encoding encoding,
			XmlDictionaryReaderQuotas quotas)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateMtomReader (
			Stream stream, Encoding [] encodings,
			XmlDictionaryReaderQuotas quotas)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateMtomReader (
			Stream stream, Encoding [] encodings, string contentType,
			XmlDictionaryReaderQuotas quotas)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateMtomReader (
			Stream stream, Encoding [] encodings, string contentType,
			XmlDictionaryReaderQuotas quotas,
			int maxBufferSize,
			OnXmlDictionaryReaderClose onClose)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateMtomReader (
			byte [] buffer, int offset, int count,
			Encoding encoding, XmlDictionaryReaderQuotas quotas)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateMtomReader (
			byte [] buffer, int offset, int count,
			Encoding [] encodings, XmlDictionaryReaderQuotas quotas)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateMtomReader (
			byte [] buffer, int offset, int count,
			Encoding [] encodings, string contentType,
			XmlDictionaryReaderQuotas quotas)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateMtomReader (
			byte [] buffer, int offset, int count,
			Encoding [] encodings, string contentType,
			XmlDictionaryReaderQuotas quotas,
			int maxBufferSize,
			OnXmlDictionaryReaderClose onClose)
		{
			throw new NotImplementedException ();
		}

		public static XmlDictionaryReader CreateTextReader (byte [] buffer, XmlDictionaryReaderQuotas quotas)
		{
			return CreateTextReader (buffer, 0, buffer.Length, quotas);
		}

		public static XmlDictionaryReader CreateTextReader (
			byte [] buffer, int offset, int count,
			XmlDictionaryReaderQuotas quotas)
		{
			return CreateTextReader (buffer, offset, count,
				Encoding.UTF8, quotas, null);
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateTextReader (
			byte [] buffer, int offset, int count,
			Encoding encoding,
			XmlDictionaryReaderQuotas quotas,
			OnXmlDictionaryReaderClose onClose)
		{
			throw new NotImplementedException ();
		}

		public static XmlDictionaryReader CreateTextReader (
			Stream stream, XmlDictionaryReaderQuotas quotas)
		{
			return CreateTextReader (stream, Encoding.UTF8, quotas, null);
		}

		[MonoTODO]
		public static XmlDictionaryReader CreateTextReader (
			Stream stream, Encoding encoding,
			XmlDictionaryReaderQuotas quotas,
			OnXmlDictionaryReaderClose onClose)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}
#endif
