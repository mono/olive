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

namespace System.Windows.Input {

	public sealed class AccessKeyManager {
		public static readonly RoutedEvent AccessKeyPressedEvent =
			EventManager.RegisterRoutedEvent ("AccessKeyPressed",
							  RoutingStrategy.Bubble,
							  typeof (AccessKeyPressedEventHandler),
							  typeof (AccessKeyManager));


		public static void AddAccessKeyPressedHandler (DependencyObject element, AccessKeyPressedEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).AddHandler (AccessKeyPressedEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).AddHandler (AccessKeyPressedEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void IsKeyRegistered (object scope, string key)
		{
			throw new NotImplementedException ();
		}

		public static void ProcessKey (object scope, string key, bool isMultiple)
		{
			throw new NotImplementedException ();
		}

		public static void Register (string key, IInputElement element)
		{
			throw new NotImplementedException ();
		}

		public static void RemoveAccessKeyPressedHandler (DependencyObject element, AccessKeyPressedEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");

			if (element is UIElement)
				((UIElement)element).RemoveHandler (AccessKeyPressedEvent, handler);
			else if (element is ContentElement)
				((ContentElement)element).RemoveHandler (AccessKeyPressedEvent, handler);
			else
				throw new NotSupportedException ();
		}

		public static void Unregister (string key, IInputElement element)
		{
			throw new NotImplementedException ();
		}
	}

}
