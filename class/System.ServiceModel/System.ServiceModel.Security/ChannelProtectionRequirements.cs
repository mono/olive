//
// ChannelProtectionRequirements.cs
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
using System.ServiceModel;

namespace System.ServiceModel.Security
{
	public class ChannelProtectionRequirements
	{
		bool is_readonly;
		ScopedMessagePartSpecification in_enc, in_sign, out_enc, out_sign;

		public ChannelProtectionRequirements ()
		{
			in_enc = new ScopedMessagePartSpecification ();
			out_enc = new ScopedMessagePartSpecification ();
			in_sign = new ScopedMessagePartSpecification ();
			out_sign = new ScopedMessagePartSpecification ();
		}

		public ChannelProtectionRequirements (
			ChannelProtectionRequirements other)
		{
			in_enc = new ScopedMessagePartSpecification (other.in_enc);
			out_enc = new ScopedMessagePartSpecification (other.out_enc);
			in_sign = new ScopedMessagePartSpecification (other.in_sign);
			out_sign = new ScopedMessagePartSpecification (other.out_sign);
		}

		public bool IsReadOnly {
			get { return is_readonly; }
		}

		public ScopedMessagePartSpecification IncomingEncryptionParts {
			get { return in_enc; }
		}

		public ScopedMessagePartSpecification IncomingSignatureParts {
			get { return in_sign; }
		}

		public ScopedMessagePartSpecification OutgoingEncryptionParts {
			get { return out_enc; }
		}

		public ScopedMessagePartSpecification OutgoingSignatureParts {
			get { return out_sign; }
		}

		public void Add (
			ChannelProtectionRequirements protectionRequirements)
		{
			Add (protectionRequirements, false);
		}

		[MonoTODO]
		public void Add (
			ChannelProtectionRequirements protectionRequirements,
			bool channelScopeOnly)
		{
			if (is_readonly)
				throw new InvalidOperationException ("This ChannelProtectionRequirements is read-only.");
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public ChannelProtectionRequirements CreateInverse ()
		{
			throw new NotImplementedException ();
		}

		public void MakeReadOnly ()
		{
			is_readonly = true;
		}
	}
}
