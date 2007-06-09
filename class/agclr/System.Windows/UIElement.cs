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
