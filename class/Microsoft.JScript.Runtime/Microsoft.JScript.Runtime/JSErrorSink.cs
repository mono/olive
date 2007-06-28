using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace Microsoft.JScript.Runtime {

	public class JSErrorSink : ErrorSink {

		bool throw_exception_on_error;

		public JSErrorSink ()
		{
		}

		public JSErrorSink (bool throwExceptionOnError)
		{
			this.throw_exception_on_error = throwExceptionOnError;
		}

		public override void Add (SourceUnit sourceUnit, string message, SourceSpan span, int errorCode, Severity severity)
		{
			base.Add (sourceUnit, message, span, errorCode, severity);
		}

		public bool ThrowExceptionOnErrror
		{
			get { return throw_exception_on_error; }
			set { throw_exception_on_error = value; }
		}
	}
}
