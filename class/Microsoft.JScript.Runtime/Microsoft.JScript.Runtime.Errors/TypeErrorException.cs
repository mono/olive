using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class TypeErrorException : Exception {
		public TypeErrorException ()
		{
		}

		public TypeErrorException (string message)
		{
		}

		public TypeErrorException (string message, Exception innerException)
		{
		}
	}
}
