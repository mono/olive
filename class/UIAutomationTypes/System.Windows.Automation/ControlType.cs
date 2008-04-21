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
		private AutomationPattern [] neverSupportedPatterns;
		private AutomationProperty [] requiredProperties;
		private AutomationPattern [][] requiredPatternSets;
		
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
			return neverSupportedPatterns;
		}
		
		public AutomationProperty [] GetRequiredProperties ()
		{
			return requiredProperties;
		}
		
		public AutomationPattern [][] GetRequiredPatternSets ()
		{
			return requiredPatternSets;
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
		
		internal const int ButtonId = 50000;
		internal const int CalendarId = 50001;
		internal const int CheckBoxId = 50002;
		internal const int ComboBoxId = 50003;
		internal const int CustomId = 50025;
		internal const int DataGridId = 50028;
		internal const int DataItemId = 50029;
		internal const int DocumentId = 0;
		internal const int EditId = 0;
		internal const int GroupId = 0;
		internal const int HeaderId = 0;
		internal const int HeaderItemId = 0;
		internal const int HyperlinkId = 0;
		internal const int ImageId = 0;
		internal const int ListId = 0;
		internal const int ListItemId = 0;
		internal const int MenuId = 0;
		internal const int MenuBarId = 0;
		internal const int MenuItemId = 0;
		internal const int PaneId = 0;
		internal const int ProgressBarId = 0;
		internal const int RadioButtonId = 0;
		internal const int ScrollBarId = 0;
		internal const int SeparatorId = 0;
		internal const int SliderId = 0;
		internal const int SpinnerId = 0;
		internal const int SplitButtonId = 0;
		internal const int StatusBarId = 0;
		internal const int TabId = 0;
		internal const int TabItemId = 0;
		internal const int TableId = 0;
		internal const int TextId = 0;
		internal const int ThumbId = 0;
		internal const int TitleBarId = 0;
		internal const int ToolBarId = 0;
		internal const int ToolTipId = 0;
		internal const int TreeId = 0;
		internal const int TreeItemId = 0;
		internal const int WindowId = 0;
		
#endregion
		
#region Static Members
		
		static ControlType ()
		{
			Window = new ControlType (WindowId, "Window");
			
			Button = new ControlType (ButtonId, "ControlType.Button");
			Button.localizedControlType = "button";
			Button.neverSupportedPatterns = new AutomationPattern [] {};
			Button.requiredProperties = new AutomationProperty [] {};
			Button.requiredPatternSets = new AutomationPattern [] [] {
				new AutomationPattern [] {
					InvokePatternIdentifiers.Pattern}};
			
			Calendar = new ControlType (CalendarId, "ControlType.Calendar");
			Calendar.localizedControlType = "calendar";
			Calendar.neverSupportedPatterns = new AutomationPattern [] {};
			Calendar.requiredProperties = new AutomationProperty [] {};
			Calendar.requiredPatternSets = new AutomationPattern [] [] {
				new AutomationPattern [] {
					GridPatternIdentifiers.Pattern,
					ValuePatternIdentifiers.Pattern,
					SelectionPatternIdentifiers.Pattern}};
			
			CheckBox = new ControlType (CheckBoxId, "ControlType.CheckBox");
			CheckBox.localizedControlType = "check box";
			CheckBox.neverSupportedPatterns = new AutomationPattern [] {};
			CheckBox.requiredProperties = new AutomationProperty [] {};
			CheckBox.requiredPatternSets = new AutomationPattern [] [] {
				new AutomationPattern [] {
					TogglePatternIdentifiers.Pattern}};
			
			ComboBox = new ControlType (ComboBoxId, "ControlType.ComboBox");
			ComboBox.localizedControlType = "combo box";
			ComboBox.neverSupportedPatterns = new AutomationPattern [] {};
			ComboBox.requiredProperties = new AutomationProperty [] {};
			ComboBox.requiredPatternSets = new AutomationPattern [] [] {
				new AutomationPattern [] {
					SelectionPatternIdentifiers.Pattern,
					ExpandCollapsePatternIdentifiers.Pattern}};
			
			Custom = new ControlType (CustomId, "ControlType.Custom");
			Custom.localizedControlType = "custom";
			Custom.neverSupportedPatterns = new AutomationPattern [] {};
			Custom.requiredProperties = new AutomationProperty [] {};
			Custom.requiredPatternSets = new AutomationPattern [] [] {};
			
			DataGrid = new ControlType (DataGridId, "ControlType.DataGrid");
			DataGrid.localizedControlType = "datagrid";
			DataGrid.neverSupportedPatterns = new AutomationPattern [] {};
			DataGrid.requiredProperties = new AutomationProperty [] {};
			DataGrid.requiredPatternSets = new AutomationPattern [] [] {
				new AutomationPattern [] {
					SelectionPatternIdentifiers.Pattern},
				new AutomationPattern [] {
					GridPatternIdentifiers.Pattern},
				new AutomationPattern [] {
					TablePatternIdentifiers.Pattern}};
			
			DataItem = new ControlType (DataItemId, "ControlType.DataItem");
			DataItem.localizedControlType = "dataitem";
			DataItem.neverSupportedPatterns = new AutomationPattern [] {};
			DataItem.requiredProperties = new AutomationProperty [] {};
			DataItem.requiredPatternSets = new AutomationPattern [] [] {};
		}
		
		public static ControlType LookupById (int id)
		{
			if (id == WindowId)
				return Window;
			else if (id == ButtonId)
				return Button;
			else if (id == CalendarId)
				return Calendar;
			else if (id == CheckBoxId)
				return CheckBox;
			else if (id == ComboBoxId)
				return ComboBox;
			else if (id == CustomId)
				return Custom;
			else if (id == DataGridId)
				return DataGrid;
			else if (id == DataItemId)
				return DataItem;
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

