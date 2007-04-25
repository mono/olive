//
// IdentityCard.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2007 Novell, Inc.  http://www.novell.com
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
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace Mono.ServiceModel.IdentitySelectors
{
	public class IdentityCard
	{
		public class ClaimTypeDefinition
		{
			public ClaimTypeDefinition (string uri, string tag, string description)
			{
				this.uri = uri;
				this.tag = tag;
				this.desc = description;
			}

			string uri, tag, desc;

			public string Uri {
				get { return uri; }
			}

			public string DisplayTag {
				get { return tag; }
			}

			public string Description {
				get { return desc; }
			}
		}

		public class ClaimValue
		{
			public ClaimValue (string uri, string value)
			{
				this.uri = uri;
				this.value = value;
			}

			string uri, value;

			public string Uri {
				get { return uri; }
			}
			public string Value {
				get { return value; }
			}
		}

		const string date_format = "yyyy-MM-dd'T'HH:mm:ss.FFFFFFFZ";

		byte [] certificate;

		// metadata
		string lang, id, version, name;
		Uri issuer;
		DateTime issued, expires;
		string image_mime;
		byte [] image;
		Collection<EndpointAddress> token_services =
			new Collection<EndpointAddress> ();
		Collection<Uri> supported_token_types = new Collection<Uri> ();
		Collection<ClaimTypeDefinition> supported_claim_types =
			new Collection<ClaimTypeDefinition> ();
		bool self_issued;
		byte [] hash_salt;
		DateTime last_updated;
		string issuer_id, issuer_name;
		int back_color;
		// private data
		byte [] master_key;
		Collection<ClaimValue> claim_values =
			new Collection<ClaimValue> ();

		public string Id {
			get { return id; }
		}

		public string Version {
			get { return version; }
		}

		public string Name {
			get { return name; }
		}

		public string Lang {
			get { return lang; }
		}

		public Uri Issuer {
			get { return issuer; }
		}

		public DateTime TimeIssued {
			get { return issued; }
		}

		public DateTime TimeExpires {
			get { return expires; }
		}

		public byte [] Certificate {
			get { return certificate; }
		}

		public void Load (XmlReader xmlReader)
		{
			XmlDictionaryReader reader = XmlDictionaryReader.CreateDictionaryReader (xmlReader);

			string ns = Constants.WsidNamespace;
			reader.MoveToContent ();
			reader.ReadStartElement ("RoamingStore", ns);
			reader.MoveToContent ();
			reader.ReadStartElement ("RoamingInformationCard", ns);
			reader.MoveToContent ();
			lang = reader.GetAttribute ("xml:lang");
			// metadata
			reader.ReadStartElement ("InformationCardMetaData", ns);
			reader.MoveToContent ();
			reader.ReadStartElement ("InformationCardReference", ns);
			reader.MoveToContent ();
			id = reader.ReadElementContentAsString ("CardId", ns);
			reader.MoveToContent ();
			version = reader.ReadElementContentAsString ("CardVersion", ns);
			reader.MoveToContent ();
			reader.ReadEndElement ();
			reader.MoveToContent ();
			name = reader.ReadElementContentAsString ("CardName", ns);
			reader.MoveToContent ();
			image_mime = reader.GetAttribute ("MimeType");
			image = Convert.FromBase64String (
				reader.ReadElementContentAsString ("CardImage", ns));
			reader.MoveToContent ();
			issuer = new Uri (
				reader.ReadElementContentAsString ("Issuer", ns));
			reader.MoveToContent ();
			issued = XmlConvert.ToDateTime (
				reader.ReadElementContentAsString ("TimeIssued", ns), XmlDateTimeSerializationMode.Utc);
			reader.MoveToContent ();
			expires = XmlConvert.ToDateTime (
				reader.ReadElementContentAsString ("TimeExpires", ns), XmlDateTimeSerializationMode.Utc);
			reader.MoveToContent ();
			if (reader.IsStartElement ("TokenServiceList", ns)) {
				reader.ReadStartElement ("TokenServiceList", ns);
				reader.MoveToContent ();
				for (reader.MoveToContent ();
				     reader.NodeType == XmlNodeType.Element;
				     reader.MoveToContent ()) {
					reader.ReadStartElement ("TokenService", ns);
					reader.MoveToContent ();
					token_services.Add (EndpointAddress.ReadFrom (reader));
					reader.MoveToContent ();
					reader.ReadEndElement ();
				}
				reader.ReadEndElement ();
			}

			reader.MoveToContent ();
			reader.ReadStartElement ("SupportedTokenTypeList", ns);
			for (reader.MoveToContent ();
			     reader.NodeType == XmlNodeType.Element;
			     reader.MoveToContent ())
				supported_token_types.Add (new Uri (
					reader.ReadElementContentAsString ("TokenType", Constants.WstNamespace)));
			reader.ReadEndElement ();

			reader.MoveToContent ();
			reader.ReadStartElement ("SupportedClaimTypeList", ns);
			for (reader.MoveToContent ();
			     reader.NodeType == XmlNodeType.Element;
			     reader.MoveToContent ()) {
				string uri = reader.GetAttribute ("Uri");
				reader.ReadStartElement ("SupportedClaimType", ns);
				string tag = reader.ReadElementContentAsString ("DisplayTag", ns);
				reader.MoveToContent ();
				string desc = reader.ReadElementContentAsString ("Description", ns);
				reader.MoveToContent ();
				reader.ReadEndElement ();
				supported_claim_types.Add (new ClaimTypeDefinition (uri, tag, desc));
			}
			reader.ReadEndElement ();

			reader.MoveToContent ();
			self_issued = reader.ReadElementContentAsBoolean ("IsSelfIssued", ns);
			reader.MoveToContent ();
			hash_salt = Convert.FromBase64String (
				reader.ReadElementContentAsString ("HashSalt", ns));
			reader.MoveToContent ();
			last_updated = XmlConvert.ToDateTime (
				reader.ReadElementContentAsString ("TimeLastUpdated", ns), XmlDateTimeSerializationMode.Utc);
			reader.MoveToContent ();
			issuer_id = reader.ReadElementContentAsString ("IssuerId", ns);
			reader.MoveToContent ();
			issuer_name = reader.ReadElementContentAsString ("IssuerName", ns);
			reader.MoveToContent ();
			back_color = reader.ReadElementContentAsInt ("BackgroundColor", ns);

			reader.MoveToContent ();
			reader.ReadEndElement (); // InformationCardMetaData

			// private data
			reader.MoveToContent ();
			reader.ReadStartElement ("InformationCardPrivateData", ns);
			reader.MoveToContent ();
			master_key = Convert.FromBase64String (
				reader.ReadElementContentAsString ("MasterKey", ns));
			reader.MoveToContent ();
			if (reader.IsStartElement ("ClaimValueList", ns)) {
				reader.ReadStartElement ("ClaimValueList", ns);

				reader.MoveToContent ();
				for (reader.MoveToContent ();
				     reader.NodeType == XmlNodeType.Element;
				     reader.MoveToContent ()) {
					string uri = reader.GetAttribute ("Uri");
					reader.ReadStartElement ("ClaimValue", ns);
					reader.MoveToContent ();
					string value = reader.ReadElementContentAsString ("Value", ns);
					reader.MoveToContent ();
					reader.ReadEndElement ();
					claim_values.Add (new ClaimValue (uri, value));
				}
				reader.ReadEndElement ();
				reader.MoveToContent ();
			}

			reader.ReadEndElement (); // InformationCardPrivateData

			reader.MoveToContent ();
			reader.ReadEndElement ();
			reader.MoveToContent ();
			reader.ReadEndElement ();
		}

		public void Save (XmlWriter xmlWriter)
		{
			XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter (xmlWriter);

			string ns = Constants.WsidNamespace;
			writer.WriteStartElement ("RoamingStore", ns);
			writer.WriteStartElement ("RoamingInformationCard", ns);
			// metadata
			writer.WriteStartElement ("InformationCardMetaData", ns);
			writer.WriteAttributeString ("xml:lang", lang);
			writer.WriteStartElement ("InformationCardReference", ns);
			writer.WriteElementString ("CardId", ns, id);
			writer.WriteElementString ("CardVersion", ns, version);
			writer.WriteEndElement ();
			writer.WriteElementString ("CardName", ns, name);
			writer.WriteStartElement ("CardImage", ns);
			writer.WriteAttributeString ("MimeType", image_mime);
			writer.WriteString (Convert.ToBase64String (image));
			writer.WriteEndElement ();
			writer.WriteElementString ("Issuer", ns, issuer.ToString ());
			writer.WriteElementString ("TimeIssued", ns, XmlConvert.ToString (issued, date_format));
			writer.WriteElementString ("TimeExpires", ns, XmlConvert.ToString (expires, date_format));
			if (token_services.Count > 0) {
				
				writer.WriteStartElement ("TokenServiceList", ns);
				foreach (EndpointAddress ea in token_services) {
					writer.WriteStartElement ("TokenService", ns);
					// FIXME: do we need different ones?
					ea.WriteTo (AddressingVersion.WSAddressing10, writer);
					writer.WriteEndElement ();
				}
				writer.WriteEndElement ();
			}

			writer.WriteStartElement ("SupportedTokenTypeList", ns);
			foreach (Uri u in supported_token_types)
				writer.WriteElementString ("TokenType", Constants.WstNamespace, u.ToString ());
			writer.WriteEndElement ();

			writer.WriteStartElement ("SupportedClaimTypeList", ns);
			foreach (ClaimTypeDefinition cd in supported_claim_types) {
				writer.WriteStartElement ("SupportedClaimType", ns);
				writer.WriteAttributeString ("Uri", cd.Uri);
				writer.WriteElementString ("DisplayTag", ns, cd.DisplayTag);
				writer.WriteElementString ("Description", ns, cd.Description);
				writer.WriteEndElement ();
			}
			writer.WriteEndElement ();

			writer.WriteStartElement ("IsSelfIssued", ns);
			writer.WriteString (XmlConvert.ToString (self_issued));
			writer.WriteEndElement ();
			writer.WriteStartElement ("HashSalt", ns);
			writer.WriteString (Convert.ToBase64String (hash_salt));
			writer.WriteEndElement ();
			writer.WriteElementString ("TimeLastUpdated", ns, XmlConvert.ToString (last_updated, XmlDateTimeSerializationMode.Utc));
			writer.WriteElementString ("IssuerId", ns, issuer_id);
			writer.WriteElementString ("IssuerName", ns, issuer_name);
			writer.WriteElementString ("BackgroundColor", ns, XmlConvert.ToString (back_color));

			writer.WriteEndElement (); // InformationCardMetaData

			// private data
			writer.WriteStartElement ("InformationCardPrivateData", ns);
			writer.WriteElementString ("MasterKey", ns, Convert.ToBase64String (master_key));
			if (claim_values.Count > 0) {
				writer.WriteStartElement ("ClaimValueList", ns);
				foreach (ClaimValue cv in claim_values) {
					writer.WriteStartElement ("ClaimValue", ns);
					writer.WriteAttributeString ("Uri", cv.Uri);
					writer.WriteElementString ("Value", ns, cv.Value);
					writer.WriteEndElement ();
				}
				writer.WriteEndElement ();
			}

			writer.WriteEndElement (); // InformationCardPrivateData

			writer.WriteEndElement ();
			writer.WriteEndElement ();
		}
	}
}
