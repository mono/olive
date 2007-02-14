//
// DispatchOperation.cs
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
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;

namespace System.ServiceModel.Dispatcher
{
	[MonoTODO]
	public sealed class DispatchOperation
	{
		internal class DispatchOperationCollection :
			SynchronizedKeyedCollection<string, DispatchOperation>
		{
			protected override string GetKeyForItem (DispatchOperation o)
			{
				return o.Name;
			}
		}

		DispatchRuntime parent;
		string name, action, reply_action;
		bool serialize_reply = true, deserialize_request = true,
			is_oneway, is_terminating,
			release_after_call, release_before_call,
			tx_auto_complete, tx_required;
		ImpersonationOption impersonation;
		IDispatchMessageFormatter formatter, actual_formatter;
		IOperationInvoker invoker;
		SynchronizedCollection<IParameterInspector> inspectors
			= new SynchronizedCollection<IParameterInspector> ();
		SynchronizedCollection<FaultContractInfo> fault_contract_infos
			= new SynchronizedCollection<FaultContractInfo> ();
		SynchronizedCollection<ICallContextInitializer> ctx_initializers
			= new SynchronizedCollection<ICallContextInitializer> ();
		OperationDescription description;

		public DispatchOperation (DispatchRuntime parent,
			string name, string action)
		{
			if (parent == null)
				throw new ArgumentNullException ("parent");
			if (name == null)
				throw new ArgumentNullException ("name");
			// action could be null

			is_oneway = true;
			this.parent = parent;
			this.name = name;
			this.action = action;
		}

		public DispatchOperation (DispatchRuntime parent,
			string name, string action, string replyAction)
			: this (parent, name, action)
		{
			// replyAction could be null
			is_oneway = false;
			reply_action = replyAction;
		}

		public string Action {
			get { return action; }
		}

		public SynchronizedCollection<ICallContextInitializer> CallContextInitializers {
			get { return ctx_initializers; }
		}

		public bool DeserializeRequest {
			get { return deserialize_request; }
			set { deserialize_request = value; }
		}

		public SynchronizedCollection<FaultContractInfo> FaultContractInfos {
			get { return fault_contract_infos; }
		}

		public IDispatchMessageFormatter Formatter {
			get { return formatter; }
			set {
				formatter = value;
				actual_formatter = null;
			}
		}

		public ImpersonationOption Impersonation {
			get { return impersonation; }
			set { impersonation = value; }
		}

		public IOperationInvoker Invoker {
			get { return invoker; }
			set { invoker = value; }
		}

		public bool IsOneWay {
			get { return is_oneway; }
		}

		public bool IsTerminating {
			get { return is_terminating; }
			set { is_terminating = value; }
		}

		public string Name {
			get { return name; }
		}

		public SynchronizedCollection<IParameterInspector> ParameterInspectors {
			get { return inspectors; }
		}

		public DispatchRuntime Parent {
			get { return parent; }
		}

		public bool ReleaseInstanceAfterCall {
			get { return release_after_call; }
			set { release_after_call = value; }
		}

		public bool ReleaseInstanceBeforeCall {
			get { return release_before_call; }
			set { release_before_call = value; }
		}

		public string ReplyAction {
			get { return reply_action; }
		}

		public bool SerializeReply {
			get { return serialize_reply; }
			set { serialize_reply = value; }
		}

		public bool TransactionAutoComplete {
			get { return tx_auto_complete; }
			set { tx_auto_complete = value; }
		}

		public bool TransactionRequired {
			get { return tx_required; }
			set { tx_required = value; }
		}

		MessageVersion MessageVersion {
			get { return Parent.ChannelDispatcher.MessageVersion; }
		}

		OperationDescription Description {
			get {
				EndpointDispatcher ed = Parent.EndpointDispatcher;
				if (ed == null)
					throw new Exception ("INTERNAL ERROR: EndpointDispatcher is not bound yet.");
				if (Parent.ChannelDispatcher == null)
					throw new Exception ("INTERNAL ERROR: ChannelDispatcher is not bound yet.");
				ContractDescription cd = ed.ChannelDispatcher.Host.GetContract (ed.ContractName, ed.ContractNamespace);
				if (cd == null)
					throw new Exception (String.Format ("INTERNAL ERROR: Contact {0} in namespace {1} not found.", ed.ContractName, ed.ContractNamespace));
				OperationDescription od =
					Name != "*" ? cd.Operations.Find (Name) :
					cd.Operations.Count > 0 ? cd.Operations [0] :
					null;
				if (od == null) {
					if (Name == "*")
						throw new Exception (String.Format ("INTERNAL ERROR: Contract {0} in namespace {1} does not contain Operations.", cd.Name, cd.Namespace));
					else
						throw new Exception (String.Format ("INTERNAL ERROR: Operation {0} was not found.", Name));
				}
				return od;
			}
		}

		IDispatchMessageFormatter GetFormatter ()
		{
			if (actual_formatter == null) {
				if (Formatter != null)
					actual_formatter = Formatter;
				else
					actual_formatter = new DefaultMessageOperationFormatter (Description);
			}
			return actual_formatter;
		}

		// Utility methods used by ChannelDispatcher.

		internal Message ProcessRequest (Message req)
		{
			try {
				return DoProcessRequest (req);
			} catch (Exception ex) {
Console.WriteLine (ex);
				// FIXME: set correct name
				FaultCode fc = new FaultCode (
					"FIXME_InternalError",
					req.Version.Addressing.Namespace);
				string reason =
					parent.ChannelDispatcher.IncludeExceptionDetailInFaults ?
					ex.ToString () :
					String.Empty;
				// FIXME: set correct namespace URI
				// FIXME: use ExceptionDetails to make Exception serializable.
				return Message.CreateMessage (req.Version, fc,
					"An internal error occured.", reason, req.Headers.Action);

			}
		}

		Message DoProcessRequest (Message req)
		{
			object instance = null;
			if (parent.InstanceContextProvider != null) {
				InstanceContext ictx = parent.InstanceContextProvider.GetExistingInstanceContext (req, null);
				if (ictx == null)
					//FIXME: What should be done here?
					return CreateActionNotSupported (req);
				instance = ictx.GetServiceInstance ();
			} else {
				instance = parent.InstanceProvider != null ?
					parent.InstanceProvider.GetInstance (OperationContext.Current.InstanceContext, req) :
					// FIXME: this is hack to make simple things work.
					Activator.CreateInstance (Parent.ChannelDispatcher.Host.Description.ServiceType);
			}

			object [] inputs;
			if (DeserializeRequest) {
				if (Invoker != null)
					inputs = Invoker.AllocateInputs ();
				else {
					/*if (!Parent.EndpointDispatcher.ContractFilter.Match (req))
						return CreateActionNotSupported (req);*/

					MessageDescription md = Description.Messages.Find (req.Headers.Action);
					if (md == null)
						return CreateActionNotSupported (req);
					inputs = new object [md.Body.Parts.Count];
				}
				GetFormatter ().DeserializeRequest (req, inputs);
			}
			else
				inputs = new object [] {req};

			object [] outputs;
			object result;

			object [] ctx_initialization_results =
				new object [CallContextInitializers.Count];

			for (int i = 0; i < ctx_initialization_results.Length; i++)
				// FIXME: get IClientChannel from somewhere.
				ctx_initialization_results [i] =
					CallContextInitializers [i].BeforeInvoke (OperationContext.Current.InstanceContext, null, req);

			if (Invoker != null)
				result = Invoker.Invoke (instance, inputs, out outputs);
			else {
				object [] fullargs = new object [Description.SyncMethod.GetParameters ().Length];
				Array.Copy (inputs, fullargs, inputs.Length);
				// FIXME: support async method
				result = Description.SyncMethod.Invoke (instance, fullargs);
				outputs = new object [fullargs.Length - inputs.Length];
				Array.Copy (
					outputs, 0, fullargs, inputs.Length,
					outputs.Length);
			}

			for (int i = 0; i < ctx_initialization_results.Length; i++)
				CallContextInitializers [i].AfterInvoke (ctx_initialization_results [i]);

			if (SerializeReply)
				return GetFormatter ().SerializeReply (
					MessageVersion, outputs, result);
			else
				return (Message) result;
		}

		Message CreateActionNotSupported (Message req)
		{
			FaultCode fc = new FaultCode (
				req.Version.Addressing.ActionNotSupported,
				req.Version.Addressing.Namespace);
			// FIXME: set correct namespace URI
			return Message.CreateMessage (req.Version, fc,
				String.Format ("action '{0}' is not supported in this service contract.", req.Headers.Action), String.Empty);
		}

		internal void ProcessInput (Message req)
		{
			object instance = parent.InstanceProvider != null ?
				parent.InstanceProvider.GetInstance (OperationContext.Current.InstanceContext, req) : null;

			object [] inputs;
			if (DeserializeRequest) {
				// FIXME: invoker and formatter could be null.
				inputs = Invoker.AllocateInputs ();
				Formatter.DeserializeRequest (req, inputs);
			}
			else
				inputs = new object [] {req};
			object [] outputs;
			if (Invoker != null)
				Invoker.Invoke (instance, inputs, out outputs);
			else {
				object [] fullargs = new object [Description.SyncMethod.GetParameters ().Length];
				Array.Copy (inputs, fullargs, inputs.Length);
				Description.SyncMethod.Invoke (instance, fullargs);
			}
		}
	}
}
