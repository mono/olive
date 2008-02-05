using System;
using System.ServiceModel;

namespace System.ServiceModel.Channels
{
	internal class WebMessageEncoderFactory : MessageEncoderFactory
	{
		MessageEncoder encoder;

		public WebMessageEncoderFactory (WebMessageEncodingBindingElement source)
		{
			encoder = new WebMessageEncoder (source);
		}

		public override MessageEncoder Encoder {
			get { return encoder; }
		}

		public override MessageVersion MessageVersion {
			get { return MessageVersion.None; }
		}
	}
}
