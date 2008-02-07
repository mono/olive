//
// WebHttpBehavior.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
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
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace System.ServiceModel.Description
{
	public class WebHttpBehavior : IEndpointBehavior
	{
		public WebHttpBehavior ()
		{
		}

		[MonoTODO]
		public virtual void AddBindingParameters (ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
		{
		}

		[MonoTODO]
		protected virtual void AddClientErrorInspector (ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
		}

		[MonoTODO]
		protected virtual void AddServerErrorHandlers (ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
		{
		}

		[MonoTODO]
		public virtual void ApplyClientBehavior (ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
		}

		[MonoTODO]
		public virtual void ApplyDispatchBehavior (ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
		{
		}

		[MonoTODO]
		protected virtual WebHttpDispatchOperationSelector GetOperationSelector (ServiceEndpoint endpoint)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected virtual QueryStringConverter GetQueryStringConverter (OperationDescription operationDescription)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected virtual IClientMessageFormatter GetReplyClientFormatter (OperationDescription operationDescription, ServiceEndpoint endpoint)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected virtual IDispatchMessageFormatter GetReplyDispatchFormatter (OperationDescription operationDescription, ServiceEndpoint endpoint)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected virtual IClientMessageFormatter GetRequestClientFormatter (OperationDescription operationDescription, ServiceEndpoint endpoint)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected virtual IDispatchMessageFormatter GetRequestDispatchFormatter (OperationDescription operationDescription, ServiceEndpoint endpoint)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual void Validate (ServiceEndpoint endpoint)
		{
			throw new NotImplementedException ();
		}
	}
}
