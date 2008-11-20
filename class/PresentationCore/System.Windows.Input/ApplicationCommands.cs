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

namespace System.Windows.Input {

	public static class ApplicationCommands {
		static RoutedUICommand cancelPrint;
		static RoutedUICommand close;
		static RoutedUICommand contextMenu;
		static RoutedUICommand copy;
		static RoutedUICommand correctionList;
		static RoutedUICommand cut;
		static RoutedUICommand delete;
		static RoutedUICommand find;
		static RoutedUICommand help;
		static RoutedUICommand new_;

		public static RoutedUICommand CancelPrint {
			get {
				if (cancelPrint == null)
					cancelPrint = new RoutedUICommand ("Cancel Print", "CancelPrint", typeof (ApplicationCommands), new InputGestureCollection());
				return cancelPrint;
			}
		}

		public static RoutedUICommand Close {
			get {
				if (close == null)
					close = new RoutedUICommand ("Close", "Close", typeof (ApplicationCommands), new InputGestureCollection());
				return close;
			}
		}

		public static RoutedUICommand ContextMenu {
			get {
				if (contextMenu == null) {
					InputGestureCollection gestures = new InputGestureCollection ();
					gestures.AddRange (new InputGesture[] { new KeyGesture (Key.F10, ModifierKeys.Shift, "Shift+F10"),
										new KeyGesture (Key.Apps, ModifierKeys.None, "Apps") });
					contextMenu = new RoutedUICommand ("Context Menu", "ContextMenu",
									   typeof (ApplicationCommands),
									   gestures);
				}
				return contextMenu;
			}
		}

		public static RoutedUICommand Copy {
			get {
				if (copy == null) {
					InputGestureCollection gestures = new InputGestureCollection ();
					gestures.AddRange (new InputGesture[] { new KeyGesture (Key.C, ModifierKeys.Control, "Ctrl+C"),
										new KeyGesture (Key.Insert, ModifierKeys.Shift, "Shift+Insert") });
					copy = new RoutedUICommand ("Copy", "Copy",
								    typeof (ApplicationCommands),
								    gestures);
				}
				return copy;
			}
		}

		public static RoutedUICommand CorrectionList {
			get {
				if (correctionList == null)
					correctionList = new RoutedUICommand ("Correction List", "CorrectionList",
									      typeof (ApplicationCommands), new InputGestureCollection());
				return correctionList;
			}
		}

		public static RoutedUICommand Cut {
			get {
				if (cut == null) {
					InputGestureCollection gestures = new InputGestureCollection ();
					gestures.AddRange (new InputGesture[] { new KeyGesture (Key.X, ModifierKeys.Control, "Ctrl+X"),
										new KeyGesture (Key.Delete, ModifierKeys.Shift, "Shift+Delete") });
					cut = new RoutedUICommand ("Cut", "Cut",
								    typeof (ApplicationCommands),
								    gestures);
				}
				return cut;
			}
		}

		public static RoutedUICommand Delete {
			get {
				if (delete == null) {
					InputGestureCollection gestures = new InputGestureCollection ();
					gestures.Add (new KeyGesture (Key.Delete, ModifierKeys.None, "Del"));
					delete = new RoutedUICommand ("Delete", "Delete",
								    typeof (ApplicationCommands),
								    gestures);
				}
				return delete;
			}
		}

		public static RoutedUICommand Find {
			get {
				if (find == null) {
					InputGestureCollection gestures = new InputGestureCollection ();
					gestures.Add (new KeyGesture (Key.F, ModifierKeys.Control, "Ctrl+F"));
					find = new RoutedUICommand ("Find", "Find",
								    typeof (ApplicationCommands),
								    gestures);
				}
				return find;
			}
		}

		public static RoutedUICommand Help {
			get {
				if (help == null) {
					InputGestureCollection gestures = new InputGestureCollection ();
					gestures.Add (new KeyGesture (Key.F1, ModifierKeys.Control, "Ctrl+F1"));
					help = new RoutedUICommand ("Help", "Help",
								    typeof (ApplicationCommands),
								    gestures);
				}
				return help;
			}
		}

		public static RoutedUICommand New {
			get {
				if (new_ == null) {
					InputGestureCollection gestures = new InputGestureCollection ();
					gestures.Add (new KeyGesture (Key.N, ModifierKeys.Control, "Ctrl+N"));
					new_ = new RoutedUICommand ("New", "New",
								    typeof (ApplicationCommands),
								    gestures);
				}
				return new_;
			}
		}

		public static RoutedUICommand NotACommand {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand Open {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand Paste {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand Print {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand PrintPreview {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand Properties {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand Redo {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand Replace {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand Save {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand SaveAs {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand SelectAll {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand Stop {
			get { throw new NotImplementedException (); }
		}

		public static RoutedUICommand Undo {
			get { throw new NotImplementedException (); }
		}
	}
}
