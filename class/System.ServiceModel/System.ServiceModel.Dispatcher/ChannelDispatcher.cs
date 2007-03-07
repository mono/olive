//
// ChannelDispatcher.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005 Novell, Inc.  http://www.novell.com
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Threading;
using System.Transactions;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace System.ServiceModel.Dispatcher
{
	public class ChannelDispatcher : ChannelDispatcherBase
	{
		ServiceHostBase host;
		ServiceEndpoint service_endpoint;

		string binding_name;
		EndpointDispatcher endpoint_dispatcher;
		Collection<IErrorHandler> error_handlers
			= new Collection<IErrorHandler> ();
		IChannelListener listener;
		IDefaultCommunicationTimeouts timeouts;
		MessageVersion message_version;
		bool receive_sync, include_exception_detail_in_faults,
			manual_addressing, is_tx_receive;
		int max_tx_batch_size;
		SynchronizedCollection<IChannelInitializer> initializers
			= new SynchronizedCollection<IChannelInitializer> ();
		IsolationLevel tx_isolation_level;
		TimeSpan tx_timeout;
		ServiceThrottle throttle;

		Guid identifier = Guid.NewGuid ();
		ManualResetEvent async_event = new ManualResetEvent (false);
		EndpointListenerAsyncResult async_result;

		ListenerLoopManager loop_manager;

		[MonoTODO ("get binding info from config")]
		public ChannelDispatcher (IChannelListener listener)
			: this (listener, null)
		{
		}

		public ChannelDispatcher (
			IChannelListener listener, string bindingName)
			: this (listener, bindingName, 
				DefaultCommunicationTimeouts.Instance)
		{
		}

		public ChannelDispatcher (
			IChannelListener listener, string bindingName,
			IDefaultCommunicationTimeouts timeouts)
		{
			if (listener == null)
				throw new ArgumentNullException ("listener");
			if (bindingName == null)
				throw new ArgumentNullException ("bindingName");
			if (timeouts == null)
				throw new ArgumentNullException ("timeouts");
			this.listener = listener;
			this.binding_name = bindingName;
			this.timeouts = timeouts;
		}

		public string BindingName {
			get { return binding_name; }
		}

		public SynchronizedCollection<IChannelInitializer> ChannelInitializers {
			get { return initializers; }
		}

		protected internal override TimeSpan DefaultCloseTimeout {
			get { return timeouts.CloseTimeout; }
		}

		protected internal override TimeSpan DefaultOpenTimeout {
			get { return timeouts.OpenTimeout; }
		}

		public Collection<IErrorHandler> ErrorHandlers {
			get { return error_handlers; }
		}

		public SynchronizedCollection<EndpointDispatcher> Endpoints {
			get {
				if (host == null)
					throw new InvalidOperationException ("host is not attached yet.");
				return new SynchronizedCollection<EndpointDispatcher> (null, endpoint_dispatcher);
			}
		}

		[MonoTODO]
		public bool IsTransactedAccept {
			get { throw new NotImplementedException (); }
		}

		public bool IsTransactedReceive {
			get { return is_tx_receive; }
			set { is_tx_receive = value; }
		}

		public bool ManualAddressing {
			get { return manual_addressing; }
			set { manual_addressing = value; }
		}

		public int MaxTransactedBatchSize {
			get { return max_tx_batch_size; }
			set { max_tx_batch_size = value; }
		}

		public override ServiceHostBase Host {
			get { return host; }
		}

		public override IChannelListener Listener {
			get { return listener; }
		}

		public MessageVersion MessageVersion {
			get { return message_version; }
			set { message_version = value; }
		}

		public bool ReceiveSynchronously {
			get { return receive_sync; }
			set { receive_sync = value; }
		}

		public bool IncludeExceptionDetailInFaults {
			get { return include_exception_detail_in_faults; }
			set { include_exception_detail_in_faults = value; }
		}

		public ServiceThrottle ServiceThrottle {
			get { return throttle; }
			set { throttle = value; }
		}

		public IsolationLevel TransactionIsolationLevel {
			get { return tx_isolation_level; }
			set { tx_isolation_level = value; }
		}

		public TimeSpan TransactionTimeout {
			get { return tx_timeout; }
			set { tx_timeout = value; }
		}

		protected internal override void Attach (ServiceHostBase host)
		{
			this.host = host;
			ServiceEndpoint se = FindEndpoint ();
			service_endpoint = se;
			// FIXME: raise an error in case endpoint was not found.

			endpoint_dispatcher = new EndpointDispatcher (
				se.Address, se.Contract.Name, se.Contract.Namespace);
			endpoint_dispatcher.ChannelDispatcher = this;
			host.ChannelDispatchers.Add (this);

			foreach (IEndpointBehavior b in se.Behaviors)
				b.ApplyDispatchBehavior (se, endpoint_dispatcher);

			// apply behaviors
			DispatchRuntime db = endpoint_dispatcher.DispatchRuntime;
			foreach (IContractBehavior b in se.Contract.Behaviors)
				b.ApplyDispatchBehavior (se.Contract, se, db);
			foreach (OperationDescription od in se.Contract.Operations) {
				if (!db.Operations.Contains (od.Name))
					PopulateDispatchOperation (db, od);
				foreach (IOperationBehavior ob in od.Behaviors)
					ob.ApplyDispatchBehavior (od, db.Operations [od.Name]);
			}
		}

		void PopulateDispatchOperation (DispatchRuntime db, OperationDescription od)
		{
			string reqA = null, resA = null;
			foreach (MessageDescription m in od.Messages) {
				if (m.Direction == MessageDirection.Input)
					reqA = m.Action;
				else
					resA = m.Action;
			}
			DispatchOperation o =
				od.IsOneWay ?
				new DispatchOperation (db, od.Name, reqA) :
				new DispatchOperation (db, od.Name, reqA, resA);
			bool has_void_reply = false;
			foreach (MessageDescription md in od.Messages) {
				if (md.Direction == MessageDirection.Input &&
				    md.Body.Parts.Count == 1 &&
				    md.Body.Parts [0].Type == typeof (Message))
					o.DeserializeRequest = false;
				if (md.Direction == MessageDirection.Output &&
				    md.Body.ReturnValue != null) {
					if (md.Body.ReturnValue.Type == typeof (Message))
						o.SerializeReply = false;
					else if (md.Body.ReturnValue.Type == typeof (void))
						has_void_reply = true;
				}
			}

			if (o.Action == "*" && o.ReplyAction == "*") {
				//Signature : Message  (Message)
				//	    : void  (Message)
				//FIXME: void (IChannel)
				if (!o.DeserializeRequest && (!o.SerializeReply || has_void_reply))
					db.UnhandledDispatchOperation = o;
			}

			db.Operations.Add (o);
		}

		public override void CloseInput ()
		{
			if (State == CommunicationState.Closed)
				return;
			try {
				try {
					listener.Close ();
				} finally {
					listener = null;
				}
			} finally {
				if (async_result != null)
					async_result.Complete (false);
			}
		}

		protected internal override void Detach (ServiceHostBase host)
		{
			endpoint_dispatcher = null;
			this.host = null;
			host.ChannelDispatchers.Remove (this);
		}

		internal ServiceEndpoint ServiceEndpoint {
			get { return service_endpoint; }
		}

		ServiceEndpoint FindEndpoint ()
		{
			foreach (ServiceEndpoint se in host.Description.Endpoints)
				if (se.Binding.Name == BindingName)
					return se;
			return null;
		}

		protected override void OnAbort ()
		{
			throw new NotImplementedException ();
		}

		protected override IAsyncResult OnBeginClose (TimeSpan timeout,
			AsyncCallback callback, object state)
		{
			async_event.Reset ();
			async_result = new CloseAsyncResult (
				async_event, identifier, timeout,
				callback, state);
			return async_result;
		}

		protected override IAsyncResult OnBeginOpen (TimeSpan timeout,
			AsyncCallback callback, object state)
		{
			async_event.Reset ();
			async_result = new OpenAsyncResult (
				async_event, identifier, timeout,
				callback, state);
			return async_result;
		}

		protected override void OnClose (TimeSpan timeout)
		{
			ProcessClose (timeout);
		}

		protected override void OnClosed ()
		{
			if (host != null)
				Detach (host);
		}

		protected override void OnEndClose (IAsyncResult result)
		{
			if (result == null)
				throw new ArgumentNullException ("result");
			OpenAsyncResult or = result as OpenAsyncResult;
			if (or == null)
				throw new ArgumentException ("Pass an IAsyncResult instance that is returned from BeginOpen().");
			CloseInput ();
			or.AsyncWaitHandle.WaitOne ();
		}

		[MonoTODO ("this is not a real async method.")]
		protected override void OnEndOpen (IAsyncResult result)
		{
			if (result == null)
				throw new ArgumentNullException ("result");
			OpenAsyncResult or = result as OpenAsyncResult;
			if (or == null)
				throw new ArgumentException ("Pass an IAsyncResult instance that is returned from BeginOpen().");
			or.AsyncWaitHandle.WaitOne ();
		}

		protected override void OnOpen (TimeSpan timeout)
		{
			ProcessOpen (timeout);
		}

		[MonoTODO ("what to do here?")]
		protected override void OnOpening ()
		{
		}

		[MonoTODO ("what to do here?")]
		protected override void OnOpened ()
		{
		}

		void ProcessClose (TimeSpan timeout)
		{
			if (loop_manager != null)
				loop_manager.Stop ();
			CloseInput ();
		}

		void ProcessOpen (TimeSpan timeout)
		{
			if (endpoint_dispatcher == null)
				throw new InvalidOperationException ("Service host is not attached to this ChannelDispatcher.");
			try {
				// FIXME: hack, just to make it runnable
				listener.Open (timeout);
				loop_manager = new ListenerLoopManager (this);
				loop_manager.Start ();
			} finally {
				if (async_result != null)
					async_result.Complete (false);
			}
		}

		class ListenerLoopManager
		{
			ChannelDispatcher owner;
			AutoResetEvent handle;
			IReplyChannel reply;
			IInputChannel input;
			bool loop;
			Thread loop_thread;

			public ListenerLoopManager (ChannelDispatcher owner)
			{
				this.owner = owner;
				MethodInfo mi = owner.Listener.GetType ().GetMethod ("AcceptChannel", Type.EmptyTypes);
				object channel = mi.Invoke (owner.Listener, new object [0]);
				reply = channel as IReplyChannel;
				input = channel as IInputChannel;
			}

			public void Start ()
			{
				if (loop_thread == null)
					loop_thread = new Thread (new ThreadStart (StartLoop));
				loop_thread.Start ();
			}

			public void Stop ()
			{
				StopLoop ();
				if (loop_thread.IsAlive)
					loop_thread.Abort ();
				loop_thread = null;
			}

			void StartLoop ()
			{
				try {
					StartLoopCore ();
				} catch (ThreadAbortException) {
					Thread.ResetAbort ();
				}
			}

			void StartLoopCore ()
			{
				loop = true;

				// FIXME: use async WaitForBlah() method so
				// that we can stop them at our own will.

				DispatchRuntime r = owner.endpoint_dispatcher.DispatchRuntime;
				if (reply != null) {
					while (loop) {
						if (reply.WaitForRequest (owner.timeouts.ReceiveTimeout))
							owner.endpoint_dispatcher.ProcessRequest (reply);
					}
				} else if (input != null) {
					while (loop) {
						if (input.WaitForMessage (owner.timeouts.ReceiveTimeout))
							owner.endpoint_dispatcher.ProcessInput (input);
					}
				}
			}

			void StopLoop ()
			{
				loop = false;
				// FIXME: send manual stop for reply or input channel.
			}
		}

		#region AsyncResult classes

		class CloseAsyncResult : EndpointListenerAsyncResult
		{
			public CloseAsyncResult (ManualResetEvent asyncEvent,
				Guid identifier, TimeSpan timeout,
				AsyncCallback callback, object state)
				: base (asyncEvent, identifier, timeout,
					callback, state)
			{
			}
		}

		class OpenAsyncResult : EndpointListenerAsyncResult
		{
			public OpenAsyncResult (ManualResetEvent asyncEvent,
				Guid identifier, TimeSpan timeout,
				AsyncCallback callback, object state)
				: base (asyncEvent, identifier, timeout,
					callback, state)
			{
			}
		}

		abstract class EndpointListenerAsyncResult : IAsyncResult
		{
			ManualResetEvent async_event;
			Guid identifier;
			TimeSpan timeout;
			AsyncCallback callback;
			object state;
			bool completed, completed_async;

			public EndpointListenerAsyncResult (
				ManualResetEvent asyncEvent,
				Guid identifier, TimeSpan timeout,
				AsyncCallback callback, object state)
			{
				async_event = asyncEvent;
				this.identifier = identifier;
				this.timeout = timeout;
				this.callback = callback;
				this.state = state;
			}

			public WaitHandle AsyncWaitHandle {
				get { return async_event; }
			}

			public bool IsCompleted {
				get { return completed; }
			}

			public TimeSpan Timeout {
				get { return timeout; }
			}

			public void Complete (bool async)
			{
				completed_async = async;
				if (callback != null)
					callback (this);
				async_event.Set ();
			}

			public object AsyncState {
				get { return state; }
			}

			public bool CompletedSynchronously {
				get { return completed_async; }
			}
		}
		#endregion
	}
}
