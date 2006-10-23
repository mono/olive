//
// SamlSubject.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.  http://www.novell.com
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.IdentityModel.Claims;
using System.IdentityModel.Selectors;
using System.Xml;

namespace System.IdentityModel.Tokens
{
	[MonoTODO]
	public class SamlSubject
	{
		public static string NameClaimType {
			get { return ClaimTypes.Name; }
		}

		bool is_readonly;
		string name_format, name_qualifier, name;
		SecurityKey crypto;
		SecurityKeyIdentifier key_identifier;
		List<string> confirmation_methods = new List<string> ();
		string confirmation_data;

		public SamlSubject ()
		{
		}

		public SamlSubject (string nameFormat, string nameQualifier, string name)
		{
			name_format = nameFormat;
			name_qualifier = nameQualifier;
			this.name = name;
		}

		public bool IsReadOnly {
			get { return is_readonly; }
		}

		public string NameFormat {
			get { return name_format; }
			set {
				CheckReadOnly ();
				name_format = value;
			}
		}

		public string NameQualifier {
			get { return name_qualifier; }
			set {
				CheckReadOnly ();
				name_qualifier = value;
			}
		}

		public string Name {
			get { return name; }
			set {
				CheckReadOnly ();
				name = value;
			}
		}

		public IList<string> ConfirmationMethods {
			get { return confirmation_methods; }
		}

		public string SubjectConfirmationData {
			get { return confirmation_data; }
			set {
				CheckReadOnly ();
				confirmation_data = value;
			}
		}

		public SecurityKey Crypto {
			get { return crypto; }
			set {
				CheckReadOnly ();
				crypto = value;
			}
		}

		public SecurityKeyIdentifier KeyIdentifier {
			get { return key_identifier; }
			set {
				CheckReadOnly ();
				key_identifier = value;
			}
		}

		private void CheckReadOnly ()
		{
			if (is_readonly)
				throw new InvalidOperationException ("This SAML subject is read-only.");
		}

		public void MakeReadOnly ()
		{
			is_readonly = true;
		}

		[MonoTODO]
		public virtual ReadOnlyCollection<Claim> ExtractClaims ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual ClaimSet ExtractSubjectKeyClaimSet (
			SamlSecurityTokenAuthenticator samlAuthenticator)
		{
			throw new NotImplementedException ();
		}


		[MonoTODO]
		public virtual void ReadXml (XmlDictionaryReader reader,
			SamlSerializer samlSerializer,
			SecurityTokenSerializer keyInfoTokenSerializer,
			SecurityTokenResolver outOfBandTokenResolver)
		{
			throw new NotImplementedException ();
		}

		public virtual void WriteXml (XmlDictionaryWriter writer,
			SamlSerializer samlSerializer,
			SecurityTokenSerializer keyInfoTokenSerializer)
		{
			writer.WriteStartElement ("saml", "Subject", SamlConstants.Namespace);
			writer.WriteStartElement ("saml", "NameIdentifier", SamlConstants.Namespace);
			writer.WriteAttributeString ("Format", NameFormat);
			writer.WriteAttributeString ("NameQualifier", NameQualifier);
			writer.WriteString (Name);
			writer.WriteEndElement ();
			writer.WriteEndElement ();
		}
	}
}
