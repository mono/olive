//
// System.Windows.Media.ImageBrush class
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
using Mono;

namespace System.Windows.Media {

	public class ImageBrush : Brush {

		public static readonly DependencyProperty DownloadProgressProperty =
			DependencyProperty.Lookup (Kind.IMAGEBRUSH, "DownloadProgress", typeof (double));
		public static readonly DependencyProperty ImageSourceProperty =
			DependencyProperty.Lookup (Kind.IMAGEBRUSH, "ImageSource", typeof (Uri));


		public ImageBrush () : base(NativeMethods.image_brush_new ())
		{
		}


		public double DownloadProgress {
			get { return (double) GetValue (DownloadProgressProperty); }
			set { SetValue (DownloadProgressProperty, value); }
		}

		public Uri ImageSource {
			get { return (Uri) GetValue (ImageSourceProperty); }
			set { SetValue (ImageSourceProperty, value); }
		}


		[MonoTODO]
		public void SetSource (DependencyObject Downloader, string PartName)
		{
			throw new NotImplementedException ();
		}

		protected internal override Kind GetKind ()
		{
			return Kind.IMAGEBRUSH;
		}

		public event ErrorEventHandler ImageFailed;
	}
}
