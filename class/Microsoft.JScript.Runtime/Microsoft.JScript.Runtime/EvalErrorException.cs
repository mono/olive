using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class EvalErrorException : Exception {
		public EvalErrorException ()
		{
		}

		public EvalErrorException (string message)
		{
		}

		public EvalErrorException (string message, Exception innerException)
		{
		}
	}
}
