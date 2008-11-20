using NUnit.Framework;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
#if notyet
using System.Windows.Media.Media3D;
#endif

// Assembly: PresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
//   Type: System.Windows.Input.AccessKeyManager
namespace MonoTests.System.Windows.Input {
	public partial class AccessKeyManagerTest {
		[Test]
		public void RoutedEvents () {
			Assert.AreEqual (typeof (AccessKeyManager), AccessKeyManager.AccessKeyPressedEvent.OwnerType);
			Assert.AreEqual ("AccessKeyPressed", AccessKeyManager.AccessKeyPressedEvent.Name);
			Assert.AreEqual ("AccessKeyManager.AccessKeyPressed", AccessKeyManager.AccessKeyPressedEvent.ToString());
			Assert.AreEqual (typeof (AccessKeyPressedEventHandler), AccessKeyManager.AccessKeyPressedEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, AccessKeyManager.AccessKeyPressedEvent.RoutingStrategy);

		}
	}
}
//   Type: System.Windows.Input.CommandManager
namespace MonoTests.System.Windows.Input {
	public partial class CommandManagerTest {
		[Test]
		public void RoutedEvents () {
			Assert.AreEqual (typeof (CommandManager), CommandManager.PreviewExecutedEvent.OwnerType);
			Assert.AreEqual ("PreviewExecuted", CommandManager.PreviewExecutedEvent.Name);
			Assert.AreEqual ("CommandManager.PreviewExecuted", CommandManager.PreviewExecutedEvent.ToString());
			Assert.AreEqual (typeof (ExecutedRoutedEventHandler), CommandManager.PreviewExecutedEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, CommandManager.PreviewExecutedEvent.RoutingStrategy);

			Assert.AreEqual (typeof (CommandManager), CommandManager.ExecutedEvent.OwnerType);
			Assert.AreEqual ("Executed", CommandManager.ExecutedEvent.Name);
			Assert.AreEqual ("CommandManager.Executed", CommandManager.ExecutedEvent.ToString());
			Assert.AreEqual (typeof (ExecutedRoutedEventHandler), CommandManager.ExecutedEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, CommandManager.ExecutedEvent.RoutingStrategy);

			Assert.AreEqual (typeof (CommandManager), CommandManager.PreviewCanExecuteEvent.OwnerType);
			Assert.AreEqual ("PreviewCanExecute", CommandManager.PreviewCanExecuteEvent.Name);
			Assert.AreEqual ("CommandManager.PreviewCanExecute", CommandManager.PreviewCanExecuteEvent.ToString());
			Assert.AreEqual (typeof (CanExecuteRoutedEventHandler), CommandManager.PreviewCanExecuteEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, CommandManager.PreviewCanExecuteEvent.RoutingStrategy);

			Assert.AreEqual (typeof (CommandManager), CommandManager.CanExecuteEvent.OwnerType);
			Assert.AreEqual ("CanExecute", CommandManager.CanExecuteEvent.Name);
			Assert.AreEqual ("CommandManager.CanExecute", CommandManager.CanExecuteEvent.ToString());
			Assert.AreEqual (typeof (CanExecuteRoutedEventHandler), CommandManager.CanExecuteEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, CommandManager.CanExecuteEvent.RoutingStrategy);

		}
	}
}
//   Type: System.Windows.ContentElement
namespace MonoTests.System.Windows {
	public partial class ContentElementTest {
		[Test]
		public void RoutedEvents () {
			Assert.AreSame (ContentElement.GotFocusEvent, FocusManager.GotFocusEvent);
			Assert.AreSame (ContentElement.LostFocusEvent, FocusManager.LostFocusEvent);
			Assert.AreSame (ContentElement.PreviewMouseDownEvent, Mouse.PreviewMouseDownEvent);
			Assert.AreSame (ContentElement.MouseDownEvent, Mouse.MouseDownEvent);
			Assert.AreSame (ContentElement.PreviewMouseUpEvent, Mouse.PreviewMouseUpEvent);
			Assert.AreSame (ContentElement.MouseUpEvent, Mouse.MouseUpEvent);
			Assert.AreSame (ContentElement.PreviewMouseLeftButtonDownEvent, UIElement.PreviewMouseLeftButtonDownEvent);
			Assert.AreSame (ContentElement.MouseLeftButtonDownEvent, UIElement.MouseLeftButtonDownEvent);
			Assert.AreSame (ContentElement.PreviewMouseLeftButtonUpEvent, UIElement.PreviewMouseLeftButtonUpEvent);
			Assert.AreSame (ContentElement.MouseLeftButtonUpEvent, UIElement.MouseLeftButtonUpEvent);
			Assert.AreSame (ContentElement.PreviewMouseRightButtonDownEvent, UIElement.PreviewMouseRightButtonDownEvent);
			Assert.AreSame (ContentElement.MouseRightButtonDownEvent, UIElement.MouseRightButtonDownEvent);
			Assert.AreSame (ContentElement.PreviewMouseRightButtonUpEvent, UIElement.PreviewMouseRightButtonUpEvent);
			Assert.AreSame (ContentElement.MouseRightButtonUpEvent, UIElement.MouseRightButtonUpEvent);
			Assert.AreSame (ContentElement.PreviewMouseMoveEvent, Mouse.PreviewMouseMoveEvent);
			Assert.AreSame (ContentElement.MouseMoveEvent, Mouse.MouseMoveEvent);
			Assert.AreSame (ContentElement.PreviewMouseWheelEvent, Mouse.PreviewMouseWheelEvent);
			Assert.AreSame (ContentElement.MouseWheelEvent, Mouse.MouseWheelEvent);
			Assert.AreSame (ContentElement.MouseEnterEvent, Mouse.MouseEnterEvent);
			Assert.AreSame (ContentElement.MouseLeaveEvent, Mouse.MouseLeaveEvent);
			Assert.AreSame (ContentElement.GotMouseCaptureEvent, Mouse.GotMouseCaptureEvent);
			Assert.AreSame (ContentElement.LostMouseCaptureEvent, Mouse.LostMouseCaptureEvent);
			Assert.AreSame (ContentElement.QueryCursorEvent, Mouse.QueryCursorEvent);
			Assert.AreSame (ContentElement.PreviewStylusDownEvent, Stylus.PreviewStylusDownEvent);
			Assert.AreSame (ContentElement.StylusDownEvent, Stylus.StylusDownEvent);
			Assert.AreSame (ContentElement.PreviewStylusUpEvent, Stylus.PreviewStylusUpEvent);
			Assert.AreSame (ContentElement.StylusUpEvent, Stylus.StylusUpEvent);
			Assert.AreSame (ContentElement.PreviewStylusMoveEvent, Stylus.PreviewStylusMoveEvent);
			Assert.AreSame (ContentElement.StylusMoveEvent, Stylus.StylusMoveEvent);
			Assert.AreSame (ContentElement.PreviewStylusInAirMoveEvent, Stylus.PreviewStylusInAirMoveEvent);
			Assert.AreSame (ContentElement.StylusInAirMoveEvent, Stylus.StylusInAirMoveEvent);
			Assert.AreSame (ContentElement.StylusEnterEvent, Stylus.StylusEnterEvent);
			Assert.AreSame (ContentElement.StylusLeaveEvent, Stylus.StylusLeaveEvent);
			Assert.AreSame (ContentElement.PreviewStylusInRangeEvent, Stylus.PreviewStylusInRangeEvent);
			Assert.AreSame (ContentElement.StylusInRangeEvent, Stylus.StylusInRangeEvent);
			Assert.AreSame (ContentElement.PreviewStylusOutOfRangeEvent, Stylus.PreviewStylusOutOfRangeEvent);
			Assert.AreSame (ContentElement.StylusOutOfRangeEvent, Stylus.StylusOutOfRangeEvent);
			Assert.AreSame (ContentElement.PreviewStylusSystemGestureEvent, Stylus.PreviewStylusSystemGestureEvent);
			Assert.AreSame (ContentElement.StylusSystemGestureEvent, Stylus.StylusSystemGestureEvent);
			Assert.AreSame (ContentElement.GotStylusCaptureEvent, Stylus.GotStylusCaptureEvent);
			Assert.AreSame (ContentElement.LostStylusCaptureEvent, Stylus.LostStylusCaptureEvent);
			Assert.AreSame (ContentElement.StylusButtonDownEvent, Stylus.StylusButtonDownEvent);
			Assert.AreSame (ContentElement.StylusButtonUpEvent, Stylus.StylusButtonUpEvent);
			Assert.AreSame (ContentElement.PreviewStylusButtonDownEvent, Stylus.PreviewStylusButtonDownEvent);
			Assert.AreSame (ContentElement.PreviewStylusButtonUpEvent, Stylus.PreviewStylusButtonUpEvent);
			Assert.AreSame (ContentElement.PreviewKeyDownEvent, Keyboard.PreviewKeyDownEvent);
			Assert.AreSame (ContentElement.KeyDownEvent, Keyboard.KeyDownEvent);
			Assert.AreSame (ContentElement.PreviewKeyUpEvent, Keyboard.PreviewKeyUpEvent);
			Assert.AreSame (ContentElement.KeyUpEvent, Keyboard.KeyUpEvent);
			Assert.AreSame (ContentElement.PreviewGotKeyboardFocusEvent, Keyboard.PreviewGotKeyboardFocusEvent);
			Assert.AreSame (ContentElement.GotKeyboardFocusEvent, Keyboard.GotKeyboardFocusEvent);
			Assert.AreSame (ContentElement.PreviewLostKeyboardFocusEvent, Keyboard.PreviewLostKeyboardFocusEvent);
			Assert.AreSame (ContentElement.LostKeyboardFocusEvent, Keyboard.LostKeyboardFocusEvent);
			Assert.AreSame (ContentElement.PreviewTextInputEvent, TextCompositionManager.PreviewTextInputEvent);
			Assert.AreSame (ContentElement.TextInputEvent, TextCompositionManager.TextInputEvent);
			Assert.AreSame (ContentElement.PreviewQueryContinueDragEvent, DragDrop.PreviewQueryContinueDragEvent);
			Assert.AreSame (ContentElement.QueryContinueDragEvent, DragDrop.QueryContinueDragEvent);
			Assert.AreSame (ContentElement.PreviewGiveFeedbackEvent, DragDrop.PreviewGiveFeedbackEvent);
			Assert.AreSame (ContentElement.GiveFeedbackEvent, DragDrop.GiveFeedbackEvent);
			Assert.AreSame (ContentElement.PreviewDragEnterEvent, DragDrop.PreviewDragEnterEvent);
			Assert.AreSame (ContentElement.DragEnterEvent, DragDrop.DragEnterEvent);
			Assert.AreSame (ContentElement.PreviewDragOverEvent, DragDrop.PreviewDragOverEvent);
			Assert.AreSame (ContentElement.DragOverEvent, DragDrop.DragOverEvent);
			Assert.AreSame (ContentElement.PreviewDragLeaveEvent, DragDrop.PreviewDragLeaveEvent);
			Assert.AreSame (ContentElement.DragLeaveEvent, DragDrop.DragLeaveEvent);
			Assert.AreSame (ContentElement.PreviewDropEvent, DragDrop.PreviewDropEvent);
			Assert.AreSame (ContentElement.DropEvent, DragDrop.DropEvent);
		}
	}
}
//   Type: System.Windows.DataObject
namespace MonoTests.System.Windows {
	public partial class DataObjectTest {
		[Test]
		public void RoutedEvents () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (DataObject), DataObject.CopyingEvent.OwnerType);
			Assert.AreEqual ("Copying", DataObject.CopyingEvent.Name);
			Assert.AreEqual ("DataObject.Copying", DataObject.CopyingEvent.ToString());
			Assert.AreEqual (typeof (DataObjectCopyingEventHandler), DataObject.CopyingEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DataObject.CopyingEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DataObject), DataObject.PastingEvent.OwnerType);
			Assert.AreEqual ("Pasting", DataObject.PastingEvent.Name);
			Assert.AreEqual ("DataObject.Pasting", DataObject.PastingEvent.ToString());
			Assert.AreEqual (typeof (DataObjectPastingEventHandler), DataObject.PastingEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DataObject.PastingEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DataObject), DataObject.SettingDataEvent.OwnerType);
			Assert.AreEqual ("SettingData", DataObject.SettingDataEvent.Name);
			Assert.AreEqual ("DataObject.SettingData", DataObject.SettingDataEvent.ToString());
			Assert.AreEqual (typeof (DataObjectSettingDataEventHandler), DataObject.SettingDataEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DataObject.SettingDataEvent.RoutingStrategy);
#endif
		}
	}
}
//   Type: System.Windows.DragDrop
namespace MonoTests.System.Windows {
	public partial class DragDropTest {
		[Test]
		public void RoutedEvents () {
			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewQueryContinueDragEvent.OwnerType);
			Assert.AreEqual ("PreviewQueryContinueDrag", DragDrop.PreviewQueryContinueDragEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewQueryContinueDrag", DragDrop.PreviewQueryContinueDragEvent.ToString());
			Assert.AreEqual (typeof (QueryContinueDragEventHandler), DragDrop.PreviewQueryContinueDragEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewQueryContinueDragEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.QueryContinueDragEvent.OwnerType);
			Assert.AreEqual ("QueryContinueDrag", DragDrop.QueryContinueDragEvent.Name);
			Assert.AreEqual ("DragDrop.QueryContinueDrag", DragDrop.QueryContinueDragEvent.ToString());
			Assert.AreEqual (typeof (QueryContinueDragEventHandler), DragDrop.QueryContinueDragEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.QueryContinueDragEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewGiveFeedbackEvent.OwnerType);
			Assert.AreEqual ("PreviewGiveFeedback", DragDrop.PreviewGiveFeedbackEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewGiveFeedback", DragDrop.PreviewGiveFeedbackEvent.ToString());
			Assert.AreEqual (typeof (GiveFeedbackEventHandler), DragDrop.PreviewGiveFeedbackEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewGiveFeedbackEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.GiveFeedbackEvent.OwnerType);
			Assert.AreEqual ("GiveFeedback", DragDrop.GiveFeedbackEvent.Name);
			Assert.AreEqual ("DragDrop.GiveFeedback", DragDrop.GiveFeedbackEvent.ToString());
			Assert.AreEqual (typeof (GiveFeedbackEventHandler), DragDrop.GiveFeedbackEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.GiveFeedbackEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewDragEnterEvent.OwnerType);
			Assert.AreEqual ("PreviewDragEnter", DragDrop.PreviewDragEnterEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewDragEnter", DragDrop.PreviewDragEnterEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.PreviewDragEnterEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewDragEnterEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.DragEnterEvent.OwnerType);
			Assert.AreEqual ("DragEnter", DragDrop.DragEnterEvent.Name);
			Assert.AreEqual ("DragDrop.DragEnter", DragDrop.DragEnterEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.DragEnterEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.DragEnterEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewDragOverEvent.OwnerType);
			Assert.AreEqual ("PreviewDragOver", DragDrop.PreviewDragOverEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewDragOver", DragDrop.PreviewDragOverEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.PreviewDragOverEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewDragOverEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.DragOverEvent.OwnerType);
			Assert.AreEqual ("DragOver", DragDrop.DragOverEvent.Name);
			Assert.AreEqual ("DragDrop.DragOver", DragDrop.DragOverEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.DragOverEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.DragOverEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewDragLeaveEvent.OwnerType);
			Assert.AreEqual ("PreviewDragLeave", DragDrop.PreviewDragLeaveEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewDragLeave", DragDrop.PreviewDragLeaveEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.PreviewDragLeaveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewDragLeaveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.DragLeaveEvent.OwnerType);
			Assert.AreEqual ("DragLeave", DragDrop.DragLeaveEvent.Name);
			Assert.AreEqual ("DragDrop.DragLeave", DragDrop.DragLeaveEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.DragLeaveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.DragLeaveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewDropEvent.OwnerType);
			Assert.AreEqual ("PreviewDrop", DragDrop.PreviewDropEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewDrop", DragDrop.PreviewDropEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.PreviewDropEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewDropEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.DropEvent.OwnerType);
			Assert.AreEqual ("Drop", DragDrop.DropEvent.Name);
			Assert.AreEqual ("DragDrop.Drop", DragDrop.DropEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.DropEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.DropEvent.RoutingStrategy);

		}
	}
}
//   Type: System.Windows.Input.FocusManager
namespace MonoTests.System.Windows.Input {
	public partial class FocusManagerTest {
		[Test]
		public void RoutedEvents () {
			Assert.AreEqual (typeof (FocusManager), FocusManager.GotFocusEvent.OwnerType);
			Assert.AreEqual ("GotFocus", FocusManager.GotFocusEvent.Name);
			Assert.AreEqual ("FocusManager.GotFocus", FocusManager.GotFocusEvent.ToString());
			Assert.AreEqual (typeof (RoutedEventHandler), FocusManager.GotFocusEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, FocusManager.GotFocusEvent.RoutingStrategy);

			Assert.AreEqual (typeof (FocusManager), FocusManager.LostFocusEvent.OwnerType);
			Assert.AreEqual ("LostFocus", FocusManager.LostFocusEvent.Name);
			Assert.AreEqual ("FocusManager.LostFocus", FocusManager.LostFocusEvent.ToString());
			Assert.AreEqual (typeof (RoutedEventHandler), FocusManager.LostFocusEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, FocusManager.LostFocusEvent.RoutingStrategy);

		}
	}
}
//   Type: System.Windows.Input.Keyboard
namespace MonoTests.System.Windows.Input {
	public partial class KeyboardTest {
		[Test]
		public void RoutedEvents () {
			Assert.AreEqual (typeof (Keyboard), Keyboard.PreviewKeyDownEvent.OwnerType);
			Assert.AreEqual ("PreviewKeyDown", Keyboard.PreviewKeyDownEvent.Name);
			Assert.AreEqual ("Keyboard.PreviewKeyDown", Keyboard.PreviewKeyDownEvent.ToString());
			Assert.AreEqual (typeof (KeyEventHandler), Keyboard.PreviewKeyDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Keyboard.PreviewKeyDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.KeyDownEvent.OwnerType);
			Assert.AreEqual ("KeyDown", Keyboard.KeyDownEvent.Name);
			Assert.AreEqual ("Keyboard.KeyDown", Keyboard.KeyDownEvent.ToString());
			Assert.AreEqual (typeof (KeyEventHandler), Keyboard.KeyDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Keyboard.KeyDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.PreviewKeyUpEvent.OwnerType);
			Assert.AreEqual ("PreviewKeyUp", Keyboard.PreviewKeyUpEvent.Name);
			Assert.AreEqual ("Keyboard.PreviewKeyUp", Keyboard.PreviewKeyUpEvent.ToString());
			Assert.AreEqual (typeof (KeyEventHandler), Keyboard.PreviewKeyUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Keyboard.PreviewKeyUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.KeyUpEvent.OwnerType);
			Assert.AreEqual ("KeyUp", Keyboard.KeyUpEvent.Name);
			Assert.AreEqual ("Keyboard.KeyUp", Keyboard.KeyUpEvent.ToString());
			Assert.AreEqual (typeof (KeyEventHandler), Keyboard.KeyUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Keyboard.KeyUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.PreviewGotKeyboardFocusEvent.OwnerType);
			Assert.AreEqual ("PreviewGotKeyboardFocus", Keyboard.PreviewGotKeyboardFocusEvent.Name);
			Assert.AreEqual ("Keyboard.PreviewGotKeyboardFocus", Keyboard.PreviewGotKeyboardFocusEvent.ToString());
			Assert.AreEqual (typeof (KeyboardFocusChangedEventHandler), Keyboard.PreviewGotKeyboardFocusEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Keyboard.PreviewGotKeyboardFocusEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.GotKeyboardFocusEvent.OwnerType);
			Assert.AreEqual ("GotKeyboardFocus", Keyboard.GotKeyboardFocusEvent.Name);
			Assert.AreEqual ("Keyboard.GotKeyboardFocus", Keyboard.GotKeyboardFocusEvent.ToString());
			Assert.AreEqual (typeof (KeyboardFocusChangedEventHandler), Keyboard.GotKeyboardFocusEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Keyboard.GotKeyboardFocusEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.PreviewLostKeyboardFocusEvent.OwnerType);
			Assert.AreEqual ("PreviewLostKeyboardFocus", Keyboard.PreviewLostKeyboardFocusEvent.Name);
			Assert.AreEqual ("Keyboard.PreviewLostKeyboardFocus", Keyboard.PreviewLostKeyboardFocusEvent.ToString());
			Assert.AreEqual (typeof (KeyboardFocusChangedEventHandler), Keyboard.PreviewLostKeyboardFocusEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Keyboard.PreviewLostKeyboardFocusEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Keyboard), Keyboard.LostKeyboardFocusEvent.OwnerType);
			Assert.AreEqual ("LostKeyboardFocus", Keyboard.LostKeyboardFocusEvent.Name);
			Assert.AreEqual ("Keyboard.LostKeyboardFocus", Keyboard.LostKeyboardFocusEvent.ToString());
			Assert.AreEqual (typeof (KeyboardFocusChangedEventHandler), Keyboard.LostKeyboardFocusEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Keyboard.LostKeyboardFocusEvent.RoutingStrategy);

		}
	}
}
//   Type: System.Windows.Input.Mouse
namespace MonoTests.System.Windows.Input {
	public partial class MouseTest {
		[Test]
		public void RoutedEvents () {
			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseMoveEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseMove", Mouse.PreviewMouseMoveEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseMove", Mouse.PreviewMouseMoveEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.PreviewMouseMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseMoveEvent.OwnerType);
			Assert.AreEqual ("MouseMove", Mouse.MouseMoveEvent.Name);
			Assert.AreEqual ("Mouse.MouseMove", Mouse.MouseMoveEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.MouseMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.MouseMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseDownOutsideCapturedElementEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseDownOutsideCapturedElement", Mouse.PreviewMouseDownOutsideCapturedElementEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseDownOutsideCapturedElement", Mouse.PreviewMouseDownOutsideCapturedElementEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.PreviewMouseDownOutsideCapturedElementEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseDownOutsideCapturedElementEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseUpOutsideCapturedElementEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseUpOutsideCapturedElement", Mouse.PreviewMouseUpOutsideCapturedElementEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseUpOutsideCapturedElement", Mouse.PreviewMouseUpOutsideCapturedElementEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.PreviewMouseUpOutsideCapturedElementEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseUpOutsideCapturedElementEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseDownEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseDown", Mouse.PreviewMouseDownEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseDown", Mouse.PreviewMouseDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.PreviewMouseDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseDownEvent.OwnerType);
			Assert.AreEqual ("MouseDown", Mouse.MouseDownEvent.Name);
			Assert.AreEqual ("Mouse.MouseDown", Mouse.MouseDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.MouseDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.MouseDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseUpEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseUp", Mouse.PreviewMouseUpEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseUp", Mouse.PreviewMouseUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.PreviewMouseUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseUpEvent.OwnerType);
			Assert.AreEqual ("MouseUp", Mouse.MouseUpEvent.Name);
			Assert.AreEqual ("Mouse.MouseUp", Mouse.MouseUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), Mouse.MouseUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.MouseUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.PreviewMouseWheelEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseWheel", Mouse.PreviewMouseWheelEvent.Name);
			Assert.AreEqual ("Mouse.PreviewMouseWheel", Mouse.PreviewMouseWheelEvent.ToString());
			Assert.AreEqual (typeof (MouseWheelEventHandler), Mouse.PreviewMouseWheelEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Mouse.PreviewMouseWheelEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseWheelEvent.OwnerType);
			Assert.AreEqual ("MouseWheel", Mouse.MouseWheelEvent.Name);
			Assert.AreEqual ("Mouse.MouseWheel", Mouse.MouseWheelEvent.ToString());
			Assert.AreEqual (typeof (MouseWheelEventHandler), Mouse.MouseWheelEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.MouseWheelEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseEnterEvent.OwnerType);
			Assert.AreEqual ("MouseEnter", Mouse.MouseEnterEvent.Name);
			Assert.AreEqual ("Mouse.MouseEnter", Mouse.MouseEnterEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.MouseEnterEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, Mouse.MouseEnterEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.MouseLeaveEvent.OwnerType);
			Assert.AreEqual ("MouseLeave", Mouse.MouseLeaveEvent.Name);
			Assert.AreEqual ("Mouse.MouseLeave", Mouse.MouseLeaveEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.MouseLeaveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, Mouse.MouseLeaveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.GotMouseCaptureEvent.OwnerType);
			Assert.AreEqual ("GotMouseCapture", Mouse.GotMouseCaptureEvent.Name);
			Assert.AreEqual ("Mouse.GotMouseCapture", Mouse.GotMouseCaptureEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.GotMouseCaptureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.GotMouseCaptureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.LostMouseCaptureEvent.OwnerType);
			Assert.AreEqual ("LostMouseCapture", Mouse.LostMouseCaptureEvent.Name);
			Assert.AreEqual ("Mouse.LostMouseCapture", Mouse.LostMouseCaptureEvent.ToString());
			Assert.AreEqual (typeof (MouseEventHandler), Mouse.LostMouseCaptureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.LostMouseCaptureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Mouse), Mouse.QueryCursorEvent.OwnerType);
			Assert.AreEqual ("QueryCursor", Mouse.QueryCursorEvent.Name);
			Assert.AreEqual ("Mouse.QueryCursor", Mouse.QueryCursorEvent.ToString());
			Assert.AreEqual (typeof (QueryCursorEventHandler), Mouse.QueryCursorEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Mouse.QueryCursorEvent.RoutingStrategy);

		}
	}
}
//   Type: System.Windows.Input.Stylus
namespace MonoTests.System.Windows.Input {
	public partial class StylusTest {
		[Test]
		public void RoutedEvents () {
			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusDownEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusDown", Stylus.PreviewStylusDownEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusDown", Stylus.PreviewStylusDownEvent.ToString());
			Assert.AreEqual (typeof (StylusDownEventHandler), Stylus.PreviewStylusDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusDownEvent.OwnerType);
			Assert.AreEqual ("StylusDown", Stylus.StylusDownEvent.Name);
			Assert.AreEqual ("Stylus.StylusDown", Stylus.StylusDownEvent.ToString());
			Assert.AreEqual (typeof (StylusDownEventHandler), Stylus.StylusDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusUpEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusUp", Stylus.PreviewStylusUpEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusUp", Stylus.PreviewStylusUpEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.PreviewStylusUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusUpEvent.OwnerType);
			Assert.AreEqual ("StylusUp", Stylus.StylusUpEvent.Name);
			Assert.AreEqual ("Stylus.StylusUp", Stylus.StylusUpEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusMoveEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusMove", Stylus.PreviewStylusMoveEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusMove", Stylus.PreviewStylusMoveEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.PreviewStylusMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusMoveEvent.OwnerType);
			Assert.AreEqual ("StylusMove", Stylus.StylusMoveEvent.Name);
			Assert.AreEqual ("Stylus.StylusMove", Stylus.StylusMoveEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusInAirMoveEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusInAirMove", Stylus.PreviewStylusInAirMoveEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusInAirMove", Stylus.PreviewStylusInAirMoveEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.PreviewStylusInAirMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusInAirMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusInAirMoveEvent.OwnerType);
			Assert.AreEqual ("StylusInAirMove", Stylus.StylusInAirMoveEvent.Name);
			Assert.AreEqual ("Stylus.StylusInAirMove", Stylus.StylusInAirMoveEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusInAirMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusInAirMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusEnterEvent.OwnerType);
			Assert.AreEqual ("StylusEnter", Stylus.StylusEnterEvent.Name);
			Assert.AreEqual ("Stylus.StylusEnter", Stylus.StylusEnterEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusEnterEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, Stylus.StylusEnterEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusLeaveEvent.OwnerType);
			Assert.AreEqual ("StylusLeave", Stylus.StylusLeaveEvent.Name);
			Assert.AreEqual ("Stylus.StylusLeave", Stylus.StylusLeaveEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusLeaveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, Stylus.StylusLeaveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusInRangeEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusInRange", Stylus.PreviewStylusInRangeEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusInRange", Stylus.PreviewStylusInRangeEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.PreviewStylusInRangeEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusInRangeEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusInRangeEvent.OwnerType);
			Assert.AreEqual ("StylusInRange", Stylus.StylusInRangeEvent.Name);
			Assert.AreEqual ("Stylus.StylusInRange", Stylus.StylusInRangeEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusInRangeEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusInRangeEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusOutOfRangeEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusOutOfRange", Stylus.PreviewStylusOutOfRangeEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusOutOfRange", Stylus.PreviewStylusOutOfRangeEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.PreviewStylusOutOfRangeEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusOutOfRangeEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusOutOfRangeEvent.OwnerType);
			Assert.AreEqual ("StylusOutOfRange", Stylus.StylusOutOfRangeEvent.Name);
			Assert.AreEqual ("Stylus.StylusOutOfRange", Stylus.StylusOutOfRangeEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusOutOfRangeEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusOutOfRangeEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusSystemGestureEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusSystemGesture", Stylus.PreviewStylusSystemGestureEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusSystemGesture", Stylus.PreviewStylusSystemGestureEvent.ToString());
			Assert.AreEqual (typeof (StylusSystemGestureEventHandler), Stylus.PreviewStylusSystemGestureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusSystemGestureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusSystemGestureEvent.OwnerType);
			Assert.AreEqual ("StylusSystemGesture", Stylus.StylusSystemGestureEvent.Name);
			Assert.AreEqual ("Stylus.StylusSystemGesture", Stylus.StylusSystemGestureEvent.ToString());
			Assert.AreEqual (typeof (StylusSystemGestureEventHandler), Stylus.StylusSystemGestureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusSystemGestureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.GotStylusCaptureEvent.OwnerType);
			Assert.AreEqual ("GotStylusCapture", Stylus.GotStylusCaptureEvent.Name);
			Assert.AreEqual ("Stylus.GotStylusCapture", Stylus.GotStylusCaptureEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.GotStylusCaptureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.GotStylusCaptureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.LostStylusCaptureEvent.OwnerType);
			Assert.AreEqual ("LostStylusCapture", Stylus.LostStylusCaptureEvent.Name);
			Assert.AreEqual ("Stylus.LostStylusCapture", Stylus.LostStylusCaptureEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.LostStylusCaptureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.LostStylusCaptureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusButtonDownEvent.OwnerType);
			Assert.AreEqual ("StylusButtonDown", Stylus.StylusButtonDownEvent.Name);
			Assert.AreEqual ("Stylus.StylusButtonDown", Stylus.StylusButtonDownEvent.ToString());
			Assert.AreEqual (typeof (StylusButtonEventHandler), Stylus.StylusButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusButtonUpEvent.OwnerType);
			Assert.AreEqual ("StylusButtonUp", Stylus.StylusButtonUpEvent.Name);
			Assert.AreEqual ("Stylus.StylusButtonUp", Stylus.StylusButtonUpEvent.ToString());
			Assert.AreEqual (typeof (StylusButtonEventHandler), Stylus.StylusButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusButtonUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusButtonDownEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusButtonDown", Stylus.PreviewStylusButtonDownEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusButtonDown", Stylus.PreviewStylusButtonDownEvent.ToString());
			Assert.AreEqual (typeof (StylusButtonEventHandler), Stylus.PreviewStylusButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusButtonUpEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusButtonUp", Stylus.PreviewStylusButtonUpEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusButtonUp", Stylus.PreviewStylusButtonUpEvent.ToString());
			Assert.AreEqual (typeof (StylusButtonEventHandler), Stylus.PreviewStylusButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusButtonUpEvent.RoutingStrategy);

		}
	}
}
//   Type: System.Windows.Input.TextCompositionManager
namespace MonoTests.System.Windows.Input {
	public partial class TextCompositionManagerTest {
		[Test]
		public void RoutedEvents () {
			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.PreviewTextInputStartEvent.OwnerType);
			Assert.AreEqual ("PreviewTextInputStart", TextCompositionManager.PreviewTextInputStartEvent.Name);
			Assert.AreEqual ("TextCompositionManager.PreviewTextInputStart", TextCompositionManager.PreviewTextInputStartEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.PreviewTextInputStartEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, TextCompositionManager.PreviewTextInputStartEvent.RoutingStrategy);

			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.TextInputStartEvent.OwnerType);
			Assert.AreEqual ("TextInputStart", TextCompositionManager.TextInputStartEvent.Name);
			Assert.AreEqual ("TextCompositionManager.TextInputStart", TextCompositionManager.TextInputStartEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.TextInputStartEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, TextCompositionManager.TextInputStartEvent.RoutingStrategy);

			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.PreviewTextInputUpdateEvent.OwnerType);
			Assert.AreEqual ("PreviewTextInputUpdate", TextCompositionManager.PreviewTextInputUpdateEvent.Name);
			Assert.AreEqual ("TextCompositionManager.PreviewTextInputUpdate", TextCompositionManager.PreviewTextInputUpdateEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.PreviewTextInputUpdateEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, TextCompositionManager.PreviewTextInputUpdateEvent.RoutingStrategy);

			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.TextInputUpdateEvent.OwnerType);
			Assert.AreEqual ("TextInputUpdate", TextCompositionManager.TextInputUpdateEvent.Name);
			Assert.AreEqual ("TextCompositionManager.TextInputUpdate", TextCompositionManager.TextInputUpdateEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.TextInputUpdateEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, TextCompositionManager.TextInputUpdateEvent.RoutingStrategy);

			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.PreviewTextInputEvent.OwnerType);
			Assert.AreEqual ("PreviewTextInput", TextCompositionManager.PreviewTextInputEvent.Name);
			Assert.AreEqual ("TextCompositionManager.PreviewTextInput", TextCompositionManager.PreviewTextInputEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.PreviewTextInputEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, TextCompositionManager.PreviewTextInputEvent.RoutingStrategy);

			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.TextInputEvent.OwnerType);
			Assert.AreEqual ("TextInput", TextCompositionManager.TextInputEvent.Name);
			Assert.AreEqual ("TextCompositionManager.TextInput", TextCompositionManager.TextInputEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.TextInputEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, TextCompositionManager.TextInputEvent.RoutingStrategy);

		}
	}
}
//   Type: System.Windows.UIElement
namespace MonoTests.System.Windows {
	public partial class UIElementTest {
		[Test]
		public void RoutedEvents () {
			Assert.AreSame (UIElement.PreviewMouseDownEvent, Mouse.PreviewMouseDownEvent);
			Assert.AreSame (UIElement.MouseDownEvent, Mouse.MouseDownEvent);
			Assert.AreSame (UIElement.PreviewMouseUpEvent, Mouse.PreviewMouseUpEvent);
			Assert.AreSame (UIElement.MouseUpEvent, Mouse.MouseUpEvent);
			Assert.AreEqual (typeof (UIElement), UIElement.PreviewMouseLeftButtonDownEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseLeftButtonDown", UIElement.PreviewMouseLeftButtonDownEvent.Name);
			Assert.AreEqual ("UIElement.PreviewMouseLeftButtonDown", UIElement.PreviewMouseLeftButtonDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.PreviewMouseLeftButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.PreviewMouseLeftButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.MouseLeftButtonDownEvent.OwnerType);
			Assert.AreEqual ("MouseLeftButtonDown", UIElement.MouseLeftButtonDownEvent.Name);
			Assert.AreEqual ("UIElement.MouseLeftButtonDown", UIElement.MouseLeftButtonDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.MouseLeftButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.MouseLeftButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.PreviewMouseLeftButtonUpEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseLeftButtonUp", UIElement.PreviewMouseLeftButtonUpEvent.Name);
			Assert.AreEqual ("UIElement.PreviewMouseLeftButtonUp", UIElement.PreviewMouseLeftButtonUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.PreviewMouseLeftButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.PreviewMouseLeftButtonUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.MouseLeftButtonUpEvent.OwnerType);
			Assert.AreEqual ("MouseLeftButtonUp", UIElement.MouseLeftButtonUpEvent.Name);
			Assert.AreEqual ("UIElement.MouseLeftButtonUp", UIElement.MouseLeftButtonUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.MouseLeftButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.MouseLeftButtonUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.PreviewMouseRightButtonDownEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseRightButtonDown", UIElement.PreviewMouseRightButtonDownEvent.Name);
			Assert.AreEqual ("UIElement.PreviewMouseRightButtonDown", UIElement.PreviewMouseRightButtonDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.PreviewMouseRightButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.PreviewMouseRightButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.MouseRightButtonDownEvent.OwnerType);
			Assert.AreEqual ("MouseRightButtonDown", UIElement.MouseRightButtonDownEvent.Name);
			Assert.AreEqual ("UIElement.MouseRightButtonDown", UIElement.MouseRightButtonDownEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.MouseRightButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.MouseRightButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.PreviewMouseRightButtonUpEvent.OwnerType);
			Assert.AreEqual ("PreviewMouseRightButtonUp", UIElement.PreviewMouseRightButtonUpEvent.Name);
			Assert.AreEqual ("UIElement.PreviewMouseRightButtonUp", UIElement.PreviewMouseRightButtonUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.PreviewMouseRightButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.PreviewMouseRightButtonUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (UIElement), UIElement.MouseRightButtonUpEvent.OwnerType);
			Assert.AreEqual ("MouseRightButtonUp", UIElement.MouseRightButtonUpEvent.Name);
			Assert.AreEqual ("UIElement.MouseRightButtonUp", UIElement.MouseRightButtonUpEvent.ToString());
			Assert.AreEqual (typeof (MouseButtonEventHandler), UIElement.MouseRightButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, UIElement.MouseRightButtonUpEvent.RoutingStrategy);

			Assert.AreSame (UIElement.PreviewMouseMoveEvent, Mouse.PreviewMouseMoveEvent);
			Assert.AreSame (UIElement.MouseMoveEvent, Mouse.MouseMoveEvent);
			Assert.AreSame (UIElement.PreviewMouseWheelEvent, Mouse.PreviewMouseWheelEvent);
			Assert.AreSame (UIElement.MouseWheelEvent, Mouse.MouseWheelEvent);
			Assert.AreSame (UIElement.MouseEnterEvent, Mouse.MouseEnterEvent);
			Assert.AreSame (UIElement.MouseLeaveEvent, Mouse.MouseLeaveEvent);
			Assert.AreSame (UIElement.GotMouseCaptureEvent, Mouse.GotMouseCaptureEvent);
			Assert.AreSame (UIElement.LostMouseCaptureEvent, Mouse.LostMouseCaptureEvent);
			Assert.AreSame (UIElement.QueryCursorEvent, Mouse.QueryCursorEvent);
			Assert.AreSame (UIElement.PreviewStylusDownEvent, Stylus.PreviewStylusDownEvent);
			Assert.AreSame (UIElement.StylusDownEvent, Stylus.StylusDownEvent);
			Assert.AreSame (UIElement.PreviewStylusUpEvent, Stylus.PreviewStylusUpEvent);
			Assert.AreSame (UIElement.StylusUpEvent, Stylus.StylusUpEvent);
			Assert.AreSame (UIElement.PreviewStylusMoveEvent, Stylus.PreviewStylusMoveEvent);
			Assert.AreSame (UIElement.StylusMoveEvent, Stylus.StylusMoveEvent);
			Assert.AreSame (UIElement.PreviewStylusInAirMoveEvent, Stylus.PreviewStylusInAirMoveEvent);
			Assert.AreSame (UIElement.StylusInAirMoveEvent, Stylus.StylusInAirMoveEvent);
			Assert.AreSame (UIElement.StylusEnterEvent, Stylus.StylusEnterEvent);
			Assert.AreSame (UIElement.StylusLeaveEvent, Stylus.StylusLeaveEvent);
			Assert.AreSame (UIElement.PreviewStylusInRangeEvent, Stylus.PreviewStylusInRangeEvent);
			Assert.AreSame (UIElement.StylusInRangeEvent, Stylus.StylusInRangeEvent);
			Assert.AreSame (UIElement.PreviewStylusOutOfRangeEvent, Stylus.PreviewStylusOutOfRangeEvent);
			Assert.AreSame (UIElement.StylusOutOfRangeEvent, Stylus.StylusOutOfRangeEvent);
			Assert.AreSame (UIElement.PreviewStylusSystemGestureEvent, Stylus.PreviewStylusSystemGestureEvent);
			Assert.AreSame (UIElement.StylusSystemGestureEvent, Stylus.StylusSystemGestureEvent);
			Assert.AreSame (UIElement.GotStylusCaptureEvent, Stylus.GotStylusCaptureEvent);
			Assert.AreSame (UIElement.LostStylusCaptureEvent, Stylus.LostStylusCaptureEvent);
			Assert.AreSame (UIElement.StylusButtonDownEvent, Stylus.StylusButtonDownEvent);
			Assert.AreSame (UIElement.StylusButtonUpEvent, Stylus.StylusButtonUpEvent);
			Assert.AreSame (UIElement.PreviewStylusButtonDownEvent, Stylus.PreviewStylusButtonDownEvent);
			Assert.AreSame (UIElement.PreviewStylusButtonUpEvent, Stylus.PreviewStylusButtonUpEvent);
			Assert.AreSame (UIElement.PreviewKeyDownEvent, Keyboard.PreviewKeyDownEvent);
			Assert.AreSame (UIElement.KeyDownEvent, Keyboard.KeyDownEvent);
			Assert.AreSame (UIElement.PreviewKeyUpEvent, Keyboard.PreviewKeyUpEvent);
			Assert.AreSame (UIElement.KeyUpEvent, Keyboard.KeyUpEvent);
			Assert.AreSame (UIElement.PreviewGotKeyboardFocusEvent, Keyboard.PreviewGotKeyboardFocusEvent);
			Assert.AreSame (UIElement.GotKeyboardFocusEvent, Keyboard.GotKeyboardFocusEvent);
			Assert.AreSame (UIElement.PreviewLostKeyboardFocusEvent, Keyboard.PreviewLostKeyboardFocusEvent);
			Assert.AreSame (UIElement.LostKeyboardFocusEvent, Keyboard.LostKeyboardFocusEvent);
			Assert.AreSame (UIElement.PreviewTextInputEvent, TextCompositionManager.PreviewTextInputEvent);
			Assert.AreSame (UIElement.TextInputEvent, TextCompositionManager.TextInputEvent);
			Assert.AreSame (UIElement.PreviewQueryContinueDragEvent, DragDrop.PreviewQueryContinueDragEvent);
			Assert.AreSame (UIElement.QueryContinueDragEvent, DragDrop.QueryContinueDragEvent);
			Assert.AreSame (UIElement.PreviewGiveFeedbackEvent, DragDrop.PreviewGiveFeedbackEvent);
			Assert.AreSame (UIElement.GiveFeedbackEvent, DragDrop.GiveFeedbackEvent);
			Assert.AreSame (UIElement.PreviewDragEnterEvent, DragDrop.PreviewDragEnterEvent);
			Assert.AreSame (UIElement.DragEnterEvent, DragDrop.DragEnterEvent);
			Assert.AreSame (UIElement.PreviewDragOverEvent, DragDrop.PreviewDragOverEvent);
			Assert.AreSame (UIElement.DragOverEvent, DragDrop.DragOverEvent);
			Assert.AreSame (UIElement.PreviewDragLeaveEvent, DragDrop.PreviewDragLeaveEvent);
			Assert.AreSame (UIElement.DragLeaveEvent, DragDrop.DragLeaveEvent);
			Assert.AreSame (UIElement.PreviewDropEvent, DragDrop.PreviewDropEvent);
			Assert.AreSame (UIElement.DropEvent, DragDrop.DropEvent);
			Assert.AreSame (UIElement.GotFocusEvent, FocusManager.GotFocusEvent);
			Assert.AreSame (UIElement.LostFocusEvent, FocusManager.LostFocusEvent);
		}
	}
}
//   Type: System.Windows.UIElement3D
namespace MonoTests.System.Windows {
	public partial class UIElement3DTest {
		[Test]
		public void RoutedEvents () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreSame (UIElement3D.PreviewMouseDownEvent, Mouse.PreviewMouseDownEvent);
			Assert.AreSame (UIElement3D.MouseDownEvent, Mouse.MouseDownEvent);
			Assert.AreSame (UIElement3D.PreviewMouseUpEvent, Mouse.PreviewMouseUpEvent);
			Assert.AreSame (UIElement3D.MouseUpEvent, Mouse.MouseUpEvent);
			Assert.AreSame (UIElement3D.PreviewMouseLeftButtonDownEvent, UIElement.PreviewMouseLeftButtonDownEvent);
			Assert.AreSame (UIElement3D.MouseLeftButtonDownEvent, UIElement.MouseLeftButtonDownEvent);
			Assert.AreSame (UIElement3D.PreviewMouseLeftButtonUpEvent, UIElement.PreviewMouseLeftButtonUpEvent);
			Assert.AreSame (UIElement3D.MouseLeftButtonUpEvent, UIElement.MouseLeftButtonUpEvent);
			Assert.AreSame (UIElement3D.PreviewMouseRightButtonDownEvent, UIElement.PreviewMouseRightButtonDownEvent);
			Assert.AreSame (UIElement3D.MouseRightButtonDownEvent, UIElement.MouseRightButtonDownEvent);
			Assert.AreSame (UIElement3D.PreviewMouseRightButtonUpEvent, UIElement.PreviewMouseRightButtonUpEvent);
			Assert.AreSame (UIElement3D.MouseRightButtonUpEvent, UIElement.MouseRightButtonUpEvent);
			Assert.AreSame (UIElement3D.PreviewMouseMoveEvent, Mouse.PreviewMouseMoveEvent);
			Assert.AreSame (UIElement3D.MouseMoveEvent, Mouse.MouseMoveEvent);
			Assert.AreSame (UIElement3D.PreviewMouseWheelEvent, Mouse.PreviewMouseWheelEvent);
			Assert.AreSame (UIElement3D.MouseWheelEvent, Mouse.MouseWheelEvent);
			Assert.AreSame (UIElement3D.MouseEnterEvent, Mouse.MouseEnterEvent);
			Assert.AreSame (UIElement3D.MouseLeaveEvent, Mouse.MouseLeaveEvent);
			Assert.AreSame (UIElement3D.GotMouseCaptureEvent, Mouse.GotMouseCaptureEvent);
			Assert.AreSame (UIElement3D.LostMouseCaptureEvent, Mouse.LostMouseCaptureEvent);
			Assert.AreSame (UIElement3D.QueryCursorEvent, Mouse.QueryCursorEvent);
			Assert.AreSame (UIElement3D.PreviewStylusDownEvent, Stylus.PreviewStylusDownEvent);
			Assert.AreSame (UIElement3D.StylusDownEvent, Stylus.StylusDownEvent);
			Assert.AreSame (UIElement3D.PreviewStylusUpEvent, Stylus.PreviewStylusUpEvent);
			Assert.AreSame (UIElement3D.StylusUpEvent, Stylus.StylusUpEvent);
			Assert.AreSame (UIElement3D.PreviewStylusMoveEvent, Stylus.PreviewStylusMoveEvent);
			Assert.AreSame (UIElement3D.StylusMoveEvent, Stylus.StylusMoveEvent);
			Assert.AreSame (UIElement3D.PreviewStylusInAirMoveEvent, Stylus.PreviewStylusInAirMoveEvent);
			Assert.AreSame (UIElement3D.StylusInAirMoveEvent, Stylus.StylusInAirMoveEvent);
			Assert.AreSame (UIElement3D.StylusEnterEvent, Stylus.StylusEnterEvent);
			Assert.AreSame (UIElement3D.StylusLeaveEvent, Stylus.StylusLeaveEvent);
			Assert.AreSame (UIElement3D.PreviewStylusInRangeEvent, Stylus.PreviewStylusInRangeEvent);
			Assert.AreSame (UIElement3D.StylusInRangeEvent, Stylus.StylusInRangeEvent);
			Assert.AreSame (UIElement3D.PreviewStylusOutOfRangeEvent, Stylus.PreviewStylusOutOfRangeEvent);
			Assert.AreSame (UIElement3D.StylusOutOfRangeEvent, Stylus.StylusOutOfRangeEvent);
			Assert.AreSame (UIElement3D.PreviewStylusSystemGestureEvent, Stylus.PreviewStylusSystemGestureEvent);
			Assert.AreSame (UIElement3D.StylusSystemGestureEvent, Stylus.StylusSystemGestureEvent);
			Assert.AreSame (UIElement3D.GotStylusCaptureEvent, Stylus.GotStylusCaptureEvent);
			Assert.AreSame (UIElement3D.LostStylusCaptureEvent, Stylus.LostStylusCaptureEvent);
			Assert.AreSame (UIElement3D.StylusButtonDownEvent, Stylus.StylusButtonDownEvent);
			Assert.AreSame (UIElement3D.StylusButtonUpEvent, Stylus.StylusButtonUpEvent);
			Assert.AreSame (UIElement3D.PreviewStylusButtonDownEvent, Stylus.PreviewStylusButtonDownEvent);
			Assert.AreSame (UIElement3D.PreviewStylusButtonUpEvent, Stylus.PreviewStylusButtonUpEvent);
			Assert.AreSame (UIElement3D.PreviewKeyDownEvent, Keyboard.PreviewKeyDownEvent);
			Assert.AreSame (UIElement3D.KeyDownEvent, Keyboard.KeyDownEvent);
			Assert.AreSame (UIElement3D.PreviewKeyUpEvent, Keyboard.PreviewKeyUpEvent);
			Assert.AreSame (UIElement3D.KeyUpEvent, Keyboard.KeyUpEvent);
			Assert.AreSame (UIElement3D.PreviewGotKeyboardFocusEvent, Keyboard.PreviewGotKeyboardFocusEvent);
			Assert.AreSame (UIElement3D.GotKeyboardFocusEvent, Keyboard.GotKeyboardFocusEvent);
			Assert.AreSame (UIElement3D.PreviewLostKeyboardFocusEvent, Keyboard.PreviewLostKeyboardFocusEvent);
			Assert.AreSame (UIElement3D.LostKeyboardFocusEvent, Keyboard.LostKeyboardFocusEvent);
			Assert.AreSame (UIElement3D.PreviewTextInputEvent, TextCompositionManager.PreviewTextInputEvent);
			Assert.AreSame (UIElement3D.TextInputEvent, TextCompositionManager.TextInputEvent);
			Assert.AreSame (UIElement3D.PreviewQueryContinueDragEvent, DragDrop.PreviewQueryContinueDragEvent);
			Assert.AreSame (UIElement3D.QueryContinueDragEvent, DragDrop.QueryContinueDragEvent);
			Assert.AreSame (UIElement3D.PreviewGiveFeedbackEvent, DragDrop.PreviewGiveFeedbackEvent);
			Assert.AreSame (UIElement3D.GiveFeedbackEvent, DragDrop.GiveFeedbackEvent);
			Assert.AreSame (UIElement3D.PreviewDragEnterEvent, DragDrop.PreviewDragEnterEvent);
			Assert.AreSame (UIElement3D.DragEnterEvent, DragDrop.DragEnterEvent);
			Assert.AreSame (UIElement3D.PreviewDragOverEvent, DragDrop.PreviewDragOverEvent);
			Assert.AreSame (UIElement3D.DragOverEvent, DragDrop.DragOverEvent);
			Assert.AreSame (UIElement3D.PreviewDragLeaveEvent, DragDrop.PreviewDragLeaveEvent);
			Assert.AreSame (UIElement3D.DragLeaveEvent, DragDrop.DragLeaveEvent);
			Assert.AreSame (UIElement3D.PreviewDropEvent, DragDrop.PreviewDropEvent);
			Assert.AreSame (UIElement3D.DropEvent, DragDrop.DropEvent);
			Assert.AreSame (UIElement3D.GotFocusEvent, FocusManager.GotFocusEvent);
			Assert.AreSame (UIElement3D.LostFocusEvent, FocusManager.LostFocusEvent);
#endif
		}
	}
}
