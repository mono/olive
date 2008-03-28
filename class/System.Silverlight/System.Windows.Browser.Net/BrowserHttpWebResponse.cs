//
// System.Windows.Browser.Net.BrowserHttpWebResponse class
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

#if NET_2_1 && FALSE

using System;
using System.Globalization;
using System.IO;
using System.Net;

using Mono;

namespace System.Windows.Browser.Net
{
	class BrowserHttpWebResponse : HttpWebResponse
	{
		BrowserHttpWebRequest request;
		IntPtr native;
		Stream response;

		HttpStatusCode status_code;
		string status_desc;

		WebHeaderCollection headers = new WebHeaderCollection ();

		public BrowserHttpWebResponse (BrowserHttpWebRequest request, IntPtr native)
		{
			this.request = request;
			this.native = native;

			if (native == IntPtr.Zero)
				return;

			NativeMethods.browser_http_response_visit_headers (native, OnHttpHeader);
		}

		~BrowserHttpWebResponse ()
		{
			if (native == IntPtr.Zero)
				return;

			NativeMethods.browser_http_response_destroy (native);
		}

		void OnHttpHeader (string name, string value)
		{
			try {
				headers [name] = value;
			} catch {}
		}

		public override void Close ()
		{
			response.Dispose ();
		}

		internal void Read ()
		{
			int size;
			IntPtr p = NativeMethods.browser_http_response_read (native, out size);

			byte [] data = new byte [size];
			unsafe {
				using (Stream stream = new SimpleUnmanagedMemoryStream ((byte *) p, size))
					stream.Read (data, 0, size);
			}

			Helper.FreeHGlobal (p);

			response = new MemoryStream (data);
		}

		public override string GetResponseHeader (string headerName)
		{
			return headers [headerName];
		}

		public override Stream GetResponseStream ()
		{
			return response;
		}

		public override string CharacterSet {
			get { throw new NotImplementedException (); }
		}

		public override string ContentEncoding {
			get { return headers [HttpResponseHeader.ContentEncoding]; }
		}

		public override long ContentLength {
			get { return long.Parse (headers [HttpResponseHeader.ContentLength], NumberStyles.Integer, CultureInfo.InvariantCulture);; }
		}

		public override string ContentType {
			get { return headers [HttpResponseHeader.ContentType]; }
		}

		public override WebHeaderCollection Headers {
			get { return headers; }
		}

		public override DateTime LastModified {
			get { return DateTime.Parse (headers [HttpResponseHeader.ContentLength], CultureInfo.InvariantCulture); }
		}

		public override string Method {
			get { return request.Method; }
		}

		public override Version ProtocolVersion {
			get { throw new NotImplementedException (); }
		}

		public override Uri ResponseUri {
			get { return request.RequestUri; }
		}

		public override string Server {
			get { return headers [HttpResponseHeader.Server]; }
		}

		void GetStatus ()
		{
			if(0 != (int) status_code)
				return;

			if (native == IntPtr.Zero)
				return;

			int code;
			status_desc = NativeMethods.browser_http_response_get_status (native, out code);
			status_code = (HttpStatusCode) code;
		}

		public override HttpStatusCode StatusCode {
			get {
				GetStatus ();
				return status_code;
			}
		}

		public override string StatusDescription {
			get {
				GetStatus ();
				return status_desc;
			}
		}
	}
}

#endif
