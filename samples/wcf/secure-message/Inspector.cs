using System;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

	public class StdErrInspectionBehavior : IEndpointBehavior
	{
		public void AddBindingParameters (
			ServiceEndpoint endpoint,
			BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyClientBehavior (ServiceEndpoint endpoint,
			ClientRuntime clientRuntime)
		{
			clientRuntime.MessageInspectors.Add (
				new StdErrInspector ());
		}

		public void ApplyDispatchBehavior (ServiceEndpoint endpoint,
			EndpointDispatcher endpointDispatcher)
		{
			endpointDispatcher.DispatchRuntime.MessageInspectors.Add (
				new StdErrInspector ());
		}

		public void Validate (ServiceEndpoint endpoint)
		{
		}
	}

	public class StdErrInspector : IClientMessageInspector, IDispatchMessageInspector
	{
		XmlWriterSettings s;

		public StdErrInspector ()
		{
			s = new XmlWriterSettings ();
			s.Indent = true;
		}

		public void AfterReceiveReply (ref Message reply, object correlationState)
		{
			MessageBuffer buf = reply.CreateBufferedCopy (0x10000);
			reply = buf.CreateMessage ();
			using (XmlWriter w = XmlWriter.Create (Console.Error, s)) {
				buf.CreateMessage ().WriteMessage (w);
			}
			Console.Error.WriteLine ("======================");
		}

		public object BeforeSendRequest (ref Message request, IClientChannel channel)
		{
			MessageBuffer buf = request.CreateBufferedCopy (0x10000);
			request = buf.CreateMessage ();
			using (XmlWriter w = XmlWriter.Create (Console.Error, s)) {
				buf.CreateMessage ().WriteMessage (w);
			}
			Console.Error.WriteLine ("======================");
			return Guid.NewGuid ();
		}

		public object AfterReceiveRequest (
			ref Message request,
			IClientChannel channel,
			InstanceContext instanceContext)
		{
			MessageBuffer buf = request.CreateBufferedCopy (0x10000);
			request = buf.CreateMessage ();
			using (XmlWriter w = XmlWriter.Create (Console.Error, s)) {
				buf.CreateMessage ().WriteMessage (w);
			}
			Console.Error.WriteLine ("======================");
			return Guid.NewGuid ();
		}

		public void BeforeSendReply (
			ref Message reply,
			Object correlationState)
		{
			MessageBuffer buf = reply.CreateBufferedCopy (0x10000);
			reply = buf.CreateMessage ();
			using (XmlWriter w = XmlWriter.Create (Console.Error, s)) {
				buf.CreateMessage ().WriteMessage (w);
			}
			Console.Error.WriteLine ("======================");
		}
	}


