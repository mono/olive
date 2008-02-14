//
// WebMessageFormatter.cs
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
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;

namespace System.ServiceModel.Description
{
	internal abstract class WebMessageFormatter
	{
		OperationDescription operation;
		MessageDescription message_desc;
		ServiceEndpoint endpoint;
		UriTemplate template;

		public WebMessageFormatter (OperationDescription operation, ServiceEndpoint endpoint)
		{
			this.operation = operation;
			this.endpoint = endpoint;
			ApplyWebAttribute ();
		}

		void ApplyWebAttribute ()
		{
			MethodInfo mi = operation.SyncMethod ?? operation.BeginMethod;

			object [] atts = mi.GetCustomAttributes (typeof (WebGetAttribute), false);
			WebAttributeInfo info = null;
			if (atts.Length > 0)
				info = ((WebGetAttribute) atts [0]).Info;
			atts = mi.GetCustomAttributes (typeof (WebInvokeAttribute), false);
			if (atts.Length > 0)
				info = ((WebInvokeAttribute) atts [0]).Info;
			if (info == null)
				info = new WebAttributeInfo ();

			template = new UriTemplate (info.UriTemplate ?? BuildUriTemplate ());
			message_desc = GetMessageDescription ();
		}

		public OperationDescription Operation {
			get { return operation; }
		}

		public MessageDescription Message {
			get { return message_desc; }
		}

		public ServiceEndpoint Endpoint {
			get { return endpoint; }
		}

		public UriTemplate UriTemplate {
			get { return template; }
		}

		public abstract MessageDirection MessageDirection { get; }

		string BuildUriTemplate ()
		{
			StringBuilder sb = new StringBuilder ();
			MessageDescription md = GetMessageDescription ();
			sb.Append (Operation.Name);
			for (int i = 0; i < md.Body.Parts.Count; i++) {
				MessagePartDescription mp = md.Body.Parts [i];
				sb.Append (i == 0 ? '?' : '&');
				sb.Append (mp.Name);
				sb.Append ("={");
				sb.Append (mp.Name);
				sb.Append ('}');
			}
			return sb.ToString ();
		}

		MessageDescription GetMessageDescription ()
		{
			foreach (MessageDescription md in operation.Messages)
				if (md.Direction == this.MessageDirection)
					return md;
			throw new SystemException ("INTERNAL ERROR: no corresponding message description for the specified direction: " + MessageDirection);
		}

		internal class RequestClientFormatter : WebMessageFormatter, IClientMessageFormatter
		{
			public RequestClientFormatter (OperationDescription operation, ServiceEndpoint endpoint)
				: base (operation, endpoint)
			{
			}

			public override MessageDirection MessageDirection {
				get { return MessageDirection.Input; }
			}

			public Message SerializeRequest (MessageVersion messageVersion, object [] parameters)
			{
				throw new NotImplementedException ();
			}

			public object DeserializeReply (Message message, object [] parameters)
			{
				throw new NotImplementedException ();
			}
		}

		internal class ReplyClientFormatter : WebMessageFormatter, IClientMessageFormatter
		{
			public ReplyClientFormatter (OperationDescription operation, ServiceEndpoint endpoint)
				: base (operation, endpoint)
			{
			}

			public override MessageDirection MessageDirection {
				get { return MessageDirection.Output; }
			}

			public Message SerializeRequest (MessageVersion messageVersion, object [] parameters)
			{
				throw new NotImplementedException ();
			}

			public object DeserializeReply (Message message, object [] parameters)
			{
				throw new NotImplementedException ();
			}
		}

		internal class RequestDispatchFormatter : WebMessageFormatter, IDispatchMessageFormatter
		{
			public RequestDispatchFormatter (OperationDescription operation, ServiceEndpoint endpoint)
				: base (operation, endpoint)
			{
			}

			public override MessageDirection MessageDirection {
				get { return MessageDirection.Input; }
			}

			public Message SerializeReply (MessageVersion messageVersion, object [] parameters, object result)
			{
				throw new NotImplementedException ();
			}

			public void DeserializeRequest (Message message, object [] parameters)
			{
				throw new NotImplementedException ();
			}
		}

		internal class ReplyDispatchFormatter : WebMessageFormatter, IDispatchMessageFormatter
		{
			public ReplyDispatchFormatter (OperationDescription operation, ServiceEndpoint endpoint)
				: base (operation, endpoint)
			{
			}

			public override MessageDirection MessageDirection {
				get { return MessageDirection.Output; }
			}

			public Message SerializeReply (MessageVersion messageVersion, object [] parameters, object result)
			{
				throw new NotImplementedException ();
			}

			public void DeserializeRequest (Message message, object [] parameters)
			{
				throw new NotImplementedException ();
			}
		}
	}
}
