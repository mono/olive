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

using System.Windows;

namespace System.Windows.Automation {

	public static class AutomationProperties {
		public static readonly DependencyProperty NameProperty;
		public static string GetName (DependencyObject obj)
		{
		    return (string)obj.GetValue (NameProperty);
		}
		public static void SetName (DependencyObject obj, string value)
		{
			obj.SetValue (NameProperty, value);
		}

		public static readonly DependencyProperty LabeledByProperty;
		public static UIElement GetLabeledBy (DependencyObject obj)
		{
		    return (UIElement)obj.GetValue (LabeledByProperty);
		}
		public static void SetLabeledBy (DependencyObject obj, UIElement value)
		{
			obj.SetValue (LabeledByProperty, value);
		}

		public static readonly DependencyProperty ItemTypeProperty;
		public static string GetItemType (DependencyObject obj)
		{
		    return (string)obj.GetValue (ItemTypeProperty);
		}
		public static void SetItemType (DependencyObject obj, string value)
		{
			obj.SetValue (ItemTypeProperty, value);
		}

		public static readonly DependencyProperty IsRequiredForFormProperty;
		public static bool GetIsRequiredForForm (DependencyObject obj)
		{
		    return (bool)obj.GetValue (IsRequiredForFormProperty);
		}
		
		public static void SetIsRequiredForForm (DependencyObject obj, bool value)
		{
			obj.SetValue (IsRequiredForFormProperty, value);
		}

		public static readonly DependencyProperty HelpTextProperty;
		public static string GetHelpText (DependencyObject obj)
		{
		    return (string)obj.GetValue (HelpTextProperty);
		}
		
		public static void SetHelpText (DependencyObject obj, string value)
		{
			obj.SetValue (HelpTextProperty, value);
		}

		public static readonly DependencyProperty AcceleratorKeyProperty;
		public static string GetAcceleratorKey (DependencyObject obj)
		{
		    return (string)obj.GetValue (AcceleratorKeyProperty);
		}
		
		public static void SetAcceleratorKey (DependencyObject obj, string value)
		{
			obj.SetValue (AcceleratorKeyProperty, value);
		}

		public static readonly DependencyProperty AccessKeyProperty;
		public static string GetAccessKey (DependencyObject obj)
		{
		    return (string)obj.GetValue (AccessKeyProperty);
		}
		
		public static void SetAccessKey (DependencyObject obj, string value)
		{
			obj.SetValue (AccessKeyProperty, value);
		}

		public static readonly DependencyProperty IsRowHeaderProperty;
		public static bool GetIsRowHeader (DependencyObject obj)
		{
		    return (bool)obj.GetValue (IsRowHeaderProperty);
		}
		
		public static void SetIsRowHeader (DependencyObject obj, bool value)
		{
			obj.SetValue (IsRowHeaderProperty, value);
		}

		public static readonly DependencyProperty IsColumnHeaderProperty;
		public static bool GetIsColumnHeader (DependencyObject obj)
		{
		    return (bool)obj.GetValue (IsColumnHeaderProperty);
		}
		
		public static void SetIsColumnHeader (DependencyObject obj, bool value)
		{
			obj.SetValue (IsColumnHeaderProperty, value);
		}

		public static readonly DependencyProperty AutomationIdProperty;
		public static string GetAutomationId (DependencyObject obj)
		{
		    return (string)obj.GetValue (AutomationIdProperty);
		}
		
		public static void SetAutomationId (DependencyObject obj, string value)
		{
			obj.SetValue (AutomationIdProperty, value);
		}

		public static readonly DependencyProperty ItemStatusProperty;
		public static string GetItemStatus (DependencyObject obj)
		{
		    return (string)obj.GetValue (ItemStatusProperty);
		}
		
		public static void SetItemStatus (DependencyObject obj, string value)
		{
			obj.SetValue (ItemStatusProperty, value);
		}
	}
}