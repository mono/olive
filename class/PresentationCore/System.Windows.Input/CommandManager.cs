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

	public sealed class CommandManager {
		public static readonly RoutedEvent CanExecuteEvent =
			EventManager.RegisterRoutedEvent ("CanExecute",
							  RoutingStrategy.Bubble,
							  typeof (CanExecuteRoutedEventHandler),
							  typeof (CommandManager));

		public static readonly RoutedEvent ExecutedEvent =
			EventManager.RegisterRoutedEvent ("Executed",
							  RoutingStrategy.Bubble,
							  typeof (ExecutedRoutedEventHandler),
							  typeof (CommandManager));

		public static readonly RoutedEvent PreviewCanExecuteEvent =
			EventManager.RegisterRoutedEvent ("PreviewCanExecute",
							  RoutingStrategy.Tunnel,
							  typeof (CanExecuteRoutedEventHandler),
							  typeof (CommandManager));

		public static readonly RoutedEvent PreviewExecutedEvent =
			EventManager.RegisterRoutedEvent ("PreviewExecuted",
							  RoutingStrategy.Tunnel,
							  typeof (ExecutedRoutedEventHandler),
							  typeof (CommandManager));

		public static event EventHandler RequerySuggested;

		public static void AddCanExecuteHandler (UIElement element, CanExecuteRoutedEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");
			element.AddHandler (CanExecuteEvent, handler);
		}

		public static void AddExecutedHandler (UIElement element, ExecutedRoutedEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");
			element.AddHandler (ExecutedEvent, handler);
		}

		public static void AddPreviewCanExecuteHandler (UIElement element, CanExecuteRoutedEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");
			element.AddHandler (PreviewCanExecuteEvent, handler);
		}

		public static void AddPreviewExecutedHandler (UIElement element, ExecutedRoutedEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");
			element.AddHandler (PreviewExecutedEvent, handler);
		}

		public static void InvalidateRequerySuggested ()
		{
			throw new NotImplementedException ();
		}

		public static void RemoveCanExecuteHandler (UIElement element, CanExecuteRoutedEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");
			element.RemoveHandler (CanExecuteEvent, handler);
		}

		public static void RemoveExecutedHandler (UIElement element, ExecutedRoutedEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");
			element.RemoveHandler (ExecutedEvent, handler);
		}

		public static void RemovePreviewCanExecuteHandler (UIElement element, CanExecuteRoutedEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");
			element.RemoveHandler (PreviewCanExecuteEvent, handler);
		}

		public static void RemovePreviewExecutedHandler (UIElement element, ExecutedRoutedEventHandler handler)
		{
			if (element == null) throw new ArgumentNullException ("element");
			if (handler == null) throw new ArgumentNullException ("handler");
			element.RemoveHandler (PreviewExecutedEvent, handler);
		}
	}

}
