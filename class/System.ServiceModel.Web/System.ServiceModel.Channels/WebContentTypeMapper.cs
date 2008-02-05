using System;

namespace System.ServiceModel.Channels
{
	public abstract class WebContentTypeMapper
	{
		protected WebContentTypeMapper ()
		{
		}

		public abstract WebContentFormat GetMessageFormatForContentType (string contentType);
	}
}
