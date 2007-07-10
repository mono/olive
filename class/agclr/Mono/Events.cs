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

	[Serializable]
	class CrossDomainProxy {
		public CrossDomainProxy (AppDomain domain, UnmanagedEventHandler handler)
		{
			//Console.WriteLine ("Created proxy in domain {0}", domain.FriendlyName);
			this.domain = domain;
			this.handler = handler;
			_wrapper = new UnmanagedEventHandler (wrapper);
		}

		
		public UnmanagedEventHandler Wrapper {
			get { return _wrapper; }
		}

		public void wrapper (IntPtr target, IntPtr calldata, IntPtr closure) {
			//Console.WriteLine ("wrapper called in domain {0}", AppDomain.CurrentDomain.FriendlyName);
			//Console.WriteLine (" +  domain = {0}", domain.FriendlyName);
			this.target = target;
			this.calldata = calldata;
			this.closure = closure;
			domain.DoCallBack (new CrossAppDomainDelegate (call_in_target_domain));
		}

		public void call_in_target_domain ()
		{
			//Console.WriteLine ("call_in_target_domain called in domain {0}", AppDomain.CurrentDomain.FriendlyName);
			if (AppDomain.CurrentDomain != domain)
				throw new Exception ("Cross domain call failed");
			handler (target, calldata, closure);
		}

		public AppDomain domain;
		public UnmanagedEventHandler handler;
		public UnmanagedEventHandler _wrapper;

		public IntPtr target;
		public IntPtr calldata;
		public IntPtr closure;
	}


	internal class Events {
		static Events() {
			AppDomain d = AppDomain.CurrentDomain;
			mouse_motion = new CrossDomainProxy (d, new UnmanagedEventHandler (mouse_motion_notify_callback));
			mouse_button_down = new CrossDomainProxy (d, new UnmanagedEventHandler (mouse_button_down_callback));
			mouse_button_up = new CrossDomainProxy (d, new UnmanagedEventHandler (mouse_button_up_callback));
			mouse_enter = new CrossDomainProxy (d, new UnmanagedEventHandler (mouse_enter_callback));
			key_down = new CrossDomainProxy (d, new UnmanagedEventHandler (key_down_callback));
			key_up = new CrossDomainProxy (d, new UnmanagedEventHandler (key_up_callback));
			got_focus = new CrossDomainProxy (d, new UnmanagedEventHandler (got_focus_callback));
			lost_focus = new CrossDomainProxy (d, new UnmanagedEventHandler (lost_focus_callback));
			loaded = new CrossDomainProxy (d, new UnmanagedEventHandler (loaded_callback));
			mouse_leave = new CrossDomainProxy (d, new UnmanagedEventHandler (mouse_leave_callback));
		}

		internal static AppDomain domain = AppDomain.CurrentDomain;

		internal static CrossDomainProxy mouse_motion;
		internal static CrossDomainProxy mouse_button_down;
		internal static CrossDomainProxy mouse_button_up;
		internal static CrossDomainProxy mouse_enter;
		internal static CrossDomainProxy key_down;
		internal static CrossDomainProxy key_up;
		internal static CrossDomainProxy got_focus;
		internal static CrossDomainProxy lost_focus;
		internal static CrossDomainProxy loaded;
		internal static CrossDomainProxy mouse_leave;

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

		static void key_up_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			// TODO: map the key
		}

		static void key_down_callback (IntPtr target, IntPtr calldata, IntPtr closure)
		{
			UIElement e = (UIElement)GCHandle.FromIntPtr (closure).Target;
			// TODO: map the key
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

		internal static void AddHandler (DependencyObject obj, string eventName, CrossDomainProxy handler)
		{
			NativeMethods.dependency_object_add_event_handler (obj.native, eventName, handler.Wrapper, obj.GCHandle);
		}

		internal static void RemoveHandler (DependencyObject obj, string eventName, CrossDomainProxy handler)
		{
			NativeMethods.dependency_object_remove_event_handler (obj.native, eventName, handler.Wrapper, obj.GCHandle);
		}
	}
}
