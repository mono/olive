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
using System.Security;

namespace System.Windows {

	public class RoutedEventArgs : EventArgs
	{
		bool handled;
		RoutedEvent routedEvent;
		object originalSource;
		object currentSource;

		public RoutedEventArgs (RoutedEvent routedEvent, object source)
		{
			this.routedEvent = routedEvent;
			originalSource = currentSource = source;
		}

		public RoutedEventArgs (RoutedEvent routedEvent)
		{
			this.routedEvent = routedEvent;
		}

		public RoutedEventArgs ()
		{
		}

		protected virtual void InvokeEventHandler (Delegate genericHandler, object genericTarget)
		{
			if (genericHandler == null)
				throw new ArgumentNullException ("genericHandler");
			if (genericTarget == null)
				throw new ArgumentNullException ("genericTarget");

			genericHandler.DynamicInvoke (genericTarget, this);
		}

		protected virtual void OnSetSource (object source)
		{
		}

		public bool Handled {
			[SecurityCritical]
			set { handled = value; }

			[SecurityCritical]
			get { return handled; }
		}

		public object OriginalSource {
			get { return originalSource; }
		}

		public RoutedEvent RoutedEvent {
			set { routedEvent = value; }
			get { return routedEvent; }
		}

		public object Source {
			set {
				currentSource = value;
				OnSetSource (value);
			}
			get {
				return currentSource;
			}
		}
	}

}
