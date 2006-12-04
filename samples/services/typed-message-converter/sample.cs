using System;
using System.Xml;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

[MessageContract]
public class Test
{
	public static void Main ()
	{
		TypedMessageConverter c = TypedMessageConverter.Create (
			typeof (Test), "http://tempuri.org/MyTest");
		Message msg = c.ToMessage (new Test ());
		MessageBuffer mb = msg.CreateBufferedCopy (10);
		using (XmlWriter w = XmlWriter.Create (Console.Out)) {
			mb.CreateMessage ().WriteMessage (w);
		}
		Test t = (Test) c.FromMessage (mb.CreateMessage ());
	}

	[MessageBodyMember]
	public Echo echo = new Echo ();

	[MessageBodyMember]
	public string body2 = "TEST Body";

	[DataContract]
	public class Echo
	{
		[DataMember]
		public string msg = "default";
	}
}

