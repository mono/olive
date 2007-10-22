//
// System.Windows.Browser.Net.BrowserHttpWebRequest class
//
// Authors:
//	Jb Evain  <jbevain@novell.com>
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
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net;

using Mono;

namespace System.Windows.Browser.Net
{
	public class BrowserHttpWebRequest : HttpWebRequest
	{
#if NET_2_1
		IntPtr native;
		Uri uri;
		string method = "GET";
		WebHeaderCollection headers = new WebHeaderCollection ();
		BrowserHttpWebResponse response = null;

		public BrowserHttpWebRequest (Uri uri)
			: base (uri)
		{
			this.uri = uri;
		}

		~BrowserHttpWebRequest ()
		{
			if (native == IntPtr.Zero)
				return;

			NativeMethods.browser_http_request_destroy (native);
		}

		[MonoTODO]
		public override void Abort ()
		{
			throw new NotImplementedException ();
		}

		public override void AddRange (int range)
		{
			AddRange ("bytes", range);
		}

		public override void AddRange (int @from, int to)
		{
			AddRange ("bytes", @from, to);
		}

		public override void AddRange (string rangeSpecifier, int range)
		{
			AddRangeInternal (rangeSpecifier, range, null);
		}

		public override void AddRange (string rangeSpecifier, int @from, int to)
		{
			AddRangeInternal (rangeSpecifier, @from, to);
		}

		static bool IsSameRangeKind (string range, string rangeSpecifier)
		{
			return range.ToLower (CultureInfo.InvariantCulture).StartsWith (
				rangeSpecifier.ToLower (CultureInfo.InvariantCulture));
		}

		void AddRangeInternal (string rangeSpecifier, int @from, int? to)
		{
			if (rangeSpecifier == null)
				throw new ArgumentNullException ("rangeSpecifier");

			if (from < 0 || ((to != null) && (to < 0 || from > to)))
				throw new ArgumentOutOfRangeException ();

			string range = headers [HttpRequestHeader.Range];
			if (string.IsNullOrEmpty (range))
				range = rangeSpecifier + "=";
			else if (IsSameRangeKind (range, rangeSpecifier))
				range += ",";
			else
				throw new InvalidOperationException ("rangeSpecifier");

			range += from.ToString (CultureInfo.InvariantCulture) + "-";
			if (to != null)
				range += ((int) to).ToString (CultureInfo.InvariantCulture);

			headers [HttpRequestHeader.Range] = range;
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

		void InitializeNativeRequest ()
		{
			if (native != IntPtr.Zero)
				return;

			native = NativeMethods.browser_http_request_new (method, uri.AbsoluteUri);

			//foreach (DictionaryEntry entry in headers)
			//	NativeMethods.browser_http_request_set_header (native, (string) entry.Key, (string) entry.Value);
		}

		public override HttpWebResponse GetResponse ()
		{
			InitializeNativeRequest ();

			IntPtr resp = NativeMethods.browser_http_request_get_response (native);

			response = new BrowserHttpWebResponse (resp);
			response.Read ();

			return response;
		}

		public override string Accept {
			get { return headers [HttpRequestHeader.Accept]; }
			set { headers [HttpRequestHeader.Connection] = value; }
		}

		public override Uri Address {
			get { return uri; }
		}

		public override bool AllowAutoRedirect {
			get { return true; } // silverlight always returns true
			set { throw new NotSupportedException (); }
		}

		public override bool AllowWriteStreamBuffering {
			get { return true; }
			set { throw new NotSupportedException (); }
		}

		public override DecompressionMethods AutomaticDecompression {
			get { return DecompressionMethods.None; }
			set { throw new NotSupportedException (); }
		}

		public override string Connection {
			get { return headers [HttpRequestHeader.Connection]; }
			set { headers [HttpRequestHeader.Connection] = value; }
		}

		public override long ContentLength {
			get {
				// silverlight 1.1 throws FormatException on ContentLength when it's not set.
				return long.Parse (headers [HttpRequestHeader.ContentLength], NumberStyles.Integer, CultureInfo.InvariantCulture);
			}
			set {
				headers [HttpRequestHeader.ContentLength] = value.ToString (CultureInfo.InvariantCulture);
			}
		}

		public override string ContentType {
			get { return headers [HttpRequestHeader.ContentType]; }
			set { headers [HttpRequestHeader.ContentType] = value; }
		}

		public Delegate ContinueDelegate {
			get { throw new NotSupportedException (); }
			set { throw new NotSupportedException (); }
		}

		public object CookieContainer {
			get { throw new NotSupportedException (); }
			set { throw new NotSupportedException (); }
		}

		public object Credentials {
			get { throw new NotSupportedException (); }
			set { throw new NotSupportedException (); }
		}

		public override string Expect {
			get { return headers [HttpRequestHeader.Expect]; }
			set { headers [HttpRequestHeader.Expect] = value; }
		}

		public override bool HaveResponse {
			get { return response != null; }
		}

		public override WebHeaderCollection Headers {
			get { return headers; }
			set { headers = value; }
		}

		public override bool KeepAlive {
			get { throw new NotSupportedException (); }
			set { throw new NotSupportedException (); }
		}

		public override string MediaType {
			get { throw new NotSupportedException (); }
			set { throw new NotSupportedException (); }
		}

		public override string Method {
			get { return method; }
			set { method = value; }
		}

		public override bool Pipelined {
			get { throw new NotSupportedException (); }
			set { throw new NotSupportedException (); }
		}

		public override bool PreAuthenticate {
			get { throw new NotSupportedException (); }
			set { throw new NotSupportedException (); }
		}

		public override int ReadWriteTimeout {
			get { throw new NotSupportedException (); }
			set { throw new NotSupportedException (); }
		}

		public override string Referer {
			get { return headers [HttpRequestHeader.Referer]; }
			set { headers [HttpRequestHeader.Referer] = value; }
		}

		public override Uri RequestUri {
			get { return uri; }
		}

		public override bool SendChunked {
			get { throw new NotSupportedException (); }
			set { throw new NotSupportedException (); }
		}

		public override int Timeout {
			get { throw new NotSupportedException (); }
			set { throw new NotSupportedException (); }
		}

		public override string TransferEncoding {
			get { return headers [HttpRequestHeader.TransferEncoding]; }
			set { headers [HttpRequestHeader.TransferEncoding] = value; }
		}

		public override string UserAgent {
			get { return headers [HttpRequestHeader.UserAgent]; }
			set { headers [HttpRequestHeader.UserAgent] = value; }
		}
#else
		BrowserHttpWebRequest ()
			: base (null, default (System.Runtime.Serialization.StreamingContext))
		{
		}
#endif
	}
}
