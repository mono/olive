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

// WARNING: this class is not for ensuring valid ATOM 1.0 document output
// (as well as Atom10ItemFormatter).

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.ServiceModel.Syndication
{
	[XmlRoot ("feed", Namespace = "http://www.w3.org/2005/Atom")]
	public class Atom10FeedFormatter : SyndicationFeedFormatter, IXmlSerializable
	{
		const string AtomNamespace ="http://www.w3.org/2005/Atom";

		bool preserve_att_ext, preserve_elem_ext;
		Type feed_type;

		public Atom10FeedFormatter ()
		{
		}

		public Atom10FeedFormatter (SyndicationFeed feedToWrite)
			: base (feedToWrite)
		{
		}

		public Atom10FeedFormatter (Type feedTypeToCreate)
		{
			if (feedTypeToCreate == null)
				throw new ArgumentNullException ("feedTypeToCreate");
			feed_type = feedTypeToCreate;
		}

		protected Type FeedType {
			get { return feed_type; }
		}

		public bool PreserveAttributeExtensions {
			get { return preserve_att_ext; }
			set { preserve_att_ext = value; }
		}

		public bool PreserveElementExtensions {
			get { return preserve_elem_ext; }
			set { preserve_elem_ext = value; }
		}

		public override string Version {
			get { return "Atom10"; }
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


		[MonoTODO ("Find out how feedBaseUri is used")]
		protected virtual void WriteItem (XmlWriter writer, SyndicationItem item, Uri feedBaseUri)
		{
			item.SaveAsAtom10 (writer);
		}

		protected virtual void WriteItems (XmlWriter writer, IEnumerable<SyndicationItem> items, Uri feedBaseUri)
		{
			if (items == null)
				throw new ArgumentNullException ("items");
			foreach (SyndicationItem item in items)
				WriteItem (writer, item, feedBaseUri);
		}

		public override void WriteTo (XmlWriter writer)
		{
			WriteXml (writer, true);
		}

		[MonoTODO]
		void IXmlSerializable.ReadXml (XmlReader reader)
		{
			throw new NotImplementedException ();
		}

		void IXmlSerializable.WriteXml (XmlWriter writer)
		{
			WriteXml (writer, false);
		}

		[MonoTODO]
		XmlSchema IXmlSerializable.GetSchema ()
		{
			throw new NotImplementedException ();
		}

		void WriteXml (XmlWriter writer, bool writeRoot)
		{
			if (writer == null)
				throw new ArgumentNullException ("writer");
			if (Feed == null)
				throw new InvalidOperationException ("Syndication item must be set before writing");

			if (writeRoot)
				writer.WriteStartElement ("feed", AtomNamespace);

			if (Feed.BaseUri != null)
				writer.WriteAttributeString ("xml:base", Feed.BaseUri.ToString ());

			if (Feed.Language != null)
				writer.WriteAttributeString ("xml:lang", Feed.Language);

			// atom:feed elements MUST contain exactly one atom:title element.
			(Feed.Title ?? new TextSyndicationContent (String.Empty)).WriteTo (writer, "title", AtomNamespace);

			// atom:feed elements MUST contain exactly one atom:id element.
			writer.WriteElementString ("id", AtomNamespace, Feed.Id ?? new UniqueId ().ToString ());

			if (Feed.Copyright != null)
				Feed.Copyright.WriteTo (writer, "rights", AtomNamespace);

			// atom:feed elements MUST contain exactly one atom:updated element.
			writer.WriteStartElement ("updated", AtomNamespace);
			// FIXME: use DateTimeOffset itself once it is implemented.
			writer.WriteString (XmlConvert.ToString (Feed.LastUpdatedTime.UtcDateTime, XmlDateTimeSerializationMode.RoundtripKind));
			writer.WriteEndElement ();

			foreach (SyndicationCategory category in Feed.Categories)
				if (category != null) {
					writer.WriteStartElement ("category", AtomNamespace);
					if (category.Name != null)
						writer.WriteAttributeString ("term", category.Name);
					if (category.Label != null)
						writer.WriteAttributeString ("label", category.Label);
					if (category.Scheme != null)
						writer.WriteAttributeString ("scheme", category.Scheme);
					WriteAttributeExtensions (writer, category, Version);
					WriteElementExtensions (writer, category, Version);
					writer.WriteEndElement ();
				}

			foreach (SyndicationPerson author in Feed.Authors)
				if (author != null) {
					writer.WriteStartElement ("author", AtomNamespace);
					WriteAttributeExtensions (writer, author, Version);
					writer.WriteElementString ("name", AtomNamespace, author.Name);
					writer.WriteElementString ("uri", AtomNamespace, author.Uri);
					writer.WriteElementString ("email", AtomNamespace, author.Email);
					WriteElementExtensions (writer, author, Version);
					writer.WriteEndElement ();
				}

			foreach (SyndicationPerson contributor in Feed.Contributors) {
				if (contributor != null) {
					writer.WriteStartElement ("contributor", AtomNamespace);
					WriteAttributeExtensions (writer, contributor, Version);
					writer.WriteElementString ("name", AtomNamespace, contributor.Name);
					writer.WriteElementString ("uri", AtomNamespace, contributor.Uri);
					writer.WriteElementString ("email", AtomNamespace, contributor.Email);
					WriteElementExtensions (writer, contributor, Version);
					writer.WriteEndElement ();
				}
			}

			foreach (SyndicationLink link in Feed.Links)
				if (link != null) {
					writer.WriteStartElement ("link");
					if (link.RelationshipType != null)
						writer.WriteAttributeString ("rel", link.RelationshipType);
					if (link.MediaType != null)
						writer.WriteAttributeString ("type", link.MediaType);
					if (link.Title != null)
						writer.WriteAttributeString ("title", link.Title);
					if (link.Length != 0)
						writer.WriteAttributeString ("length", link.Length.ToString (CultureInfo.InvariantCulture));
					writer.WriteAttributeString ("href", link.Uri != null ? link.Uri.ToString () : String.Empty);
					WriteAttributeExtensions (writer, link, Version);
					WriteElementExtensions (writer, link, Version);
					writer.WriteEndElement ();
				}

			if (Feed.Description != null)
				Feed.Description.WriteTo (writer, "description", AtomNamespace);

			if (Feed.ImageUrl != null)
				writer.WriteElementString ("logo", AtomNamespace, Feed.ImageUrl.ToString ());

			if (Feed.Generator != null)
				writer.WriteElementString ("generator", AtomNamespace, Feed.Generator);

			WriteItems (writer, Feed.Items, Feed.BaseUri);

			if (writeRoot)
				writer.WriteEndElement ();
		}
	}
}
