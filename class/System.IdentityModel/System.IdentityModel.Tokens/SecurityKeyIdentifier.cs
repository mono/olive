//
// SecurityKeyIdentifier.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005-2006 Novell, Inc.  http://www.novell.com
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
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IdentityModel.Policy;

namespace System.IdentityModel.Tokens
{
	public class SecurityKeyIdentifier
		: IEnumerable<SecurityKeyIdentifierClause>, IEnumerable
	{
		public SecurityKeyIdentifier ()
		{
			this.list = new List<SecurityKeyIdentifierClause> ();
		}

		public SecurityKeyIdentifier (params SecurityKeyIdentifierClause [] identifiers)
		{
			this.list = new List<SecurityKeyIdentifierClause> (identifiers);
		}

		List<SecurityKeyIdentifierClause> list;
		bool is_readonly;

		[MonoTODO]
		public bool CanCreateKey {
			get { throw new NotImplementedException (); }
		}

		public int Count {
			get { return list.Count; }
		}

		[MonoTODO]
		public bool IsReadOnly {
			get { return is_readonly; }
		}

		public SecurityKeyIdentifierClause this [int i] {
			get { return list [i]; }
		}

		[MonoTODO]
		public void Add (SecurityKeyIdentifierClause item)
		{
			if (is_readonly)
				throw new InvalidOperationException ("This SecurityKeyIdentifier is read-only.");
			list.Add (item);
		}

		[MonoTODO]
		public SecurityKey CreateKey ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public TClause Find<TClause> ()
			where TClause : SecurityKeyIdentifierClause
		{
			throw new NotImplementedException ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}

		[MonoTODO]
		public IEnumerator<SecurityKeyIdentifierClause> GetEnumerator ()
		{
			return list.GetEnumerator ();
		}

		[MonoTODO]
		public void MakeReadOnly ()
		{
			is_readonly = true;
		}

		[MonoTODO]
		public override string ToString ()
		{
			return base.ToString ();
		}

		[MonoTODO]
		public bool TryFind<TClause> (out TClause result)
			where TClause : SecurityKeyIdentifierClause
		{
			throw new NotImplementedException ();
		}
	}
}
