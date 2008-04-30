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
	public class AutomationEvent : AutomationIdentifier
	{
#region Internal Constructor
		
		internal AutomationEvent (int id, string programmaticName) :
			base (id, programmaticName)
		{
		}
		
#endregion
		
#region Public Static Methods
		
		public static AutomationEvent LookupById (int id)
		{
			if (id == InvokePatternIdentifiers.InvokedEventId)
				return InvokePatternIdentifiers.InvokedEvent;
			else if (id == AutomationElementIdentifiers.AsyncContentLoadedEventId)
				return AutomationElementIdentifiers.AsyncContentLoadedEvent;
			else if (id == AutomationElementIdentifiers.AutomationFocusChangedEventId)
				return AutomationElementIdentifiers.AutomationFocusChangedEvent;
			else if (id == AutomationElementIdentifiers.AutomationPropertyChangedEventId)
				return AutomationElementIdentifiers.AutomationPropertyChangedEvent;
			else if (id == AutomationElementIdentifiers.LayoutInvalidatedEventId)
				return AutomationElementIdentifiers.LayoutInvalidatedEvent;
			else if (id == AutomationElementIdentifiers.MenuClosedEventId)
				return AutomationElementIdentifiers.MenuClosedEvent;
			else if (id == AutomationElementIdentifiers.MenuOpenedEventId)
				return AutomationElementIdentifiers.MenuOpenedEvent;
			else if (id == AutomationElementIdentifiers.StructureChangedEventId)
				return AutomationElementIdentifiers.StructureChangedEvent;
			else if (id == AutomationElementIdentifiers.ToolTipClosedEventId)
				return AutomationElementIdentifiers.ToolTipClosedEvent;
			else if (id == AutomationElementIdentifiers.ToolTipOpenedEventId)
				return AutomationElementIdentifiers.ToolTipOpenedEvent;
			else if (id == SelectionItemPatternIdentifiers.ElementAddedToSelectionEventId)
				return SelectionItemPatternIdentifiers.ElementAddedToSelectionEvent;
			else if (id == SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEventId)
				return SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent;
			else if (id == SelectionItemPatternIdentifiers.ElementSelectedEventId)
				return SelectionItemPatternIdentifiers.ElementSelectedEvent;
			else
				return null;
		}
		
#endregion
	}
}
