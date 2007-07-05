//
// NetMsmqBinding.cs
//
// Author: Atsushi Enomoto  <atsushi@ximian.com>
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
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;

namespace System.ServiceModel
{
	public class NetMsmqBinding : MsmqBindingBase
	{
		NetMsmqSecurity security;
		bool use_ad;
		long max_buffer_pool_size;
		QueueTransferProtocol queue_tr_protocol;
		XmlDictionaryReaderQuotas quotas;
		EnvelopeVersion envelope_version = EnvelopeVersion.Soap12;

		public NetMsmqBinding ()
			: this (NetMsmqSecurityMode.None)
		{
		}

		public NetMsmqBinding (NetMsmqSecurityMode securityMode)
		{
			security = new NetMsmqSecurity (securityMode);
		}

		[MonoTODO]
		public NetMsmqBinding (string configurationName)
		{
			throw new NotImplementedException ();
		}

		public NetMsmqSecurity Security {
			get { return security; }
		}

		public EnvelopeVersion EnvelopeVersion {
			get { return envelope_version; }
		}

		public long MaxBufferPoolSize {
			get { return max_buffer_pool_size; }
			set { max_buffer_pool_size = value; }
		}

		public QueueTransferProtocol QueueTransferProtocol {
			get { return queue_tr_protocol; }
			set { queue_tr_protocol = value; }
		}

		public XmlDictionaryReaderQuotas ReaderQuotas {
			get { return quotas; }
			set { quotas = value; }
		}

		public bool UseActiveDirectory {
			get { return use_ad; }
			set { use_ad = value; }
		}

		[MonoTODO]
		public override BindingElementCollection CreateBindingElements ()
		{
			throw new NotImplementedException ();
		}
	}
}
