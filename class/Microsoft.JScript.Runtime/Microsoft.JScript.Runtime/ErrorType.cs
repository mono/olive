using System;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public enum ErrorType {
		OtherError,
		Error,
		EvalError,
		RangeError,
		ReferenceError,
		SyntaxError,
		TypeError,
		URIError
	}
}
