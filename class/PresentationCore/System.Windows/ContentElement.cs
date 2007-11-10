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

using System.Windows.Input;
using System.Windows.Media.Animation;

namespace System.Windows {

	public class ContentElement : DependencyObject, IInputElement, IAnimatable
	{
		public static readonly DependencyProperty AllowDropProperty;
		public static readonly DependencyProperty FocusableProperty;
		public static readonly DependencyProperty IsEnabledProperty;
		public static readonly DependencyProperty IsFocusedProperty;
		public static readonly DependencyProperty IsKeyboardFocusedProperty;
		public static readonly DependencyProperty IsKeyboardFocusWithinProperty;
		public static readonly DependencyProperty IsMouseCapturedProperty;
		public static readonly DependencyProperty IsMouseCaptureWithinProperty;
		public static readonly DependencyProperty IsMouseDirectlyOverProperty;
		public static readonly DependencyProperty IsMouseOverProperty;
		public static readonly DependencyProperty IsStylusCapturedProperty;
		public static readonly DependencyProperty IsStylusCaptureWithinProperty;
		public static readonly DependencyProperty IsStylusDirectlyOverProperty;
		public static readonly DependencyProperty IsStylusOverProperty;

		public static readonly RoutedEvent DragEnterEvent;
		public static readonly RoutedEvent DragLeaveEvent;
		public static readonly RoutedEvent DragOverEvent;
		public static readonly RoutedEvent DropEvent;
		public static readonly RoutedEvent GiveFeedbackEvent;
		public static readonly RoutedEvent GotFocusEvent;
		public static readonly RoutedEvent GotKeyboardFocusEvent;
		public static readonly RoutedEvent GotMouseCaptureEvent;
		public static readonly RoutedEvent GotStylusCaptureEvent;
		public static readonly RoutedEvent KeyDownEvent;
		public static readonly RoutedEvent KeyUpEvent;
		public static readonly RoutedEvent LostFocusEvent;
		public static readonly RoutedEvent LostKeyboardFocusEvent;
		public static readonly RoutedEvent LostMouseCaptureEvent;
		public static readonly RoutedEvent LostStylusCaptureEvent;
		public static readonly RoutedEvent MouseDownEvent;
		public static readonly RoutedEvent MouseEnterEvent;
		public static readonly RoutedEvent MouseLeaveEvent;
		public static readonly RoutedEvent MouseLeftButtonDownEvent;
		public static readonly RoutedEvent MouseLeftButtonUpEvent;
		public static readonly RoutedEvent MouseMoveEvent;
		public static readonly RoutedEvent MouseRightButtonDownEvent;
		public static readonly RoutedEvent MouseRightButtonUpEvent;
		public static readonly RoutedEvent MouseUpEvent;
		public static readonly RoutedEvent MouseWheelEvent;
		public static readonly RoutedEvent PreviewDragEnterEvent;
		public static readonly RoutedEvent PreviewDragLeaveEvent;
		public static readonly RoutedEvent PreviewDragOverEvent;
		public static readonly RoutedEvent PreviewDropEvent;
		public static readonly RoutedEvent PreviewGiveFeedbackEvent;
		public static readonly RoutedEvent PreviewGotKeyboardFocusEvent;
		public static readonly RoutedEvent PreviewKeyDownEvent;
		public static readonly RoutedEvent PreviewKeyUpEvent;
		public static readonly RoutedEvent PreviewLostKeyboardFocusEvent;
		public static readonly RoutedEvent PreviewMouseDownEvent;
		public static readonly RoutedEvent PreviewMouseLeftButtonDownEvent;
		public static readonly RoutedEvent PreviewMouseLeftButtonUpEvent;
		public static readonly RoutedEvent PreviewMouseMoveEvent;
		public static readonly RoutedEvent PreviewMouseRightButtonDownEvent;
		public static readonly RoutedEvent PreviewMouseRightButtonUpEvent;
		public static readonly RoutedEvent PreviewMouseUpEvent;
		public static readonly RoutedEvent PreviewMouseWheelEvent;
		public static readonly RoutedEvent PreviewQueryContinueDragEvent;
		public static readonly RoutedEvent PreviewStylusButtonDownEvent;
		public static readonly RoutedEvent PreviewStylusButtonUpEvent;
		public static readonly RoutedEvent PreviewStylusDownEvent;
		public static readonly RoutedEvent PreviewStylusInAirMoveEvent;
		public static readonly RoutedEvent PreviewStylusInRangeEvent;
		public static readonly RoutedEvent PreviewStylusMoveEvent;
		public static readonly RoutedEvent PreviewStylusOutOfRangeEvent;
		public static readonly RoutedEvent PreviewStylusSystemGestureEvent;
		public static readonly RoutedEvent PreviewStylusUpEvent;
		public static readonly RoutedEvent PreviewTextInputEvent;
		public static readonly RoutedEvent QueryContinueDragEvent;
		public static readonly RoutedEvent QueryCursorEvent;
		public static readonly RoutedEvent StylusButtonDownEvent;
		public static readonly RoutedEvent StylusButtonUpEvent;
		public static readonly RoutedEvent StylusDownEvent;
		public static readonly RoutedEvent StylusEnterEvent;
		public static readonly RoutedEvent StylusInAirMoveEvent;
		public static readonly RoutedEvent StylusInRangeEvent;
		public static readonly RoutedEvent StylusLeaveEvent;
		public static readonly RoutedEvent StylusMoveEvent;
		public static readonly RoutedEvent StylusOutOfRangeEvent;
		public static readonly RoutedEvent StylusSystemGestureEvent;
		public static readonly RoutedEvent StylusUpEvent;
		public static readonly RoutedEvent TextInputEvent;


		public event DragEventHandler DragEnter;
		public event DragEventHandler DragLeave;
		public event DragEventHandler DragOver;
		public event DragEventHandler Drop;
		public event DependencyPropertyChangedEventHandler FocusableChanged;
		public event GiveFeedbackEventHandler GiveFeedback;
		public event RoutedEventHandler GotFocus;
		public event KeyboardFocusChangedEventHandler GotKeyboardFocus;
		public event MouseEventHandler GotMouseCapture;
		public event StylusEventHandler GotStylusCapture;
		public event DependencyPropertyChangedEventHandler IsEnabledChanged;
		public event DependencyPropertyChangedEventHandler IsKeyboardFocusedChanged;
		public event DependencyPropertyChangedEventHandler IsKeyboardFocusWithinChanged;
		public event DependencyPropertyChangedEventHandler IsMouseCapturedChanged;
		public event DependencyPropertyChangedEventHandler IsMouseCaptureWithinChanged;
		public event DependencyPropertyChangedEventHandler IsMouseDirectlyOverChanged;
		public event DependencyPropertyChangedEventHandler IsStylusCapturedChanged;
		public event DependencyPropertyChangedEventHandler IsStylusCaptureWithinChanged;
		public event DependencyPropertyChangedEventHandler IsStylusDirectlyOverChanged;
		public event KeyEventHandler KeyDown;
		public event KeyEventHandler KeyUp;
		public event RoutedEventHandler LostFocus;
		public event KeyboardFocusChangedEventHandler LostKeyboardFocus;
		public event MouseEventHandler LostMouseCapture;
		public event StylusEventHandler LostStylusCapture;
		public event MouseButtonEventHandler MouseDown;
		public event MouseEventHandler MouseEnter;
		public event MouseEventHandler MouseLeave;
		public event MouseButtonEventHandler MouseLeftButtonDown;
		public event MouseButtonEventHandler MouseLeftButtonUp;
		public event MouseEventHandler MouseMove;
		public event MouseButtonEventHandler MouseRightButtonDown;
		public event MouseButtonEventHandler MouseRightButtonUp;
		public event MouseButtonEventHandler MouseUp;
 		public event MouseWheelEventHandler MouseWheel;
		public event DragEventHandler PreviewDragEnter;
		public event DragEventHandler PreviewDragLeave;
		public event DragEventHandler PreviewDragOver;
		public event DragEventHandler PreviewDrop;
		public event GiveFeedbackEventHandler PreviewGiveFeedback;
		public event KeyboardFocusChangedEventHandler PreviewGotKeyboardFocus;
		public event KeyEventHandler PreviewKeyDown;
		public event KeyEventHandler PreviewKeyUp;
		public event KeyboardFocusChangedEventHandler PreviewLostKeyboardFocus;
		public event MouseButtonEventHandler PreviewMouseDown;
		public event MouseButtonEventHandler PreviewMouseLeftButtonDown;
		public event MouseButtonEventHandler PreviewMouseLeftButtonUp;
		public event MouseEventHandler PreviewMouseMove;
		public event MouseButtonEventHandler PreviewMouseRightButtonDown;
		public event MouseButtonEventHandler PreviewMouseRightButtonUp;
		public event MouseButtonEventHandler PreviewMouseUp;
		public event MouseWheelEventHandler PreviewMouseWheel;
		public event QueryContinueDragEventHandler PreviewQueryContinueDrag;
		public event StylusButtonEventHandler PreviewStylusButtonDown;
		public event StylusButtonEventHandler PreviewStylusButtonUp;
		public event StylusDownEventHandler PreviewStylusDown;
		public event StylusEventHandler PreviewStylusInAirMove;
		public event StylusEventHandler PreviewStylusInRange;
		public event StylusEventHandler PreviewStylusMove;
		public event StylusEventHandler PreviewStylusOutOfRange;
		public event StylusSystemGestureEventHandler PreviewStylusSystemGesture;
		public event StylusEventHandler PreviewStylusUp;
		public event TextCompositionEventHandler PreviewTextInput;
		public event QueryContinueDragEventHandler QueryContinueDrag;
		public event QueryCursorEventHandler QueryCursor;
		public event StylusButtonEventHandler StylusButtonDown;
		public event StylusButtonEventHandler StylusButtonUp;
		public event StylusDownEventHandler StylusDown;
		public event StylusEventHandler StylusEnter;
		public event StylusEventHandler StylusInAirMove;
		public event StylusEventHandler StylusInRange;
		public event StylusEventHandler StylusLeave;
		public event StylusEventHandler StylusMove;
		public event StylusEventHandler StylusOutOfRange;
		public event StylusSystemGestureEventHandler StylusSystemGesture;
		public event StylusEventHandler StylusUp;
		public event TextCompositionEventHandler TextInput;

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

		public virtual void PredictFocus (FocusNavigationDirection direction)
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

		public bool ShouldSerializeCommandBindings ()
		{
			throw new NotImplementedException ();
		}

		public bool ShouldSerializeInputBindings ()
		{
			throw new NotImplementedException ();
		}


		public bool AllowDrop {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

#if notyet
		public CommandBindingCollection CommandBindings {
			get { throw new NotImplementedException (); }
		}
#endif

		public bool Focusable {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
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
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public virtual bool IsEnabledCore {
			get { throw new NotImplementedException (); }
		}
		
		public bool IsFocused {
			get { throw new NotImplementedException (); }
		}

		public bool IsInputMethodEnabled {
			get { throw new NotImplementedException (); }
		}

		public bool IsKeyboardFocused {
			get { throw new NotImplementedException (); }
		}

		public bool IsKeyboardFocusWithin {
			get { throw new NotImplementedException (); }
		}

		public bool IsMouseCaptured {
			get { throw new NotImplementedException (); }
		}

		public bool IsMouseCaptureWithin {
			get { throw new NotImplementedException (); }
		}

		public bool IsMouseDirectlyOver {
			get { throw new NotImplementedException (); }
		}

		public bool IsMouseOver {
			get { throw new NotImplementedException (); }
		}

		public bool IsStylusCaptured {
			get { throw new NotImplementedException (); }
		}

		public bool IsStylusCaptureWithin {
			get { throw new NotImplementedException (); }
		}

		public bool IsStylusDirectlyOver {
			get { throw new NotImplementedException (); }
		}
		public bool IsStylusOver {
			get { throw new NotImplementedException (); }
		}


	}
}
