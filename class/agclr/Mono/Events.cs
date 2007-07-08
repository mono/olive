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

	internal class Events {
		internal static UnmanagedEventHandler mouse_motion      = new UnmanagedEventHandler (mouse_motion_notify_callback);
		internal static UnmanagedEventHandler mouse_button_down = new UnmanagedEventHandler (mouse_button_down_callback);
		internal static UnmanagedEventHandler mouse_button_up   = new UnmanagedEventHandler (mouse_button_up_callback);
		internal static UnmanagedEventHandler mouse_enter       = new UnmanagedEventHandler (mouse_enter_callback);

		internal static UnmanagedEventHandler key_down = new UnmanagedEventHandler (key_down_callback);
		internal static UnmanagedEventHandler key_up   = new UnmanagedEventHandler (key_up_callback);
		
		internal static UnmanagedEventHandler got_focus   = new UnmanagedEventHandler (got_focus_callback);
		internal static UnmanagedEventHandler lost_focus  = new UnmanagedEventHandler (lost_focus_callback);
		internal static UnmanagedEventHandler loaded      = new UnmanagedEventHandler (loaded_callback);
		internal static UnmanagedEventHandler mouse_leave = new UnmanagedEventHandler (mouse_leave_callback);

		static PlainEvent surface_resized = new PlainEvent (surface_resized_callback);

		internal static DependencyObject ObjectFromPtr (IntPtr target)
		{
			object o = DependencyObject.Lookup (target);
			if (o == null){
				Kind k = NativeMethods.dependency_object_get_object_type (target);
				o = DependencyObject.Lookup (k, target);
			}

			return o as DependencyObject;
		}

		internal static UIElement ElementFromPtr (IntPtr target)
		{
			object o = ObjectFromPtr (target);

			UIElement e = o as UIElement;
			if (e == null)
				throw new Exception (String.Format ("The object registered for {0} was not an UIElement", target));

			return e;
		}
					    
		static void got_focus_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = ElementFromPtr (target);
			e.InvokeGotFocus ();
		}

		static void lost_focus_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = ElementFromPtr (target);
			e.InvokeLostFocus ();
		}

		static void loaded_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = ElementFromPtr (target);
			e.InvokeLoaded ();
		}

		static void mouse_leave_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = ElementFromPtr (target);
			e.InvokeMouseLeave ();
		}

		static void key_up_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = ElementFromPtr (target);
			// TODO: map the key
		}

		static void key_down_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = ElementFromPtr (target);
			// TODO: map the key
		}

		static MouseEventArgs MarshalMouseEventArgs (IntPtr calldata)
		{
			UnmanagedMouseEventArgs args =
				(UnmanagedMouseEventArgs)Marshal.PtrToStructure (calldata, typeof (UnmanagedMouseEventArgs));
			return new MouseEventArgs (args.state, args.x, args.y)
		}
		
		static void mouse_motion_notify_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = ElementFromPtr (target);
			e.InvokeMouseMove (MarshalMouseEventArgs (calldata));
		}
		
		static void mouse_button_down_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = ElementFromPtr (target);
			e.InvokeMouseButtonDown (MarshalMouseEventArgs (calldata));
		}
		
		static void mouse_button_up_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = ElementFromPtr (target);
			e.InvokeMouseButtonUp (MarshalMouseEventArgs (calldata));
		}
		
		static void mouse_enter_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = ElementFromPtr (target);
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

		internal static void AddHandler (IntPtr handle, string eventName, UnmanagedEventHandler handler)
		{
			NativeMethods.dependency_object_add_event_handler (handle, eventName, handler, IntPtr.Zero);
		}

		internal static void RemoveHandler (IntPtr handle, string eventName, UnmanagedEventHandler handler)
		{
			NativeMethods.dependency_object_remove_event_handler (handle, eventName, handler, IntPtr.Zero);
		}
	}
	
}
