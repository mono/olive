//
// SyndicationFeed.cs
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
	public class SyndicationFeed
	{
		[MonoTODO]
		public SyndicationFeed ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public SyndicationFeed (IEnumerable<SyndicationItem> items)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public SyndicationFeed (string title, string description, Uri feedAlternateLink)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public SyndicationFeed (string title, string description, Uri feedAlternateLink,
					IEnumerable<SyndicationItem> items)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public SyndicationFeed (string title, string description, Uri feedAlternateLink, string id,
					DateTimeOffset lastUpdatedTime)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public SyndicationFeed (string title, string description, Uri feedAlternateLink, string id,
					DateTimeOffset lastUpdatedTime, IEnumerable<SyndicationItem> items)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected SyndicationFeed (SyndicationFeed source, bool cloneItems)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Dictionary<XmlQualifiedName, string> AttributeExtensions {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public SyndicationElementExtensionCollection ElementExtensions {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public Collection<SyndicationPerson> Authors {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public Collection<SyndicationCategory> Categories {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public Collection<SyndicationPerson> Contributors {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public IEnumerable<SyndicationItem> Items {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public Collection<SyndicationLink> Links {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public Uri BaseUri {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public TextSyndicationContent Copyright {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public TextSyndicationContent Description {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public string Generator {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public string Id {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public Uri ImageUrl {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public string Language {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public DateTimeOffset LastUpdatedTime {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public TextSyndicationContent Title {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public virtual SyndicationFeed Clone (bool cloneItems)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal virtual SyndicationCategory CreateCategory ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal virtual SyndicationItem CreateItem ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal virtual SyndicationLink CreateLink ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal virtual SyndicationPerson CreatePerson ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Atom10FeedFormatter GetAtom10Formatter ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Rss20FeedFormatter GetRss20Formatter ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Rss20FeedFormatter GetRss20Formatter (bool serializeExtensionsAsAtom)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static SyndicationFeed Load (XmlReader reader)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static TSyndicationFeed Load<TSyndicationFeed> (XmlReader reader) where TSyndicationFeed : SyndicationFeed
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void SaveAsAtom10 (XmlWriter writer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void SaveAsRss20 (XmlWriter writer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal virtual bool TryParseAttribute (string name, string ns, string value, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal virtual bool TryParseElement (XmlReader reader, string version)
		{
			throw new NotImplementedException ();
		}


		[MonoTODO]
		protected internal virtual void WriteAttributeExtensions (XmlWriter writer, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal virtual void WriteElementExtensions (XmlWriter writer, string version)
		{
			throw new NotImplementedException ();
		}
	}
}
