using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class URIErrorException : Exception {
		public URIErrorException ()
		{
		}

		public URIErrorException (string message)
		{
		}

		public URIErrorException (string message, Exception innerException)
		{
		}
	}
}
