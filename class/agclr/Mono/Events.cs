//
// Events.cs
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

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace Mono {

	[StructLayout(LayoutKind.Sequential)]
	struct UnmanagedMouseEventArgs {
		public int state;
		public double x;
		public double y;
	}

	[StructLayout(LayoutKind.Sequential)]
	struct UnmanagedKeyboardEventArgs {
		public int state;
		public int platformcode;
		public int key;
	}

	internal class Events {
		internal static UnmanagedEventHandler mouse_motion = new UnmanagedEventHandler (mouse_motion_notify_callback);
		internal static UnmanagedEventHandler mouse_button_down = new UnmanagedEventHandler (mouse_button_down_callback);
		internal static UnmanagedEventHandler mouse_button_up = new UnmanagedEventHandler (mouse_button_up_callback);
		internal static UnmanagedEventHandler mouse_enter = new UnmanagedEventHandler (mouse_enter_callback);
		internal static UnmanagedEventHandler key_down = new UnmanagedEventHandler (key_down_callback);
		internal static UnmanagedEventHandler key_up = new UnmanagedEventHandler (key_up_callback);
		internal static UnmanagedEventHandler got_focus = new UnmanagedEventHandler (got_focus_callback);
		internal static UnmanagedEventHandler lost_focus = new UnmanagedEventHandler (lost_focus_callback);
		internal static UnmanagedEventHandler loaded = new UnmanagedEventHandler (loaded_callback);
		internal static UnmanagedEventHandler mouse_leave = new UnmanagedEventHandler (mouse_leave_callback);

		static PlainEvent surface_resized = new PlainEvent (surface_resized_callback);

		static void got_focus_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			e.InvokeGotFocus ();
		}

		static void lost_focus_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			e.InvokeLostFocus ();
		}

		static void loaded_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			e.InvokeLoaded ();
		}

		static void mouse_leave_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			e.InvokeMouseLeave ();
		}

		static KeyboardEventArgs MarshalKeyboardEventArgs (IntPtr calldata)
		{
			UnmanagedKeyboardEventArgs args =
				(UnmanagedKeyboardEventArgs)Marshal.PtrToStructure (calldata,
										    typeof (UnmanagedKeyboardEventArgs));

			return new KeyboardEventArgs (false/*XXX*/, false/*XXX*/, args.key, args.platformcode);
		}

		static void key_up_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			e.InvokeKeyUp (MarshalKeyboardEventArgs (calldata));
		}

		static void key_down_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			e.InvokeKeyDown (MarshalKeyboardEventArgs (calldata));
		}

		static MouseEventArgs MarshalMouseEventArgs (IntPtr calldata)
		{
			UnmanagedMouseEventArgs args =
				(UnmanagedMouseEventArgs)Marshal.PtrToStructure (calldata, typeof (UnmanagedMouseEventArgs));
			return new MouseEventArgs (args.state, args.x, args.y);
		}
		
		static void mouse_motion_notify_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			e.InvokeMouseMove (MarshalMouseEventArgs (calldata));
		}
		
		static void mouse_button_down_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			e.InvokeMouseButtonDown (MarshalMouseEventArgs (calldata));
		}
		
		static void mouse_button_up_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			e.InvokeMouseButtonUp (MarshalMouseEventArgs (calldata));
		}
		
		static void mouse_enter_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			e.InvokeMouseEnter (MarshalMouseEventArgs (calldata));
		}

		static void surface_resized_callback (IntPtr target)
		{
			// Parameter ignored

			BrowserHost.InvokeResize ();
		}

		internal static void InitSurface (IntPtr surface)
		{
			NativeMethods.surface_register_events (surface, surface_resized);
		}

		internal static void AddHandler (DependencyObject obj, string eventName, UnmanagedEventHandler handler)
		{
			NativeMethods.dependency_object_add_event_handler (obj.native, eventName, handler, obj.GCHandle);
		}

		internal static void RemoveHandler (DependencyObject obj, string eventName, UnmanagedEventHandler handler)
		{
			NativeMethods.dependency_object_remove_event_handler (obj.native, eventName, handler, obj.GCHandle);
		}
	}
}
