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
using System.Windows;
using System.Windows.Input;
using NUnit.Framework;

namespace MonoTests.System.Windows.Input {

	[TestFixture]
	public class ApplicationCommandsTest {

		void CommandTest (RoutedUICommand cmd,
				  string text, string name, InputGesture[] gestures)
		{
			Assert.AreEqual (cmd.OwnerType, typeof (ApplicationCommands));
			Assert.AreEqual (text, cmd.Text);
			Assert.AreEqual (name, cmd.Name);
			if (gestures == null) {
				Assert.AreEqual (0, cmd.InputGestures.Count);
			}
			else {
				Assert.AreEqual (gestures.Length, cmd.InputGestures.Count);
				for (int i = 0; i < gestures.Length; i ++) {
					Assert.AreEqual (gestures[i], cmd.InputGestures[i]);
				}
			}
		}

		[Test]
		public void TestCommands ()
		{
			CommandTest (ApplicationCommands.CancelPrint, "Cancel Print", "CancelPrint", null);
			CommandTest (ApplicationCommands.Close, "Close", "Close", null);
			CommandTest (ApplicationCommands.ContextMenu, "Context Menu", "ContextMenu",
				     new InputGesture[] { new KeyGesture (Key.F10, ModifierKeys.Shift, "Shift+F10"),
							  new KeyGesture (Key.Apps, ModifierKeys.None, "Apps") });
			CommandTest (ApplicationCommands.Copy, "Copy", "Copy",
				     new InputGesture[] { new KeyGesture (Key.C, ModifierKeys.Control, "Ctrl+C"),
							  new KeyGesture (Key.Insert, ModifierKeys.Shift, "Shift+Insert") });
			CommandTest (ApplicationCommands.CorrectionList, "Correction List", "CorrectionList", null);
			CommandTest (ApplicationCommands.Cut, "Cut", "Cut",
				     new InputGesture[] { new KeyGesture (Key.X, ModifierKeys.Control, "Ctrl+X"),
							  new KeyGesture (Key.Delete, ModifierKeys.Shift, "Shift+Delete") });
			CommandTest (ApplicationCommands.Delete, "Delete", "Delete",
				     new InputGesture[] { new KeyGesture (Key.Delete, ModifierKeys.None, "Del") });
			CommandTest (ApplicationCommands.Find, "Find", "Find",
				     new InputGesture[] { new KeyGesture (Key.F, ModifierKeys.Control, "Ctrl+F") });
			CommandTest (ApplicationCommands.Help, "Help", "Help",
				     new InputGesture[] { new KeyGesture (Key.F1, ModifierKeys.Control, "Ctrl+F1") });
			CommandTest (ApplicationCommands.New, "New", "New",
				     new InputGesture[] { new KeyGesture (Key.N, ModifierKeys.Control, "Ctrl+N") });
			CommandTest (ApplicationCommands.NotACommand, "Not a Command", "NotACommand", null);
			CommandTest (ApplicationCommands.Open, "Open", "Open",
				     new InputGesture[] { new KeyGesture (Key.O, ModifierKeys.Control, "Ctrl+O") });
			CommandTest (ApplicationCommands.Paste, "Paste", "Paste",
				     new InputGesture[] { new KeyGesture (Key.V, ModifierKeys.Control, "Ctrl+V"),
							  new KeyGesture (Key.Insert, ModifierKeys.Shift, "Shift+Insert") });
			CommandTest (ApplicationCommands.Print, "Print", "Print",
				     new InputGesture[] { new KeyGesture (Key.P, ModifierKeys.Control, "Ctrl+P") });
			CommandTest (ApplicationCommands.PrintPreview, "Print Preview", "PrintPreview",
				     new InputGesture[] { new KeyGesture (Key.F2, ModifierKeys.Control, "Ctrl+F2") });
			CommandTest (ApplicationCommands.Properties, "Properties", "Properties",
				     new InputGesture[] { new KeyGesture (Key.F4, ModifierKeys.None, "F4") });
			CommandTest (ApplicationCommands.Redo, "Redo", "Redo",
				     new InputGesture[] { new KeyGesture (Key.Y, ModifierKeys.Control, "Ctrl+Y") });
			CommandTest (ApplicationCommands.Replace, "Replace", "Replace",
				     new InputGesture[] { new KeyGesture (Key.H, ModifierKeys.Control, "Ctrl+H") });
			CommandTest (ApplicationCommands.Save, "Save", "Save",
				     new InputGesture[] { new KeyGesture (Key.S, ModifierKeys.Control, "Ctrl+S") });
			CommandTest (ApplicationCommands.SaveAs, "Save As", "SaveAs", null);
			CommandTest (ApplicationCommands.SelectAll, "Select All", "SelectAll",
				     new InputGesture[] { new KeyGesture (Key.A, ModifierKeys.Control, "Ctrl+A") });
			CommandTest (ApplicationCommands.Stop, "Stop", "Stop",
				     new InputGesture[] { new KeyGesture (Key.Escape, ModifierKeys.None, "Esc") });
			CommandTest (ApplicationCommands.Undo, "Undo", "Undo",
				     new InputGesture[] { new KeyGesture (Key.Z, ModifierKeys.Control, "Ctrl+Z") });
		}
	}

}
