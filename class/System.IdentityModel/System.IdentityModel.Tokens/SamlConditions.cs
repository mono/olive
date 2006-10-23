//
// SamlConditions.cs
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
using System;
using System.Collections.Generic;
using System.Xml;
using System.IdentityModel.Policy;
using System.IdentityModel.Selectors;
using System.Security.Cryptography;

namespace System.IdentityModel.Tokens
{
	public class SamlConditions
	{
		DateTime not_before, not_on_after;
		bool is_readonly;
		List<SamlCondition> conditions = new List<SamlCondition> ();

		[MonoTODO]
		public SamlConditions ()
		{
			throw new NotImplementedException ();
		}

		public SamlConditions (DateTime notBefore, DateTime notOnOrAfter)
		{
			this.not_before = notBefore;
			this.not_on_after = notOnOrAfter;
		}

		public SamlConditions (DateTime notBefore, DateTime notOnOrAfter,
			IEnumerable<SamlCondition> conditions)
			: this (notBefore, notOnOrAfter)
		{
			if (conditions == null)
				throw new ArgumentNullException ("conditions");
			foreach (SamlCondition cond in conditions)
				this.conditions.Add (cond);
		}

		public IList<SamlCondition> Conditions {
			get { return conditions; }
		}

		[MonoTODO]
		public DateTime NotBefore {
			get { return not_before; }
			set { not_before = value; }
		}

		[MonoTODO]
		public DateTime NotOnOrAfter {
			get { return not_on_after; }
			set { not_on_after = value; }
		}

		public bool IsReadOnly {
			get { return is_readonly; }
		}

		public void MakeReadOnly ()
		{
			is_readonly = true;
		}

		[MonoTODO]
		public virtual void ReadXml (XmlDictionaryReader reader,
			SamlSerializer samlSerializer,
			SecurityTokenSerializer keyInfoTokenSerializer,
			SecurityTokenResolver outOfBandTokenResolver)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual void WriteXml (XmlDictionaryWriter writer,
			SamlSerializer samlSerializer,
			SecurityTokenSerializer keyInfoTokenSerializer)
		{
			throw new NotImplementedException ();
		}
	}
}
