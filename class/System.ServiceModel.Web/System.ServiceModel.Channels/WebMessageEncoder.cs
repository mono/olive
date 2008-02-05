using System;
using System.IO;
using System.ServiceModel;

namespace System.ServiceModel.Channels
{
	internal class WebMessageEncoder : MessageEncoder
	{
		WebMessageEncodingBindingElement source;

		public WebMessageEncoder (WebMessageEncodingBindingElement source)
		{
			this.source = source;
		}

		public override string ContentType {
			get { return MediaType + "; charset=" + source.WriteEncoding.HeaderName; }
		}

		// FIXME: find out how it can be customized.
		public override string MediaType {
			get { return "application/xml"; }
		}

		public override MessageVersion MessageVersion {
			get { return MessageVersion.None; }
		}

		public override Message ReadMessage (ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
		{
			throw new NotImplementedException ();
		}

		public override Message ReadMessage (Stream stream, int maxSizeOfHeaders, string contentType)
		{
			throw new NotImplementedException ();
		}

		public override void WriteMessage (Message message, Stream stream)
		{
			throw new NotImplementedException ();
		}

		public override ArraySegment<byte> WriteMessage (Message message, int maxMessageSize, BufferManager bufferManager,
								 int messageOffset)
		{
			throw new NotImplementedException ();
		}
	}
}
