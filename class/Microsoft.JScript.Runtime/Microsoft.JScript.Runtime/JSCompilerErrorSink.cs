using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace Microsoft.JScript.Runtime {

	public class JSCompilerErrorSink : ErrorSink {

		public JSCompilerErrorSink ()
		{
		}

		public override void Add (SourceUnit sourceUnit, string message, SourceSpan span, int errorCode, Severity severity)
		{
			base.Add (sourceUnit, message, span, errorCode, severity);
		}
	}
}
