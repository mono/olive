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
//      Sandy Armstrong <sanfordarmstrong@gmail.com>
// 

using System;

namespace System.Windows.Automation
{
	public static class AutomationElementIdentifiers
	{
#region Static Constructor
		
		static AutomationElementIdentifiers ()
		{
			NotSupported = new object ();
			
			// TODO: Assign fields
			// TODO: Figure out IDs via test
			NameProperty = AutomationProperty.LookupById (AutomationProperty.NamePropertyId);
			ControlTypeProperty = AutomationProperty.LookupById (AutomationProperty.ControlTypePropertyId);
		}
		
#endregion
		
#region Public Fields
		
		public static readonly AutomationProperty AcceleratorKeyProperty;
		
		public static readonly AutomationProperty AccessKeyProperty;
		
		public static readonly AutomationEvent AsyncContentLoadedEvent;
		
		public static readonly AutomationEvent AutomationFocusChangedEvent;
		
		public static readonly AutomationProperty AutomationIdProperty;
		
		public static readonly AutomationEvent AutomationPropertyChangedEvent;
		
		public static readonly AutomationProperty BoundingRectangleProperty;
		
		public static readonly AutomationProperty ClassNameProperty;
		
		public static readonly AutomationProperty ClickablePointProperty;
		
		public static readonly AutomationProperty ControlTypeProperty;
		
		public static readonly AutomationProperty CultureProperty;
		
		public static readonly AutomationProperty FrameworkIdProperty;
		
		public static readonly AutomationProperty HasKeyboardFocusProperty;
		
		public static readonly AutomationProperty HelpTextProperty;
		
		public static readonly AutomationProperty IsContentElementProperty;
		
		public static readonly AutomationProperty IsControlElementProperty;
		
		public static readonly AutomationProperty IsDockPatternAvailableProperty;
		
		public static readonly AutomationProperty IsEnabledProperty;
		
		public static readonly AutomationProperty IsExpandCollapsePatternAvailableProperty;
		
		public static readonly AutomationProperty IsGridItemPatternAvailableProperty;
		
		public static readonly AutomationProperty IsGridPatternAvailableProperty;
		
		public static readonly AutomationProperty IsInvokePatternAvailableProperty;
		
		public static readonly AutomationProperty IsKeyboardFocusableProperty;
		
		public static readonly AutomationProperty IsMultipleViewPatternAvailableProperty;
		
		public static readonly AutomationProperty IsOffscreenProperty;
		
		public static readonly AutomationProperty IsPasswordProperty;
		
		public static readonly AutomationProperty IsRangeValuePatternAvailableProperty;
		
		public static readonly AutomationProperty IsRequiredForFormProperty;
		
		public static readonly AutomationProperty IsScrollItemPatternAvailableProperty;
		
		public static readonly AutomationProperty IsScrollPatternAvailableProperty;
		
		public static readonly AutomationProperty IsSelectionItemPatternAvailableProperty;
		
		public static readonly AutomationProperty IsSelectionPatternAvailableProperty;
		
		public static readonly AutomationProperty IsTableItemPatternAvailableProperty;
		
		public static readonly AutomationProperty IsTablePatternAvailableProperty;
		
		public static readonly AutomationProperty IsTextPatternAvailableProperty;
		
		public static readonly AutomationProperty IsTogglePatternAvailableProperty;
		
		public static readonly AutomationProperty IsTransformPatternAvailableProperty;
		
		public static readonly AutomationProperty IsValuePatternAvailableProperty;
		
		public static readonly AutomationProperty IsWindowPatternAvailableProperty;
		
		public static readonly AutomationProperty ItemStatusProperty;
		
		public static readonly AutomationProperty ItemTypeProperty;
		
		public static readonly AutomationProperty LabeledByProperty;
		
		public static readonly AutomationEvent LayoutInvalidatedEvent;
		
		public static readonly AutomationProperty LocalizedControlTypeProperty;
		
		public static readonly AutomationEvent MenuClosedEvent;
		
		public static readonly AutomationEvent MenuOpenedEvent;
		
		public static readonly AutomationProperty NameProperty;
		
		public static readonly AutomationProperty NativeWindowHandleProperty;
		
		public static readonly Object NotSupported;
		
		public static readonly AutomationProperty OrientationProperty;
		
		public static readonly AutomationProperty ProcessIdProperty;
		
		public static readonly AutomationProperty RuntimeIdProperty;
		
		public static readonly AutomationEvent StructureChangedEvent;
		
		public static readonly AutomationEvent ToolTipClosedEvent;
		
		public static readonly AutomationEvent ToolTipOpenedEvent;
		
#endregion
	}
}
