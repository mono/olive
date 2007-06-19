//
// UIElemtn.cs
//
// Author:
//   Miguel de Icaza (miguel@novell.com)
//
// Copyright 2007 Novell, Inc.
//
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
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Runtime.InteropServices;
using Mono;

namespace System.Windows {
	
	public abstract class UIElement : Visual {
	        public static readonly DependencyProperty OpacityProperty;
	        public static readonly DependencyProperty ClipProperty;
	        public static readonly DependencyProperty RenderTransformProperty;
	        public static readonly DependencyProperty TriggersProperty;
	        public static readonly DependencyProperty OpacityMaskProperty;
	        public static readonly DependencyProperty RenderTransformOriginProperty;
	        public static readonly DependencyProperty CursorProperty;
	        public static readonly DependencyProperty IsHitTestVisibleProperty;
	        public static readonly DependencyProperty VisibilityProperty;
	        public static readonly DependencyProperty ResourcesProperty;
	        public static readonly DependencyProperty ZIndexProperty;
	
		static UIElement ()
		{
	        	OpacityProperty = DependencyProperty.Lookup (Kind.UIELEMENT, "Opacity", typeof (double));
	        	ClipProperty = DependencyProperty.Lookup (Kind.UIELEMENT, "Clip", typeof (Geometry));
	        	RenderTransformProperty = DependencyProperty.Lookup (Kind.UIELEMENT, "RenderTransform", typeof (Transform));
	        	TriggersProperty = DependencyProperty.Lookup (Kind.UIELEMENT, "Triggers", typeof (TriggerCollection));
			OpacityMaskProperty = DependencyProperty.Lookup (Kind.UIELEMENT, "OpacityMask", typeof (Brush));
			RenderTransformOriginProperty = DependencyProperty.Lookup (Kind.UIELEMENT, "RenderTransformOrigin", typeof (Point));
			CursorProperty = DependencyProperty.Lookup (Kind.UIELEMENT, "Cursor", typeof (Cursors));
			IsHitTestVisibleProperty = DependencyProperty.Lookup (Kind.UIELEMENT, "IsHitTestVisible", typeof (bool));
			VisibilityProperty = DependencyProperty.Lookup (Kind.UIELEMENT, "Visibility", typeof (Visibility));
			ResourcesProperty = DependencyProperty.Lookup (Kind.UIELEMENT, "Resources", typeof (ResourceCollection));
		}
			
		public UIElement () : base (NativeMethods.uielement_new ())
		{
			NativeMethods.base_ref (native);
		}

		internal UIElement (IntPtr raw) : base (raw)
		{
			mouse_motion      = new UnmanagedEventHandler (mouse_motion_notify_callback);
			mouse_button_down = new UnmanagedEventHandler (mouse_button_down_callback);
			mouse_button_up   = new UnmanagedEventHandler (mouse_button_up_callback);
			mouse_enter       = new UnmanagedEventHandler (mouse_enter_callback);

			keydown = new UnmanagedEventHandler (key_down_callback);
			keyup   = new UnmanagedEventHandler (key_up_callback);
		
			got_focus   = new UnmanagedEventHandler (got_focus_callback);
			lost_focus  = new UnmanagedEventHandler (lost_focus_callback);
			loaded      = new UnmanagedEventHandler (loaded_callback);
			mouse_leave = new UnmanagedEventHandler (mouse_leave_callback);

			Events.AddHandler (raw, "MouseMove", mouse_motion);
			Events.AddHandler (raw, "MouseLeftButtonUp", mouse_button_up);
			Events.AddHandler (raw, "MouseLeftButtonDown", mouse_button_down);
			Events.AddHandler (raw, "MouseEnter", mouse_enter);
			Events.AddHandler (raw, "KeyDown", keydown);
			Events.AddHandler (raw, "KeyUp", keyup);
			Events.AddHandler (raw, "GotFocus", got_focus);
			Events.AddHandler (raw, "LostFocus", lost_focus);
			Events.AddHandler (raw, "Loaded", loaded);
			Events.AddHandler (raw, "MouseLeave", mouse_leave);
		}
		
		public Geometry Clip {
			get {
				return (Geometry) GetValue (ClipProperty);
			}
				
			set {
				SetValue (ClipProperty, value);
			}
		}
		
		public Cursors Cursor {
			get {
				return (Cursors) GetValue (CursorProperty);
			}
				
			set {
				SetValue (CursorProperty, value);
			}
		}
		
		public bool IsHitTestVisible {
			get {
				return (bool) GetValue (IsHitTestVisibleProperty);
			}
				
			set {
				SetValue (IsHitTestVisibleProperty, value);
			}
		}
		
		public double Opacity {
			get {
				return (double) GetValue (OpacityProperty);
			}
				
			set {
				SetValue (OpacityProperty, value);
			}
		}
		
		public Brush OpacityMask {
			get {
				return (Brush) GetValue (OpacityMaskProperty);
			}
				
			set {
				SetValue (OpacityMaskProperty, value);
			}
		}
		
		public Transform RenderTransform {
			get {
				return (Transform) GetValue (RenderTransformProperty);
			}
				
			set {
				SetValue (RenderTransformProperty, value);
			}
		}
		
		public Point RenderTransformOrigin {
			get {
				return (Point) GetValue (RenderTransformOriginProperty);
			}
				
			set {
				SetValue (RenderTransformOriginProperty, value);
			}
		}
		
		public ResourceCollection Resources {
			get {
				return (ResourceCollection) GetValue (ResourcesProperty);
			}
				
			set {
				SetValue (ResourcesProperty, value);
			}
		}
		
		public TriggerCollection Triggers {
			get {
				return (TriggerCollection) GetValue (TriggersProperty);
			}
				
			set {
				SetValue (TriggersProperty, value);
			}
		}
		
		public Visibility Visibility {
			get {
				return (Visibility) GetValue (VisibilityProperty);
			}
				
			set {
				SetValue (VisibilityProperty, value);
			}
		}

		public event EventHandler GotFocus;
		public event EventHandler LostFocus;
		public event EventHandler Loaded;
			
		public event KeyboardEventHandler KeyDown;
		public event KeyboardEventHandler KeyUp;

		public event MouseEventHandler MouseEnter;
		public event EventHandler MouseLeave;
		
		public event MouseEventHandler MouseLeftButtonDown;
		public event MouseEventHandler MouseLeftButtonUp;
		public event MouseEventHandler MouseMove;

		UnmanagedEventHandler mouse_motion;
		UnmanagedEventHandler mouse_button_down;
		UnmanagedEventHandler mouse_button_up;
		UnmanagedEventHandler mouse_enter;

		UnmanagedEventHandler keydown;
		UnmanagedEventHandler keyup;
		
		UnmanagedEventHandler got_focus;
		UnmanagedEventHandler lost_focus;
		UnmanagedEventHandler loaded;
		UnmanagedEventHandler mouse_leave;

		void mouse_event (MouseEventHandler h, IntPtr event_data)
		{
			UnmanagedMouseEventArgs args = (UnmanagedMouseEventArgs)Marshal.PtrToStructure(event_data, typeof(UnmanagedMouseEventArgs));
			h (this, new MouseEventArgs (args.state, args.x, args.y));
		}

		void mouse_motion_notify_callback (IntPtr sender, IntPtr event_data, IntPtr closure)
		{
			if (MouseMove != null)
				mouse_event (MouseMove, event_data);
		}

		void mouse_button_down_callback (IntPtr sender, IntPtr event_data, IntPtr closure)
		{
			if (MouseLeftButtonDown != null)
				mouse_event (MouseLeftButtonDown, event_data);
		}

		void mouse_button_up_callback (IntPtr sender, IntPtr event_data, IntPtr closure)
		{
			if (MouseLeftButtonUp != null)
				mouse_event (MouseLeftButtonUp, event_data);
		}

		void mouse_enter_callback (IntPtr sender, IntPtr event_data, IntPtr closure)
		{
			if (MouseEnter != null)
				mouse_event (MouseEnter, event_data);
		}

		void mouse_leave_callback (IntPtr sender, IntPtr event_data, IntPtr closure)
		{
			if (MouseLeave != null)
				MouseLeave (this, EventArgs.Empty);
		}

		void key_event (KeyboardEventHandler h, IntPtr event_data)
		{
			UnmanagedKeyboardEventArgs args = (UnmanagedKeyboardEventArgs)Marshal.PtrToStructure(event_data, typeof(UnmanagedKeyboardEventArgs));
			h (this, new KeyboardEventArgs (/*args.state ...*/));
		}

		void key_up_callback (IntPtr sender, IntPtr event_data, IntPtr closure)
		{
			if (KeyUp != null)
				key_event (KeyUp, event_data);
		}

		void key_down_callback (IntPtr sender, IntPtr event_data, IntPtr closure)
		{
			if (KeyDown != null)
				key_event (KeyDown, event_data);
		}

		void loaded_callback (IntPtr sender, IntPtr event_data, IntPtr closure)
		{
			if (Loaded != null)
				Loaded (this, EventArgs.Empty);
		}

		void got_focus_callback (IntPtr sender, IntPtr event_data, IntPtr closure)
		{
			// XXX
		}

		void lost_focus_callback (IntPtr sender, IntPtr event_data, IntPtr closure)
		{
			// XXX
		}


		protected internal override Kind GetKind ()
		{
			return Kind.UIELEMENT;
		}
	}
}
