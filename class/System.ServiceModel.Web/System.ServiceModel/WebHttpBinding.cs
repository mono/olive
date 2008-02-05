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
