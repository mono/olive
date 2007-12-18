//
// Atom10ItemFormatter.cs
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

//
// WARNING:
// This class is not for outputting ATOM 1.0 conformant XML. For example
// it does not report errors with related to the following constraints:

// - atom:entry elements MUST NOT contain more than one atom:link
//   element with a rel attribute value of "alternate" that has the
//   same combination of type and hreflang attribute values.
// - atom:entry elements that contain no child atom:content element
//   MUST contain at least one atom:link element with a rel attribute
//   value of "alternate".
//

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
	[XmlRoot ("entry", Namespace = "http://www.w3.org/2005/Atom")]
	public class Atom10ItemFormatter : SyndicationItemFormatter, IXmlSerializable
	{
		const string AtomNamespace ="http://www.w3.org/2005/Atom";

		bool preserve_att_ext = true, preserve_elem_ext = true;
		Type item_type;

		public Atom10ItemFormatter ()
		{
		}

		public Atom10ItemFormatter (SyndicationItem feedToWrite)
			: base (feedToWrite)
		{
		}

		public Atom10ItemFormatter (Type itemTypeToCreate)
		{
			if (itemTypeToCreate == null)
				throw new ArgumentNullException ("itemTypeToCreate");
			item_type = itemTypeToCreate;
		}

		protected Type ItemType {
			get { return item_type; }
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

		protected override SyndicationItem CreateItemInstance ()
		{
			return new SyndicationItem ();
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
			if (Item == null)
				throw new InvalidOperationException ("Syndication item must be set before writing");

			if (writeRoot)
				writer.WriteStartElement ("entry", AtomNamespace);

			if (Item.BaseUri != null)
				writer.WriteAttributeString ("xml:base", Item.BaseUri.ToString ());

			// atom:entry elements MUST contain exactly one atom:id element.
			writer.WriteElementString ("id", AtomNamespace, Item.Id ?? new UniqueId ().ToString ());

			// atom:entry elements MUST contain exactly one atom:title element.
			(Item.Title ?? new TextSyndicationContent (String.Empty)).WriteTo (writer, "title", AtomNamespace);

			if (Item.Summary != null)
				Item.Summary.WriteTo (writer, "summary", AtomNamespace);

			if (!Item.PublishDate.Equals (default (DateTimeOffset))) {
				writer.WriteStartElement ("published");
				// FIXME: use DateTimeOffset itself once it is implemented.
				writer.WriteString (XmlConvert.ToString (Item.PublishDate.UtcDateTime, XmlDateTimeSerializationMode.RoundtripKind));
				writer.WriteEndElement ();
			}

			// atom:entry elements MUST contain exactly one atom:updated element.
			writer.WriteStartElement ("updated", AtomNamespace);
			// FIXME: use DateTimeOffset itself once it is implemented.
			writer.WriteString (XmlConvert.ToString (Item.LastUpdatedTime.UtcDateTime, XmlDateTimeSerializationMode.RoundtripKind));
			writer.WriteEndElement ();

			foreach (SyndicationPerson author in Item.Authors)
				if (author != null) {
					writer.WriteStartElement ("author", AtomNamespace);
					WriteAttributeExtensions (writer, author, Version);
					writer.WriteElementString ("name", AtomNamespace, author.Name);
					writer.WriteElementString ("uri", AtomNamespace, author.Uri);
					writer.WriteElementString ("email", AtomNamespace, author.Email);
					WriteElementExtensions (writer, author, Version);
					writer.WriteEndElement ();
				}

			foreach (SyndicationPerson contributor in Item.Contributors) {
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

			foreach (SyndicationCategory category in Item.Categories)
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

			foreach (SyndicationLink link in Item.Links)
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

			if (Item.Content != null)
				Item.Content.WriteTo (writer, "content", AtomNamespace);

			if (Item.Copyright != null)
				Item.Copyright.WriteTo (writer, "rights", AtomNamespace);

			if (Item.SourceFeed != null) {
				writer.WriteStartElement ("source", AtomNamespace);
				Item.SourceFeed.SaveAsAtom10 (writer);
				writer.WriteEndElement ();
			}

			if (writeRoot)
				writer.WriteEndElement ();
		}
	}
}
