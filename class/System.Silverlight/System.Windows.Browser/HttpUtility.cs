using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace System.Windows.Browser
{
	public sealed class HttpUtility
	{
		public string HtmlDecode (string s)
		{
			using (StringWriter sw = new StringWriter ()) {
				HtmlDecode (s, sw);
				return sw.ToString ();
			}
		}

		[MonoTODO]
		public void HtmlDecode (string s, TextWriter output)
		{
			throw new NotImplementedException ();
		}

		public string HtmlEncode (string s)
		{
			using (StringWriter sw = new StringWriter ()) {
				HtmlEncode (s, sw);
				return sw.ToString ();
			}
		}

		[MonoTODO]
		public void HtmlEncode (string s, TextWriter output)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public string UrlDecode (byte [] bytes, Encoding e)
		{
			if (bytes == null)
				throw new ArgumentNullException ("bytes");
			return UrlDecode (bytes, 0, bytes.Length, e);
		}

		[MonoTODO]
		public string UrlDecode (byte [] bytes, int offset, int count, Encoding e)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public string UrlDecode (string str)
		{
			return UrlDecode (str, Encoding.UTF8);
		}

		[MonoTODO]
		public string UrlDecode (string str, Encoding e)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public string UrlDecodeToBytes (byte [] bytes, Encoding e)
		{
			if (bytes == null)
				throw new ArgumentNullException ("bytes");
			return UrlDecodeToBytes (bytes, 0, bytes.Length, e);
		}

		[MonoTODO]
		public string UrlDecodeToBytes (byte [] bytes, int offset, int count, Encoding e)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public string UrlDecodeToBytes (string str)
		{
			return UrlDecodeToBytes (str, Encoding.UTF8);
		}

		[MonoTODO]
		public string UrlDecodeToBytes (string str, Encoding e)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public string UrlEncode (byte [] bytes, Encoding e)
		{
			if (bytes == null)
				throw new ArgumentNullException ("bytes");
			return UrlEncode (bytes, 0, bytes.Length, e);
		}

		[MonoTODO]
		public string UrlEncode (byte [] bytes, int offset, int count, Encoding e)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public string UrlEncode (string str)
		{
			return UrlEncode (str, Encoding.UTF8);
		}

		[MonoTODO]
		public string UrlEncode (string str, Encoding e)
		{
			throw new NotImplementedException ();
		}
	}
}

