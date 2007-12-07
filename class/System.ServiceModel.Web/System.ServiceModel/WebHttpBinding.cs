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

		int max_buffer_size = 0x40000;
		long max_buffer_pool_size = 0x10000,
		     max_received_msg_size = 0x40000;
		Uri proxy_address;
		XmlDictionaryReaderQuotas quotas;
		WebHttpSecurity security = new WebHttpSecurity ();
		TransferMode transfer_mode;
		bool allow_cookies, bypass_proxy_on_local,
		     use_default_web_proxy;
		Encoding write_encoding;
		HostNameComparisonMode cmp_mode;

		[MonoTODO]
		public bool AllowCookies {
			get { return allow_cookies; }
			set { allow_cookies = value; }
		}

		[MonoTODO]
		public bool BypassProxyOnLocal {
			get { return bypass_proxy_on_local; }
			set { bypass_proxy_on_local = value; }
		}

		[MonoTODO]
		public EnvelopeVersion EnvelopeVersion {
			get { return EnvelopeVersion.Soap12; }
		}

		[MonoTODO]
		public HostNameComparisonMode HostNameComparisonMode {
			get { return cmp_mode; }
			set { cmp_mode = value; }
		}

		[MonoTODO]
		public long MaxBufferPoolSize {
			get { return max_buffer_pool_size; }
			set { max_buffer_pool_size = value; }
		}

		[MonoTODO]
		public int MaxBufferSize {
			get { return max_buffer_size; }
			set { max_buffer_size = value; }
		}

		[MonoTODO]
		public long MaxReceivedMessageSize {
			get { return max_received_msg_size; }
			set { max_received_msg_size = value; }
		}

		[MonoTODO]
		public Uri ProxyAddress {
			get { return proxy_address; }
			set { proxy_address = value; }
		}

		[MonoTODO]
		public XmlDictionaryReaderQuotas ReaderQuotas {
			get { return quotas; }
			set { quotas = value; }
		}

		[MonoTODO]
		public override string Scheme {
			get { return Uri.UriSchemeHttp; }
		}

		[MonoTODO]
		public WebHttpSecurity Security {
			get { return security; }
		}

		[MonoTODO]
		public TransferMode TransferMode {
			get { return transfer_mode; }
			set { transfer_mode = value; }
		}

		[MonoTODO]
		public bool UseDefaultWebProxy {
			get { return use_default_web_proxy; }
			set { use_default_web_proxy = value; }
		}

		[MonoTODO]
		public Encoding WriteEncoding {
			get { return write_encoding; }
			set { write_encoding = value; }
		}

		[MonoTODO]
		public override BindingElementCollection CreateBindingElements ()
		{
			throw new NotImplementedException ();
		}
	}
}
