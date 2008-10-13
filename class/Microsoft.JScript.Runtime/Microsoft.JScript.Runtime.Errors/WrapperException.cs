using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class WrapperException : Exception {

		public WrapperException ()
		{
		}

		public WrapperException (string message)
		{
		}

		public WrapperException (string message, Exception innerException)
		{
		}

		public override string Message {
			get { return base.Message; }
		}
	}
}
