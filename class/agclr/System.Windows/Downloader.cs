//
// System.Windows.Downloader class
//
// Authors:
//	Sebastien Pouliot <sebastien@ximian.com>
//	Miguel de Icaza   <miguel@ximian.com>
//
// TODO:
//    Register callbacks so we can raise the various events
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
using Mono;
using System.Runtime.InteropServices;

namespace System.Windows {

	public sealed class Downloader : DependencyObject {

		public static readonly DependencyProperty DownloadProgressProperty =
			DependencyProperty.Lookup (Kind.DOWNLOADER, "DownloadProgress", typeof (double));
		public static readonly DependencyProperty ResponseTextProperty =
			DependencyProperty.Lookup (Kind.DOWNLOADER, "ResponseText", typeof (string));
		public static readonly DependencyProperty StatusProperty =
			DependencyProperty.Lookup (Kind.DOWNLOADER, "Status", typeof (int));
		public static readonly DependencyProperty StatusTextProperty =
			DependencyProperty.Lookup (Kind.DOWNLOADER, "StatusText", typeof (string));
		public static readonly DependencyProperty UriProperty =
			DependencyProperty.Lookup (Kind.DOWNLOADER, "Uri", typeof (string));

		NativeMethods.UpdateFunction updater;

		string filename;
		
		void UpdateCallback (int kind, IntPtr cb_data, IntPtr extra)
		{
			EventHandler h = null;
			
			switch (kind){
			case 0:
				h = Completed;
				break;
			case 1:
				h = DownloadProgressChanged;
				break;
			case 2:
				ErrorEventHandler df = DownloadFailed;
				if (df != null) {
					filename = Marshal.PtrToStringAuto (extra);
					ErrorEventArgs eea = new ErrorEventArgs (4001, filename, ErrorType.DownloadError);
					df (this, eea);
				}
				return;
			}
			if (h != null)
				h (this, EventArgs.Empty);
		}
		
		internal void NotifyWantUpdates ()
		{
			if (native == IntPtr.Zero)
				return;
			
			updater = new NativeMethods.UpdateFunction (UpdateCallback);
			NativeMethods.downloader_want_events (native, updater, IntPtr.Zero);
		}
		
		public Downloader () : base (NativeMethods.downloader_new ())
		{
			NativeMethods.base_ref (native);

			// OPTIMIZEME: We should do this only if an event is hooked up,
			// currently we do it always.
			NotifyWantUpdates ();
		}
		
		internal Downloader (IntPtr raw) : base (raw)
		{
			// OPTIMIZME: We should do this only if an event is hooked up,
			// currently we do it always.
			NotifyWantUpdates ();
		}


		public double DownloadProgress {
			get { return (double) GetValue (DownloadProgressProperty); }
			set { SetValue (DownloadProgressProperty, value); }
		}

		public string ResponseText {
			get { return (string) GetValue (ResponseTextProperty); }
			set { SetValue (ResponseTextProperty, value); }
		}

		public int Status {
			get { return (int) GetValue (StatusProperty); }
			set { SetValue (StatusProperty, value); }
		}
		
		public string StatusText {
			get { return (string) GetValue (StatusTextProperty); }
			set { SetValue (StatusTextProperty, value); }
		}

		public Uri Uri {
			get {
				// Uri is not a DependencyObject, we save it as a string
				string uri = (string) GetValue (UriProperty);
				return new Uri (uri);
			}
			set {
				string uri = value.OriginalString;
				SetValue (UriProperty, uri); 
			}
		}

		public void Abort ()
		{
			NativeMethods.downloader_abort (native);
		}

		public string GetResponseText (string PartName)
		{
			IntPtr n;
			uint size;
			
			n = NativeMethods.downloader_get_response_text (native, PartName, out size);

			//
			// This returns the contents as string, but the data is a binary blob
			//
			unsafe {
				return new String ((sbyte *) n, 0, (int) size, System.Text.Encoding.UTF8);
			}
		}

		public void Open (string verb, Uri URI, bool Async)
		{
			NativeMethods.downloader_open (native, verb, URI.ToString (), Async);
		}

		public void Send ()
		{
			NativeMethods.downloader_send (native);
		}

		public event EventHandler Completed;

		public event EventHandler DownloadProgressChanged;

		public event ErrorEventHandler DownloadFailed;
		
		internal override Kind GetKind ()
		{
			return Kind.DOWNLOADER;
		}
	}
}
