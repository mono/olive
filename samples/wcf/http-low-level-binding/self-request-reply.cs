using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading;
using System.Xml;

public class Test
{
	public static void Main ()
	{
		HttpTransportBindingElement el =
			new HttpTransportBindingElement ();
		IChannelListener<IReplyChannel> listener =
			el.BuildChannelListener<IReplyChannel> (
				new BindingContext (new CustomBinding (),
					new BindingParameterCollection (),
					new Uri ("http://localhost:37564"),
					String.Empty, ListenUriMode.Explicit));
		IChannelFactory<IRequestChannel> factory =
			el.BuildChannelFactory<IRequestChannel> (
				new BindingContext (new CustomBinding (),
					new BindingParameterCollection ()));

		listener.Open ();
		factory.Open ();

		IRequestChannel request = factory.CreateChannel (
			new EndpointAddress ("http://localhost:37564"));
		IReplyChannel reply = listener.AcceptChannel ();

		reply.Open ();
		request.Open ();

		new Thread (delegate () { try { RunListener (reply); } catch (Exception ex) { Console.WriteLine (ex); } }).Start ();
		Message msg = request.Request (Message.CreateMessage (
			MessageVersion.Default, "Echo"), TimeSpan.FromSeconds (15));
		XmlWriterSettings settings = new XmlWriterSettings ();
		settings.OmitXmlDeclaration = true;
		StringWriter sw = new StringWriter ();
		using (XmlWriter w = XmlWriter.Create (sw, settings)) {
			msg.WriteMessage (w);
		}
		Console.WriteLine (sw);
	}

	static void RunListener (IReplyChannel reply)
	{
		if (!reply.WaitForRequest (TimeSpan.FromSeconds (10))) {
			Console.WriteLine ("No request reached here.");
			return;
		}
		Console.WriteLine ("Receiving request ...");
		RequestContext ctx = reply.ReceiveRequest ();
		if (ctx == null)
			return;
		Console.WriteLine ("Starting reply ...");
		ctx.Reply (Message.CreateMessage (MessageVersion.Default, "Ack"));
	}
}

