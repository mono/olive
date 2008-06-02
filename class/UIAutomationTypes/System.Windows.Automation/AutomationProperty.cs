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
// Authors: 
//      Calvin Gaisford <calvinrg@gmail.com>
// 

using System;

namespace System.Windows.Automation
{
	public class AutomationProperty : AutomationIdentifier
	{
#region Internal Constructor
		
		internal AutomationProperty (int id, string programmaticName) :
			base (id, programmaticName)
		{
		}
		
#endregion
		
#region Public Static Methods
		
		public static AutomationProperty LookupById (int id)
		{
			if (id == AutomationElementIdentifiers.AcceleratorKeyPropertyId)
				return AutomationElementIdentifiers.AcceleratorKeyProperty;
			else if (id == AutomationElementIdentifiers.AccessKeyPropertyId)
				return AutomationElementIdentifiers.AccessKeyProperty;
			else if (id == AutomationElementIdentifiers.AutomationIdPropertyId)
				return AutomationElementIdentifiers.AutomationIdProperty;
			else if (id == AutomationElementIdentifiers.BoundingRectanglePropertyId)
				return AutomationElementIdentifiers.BoundingRectangleProperty;
			else if (id == AutomationElementIdentifiers.ClassNamePropertyId)
				return AutomationElementIdentifiers.ClassNameProperty;
			else if (id == AutomationElementIdentifiers.ClickablePointPropertyId)
				return AutomationElementIdentifiers.ClickablePointProperty;
			else if (id == AutomationElementIdentifiers.ControlTypePropertyId)
				return AutomationElementIdentifiers.ControlTypeProperty;
			else if (id == AutomationElementIdentifiers.CulturePropertyId)
				return AutomationElementIdentifiers.CultureProperty;
			else if (id == AutomationElementIdentifiers.FrameworkIdPropertyId)
				return AutomationElementIdentifiers.FrameworkIdProperty;
			else if (id == AutomationElementIdentifiers.HasKeyboardFocusPropertyId)
				return AutomationElementIdentifiers.HasKeyboardFocusProperty;
			else if (id == AutomationElementIdentifiers.HelpTextPropertyId)
				return AutomationElementIdentifiers.HelpTextProperty;
			else if (id == AutomationElementIdentifiers.IsContentElementPropertyId)
				return AutomationElementIdentifiers.IsContentElementProperty;
			else if (id == AutomationElementIdentifiers.IsControlElementPropertyId)
				return AutomationElementIdentifiers.IsControlElementProperty;
			else if (id == AutomationElementIdentifiers.IsDockPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsDockPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsEnabledPropertyId)
				return AutomationElementIdentifiers.IsEnabledProperty;
			else if (id == AutomationElementIdentifiers.IsExpandCollapsePatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsExpandCollapsePatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsGridItemPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsGridItemPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsGridPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsGridPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsInvokePatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsInvokePatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsKeyboardFocusablePropertyId)
				return AutomationElementIdentifiers.IsKeyboardFocusableProperty;
			else if (id == AutomationElementIdentifiers.IsMultipleViewPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsMultipleViewPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsOffscreenPropertyId)
				return AutomationElementIdentifiers.IsOffscreenProperty;
			else if (id == AutomationElementIdentifiers.IsPasswordPropertyId)
				return AutomationElementIdentifiers.IsPasswordProperty;
			else if (id == AutomationElementIdentifiers.IsRangeValuePatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsRangeValuePatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsRequiredForFormPropertyId)
				return AutomationElementIdentifiers.IsRequiredForFormProperty;
			else if (id == AutomationElementIdentifiers.IsScrollItemPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsScrollItemPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsScrollPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsScrollPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsSelectionItemPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsSelectionItemPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsSelectionPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsSelectionPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsTableItemPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsTableItemPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsTablePatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsTablePatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsTextPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsTextPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsTogglePatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsTogglePatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsTransformPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsTransformPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsValuePatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsValuePatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.IsWindowPatternAvailablePropertyId)
				return AutomationElementIdentifiers.IsWindowPatternAvailableProperty;
			else if (id == AutomationElementIdentifiers.ItemStatusPropertyId)
				return AutomationElementIdentifiers.ItemStatusProperty;
			else if (id == AutomationElementIdentifiers.ItemTypePropertyId)
				return AutomationElementIdentifiers.ItemTypeProperty;
			else if (id == AutomationElementIdentifiers.LabeledByPropertyId)
				return AutomationElementIdentifiers.LabeledByProperty;
			else if (id == AutomationElementIdentifiers.LocalizedControlTypePropertyId)
				return AutomationElementIdentifiers.LocalizedControlTypeProperty;
			else if (id == AutomationElementIdentifiers.NamePropertyId)
				return AutomationElementIdentifiers.NameProperty;
			else if (id == AutomationElementIdentifiers.NativeWindowHandlePropertyId)
				return AutomationElementIdentifiers.NativeWindowHandleProperty;
			else if (id == AutomationElementIdentifiers.OrientationPropertyId)
				return AutomationElementIdentifiers.OrientationProperty;
			else if (id == AutomationElementIdentifiers.ProcessIdPropertyId)
				return AutomationElementIdentifiers.ProcessIdProperty;
			else if (id == AutomationElementIdentifiers.RuntimeIdPropertyId)
				return AutomationElementIdentifiers.RuntimeIdProperty;
			else if (id == TogglePatternIdentifiers.ToggleStatePropertyId)
				return TogglePatternIdentifiers.ToggleStateProperty;
			else if (id == SelectionItemPatternIdentifiers.IsSelectedPropertyId)
				return SelectionItemPatternIdentifiers.IsSelectedProperty;
			else if (id == SelectionItemPatternIdentifiers.SelectionContainerPropertyId)
				return SelectionItemPatternIdentifiers.SelectionContainerProperty;
			else if (id == RangeValuePatternIdentifiers.IsReadOnlyPropertyId)
				return RangeValuePatternIdentifiers.IsReadOnlyProperty;
			else if (id == RangeValuePatternIdentifiers.LargeChangePropertyId)
				return RangeValuePatternIdentifiers.LargeChangeProperty;
			else if (id == RangeValuePatternIdentifiers.MaximumPropertyId)
				return RangeValuePatternIdentifiers.MaximumProperty;
			else if (id == RangeValuePatternIdentifiers.MinimumPropertyId)
				return RangeValuePatternIdentifiers.MinimumProperty;
			else if (id == RangeValuePatternIdentifiers.SmallChangePropertyId)
				return RangeValuePatternIdentifiers.SmallChangeProperty;
			else if (id == RangeValuePatternIdentifiers.ValuePropertyId)
				return RangeValuePatternIdentifiers.ValueProperty;
			else if (id == ScrollPatternIdentifiers.HorizontallyScrollablePropertyId)
				return ScrollPatternIdentifiers.HorizontallyScrollableProperty;
			else if (id == ScrollPatternIdentifiers.HorizontalScrollPercentPropertyId)
				return ScrollPatternIdentifiers.HorizontalScrollPercentProperty;
			else if (id == ScrollPatternIdentifiers.HorizontalViewSizePropertyId)
				return ScrollPatternIdentifiers.HorizontalViewSizeProperty;
			else if (id == ScrollPatternIdentifiers.VerticallyScrollablePropertyId)
				return ScrollPatternIdentifiers.VerticallyScrollableProperty;
			else if (id == ScrollPatternIdentifiers.VerticalScrollPercentPropertyId)
				return ScrollPatternIdentifiers.VerticalScrollPercentProperty;
			else if (id == ScrollPatternIdentifiers.VerticalViewSizePropertyId)
				return ScrollPatternIdentifiers.VerticalViewSizeProperty;
			else
				return null;
		}
		
#endregion
	}
}

