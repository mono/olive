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
//	Chris Toshok (toshok@novell.com)
//

using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace System.Windows {

	public class ContentElement : DependencyObject, IInputElement, IAnimatable
	{
		public static readonly DependencyProperty AllowDropProperty = UIElement.AllowDropProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty FocusableProperty = UIElement.FocusableProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsEnabledProperty = UIElement.IsEnabledProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsFocusedProperty = UIElement.IsFocusedProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsKeyboardFocusedProperty = UIElement.IsKeyboardFocusedProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsKeyboardFocusWithinProperty = UIElement.IsKeyboardFocusWithinProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsMouseCapturedProperty = UIElement.IsMouseCapturedProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsMouseCaptureWithinProperty = UIElement.IsMouseCaptureWithinProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsMouseDirectlyOverProperty = UIElement.IsMouseDirectlyOverProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsMouseOverProperty = UIElement.IsMouseOverProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsStylusCapturedProperty = UIElement.IsStylusCapturedProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsStylusCaptureWithinProperty = UIElement.IsStylusCaptureWithinProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsStylusDirectlyOverProperty = UIElement.IsStylusDirectlyOverProperty.AddOwner (typeof (ContentElement));
		public static readonly DependencyProperty IsStylusOverProperty = UIElement.IsStylusOverProperty.AddOwner (typeof (ContentElement));

		public static readonly RoutedEvent DragEnterEvent = DragDrop.DragEnterEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent DragLeaveEvent = DragDrop.DragLeaveEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent DragOverEvent = DragDrop.DragOverEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent DropEvent = DragDrop.DropEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent GiveFeedbackEvent = DragDrop.GiveFeedbackEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent GotFocusEvent = FocusManager.GotFocusEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent GotKeyboardFocusEvent = Keyboard.GotKeyboardFocusEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent GotMouseCaptureEvent = Mouse.GotMouseCaptureEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent GotStylusCaptureEvent; // XXX
		public static readonly RoutedEvent KeyDownEvent = Keyboard.KeyDownEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent KeyUpEvent = Keyboard.KeyUpEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent LostFocusEvent = FocusManager.LostFocusEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent LostKeyboardFocusEvent = Keyboard.LostKeyboardFocusEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent LostMouseCaptureEvent = Mouse.LostMouseCaptureEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent LostStylusCaptureEvent; // XXX
		public static readonly RoutedEvent MouseDownEvent = Mouse.MouseDownEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent MouseEnterEvent = Mouse.MouseEnterEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent MouseLeaveEvent = Mouse.MouseLeaveEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent MouseLeftButtonDownEvent = UIElement.MouseLeftButtonDownEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent MouseLeftButtonUpEvent = UIElement.MouseLeftButtonUpEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent MouseMoveEvent = Mouse.MouseMoveEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent MouseRightButtonDownEvent = UIElement.MouseRightButtonDownEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent MouseRightButtonUpEvent = UIElement.MouseRightButtonUpEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent MouseUpEvent = Mouse.MouseUpEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent MouseWheelEvent = Mouse.MouseWheelEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewDragEnterEvent =  DragDrop.PreviewDragEnterEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewDragLeaveEvent = DragDrop.PreviewDragLeaveEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewDragOverEvent = DragDrop.PreviewDragOverEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewDropEvent = DragDrop.PreviewDropEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewGiveFeedbackEvent = DragDrop.PreviewGiveFeedbackEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewGotKeyboardFocusEvent = Keyboard.PreviewGotKeyboardFocusEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewKeyDownEvent = Keyboard.PreviewKeyDownEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewKeyUpEvent = Keyboard.PreviewKeyUpEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewLostKeyboardFocusEvent = Keyboard.PreviewLostKeyboardFocusEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewMouseDownEvent = Mouse.PreviewMouseDownEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewMouseLeftButtonDownEvent = UIElement.PreviewMouseLeftButtonDownEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewMouseLeftButtonUpEvent = UIElement.PreviewMouseLeftButtonUpEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewMouseMoveEvent = Mouse.PreviewMouseMoveEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewMouseRightButtonDownEvent = UIElement.PreviewMouseRightButtonDownEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewMouseRightButtonUpEvent = UIElement.PreviewMouseRightButtonUpEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewMouseUpEvent = Mouse.PreviewMouseUpEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewMouseWheelEvent = Mouse.PreviewMouseWheelEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewQueryContinueDragEvent = DragDrop.PreviewQueryContinueDragEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent PreviewStylusButtonDownEvent; // XXX
		public static readonly RoutedEvent PreviewStylusButtonUpEvent; // XXX
		public static readonly RoutedEvent PreviewStylusDownEvent; // XXX
		public static readonly RoutedEvent PreviewStylusInAirMoveEvent; // XXX
		public static readonly RoutedEvent PreviewStylusInRangeEvent; // XXX
		public static readonly RoutedEvent PreviewStylusMoveEvent; // XXX
		public static readonly RoutedEvent PreviewStylusOutOfRangeEvent; // XXX
		public static readonly RoutedEvent PreviewStylusSystemGestureEvent; // XXX
		public static readonly RoutedEvent PreviewStylusUpEvent; // XXX
		public static readonly RoutedEvent PreviewTextInputEvent = TextCompositionManager.PreviewTextInputEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent QueryContinueDragEvent = DragDrop.QueryContinueDragEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent QueryCursorEvent = Mouse.QueryCursorEvent.AddOwner (typeof (ContentElement));
		public static readonly RoutedEvent StylusButtonDownEvent; // XXX
		public static readonly RoutedEvent StylusButtonUpEvent; // XXX
		public static readonly RoutedEvent StylusDownEvent; // XXX
		public static readonly RoutedEvent StylusEnterEvent; // XXX
		public static readonly RoutedEvent StylusInAirMoveEvent; // XXX
		public static readonly RoutedEvent StylusInRangeEvent; // XXX
		public static readonly RoutedEvent StylusLeaveEvent; // XXX
		public static readonly RoutedEvent StylusMoveEvent; // XXX
		public static readonly RoutedEvent StylusOutOfRangeEvent; // XXX
		public static readonly RoutedEvent StylusSystemGestureEvent; // XXX
		public static readonly RoutedEvent StylusUpEvent; // XXX
		public static readonly RoutedEvent TextInputEvent = TextCompositionManager.TextInputEvent.AddOwner (typeof (ContentElement));

		public event DragEventHandler DragEnter {
			add    { AddHandler (DragEnterEvent, value); }
			remove { RemoveHandler (DragEnterEvent, value); }
		}

		public event DragEventHandler DragLeave {
			add { AddHandler (DragLeaveEvent, value); }
			remove { RemoveHandler (DragLeaveEvent, value); }
		}
		public event DragEventHandler DragOver {
			add { AddHandler (DragOverEvent, value); }
			remove { RemoveHandler (DragOverEvent, value); }
		}
		public event DragEventHandler Drop {
			add { AddHandler (DropEvent, value); }
			remove { RemoveHandler (DropEvent, value); }
		}
		public event GiveFeedbackEventHandler GiveFeedback {
			add { AddHandler (GiveFeedbackEvent, value); }
			remove { RemoveHandler (GiveFeedbackEvent, value); }
		}
		public event RoutedEventHandler GotFocus {
			add { AddHandler (GotFocusEvent, value); }
			remove { RemoveHandler (GotFocusEvent, value); }
		}
		public event KeyboardFocusChangedEventHandler GotKeyboardFocus {
			add { AddHandler (GotKeyboardFocusEvent, value); }
			remove { RemoveHandler (GotKeyboardFocusEvent, value); }
		}
		public event MouseEventHandler GotMouseCapture {
			add { AddHandler (GotMouseCaptureEvent, value); }
			remove { RemoveHandler (GotMouseCaptureEvent, value); }
		}
		public event StylusEventHandler GotStylusCapture {
			add { AddHandler (GotStylusCaptureEvent, value); }
			remove { RemoveHandler (GotStylusCaptureEvent, value); }
		}

		public event DependencyPropertyChangedEventHandler FocusableChanged;
		public event DependencyPropertyChangedEventHandler IsEnabledChanged;
		public event DependencyPropertyChangedEventHandler IsKeyboardFocusedChanged;
		public event DependencyPropertyChangedEventHandler IsKeyboardFocusWithinChanged;
		public event DependencyPropertyChangedEventHandler IsMouseCapturedChanged;
		public event DependencyPropertyChangedEventHandler IsMouseCaptureWithinChanged;
		public event DependencyPropertyChangedEventHandler IsMouseDirectlyOverChanged;
		public event DependencyPropertyChangedEventHandler IsStylusCapturedChanged;
		public event DependencyPropertyChangedEventHandler IsStylusCaptureWithinChanged;
		public event DependencyPropertyChangedEventHandler IsStylusDirectlyOverChanged;

		public event KeyEventHandler KeyDown {
			add { AddHandler (KeyDownEvent, value); }
			remove { RemoveHandler (KeyDownEvent, value); }
		}
		public event KeyEventHandler KeyUp {
			add { AddHandler (KeyUpEvent, value); }
			remove { RemoveHandler (KeyUpEvent, value); }
		}
		public event RoutedEventHandler LostFocus {
			add { AddHandler (LostFocusEvent, value); }
			remove { RemoveHandler (LostFocusEvent, value); }
		}
		public event KeyboardFocusChangedEventHandler LostKeyboardFocus {
			add { AddHandler (LostKeyboardFocusEvent, value); }
			remove { RemoveHandler (LostKeyboardFocusEvent, value); }
		}
		public event MouseEventHandler LostMouseCapture {
			add { AddHandler (LostMouseCaptureEvent, value); }
			remove { RemoveHandler (LostMouseCaptureEvent, value); }
		}
		public event StylusEventHandler LostStylusCapture {
			add { AddHandler (LostStylusCaptureEvent, value); }
			remove { RemoveHandler (LostStylusCaptureEvent, value); }
		}
		public event MouseButtonEventHandler MouseDown {
			add { AddHandler (MouseDownEvent, value); }
			remove { RemoveHandler (MouseDownEvent, value); }
		}
		public event MouseEventHandler MouseEnter {
			add { AddHandler (MouseEnterEvent, value); }
			remove { RemoveHandler (MouseEnterEvent, value); }
		}
		public event MouseEventHandler MouseLeave {
			add { AddHandler (MouseLeaveEvent, value); }
			remove { RemoveHandler (MouseLeaveEvent, value); }
		}
		public event MouseButtonEventHandler MouseLeftButtonDown {
			add { AddHandler (MouseLeftButtonDownEvent, value); }
			remove { RemoveHandler (MouseLeftButtonDownEvent, value); }
		}
		public event MouseButtonEventHandler MouseLeftButtonUp {
			add { AddHandler (MouseLeftButtonUpEvent, value); }
			remove { RemoveHandler (MouseLeftButtonUpEvent, value); }
		}
		public event MouseEventHandler MouseMove {
			add { AddHandler (MouseMoveEvent, value); }
			remove { RemoveHandler (MouseMoveEvent, value); }
		}
		public event MouseButtonEventHandler MouseRightButtonDown {
			add { AddHandler (MouseRightButtonDownEvent, value); }
			remove { RemoveHandler (MouseRightButtonDownEvent, value); }
		}
		public event MouseButtonEventHandler MouseRightButtonUp {
			add { AddHandler (MouseRightButtonUpEvent, value); }
			remove { RemoveHandler (MouseRightButtonUpEvent, value); }
		}
		public event MouseButtonEventHandler MouseUp {
			add { AddHandler (MouseUpEvent, value); }
			remove { RemoveHandler (MouseUpEvent, value); }
		}
 		public event MouseWheelEventHandler MouseWheel {
			add { AddHandler (MouseWheelEvent, value); }
			remove { RemoveHandler (MouseWheelEvent, value); }
		}
		public event DragEventHandler PreviewDragEnter {
			add { AddHandler (PreviewDragEnterEvent, value); }
			remove { RemoveHandler (PreviewDragEnterEvent, value); }
		}
		public event DragEventHandler PreviewDragLeave {
			add { AddHandler (PreviewDragLeaveEvent, value); }
			remove { RemoveHandler (PreviewDragLeaveEvent, value); }
		}
		public event DragEventHandler PreviewDragOver {
			add { AddHandler (PreviewDragOverEvent, value); }
			remove { RemoveHandler (PreviewDragOverEvent, value); }
		}
		public event DragEventHandler PreviewDrop {
			add { AddHandler (PreviewDropEvent, value); }
			remove { RemoveHandler (PreviewDropEvent, value); }
		}
		public event GiveFeedbackEventHandler PreviewGiveFeedback {
			add { AddHandler (PreviewGiveFeedbackEvent, value); }
			remove { RemoveHandler (PreviewGiveFeedbackEvent, value); }
		}
		public event KeyboardFocusChangedEventHandler PreviewGotKeyboardFocus {
			add { AddHandler (PreviewGotKeyboardFocusEvent, value); }
			remove { RemoveHandler (PreviewGotKeyboardFocusEvent, value); }
		}
		public event KeyEventHandler PreviewKeyDown {
			add { AddHandler (PreviewKeyDownEvent, value); }
			remove { RemoveHandler (PreviewKeyDownEvent, value); }
		}
		public event KeyEventHandler PreviewKeyUp {
			add { AddHandler (PreviewKeyUpEvent, value); }
			remove { RemoveHandler (PreviewKeyUpEvent, value); }
		}
		public event KeyboardFocusChangedEventHandler PreviewLostKeyboardFocus {
			add { AddHandler (PreviewLostKeyboardFocusEvent, value); }
			remove { RemoveHandler (PreviewLostKeyboardFocusEvent, value); }
		}
		public event MouseButtonEventHandler PreviewMouseDown {
			add { AddHandler (PreviewMouseDownEvent, value); }
			remove { RemoveHandler (PreviewMouseDownEvent, value); }
		}
		public event MouseButtonEventHandler PreviewMouseLeftButtonDown {
			add { AddHandler (PreviewMouseLeftButtonDownEvent, value); }
			remove { RemoveHandler (PreviewMouseLeftButtonDownEvent, value); }
		}
		public event MouseButtonEventHandler PreviewMouseLeftButtonUp {
			add { AddHandler (PreviewMouseLeftButtonUpEvent, value); }
			remove { RemoveHandler (PreviewMouseLeftButtonUpEvent, value); }
		}
		public event MouseEventHandler PreviewMouseMove {
			add { AddHandler (PreviewMouseMoveEvent, value); }
			remove { RemoveHandler (PreviewMouseMoveEvent, value); }
		}
		public event MouseButtonEventHandler PreviewMouseRightButtonDown {
			add { AddHandler (PreviewMouseRightButtonDownEvent, value); }
			remove { RemoveHandler (PreviewMouseRightButtonDownEvent, value); }
		}
		public event MouseButtonEventHandler PreviewMouseRightButtonUp {
			add { AddHandler (PreviewMouseRightButtonUpEvent, value); }
			remove { RemoveHandler (PreviewMouseRightButtonUpEvent, value); }
		}
		public event MouseButtonEventHandler PreviewMouseUp {
			add { AddHandler (PreviewMouseUpEvent, value); }
			remove { RemoveHandler (PreviewMouseUpEvent, value); }
		}
		public event MouseWheelEventHandler PreviewMouseWheel {
			add { AddHandler (PreviewMouseWheelEvent, value); }
			remove { RemoveHandler (PreviewMouseWheelEvent, value); }
		}
		public event QueryContinueDragEventHandler PreviewQueryContinueDrag {
			add { AddHandler (PreviewQueryContinueDragEvent, value); }
			remove { RemoveHandler (PreviewQueryContinueDragEvent, value); }
		}
		public event StylusButtonEventHandler PreviewStylusButtonDown {
			add { AddHandler (PreviewStylusButtonDownEvent, value); }
			remove { RemoveHandler (PreviewStylusButtonDownEvent, value); }
		}
		public event StylusButtonEventHandler PreviewStylusButtonUp {
			add { AddHandler (PreviewStylusButtonUpEvent, value); }
			remove { RemoveHandler (PreviewStylusButtonUpEvent, value); }
		}
		public event StylusDownEventHandler PreviewStylusDown {
			add { AddHandler (PreviewStylusDownEvent, value); }
			remove { RemoveHandler (PreviewStylusDownEvent, value); }
		}
		public event StylusEventHandler PreviewStylusInAirMove {
			add { AddHandler (PreviewStylusInAirMoveEvent, value); }
			remove { RemoveHandler (PreviewStylusInAirMoveEvent, value); }
		}
		public event StylusEventHandler PreviewStylusInRange {
			add { AddHandler (PreviewStylusInRangeEvent, value); }
			remove { RemoveHandler (PreviewStylusInRangeEvent, value); }
		}
		public event StylusEventHandler PreviewStylusMove {
			add { AddHandler (PreviewStylusMoveEvent, value); }
			remove { RemoveHandler (PreviewStylusMoveEvent, value); }
		}
		public event StylusEventHandler PreviewStylusOutOfRange {
			add { AddHandler (PreviewStylusOutOfRangeEvent, value); }
			remove { RemoveHandler (PreviewStylusOutOfRangeEvent, value); }
		}
		public event StylusSystemGestureEventHandler PreviewStylusSystemGesture {
			add { AddHandler (PreviewStylusSystemGestureEvent, value); }
			remove { RemoveHandler (PreviewStylusSystemGestureEvent, value); }
		}
		public event StylusEventHandler PreviewStylusUp {
			add { AddHandler (PreviewStylusUpEvent, value); }
			remove { RemoveHandler (PreviewStylusUpEvent, value); }
		}
		public event TextCompositionEventHandler PreviewTextInput {
			add { AddHandler (PreviewTextInputEvent, value); }
			remove { RemoveHandler (PreviewTextInputEvent, value); }
		}
		public event QueryContinueDragEventHandler QueryContinueDrag {
			add { AddHandler (QueryContinueDragEvent, value); }
			remove { RemoveHandler (QueryContinueDragEvent, value); }
		}
		public event QueryCursorEventHandler QueryCursor {
			add { AddHandler (QueryCursorEvent, value); }
			remove { RemoveHandler (QueryCursorEvent, value); }
		}
		public event StylusButtonEventHandler StylusButtonDown {
			add { AddHandler (StylusButtonDownEvent, value); }
			remove { RemoveHandler (StylusButtonDownEvent, value); }
		}
		public event StylusButtonEventHandler StylusButtonUp {
			add { AddHandler (StylusButtonUpEvent, value); }
			remove { RemoveHandler (StylusButtonUpEvent, value); }
		}
		public event StylusDownEventHandler StylusDown {
			add { AddHandler (StylusDownEvent, value); }
			remove { RemoveHandler (StylusDownEvent, value); }
		}
		public event StylusEventHandler StylusEnter {
			add { AddHandler (StylusEnterEvent, value); }
			remove { RemoveHandler (StylusEnterEvent, value); }
		}
		public event StylusEventHandler StylusInAirMove {
			add { AddHandler (StylusInAirMoveEvent, value); }
			remove { RemoveHandler (StylusInAirMoveEvent, value); }
		}
		public event StylusEventHandler StylusInRange {
			add { AddHandler (StylusInRangeEvent, value); }
			remove { RemoveHandler (StylusInRangeEvent, value); }
		}
		public event StylusEventHandler StylusLeave {
			add { AddHandler (StylusLeaveEvent, value); }
			remove { RemoveHandler (StylusLeaveEvent, value); }
		}
		public event StylusEventHandler StylusMove {
			add { AddHandler (StylusMoveEvent, value); }
			remove { RemoveHandler (StylusMoveEvent, value); }
		}
		public event StylusEventHandler StylusOutOfRange {
			add { AddHandler (StylusOutOfRangeEvent, value); }
			remove { RemoveHandler (StylusOutOfRangeEvent, value); }
		}
		public event StylusSystemGestureEventHandler StylusSystemGesture {
			add { AddHandler (StylusSystemGestureEvent, value); }
			remove { RemoveHandler (StylusSystemGestureEvent, value); }
		}
		public event StylusEventHandler StylusUp {
			add { AddHandler (StylusUpEvent, value); }
			remove { RemoveHandler (StylusUpEvent, value); }
		}
		public event TextCompositionEventHandler TextInput {
			add { AddHandler (TextInputEvent, value); }
			remove { RemoveHandler (TextInputEvent, value); }
		}

		public ContentElement ()
		{
		}

		public void AddHandler (RoutedEvent routedEvent, Delegate handler)
		{
			throw new NotImplementedException ();
		}

		public void AddHandler (RoutedEvent routedEvent, Delegate handler, bool handledEventsToo)
		{
			throw new NotImplementedException ();
		}

		public void AddToEventRoute (EventRoute route, RoutedEventArgs e)
		{
			throw new NotImplementedException ();
		}

		public void ApplyAnimationClock (DependencyProperty dp, AnimationClock clock)
		{
			throw new NotImplementedException ();
		}

		public void ApplyAnimationClock (DependencyProperty dp, AnimationClock clock, HandoffBehavior handoffBehavior)
		{
			throw new NotImplementedException ();
		}

		public void BeginAnimation (DependencyProperty dp, AnimationTimeline animation)
		{
			throw new NotImplementedException ();
		}

		public void BeginAnimation (DependencyProperty dp, AnimationTimeline animation, HandoffBehavior handoffBehavior)
		{
			throw new NotImplementedException ();
		}

		public bool CaptureMouse ()
		{
			throw new NotImplementedException ();
		}

		public bool CaptureStylus ()
		{
			throw new NotImplementedException ();
		}
	       
		public bool Focus ()
		{
			throw new NotImplementedException ();
		}

		public object GetAnimationBaseValue (DependencyProperty dp)
		{
			throw new NotImplementedException ();
		}

		protected internal virtual DependencyObject GetUIParentCore ()
		{
			throw new NotImplementedException ();
		}

		public virtual bool MoveFocus (TraversalRequest request)
		{
			throw new NotImplementedException ();
		}
#if notyet
		protected virtual AutomationPeer OnCreateAutomationPeer ()
		{
			throw new NotImplementedException ();
		}
#endif

		protected virtual void OnDragEnter (DragEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnDragLeave (DragEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnDragOver (DragEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnDrop (DragEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnGiveFeedback (GiveFeedbackEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnGotFocus (RoutedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnGotKeyboardFocus (KeyboardFocusChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnGotMouseCapture (MouseEventArgs e )
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnGotStylusCapture (StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnIsKeyboardFocusedChanged (DependencyPropertyChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnIsKeyboardFocusWithinChanged (DependencyPropertyChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnIsMouseCapturedChanged (DependencyPropertyChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnIsMouseCaptureWithinChanged (DependencyPropertyChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnIsMouseDirectlyOverChanged (DependencyPropertyChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnIsStylusCapturedChanged (DependencyPropertyChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnIsStylusCaptureWithinChanged (DependencyPropertyChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnIsStylusDirectlyOverChanged (DependencyPropertyChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnKeyDown( KeyEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnKeyUp(KeyEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnLostFocus (RoutedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnLostMouseCapture(MouseEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnLostStylusCapture(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnMouseDown (MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnMouseEnter(MouseEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnMouseLeave(MouseEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnMouseMove(MouseEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnMouseRightButtonDown(MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnMouseRightButtonUp(MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnMouseUp (MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
 		protected virtual void OnMouseWheel(MouseWheelEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewDragEnter(DragEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewDragLeave(DragEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewDragOver(DragEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewDrop(DragEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewGiveFeedback(GiveFeedbackEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewKeyDown(KeyEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewKeyUp(KeyEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewMouseDown (Input.MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewMouseMove(MouseEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewMouseRightButtonDown(MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewMouseUp (MouseButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewMouseWheel(MouseWheelEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewQueryContinueDrag (QueryContinueDragEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewStylusButtonDown(StylusButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewStylusButtonUp(StylusButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewStylusDown(StylusDownEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewStylusInAirMove(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewStylusInRange(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewStylusMove(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewStylusOutOfRange(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewStylusSystemGesture(StylusSystemGestureEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewStylusUp(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnPreviewTextInput(TextCompositionEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnQueryContinueDrag (QueryContinueDragEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnQueryCursor(QueryCursorEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnStylusButtonDown(StylusButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnStylusButtonUp(StylusButtonEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnStylusDown(StylusDownEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnStylusEnter(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnStylusInAirMove(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnStylusInRange(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnStylusLeave(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnStylusMove(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnStylusOutOfRange(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnStylusSystemGesture(StylusSystemGestureEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnStylusUp(StylusEventArgs e)
		{
			throw new NotImplementedException ();
		}
		protected virtual void OnTextInput( TextCompositionEventArgs e)
		{
			throw new NotImplementedException ();
		}

		public virtual DependencyObject PredictFocus (FocusNavigationDirection direction)
		{
			throw new NotImplementedException ();
		}

		public virtual void RaiseEvent (RoutedEventArgs e)
		{
			throw new NotImplementedException ();
		}

		public virtual void ReleaseMouseCapture ()
		{
			throw new NotImplementedException ();
		}

		public virtual void ReleaseStylusCapture ()
		{
			throw new NotImplementedException ();
		}

		public virtual void RemoveHandler (RoutedEvent routedEvent, Delegate handler)
		{
			throw new NotImplementedException ();
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		public bool ShouldSerializeCommandBindings ()
		{
			throw new NotImplementedException ();
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		public bool ShouldSerializeInputBindings ()
		{
			throw new NotImplementedException ();
		}


		public bool AllowDrop {
			get { return (bool)GetValue (AllowDropProperty); }
			set { SetValue (AllowDropProperty, value); }
		}

#if notyet
		public CommandBindingCollection CommandBindings {
			get { throw new NotImplementedException (); }
		}
#endif

		public bool Focusable {
			get { return (bool)GetValue (FocusableProperty); }
			set { SetValue (FocusableProperty, value); }
		}

		public bool HasAnimatedProperties {
			get { throw new NotImplementedException (); }
		}

#if notyet
		public InputBindingCollection InputBindings {
			get { throw new NotImplementedException (); }
		}
#endif

		public bool IsEnabled {
			get { return (bool)GetValue (IsEnabledProperty); }
			set { SetValue (IsEnabledProperty, value); }
		}

		public virtual bool IsEnabledCore {
			get { throw new NotImplementedException (); }
		}
		
		public bool IsFocused {
			get { return (bool)GetValue (IsFocusedProperty); }
		}

		public bool IsInputMethodEnabled {
			get { throw new NotImplementedException (); }
		}

		public bool IsKeyboardFocused {
			get { return (bool)GetValue (IsKeyboardFocusedProperty); }
		}

		public bool IsKeyboardFocusWithin {
			get { return (bool)GetValue (IsKeyboardFocusWithinProperty); }
		}

		public bool IsMouseCaptured {
			get { return (bool)GetValue (IsMouseCapturedProperty); }
		}

		public bool IsMouseCaptureWithin {
			get { return (bool)GetValue (IsMouseCaptureWithinProperty); }
		}

		public bool IsMouseDirectlyOver {
			get { return (bool)GetValue (IsMouseDirectlyOverProperty); }
		}

		public bool IsMouseOver {
			get { return (bool)GetValue (IsMouseOverProperty); }
		}

		public bool IsStylusCaptured {
			get { return (bool)GetValue (IsStylusCapturedProperty); }
		}

		public bool IsStylusCaptureWithin {
			get { return (bool)GetValue (IsStylusCaptureWithinProperty); }
		}

		public bool IsStylusDirectlyOver {
			get { return (bool)GetValue (IsStylusDirectlyOverProperty); }
		}
		public bool IsStylusOver {
			get { return (bool)GetValue (IsStylusOverProperty); }
		}


	}
}
