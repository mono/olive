//
// XmlSyndicationContent.cs
//
// Author:
//      Stephen A Jazdzewski (Steve@Jazd.com)
//
// Copyright (C) 2007 Stephen A Jazdzewski
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
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel.Syndication;

namespace System.ServiceModel.Syndication
{
	[MonoTODO]
	public class XmlSyndicationContent : SyndicationContent {
		[MonoTODO]
		public XmlSyndicationContent (string type, XmlElement element)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public XmlSyndicationContent (string type, SyndicationElementExtension extension)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public XmlSyndicationContent (string type, object xmlSerializerExtension, XmlSerializer serializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public XmlSyndicationContent (string type, object dataContractExtension, XmlObjectSerializer dateContractSerializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public XmlSyndicationContent (XmlReader reader, int maxContentSize)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public XmlDictionaryReader GetReaderAtContent()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public TContent ReadContent <TContent> ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public TContent ReadContent <TContent> (XmlSerializer serializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public TContent ReadContent <TContent> (XmlObjectSerializer dataContractSerializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override void WriteContentsTo (XmlWriter writer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public SyndicationElementExtension Extension {
			get {throw new NotImplementedException ();}
		}

		public override string Type {
			get {throw new NotImplementedException ();}
		}
	}
}
