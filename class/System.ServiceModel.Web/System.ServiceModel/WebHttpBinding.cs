//
// WebHttpBinding.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
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
using System.Text;
using System.Xml;

namespace System.ServiceModel
{
	[MonoTODO]
	public class WebHttpBinding : Binding
	{
		[MonoTODO]
		public WebHttpBinding ()
		{
		}

		[MonoTODO]
		public WebHttpBinding (WebHttpSecurityMode mode)
		{
			security.Mode = mode;
		}

		[MonoTODO]
		public WebHttpBinding (string configurationName)
		{
		}

		XmlDictionaryReaderQuotas quotas;
		WebHttpSecurity security = new WebHttpSecurity ();
		Encoding write_encoding = Encoding.UTF8;

		HttpTransportBindingElement t = new HttpTransportBindingElement ();

		public bool AllowCookies {
			get { return t.AllowCookies; }
			set { t.AllowCookies = value; }
		}

		public bool BypassProxyOnLocal {
			get { return t.BypassProxyOnLocal; }
			set { t.BypassProxyOnLocal = value; }
		}

		public EnvelopeVersion EnvelopeVersion {
			get { return EnvelopeVersion.None; }
		}

		public HostNameComparisonMode HostNameComparisonMode {
			get { return t.HostNameComparisonMode; }
			set { t.HostNameComparisonMode = value; }
		}

		public long MaxBufferPoolSize {
			get { return t.MaxBufferPoolSize; }
			set { t.MaxBufferPoolSize = value; }
		}

		public int MaxBufferSize {
			get { return t.MaxBufferSize; }
			set { t.MaxBufferSize = value; }
		}

		public long MaxReceivedMessageSize {
			get { return t.MaxReceivedMessageSize; }
			set { t.MaxReceivedMessageSize = value; }
		}

		public Uri ProxyAddress {
			get { return t.ProxyAddress; }
			set { t.ProxyAddress = value; }
		}

		public XmlDictionaryReaderQuotas ReaderQuotas {
			get { return quotas; }
			set { quotas = value; }
		}

		public override string Scheme {
			get { return Uri.UriSchemeHttp; }
		}

		[MonoTODO]
		public WebHttpSecurity Security {
			get { return security; }
		}

		public TransferMode TransferMode {
			get { return t.TransferMode; }
			set { t.TransferMode = value; }
		}

		public bool UseDefaultWebProxy {
			get { return t.UseDefaultWebProxy; }
			set { t.UseDefaultWebProxy = value; }
		}

		public Encoding WriteEncoding {
			get { return write_encoding; }
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				write_encoding = value; 
			}
		}

		[MonoTODO]
		public override BindingElementCollection CreateBindingElements ()
		{
			// FIXME: apply Security

			WebMessageEncodingBindingElement m = new WebMessageEncodingBindingElement (WriteEncoding);
			if (ReaderQuotas != null)
				ReaderQuotas.CopyTo (m.ReaderQuotas);

			return new BindingElementCollection (m, t.Clone ());
		}
	}
}
