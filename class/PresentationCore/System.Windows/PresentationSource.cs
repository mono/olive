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
// Copyright (c) 2007 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Chris Toshok (toshok@ximian.com)
//

using System;
using System.Collections;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Threading;

namespace System.Windows {

	public abstract class PresentationSource : DispatcherObject {
		protected PresentationSource ()
		{
			throw new NotImplementedException ();
		}

		public static PresentationSource FromVisual (Visual visual)
		{
			throw new NotImplementedException ();
		}


		protected void AddSource ()
		{
			throw new NotImplementedException ();
		}

		protected void RemoveSource ()
		{
			throw new NotImplementedException ();
		}

		public static void AddSourceChangedHandler (IInputElement element,
							    SourceChangedEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemoveSourceChangedHandler (IInputElement e,
							       SourceChangedEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		protected void ClearContentRenderedListeners ()
		{
			ContentRendered = null;
		}

		protected void RootChanged (Visual oldRoot, Visual newRoot)
		{
			throw new NotImplementedException ();
		}

		public CompositionTarget CompositionTarget {
			get {
				throw new NotImplementedException ();
			}
		}

		public static IEnumerable CurrentSources {
			get {
				throw new NotImplementedException ();
			}
		}

		protected abstract CompositionTarget GetCompositionTargetCore ();
		public abstract bool IsDisposed { get; }
		public abstract Visual RootVisual { set; get; }
		public event EventHandler ContentRendered;
	}

}

