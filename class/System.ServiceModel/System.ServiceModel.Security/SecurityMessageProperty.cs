//
// SecurityMessageProperty.cs
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
using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;

namespace System.ServiceModel.Security
{
	public class SecurityMessageProperty : IMessageProperty
	{
		SecurityTokenSpecification initiator_token, protection_token,
			recipient_token, transport_token;
		string sender_id_prefix;
		ServiceSecurityContext context;

		public SecurityMessageProperty ()
		{
		}

		[MonoTODO]
		public bool HasIncomingSupportingTokens {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public ReadOnlyCollection<IAuthorizationPolicy>
			ExternalAuthorizationPolicies {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public Collection<SupportingTokenSpecification>
			IncomingSupportingTokens {
			get { throw new NotImplementedException (); }
		}

		public SecurityTokenSpecification InitiatorToken {
			get { return initiator_token; }
			set { initiator_token = value; }
		}

		public SecurityTokenSpecification ProtectionToken {
			get { return protection_token; }
			set { protection_token = value; }
		}

		public SecurityTokenSpecification RecipientToken {
			get { return recipient_token; }
			set { recipient_token = value; }
		}

		public SecurityTokenSpecification TransportToken {
			get { return transport_token; }
			set { transport_token = value; }
		}

		public string SenderIdPrefix {
			get { return sender_id_prefix; }
			set { sender_id_prefix = value; }
		}

		public ServiceSecurityContext ServiceSecurityContext {
			get { return context; }
			set { context = value; }
		}

		public IMessageProperty CreateCopy ()
		{
			return (SecurityMessageProperty) MemberwiseClone ();
		}

		[MonoTODO]
		public static SecurityMessageProperty GetOrCreate (Message message)
		{
			throw new NotImplementedException ();
		}
	}
}
