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

using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Media;

namespace System.Windows.Interop {

	public class HwndSource : PresentationSource, IWin32Window, IDisposable {
		[SecurityCritical]
		public HwndSource ()
		{
		}

		public void Dispose ()
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public void AddHook (HwndSourceHook hook)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public void RemoveHook (HwndSourceHook hook)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		protected override CompositionTarget GetCompositionTargetCore ()
		{
			throw new NotImplementedException ();
		}

		public bool UsesPerPixelOpacity {
			[SecurityCritical]
			get { throw new NotImplementedException (); }
		}

		public IntPtr Handle {
			[SecurityCritical]
			get { throw new NotImplementedException (); }
		}

		public new HwndTarget CompositionTarget {
			[SecurityCritical]
			get { throw new NotImplementedException (); }
		}

		public override bool IsDisposed {
			get { throw new NotImplementedException (); }
		}

		public SizeToContent SizeToContent {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public override Visual RootVisual {
			[SecurityCritical]
			get { throw new NotImplementedException (); }
			[SecurityCritical]
			set { throw new NotImplementedException (); }
		}

		[SecurityCritical]
		public static HwndSource FromHwnd (IntPtr hwnd)
		{
			throw new NotImplementedException ();
		}

		public HandleRef CreateHandleRef ()
		{
			throw new NotImplementedException ();
		}
	}
}