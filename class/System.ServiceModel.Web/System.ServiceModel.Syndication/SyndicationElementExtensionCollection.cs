//
// SyndicationElementExtensionCollection.cs
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
	public sealed class SyndicationElementExtensionCollection : Collection<SyndicationElementExtension>
	{
		internal SyndicationElementExtensionCollection ()
		{
		}

		internal SyndicationElementExtensionCollection (IEnumerable<SyndicationElementExtension> source)
		{
			if (source == null)
				throw new ArgumentNullException ("source");
			foreach (SyndicationElementExtension item in source)
				Add (item);
		}

		[MonoTODO]
		public void Add (object extension)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void Add (object dataContractExtension, DataContractSerializer serializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void Add (object xmlSerializerExtension, XmlSerializer serializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void Add (string outerName, string outerNamespace, object dataContractExtension)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void Add (string outerName, string outerNamespace, object dataContractExtension, XmlObjectSerializer dataContractSerializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void Add (XmlReader xmlReader)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override void ClearItems ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public XmlReader GetReaderAtElementExtensions ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override void InsertItem (int index, SyndicationElementExtension item)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Collection<TExtension> ReadElementExtensions<TExtension> (string extensionName, string extensionNamespace)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Collection<TExtension> ReadElementExtensions<TExtension> (string extensionName, string extensionNamespace, XmlObjectSerializer serializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Collection<TExtension> ReadElementExtensions<TExtension> (string extensionName, string extensionNamespace, XmlSerializer serializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override void RemoveItem (int index)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override void SetItem (int index, SyndicationElementExtension item)
		{
			throw new NotImplementedException ();
		}
	}
}
