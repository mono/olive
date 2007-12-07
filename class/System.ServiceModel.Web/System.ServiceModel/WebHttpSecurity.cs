namespace System.ServiceModel
{
	public sealed class WebHttpSecurity
	{
		internal WebHttpSecurity ()
		{
		}

		WebHttpSecurityMode mode;

		public WebHttpSecurityMode Mode {
			get { return mode; }
			set { mode = value; }
		}

		[MonoTODO] // how can I instantiate it?
		public HttpTransportSecurity Transport {
			get { throw new NotImplementedException (); }
		}
	}
}
