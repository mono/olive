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
using System.ComponentModel;

namespace System.Windows.Input {

	public static class FocusManager {

		public static readonly DependencyProperty FocusedElementProperty;
		public static readonly DependencyProperty IsFocusScopeProperty;

		public static readonly RoutedEvent GotFocusEvent = new RoutedEvent ("GotFocus",
										    typeof (RoutedEventHandler),
										    typeof (FocusManager),
										    RoutingStrategy.Bubble);
		public static readonly RoutedEvent LostFocusEvent = new RoutedEvent ("LostFocus",
										    typeof (RoutedEventHandler),
										    typeof (FocusManager),
										    RoutingStrategy.Bubble);

		[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
		public static IInputElement GetFocusedElement (DependencyObject element)
		{
			return (IInputElement)element.GetValue (FocusedElementProperty);
		}

		public static DependencyObject GetFocusScope (DependencyObject element)
		{
			throw new NotImplementedException ();
		}

		public static bool GetIsFocusScope (DependencyObject element)
		{
			return (bool)element.GetValue (IsFocusScopeProperty);
		}

		public static void SetFocusedElement (DependencyObject element, IInputElement value)
		{
			element.SetValue (FocusedElementProperty, value);
		}

		public static void SetIsFocusScope (DependencyObject element, bool value)
		{
			element.SetValue (IsFocusScopeProperty, value);
		}
	}
}
