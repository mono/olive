using System;
using System.IO;
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

#if NET_2_1
		[MonoTODO]
		public override void Abort ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void AddRange (int range)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void AddRange (int from, int to)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void AddRange (string rangeSpecifier, int range)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void AddRange (string rangeSpecifier, int from, int to)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override IAsyncResult BeginGetRequestStream (AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override IAsyncResult BeginGetResponse (AsyncCallback callback, object state)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override Stream EndGetRequestStream (IAsyncResult asyncResult)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override HttpWebResponse EndGetResponse (IAsyncResult asyncResult)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override Stream GetRequestStream ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override HttpWebResponse GetResponse ()
		{
			throw new NotImplementedException ();
		}
		
		[MonoTODO]
		public override string Accept {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public override Uri Address {
			get { throw new NotImplementedException (); }
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
		public override DecompressionMethods AutomaticDecompression {
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
		public override string Expect {
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
#endif
	}
}
