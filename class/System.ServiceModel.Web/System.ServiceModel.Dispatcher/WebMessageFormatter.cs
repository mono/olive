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
using System.Collections.Specialized;
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
		QueryStringConverter converter;
		WebHttpBehavior behavior;
		UriTemplate template;
		WebAttributeInfo info = null;

		public WebMessageFormatter (OperationDescription operation, ServiceEndpoint endpoint, QueryStringConverter converter, WebHttpBehavior behavior)
		{
			this.operation = operation;
			this.endpoint = endpoint;
			this.converter = converter;
			this.behavior = behavior;
			ApplyWebAttribute ();
		}

		void ApplyWebAttribute ()
		{
			MethodInfo mi = operation.SyncMethod ?? operation.BeginMethod;

			object [] atts = mi.GetCustomAttributes (typeof (WebGetAttribute), false);
			if (atts.Length > 0)
				info = ((WebGetAttribute) atts [0]).Info;
			atts = mi.GetCustomAttributes (typeof (WebInvokeAttribute), false);
			if (atts.Length > 0)
				info = ((WebInvokeAttribute) atts [0]).Info;
			if (info == null)
				info = new WebAttributeInfo ();

			template = info.BuildUriTemplate (Operation, GetMessageDescription ());
			message_desc = GetMessageDescription ();
		}

		public WebAttributeInfo Info {
			get { return info; }
		}

		public OperationDescription Operation {
			get { return operation; }
		}

		public MessageDescription MessageDescription {
			get { return message_desc; }
		}

		public QueryStringConverter Converter {
			get { return converter; }
		}

		public ServiceEndpoint Endpoint {
			get { return endpoint; }
		}

		public UriTemplate UriTemplate {
			get { return template; }
		}

		public abstract MessageDirection MessageDirection { get; }

		protected void CheckMessageVersion (MessageVersion messageVersion)
		{
			if (messageVersion == null)
				throw new ArgumentNullException ("messageVersion");

			if (!MessageVersion.None.Equals (messageVersion))
				throw new ArgumentException ("Only MessageVersion.None is supported");
		}

		MessageDescription GetMessageDescription ()
		{
			foreach (MessageDescription md in operation.Messages)
				if (md.Direction == this.MessageDirection)
					return md;
			throw new SystemException ("INTERNAL ERROR: no corresponding message description for the specified direction: " + MessageDirection);
		}

		internal class RequestClientFormatter : WebClientMessageFormatter
		{
			public RequestClientFormatter (OperationDescription operation, ServiceEndpoint endpoint, QueryStringConverter converter, WebHttpBehavior behavior)
				: base (operation, endpoint, converter, behavior)
			{
			}
		}

		internal class ReplyClientFormatter : WebClientMessageFormatter
		{
			public ReplyClientFormatter (OperationDescription operation, ServiceEndpoint endpoint, QueryStringConverter converter, WebHttpBehavior behavior)
				: base (operation, endpoint, converter, behavior)
			{
			}
		}

		internal class RequestDispatchFormatter : WebDispatchMessageFormatter
		{
			public RequestDispatchFormatter (OperationDescription operation, ServiceEndpoint endpoint, QueryStringConverter converter, WebHttpBehavior behavior)
				: base (operation, endpoint, converter, behavior)
			{
			}
		}

		internal class ReplyDispatchFormatter : WebDispatchMessageFormatter
		{
			public ReplyDispatchFormatter (OperationDescription operation, ServiceEndpoint endpoint, QueryStringConverter converter, WebHttpBehavior behavior)
				: base (operation, endpoint, converter, behavior)
			{
			}
		}

		internal abstract class WebClientMessageFormatter : WebMessageFormatter, IClientMessageFormatter
		{
			protected WebClientMessageFormatter (OperationDescription operation, ServiceEndpoint endpoint, QueryStringConverter converter, WebHttpBehavior behavior)
				: base (operation, endpoint, converter, behavior)
			{
			}

			public override MessageDirection MessageDirection {
				get { return MessageDirection.Input; }
			}

			public Message SerializeRequest (MessageVersion messageVersion, object [] parameters)
			{
				if (parameters == null)
					throw new ArgumentNullException ("parameters");
				CheckMessageVersion (messageVersion);

				var c = new NameValueCollection ();

				if (parameters.Length != MessageDescription.Body.Parts.Count)
					throw new ArgumentException ("Parameter array length does not match the number of message body parts");

				for (int i = 0; i < parameters.Length; i++) {
					var p = MessageDescription.Body.Parts [i];
					string name = p.Name.ToUpperInvariant ();
					if (UriTemplate.PathSegmentVariableNames.Contains (name) ||
					    UriTemplate.QueryValueVariableNames.Contains (name))
						c.Add (name, parameters [i] != null ? Converter.ConvertValueToString (parameters [i], parameters [i].GetType ()) : null);
					else
						// FIXME: bind as a message part
						throw new NotImplementedException (String.Format ("parameter {0} is not contained in the URI template {1} {2} {3}", p.Name, UriTemplate, UriTemplate.PathSegmentVariableNames.Count, UriTemplate.QueryValueVariableNames.Count));
				}

				Uri to = UriTemplate.BindByName (Endpoint.Address.Uri, c);

				Message ret = Message.CreateMessage (messageVersion, null);
				ret.Headers.To = to;

				return ret;
			}

			public object DeserializeReply (Message message, object [] parameters)
			{
				if (parameters == null)
					throw new ArgumentNullException ("parameters");
				CheckMessageVersion (message.Version);

				throw new NotImplementedException ();
			}
		}

		internal abstract class WebDispatchMessageFormatter : WebMessageFormatter, IDispatchMessageFormatter
		{
			protected WebDispatchMessageFormatter (OperationDescription operation, ServiceEndpoint endpoint, QueryStringConverter converter, WebHttpBehavior behavior)
				: base (operation, endpoint, converter, behavior)
			{
			}

			public override MessageDirection MessageDirection {
				get { return MessageDirection.Input; }
			}

			public Message SerializeReply (MessageVersion messageVersion, object [] parameters, object result)
			{
				if (parameters == null)
					throw new ArgumentNullException ("parameters");
				CheckMessageVersion (messageVersion);

				throw new NotImplementedException ();
			}

			public void DeserializeRequest (Message message, object [] parameters)
			{
				if (parameters == null)
					throw new ArgumentNullException ("parameters");
				CheckMessageVersion (message.Version);

				throw new NotImplementedException ();
			}
		}
	}
}
