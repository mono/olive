using System;
using System.Net;

namespace System.Windows.Browser.Net
{
	public class BrowserHttpWebRequest : HttpWebRequest
	{
		[MonoTODO]
		public BrowserHttpWebRequest (Uri uri)
#if NET_2_1
			: base (uri)
#else
			: base (null, default (System.Runtime.Serialization.StreamingContext)) // FIXME: 2.0 != SL
#endif
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		~BrowserHttpWebRequest ()
		{
			throw new NotImplementedException ();
		}

/*
		They are commented out since they are overridable only
		in Silverlight.

		[MonoTODO]
		public override string Accept {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override bool AllowAutoRedirect {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override bool AllowWriteStreamBuffering {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override DecompressionMethod AutomaticDecompression {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override string Connection {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override long ContentLength {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override string ContentType {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public Delegate ContinueDelegate {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public object CookieContainer {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public object Credentials {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override string Except {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override bool HaveResponse {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override WebHeaderCollection Headers {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override string IfModifiedSince {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override bool KeepAlive {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override string MediaType {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override string Method {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override bool Pipelined {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override bool PreAuthenticate {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override int ReadWriteTimeout {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override string Referer {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override Uri RequestUri {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override bool SendChunked {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override int Timeout {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override string TransferEncoding {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override string UserAgent {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}
*/
	}
}
