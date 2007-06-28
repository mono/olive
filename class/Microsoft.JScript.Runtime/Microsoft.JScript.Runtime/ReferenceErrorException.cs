using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class ReferenceErrorException : Exception {
		public ReferenceErrorException ()
		{
		}

		public ReferenceErrorException (string message)
		{
		}

		public ReferenceErrorException (string message, Exception innerException)
		{
		}
	}
}
