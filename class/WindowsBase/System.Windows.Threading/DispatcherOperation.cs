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

	public sealed class DispatcherOperation {
		DispatcherOperationStatus status;
		DispatcherPriority priority;
		Dispatcher dispatcher;
		Task task;
		object result;
		
		internal DispatcherOperation (Dispatcher dis, DispatcherPriority prio, Task t)
		{
			dispatcher = dis;
			priority = prio;
			status = DispatcherOperationStatus.Pending;
			task = t;
		}
	
		public bool Abort ()
		{
			throw new NotImplementedException ();
		}

		public DispatcherOperationStatus Status {
			get {
				return status;
			}
		}

		public Dispatcher Dispatcher {
			get {
				return dispatcher;
			}
		}

		public DispatcherPriority Priority {
			get {
				return priority;
			}

			set {
				priority = value;
			}
		}

		public object Result {
			get {
				return result;
			}
		}

		public DispatcherOperationStatus Wait ()
		{
			if (status == DispatcherOperationStatus.Executing)
				throw new InvalidOperationException ("Already executing");

			throw new NotImplementedException ();
		}

		public DispatcherOperationStatus Wait (TimeSpan timeout)
		{
			if (status == DispatcherOperationStatus.Executing)
				throw new InvalidOperationException ("Already executing");

			throw new NotImplementedException ();
		}
		
		public event EventHandler Aborted;
		public event EventHandler Completed;	}
}
