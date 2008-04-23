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
	public class AutomationPattern : AutomationIdentifier
	{
#region Internal Constructor
		
		internal AutomationPattern (int id, string programmaticName) :
			base (id, programmaticName)
		{
		}
		
#endregion
		
#region Public Static Methods
		
		public static AutomationPattern LookupById (int id)
		{
			if (id == ExpandCollapsePatternIdentifiers.PatternId)
				return ExpandCollapsePatternIdentifiers.Pattern;
			else if (id == GridPatternIdentifiers.PatternId)
				return GridPatternIdentifiers.Pattern;
			else if (id == InvokePatternIdentifiers.PatternId)
				return InvokePatternIdentifiers.Pattern;
			else if (id == MultipleViewPatternIdentifiers.PatternId)
				return MultipleViewPatternIdentifiers.Pattern;
			else if (id == RangeValuePatternIdentifiers.PatternId)
				return RangeValuePatternIdentifiers.Pattern;
			else if (id == ScrollPatternIdentifiers.PatternId)
				return ScrollPatternIdentifiers.Pattern;
			else if (id == SelectionItemPatternIdentifiers.PatternId)
				return SelectionItemPatternIdentifiers.Pattern;
			else if (id == SelectionPatternIdentifiers.PatternId)
				return SelectionPatternIdentifiers.Pattern;
			else if (id == TablePatternIdentifiers.PatternId)
				return TablePatternIdentifiers.Pattern;
			else if (id == TextPatternIdentifiers.PatternId)
				return TextPatternIdentifiers.Pattern;
			else if (id == TogglePatternIdentifiers.PatternId)
				return TogglePatternIdentifiers.Pattern;
			else if (id == TransformPatternIdentifiers.PatternId)
				return TransformPatternIdentifiers.Pattern;
			else if (id == ValuePatternIdentifiers.PatternId)
				return ValuePatternIdentifiers.Pattern;
			else if (id == WindowPatternIdentifiers.PatternId)
				return WindowPatternIdentifiers.Pattern;
			else
				return null;
		}
		
#endregion
	}
}
