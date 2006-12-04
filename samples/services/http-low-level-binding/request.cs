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
		IChannelFactory<IRequestChannel> factory =
			el.BuildChannelFactory<IRequestChannel> (
				new BindingContext (new CustomBinding (),
					new BindingParameterCollection ()));

		factory.Open ();

		IRequestChannel request = factory.CreateChannel (
			new EndpointAddress ("http://localhost:37564"));

		request.Open ();

		using (XmlWriter w = XmlWriter.Create (Console.Out)) {
			Message.CreateMessage (MessageVersion.Default, "Echo")
				.WriteMessage (w);
		}
		Console.WriteLine ();

		Message msg = request.Request (
			Message.CreateMessage (MessageVersion.Default, "Echo"),
			TimeSpan.FromSeconds (15));
		using (XmlWriter w = XmlWriter.Create (Console.Out)) {
			msg.WriteMessage (w);
		}
	}
}

