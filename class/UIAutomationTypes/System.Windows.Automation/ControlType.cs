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
//	  Sandy Armstrong <sanfordarmstrong@gmail.com>
// 

using System;

namespace System.Windows.Automation
{
	public class ControlType : AutomationIdentifier
	{
#region Private Fields
		
		private string localizedControlType;
		
#endregion
		
#region Protected Constructor
		
		protected ControlType (int id, string programmaticName) :
			base (id, programmaticName)
		{
		}
		
#endregion
		
#region Public Methods
		
		public AutomationPattern [] GetNeverSupportedPatterns ()
		{
			throw new NotImplementedException ();
		}
		
		public AutomationProperty [] GetRequiredProperties ()
		{
			throw new NotImplementedException ();
		}
		
		public AutomationPattern [][] GetRequiredPatternSets ()
		{
			throw new NotImplementedException ();
		}
		
#endregion
		
#region Public Properties
		
		public string LocalizedControlType
		{
			get {
				return localizedControlType;
			}
		}
		
#endregion
		
#region Internal Constants
		
		internal const int WindowId = 0;
		
#endregion
		
#region Static Members
		
		static ControlType ()
		{
			// TODO: Initialize Fields
			// TODO: Figure out IDs via test
			Window = LookupById (WindowId);
		}
		
		public static ControlType LookupById (int id)
		{
			if (id == WindowId)
				return new ControlType (id, "Window");
			else
				return null;
		}
		
		public static readonly ControlType Button;
		public static readonly ControlType Calendar;
		public static readonly ControlType CheckBox;
		public static readonly ControlType ComboBox;
		public static readonly ControlType Custom;
		public static readonly ControlType DataGrid;
		public static readonly ControlType DataItem;
		public static readonly ControlType Document;
		public static readonly ControlType Edit;
		public static readonly ControlType Group;
		public static readonly ControlType Header;
		public static readonly ControlType HeaderItem;
		public static readonly ControlType Hyperlink;
		public static readonly ControlType Image;
		public static readonly ControlType List;
		public static readonly ControlType ListItem;
		public static readonly ControlType Menu;
		public static readonly ControlType MenuBar;
		public static readonly ControlType MenuItem;
		public static readonly ControlType Pane;
		public static readonly ControlType ProgressBar;
		public static readonly ControlType RadioButton;
		public static readonly ControlType ScrollBar;
		public static readonly ControlType Separator;
		public static readonly ControlType Slider;
		public static readonly ControlType Spinner;
		public static readonly ControlType SplitButton;
		public static readonly ControlType StatusBar;
		public static readonly ControlType Tab;
		public static readonly ControlType TabItem;
		public static readonly ControlType Table;
		public static readonly ControlType Text;
		public static readonly ControlType Thumb;
		public static readonly ControlType TitleBar;
		public static readonly ControlType ToolBar;
		public static readonly ControlType ToolTip;
		public static readonly ControlType Tree;
		public static readonly ControlType TreeItem;
		public static readonly ControlType Window;
		
#endregion
	}
}

