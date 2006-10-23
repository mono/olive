//
// ConnectionOrientedTransportBindingElement.cs
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
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace System.ServiceModel.Channels
{
	[MonoTODO]
	public abstract class ConnectionOrientedTransportBindingElement
		: TransportBindingElement
	{
		int connection_buf_size, max_buf_size,
			max_inbound_connections, max_outbound,
			max_pending_accepts;
		string connection_pool_group_name;
		HostNameComparisonMode host_cmp_mode;
		TimeSpan idle_timeout, max_output_delay;
		TransferMode transfer_mode;

		internal ConnectionOrientedTransportBindingElement ()
		{
		}

		internal ConnectionOrientedTransportBindingElement (
			ConnectionOrientedTransportBindingElement other)
			: base (other)
		{
			connection_buf_size = other.connection_buf_size;
			max_buf_size = other.max_buf_size;
			max_inbound_connections = other.max_inbound_connections;
			max_outbound = other.max_outbound;
			max_pending_accepts = other.max_pending_accepts;
			connection_pool_group_name =
				other.connection_pool_group_name;
			host_cmp_mode = other.host_cmp_mode;
			idle_timeout = other.idle_timeout;
			max_output_delay = other.max_output_delay;
			transfer_mode = other.transfer_mode;
		}

		public int ConnectionBufferSize {
			get { return connection_buf_size; }
			set { connection_buf_size = value; }
		}

		public string ConnectionPoolGroupName {
			get { return connection_pool_group_name; }
			set { connection_pool_group_name = value; }
		}

		public HostNameComparisonMode HostNameComparisonMode {
			get { return host_cmp_mode; }
			set { host_cmp_mode = value; }
		}

		public TimeSpan IdleTimeout {
			get { return idle_timeout; }
			set { idle_timeout = value; }
		}

		public int MaxBufferSize {
			get { return max_buf_size; }
			set { max_buf_size = value; }
		}

		public int MaxInboundConnections {
			get { return max_inbound_connections; }
			set { max_inbound_connections = value; }
		}

		public int MaxOutboundConnectionsPerEndpoint {
			get { return max_outbound; }
			set { max_outbound = value; }
		}

		public TimeSpan MaxOutputDelay {
			get { return max_output_delay; }
			set { max_output_delay = value; }
		}

		public int MaxPendingAccepts {
			get { return max_pending_accepts; }
			set { max_pending_accepts = value; }
		}

		public TransferMode TransferMode {
			get { return transfer_mode; }
			set { transfer_mode = value; }
		}
	}
}
