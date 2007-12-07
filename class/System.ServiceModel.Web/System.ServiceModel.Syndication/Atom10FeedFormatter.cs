//
// Atom10FeedFormatter.cs
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

namespace System.ServiceModel.Syndication
{
	public class Atom10FeedFormatter : SyndicationFeedFormatter
	{
		[MonoTODO]
		public Atom10FeedFormatter ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Atom10FeedFormatter (SyndicationFeed feedToWrite)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Atom10FeedFormatter (Type feedTypeToCreate)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected Type FeedType {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public bool PreserveAttributeExtensions {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public bool PreserveElementExtensions {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override string Version {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		protected override SyndicationFeed CreateFeedInstance ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override bool CanRead (XmlReader reader)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void ReadFrom (XmlReader reader)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected virtual SyndicationItem ReadItem (XmlReader reader, SyndicationFeed feed)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected virtual IEnumerable<SyndicationItem> ReadItems (XmlReader reader, SyndicationFeed feed, out bool areAllItemsRead)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected virtual void WriteItem (XmlWriter writer, SyndicationItem item, Uri feedBaseUri)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected virtual void WriteItems (XmlWriter writer, IEnumerable<SyndicationItem> items, Uri feedBaseUri)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void WriteTo (XmlWriter writer)
		{
			throw new NotImplementedException ();
		}
	}
}
