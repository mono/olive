//
// Just starting stubs, a deeper understanding is required before work
// here can continue.
//
// Very confusing information about Shutdown: it states that shutdown is
// not over, until all events are unwinded, and also states that all events
// are aborted at that point.  Which is it?
//
// The documentation for the Dispatcher family is poorly written, complete
// sections are cut-and-pasted that add no value and the important pieces
// like (what is a frame) is not on the APIs, but scattered everywhere else
//
// TODO:
//    Add support for disabling the dispatcher and resuming it.
//    Add support for Waiting for new tasks to be pushed, so that we dont busy loop.
// 
// -----------------------------------------------------------------------
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
// Copyright (c) 2006 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Miguel de Icaza (miguel@novell.com)
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace System.Windows.Threading {

	[Flags]
	internal enum Flags {
		ShutdownStarted = 1,
		Shutdown = 2,
		Disabled = 4
	}
	
	public sealed class Dispatcher {
		static Dictionary<Thread, Dispatcher> dispatchers = new Dictionary<Thread, Dispatcher> ();
		static object olock = new object ();
		static DispatcherFrame main_execution_frame = new DispatcherFrame ();

		const int TOP_PRIO = (int)DispatcherPriority.Send;
		Thread base_thread;
		Queue [] priority_queues = new Queue [TOP_PRIO];

		Flags flags;
		int queue_bits;
		EventWaitHandle wait;
		Queue async_tasks;
		bool want_async_lookup;
		
		Dispatcher (Thread t)
		{
			base_thread = t;
			for (int i = 1; i < (int) DispatcherPriority.Send; i++)
				priority_queues [i] = new Queue ();
			wait = new EventWaitHandle (false, EventResetMode.AutoReset);
			async_tasks = new Queue ();
		}

		public bool CheckAccess ()
		{
			return Thread.CurrentThread == base_thread;
		}

		public void VerifyAccess ()
		{
			if (Thread.CurrentThread != base_thread)
				throw new InvalidOperationException ("Invoked from a different thread");
		}
		
		public object Invoke (DispatcherPriority priority, Delegate method)
		{
			if (priority < 0 || priority > DispatcherPriority.Send)
				throw new InvalidEnumArgumentException ("priority");
			if (priority == DispatcherPriority.Inactive)
				throw new ArgumentException ("priority can not be inactive", "priority");
			if (method == null)
				throw new ArgumentNullException ("method");

			DispatcherOperation op = new DispatcherOperation (this, priority, method);
			Queue (priority, op);
			Run ();
			
			throw new NotImplementedException ();
		}

		public object Invoke (DispatcherPriority priority, Delegate method, object arg)
		{
			if (priority < 0 || priority > DispatcherPriority.Send)
				throw new InvalidEnumArgumentException ("priority");
			if (priority == DispatcherPriority.Inactive)
				throw new ArgumentException ("priority can not be inactive", "priority");
			if (method == null)
				throw new ArgumentNullException ("method");

			Queue (priority, new DispatcherOperation (this, priority, method, arg));
			throw new NotImplementedException ();
		}
		
		public object Invoke (DispatcherPriority priority, Delegate method, object arg, params object [] args)
		{
			if (priority < 0 || priority > DispatcherPriority.Send)
				throw new InvalidEnumArgumentException ("priority");
			if (priority == DispatcherPriority.Inactive)
				throw new ArgumentException ("priority can not be inactive", "priority");
			if (method == null)
				throw new ArgumentNullException ("method");

			Queue (priority, new DispatcherOperation (this, priority, method, arg, args));

			throw new NotImplementedException ();
		}

		void Queue (DispatcherPriority priority, object x)
		{
			if (CheckAccess ()){
				int p = ((int) priority);
				Queue q = priority_queues [p];
				int flag = 1 << p;
				q.Enqueue (x);
				queue_bits |= flag;
			} else {
				lock (async_tasks){
					want_async_lookup = true;
					async_tasks.Enqueue (x);
				}
				wait.Reset ();
			}
		}
		
		public static Dispatcher CurrentDispatcher {
			get {
				lock (olock){
					Thread t = Thread.CurrentThread;
					Dispatcher dis = FromThread (t);

					if (dis != null)
						return dis;
				
					dis = new Dispatcher (t);
					dispatchers [t] = dis;
					return dis;
				}
			}
		}

		public static Dispatcher FromThread (Thread thread)
		{
			Dispatcher dis;
			
			if (dispatchers.TryGetValue (thread, out dis))
				return dis;

			return null;
		}

		public Thread Thread {
			get {
				return base_thread;
			}
		}

		public static void Run ()
		{
			PushFrame (main_execution_frame);
		}
		
		public static void PushFrame (DispatcherFrame frame)
		{
			if (frame == null)
				throw new ArgumentNullException ("frame");

			Dispatcher dis = CurrentDispatcher;

			if (dis.HasShutdownFinished)
				throw new InvalidOperationException ("The Dispatcher has shut down");
			if (frame.dispatcher != null)
				throw new InvalidOperationException ("Frame is already running on a different dispatcher");
			if ((dis.flags & Flags.Disabled) != 0)
				throw new InvalidOperationException ("Dispatcher processing has been disabled");
			
			frame.dispatcher = dis;

			dis.RunFrame (frame);
		}

		void RunFrame (DispatcherFrame frame)
		{
			bool done = false;
			do {
				while (queue_bits != 0){
					for (int i = TOP_PRIO; i > 0 && queue_bits != 0; i--){
						int current_bit = queue_bits & (1 << i);
						if (current_bit != 0){
							Queue q = priority_queues [i];

							do {
								DispatcherOperation task = (DispatcherOperation) q.Dequeue ();
								task.Invoke ();

								// if we are done with this queue, leave.
								if (q.Count == 0){
									queue_bits &= ~(1 << i);
									break;
								}

								//
								// If a higher-priority task comes in, go do that
								//
								if (current_bit < (queue_bits & ~current_bit))
									break;
							} while (true);
						}
					}
				}
				wait.WaitOne ();
				if (want_async_lookup){
					lock (async_tasks){
						DispatcherOperation op;

						while ((op = (DispatcherOperation) async_tasks.Dequeue ()) != null)
							Queue (op.Priority, op);
						want_async_lookup = false;
					}
				}
			} while (frame.Continue);
		}
		
		public bool HasShutdownStarted {
			get {
				return (flags & Flags.ShutdownStarted) != 0;
			}
		}

		public bool HasShutdownFinished {
			get {
				return (flags & Flags.Shutdown) != 0;
			}
		}

		public void InvokeShutdown ()
		{
			flags |= Flags.ShutdownStarted;
			if (ShutdownStarted != null)
				ShutdownStarted (this, new EventArgs ());
		}

		
		public event EventHandler ShutdownStarted;
	}
}
