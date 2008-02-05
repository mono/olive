using System;

namespace System.ServiceModel.Channels
{
	public sealed class WebBodyFormatMessageProperty : IMessageProperty
	{
		WebContentFormat format;

		public WebBodyFormatMessageProperty (WebContentFormat format)
		{
			this.format = format;
		}

		public const string Name = "WebBodyFormatMessageProperty";

		public WebContentFormat Format {
			get { return format; }
		}

		public IMessageProperty CreateCopy ()
		{
			return (IMessageProperty) MemberwiseClone ();
		}

		public override string ToString ()
		{
			return format.ToString ();
		}
	}
}
