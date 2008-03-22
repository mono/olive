using System;
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
		BindingContext bc = new BindingContext (
			new CustomBinding (),
			new BindingParameterCollection (),
			new Uri ("http://localhost:37564"),
			String.Empty, ListenUriMode.Explicit);
		IChannelListener<IReplyChannel> listener =
			el.BuildChannelListener<IReplyChannel> (bc);

		listener.Open ();

		IReplyChannel reply = listener.AcceptChannel ();

		reply.Open ();

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

