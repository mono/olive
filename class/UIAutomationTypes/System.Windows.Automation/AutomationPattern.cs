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
#region Protected Constructor
		
		protected AutomationPattern (int id, string programmaticName) :
			base (id, programmaticName)
		{
		}
		
#endregion
		
#region Internal Constants
	
		internal const int ExpandCollapsePatternId = 10005;
		internal const int GridPatternId = 10006;
		internal const int InvokePatternId = 10000;
		internal const int MultipleViewPatternId = 10008;
		internal const int RangeValuePatternId = 10003;
		internal const int ScrollPatternId = 10004;
		internal const int SelectionItemPatternId = 10010;
		internal const int SelectionPatternId = 10001;
		internal const int TablePatternId = 10012;
		internal const int TextPatternId = 10014;
		internal const int TogglePatternId = 10015;
		internal const int TransformPatternId = 10016;
		internal const int ValuePatternId = 10002;
		internal const int WindowPatternId = 10009;
		
		internal static readonly AutomationPattern ExpandCollapsePattern;
		internal static readonly AutomationPattern GridPattern;
		internal static readonly AutomationPattern InvokePattern;
		internal static readonly AutomationPattern MultipleViewPattern;
		internal static readonly AutomationPattern RangeValuePattern;
		internal static readonly AutomationPattern ScrollPattern;
		internal static readonly AutomationPattern SelectionItemPattern;
		internal static readonly AutomationPattern SelectionPattern;
		internal static readonly AutomationPattern TablePattern;
		internal static readonly AutomationPattern TextPattern;
		internal static readonly AutomationPattern TogglePattern;
		internal static readonly AutomationPattern TransformPattern;
		internal static readonly AutomationPattern ValuePattern;
		internal static readonly AutomationPattern WindowPattern;
		
#endregion
		
#region Public Static Methods
		
		static AutomationPattern ()
		{
			ExpandCollapsePattern =
				new AutomationPattern (ExpandCollapsePatternId,
				                       "ExpandCollapsePatternIdentifiers.Pattern");
			GridPattern =
				new AutomationPattern (GridPatternId,
				                       "GridPatternIdentifiers.Pattern");
			InvokePattern =
				new AutomationPattern (InvokePatternId,
				                       "InvokePatternIdentifiers.Pattern");
			MultipleViewPattern =
				new AutomationPattern (MultipleViewPatternId,
				                       "MultipleViewPatternIdentifiers.Pattern");
			RangeValuePattern =
				new AutomationPattern (RangeValuePatternId,
				                       "RangeValuePatternIdentifiers.Pattern");
			ScrollPattern =
				new AutomationPattern (ScrollPatternId,
				                       "ScrollPatternIdentifiers.Pattern");
			SelectionItemPattern =
				new AutomationPattern (SelectionItemPatternId,
				                       "SelectionItemPatternIdentifiers.Pattern");
			SelectionPattern =
				new AutomationPattern (SelectionPatternId,
				                       "SelectionPatternIdentifiers.Pattern");
			TablePattern =
				new AutomationPattern (TablePatternId,
				                       "TablePatternIdentifiers.Pattern");
			TextPattern =
				new AutomationPattern (TextPatternId,
				                       "TextPatternIdentifiers.Pattern");
			TogglePattern =
				new AutomationPattern (TogglePatternId,
				                       "TogglePatternIdentifiers.Pattern");
			TransformPattern =
				new AutomationPattern (TransformPatternId,
				                       "TransformPatternIdentifiers.Pattern");
			ValuePattern =
				new AutomationPattern (ValuePatternId, 
				                       "ValuePatternIdentifiers.Pattern");
			WindowPattern =
				new AutomationPattern (WindowPatternId,
				                       "WindowPatternIdentifiers.Pattern");
		}
		
		public static AutomationPattern LookupById (int id)
		{
			if (id == ExpandCollapsePatternId)
				return ExpandCollapsePattern;
			else if (id == GridPatternId)
				return GridPattern;
			else if (id == InvokePatternId)
				return InvokePattern;
			else if (id == MultipleViewPatternId)
				return MultipleViewPattern;
			else if (id == RangeValuePatternId)
				return RangeValuePattern;
			else if (id == ScrollPatternId)
				return ScrollPattern;
			else if (id == SelectionItemPatternId)
				return SelectionItemPattern;
			else if (id == SelectionPatternId)
				return SelectionPattern;
			else if (id == TablePatternId)
				return TablePattern;
			else if (id == TextPatternId)
				return TextPattern;
			else if (id == TogglePatternId)
				return TogglePattern;
			else if (id == TransformPatternId)
				return TransformPattern;
			else if (id == ValuePatternId)
				return ValuePattern;
			else if (id == WindowPatternId)
				return WindowPattern;
			else
				return null;
		}
		
#endregion
	}
}
