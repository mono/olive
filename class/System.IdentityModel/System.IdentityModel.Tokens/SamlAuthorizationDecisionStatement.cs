//
// SamlAuthorizationDecisionStatement.cs
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
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;

namespace System.IdentityModel.Tokens
{
	public class SamlAuthorizationDecisionStatement : SamlSubjectStatement
	{
		public static string ClaimType {
			get { return "http://schemas.microsoft.com/mb/2005/09/ClaimType/SamlAuthorizationDecision"; }
		}

		public SamlAuthorizationDecisionStatement ()
		{
		}

		public SamlAuthorizationDecisionStatement (
			SamlSubject samlSubject, string resource,
			SamlAccessDecision accessDecision,
			IEnumerable<SamlAction> samlActions)
			: this (samlSubject, resource, accessDecision, samlActions, null)
		{
		}

		public SamlAuthorizationDecisionStatement (
			SamlSubject samlSubject, string resource,
			SamlAccessDecision accessDecision,
			IEnumerable<SamlAction> samlActions,
			SamlEvidence samlEvidence)
			: base (samlSubject)
		{
			this.resource = resource;
			this.access_decision = accessDecision;
			foreach (SamlAction a in samlActions)
				actions.Add (a);
			evidence = samlEvidence;
		}

		SamlAccessDecision access_decision;
		SamlEvidence evidence;
		string resource;
		List<SamlAction> actions = new List<SamlAction> ();

		public IList<SamlAction> SamlActions {
			get { return actions; }
		}

		public SamlAccessDecision AccessDecision {
			get { return access_decision; }
			set {
				CheckReadOnly ();
				access_decision = value;
			}
		}

		public SamlEvidence Evidence {
			get { return evidence; }
			set {
				CheckReadOnly ();
				evidence = value;
			}
		}

		public string Resource {
			get { return resource; }
			set {
				CheckReadOnly ();
				resource = value;
			}
		}

		public override bool IsReadOnly {
			get { return base.IsReadOnly; }
		}

		private void CheckReadOnly ()
		{
			if (IsReadOnly)
				throw new InvalidOperationException ("This SAML assertion is read-only.");
		}

		public override void MakeReadOnly ()
		{
			base.MakeReadOnly ();
		}

		[MonoTODO]
		protected override void AddClaimsToList (IList<Claim> claims)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void ReadXml (XmlDictionaryReader reader,
			SamlSerializer samlSerializer, 
			SecurityTokenSerializer keyInfoSerializer, 
			SecurityTokenResolver resolver)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void WriteXml (XmlDictionaryWriter writer,
			SamlSerializer samlSerializer, 
			SecurityTokenSerializer keyInfoSerializer)
		{
			throw new NotImplementedException ();
		}

	}
}
