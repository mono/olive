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
			Type ttype = typeof (UIElement);
			
	        	OpacityProperty = DependencyProperty.Register ("Opacity", typeof (double), ttype);
	        	ClipProperty = DependencyProperty.Register ("Clip", typeof (Geometry), ttype);
	        	RenderTransformProperty = DependencyProperty.Register ("RenderTransform", typeof (Transform), ttype);
	        	TriggersProperty = DependencyProperty.Register ("Triggers", typeof (TriggerCollection), ttype);
			OpacityMaskProperty = DependencyProperty.Register ("OpacityMask", typeof (Brush), ttype);
			RenderTransformOriginProperty = DependencyProperty.Register ("RenderTransformOrigin", typeof (Point), ttype);
			CursorProperty = DependencyProperty.Register ("Cursor", typeof (Cursors), ttype);
			IsHitTestVisibleProperty = DependencyProperty.Register ("IsHitTestVisible", typeof (bool), ttype);
			VisibilityProperty = DependencyProperty.Register ("Visibility", typeof (Visibility), ttype);
			ResourcesProperty = DependencyProperty.Register ("Resources", typeof(ResourceCollection), ttype);
		}
			
		public UIElement ()
		{
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
	}
}
