//
// EndpointDispatcher.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005-2006 Novell, Inc.  http://www.novell.com
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
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace System.ServiceModel.Dispatcher
{
	public class EndpointDispatcher
	{
		EndpointAddress address;
		string contract_name, contract_ns;
		ChannelDispatcher channel_dispatcher;
		MessageFilter address_filter;
		MessageFilter contract_filter;
		int filter_priority;
		DispatchRuntime dispatch_runtime;

		// Umm, this API is ugly, since it or its members will
		// anyways require ServiceEndpoint, those arguments are
		// likely to be replaced by ServiceEndpoint (especially
		// considering about possible EndpointAddress inconsistency).
		public EndpointDispatcher (EndpointAddress address,
			string contractName, string contractNamespace)
		{
			if (contractName == null)
				throw new ArgumentNullException ("contractName");
			if (contractNamespace == null)
				throw new ArgumentNullException ("contractNamespace");
			if (address == null)
				throw new ArgumentNullException ("address");

			this.address = address;
			contract_name = contractName;
			contract_ns = contractNamespace;

			dispatch_runtime = new DispatchRuntime (this);
			address_filter = new EndpointAddressMessageFilter (address);

			//FIXME: Use ActionMessageFilter here, get action?
			contract_filter = new MatchNoneMessageFilter ();
		}

		public DispatchRuntime DispatchRuntime {
			get { return dispatch_runtime; }
		}

		public string ContractName {
			get { return contract_name; }
		}

		public string ContractNamespace {
			get { return contract_ns; }
		}

		public ChannelDispatcher ChannelDispatcher {
			get { return channel_dispatcher; }
			internal set { channel_dispatcher = value; }
		}

		public MessageFilter AddressFilter {
			get { return address_filter; }
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				address_filter = value;
			}
		}

		public MessageFilter ContractFilter {
			get { return contract_filter; }
			set {
				if (value == null)
					throw new ArgumentNullException ("value");
				contract_filter = value;
			}
		}

		public EndpointAddress EndpointAddress {
			get { return address; }
		}

		public int FilterPriority {
			get { return filter_priority; }
			set { filter_priority = value; }
		}

		#region communication processing

		internal void ProcessRequest (IReplyChannel reply)
		{
			try {
				DoProcessRequest (reply);
			} catch (Exception ex) {
Console.WriteLine (ex);
				HandleError (ex);
			}
		}

		void DoProcessRequest (IReplyChannel reply)
		{
			ServiceEndpoint se = channel_dispatcher.ServiceEndpoint;
			IServiceChannel cch = new ServiceRuntimeChannel (se, reply);
			using (OperationContextScope scope = new OperationContextScope (cch)) {
				OperationContext.Current.EndpointDispatcher = this;
				RequestContext rc = reply.ReceiveRequest (se.Binding.ReceiveTimeout);
				if (rc == null)
					throw new InvalidOperationException ("The reply channel didn't return RequestContext");
				OperationContext.Current.RequestContext = rc;
				// This covers some kind of extra consideration
				// to catch errors and replies SOAP fault. It
				// still depends on the channel implementation
				// to not raise errors instead of replying
				// fault at Reply() though ...
				try {
					ProcessRequestCore (reply, cch, rc);
				} catch (Exception ex) {
					FaultConverter fc = FaultConverter.GetDefaultFaultConverter (channel_dispatcher.MessageVersion);
					Message fault;
					if (fc.TryCreateFaultMessage (ex, out fault))
						rc.Reply (fault, se.Binding.SendTimeout);
					else
						throw;
				}
			}
		}

		void ProcessRequestCore (IReplyChannel reply, IServiceChannel cch, RequestContext rc)
		{
			ServiceEndpoint se = channel_dispatcher.ServiceEndpoint;
			if (IsMessageFilteredOut (rc.RequestMessage))
				throw new EndpointNotFoundException (String.Format ("The request message has the target '{0}' which is not reachable in this service contract", rc.RequestMessage.Headers.To));

			Message req = rc.RequestMessage;
			DispatchOperation op = GetOperation (req);
			Message res = op.ProcessRequest (req);
			if (res == null)
				throw new InvalidOperationException (String.Format ("The operation '{0}' returned a null message.", op.Action));
			rc.Reply (res, se.Binding.SendTimeout);
		}

		internal void ProcessInput (IInputChannel input)
		{
			try {
				DoProcessInput (input);
			} catch (Exception ex) {
Console.WriteLine (ex);
				HandleError (ex);
			}
		}

		void DoProcessInput (IInputChannel input)
		{
			ServiceEndpoint se = channel_dispatcher.ServiceEndpoint;
			IServiceChannel cch = new ServiceRuntimeChannel (se, input);
			using (OperationContextScope scope = new OperationContextScope (cch)) {
				OperationContext.Current.EndpointDispatcher = this;
				// IInputChannel is simpler since it does
				// not have to return SOAP Fault.

				Message msg = input.Receive (se.Binding.ReceiveTimeout);
				if (IsMessageFilteredOut (msg))
					throw new EndpointNotFoundException (String.Format ("The input message has the target '{0}' which is not reachable in this service contract", msg.Headers.To));

				DispatchOperation op = GetOperation (msg);
				op.ProcessInput (msg);
			}
		}

		bool IsMessageFilteredOut (Message req)
		{
			Uri to = req.Headers.To;
			if (to == null)
				return false;
			if (to.AbsoluteUri == Constants.WsaAnonymousUri)
				return false;
			return !AddressFilter.Match (req);
		}

		DispatchOperation GetOperation (Message input)
		{
			if (DispatchRuntime.OperationSelector != null) {
				string name = DispatchRuntime.OperationSelector.SelectOperation (ref input);
				foreach (DispatchOperation d in DispatchRuntime.Operations)
					if (d.Name == name)
						return d;
			} else {
				string action = input.Headers.Action;
				foreach (DispatchOperation d in DispatchRuntime.Operations)
					if (d.Action == action)
						return d;
			}

			return DispatchRuntime.UnhandledDispatchOperation;
		}
		
		void HandleError (Exception ex)
		{
			foreach (IErrorHandler handler in channel_dispatcher.ErrorHandlers)
				if (handler.HandleError (ex))
					break;
		}

		#endregion
	}
}
