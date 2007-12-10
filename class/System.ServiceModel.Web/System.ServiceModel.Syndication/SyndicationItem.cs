//
// SyndicationItem.cs
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
	public class SyndicationItem : ISyndicationElement
	{
		[MonoTODO]
		public SyndicationItem ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public SyndicationItem (string title, string description, Uri feedAlternateLink)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public SyndicationItem (string title, string description, Uri feedAlternateLink, string id,
					DateTimeOffset lastUpdatedTime)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public SyndicationItem (string title, SyndicationContent content, Uri feedAlternateLink, string id,
					DateTimeOffset lastUpdatedTime)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected SyndicationItem (SyndicationItem source)
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
		public SyndicationContent Content {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public string Id {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public DateTimeOffset LastUpdatedTime {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public DateTimeOffset PublishDate {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public SyndicationFeed SourceFeed {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public TextSyndicationContent Summary {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public TextSyndicationContent Title {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public void AddPermalink (Uri link)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual SyndicationItem Clone ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal virtual SyndicationCategory CreateCategory ()
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
		public Atom10ItemFormatter GetAtom10Formatter ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Rss20ItemFormatter GetRss20Formatter ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public Rss20ItemFormatter GetRss20Formatter (bool serializeExtensionsAsAtom)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static SyndicationItem Load (XmlReader reader)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static TSyndicationItem Load<TSyndicationItem> (XmlReader reader) where TSyndicationItem : SyndicationItem
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
		protected internal virtual bool TryParseContent (XmlReader reader, string contentType, string version, out SyndicationContent content)
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
