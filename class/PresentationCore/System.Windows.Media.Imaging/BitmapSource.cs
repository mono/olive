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
// Copyright (c) 2008 Novell, Inc. (http://www.novell.com)
//
// Author:
//	Chris Toshok (toshok@ximian.com)
//

using System;
using System.Security;
using System.Windows;
using System.Windows.Media;

namespace System.Windows.Media.Imaging {

	[Localizability (LocalizationCategory.None, Readability = Readability.Unreadable)]
	public abstract class BitmapSource : ImageSource {
		[SecurityCritical]
		[SecurityTreatAsSafe]
		protected BitmapSource ()
		{
		}

		public override ImageMetadata Metadata {
			get { throw new NotImplementedException (); }
		}

		public override double Height {
			get { throw new NotImplementedException (); }
		}

		public override double Width {
			get { throw new NotImplementedException (); }
		}

		public abstract int PixelHeight { get; }
		public abstract int PixelWidth { get; }
		public abstract double DpiX { get; }
		public abstract double DpiY { get; }
		public abstract BitmapPalette Palette { get; }
		public abstract PixelFormat Format { get; }
		public abstract bool IsDownloading { get; }

		[SecurityCritical]
		[SecurityTreatAsSafe]
		protected void CheckIfSiteOfOrigin ()
		{
			throw new NotImplementedException ();
		}

		public new BitmapSource Clone ()
		{
			throw new NotImplementedException ();
		}

		protected override void CloneCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}

		public new BitmapSource CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override void CloneCurrentValueCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public virtual void CopyPixels (Int32Rect sourceRect, IntPtr butter, int bufferSize, int stride)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public virtual void CopyPixels (Int32Rect sourceRect, Array pixels, int stride, int offset)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public virtual void CopyPixels (Array pixels, int stride, int offset)
		{
			throw new NotImplementedException ();
		}

		public static BitmapSource Create (int pixelWidth, int pixelHeight,
						   double dpiX, double dpiY,
						   PixelFormat pixelFormat, BitmapPalette palette,
						   Array pixels, int stride)
		{
			throw new NotImplementedException ();
		}

		public static BitmapSource Create (int pixelWidth, int pixelHeight,
						   double dpiX, double dpiY,
						   PixelFormat pixelFormat, BitmapPalette palette,
						   IntPtr buffer, int bufferSize, int stride)
		{
			throw new NotImplementedException ();
		}

		protected override bool FreezeCore (bool isChecking)
		{
			throw new NotImplementedException ();
		}

		protected override void GetAsFrozenCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}

		protected override void GetCurrentValueAsFrozenCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}
	}
}