//
// Rss20ItemFormatter.cs
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
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.ServiceModel.Syndication
{
	[XmlRoot ("item", Namespace = "")]
	public class Rss20ItemFormatter : SyndicationItemFormatter, IXmlSerializable
	{
		const string AtomNamespace ="http://www.w3.org/2005/Atom";

		bool ext_atom_serialization, preserve_att_ext, preserve_elem_ext;
		Type item_type;

		public Rss20ItemFormatter ()
		{
			ext_atom_serialization = true;
		}

		public Rss20ItemFormatter (SyndicationItem feedToWrite)
			: this (feedToWrite, true)
		{
		}

		public Rss20ItemFormatter (SyndicationItem feedToWrite, bool serializeExtensionsAsAtom)
			: base (feedToWrite)
		{
			ext_atom_serialization = serializeExtensionsAsAtom;
		}

		public Rss20ItemFormatter (Type itemTypeToCreate)
		{
			if (itemTypeToCreate == null)
				throw new ArgumentNullException ("itemTypeToCreate");
			item_type = itemTypeToCreate;
		}

		public bool SerializeExtensionsAsAtom {
			get { return ext_atom_serialization; }
			set { ext_atom_serialization = value; }
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
			get { return "Rss20"; }
		}

		[MonoTODO]
		protected override SyndicationItem CreateItemInstance ()
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

		// FIXME: output every non-ISyndicationElement properties (id, pubDate, etc.)
		void WriteXml (XmlWriter writer, bool writeRoot)
		{
			if (writer == null)
				throw new ArgumentNullException ("writer");
			if (Item == null)
				throw new InvalidOperationException ("Syndication item must be set before writing");

			if (writeRoot)
				writer.WriteStartElement ("item");

			if (Item.Title != null) {
				writer.WriteStartElement ("title");
				writer.WriteString (Item.Title.Text);
				writer.WriteEndElement ();
			}

			foreach (SyndicationPerson author in Item.Authors)
				if (author != null) {
					writer.WriteStartElement ("author");
					WriteAttributeExtensions (writer, author, Version);
					writer.WriteString (author.Email);
					WriteElementExtensions (writer, author, Version);
					writer.WriteEndElement ();
				}
			foreach (SyndicationCategory category in Item.Categories)
				if (category != null) {
					writer.WriteStartElement ("category");
					if (category.Scheme != null)
						writer.WriteAttributeString ("domain", category.Scheme);
					WriteAttributeExtensions (writer, category, Version);
					writer.WriteString (category.Name);
					WriteElementExtensions (writer, category, Version);
					writer.WriteEndElement ();
				}
			if (Item.Summary != null)
				Item.Summary.WriteTo (writer, "description", String.Empty);
			else if (Item.Title == null) { // according to the RSS 2.0 spec, either of title or description must exist.
				writer.WriteStartElement ("description");
				writer.WriteEndElement ();
			}
			// FIXME; what to do for Contributors?
			foreach (SyndicationLink link in Item.Links)
				if (link != null) {
					writer.WriteStartElement ("link");
					WriteAttributeExtensions (writer, link, Version);
					writer.WriteString (link.Uri != null ? link.Uri.ToString () : String.Empty);
					WriteElementExtensions (writer, link, Version);
					writer.WriteEndElement ();
				}

			// Contributors are part of Atom extension
			if (SerializeExtensionsAsAtom)
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

			if (writeRoot)
				writer.WriteEndElement ();
		}
	}
}
