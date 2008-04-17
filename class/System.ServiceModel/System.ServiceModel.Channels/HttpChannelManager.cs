using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace System.ServiceModel.Channels
{
	internal class HttpChannelManager<TChannel> where TChannel : class, IChannel
	{
		static Dictionary<Uri, HttpListener> opened_listeners;
		HttpChannelListener<TChannel> channel_listener;
		HttpListener http_listener;

		static HttpChannelManager ()
		{
			opened_listeners = new Dictionary<Uri, HttpListener> ();
		}

		public HttpChannelManager (HttpChannelListener<TChannel> channel_listener)
		{
			this.channel_listener = channel_listener;
		}

		public void Open (TimeSpan timeout)
		{
			if (opened_listeners.ContainsKey (channel_listener.Uri))
				http_listener = opened_listeners [channel_listener.Uri];

			if (http_listener == null) {
				http_listener = new HttpListener ();

				http_listener.Prefixes.Add (channel_listener.Uri.ToString ());
				http_listener.Start ();

				opened_listeners [channel_listener.Uri] = http_listener;
			}
		}

		public void Stop ()
		{
			if (http_listener == null)
				return;
			if (http_listener.IsListening)
				http_listener.Stop ();
			((IDisposable) http_listener).Dispose ();
		}

		public HttpListener HttpListener
		{
			get { return http_listener; }
		}
	}
}
