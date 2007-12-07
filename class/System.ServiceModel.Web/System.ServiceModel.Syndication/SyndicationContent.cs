//
// SyndicationContent.cs
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace System.ServiceModel.Syndication
{
	public abstract class SyndicationContent
	{
		[MonoTODO]
		public static TextSyndicationContent CreateHtmlContent (string content)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static TextSyndicationContent CreatePlaintextContent (string content)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static UrlSyndicationContent CreateUrlContent (Uri url, string mediaType)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static TextSyndicationContent CreateXhtmlContent (string content)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static XmlSyndicationContent CreateXmlContent (object dataContractObject)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static XmlSyndicationContent CreateXmlContent (object dataContractObject, XmlObjectSerializer dataContractSerializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static XmlSyndicationContent CreateXmlContent (object xmlSerializerObject, XmlSerializer serializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static XmlSyndicationContent CreateXmlContent (XmlReader reader)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected SyndicationContent ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected SyndicationContent (SyndicationContent source)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Dictionary<XmlQualifiedName, string> AttributeExtensions {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public abstract string Type { get; }

		[MonoTODO]
		public abstract SyndicationContent Clone ();

		[MonoTODO]
		protected abstract void WriteContentsTo (XmlWriter writer);

		[MonoTODO]
		public void WriteTo (XmlWriter writer, string outerElementName, string outerElementNamespace)
		{
			throw new NotImplementedException ();
		}

	}
}
