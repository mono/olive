//
// System.Windows.Browser.HtmlObject class
//
// Authors:
//	Sebastien Pouliot  <sebastien@ximian.com>
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
using System.Runtime.InteropServices;

namespace System.Windows.Browser {

	public abstract class HtmlObject : ScriptableObject {

		protected HtmlObject ()
		{
		}

		internal HtmlObject (IntPtr handle)
			: base (handle)
		{
		}

		public bool AttachEvent (string eventName, EventHandler handler)
		{
			return true;
		}

		public bool AttachEvent (string eventName, EventHandler<HtmlEventArgs> handler)
		{
			return AttachEvent (WebApplication.Current.PluginHandle, Handle, eventName, handler);
		}

		public void DetachEvent (string eventName, EventHandler handler)
		{
			DetachEvent (WebApplication.Current.PluginHandle, Handle, eventName, handler);
		}

		public void DetachEvent (string eventName, EventHandler<HtmlEventArgs> handler)
		{
			DetachEvent (WebApplication.Current.PluginHandle, Handle, eventName, handler);
		}

		internal static T GetPropertyInternal<T> (IntPtr handle, string name)
		{
			Mono.Value res;
			html_object_get_property (WebApplication.Current.PluginHandle, handle, name, out res);

			if (res.k != Mono.Kind.INVALID) {
				object o = ScriptableObjectWrapper.ObjectFromValue (res);
				return (T) o;
			}

			return default (T);
		}

		internal static void SetPropertyInternal (IntPtr handle, string name, object value)
		{
			Mono.Value dp = new Mono.Value ();
			ScriptableObjectWrapper.ValueFromObject (ref dp, value);
			html_object_set_property (WebApplication.Current.PluginHandle, handle, name, ref dp);
		}

		internal static T InvokeInternal<T> (IntPtr handle, string name, params object [] args)
		{
			Mono.Value res;
			Mono.Value [] vargs = new Mono.Value [args.Length];

			for (int i = 0; i < args.Length; i++)
				ScriptableObjectWrapper.ValueFromObject (ref vargs [i], args [i]);

			html_object_invoke (WebApplication.Current.PluginHandle, handle, name, vargs, args.Length, out res);

			if (res.k != Mono.Kind.INVALID) {
				object o = ScriptableObjectWrapper.ObjectFromValue (res);
				return (T) o;
			}

			return default (T);
		}

		[DllImport ("moonplugin")]
		static extern bool AttachEvent (IntPtr xpp, IntPtr obj, string name, EventHandler handler);

		[DllImport ("moonplugin")]
		static extern bool AttachEvent (IntPtr xpp, IntPtr obj, string name, EventHandler<HtmlEventArgs> handler);

		[DllImport ("moonplugin")]
		static extern void DetachEvent (IntPtr xpp, IntPtr obj, string name, EventHandler handler);

		[DllImport ("moonplugin")]
		static extern void DetachEvent (IntPtr xpp, IntPtr obj, string name, EventHandler<HtmlEventArgs> handler);

		[DllImport ("moonplugin")]
		internal static extern void html_object_get_property (IntPtr plugin, IntPtr obj, string name, out Mono.Value result);

		[DllImport ("moonplugin")]
		internal static extern void html_object_set_property (IntPtr plugin, IntPtr obj, string name, ref Mono.Value value);

		[DllImport ("moonplugin")]
		internal static extern void html_object_invoke (IntPtr plugin, IntPtr obj, string name,
				Mono.Value [] args, int arg_count, out Mono.Value result);

		[DllImport ("moonplugin")]
		internal static extern IntPtr html_object_attach_event (IntPtr plugin, IntPtr obj, string name, Mono.PlainEvent cb);

	}
}
