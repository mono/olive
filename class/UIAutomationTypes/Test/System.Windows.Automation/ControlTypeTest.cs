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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Automation;

using NUnit.Framework;

namespace MonoTests.System.Windows.Automation {

	[TestFixture]
	public class ControlTypeTest {

		[Test]
		public void ButtonTest ()
		{
			ControlType myButton = ControlType.Button;
			Assert.AreEqual (
				50000,
				myButton.Id,
				"Id");
			Assert.AreEqual (
				"button",
				myButton.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Button",
				myButton.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myButton.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myButton.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {InvokePatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myButton.GetRequiredPatternSets ());

		}

		[Test]
		public void CalendarTest ()
		{
			ControlType myCalendar = ControlType.Calendar;
			Assert.AreEqual (
				50001,
				myCalendar.Id,
				"Id");
			Assert.AreEqual (
				"calendar",
				myCalendar.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Calendar",
				myCalendar.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myCalendar.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myCalendar.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {GridPatternIdentifiers.Pattern, ValuePatternIdentifiers.Pattern, SelectionPatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myCalendar.GetRequiredPatternSets ());

		}

		[Test]
		public void CheckBoxTest ()
		{
			ControlType myCheckBox = ControlType.CheckBox;
			Assert.AreEqual (
				50002,
				myCheckBox.Id,
				"Id");
			Assert.AreEqual (
				"check box",
				myCheckBox.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.CheckBox",
				myCheckBox.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myCheckBox.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myCheckBox.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {TogglePatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myCheckBox.GetRequiredPatternSets ());

		}

		[Test]
		public void ComboBoxTest ()
		{
			ControlType myComboBox = ControlType.ComboBox;
			Assert.AreEqual (
				50003,
				myComboBox.Id,
				"Id");
			Assert.AreEqual (
				"combo box",
				myComboBox.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.ComboBox",
				myComboBox.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myComboBox.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myComboBox.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {SelectionPatternIdentifiers.Pattern, ExpandCollapsePatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myComboBox.GetRequiredPatternSets ());

		}

		[Test]
		public void EditTest ()
		{
			ControlType myEdit = ControlType.Edit;
			Assert.AreEqual (
				50004,
				myEdit.Id,
				"Id");
			Assert.AreEqual (
				"edit",
				myEdit.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Edit",
				myEdit.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myEdit.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myEdit.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {ValuePatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myEdit.GetRequiredPatternSets ());

		}

		[Test]
		public void HyperlinkTest ()
		{
			ControlType myHyperlink = ControlType.Hyperlink;
			Assert.AreEqual (
				50005,
				myHyperlink.Id,
				"Id");
			Assert.AreEqual (
				"hyperlink",
				myHyperlink.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Hyperlink",
				myHyperlink.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myHyperlink.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myHyperlink.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {InvokePatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myHyperlink.GetRequiredPatternSets ());

		}

		[Test]
		public void ImageTest ()
		{
			ControlType myImage = ControlType.Image;
			Assert.AreEqual (
				50006,
				myImage.Id,
				"Id");
			Assert.AreEqual (
				"image",
				myImage.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Image",
				myImage.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myImage.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myImage.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myImage.GetRequiredPatternSets ());

		}

		[Test]
		public void ListItemTest ()
		{
			ControlType myListItem = ControlType.ListItem;
			Assert.AreEqual (
				50007,
				myListItem.Id,
				"Id");
			Assert.AreEqual (
				"list item",
				myListItem.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.ListItem",
				myListItem.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myListItem.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myListItem.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {SelectionItemPatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myListItem.GetRequiredPatternSets ());

		}

		[Test]
		public void ListTest ()
		{
			ControlType myList = ControlType.List;
			Assert.AreEqual (
				50008,
				myList.Id,
				"Id");
			Assert.AreEqual (
				"list view",
				myList.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.List",
				myList.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myList.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myList.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {SelectionPatternIdentifiers.Pattern, TablePatternIdentifiers.Pattern, GridPatternIdentifiers.Pattern, MultipleViewPatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myList.GetRequiredPatternSets ());

		}

		[Test]
		public void MenuTest ()
		{
			ControlType myMenu = ControlType.Menu;
			Assert.AreEqual (
				50009,
				myMenu.Id,
				"Id");
			Assert.AreEqual (
				"menu",
				myMenu.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Menu",
				myMenu.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myMenu.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myMenu.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myMenu.GetRequiredPatternSets ());

		}

		[Test]
		public void MenuBarTest ()
		{
			ControlType myMenuBar = ControlType.MenuBar;
			Assert.AreEqual (
				50010,
				myMenuBar.Id,
				"Id");
			Assert.AreEqual (
				"menu bar",
				myMenuBar.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.MenuBar",
				myMenuBar.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myMenuBar.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myMenuBar.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myMenuBar.GetRequiredPatternSets ());

		}

		[Test]
		public void MenuItemTest ()
		{
			ControlType myMenuItem = ControlType.MenuItem;
			Assert.AreEqual (
				50011,
				myMenuItem.Id,
				"Id");
			Assert.AreEqual (
				"menu item",
				myMenuItem.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.MenuItem",
				myMenuItem.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myMenuItem.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myMenuItem.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {InvokePatternIdentifiers.Pattern}, 
				new AutomationIdentifier [] {ExpandCollapsePatternIdentifiers.Pattern}, 
				new AutomationIdentifier [] {TogglePatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myMenuItem.GetRequiredPatternSets ());

		}

		[Test]
		public void ProgressBarTest ()
		{
			ControlType myProgressBar = ControlType.ProgressBar;
			Assert.AreEqual (
				50012,
				myProgressBar.Id,
				"Id");
			Assert.AreEqual (
				"progress bar",
				myProgressBar.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.ProgressBar",
				myProgressBar.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myProgressBar.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myProgressBar.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {ValuePatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myProgressBar.GetRequiredPatternSets ());

		}

		[Test]
		public void RadioButtonTest ()
		{
			ControlType myRadioButton = ControlType.RadioButton;
			Assert.AreEqual (
				50013,
				myRadioButton.Id,
				"Id");
			Assert.AreEqual (
				"radio button",
				myRadioButton.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.RadioButton",
				myRadioButton.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myRadioButton.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myRadioButton.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myRadioButton.GetRequiredPatternSets ());

		}

		[Test]
		public void ScrollBarTest ()
		{
			ControlType myScrollBar = ControlType.ScrollBar;
			Assert.AreEqual (
				50014,
				myScrollBar.Id,
				"Id");
			Assert.AreEqual (
				"scroll bar",
				myScrollBar.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.ScrollBar",
				myScrollBar.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myScrollBar.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myScrollBar.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myScrollBar.GetRequiredPatternSets ());

		}

		[Test]
		public void SliderTest ()
		{
			ControlType mySlider = ControlType.Slider;
			Assert.AreEqual (
				50015,
				mySlider.Id,
				"Id");
			Assert.AreEqual (
				"slider",
				mySlider.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Slider",
				mySlider.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				mySlider.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				mySlider.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {RangeValuePatternIdentifiers.Pattern}, 
				new AutomationIdentifier [] {SelectionPatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				mySlider.GetRequiredPatternSets ());

		}

		[Test]
		public void SpinnerTest ()
		{
			ControlType mySpinner = ControlType.Spinner;
			Assert.AreEqual (
				50016,
				mySpinner.Id,
				"Id");
			Assert.AreEqual (
				"spinner",
				mySpinner.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Spinner",
				mySpinner.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				mySpinner.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				mySpinner.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {RangeValuePatternIdentifiers.Pattern}, 
				new AutomationIdentifier [] {SelectionPatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				mySpinner.GetRequiredPatternSets ());

		}

		[Test]
		public void StatusBarTest ()
		{
			ControlType myStatusBar = ControlType.StatusBar;
			Assert.AreEqual (
				50017,
				myStatusBar.Id,
				"Id");
			Assert.AreEqual (
				"status bar",
				myStatusBar.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.StatusBar",
				myStatusBar.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myStatusBar.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myStatusBar.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myStatusBar.GetRequiredPatternSets ());

		}

		[Test]
		public void TabTest ()
		{
			ControlType myTab = ControlType.Tab;
			Assert.AreEqual (
				50018,
				myTab.Id,
				"Id");
			Assert.AreEqual (
				"tab",
				myTab.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Tab",
				myTab.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myTab.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myTab.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myTab.GetRequiredPatternSets ());

		}

		[Test]
		public void TabItemTest ()
		{
			ControlType myTabItem = ControlType.TabItem;
			Assert.AreEqual (
				50019,
				myTabItem.Id,
				"Id");
			Assert.AreEqual (
				"tab item",
				myTabItem.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.TabItem",
				myTabItem.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myTabItem.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myTabItem.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myTabItem.GetRequiredPatternSets ());

		}

		[Test]
		public void TextTest ()
		{
			ControlType myText = ControlType.Text;
			Assert.AreEqual (
				50020,
				myText.Id,
				"Id");
			Assert.AreEqual (
				"text",
				myText.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Text",
				myText.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myText.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myText.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myText.GetRequiredPatternSets ());

		}

		[Test]
		public void ToolBarTest ()
		{
			ControlType myToolBar = ControlType.ToolBar;
			Assert.AreEqual (
				50021,
				myToolBar.Id,
				"Id");
			Assert.AreEqual (
				"tool bar",
				myToolBar.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.ToolBar",
				myToolBar.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myToolBar.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myToolBar.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myToolBar.GetRequiredPatternSets ());

		}

		[Test]
		public void ToolTipTest ()
		{
			ControlType myToolTip = ControlType.ToolTip;
			Assert.AreEqual (
				50022,
				myToolTip.Id,
				"Id");
			Assert.AreEqual (
				"tool tip",
				myToolTip.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.ToolTip",
				myToolTip.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myToolTip.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myToolTip.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myToolTip.GetRequiredPatternSets ());

		}

		[Test]
		public void TreeTest ()
		{
			ControlType myTree = ControlType.Tree;
			Assert.AreEqual (
				50023,
				myTree.Id,
				"Id");
			Assert.AreEqual (
				"tree view",
				myTree.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Tree",
				myTree.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myTree.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myTree.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myTree.GetRequiredPatternSets ());

		}

		[Test]
		public void TreeItemTest ()
		{
			ControlType myTreeItem = ControlType.TreeItem;
			Assert.AreEqual (
				50024,
				myTreeItem.Id,
				"Id");
			Assert.AreEqual (
				"tree view item",
				myTreeItem.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.TreeItem",
				myTreeItem.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myTreeItem.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myTreeItem.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myTreeItem.GetRequiredPatternSets ());

		}

		[Test]
		public void CustomTest ()
		{
			ControlType myCustom = ControlType.Custom;
			Assert.AreEqual (
				50025,
				myCustom.Id,
				"Id");
			Assert.AreEqual (
				"custom",
				myCustom.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Custom",
				myCustom.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myCustom.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myCustom.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myCustom.GetRequiredPatternSets ());

		}

		[Test]
		public void GroupTest ()
		{
			ControlType myGroup = ControlType.Group;
			Assert.AreEqual (
				50026,
				myGroup.Id,
				"Id");
			Assert.AreEqual (
				"group",
				myGroup.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Group",
				myGroup.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myGroup.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myGroup.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myGroup.GetRequiredPatternSets ());

		}

		[Test]
		public void ThumbTest ()
		{
			ControlType myThumb = ControlType.Thumb;
			Assert.AreEqual (
				50027,
				myThumb.Id,
				"Id");
			Assert.AreEqual (
				"thumb",
				myThumb.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Thumb",
				myThumb.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myThumb.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myThumb.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myThumb.GetRequiredPatternSets ());

		}

		[Test]
		public void DataGridTest ()
		{
			ControlType myDataGrid = ControlType.DataGrid;
			Assert.AreEqual (
				50028,
				myDataGrid.Id,
				"Id");
			Assert.AreEqual (
				"datagrid",
				myDataGrid.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.DataGrid",
				myDataGrid.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myDataGrid.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myDataGrid.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {GridPatternIdentifiers.Pattern}, 
				new AutomationIdentifier [] {SelectionPatternIdentifiers.Pattern}, 
				new AutomationIdentifier [] {TablePatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myDataGrid.GetRequiredPatternSets ());

		}

		[Test]
		public void DataItemTest ()
		{
			ControlType myDataItem = ControlType.DataItem;
			Assert.AreEqual (
				50029,
				myDataItem.Id,
				"Id");
			Assert.AreEqual (
				"dataitem",
				myDataItem.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.DataItem",
				myDataItem.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myDataItem.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myDataItem.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {SelectionItemPatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myDataItem.GetRequiredPatternSets ());

		}

		[Test]
		public void DocumentTest ()
		{
			ControlType myDocument = ControlType.Document;
			Assert.AreEqual (
				50030,
				myDocument.Id,
				"Id");
			Assert.AreEqual (
				"document",
				myDocument.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Document",
				myDocument.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { ValuePatternIdentifiers.Pattern };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myDocument.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myDocument.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {ScrollPatternIdentifiers.Pattern}, 
				new AutomationIdentifier [] {TextPatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myDocument.GetRequiredPatternSets ());

		}

		[Test]
		public void SplitButtonTest ()
		{
			ControlType mySplitButton = ControlType.SplitButton;
			Assert.AreEqual (
				50031,
				mySplitButton.Id,
				"Id");
			Assert.AreEqual (
				"split button",
				mySplitButton.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.SplitButton",
				mySplitButton.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				mySplitButton.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				mySplitButton.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {InvokePatternIdentifiers.Pattern}, 
				new AutomationIdentifier [] {ExpandCollapsePatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				mySplitButton.GetRequiredPatternSets ());

		}

		[Test]
		public void WindowTest ()
		{
			ControlType myWindow = ControlType.Window;
			Assert.AreEqual (
				50032,
				myWindow.Id,
				"Id");
			Assert.AreEqual (
				"window",
				myWindow.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Window",
				myWindow.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myWindow.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myWindow.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {TransformPatternIdentifiers.Pattern}, 
				new AutomationIdentifier [] {WindowPatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myWindow.GetRequiredPatternSets ());

		}

		[Test]
		public void PaneTest ()
		{
			ControlType myPane = ControlType.Pane;
			Assert.AreEqual (
				50033,
				myPane.Id,
				"Id");
			Assert.AreEqual (
				"pane",
				myPane.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Pane",
				myPane.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myPane.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myPane.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {TransformPatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myPane.GetRequiredPatternSets ());

		}

		[Test]
		public void HeaderTest ()
		{
			ControlType myHeader = ControlType.Header;
			Assert.AreEqual (
				50034,
				myHeader.Id,
				"Id");
			Assert.AreEqual (
				"header",
				myHeader.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Header",
				myHeader.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myHeader.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myHeader.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myHeader.GetRequiredPatternSets ());

		}

		[Test]
		public void HeaderItemTest ()
		{
			ControlType myHeaderItem = ControlType.HeaderItem;
			Assert.AreEqual (
				50035,
				myHeaderItem.Id,
				"Id");
			Assert.AreEqual (
				"header item",
				myHeaderItem.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.HeaderItem",
				myHeaderItem.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myHeaderItem.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myHeaderItem.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myHeaderItem.GetRequiredPatternSets ());

		}

		[Test]
		public void TableTest ()
		{
			ControlType myTable = ControlType.Table;
			Assert.AreEqual (
				50036,
				myTable.Id,
				"Id");
			Assert.AreEqual (
				"table",
				myTable.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Table",
				myTable.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myTable.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myTable.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] {
				new AutomationIdentifier [] {GridPatternIdentifiers.Pattern}, 
				new AutomationIdentifier [] {SelectionPatternIdentifiers.Pattern}, 
				new AutomationIdentifier [] {TablePatternIdentifiers.Pattern}};
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myTable.GetRequiredPatternSets ());

		}

		[Test]
		public void TitleBarTest ()
		{
			ControlType myTitleBar = ControlType.TitleBar;
			Assert.AreEqual (
				50037,
				myTitleBar.Id,
				"Id");
			Assert.AreEqual (
				"title bar",
				myTitleBar.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.TitleBar",
				myTitleBar.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				myTitleBar.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				myTitleBar.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				myTitleBar.GetRequiredPatternSets ());

		}

		[Test]
		public void SeparatorTest ()
		{
			ControlType mySeparator = ControlType.Separator;
			Assert.AreEqual (
				50038,
				mySeparator.Id,
				"Id");
			Assert.AreEqual (
				"separator",
				mySeparator.LocalizedControlType,
				"LocalizedControlType");
			Assert.AreEqual (
				"ControlType.Separator",
				mySeparator.ProgrammaticName,
				"ProgrammaticName");
			AutomationIdentifier [] expectedNeverSupportedPatternIds = { };
			TestAutomationIdentifierLists (
				expectedNeverSupportedPatternIds,
				mySeparator.GetNeverSupportedPatterns ());
			AutomationIdentifier [] expectedRequiredPropertyIds = { };
			TestAutomationIdentifierLists (
				expectedRequiredPropertyIds,
				mySeparator.GetRequiredProperties ());
			AutomationIdentifier [] [] expectedRequiredPatternSets = new AutomationIdentifier [] [] { };
			TestAutomationIdentifierListLists (
				expectedRequiredPatternSets,
				mySeparator.GetRequiredPatternSets ());

		}

		private static void TestAutomationIdentifierListLists (AutomationIdentifier [] [] expectedIdentifierIdsArray, Array actualIdentifiers)
		{
			List<AutomationIdentifier []> expectedIdentifierIdArrays =
				new List<AutomationIdentifier []> (expectedIdentifierIdsArray);
			Assert.AreEqual (expectedIdentifierIdsArray.Length, actualIdentifiers.Length, "Length mismatch");
			foreach (Array identifierArray in actualIdentifiers) {
				int matchingIndex = -1;
				for (int i = 0; i < expectedIdentifierIdArrays.Count; i++) {
					AutomationIdentifier [] ids = expectedIdentifierIdArrays [i];
					try {
						TestAutomationIdentifierLists (ids, identifierArray);
						matchingIndex = i;
						break;
					} catch (AssertionException) { }
				}
				if (matchingIndex >= 0) {
					expectedIdentifierIdArrays.RemoveAt (matchingIndex);
				} else {
					IEnumerable<string> expectedIds = from AutomationIdentifier x in identifierArray select x.ProgrammaticName;
					string expectedIdList = GetCommaSeparatedList (expectedIds);
					Assert.Fail ("Did not expect array: " + expectedIdList);
				}
			}

			if (expectedIdentifierIdArrays.Count > 0)
				Assert.Fail (
					"Missed {0} expected arrays.  Here's the first one: {1}",
					expectedIdentifierIdArrays.Count,
					GetCommaSeparatedList (expectedIdentifierIdArrays [0]));
		}

		private static void TestAutomationIdentifierLists (AutomationIdentifier [] expectedIdentifierIdsArray, Array actualIdentifiers)
		{
			List<AutomationIdentifier> expectedIdentifierIds =
				new List<AutomationIdentifier> (expectedIdentifierIdsArray);

			Assert.AreEqual (
				expectedIdentifierIds.Count,
				actualIdentifiers.Length,
				"Length mismatch.");
			foreach (AutomationIdentifier identifier in actualIdentifiers) {
				int matchingIndex = -1;
				for (int i = 0; i < expectedIdentifierIds.Count; i++) {
					AutomationIdentifier id = expectedIdentifierIds [i];
					if (identifier == id) {
						matchingIndex = i;
						break;
					}
				}
				if (matchingIndex >= 0)
					expectedIdentifierIds.RemoveAt (matchingIndex);
				else
					Assert.Fail (string.Format (
						"Did not expect \"{0}\" with id \"{1}\"",
						identifier.ProgrammaticName,
						identifier.Id));
			}

			if (expectedIdentifierIds.Count > 0) {
				string ids = string.Empty;
				for (int i = 0; i < expectedIdentifierIds.Count; i++) {
					ids += expectedIdentifierIds [i].ToString ();
					if (i < expectedIdentifierIds.Count - 1)
						ids += ", ";
				}
				Assert.Fail ("Expected the following additional identifiers: {0}", ids);
			}
		}

		private static string GetCommaSeparatedList<T> (IEnumerable<T> collection)
		{
			IList<T> itemList = new List<T> (collection);
			string output = string.Empty;
			for (int i = 0; i < itemList.Count; i++) {
				output += itemList [i].ToString ();
				if (i < itemList.Count - 1)
					output += ", ";
			}
			return output;
		}

	}
}



