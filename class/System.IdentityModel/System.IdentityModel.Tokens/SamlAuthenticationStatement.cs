//
// SamlAuthenticationStatement.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005 Novell, Inc.  http://www.novell.com
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
using System.Xml;
using System.IdentityModel.Claims;
using System.IdentityModel.Selectors;

namespace System.IdentityModel.Tokens
{
	public class SamlAuthenticationStatement : SamlSubjectStatement
	{
		public static string ClaimType {
			get { return "http://schemas.microsoft.com/mb/2005/09/ClaimType/SamlAuthentication"; }
		}

		bool is_readonly;
		string auth_method, dns, ip;
		new IList<SamlAuthorityBinding> bindings;
		DateTime instant;

		public SamlAuthenticationStatement ()
		{
			bindings = new List<SamlAuthorityBinding> ();
		}

		public SamlAuthenticationStatement (SamlSubject samlSubject,
			string authenticationMethod,
			DateTime authenticationInstant,
			string dnsAddress, string ipAddress,
			IEnumerable<SamlAuthorityBinding> authorityBindings)
		{
			auth_method = authenticationMethod;
			instant = authenticationInstant;
			dns = dnsAddress;
			ip = ipAddress;
			bindings = new List<SamlAuthorityBinding> (authorityBindings);
		}

		public DateTime AuthenticationInstant {
			get { return instant; }
			set {
				CheckReadOnly ();
				instant = value;
			}
		}

		public string AuthenticationMethod {
			get { return auth_method; }
			set {
				CheckReadOnly ();
				auth_method = value;
			}
		}

		public IList<SamlAuthorityBinding> AuthorityBindings {
			get { return bindings; }
		}

		public string DnsAddress {
			get { return dns; }
			set {
				CheckReadOnly ();
				dns = value;
			}
		}

		public string IPAddress {
			get { return ip; }
			set {
				CheckReadOnly ();
				ip= value;
			}
		}

		public override bool IsReadOnly {
			get { return is_readonly; }
		}

		private void CheckReadOnly ()
		{
			if (is_readonly)
				throw new InvalidOperationException ("This SAML assertion is read-only.");
		}

		public override void MakeReadOnly ()
		{
			is_readonly = true;
		}

		[MonoTODO]
		public override void ReadXml (XmlDictionaryReader reader,
			SamlSerializer samlSerializer,
			SecurityTokenSerializer keyInfoTokenSerializer,
			SecurityTokenResolver outOfBandTokenResolver)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void WriteXml (XmlDictionaryWriter writer,
			SamlSerializer samlSerializer,
			SecurityTokenSerializer keyInfoTokenSerializer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override void AddClaimsToList (IList<Claim> claims)
		{
			throw new NotImplementedException ();
		}
	}
}
